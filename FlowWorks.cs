using FlowWorks;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace FlowWorks
{
    class FlowWorks
    {
        private int comportNum;
        private Writer writer;
        private Reader reader;
        private Config config;
        public volatile ConnectionManager connectionManager;
        public DeviceData deviceData;   // updated on each new status read from the device
        private DeviceStatus deviceStatus;   // updated on each new status read from the device
        //private bool deviceConnected;
        // constants
        private readonly int kDefaultComportNum;
        private readonly int kDefaultDataRequestInterval;
        //private readonly int kStreamingTimeout;
        // objects
        private Form1 form;
        public volatile SerialPort serialPort;
        public bool streamingPaused;
        private bool dataPending;
        private int dataRequestIntervalmsecs;

        // constructor
        public FlowWorks(Form1 f)
        {
            // constants
            this.kDefaultComportNum = 3;
            this.kDefaultDataRequestInterval = 100;
            // how long do we wait for feedback
            //this.kStreamingTimeout = 4; // was 2;
            this.form = f;

            // load settings
            this.config = new Config("FlowWorks.cfg");
            this.LoadSettings();

            // components
            string comportName = "COM" + this.comportNum.ToString();
            this.serialPort = new SerialPort(comportName, 115200, Parity.None, 8, StopBits.One);
            this.connectionManager = new ConnectionManager(serialPort, this.EventNotification, this.StatusNotification);
            this.writer = new Writer(serialPort, this.EventNotification);
            this.reader = new Reader(serialPort, this.EventNotification, this.DeviceResponseReceived, this.DeviceDataReceived, this.DeviceStatusReceived, this.form);

            // settings

            // initial state
            this.deviceData = new DeviceData();
            this.streamingPaused = true;
            this.dataRequestIntervalmsecs = kDefaultDataRequestInterval;  // default data request interval is 100 msecs

            // launch background threads
            Thread connectionMgrThread = new Thread(new ThreadStart(this.connectionManager.Run));
            connectionMgrThread.IsBackground = true;
            connectionMgrThread.Start();
            Thread writeThread = new Thread(new ThreadStart(this.writer.Run));
            writeThread.IsBackground = true;
            writeThread.Start();
            Thread readThread = new Thread(new ThreadStart(this.reader.Run));
            readThread.IsBackground = true;
            readThread.Start();
            //Thread heartbeatThread = new Thread(new ThreadStart(this.heartbeatGenerator.Run));
            //heartbeatThread.IsBackground = true;
            //heartbeatThread.Start();
            //Thread timestampThread = new Thread(new ThreadStart(this.timeStampUpdate));
            //timestampThread.IsBackground = true;
            //timestampThread.Start();
            Thread dataRequestThread = new Thread(new ThreadStart(this.dataRequestUpdate));
            dataRequestThread.IsBackground = true;
            dataRequestThread.Start();
            Thread statusRequestThread = new Thread(new ThreadStart(this.statusRequestUpdate));
            statusRequestThread.IsBackground = true;
            statusRequestThread.Start();

            this.streamingPaused = false;
        }
        // This function sends commands to the target to retrieve data information
        // It runs in a thread, constantly sending the command
        void dataRequestUpdate()
        {
            while (true)
            {
                if (this.reader.ConnectionIsOpen) // && this.deviceConnected)
                {
                    // This means we request data every 100 msecs (default)
                    Thread.Sleep(dataRequestIntervalmsecs);
                    if ((!this.dataPending) && !(streamingPaused))
                    {
                        this.dataPending = true;
                        this.reader.DiscardBytes();
                        this.reader.updateTimeStamp();
                        //Console.WriteLine(DateTime.UtcNow.ToString("HH:mm:ss.fff") + " dataRequestUpdate");
                        this.writer.AddTerminalCommand("sendData");
                    }
                }
            }
        }
        // This function sends commands to the target to retrieve data information
        // It runs in a thread, constantly sending the command
        void statusRequestUpdate()
        {
            while (true)
            {
                if (this.reader.ConnectionIsOpen) // && this.deviceConnected)
                {
                    if ((!this.dataPending) && !(streamingPaused))
                    {
                        this.dataPending = true;
                        this.reader.DiscardBytes();
                        this.reader.updateTimeStamp();
                        //Console.WriteLine(DateTime.UtcNow.ToString("HH:mm:ss.fff") + " statusRequestUpdate");
                        this.writer.AddTerminalCommand("sendStatus");
                    }
                    // This means we request data every 1000 msecs
                    Thread.Sleep(500);
                }
            }
        }
        private void LoadSettings()
        {
            this.config.Load();
            this.comportNum = this.config.Get("comport", this.kDefaultComportNum);
        }
        public void SendTime()
        {
            DateTime timeStamp = DateTime.Now;
            string sendString = "setTime(" + timeStamp.Hour + ":" + timeStamp.Minute + ":" + timeStamp.Second + ")";
            this.writer.AddTerminalCommand(sendString);
            sendString = "setdate(" + timeStamp.Month + "/" + timeStamp.Day + "/" + (timeStamp.Year - 2000) + ")";
            this.writer.AddTerminalCommand(sendString);
        }
        public int ComportNum
        {
            get { return this.comportNum; }
            set
            {
                this.comportNum = value;
                this.SaveSettings();   // save the new comport num to config file
                this.connectionManager.ConnectionOpenerEnabled = false;
                this.connectionManager.CloseConnection();
                string comportName = "COM" + value.ToString();
                this.connectionManager.ChangeComport(comportName);
                this.ResetState();
                this.connectionManager.ConnectionOpenerEnabled = true;
            }
        }

        private void ResetState()
        {
            this.writer.Reset();
            this.reader.Reset();
        }
        public void AddTerminalCommand(string command)
        {
            this.streamingPaused = true;
            // Pause the request interval
            this.dataRequestIntervalmsecs = 1000;
            this.writer.AddTerminalCommand(command);
        }
        private void SaveSettings()
        {
            this.config.Add("comport", this.comportNum);
            this.config.Save();
        }
        public void EventNotification(ConnectionManager.Event e)
        {
            switch (e)
            {
                case ConnectionManager.Event.MadeConnection:
                    this.reader.ConnectionIsOpen = true;
                    this.writer.Enabled = true;
                    // Clear out any characters by send <CR>
                    this.writer.AddTerminalCommand("\n");
                    // Once port is open, set the time first
                    SendTime();
                    break;
                case ConnectionManager.Event.DeviceNotDetected:
                    //this.PostErrorToUI("Device not detected");
                    break;
            }
        }
        public void EventNotification(Writer.Event e)
        {
            switch (e)
            {
                case Writer.Event.WriteFailed:
                    this.CloseConnection();
                    this.PostErrorToUI("Comport write failure... connection closed");
                    break;
            }
        }
        public void EventNotification(Reader.Event e)
        {
            //bool devReady = (e == Reader.Event.DeviceReady);
            //this.writer.Enabled = devReady;
            switch (e)
            {
                case Reader.Event.DeviceReady:
                    // when device becomes ready, immediately send a heartbeat.  Then enable image streaming.
                    this.writer.Enabled = true;
                   // this.heartbeatGenerator.SendHeartbeat();
                   // this.deviceConnected = true;
                    this.dataPending = false;
                    break;
                case Reader.Event.ReadFailure:
                    this.CloseConnection();
                    break;
                case Reader.Event.ResetStream:
                    Console.WriteLine(DateTime.UtcNow.ToString("HH:mm:ss.fff") + " ResetStream");
                    this.CloseConnection(); // Hard close the port
                                            //would like to delay some time here before setting dataPending false
                    Thread.Sleep(500);
                    break;
            }
        }
        public void DeviceDataReceived(DeviceData deviceData)
        {
            // If streaming is paused, don't save the data from the board - this interferes with trying to change settings
            if (!this.streamingPaused)
            {
                this.deviceData = deviceData;  // save the information locally
                this.PostDeviceDataToUI(deviceData);
            }
        }
        public void DeviceStatusReceived(DeviceStatus deviceStatus)
        {
            this.deviceStatus = deviceStatus;  // save the information locally
            this.PostDeviceStatusToUI(deviceStatus);
        }
        public void DeviceResponseReceived(string s)
        {
            this.PostResponseToUI(s);
            // If we get an "ack" to a given command, un-pause the streaming
            if (s.Contains("Command:"))
            {
                this.streamingPaused = false;
                this.dataPending = false;
                this.dataRequestIntervalmsecs = kDefaultDataRequestInterval;
            }
        }
        private void PostConnectedStatus(bool isConnected)
        {
            if (form.IsHandleCreated)
            {
                form.BeginInvoke(new Form1.BoolParameterDelegate(form.UpdateConnectedSignal), new object[] { isConnected });
            }
        }
        private void PostResponseToUI(string s)
        {
            // use 'Invoke' to block here until the message has been posted.  This will prevent the UI from
            //   getting frozen by a flood of 'post response' requests if the application mistakenly starts
            //   interpreting image data as a text response.
            //form.BeginInvoke(new Form1.StringParameterDelegate(form.UpdateResponse), new object[] { s });
            if (form.IsHandleCreated)
            {
                form.Invoke(new Form1.StringParameterDelegate(form.UpdateResponse), new object[] { s });
            }
        }

        private void PostDeviceDataToUI(DeviceData deviceData)
        {
            if (form.IsHandleCreated)
            {
                form.BeginInvoke(new Form1.DeviceDataParameterDelegate(form.UpdateDeviceData),
                                 new object[] { deviceData });
                this.dataPending = false;
            }
        }
        private void PostDeviceStatusToUI(DeviceStatus deviceStatus)
        {
            if (form.IsHandleCreated)
            {
                form.BeginInvoke(new Form1.DeviceStatusParameterDelegate(form.UpdateDeviceStatus),
                                 new object[] { deviceStatus });
                this.dataPending = false;
            }
        }
        public void StatusNotification(ConnectionManager.Status status)
        {
            bool isConnected = (status == ConnectionManager.Status.Connected);
            this.PostConnectedStatus(isConnected);
            this.reader.ConnectionIsOpen = isConnected;
        }
        private void CloseConnection()
        {
            this.connectionManager.ConnectionOpenerEnabled = false;
            this.connectionManager.CloseConnection();
            //this.deviceConnected = false;
            this.ResetState();
            this.connectionManager.ConnectionOpenerEnabled = true;
        }
        private void PostErrorToUI(string s)
        {
            if (form.IsHandleCreated)
            {
                form.BeginInvoke(new Form1.StringParameterDelegate(form.UpdateErrorMsg), new object[] { s });
            }
        }

    }
    public class DeviceStatus
    {
        // public data
        public int versionMajor;
        public int versionMinor;
        public int versionBuild;
        public int timeHour;
        public int timeMin;
        public int timeSec;
        public int dateMonth;
        public int dateDay;
        public int dateYear;
        public int currentScreen;
        private string boardSerialNumber;
        public double ambientPressure;
        public int o2Status;
        public int o2CalibrationStatus;
        public double batteryCharge;
        public double batteryCurrent;
        public double batteryVoltage;

        public string Status
        {
            set
            {
                string[] dataList = value.Split(',');
                for (int i = 0; i < dataList.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            this.versionMajor = Convert.ToInt32(dataList[i]);
                            break;
                        case 1:
                            this.versionMinor = Convert.ToInt32(dataList[i]);
                            break;
                        case 2:
                            this.versionBuild = Convert.ToInt32(dataList[i]);
                            break;
                        case 3:
                            this.timeHour = Convert.ToInt32(dataList[i]);
                            break;
                        case 4:
                            this.timeMin = Convert.ToInt32(dataList[i]);
                            break;
                        case 5:
                            this.timeSec = Convert.ToInt32(dataList[i]);
                            break;
                        case 6:
                            this.dateMonth = Convert.ToInt32(dataList[i]);
                            break;
                        case 7:
                            this.dateDay = Convert.ToInt32(dataList[i]);
                            break;
                        case 8:
                            this.dateYear = Convert.ToInt32(dataList[i]);
                            break;
                        case 9:
                            this.boardSerialNumber = dataList[i].ToString();
                            break;
                        case 10:
                            this.currentScreen = Convert.ToInt32(dataList[i]);
                            break;
                        case 11:
                            this.ambientPressure = Convert.ToDouble(dataList[i]);
                            break;
                        case 12:
                            this.o2Status = Convert.ToInt32(dataList[i]);
                            break;
                        case 13:
                            this.o2CalibrationStatus = Convert.ToInt32(dataList[i]);
                            break;
                        case 14:
                            this.batteryCharge = Convert.ToDouble(dataList[i]);
                            break;
                        case 15:
                            this.batteryCurrent = Convert.ToDouble(dataList[i]);
                            break;
                        case 16:
                            this.batteryVoltage = Convert.ToDouble(dataList[i]);
                            break;
                    }
                }

            }
        }
    }
    public class DeviceData
    {
        // public data
        public double pressInsp;
        public double pressExp;
        public double flowInsp;
        public double flowOx;
        public double tempDist;
        public double tempProx;
        public double tempHeater;
        public double tempPCB;
        public double fio2;
        public double babyPressure;
        public double flowExp;
        public double flowLeak;
        public double fio2Setpt;
        public double pressSetpt;
        public double pressCkt;
        public int blowerSpeed;
        public int babyPressurePIDEnable;
        public int fio2PIDEnable;
        public double cFactor;
        public int calibrationState;
        public double heatPlateSetpt;
        public double heatWireSetpt;
        public int heatPlatePIDEnable;
        public int heatWirePIDEnable;
        public double o2Sensor;
        public double propValveSetting { get; set; }
        public int blowerSetting { get; set; }
        public string Data
        {
            set
            {
                string[] dataList = value.Split(',');
                for (int i=0; i < dataList.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            this.pressInsp = Convert.ToDouble(dataList[i]);
                            break;
                        case 1:
                            this.pressExp = Convert.ToDouble(dataList[i]);
                            break;
                        case 2:
                            this.flowInsp = Convert.ToDouble(dataList[i]);
                            break;
                        case 3:
                            this.flowOx = Convert.ToDouble(dataList[i]);
                            break;
                        case 4:
                            this.tempDist = Convert.ToDouble(dataList[i]);
                            break;
                        case 5:
                            this.tempProx = Convert.ToDouble(dataList[i]);
                            break;
                        case 6:
                            this.tempHeater = Convert.ToDouble(dataList[i]);
                            break;
                        case 7:
                            this.tempPCB = Convert.ToDouble(dataList[i]);
                            break;
                        case 8:
                            this.fio2 = Convert.ToDouble(dataList[i]);
                            break;
                        case 9:
                            this.babyPressure = Convert.ToDouble(dataList[i]);
                            break;
                        case 10:
                            this.flowExp = Convert.ToDouble(dataList[i]);
                            break;
                        case 11:
                            this.flowLeak = Convert.ToDouble(dataList[i]);
                            break;
                        case 12:
                            this.fio2Setpt = Convert.ToDouble(dataList[i]);
                            if (this.fio2Setpt < 21) this.fio2Setpt = 21;
                            break;
                        case 13:
                            this.pressSetpt = Convert.ToDouble(dataList[i]);
                            if (this.pressSetpt < 3) this.pressSetpt = 3;
                            break;
                        case 14:
                            this.blowerSpeed = Convert.ToInt32(dataList[i]);
                            this.blowerSpeed = (this.blowerSpeed - 70) / 10;
                            break;
                        case 15:
                            this.pressCkt = Convert.ToDouble(dataList[i]);
                            break;
                        case 16:
                            this.propValveSetting = Convert.ToDouble(dataList[i]);
                            break;
                        case 17:
                            this.blowerSetting = Convert.ToInt32(dataList[i]);
                            break;
                        case 18:
                            this.babyPressurePIDEnable = Convert.ToInt32(dataList[i]);
                            break;
                        case 19:
                            this.fio2PIDEnable =  Convert.ToInt32(dataList[i]);
                            break;
                        case 20:
                            this.cFactor = Convert.ToDouble(dataList[i]);
                            break;
                        case 21:
                            this.calibrationState = Convert.ToInt32(dataList[i]);
                            break;
                        case 22:
                            this.heatPlateSetpt = Convert.ToDouble(dataList[i]);
                            break;
                        case 23:
                            this.heatWireSetpt = Convert.ToDouble(dataList[i]);
                            break;
                        case 24:
                            this.heatPlatePIDEnable = Convert.ToInt32(dataList[i]);
                            break;
                        case 25:
                            this.heatWirePIDEnable = Convert.ToInt32(dataList[i]);
                            break;
                        case 26:
                            this.o2Sensor = Convert.ToDouble(dataList[i]);
                            break;
                    }
                }
 
            }
        }

        // event handlers

    }

}

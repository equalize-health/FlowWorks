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
        private DeviceStatus deviceStatus;   // updated on each new status read from the device
        private bool deviceConnected;
        // constants
        private readonly int kDefaultComportNum;
        private readonly int kStreamingTimeout;
        // objects
        private Form1 form;
        public volatile SerialPort serialPort;
        private bool streamingPaused;

        // constructor
        public FlowWorks(Form1 f)
        {
            // constants
            this.kDefaultComportNum = 3;
            // how long do we wait for images
            this.kStreamingTimeout = 4; // was 2;
            this.form = f;

            // load settings
            this.config = new Config("DreamworksViewer.cfg");
            this.LoadSettings();

            // components
            string comportName = "COM" + this.comportNum.ToString();
            this.serialPort = new SerialPort(comportName, 115200, Parity.None, 8, StopBits.One);
            this.connectionManager = new ConnectionManager(serialPort, this.EventNotification, this.StatusNotification);
            this.writer = new Writer(serialPort, this.EventNotification);
            this.reader = new Reader(serialPort, this.EventNotification, this.DeviceResponseReceived, this.DeviceStatusReceived, this.form);

            // settings

            // initial state
            this.deviceStatus = new DeviceStatus();
            this.deviceConnected = false;

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
            //Thread statusRequestThread = new Thread(new ThreadStart(this.statusRequestUpdate));
            //statusRequestThread.IsBackground = true;
            //statusRequestThread.Start();
        }
        private void LoadSettings()
        {
            this.config.Load();
            this.comportNum = this.config.Get("comport", this.kDefaultComportNum);
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
                    break;
                case ConnectionManager.Event.DeviceNotDetected:
                    //this.PostErrorToUI("Device not detected");
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
                    this.deviceConnected = true;
                    //this.imagePending = false;
                    break;
                case Reader.Event.ReadFailure:
                    this.CloseConnection();
                    break;
                case Reader.Event.ResetStream:
                    Console.WriteLine(DateTime.UtcNow.ToString("HH:mm:ss.fff") + " ResetStream");
                    this.CloseConnection(); // Hard close the port
                                            //would like to delay some time here before setting imagePending false
                    Thread.Sleep(500);
                    break;
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

        private void PostDeviceStatusToUI(DeviceStatus deviceStatus)
        {
            if (form.IsHandleCreated)
            {
                form.BeginInvoke(new Form1.DeviceStatusParameterDelegate(form.UpdateDeviceStatus),
                                 new object[] { deviceStatus });
            }
        }
        public void StatusNotification(ConnectionManager.Status status)
        {
            bool isConnected = (status == ConnectionManager.Status.Connected);
            this.PostConnectedStatus(isConnected);
            this.reader.ConnectionIsOpen = isConnected;
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
        private void CloseConnection()
        {
            this.connectionManager.ConnectionOpenerEnabled = false;
            this.connectionManager.CloseConnection();
            this.deviceConnected = false;
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
        public float babyPressure;
        public byte[] Data
        {
            set
            {
                if (value.Length >= 4)
                {
                    this.babyPressure = BitConverter.ToInt32(value, 0);
                }
            }
        }


        public int deviceStatusSize = 92;   //must match size of the Data buffer
        public int dateMonth;
        public int dateDay;
        public int dateYear;
        public int timeHours;
        public int timeMinutes;
        public int timeSeconds;
        public int fwVersionMajor;
        public int fwVersionMinor;
        public int fwVersionRevision;
        // event handlers

    }

}

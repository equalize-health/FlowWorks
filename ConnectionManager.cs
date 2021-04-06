using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace FlowWorks
{
    public class ConnectionManager
    {

        // public enums
        public enum Event
        {
            MadeConnection,
            DeviceNotDetected
        }
        public enum Status
        {
            Connected,
            NotConnected
        }

        // public delegates
        public delegate void EventPublicationFunction(Event e);
        public delegate void StatusPublicationFunction(Status s);

        // public properties
        public bool ConnectionOpenerEnabled
        {
            get { return this.connectionOpenerEnabled; }
            set { this.connectionOpenerEnabled = value; }
        }

        // constructor
        public ConnectionManager(SerialPort port,
                                EventPublicationFunction publishEvent,
                                StatusPublicationFunction publishStatus)
        {
            this.serialPort = port;
            this.PublishEvent = publishEvent;
            this.PublishStatus = publishStatus;
            this.connectionOpenerEnabled = true;
            this.serialPortLock = new Object();
        }
        public void Run()
        {   // endless loop

            while (true)
            {
                // try to establish a com port connection if we don't yet have one
                lock (this.serialPortLock)
                {
                    if (this.connectionOpenerEnabled && !this.serialPort.IsOpen)
                    {
                        try
                        {
                            if (this.serialPort.IsOpen)
                            {
                                this.serialPort.Close();  // Close port if somehow already open
                            }
                            // Print out all port settings on the Console (debugging only)
                            Console.WriteLine("baud " + this.serialPort.BaudRate + " stopbits " + this.serialPort.StopBits + " rtsEnable " + this.serialPort.RtsEnable);
                            Console.WriteLine("Port " + this.serialPort.PortName + " Databits " + this.serialPort.DataBits + " parity " + this.serialPort.Parity + " handshake " + this.serialPort.Handshake);
                            //Console.WriteLine("DataNull " + this.serialPort.DiscardNull + " readTO " + this.serialPort.ReadTimeout + " writeTO " + this.serialPort.WriteTimeout);
                            //Console.WriteLine("dtrEnable " + this.serialPort.DtrEnable + " Parityrepl " + this.serialPort.ParityReplace + " handshake " + this.serialPort.Handshake);

                            this.serialPort.Open();

                            while (!this.serialPort.IsOpen)
                            {
                            }
                            this.PublishEvent(Event.MadeConnection);
                        }
                        catch (Exception ex)
                        {
                            this.PublishEvent(Event.DeviceNotDetected);
                            string msg = ex.Message;
                            Console.WriteLine("Error in ConnectionManager: " + msg);
                            // Pop up a message box on Connection Failure, shows error message

                            //MessageBox.Show("Error: " + msg, "Comport ERROR");
                            Thread.Sleep(1000);
                        }
                    }
                }
                // publish status
                Status status = serialPort.IsOpen ? Status.Connected : Status.NotConnected;
                this.PublishStatus(status);
                Thread.Sleep(200);
            }
        }
        public void ChangeComport(string comportName)
        {
            this.CloseConnection();
            this.serialPort.PortName = comportName;
        }
        public void CloseConnection()
        {
            // disable opener so that connection is not immediately re-opened
            this.connectionOpenerEnabled = false;
            lock (this.serialPortLock)
            {
                try
                {
                    this.serialPort.Close();
                    while (this.serialPort.IsOpen)
                    {
                    }
                }
                catch
                {
                }
            }
        }

        // private
        private SerialPort serialPort;
        private EventPublicationFunction PublishEvent;
        private StatusPublicationFunction PublishStatus;
        private volatile bool connectionOpenerEnabled;
        private volatile Object serialPortLock;
    }
}

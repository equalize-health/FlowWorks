
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace FlowWorks {
  public class Reader
  {
    // public enums
    public enum Event
    {
      DeviceReady,
      ReadFailure,
      ResetStream
    }

    // public delegates
    public delegate void EventPublicationFunction(Event e);
    public delegate void DeviceResponsePublicationFunction(string s);
    public delegate void DeviceDataPublicationFunction(DeviceData deviceData);
    public delegate void DeviceStatusPublicationFunction(DeviceStatus deviceStatus);

    // public properties
    public bool ConnectionIsOpen
    {
      set { this.connectionIsOpen = value; }
      get { return this.connectionIsOpen; }
    }
        public bool DiscardBytes()
        {
        try
        {
            if (!this.serialPort.IsOpen) return false;
            int bytesToRead = this.serialPort.BytesToRead;
            byte[] byteBuffer = new byte[bytesToRead];
            int bytesRead = 0;
            if (bytesToRead == 0) return true;
            if (this.serialPort.BytesToRead > 0)
            {
                bytesRead += this.serialPort.Read(byteBuffer, 0, bytesToRead);
            }
            if (bytesRead != bytesToRead)
            {
                if (DebugPrintsEnabled) Console.WriteLine(" Failed to clear buffer, only read " + bytesRead);
                return false;
            }
            if (DebugPrintsEnabled) Console.WriteLine(DateTime.UtcNow.ToString("HH:mm:ss.fff") + " Clear Buffer, Discarded " + bytesToRead + " bytes " + byteBuffer[0]);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool DebugPrintsEnabled = true;
    public bool ErrorPrintsEnabled = true;

    // constructor
    public Reader(SerialPort port,
                  EventPublicationFunction publishEvent,
                  DeviceResponsePublicationFunction publishResponse,
                  DeviceDataPublicationFunction publishData,
                  DeviceStatusPublicationFunction publishStatus,
                  Form1 form)
    {
      // constants
      this.kDeviceReadyMsg = "senddata";
      this.serialPort = port;

      // initial state
      this.connectionIsOpen = false;
      this.deviceResponse = "";
      this.readingDeviceResponse = false;
      this.lastStreamTime = new DateTime();
      this.serialPort.ReadBufferSize = 8192;

      // publishing functions
      this.PublishEvent = publishEvent;
      this.PublishDeviceResponse = publishResponse;
      this.PublishDataResponse = publishData;
      this.PublishStatusResponse = publishStatus;

      this.formVar = form;
    }
    public void Run()
    {     // endless loop
      byte[] readBuffer = new byte[4];
      bool clearBuffOnce = true;
      while (true)
      {
        if (this.connectionIsOpen)
        {
          try
          {
            // After opening connection, discard whatever is in buffer
            if (clearBuffOnce)
            {
              clearBuffOnce = false;
              this.DiscardBytes();
            }
            // read one byte
            int bytesRead = 0;
            while (bytesRead == 0)
            {
              bytesRead = this.serialPort.Read(readBuffer, 0, 1);
            }
            char c = Convert.ToChar(readBuffer[0]);

            switch (c)
            {
            // CR -- end of message from device
            case '\r':
                if ((this.deviceResponse != this.kDeviceReadyMsg) && (this.deviceResponse != "sendstatus") && (this.deviceResponse.Length > 1))
                {
                    this.PublishDeviceResponse(this.deviceResponse);
                    if (this.deviceResponse.StartsWith(","))
                    {
                        formVar.logData(this.deviceResponse);
                    }

                }
                this.deviceResponse = "";
                this.readingDeviceResponse = false;
                break;

            // newline -- ignore
            case '\n':
                break;
            case '&':
                if (this.readingDeviceResponse)
                {  // normal char inside device response
                    this.deviceResponse += c;
                } else
                {
                    DeviceData deviceData = new DeviceData();

                    if (this.ParseDataStream(ref deviceData))
                    {
                        this.PublishDataResponse(deviceData);
                    }

                }
                break;
            case '!':
                if (this.readingDeviceResponse)
                {  // normal char inside device response
                    this.deviceResponse += c;
                }
                else
                {
                    DeviceStatus deviceStatus = new DeviceStatus();

                    if (this.ParseStatusStream(ref deviceStatus))
                    {
                        this.PublishStatusResponse(deviceStatus);
                    }

                }
                break;
            // normal character -- add to the device response
            default:
                //if the character is not printable (<=0x1F or > 0x7E) except tab 0x09 - then the entire deviceResponse is bogus
                if (c != 0x09 && (c < 0x20 || c > 0x7E))
                {
                this.deviceResponse = "";
                this.readingDeviceResponse = false;
                }
                else
                {
                this.deviceResponse += c;
                this.readingDeviceResponse = true;
                }
                break;
            }

          }
          // if a read error occurred, connection is probably dead; post error msg and close com port
          catch (Exception e)
          {
            this.PublishEvent(Event.ReadFailure);
            if (ErrorPrintsEnabled) Console.WriteLine("Reader thread exception: " + e.Message);
          }
        }
        else
        {
          clearBuffOnce = true;
          // communication not yet established -- wait and try again
          Thread.Sleep(100);
        }
      }
    }

    private bool ParseDataStream(ref DeviceData deviceData)
    {
        //if (this.ReadDataBlock(ref this.deviceStatusDataBuffer, deviceStatus.deviceStatusSize, 100))
        this.deviceStatusDataBuffer = this.serialPort.ReadLine();
        // Log the "sendData" data here, but maybe we don't need to see all that - just avgStream stuff starting with a comma
        //formVar.logData(this.deviceStatusDataBuffer);
        deviceData.Data = this.deviceStatusDataBuffer;
        return true;
    }
    private bool ParseStatusStream(ref DeviceStatus deviceStatus)
    {
        //if (this.ReadDataBlock(ref this.deviceStatusDataBuffer, deviceStatus.deviceStatusSize, 100))
        this.deviceStatusDataBuffer = this.serialPort.ReadLine();

        deviceStatus.Status = this.deviceStatusDataBuffer;
        return true;
    }
    public void Reset()
    {
      this.connectionIsOpen = false;
      this.deviceResponse = "";
      this.readingDeviceResponse = false;
      if (ErrorPrintsEnabled) Console.WriteLine("Reset Read thread ");

    }

    public DateTime getTimeStamp()
    {
      return this.lastStreamTime;
    }
    public void updateTimeStamp()
    {
      this.lastStreamTime = DateTime.Now;
    }
    public void sendReadBufferContinuePacket()
    {
      //byte[] zlpByte = new byte[] { 0, (byte)'\r' };
      byte[] zlpByte = Encoding.ASCII.GetBytes("**HOST_HB\r");
      this.serialPort.Write(zlpByte,0,zlpByte.Length);
      Thread.Sleep(5);
    }

    //
    // private
    //

    // constants
    private readonly string kDeviceReadyMsg;

    // components
    private SerialPort serialPort;
    private Form1 formVar;

    // state
    private volatile bool connectionIsOpen;
    private volatile string deviceResponse;
    private volatile bool readingDeviceResponse;
    private DateTime lastStreamTime;

    // publication functions
    private EventPublicationFunction PublishEvent;
    private DeviceResponsePublicationFunction PublishDeviceResponse;

    public DeviceDataPublicationFunction PublishDataResponse { get; }
    public DeviceStatusPublicationFunction PublishStatusResponse { get; }

    // read buffers
    private string deviceStatusDataBuffer;

    // private methods

    private bool ReadDeviceData(ref DeviceData deviceData)
    {
        this.deviceStatusDataBuffer = this.serialPort.ReadLine();

        //deviceStatus.Data = this.deviceStatusDataBuffer;
        return true;

    }

  }
  }

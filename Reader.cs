
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
            if (DebugPrintsEnabled) Console.WriteLine(DateTime.UtcNow.ToString("HH:mm:ss.fff") + " Clear Buffer, Discarded " + bytesToRead + " bytes");
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool DebugPrintsEnabled = false;
    public bool ErrorPrintsEnabled = true;

    // constructor
    public Reader(SerialPort port,
                  EventPublicationFunction publishEvent,
                  DeviceResponsePublicationFunction publishResponse,
                  DeviceStatusPublicationFunction publishStatus,
                  Form1 form)
    {
      // constants
      this.kDeviceReadyMsg = ",";
      this.serialPort = port;
      this.delimiterWord = 987654321;

      // initial state
      this.connectionIsOpen = false;
      this.deviceReady = false;
      this.deviceReadyMsgCharIndex = 0;       // used in detecting 'device ready' msg
      this.deviceResponse = "";
      this.readingDeviceResponse = false;
      this.lastStreamTime = new DateTime();
      this.serialPort.ReadBufferSize = 8192;

      // publishing functions
      this.PublishEvent = publishEvent;
      this.PublishDeviceResponse = publishResponse;

      // read buffers
      this.deviceStatusDataBuffer = new byte[0];

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
            // if device has not yet sent a 'device ready' message, continue watching for one
            if (!this.deviceReady)
            {
              this.deviceReady = this.DeviceReadyMsgReceived(c);
              if (this.deviceReady)
              {
                this.PublishEvent(Event.DeviceReady);
              }
            }
            else
            {
              switch (c)
              {
                // CR -- end of message from device
                case '\r':
                  if (this.deviceResponse != this.kDeviceReadyMsg)
                  {
                    this.PublishDeviceResponse(this.deviceResponse);
                  }
                  this.deviceResponse = "";
                  this.readingDeviceResponse = false;
                  break;

                // newline -- ignore
                case '\n':
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
    public void Reset()
    {
      this.connectionIsOpen = false;
      this.deviceReady = false;
      this.deviceReadyMsgCharIndex = 0;
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
    private readonly int delimiterWord;

    // components
    private SerialPort serialPort;
    private Form1 formVar;

    // state
    private volatile bool connectionIsOpen;
    private volatile bool deviceReady;
    private volatile int deviceReadyMsgCharIndex;
    private volatile string deviceResponse;
    private volatile bool readingDeviceResponse;
    private DateTime lastStreamTime;

    // publication functions
    private EventPublicationFunction PublishEvent;
    private DeviceResponsePublicationFunction PublishDeviceResponse;

    // read buffers
    private byte[] deviceStatusDataBuffer;

    // private methods

    private bool ReadDeviceStatus(ref DeviceStatus deviceStatus)
    {
      if (this.ReadDataBlock(ref this.deviceStatusDataBuffer, deviceStatus.deviceStatusSize, 100))
      {
        deviceStatus.Data = this.deviceStatusDataBuffer;
        return true;
      }
      else
      {
        return false;
      }
    }

    //Data block must match expected size and be retrieved within the timeout period
    private bool ReadDataBlock(ref byte[] dataBlock, int expectedSize, int timeoutms)
    {
      byte[] readBuffer = new byte[4];
      TimeSpan diff;
      
        // first 4 bytes contain the block size
        int readBytes = 0;
        if (DebugPrintsEnabled) Console.WriteLine(DateTime.UtcNow.ToString("HH:mm:ss.fff") + " Getting Magic Word");
        while (readBytes < 4)
        {
          if (this.serialPort.BytesToRead > 0)
          {
            readBytes += this.serialPort.Read(readBuffer, readBytes, 4 - readBytes);
          }
        }

      // first 4 bytes contain the block size
      int bytesRead = 0;
      //Thread.Sleep(10);
      if (DebugPrintsEnabled)  Console.WriteLine(DateTime.UtcNow.ToString("HH:mm:ss.fff") + " Got Magic Word, getting length");
      DateTime curTime = DateTime.Now;
      while (bytesRead < 4)
      {
        if (this.serialPort.BytesToRead > 0)
        {
          bytesRead += this.serialPort.Read(readBuffer, bytesRead, 4 - bytesRead);
        }
        else
        {
        //  this.sendReadBufferContinuePacket();
          diff = DateTime.Now - curTime;
          if (diff.Seconds > timeoutms/1000)
          {
            if (ErrorPrintsEnabled) Console.WriteLine(DateTime.UtcNow.ToString("HH:mm:ss.fff") + " Timeout in ReadDataBlock " + diff.Milliseconds);
            return false;
          }
        }
      }
      //this.sendReadBufferContinuePacket();
      // if block size is different than expected, resize our data buffer
      int blockSize = BitConverter.ToInt32(readBuffer, 0);
      if (DebugPrintsEnabled) Console.WriteLine(DateTime.UtcNow.ToString("HH:mm:ss.fff") + " Got length " + blockSize + ", getting data");
      if (blockSize > 40000)
      {
        if( ErrorPrintsEnabled) Console.WriteLine("Block Size invalid: " + blockSize);
        return false;
      }
      curTime = DateTime.Now;
      if (dataBlock.Length != blockSize)
      {
        dataBlock = new byte[blockSize];
      }
      int firmwareMajor = BitConverter.ToInt32(dataBlock, 0);
      int firmwareMinor = BitConverter.ToInt32(dataBlock, 4);
      int firmwareSub = BitConverter.ToInt32(dataBlock, 8);
      bool firmwareCheck = ((firmwareMajor >= 4) && (firmwareMinor >= 1) && (firmwareSub >= 4));
      // Only check blocksize of metadata if we have firmware that has been updated with extra fields
      if (!firmwareCheck || (blockSize == expectedSize))
      {
        if (dataBlock.Length != blockSize)
        {
          dataBlock = new byte[blockSize];
        }
        //Thread.Sleep(10);
        // read in the block
        bytesRead = 0;
        while (bytesRead < blockSize)
        {
          if (this.serialPort.BytesToRead > 0)
          {
            bytesRead += this.serialPort.Read(dataBlock, bytesRead, blockSize - bytesRead);
          }
          else
          {
            //this.sendReadBufferContinuePacket();
            diff = DateTime.Now - curTime;
            if (diff.Milliseconds > timeoutms)
            {
              if (ErrorPrintsEnabled) Console.WriteLine(DateTime.UtcNow.ToString("HH:mm:ss.fff") + " 2nd Timeout in ReadDataBlock " + diff.Milliseconds + " reading size " + blockSize);
              return false;
            }
          }
        }
        if (DebugPrintsEnabled) Console.WriteLine(DateTime.UtcNow.ToString("HH:mm:ss.fff") + " Got Data bytes: " + bytesRead);
        //this.sendReadBufferContinuePacket();
        return true;  //data block successfully retrieved
      }
      if (ErrorPrintsEnabled) Console.WriteLine(DateTime.UtcNow.ToString("HH:mm:ss.fff") + " Failed in ReadDataBlock " + blockSize);
      return false;
    }

    private bool DeviceReadyMsgReceived(char c)
    {
      bool result;
      // does c match the char we're looking for?
      if (this.kDeviceReadyMsg[this.deviceReadyMsgCharIndex] == c)
      {
        // advance to next char
        this.deviceReadyMsgCharIndex++;
        // do we have a complete match?
        if (this.deviceReadyMsgCharIndex == this.kDeviceReadyMsg.Length)
        {
          result = true;
          this.deviceReadyMsgCharIndex = 0;
        }
        else
        {
          result = false;
        }
      }
      else
      {
        // start over
        this.deviceReadyMsgCharIndex = 0;
        result = false;
      }
      return result;
    }

  }
  }

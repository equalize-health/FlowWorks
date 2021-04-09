using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Collections;
using System.Threading;


namespace FlowWorks {
  public class Writer {

    // public enums
    public enum Event {
      WriteFailed
    }

    // public delegates
    public delegate void EventPublicationFunction(Event e);

    // public properties
    public bool Enabled {
      get { return this.enabled; }
      set { this.enabled = value; }
    }

    // constructor  
    public Writer(SerialPort port, EventPublicationFunction publishEvent) {
      this.serialPort       = port;
      this.commandQueue     = new Queue();
      this.commandQueueLock = new Object();
      this.terminalCommandQueue = new Queue();
      this.terminalCommandQueueLock = new Object();
      this.enabled          = false;
      this.PublishEvent     = publishEvent;
    }

    // public functions
    public void Run() {    // endless loop
      while (true) {
        try {
          // send commands
          if (this.serialPort.IsOpen) {
            while (this.terminalCommandQueue.Count > 0)
            {
                string termCommand = this.terminalCommandQueue.Dequeue().ToString().ToLower();
                if (termCommand.Length > 0)
                {
                    this.serialPort.Write(termCommand + '\r'); // add CR
                    Thread.Sleep(400);
                }
            }
          }
        }
        // if a write error occurred, connection is probably dead; close com port and post error msg
        catch (Exception e) {
          this.PublishEvent(Event.WriteFailed);
          Console.WriteLine("Reader thread exception: " + e.Message);
        }
        Thread.Sleep(100);
      }
    }
    public void AddCommand(string command) {
      lock (this.commandQueueLock) {
        if (this.enabled) {
          this.commandQueue.Enqueue(command);
        }
      }
    }
    public void AddTerminalCommand(string command)
    {
      lock (this.terminalCommandQueueLock)
      {
        if (this.enabled)
        {
            if (command.StartsWith("."))
                    {
                        Console.WriteLine("Starts with .");
                    }
            this.terminalCommandQueue.Enqueue(command);
        }
      }
    }

    public void Reset() {
      lock (this.commandQueueLock) {
        this.enabled = false;
        this.commandQueue.Clear();
      }
      lock (this.terminalCommandQueueLock)
      {
        this.terminalCommandQueue.Clear();
      }

      Console.WriteLine("Reset Write thread ");
    }

    // 
    // private
    //

    private SerialPort               serialPort;
    private volatile Queue           commandQueue;
    private volatile Queue           terminalCommandQueue;
    private volatile Object          commandQueueLock;
    private volatile Object          terminalCommandQueueLock;
    private volatile bool            enabled;
    private EventPublicationFunction PublishEvent;
  }
}

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
            while (commandQueue.Count > 0) {
              string command = commandQueue.Dequeue().ToString();
              // send the command only if writer is enabled; otherwise discard it
              if (this.enabled && (command.Length > 0)) {
                // First, check if there is a terminal command pending, send it BEFORE "&sendStatus"
                if (command.Equals("&sendStatus"))
                {
                  while (terminalCommandQueue.Count > 0)
                  {
                    string termCommand = terminalCommandQueue.Dequeue().ToString().ToLower();
                    if (termCommand.Length > 0)
                    {
                      // Before sending "&sendStatus", send the pending command from the Command Window
                      this.serialPort.Write(termCommand + '\r'); // add CR
                      if (termCommand.Equals("lcal") || termCommand.Equals("lcalb"))
                      {
                        Console.WriteLine("LCAL start: " + DateTime.UtcNow.ToString("HH:mm:ss.fff"));
                        // Wait for response from board
                        Thread.Sleep(3000);
                        Console.WriteLine("LCAL finished: " + DateTime.UtcNow.ToString("HH:mm:ss.fff"));
                      }
                      else
                      {
                        Thread.Sleep(400);
                      }
                    }
                  }
                }
                this.serialPort.Write(command + '\r');  // add CR 
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
            if (!command.EndsWith("\n\r"))
            {
                command += "\n\r";
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

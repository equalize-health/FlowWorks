using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.IO;

namespace FlowWorks
{
    public partial class Form1 : Form
    {
        private FlowWorks fwViewer;
        private List<string> commandHistory;
        private int commandHistoryIndex = 0;
        private decimal oldPropValue;
        private decimal oldBlowerValue;
        private double oldHeatPlateValue;
        private double oldHeatWireValue;

        public bool FiO2UnderPIDControl { get; private set; }
        public bool BabyPressureUnderPIDControl { get; private set; }
        public int CalibrationState;
        public bool HeatPlateUnderPIDControl;
        public bool HeatWireUnderPIDControl;

        public delegate void BoolParameterDelegate(bool b);
        public delegate void StringParameterDelegate(string s);
        public delegate void DeviceDataParameterDelegate(DeviceData deviceData);
        public delegate void DeviceStatusParameterDelegate(DeviceStatus deviceStatus);

        private Simulation SimulationScreen;
        private bool logFileOpened;
        private OpenFileDialog openFileDialog1;
        private string openFileName;

        public bool isConnected { get; private set; }
        public int CurrentScreen { get; private set; }
        public double TempProxValue { get; private set; }
        public double BabyPressureValue { get; private set; }
        public double FiO2Value { get; private set; }
        public string o2Status { get; private set; }

        public Form1()
        {
            InitializeComponent();
            // create the main application object
            fwViewer = new FlowWorks(this);
            // UI initialization
            this.UpdateCheckmarkInComportMenu(this.fwViewer.ComportNum);
            this.commandHistory = new List<string>();
            this.ActiveControl = this.commandBox;
            this.VersionString.Text = "Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.Text = "FlowWorks App " + Assembly.GetExecutingAssembly().GetName().Version.ToString(); ;
        }

        //The Comport menu (under Tools menu) may change, so update on every "Tools" click
        private void RefreshComList(object sender, EventArgs e)
        {
            int i = 0;
            var ComList = new List<string>();
            char[] RemoveCom = { 'C', 'O', 'M' };
            this.comportMenu.DropDownItems.Clear();

            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                if (ComList.Contains(s)) continue;
                else if (i == 0)
                {
                    this.comportMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                this.cOM1ToolStripMenuItem
                            });
                    this.cOM1ToolStripMenuItem.Name = "cOM1ToolStripMenuItem";
                    this.cOM1ToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
                    this.cOM1ToolStripMenuItem.Text = s;
                    this.cOM1ToolStripMenuItem.Click += new System.EventHandler(this.cOM1ToolStripMenuItem_Click);
                    this.cOM1ToolStripMenuItem.Tag = Int32.Parse(s.TrimStart(RemoveCom)); // Tag contains the port number
                }
                else if (i == 1)
                {
                    this.comportMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                this.cOM2ToolStripMenuItem
                            });
                    this.cOM2ToolStripMenuItem.Name = "cOM2ToolStripMenuItem";
                    this.cOM2ToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
                    this.cOM2ToolStripMenuItem.Text = s;
                    this.cOM2ToolStripMenuItem.Click += new System.EventHandler(this.cOM2ToolStripMenuItem_Click);
                    this.cOM2ToolStripMenuItem.Tag = Int32.Parse(s.TrimStart(RemoveCom)); // Tag contains the port number
                }
                else if (i == 2)
                {
                    this.comportMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                this.cOM3ToolStripMenuItem
                            });
                    this.cOM3ToolStripMenuItem.Name = "cOM3ToolStripMenuItem";
                    this.cOM3ToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
                    this.cOM3ToolStripMenuItem.Text = s;
                    this.cOM3ToolStripMenuItem.Click += new System.EventHandler(this.cOM3ToolStripMenuItem_Click);
                    this.cOM3ToolStripMenuItem.Tag = Int32.Parse(s.TrimStart(RemoveCom)); // Tag contains the port number
                }
                else if (i == 3)
                {
                    this.comportMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                this.cOM4ToolStripMenuItem
                            });
                    this.cOM4ToolStripMenuItem.Name = "cOM4ToolStripMenuItem";
                    this.cOM4ToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
                    this.cOM4ToolStripMenuItem.Text = s;
                    this.cOM4ToolStripMenuItem.Click += new System.EventHandler(this.cOM4ToolStripMenuItem_Click);
                    this.cOM4ToolStripMenuItem.Tag = Int32.Parse(s.TrimStart(RemoveCom)); // Tag contains the port number
                }
                else if (i == 4)
                {
                    this.comportMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                this.cOM5ToolStripMenuItem
                            });
                    this.cOM5ToolStripMenuItem.Name = "cOM5ToolStripMenuItem";
                    this.cOM5ToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
                    this.cOM5ToolStripMenuItem.Text = s;
                    this.cOM5ToolStripMenuItem.Click += new System.EventHandler(this.cOM5ToolStripMenuItem_Click);
                    this.cOM5ToolStripMenuItem.Tag = Int32.Parse(s.TrimStart(RemoveCom)); // Tag contains the port number
                }
                else if (i == 5)
                {
                    this.comportMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.cOM6ToolStripMenuItem
                                });
                    this.cOM6ToolStripMenuItem.Name = "cOM6ToolStripMenuItem";
                    this.cOM6ToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
                    this.cOM6ToolStripMenuItem.Text = s;
                    this.cOM6ToolStripMenuItem.Click += new System.EventHandler(this.cOM6ToolStripMenuItem_Click);
                    this.cOM6ToolStripMenuItem.Tag = Int32.Parse(s.TrimStart(RemoveCom)); // Tag contains the port number
                }
                else if (i == 6)
                {
                    this.comportMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.cOM7ToolStripMenuItem
                                });
                    this.cOM7ToolStripMenuItem.Name = "cOM7ToolStripMenuItem";
                    this.cOM7ToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
                    this.cOM7ToolStripMenuItem.Text = s;
                    this.cOM7ToolStripMenuItem.Click += new System.EventHandler(this.cOM7ToolStripMenuItem_Click);
                    this.cOM7ToolStripMenuItem.Tag = Int32.Parse(s.TrimStart(RemoveCom)); // Tag contains the port number
                }
                else if (i == 7)
                {
                    this.comportMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.cOM8ToolStripMenuItem
                                });
                    this.cOM8ToolStripMenuItem.Name = "cOM8ToolStripMenuItem";
                    this.cOM8ToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
                    this.cOM8ToolStripMenuItem.Text = s;
                    this.cOM8ToolStripMenuItem.Click += new System.EventHandler(this.cOM8ToolStripMenuItem_Click);
                    this.cOM8ToolStripMenuItem.Tag = Int32.Parse(s.TrimStart(RemoveCom)); // Tag contains the port number
                }

                i++;
                ComList.Add(s);  // ComList will contain a list of the Com ports in ASCII (not a number)
            }
        }
        public void UpdateConnectedSignal(bool isConnected)
        {
            this.connectedTextBox.BackColor = isConnected ? Color.Lime : SystemColors.Control;
            this.isConnected = isConnected;
        }
        public void SendTerminalCommand(string cmd)
        {
            fwViewer.AddTerminalCommand(cmd);
        }
        private void ChangeComport(int comportNum)
        {
            //this.dwApp.ComPort = "COM" + comportNum.ToString();
            this.fwViewer.ComportNum = comportNum;
            this.UpdateCheckmarkInComportMenu(comportNum);
        }
        public void UpdateDeviceData(DeviceData deviceData)
        {
            this.BabyPressure.Text = deviceData.babyPressure.ToString("N2");
            this.BabyPressureValue = deviceData.babyPressure;
            this.FlowLeak.Text = deviceData.flowLeak.ToString("N2");
            this.PressExp.Text = deviceData.pressExp.ToString("N2");
            this.FlowExp.Text = deviceData.flowExp.ToString("N2");
            this.PressCkt.Text = deviceData.pressCkt.ToString("#.##");
            this.TempProxValue = deviceData.tempProx;
            if (deviceData.tempProx < -40) this.TempProx.Text = "N/C";
            else this.TempProx.Text = deviceData.tempProx.ToString("N1");
            if (deviceData.tempDist < -40) this.TempDist.Text = "N/C";
            else this.TempDist.Text = deviceData.tempDist.ToString("N1");
            if (deviceData.tempHeater < -40) this.TempPlate.Text = "N/C";
            else this.TempPlate.Text = deviceData.tempHeater.ToString("N1");
            this.PressInsp.Text = deviceData.pressInsp.ToString("N2");
            this.BlowerSpeed.Text = deviceData.blowerSpeed.ToString("N0");
            this.FlowInsp.Text = deviceData.flowInsp.ToString("N2");
            this.FlowOx.Text = deviceData.flowOx.ToString("N2");
            this.TempAmb.Text = deviceData.tempPCB.ToString("N1");
            this.FiO2.Text = deviceData.fio2.ToString("N1");
            this.FiO2Value = deviceData.fio2;
            this.Fio2Setpt.Value = (decimal)deviceData.fio2Setpt;
            this.PressBabySetpt.Value = (decimal)deviceData.pressSetpt;
            if (Convert.ToBoolean(deviceData.fio2PIDEnable))
            {
                this.StartFiO2.BackColor = Color.Red;
                this.FiO2UnderPIDControl = true;
                this.StartFiO2.Text = "Stop";
            }
            else
            {
                this.StartFiO2.BackColor = Color.Green;
                this.FiO2UnderPIDControl = false;
                this.StartFiO2.Text = "Start";
            }
            if (Convert.ToBoolean(deviceData.babyPressurePIDEnable))
            {
                this.StartBabyPressure.BackColor = Color.Red;
                this.BabyPressureUnderPIDControl = true;
                this.StartBabyPressure.Text = "Stop";
            }
            else
            {
                this.StartBabyPressure.BackColor = Color.Green;
                this.BabyPressureUnderPIDControl = false;
                this.StartBabyPressure.Text = "Start";
            }
            if (Convert.ToBoolean(deviceData.heatPlatePIDEnable))
            {
                this.StartHeatPlate.BackColor = Color.Red;
                this.HeatPlateUnderPIDControl = true;
                this.StartHeatPlate.Text = "Stop";
            }
            else
            {
                this.StartHeatPlate.BackColor = Color.Green;
                this.HeatPlateUnderPIDControl = false;
                this.StartHeatPlate.Text = "Start";
            }
            if (Convert.ToBoolean(deviceData.heatWirePIDEnable))
            {
                this.StartHeatWire.BackColor = Color.Red;
                this.HeatWireUnderPIDControl = true;
                this.StartHeatWire.Text = "Stop";
            }
            else
            {
                this.StartHeatWire.BackColor = Color.Green;
                this.HeatWireUnderPIDControl = false;
                this.StartHeatWire.Text = "Start";
            }
            if (deviceData.o2Sensor < 0.0)
            {
                // Invalid O2 sensor reading, probably O2 sensor is missing
                this.o2SensorAvg.Text = "N/C";
                this.o2SensorAvg.BackColor = Color.LightGray;
                this.o2SensorStatusDescription.Text = "Not Available";
            } else
            {
                this.o2SensorAvg.Text = deviceData.o2Sensor.ToString("N2");
            }
            this.SetBlower.Value = (decimal)deviceData.blowerSetting;
            this.SetPropValve.Value = (decimal)deviceData.propValveSetting;
            this.cFactor.Text = deviceData.cFactor.ToString("N3");
            this.CalibrationState = deviceData.calibrationState;
            this.HeatPlateSetting.Text = deviceData.heatPlateSetpt.ToString("N1");
            this.HeatWireSetting.Text = deviceData.heatWireSetpt.ToString("N1");
        }

        public void logData(string inputString)
        {
            if (logFileOpened)
            {
                string writeLine;
                DateTime value = DateTime.Now;
                writeLine = DateTime.UtcNow.ToString("HH:mm:ss.fff,");
                writeLine += inputString;
                File.AppendAllText(openFileName, writeLine + Environment.NewLine);
            }
        }

        public void UpdateDeviceStatus(DeviceStatus deviceStatus)
        {            
            this.firmwareVersionLabel.Text = "v" + deviceStatus.versionMajor.ToString() +
                                             "." + deviceStatus.versionMinor.ToString() +
                                             "." + deviceStatus.versionBuild.ToString();
            this.dateLabel.Text = deviceStatus.dateMonth.ToString() + "/" +
                                  deviceStatus.dateDay.ToString() + "/" +
                                  deviceStatus.dateYear.ToString("00");
            this.timeLabel.Text = deviceStatus.timeHour.ToString() + ":" +
                                  deviceStatus.timeMin.ToString("00") + ":" +
                                  deviceStatus.timeSec.ToString("00");
            this.CurrentScreen = deviceStatus.currentScreen;
            if (deviceStatus.ambientPressure > 700)
            {
                this.pressureAmbient.Text = deviceStatus.ambientPressure.ToString("N0");
            } else
            {
                this.pressureAmbient.Text = "N/C";
                this.pressureAmbient.BackColor = Color.LightGray;
            }
            this.o2Status = deviceStatus.o2Status.ToString();
            if (deviceStatus.o2Status == 0)
            {
                this.o2SensorAvg.BackColor = Color.Red;
                this.o2SensorStatusDescription.Text = "Sensor Off";
            }
            else if (deviceStatus.o2Status == 1)
            {
                if (deviceStatus.o2CalibrationStatus == 1)
                {
                    this.o2SensorAvg.BackColor = Color.LightYellow;
                    this.o2SensorStatusDescription.Text = "Calibrating O2...";
                }
                else if (deviceStatus.o2CalibrationStatus == 2)
                {
                    this.o2SensorAvg.BackColor = Color.LightBlue;
                    this.o2SensorStatusDescription.Text = "Warming up, Calibration Complete";
                }
                else {
                    this.o2SensorAvg.BackColor = Color.Yellow;
                    this.o2SensorStatusDescription.Text = "Warming Up";
                }
            }
            else if (deviceStatus.o2Status == 2)
            {
                if (deviceStatus.o2CalibrationStatus == 1)
                {
                    this.o2SensorAvg.BackColor = Color.LightYellow;
                    this.o2SensorStatusDescription.Text = "Calibrating O2...";
                }
                else if (deviceStatus.o2CalibrationStatus == 2)
                {
                    this.o2SensorAvg.BackColor = Color.LightBlue;
                    this.o2SensorStatusDescription.Text = "Running, Calibration Complete";
                }
                else {

                    this.o2SensorAvg.BackColor = Color.LightGreen;
                    this.o2SensorStatusDescription.Text = "Running";
                }
            }
        }
        // private helper functions
        private void OverwriteLastCommandWith(string s)
        {
            List<string> myList = commandBox.Lines.ToList();
            if (myList.Count > 0)
            {
                myList.RemoveAt(myList.Count - 1);
                commandBox.Lines = myList.ToArray();
            }
            commandBox.AppendText("\r\n" + s);
        }
        private void UpdateCheckmarkInComportMenu(int comportNum)
        {
            ToolStripMenuItem setupMenu = (ToolStripMenuItem)menuStrip1.Items["setupMenu"];
            ToolStripMenuItem comportMenu = (ToolStripMenuItem)setupMenu.DropDownItems["comportMenu"];
            for (int i = 0; i < comportMenu.DropDownItems.Count; i++)
            {
                ToolStripMenuItem comPort = (ToolStripMenuItem)comportMenu.DropDownItems[i];
                comPort.Checked = ((int)comPort.Tag == comportNum);
            }
        }
        private void cOM1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ChangeComport((int)this.cOM1ToolStripMenuItem.Tag);
        }
        private void cOM2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ChangeComport((int)this.cOM2ToolStripMenuItem.Tag);
        }
        private void cOM3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ChangeComport((int)this.cOM3ToolStripMenuItem.Tag);
        }
        private void cOM4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ChangeComport((int)this.cOM4ToolStripMenuItem.Tag);
        }
        private void cOM5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ChangeComport((int)this.cOM5ToolStripMenuItem.Tag);
        }
        private void cOM6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ChangeComport((int)this.cOM6ToolStripMenuItem.Tag);
        }
        private void cOM7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ChangeComport((int)this.cOM7ToolStripMenuItem.Tag);
        }
        private void cOM8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ChangeComport((int)this.cOM8ToolStripMenuItem.Tag);
        }
        public void UpdateErrorMsg(string s)
        {
            // for debug...
            //this.responseBox.AppendText(">>> COMMUNICATIONS ERROR: " + s + "\r\n");
        }
        public void UpdateResponse(string s)
        {
            // Ignore lines starting with comma
            if (!s.StartsWith(",") && !s.StartsWith("&") && !s.StartsWith("!"))
                this.responseBox.AppendText(s + "\r\n");
        }

        private void commandBox_Click(object sender, EventArgs e)
        {
            // keep cursor always at the end of the textbox
            commandBox.Select(commandBox.Text.Length, 0);
        }

        private void commandBox_KeyDown(object sender, KeyEventArgs e)
        {
            int colNum;
            switch (e.KeyCode)
            {
                case Keys.Return:
                    if (commandBox.Lines.Length > 0)
                    {
                        string command = commandBox.Lines[commandBox.Lines.Length - 1];
                        commandHistory.Add(command);
                        commandHistoryIndex = commandHistory.Count;
                        fwViewer.AddTerminalCommand(command);
                        responseBox.AppendText("\r\n");
                        if (command.Length > 0)
                        {
                            responseBox.AppendText("> " + command + "\r\n");
                        }
                    }
                    break;
                case Keys.Up:
                    if (commandHistoryIndex > 0)
                    {
                        commandHistoryIndex--;
                        this.OverwriteLastCommandWith(commandHistory[commandHistoryIndex]);
                    }
                    e.Handled = true;
                    break;
                case Keys.Down:
                    if (commandHistoryIndex < commandHistory.Count)
                    {
                        commandHistoryIndex++;
                    }
                    if (commandHistoryIndex == commandHistory.Count)
                    {
                        this.OverwriteLastCommandWith("");
                    }
                    else
                    {
                        this.OverwriteLastCommandWith(commandHistory[commandHistoryIndex]);
                    }
                    e.Handled = true;
                    break;
                case Keys.Back:
                    // don't allow backspacing beyond start of line
                    colNum = commandBox.SelectionStart -
                             commandBox.GetFirstCharIndexFromLine(commandBox.GetLineFromCharIndex(commandBox.SelectionStart));
                    if (colNum == 0)
                    {
                        // e.Handled = true;  <-- didn't work
                        commandBox.AppendText("\r\n");
                    }
                    break;
                case Keys.Left:
                    e.Handled = true;
                    break;
            }
        }

        private void PressBabySetpt_ValueChanged(object sender, EventArgs e)
        {
            fwViewer.AddTerminalCommand("pressSetpt(" + this.PressBabySetpt.Value + ")");
        }

        private void Fio2Setpt_ValueChanged(object sender, EventArgs e)
        {
            fwViewer.AddTerminalCommand("fio2Setpt(" + this.Fio2Setpt.Value + ")");
        }

        private void StartBabyPressure_Click(object sender, EventArgs e)
        {
            fwViewer.AddTerminalCommand("pressSetpt("+this.PressBabySetpt.Value+")");
            fwViewer.AddTerminalCommand("togglePIDPress");
        }

        private void StartFiO2_Click(object sender, EventArgs e)
        {
            fwViewer.AddTerminalCommand("fio2Setpt(" + this.Fio2Setpt.Value + ")");
            fwViewer.AddTerminalCommand("togglePIDFiO2");
        }

        private void SetBlower_ValueChanged(object sender, EventArgs e)
        {
            fwViewer.deviceData.blowerSetting = Convert.ToInt32(this.SetBlower.Value);
            // Only send the blower command if the user has deliberately changed the value
            if ((this.BabyPressureUnderPIDControl == true) || (this.CalibrationState > 0))
            {
                this.SetBlower.BackColor = Color.Gray;
            }
            else if ((oldBlowerValue < this.SetBlower.Value) || (oldBlowerValue > this.SetBlower.Value))
            {
                fwViewer.AddTerminalCommand("blower(" + this.SetBlower.Value + ")");
                this.SetBlower.BackColor = Color.Empty;
            }
            oldBlowerValue = this.SetBlower.Value;
        }
        private void SetPropValve_ValueChanged(object sender, EventArgs e)
        {
            fwViewer.deviceData.propValveSetting = Convert.ToDouble(this.SetPropValve.Value);
            // Only send the propValve command if the user has deliberately changed the value
            if ((this.FiO2UnderPIDControl == true) || (this.CalibrationState > 0))
            {
                this.SetPropValve.BackColor = Color.Gray;
            }
            else if ((oldPropValue < this.SetPropValve.Value) || (oldPropValue > this.SetPropValve.Value))
            {
                fwViewer.AddTerminalCommand("propValve(" + this.SetPropValve.Value + ")");
                this.SetPropValve.BackColor = Color.Empty;
            }
            oldPropValue = this.SetPropValve.Value;
        }

        private void Calibrate_Click(object sender, EventArgs e)
        {
            Form2 calibratePopup = new Form2();
            if (calibratePopup.ShowDialog(this) == DialogResult.OK) 
            {
                fwViewer.AddTerminalCommand("calibrate");
            }
            calibratePopup.Dispose();
        }

        private void StartHeatPlate_Click(object sender, EventArgs e)
        {
            fwViewer.AddTerminalCommand("heatPlateSetpt(" + Convert.ToDouble(this.HeatPlateSetting.Text) + ")");
            fwViewer.AddTerminalCommand("togglePIDHeatPlate");
            if (StartHeatPlate.Text == "Stop")
            {
                fwViewer.AddTerminalCommand("heatPlate(0)");
            }
        }

        private void StartHeatWire_Click(object sender, EventArgs e)
        {
            fwViewer.AddTerminalCommand("heatWireSetpt(" + Convert.ToDouble(this.HeatWireSetting.Text) + ")");
            fwViewer.AddTerminalCommand("togglePIDHeatWire");
            if (StartHeatWire.Text == "Stop")
            {
                fwViewer.AddTerminalCommand("heatWire(0)");
            }
        }

        private void HeatPlateSetting_ValueChanged(object sender, EventArgs e)
        {
            double newHeatPlateValue = Convert.ToDouble(this.HeatPlateSetting.Value);
            fwViewer.deviceData.heatPlateSetpt = newHeatPlateValue;
            if ((oldHeatPlateValue < newHeatPlateValue) || (oldHeatPlateValue > newHeatPlateValue))
            {
                fwViewer.AddTerminalCommand("heatPlateSetpt(" + newHeatPlateValue + ")");
            }
            oldHeatPlateValue = newHeatPlateValue;

        }

        private void HeatWireSetting_ValueChanged(object sender, EventArgs e)
        {
            double newHeatWireValue = Convert.ToDouble(this.HeatWireSetting.Value);
            fwViewer.deviceData.heatWireSetpt = newHeatWireValue;
            if ((oldHeatWireValue < newHeatWireValue) || (oldHeatWireValue > newHeatWireValue))
            {
                fwViewer.AddTerminalCommand("heatWireSetpt(" + newHeatWireValue + ")");
            }
            oldHeatWireValue = newHeatWireValue;
        }

        private void startFirwmareDownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DownloadFW downloadPopup = new DownloadFW();
            if (downloadPopup.ShowDialog(this) == DialogResult.OK)
            {
                // Use ProcessStartInfo class
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = false;
                startInfo.FileName = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/ProgramAtmel.bat";
                Console.WriteLine("Execute program: " + startInfo.FileName);
                UpdateResponse("Running program: " + startInfo.FileName);
                startInfo.WindowStyle = ProcessWindowStyle.Normal;
                try
                {
                    // Start the process with the info we specified.
                    // Call WaitForExit and then the using statement will close.
                    using (Process exeProcess = Process.Start(startInfo))
                    {
                        exeProcess.WaitForExit();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    UpdateResponse("Error during download: " + ex.Message);
                }
            }
            downloadPopup.Dispose();
        }

        private void aboutFirmwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe ";
            startInfo.Arguments = "\"" + System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ReleaseNotes.pdf" + "\"";
            //startInfo.Arguments = "ReleaseNotes.pdf";
            Console.WriteLine("Opening file: " + startInfo.Arguments);
            //UpdateResponse("Running program: " + startInfo.FileName);
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            try
            {
                Process exeProcess = Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                UpdateResponse("Error while opening PDF File: " + ex.Message);
            }
        }

        private void StartSimulation_Click(object sender, EventArgs e)
        {
            SimulationScreen = new Simulation(this);
            DialogResult result = SimulationScreen.ShowDialog();
            SimulationScreen.Invalidate();
        }

        private void enableLoggingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // If a file is not opened, then set the initial directory to the
            // FolderBrowserDialog.SelectedPath value.
            if (!logFileOpened)
            {
                this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
                openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                Console.WriteLine("My Documents directory: " + openFileDialog1.InitialDirectory);

                try
                {
                    if (!Directory.Exists(openFileDialog1.InitialDirectory))
                    {
                        // Logging directory doesn't exist yet
                        Directory.CreateDirectory(openFileDialog1.InitialDirectory);
                    }
                    if (openFileDialog1.InitialDirectory.Length > 1)
                    {
                        openFileDialog1.InitialDirectory += "\\FlowWorksLogs";
                    }
                    openFileDialog1.FileName = openFileDialog1.InitialDirectory + "\\flowWorks.log";
                    Console.WriteLine("Logging file: " + openFileDialog1.FileName);
                } 
                catch(Exception exp)
                {
                    MessageBox.Show("An error occurred while attempting to load the file: " + openFileDialog1.FileName + ".  The error is:"
                                    + System.Environment.NewLine + exp.ToString() + System.Environment.NewLine);
                    logFileOpened = false;
                }

            }

            openFileDialog1.CheckFileExists = false;
            // Display the openFile dialog.
            DialogResult result = openFileDialog1.ShowDialog();

            // OK button was pressed.
            if (result == DialogResult.OK)
            {
                openFileName = openFileDialog1.FileName;
                try
                {
                    // Make sure we can open the file
                    if (!File.Exists(openFileName))
                    {
                        //File.Create(openFileName);
                        // Create header in new file
                        File.AppendAllText(openFileName, "TIMESTAMP,P_INSP, P_EXP,F_INS,FL_OX,T_DIS,T_PRX, T_HT,T_PCB,  FIO2,  BABY, F_EXP,F_LEAK,HW_STPT,HW_ACT,HW_CTL,HW_ERR,HW_INT" + Environment.NewLine);
                    }

                    logFileOpened = true;
                }
                catch (Exception exp)
                {
                    MessageBox.Show("An error occurred while attempting to load the file: "+openFileName+".  The error is:"
                                    + System.Environment.NewLine + exp.ToString() + System.Environment.NewLine);
                    logFileOpened = false;
                }
                Invalidate();

               // closeMenuItem.Enabled = logFileOpened;
            }

            // Cancel button was pressed.
            else if (result == DialogResult.Cancel)
            {
                return;
            }
        }

        private void o2SensorAvg_Click(object sender, EventArgs e)
        {
            if (this.pressureAmbient.Text == "N/C")
            {
                // Don't bring up O2 sensor popup if sensor appears not connected
                return;
            }
            o2Sensor o2SensorPopup = new o2Sensor();
            DialogResult result = o2SensorPopup.ShowDialog(this);
            if (result == DialogResult.Yes)
            {
                fwViewer.AddTerminalCommand("o2Power(1)");
                Console.WriteLine("Turn on O2 Power");
            }
            if (result == DialogResult.No) {
                fwViewer.AddTerminalCommand("o2calibrate(0)");
                fwViewer.AddTerminalCommand("o2Power(0)");
                Console.WriteLine("Turn off O2 Power");
            }
            if (result == DialogResult.OK) {
                fwViewer.AddTerminalCommand("o2calibrate(1)");
                Console.WriteLine("Turn on O2 Calibration");
            }
            if (result == DialogResult.Cancel)
            {
                // Do Nothing
                Console.WriteLine("Cancel O2 operation");
            }
            o2SensorPopup.Dispose();
        }
    }
}

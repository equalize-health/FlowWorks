using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace FlowWorks
{
    public partial class Simulation : Form
    {
        private bool button1 = false;
        private bool button2 = false;
        private bool button3 = false;
        private bool button4 = false;
        private bool button5 = false;
        private bool button10 = false;
        private Form1 form1;
        private Thread stateChangeThread;
        private Color MediumGreyBackground;
        private Color MediumBlueBackground;
        private Color LightGreyBackground;
        private Color DarkGreyBackground;

        public int CurrentScreen { get; private set; }
        public int RequestedScreen { get; private set; }

        public Simulation()
        {
            InitializeComponent();
            stateChangeThread = new Thread(new ThreadStart(this.stateMachine));
            stateChangeThread.IsBackground = true;
            stateChangeThread.Start();
        }

        public Simulation(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            this.CurrentScreen = 0;
            stateChangeThread = new Thread(new ThreadStart(this.stateMachine));
            stateChangeThread.IsBackground = true;
            stateChangeThread.Start();
        }
        ~Simulation() // finalizer
        {
            stateChangeThread.Abort();
        }
        // This function sends commands to the target to retrieve data information
        // It runs in a thread, constantly sending the command
        void stateMachine()
        {
            MediumGreyBackground = Color.FromArgb(
                                255, // Specifies the transparency of the color.
                                208, // Specifies the amount of red.
                                208, // specifies the amount of green.
                                208); // Specifies the amount of blue.
            DarkGreyBackground = Color.FromArgb(
                                255, // Specifies the transparency of the color.
                                87, // Specifies the amount of red.
                                87, // specifies the amount of green.
                                87); // Specifies the amount of blue.
            LightGreyBackground = Color.FromArgb(
                                255, // Specifies the transparency of the color.
                                245, // Specifies the amount of red.
                                245, // specifies the amount of green.
                                245); // Specifies the amount of blue.
            MediumBlueBackground = Color.FromArgb(
                                255, // Specifies the transparency of the color.
                                45, // Specifies the amount of red.
                                95, // specifies the amount of green.
                                140); // Specifies the amount of blue.

            while (true)
            {
                if (this.form1.isConnected)
                {
                    // This means we request data every 500 msecs (default)
                    Thread.Sleep(500);
                    if (this.form1.CurrentScreen != this.RequestedScreen)
                    {
                        Console.WriteLine("Change to screen: " + this.form1.CurrentScreen.ToString());
                        changeScreen(this.form1.CurrentScreen);
                        this.RequestedScreen = this.form1.CurrentScreen;
                    }
                    if ((this.CurrentScreen >= 6) && (this.CurrentScreen <= 47))
                    {
#if false
                        // Refresh the box to re-draw the FiO2 and baby pressure
                        if (this.simulationPictureBox.InvokeRequired)
                        {
                            this.simulationPictureBox.Invoke(new MethodInvoker(
                                delegate ()
                                {
                                    this.simulationPictureBox.Refresh();
                                }
                            ));
                        }
                        else
                        {
                            this.simulationPictureBox.Refresh();
                        }
#endif
                        // Refresh the box to re-draw the FiO2 and baby pressure
                        if (this.pictureBoxMain.InvokeRequired)
                        {
                            this.pictureBoxMain.Invoke(new MethodInvoker(
                                delegate ()
                                {
                                    this.pictureBoxMain.Refresh();
                                }
                            ));
                        }
                        else
                        {
                            this.pictureBoxMain.Refresh();
                        }

                    }

                    if (button1)
                    {
                        this.form1.SendTerminalCommand("button(1)");
                        button1 = false;
                    }
                    else if (button2)
                    {
                        this.form1.SendTerminalCommand("button(2)");
                        button2 = false;
                    }
                    else if (button3)
                    {
                        this.form1.SendTerminalCommand("button(3)");
                        button3 = false;
                    }
                    else if (button4)
                    {
                        this.form1.SendTerminalCommand("button(4)");
                        button4 = false;
                    }
                    else if (button5)
                    {
                        this.form1.SendTerminalCommand("button(5)");
                        button5 = false;
                    }
                    else if (button10)
                    {
                        this.form1.SendTerminalCommand("button(10)");
                        button10 = false;
                    }
                }
            }
        }

        // Define the screen positions in the resources database
        int splash_start_screen = 31;
        int splash_done_screen = 38;
        int fill_humidifer_screen = 39;
        int reinstall_humidifer_screen = 43;
        int connect_adapter_tube_screen = 44;
        int connect_heater_screen = 40;
        int connect_mid_temp_sensor_screen = 41;
        int connect_end_temp_sensor_screen = 45;
        int connect_insp_circuit_screen = 42;
        int connect_colored_cables_screen = 32;
        int connect_nasal_circuit_screen = 33;
        int connect_CPAP_below_patient_screen = 22;
        int start_circuit_test_screen = 34;
        int in_progress_circuit_test_screen = 35;
        int alarm_change_filter_screen = 6;
        int therapy_setting_screen = 36;
        int therapy_ramping_screen = 37;
        int therapy_running_screen = 37;
        int alarm_low_pressure_screen = 16;
        int alarm_low_fio2_screen = 14;
        int alarm_low_battery_screen = 13;
        int alarm_high_pressure_screen = 11;
        int alarm_occlusion_screen = 18;
        int alarm_critically_low_battery_screen = 7;
        int alarm_heater_cable_disconnected_screen = 8;
        int alarm_high_temperature_screen = 12;
        int alarm_temp_sensor_disconnected_screen = 21;
        int alarm_high_fio2_screen = 9;
        int alarm_low_temperature_screen = 17;
        int alarm_high_plate_temperature_screen = 10;
        int alarm_low_plate_temperature_screen = 15;
        int backward_button = 25;
        int forward_button = 26;
        int mute_button = 27;
        int circuit_test_button = 30;
        int pause_button = 28;
        int complete_button = 23;
        int dismiss_button = 24;

        private bool alarmScreenPresent(int currentScreen)
        {
            if (currentScreen == alarm_low_pressure_screen) return true;
            if (currentScreen == alarm_low_fio2_screen) return true;
            if (currentScreen == alarm_low_battery_screen) return true;
            if (currentScreen == alarm_high_pressure_screen) return true;
            if (currentScreen == alarm_occlusion_screen) return true;
            if (currentScreen == alarm_critically_low_battery_screen) return true;
            if (currentScreen == alarm_heater_cable_disconnected_screen) return true;
            if (currentScreen == alarm_high_temperature_screen) return true;
            if (currentScreen == alarm_temp_sensor_disconnected_screen) return true;
            if (currentScreen == alarm_high_fio2_screen) return true;
            if (currentScreen == alarm_low_temperature_screen) return true;
            if (currentScreen == alarm_high_plate_temperature_screen) return true;
            if (currentScreen == alarm_low_plate_temperature_screen) return true;

            return false;
        }
        private bool therapyScreenPresent(int currentScreen)
        {
            if (currentScreen == therapy_setting_screen) return true;
            if (currentScreen == therapy_ramping_screen) return true;
            if (currentScreen == therapy_running_screen) return true;
            return false;
        }
        private void changeScreen(int currentScreen)
        {
            string screenName = " ";
            string[] screenImages = Assembly.GetEntryAssembly().GetManifestResourceNames();
            int screenImageBase = 23;
            screenImageBase = 0;
            switch (currentScreen)
            {
                case 1:
                    //Splash_START:
                    this.CurrentScreen = splash_start_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 2:
                    //Splash_DONE
                    this.CurrentScreen = splash_done_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 3:
                    //Fill_Humidifier
                    this.CurrentScreen = fill_humidifer_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 7:
                    //Reinstall_Humidifier
                    this.CurrentScreen = reinstall_humidifer_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 8:
                    //Connect_Exp
                    this.CurrentScreen = connect_adapter_tube_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];    // This is connect adapter tube
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 4:
                    //connect_Heater_to_Insp
                    this.CurrentScreen = connect_heater_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];    // There's only 1 "connect heater" screen
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 5:
                    //connect_mid_temp_to_Insp
                    this.CurrentScreen = connect_mid_temp_sensor_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 9:
                    //connect_end_temp_to_Insp
                    this.CurrentScreen = connect_end_temp_sensor_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 11:
                    //connect nasal circuit
                    this.CurrentScreen = connect_nasal_circuit_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];    //  "nasal circuit" screen
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 10:
                    //connect colored cables
                    this.CurrentScreen = connect_colored_cables_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];    // Connect "Colored" cables
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 6:
                    //connect_insp_tube
                    this.CurrentScreen = connect_insp_circuit_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];    // Connect "Inspiratory" circuit
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 34:
                    // CPAP below patient
                    this.CurrentScreen = connect_CPAP_below_patient_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];    // Baby below CPAP
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 35:
                    // change filter
                    this.CurrentScreen = alarm_change_filter_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];    // change filter
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 12:
                    //self_test_start
                    this.CurrentScreen = start_circuit_test_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];    // Start circuit test
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 13:
                    //self_test_progress
                    this.CurrentScreen = in_progress_circuit_test_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];    // Circuit test in progress
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 14:
                    //Pause, waiting to run
                    this.CurrentScreen = therapy_setting_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];    // set screen
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 15:
                    //Adjusting to new setpoint
                    this.CurrentScreen = therapy_ramping_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];    // ramping
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 16:
                    //running  stable
                    this.CurrentScreen = therapy_running_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];    // run screen
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 17:
                    // Low pressure alarm
                    this.CurrentScreen = alarm_low_pressure_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];    // Low Pressure alarm screen
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 18:
                    // Low Fio2
                    this.CurrentScreen = alarm_low_fio2_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];    // Low FiO2 alarm screen
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 19:
                    // alarm low battery
                    this.CurrentScreen = alarm_low_battery_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];    // Low battery alarm screen
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 20:
                    // High Pressure alarm
                    this.CurrentScreen = alarm_high_pressure_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];    // Hi Pressure alarm screen
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 21:
                    // occlusion
                    this.CurrentScreen = alarm_occlusion_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];    // Occlusion alarm screen
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 36:
                    // Critically low battery alarm
                    this.CurrentScreen = alarm_critically_low_battery_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];    // Crit. Low battery alarm screen
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 37:
                    // heater cable disconnected alarm
                    this.CurrentScreen = alarm_heater_cable_disconnected_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];    // Heater cable disc. alarm screen
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 38:
                    // high temperature alarm
                    this.CurrentScreen = alarm_high_temperature_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];    // Hi Temp alarm screen
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 39:
                    // temp sensor disconnected alarm
                    this.CurrentScreen = alarm_temp_sensor_disconnected_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];    // Temp sensor disc. alarm screen
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 40:
                    // high FiO2 alarm
                    this.CurrentScreen = alarm_high_fio2_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];    // Hi Fio2 alarm screen
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 41:
                    // low temperature alarm
                    this.CurrentScreen = alarm_low_temperature_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];    // Low Temp alarm screen
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 43:
                    // High plate temperature
                    this.CurrentScreen = alarm_high_plate_temperature_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];    // Hi Plate Temp alarm screen
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 42:
                    // Low plate temperature
                    this.CurrentScreen = alarm_low_plate_temperature_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];    // Low Plate Temp alarm screen
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 22:
                    // lock button - NO LONGER USED
                    screenName = screenImages[screenImageBase + backward_button];    // Back button
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 23:
                    // unlock button - NO LONGER USED
                    this.CurrentScreen = alarm_high_fio2_screen;
                    screenName = screenImages[screenImageBase + forward_button];    // forward button
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 24:
                    // mute button
                    this.CurrentScreen = alarm_high_fio2_screen;
                    screenName = screenImages[screenImageBase + mute_button];    // Mute button
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 25:
                    // unmute button
                    screenName = screenImages[screenImageBase + mute_button];    // Mute button
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 26:
                    // back button
                    screenName = screenImages[screenImageBase + backward_button];    // Back button
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 27:
                    // change button
                    screenName = screenImages[screenImageBase + circuit_test_button];    // Test button
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 28:
                    // next button
                    screenName = screenImages[screenImageBase + forward_button];    // forward button
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 29:
                    // pause button
                    screenName = screenImages[screenImageBase + pause_button];    // Pause button
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 30:
                    // run button
                    screenName = screenImages[screenImageBase + forward_button];    // forward button
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 31:
                    // skip setup button - NOT USED
                    screenName = screenImages[screenImageBase + pause_button];    // Pause button
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 32:
                    // dismiss button
                    screenName = screenImages[screenImageBase + dismiss_button];    // dismiss button
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 33:
                    // complete button
                    screenName = screenImages[screenImageBase + complete_button];    // Complete button
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;

                case 124:
                    // Maintenance screen
                    //if (screen_choice == 1) screenName = screenImages[screenImageBase + currentScreen + 3];
                    //this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    this.CurrentScreen = 124;
                    using (Graphics g = Graphics.FromImage(this.pictureBoxMain.Image))
                    {
                        int lineSpacing = 0;
                        SolidBrush fillBrush = new SolidBrush(LightGreyBackground);
                        RectangleF rect = new RectangleF(0, 0, 690, 480);
                        g.FillRectangle(fillBrush, rect);
                        g.DrawString("             MAINTENANCE SCREEN",
                            new Font("Tahoma", 32), Brushes.Black,
                            rect);
                        lineSpacing += 40;
                        rect = new Rectangle(5, lineSpacing, 690, 20);
                        g.DrawString("Software Version: " + this.form1.firmwareVersionLabel.Text,
                            new Font("Tahoma", 20), Brushes.Black,
                            rect);
                        lineSpacing += 22;
                        rect = new Rectangle(5, lineSpacing, 690, 20);
                        g.DrawString("Board ID: "+ this.form1.boardSerialNumber.ToString(),
                            new Font("Tahoma", 20), Brushes.Black,
                            rect);
                        lineSpacing += 22;
                        rect = new Rectangle(5, lineSpacing, 690, 20);
                        g.DrawString("RTC Time: " + this.form1.dateLabel.Text + " " + this.form1.timeLabel.Text,
                            new Font("Tahoma", 20), Brushes.Black,
                            rect);
                        lineSpacing += 22;
                        rect = new Rectangle(5, lineSpacing, 690, 20);
                        g.DrawString("Battery: " + this.form1.batteryVolts.Text,
                            new Font("Tahoma", 20), Brushes.Black,
                            rect);
                    }

                    break;
                default:
                    string[] all = System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceNames();
                    this.CurrentScreen = alarm_temp_sensor_disconnected_screen;
                    screenName = screenImages[screenImageBase + this.CurrentScreen];    // Temp sensor alarm DEFAULT
                    this.pictureBoxMain.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
            }
        }

#if false
        private void simulationPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.X > 520) && (e.X < 595))
            {
                if ((e.Y > 50) && (e.Y < 128))
                {
                    // This is in the button 1 area
                    Console.WriteLine("Mouseclick region 1");
                    button1 = true;
                }
                if ((e.Y > 140) && (e.Y < 220))
                {
                    // This is in the button 2 area
                    Console.WriteLine("Mouseclick region 2");
                    button2 = true;
                }

                if ((e.Y > 230) && (e.Y < 309))
                {
                    // This is in the button 3 area
                    Console.WriteLine("Mouseclick region 3");
                    button3 = true;
                }
                if ((e.Y > 320) && (e.Y < 406))
                {
                    // This is in the button 4 area
                    Console.WriteLine("Mouseclick region 4");
                    button4 = true;
                }
            }
            else if ((e.Y > 320) && (e.X < 90))
            {
                // This is in the button 4 area
                Console.WriteLine("Mouseclick region 5");
                button5 = true;
            }
        }
#endif
        private void Simulation_FormClosed(object sender, FormClosedEventArgs e)
        {
            stateChangeThread.Abort();
        }

        private void simulationPictureBox_Paint(object sender, PaintEventArgs e)
        {
            Color myColor = new Color();
            // This draws the setpoints for baby pressure and FiO2 into the lower area (smaller font)
            if ((this.CurrentScreen >= 6) && (this.CurrentScreen < 47))
            {
                using (Font myFont = new Font("Arial", 17))
                {
                    // Draw the Baby Pressure setpoint here
                   // e.Graphics.DrawString(this.form1.PressBabySetpt.Value.ToString(), myFont, Brushes.Black, new Point(170, 384));
                    this.PressSetpt.Value = this.form1.PressBabySetpt.Value;
                    // Draw the FiO2 setpoint here
                    e.Graphics.DrawString(this.form1.Fio2Setpt.Value.ToString(), myFont, Brushes.WhiteSmoke, new Point(410, 384));
                    if (this.form1.Fio2Setpt.Value > 21) this.O2Setpoint.Value = 21;
                    else if (this.form1.Fio2Setpt.Value > 97) this.O2Setpoint.Value = 97;
                    else this.O2Setpoint.Value = this.form1.Fio2Setpt.Value;
                }
            }
            // This draws the current values of baby pressure and FiO2 into the upper panel area (larger font)
            if ((alarmScreenPresent(this.CurrentScreen)) || (therapyScreenPresent(this.CurrentScreen)))
            {
                float fontSize = 72;
                using (Font myFont = new Font("Arial", fontSize))
                {
                    string babyPressureString = this.form1.BabyPressureValue.ToString("N0");
                    Size sizeOfText = TextRenderer.MeasureText(babyPressureString, new Font("Arial", fontSize));
                    int bpStartX = 135;
                    int fio2StartX = 390;
                    int startY = 255;
                    Rectangle babyPressureRectangle = new Rectangle(new Point(bpStartX, startY), sizeOfText);

                    // Draw the Baby Pressure  here
                    if ((this.CurrentScreen == alarm_low_pressure_screen) || (this.CurrentScreen == alarm_high_pressure_screen))
                    {
                        e.Graphics.DrawString(babyPressureString, myFont, Brushes.OrangeRed, new Point(bpStartX, startY));
                    }
                    else
                    {
                        e.Graphics.DrawString(babyPressureString, myFont, Brushes.Black, new Point(bpStartX, startY));
                    }
                    Font unitsFont = new Font("Arial", 18);
                    string units = "cmH₂O";
                    int startUnitsY = startY + 65;
                    e.Graphics.DrawString(units, unitsFont, Brushes.Black, new Point(bpStartX + babyPressureRectangle.Width - 25, startUnitsY));

                    string fio2String = this.form1.FiO2ScreenValue.ToString();
                    babyPressureString += "%O₂";
                    sizeOfText = TextRenderer.MeasureText(fio2String, new Font("Arial", fontSize));
                    Rectangle fio2Rectangle = new Rectangle(new Point(fio2StartX, startY), sizeOfText);

                    // Draw the FiO2 value here
                    if ((this.CurrentScreen == alarm_low_fio2_screen) || (this.CurrentScreen == alarm_high_fio2_screen))
                        e.Graphics.DrawString(fio2String, myFont, Brushes.OrangeRed, new Point(fio2StartX, startY));
                    else
                        e.Graphics.DrawString(fio2String, myFont, Brushes.WhiteSmoke, new Point(fio2StartX, startY));

                    units = "%O₂";
                    e.Graphics.DrawString(units, unitsFont, Brushes.Black, new Point(fio2StartX + fio2Rectangle.Width - 25, startUnitsY));
                }
            }

            // This draws the current values of temperature
            if ((alarmScreenPresent(this.CurrentScreen)) || (therapyScreenPresent(this.CurrentScreen)))
            {
                float fontSize = 22;
                myColor = LightGreyBackground;
                //if (((this.CurrentScreen >= 36) && (this.CurrentScreen <= 40)) || (this.CurrentScreen == 20))
                //{
                    myColor = MediumGreyBackground;
                //}
                SolidBrush mySolidBrush = new SolidBrush(myColor);
                using (Font myFont = new Font("Arial Rounded MT", fontSize))
                {
                    Size sizeOfText = TextRenderer.MeasureText(this.form1.TempProx.Text, new Font("Arial Rounded MT", fontSize));
                    int tempStartX = 530;
                    int tempStartY = 200;
                    //Rectangle temperatureRectangle = new Rectangle(new Point(tempStartX, tempStartY), sizeOfText);
                    //e.Graphics.FillRectangle(mySolidBrush, temperatureRectangle);
                    string temperatureString;
                    if (this.form1.TempProxValue > -40.0)
                    {
                        if ((this.form1.TempDistValue > -40.0) && (this.form1.TempDistValue < this.form1.TempProxValue))
                        {
                            // Temp probe connected and Temp_Dist is lower value
                            temperatureString = this.form1.TempDistValue.ToString("N0");
                        } else
                        {
                            // Temp_prox probe connected and Temp_Dist is not lower value
                            temperatureString = this.form1.TempProxValue.ToString("N0");
                        }

                    } else
                    {
                        // Temp probe disconnected
                        temperatureString = "- -";
                    }
                    // Draw the Temperature Proximate here
                    if ((this.CurrentScreen == alarm_low_temperature_screen) || (this.CurrentScreen == alarm_high_temperature_screen))
                        e.Graphics.DrawString(temperatureString + "°", myFont, Brushes.OrangeRed, new Point(tempStartX, tempStartY));
                    else
                        e.Graphics.DrawString(temperatureString + "°", myFont, Brushes.Black, new Point(tempStartX, tempStartY));
                }

            }

            // This draws the current value of firmware revision
            if ((this.CurrentScreen == splash_start_screen) || (this.CurrentScreen == splash_done_screen))
            {
                float fontSize = 14;
                myColor = LightGreyBackground;
                SolidBrush mySolidBrush = new SolidBrush(myColor);
                using (Font myFont = new Font("Arial", fontSize))
                {
                    string versionString = "Software " + this.form1.firmwareVersionLabel.Text + "        ";
                    Size sizeOfText = TextRenderer.MeasureText(versionString, new Font("Arial", fontSize));
                    int versionStartX = 15;
                    int startY = 227;
                    Rectangle versionRectangle = new Rectangle(new Point(versionStartX, startY), sizeOfText);
                    // First fill in the rectangle - this covers over the "dashes" in the .png file
                    e.Graphics.FillRectangle(mySolidBrush, versionRectangle);

                    // Draw the Baby Pressure setpoint here
                    e.Graphics.DrawString(versionString, myFont, Brushes.Gray, new Point(versionStartX, startY));
                }
            }
            int buttonXLocation = 518;
#if false
            // This will draw the lock and mute buttons
            if (((this.CurrentScreen >= 14) && (this.CurrentScreen <= 21)) || ((this.CurrentScreen >= 36) && (this.CurrentScreen <= 44)))
            {
                float buttonScaleFactorX = .79f; // Scale buttons to fit on simulation screen
                float buttonScaleFactorY = .88f; // Scale buttons to fit on simulation screen
                string[] screenImages = Assembly.GetEntryAssembly().GetManifestResourceNames();
                Bitmap tempImage = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenImages[21]));
                Bitmap LockImage = new Bitmap(tempImage, new Size((int)(tempImage.Width * buttonScaleFactorX), (int)(tempImage.Height * buttonScaleFactorY)));
                tempImage = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenImages[64]));
                Bitmap UnLockImage = new Bitmap(tempImage, new Size((int)(tempImage.Width * buttonScaleFactorX), (int)(tempImage.Height * buttonScaleFactorY)));
                tempImage = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenImages[22]));
                Bitmap MuteImage = new Bitmap(tempImage, new Size((int)(tempImage.Width * buttonScaleFactorX), (int)(tempImage.Height * buttonScaleFactorY)));
                tempImage = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenImages[23]));
                Bitmap UnmuteImage = new Bitmap(tempImage, new Size((int)(tempImage.Width * buttonScaleFactorX), (int)(tempImage.Height * buttonScaleFactorY)));
                if (form1.lockScreenStatus == 1)
                {
                    e.Graphics.DrawImage(UnLockImage, buttonXLocation, 132);
                } else
                {
                    e.Graphics.DrawImage(LockImage, buttonXLocation, 132);
                }
                if (form1.alarmMuteStatus == 0)
                {
                    e.Graphics.DrawImage(MuteImage, buttonXLocation, 317);
                } else
                {
                    e.Graphics.DrawImage(UnmuteImage, buttonXLocation, 317);
                }
            }
            if (((this.CurrentScreen == 19) || (this.CurrentScreen == 21) || ((this.CurrentScreen >= 38) && (this.CurrentScreen <= 44))) && (this.form1.BabyPressureUnderPIDControl))
            {
                // This will draw the PAUSE button on the low-battery screen
                float buttonScaleFactorX = .79f; // Scale buttons to fit on simulation screen
                float buttonScaleFactorY = .88f; // Scale buttons to fit on simulation screen
                string[] screenImages = Assembly.GetEntryAssembly().GetManifestResourceNames();
                Bitmap tempImage = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenImages[25]));
                Bitmap PauseImage = new Bitmap(tempImage, new Size((int)(tempImage.Width * buttonScaleFactorX), (int)(tempImage.Height * buttonScaleFactorY)));
                e.Graphics.DrawImage(PauseImage, buttonXLocation, 224);
            } 
            else if ((this.CurrentScreen == 19) || (this.CurrentScreen == 21) || ((this.CurrentScreen >= 39) && (this.CurrentScreen <= 44))
                        && (!this.form1.BabyPressureUnderPIDControl))
            {
                // This will draw the RUN button on the low-battery screen
                float buttonScaleFactorX = .79f; // Scale buttons to fit on simulation screen
                float buttonScaleFactorY = .88f; // Scale buttons to fit on simulation screen
                string[] screenImages = Assembly.GetEntryAssembly().GetManifestResourceNames();
                Bitmap tempImage = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenImages[26]));
                Bitmap RunImage = new Bitmap(tempImage, new Size((int)(tempImage.Width * buttonScaleFactorX), (int)(tempImage.Height * buttonScaleFactorY)));
                e.Graphics.DrawImage(RunImage, buttonXLocation, 224);
            }
#endif
            // Fill in the battery progress bar
            double battVolts = Convert.ToDouble(form1.batteryVolts.Text);
            Int32 checkBattVolts = Convert.ToInt32(battVolts);
            if (checkBattVolts > this.batteryCharge.Maximum) checkBattVolts = this.batteryCharge.Maximum;
            if (checkBattVolts < this.batteryCharge.Minimum) checkBattVolts = this.batteryCharge.Minimum + 1;
            this.batteryCharge.Value = checkBattVolts;
            if (this.batteryCharge.Value > 22) this.batteryCharge.SetState(1); // this.batteryCharge.ForeColor = Color.Green;
            else if (this.batteryCharge.Value > 21) this.batteryCharge.SetState(3); //this.batteryCharge.ForeColor = Color.Yellow;
            else if (this.batteryCharge.Value <= 21) this.batteryCharge.SetState(2); //this.batteryCharge.ForeColor = Color.Red;

            // decide whether to show the "plugged in" icon
            myColor = MediumBlueBackground;
            SolidBrush plugSolidBrush = new SolidBrush(myColor);
            // If charging and not "Low Battery alarm" screen
            if ((form1.BatteryCurrent > -8.0) && (this.CurrentScreen != alarm_low_battery_screen))
            {
                plugSolidBrush.Color = Color.Empty;
            } else if ((form1.BatteryCurrent < 0) && (this.CurrentScreen == alarm_low_battery_screen))
            {
                // Not charging and alarm screen
                plugSolidBrush.Color = Color.Empty;
            }
            int plugStartX = 562;
            int plugStartY = 5;
            Size plugRectangle = new Size(50, 25);
            Rectangle plugTotalRectangle = new Rectangle(new Point(plugStartX, plugStartY), plugRectangle);
            e.Graphics.FillRectangle(plugSolidBrush, plugTotalRectangle);
        }

        private void pictureBoxPrevious_Click(object sender, EventArgs e)
        {
            // This is in the button "left arrow" area
            Console.WriteLine("Mouseclick Previous button");
            button5 = true;
        }

        private void pictureBoxCircuitTest_Click(object sender, EventArgs e)
        {
            // This is in the button "Test" area
            Console.WriteLine("Mouseclick Circuit Test button");
            button1 = true;
        }

        private void pictureBoxMute_Click(object sender, EventArgs e)
        {
            // This is in the button "Mute" area
            Console.WriteLine("Mouseclick Mute button");
            button4 = true;
        }

        private void pictureBoxPower_Click(object sender, EventArgs e)
        {
            // This is in the button "Power" area
            Console.WriteLine("Mouseclick Power button");
            button10 = true;
        }

        private void pictureBoxPause_Click(object sender, EventArgs e)
        {
            // This is in the button "Pause" area
            Console.WriteLine("Mouseclick Pause button");
            button3 = true;
        }

        private void pictureBoxNext_Click(object sender, EventArgs e)
        {
            // This is in the button "Next" area
            Console.WriteLine("Mouseclick Next button");
            if ((this.CurrentScreen == therapy_setting_screen) || (this.CurrentScreen == therapy_running_screen)) button3 = true;   // pause or run screen
            if (alarmScreenPresent(this.CurrentScreen)) button3 = true;   // any alarm screen
            else button4 = true;    // setup screens
        }

        private void PressSetpt_ValueChanged(object sender, EventArgs e)
        {

            this.form1.PressBabySetpt.Value = this.PressSetpt.Value;
            this.form1.SendPressSetpoint(this.PressSetpt.Value);
            // this.form1.fwViewer.writer.AddTerminalCommand("pressSetpt(" + this.PressSetpt.Value + ")");
        }

        private void O2Setpoint_ValueChanged(object sender, EventArgs e)
        {
            this.form1.Fio2Setpt.Value = this.O2Setpoint.Value;
            this.form1.SendFio2Setpoint(this.O2Setpoint.Value);
           // this.form1.fwViewer.writer.AddTerminalCommand("fio2Setpt(" + this.O2Setpoint.Value + ")");
        }
    }
    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }

}

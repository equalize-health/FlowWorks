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

namespace FlowWorks
{
    public partial class Simulation : Form
    {
        private bool button1 = false;
        private bool button2 = false;
        private bool button3 = false;
        private bool button4 = false;
        private Form1 form1;
        private Thread stateChangeThread;

        public int CurrentScreen { get; private set; }

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
            while (true)
            {
                if (this.form1.isConnected)
                {
                    // This means we request data every 500 msecs (default)
                    Thread.Sleep(500);
                    if (this.form1.CurrentScreen != this.CurrentScreen)
                    {
                        Console.WriteLine("Change to screen: " + this.form1.CurrentScreen.ToString());
                        changeScreen(this.form1.CurrentScreen);
                        this.CurrentScreen = this.form1.CurrentScreen;
                    }
                    if ((this.CurrentScreen >= 1) && (this.CurrentScreen <= 24))
                    {
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

                }
            }
        }

        private void changeScreen(int currentScreen)
        {
            string screenName;
            string[] screenImages = Assembly.GetEntryAssembly().GetManifestResourceNames();
            int screenImageBase = 14 + 1;
            switch (currentScreen)
            {
                case 1:
                    //Splash_START:
                    screenName = screenImages[screenImageBase];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 2:
                    //Splash_PROGRESS
                    screenName = screenImages[screenImageBase+2];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 3:
                    //Splash_DONE
                    screenName = screenImages[screenImageBase+1];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 4:
                    //Fill_Humidifier
                    screenName = screenImages[screenImageBase+3];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 5:
                    //Reinstall_Humidifier
                    screenName = screenImages[screenImageBase+4];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 6:
                    //Connect_Exp
                    screenName = screenImages[screenImageBase+5];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 7:
                    //connect_Heater_to_Insp
                    screenName = screenImages[screenImageBase+6];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 8:
                    //connect_mid_temp_to_Insp
                    screenName = screenImages[screenImageBase-9];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 9:
                    //connect_end_temp_to_Insp
                    screenName = screenImages[screenImageBase-8];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 10:
                    //connect_heater_cable
                    screenName = screenImages[screenImageBase-7];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 11:
                    //connect_temperature_cable
                    screenName = screenImages[screenImageBase-6];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 12:
                    //connect_insp_tube
                    screenName = screenImages[screenImageBase-5];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 13:
                    //connect_nasal_interface
                    screenName = screenImages[screenImageBase-4];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 14:
                    //connect_oxygen
                    screenName = screenImages[screenImageBase-3];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 15:
                    //self_test_start
                    screenName = screenImages[screenImageBase-2];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 16:
                    //self_test_progress
                    screenName = screenImages[screenImageBase-1];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 17:
                    //running_01 encod_Screen1
                    screenName = screenImages[screenImageBase+11];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 18:
                    //running_02 encod_Screen2
                    screenName = screenImages[screenImageBase+12];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 19:
                    //running_03 encod_ScreenDASH
                    screenName = screenImages[screenImageBase+13];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 20:
                    //running_04 encod_ScreenAdjusting
                    screenName = screenImages[screenImageBase+14];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 21:
                    // alarm high pressure
                    screenName = screenImages[screenImageBase+8];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 22:
                    // alarm low pressure
                    screenName = screenImages[screenImageBase+10];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 23:
                    // alarm low FiO2
                    screenName = screenImages[screenImageBase+9];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 24:
                    // alarm low battery
                    screenName = screenImages[screenImageBase+7];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                default:
                    string[] all = System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceNames();
                    screenName = screenImages[screenImageBase+10]; // Alarm screen
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;


            }
        }

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
        }

        private void Simulation_FormClosed(object sender, FormClosedEventArgs e)
        {
            stateChangeThread.Abort();
        }

        private void simulationPictureBox_Paint(object sender, PaintEventArgs e)
        {
            Color myColor = new Color();
            // This draws the setpoints for baby pressure and FiO2 into the lower panel area (smaller font)
            if ((this.CurrentScreen >= 17) && (this.CurrentScreen <= 24))
            {
                using (Font myFont = new Font("Arial", 19))
                {
                    // Draw the Baby Pressure setpoint here
                    e.Graphics.DrawString(this.form1.PressBabySetpt.Value.ToString(), myFont, Brushes.Black, new Point(170, 374));
                    // Draw the FiO2 setpoint here
                    e.Graphics.DrawString(this.form1.Fio2Setpt.Value.ToString(), myFont, Brushes.WhiteSmoke, new Point(410, 374));
                }
            }
            // This draws the current values of baby pressure and FiO2 into the upper panel area (larger font)
            if ((this.CurrentScreen >= 18) && (this.CurrentScreen <= 24))
            {
                float fontSize = 72;
                using (Font myFont = new Font("Arial", fontSize))
                {
                    string babyPressureString = this.form1.BabyPressureValue.ToString("N0");
                    Size sizeOfText = TextRenderer.MeasureText(babyPressureString, new Font("Arial", fontSize));
                    int bpStartX = 105;
                    int fio2StartX = 330;
                    int startY = 255;
                    Rectangle babyPressureRectangle = new Rectangle(new Point(bpStartX, startY), sizeOfText);
                    if (this.CurrentScreen != 18)
                    {
                        // First fill in the rectangle - this covers over the "dashes" in the .png file
                        e.Graphics.FillRectangle(Brushes.White, babyPressureRectangle);
                    }
                    // Draw the Baby Pressure setpoint here
                    if (this.CurrentScreen == 21 || this.CurrentScreen == 22)
                        e.Graphics.DrawString(babyPressureString, myFont, Brushes.OrangeRed, new Point(bpStartX, startY));
                    else
                        e.Graphics.DrawString(babyPressureString, myFont, Brushes.Black, new Point(bpStartX, startY));
                    string fio2String = this.form1.FiO2Value.ToString("N0");
                    sizeOfText = TextRenderer.MeasureText(fio2String, new Font("Arial", fontSize));
                    Rectangle fio2Rectangle = new Rectangle(new Point(fio2StartX, startY), sizeOfText);
                    // Don't need the background box for the screen with no dashes
                    if (this.CurrentScreen != 18)
                    {
                        myColor =
                            Color.FromArgb(
                                255, // Specifies the transparency of the color.
                                87, // Specifies the amount of red.
                                87, // specifies the amount of green.
                                87); // Specifies the amount of blue.
                        SolidBrush mySolidBrush = new SolidBrush(myColor);
                        // First fill in the rectangle - this covers over the "dashes" in the .png file
                        e.Graphics.FillRectangle(mySolidBrush, fio2Rectangle);
                    }
                    // Draw the FiO2 value here
                    if (this.CurrentScreen == 23 || this.CurrentScreen == 23)
                        e.Graphics.DrawString(fio2String, myFont, Brushes.OrangeRed, new Point(fio2StartX, startY));
                    else
                        e.Graphics.DrawString(fio2String, myFont, Brushes.WhiteSmoke, new Point(fio2StartX, startY));
                }
            }

            // This draws the current values of temperature
            if ((this.CurrentScreen >= 17) && (this.CurrentScreen <= 24))
            {
                float fontSize = 22;
                myColor =
                    Color.FromArgb(
                        255, // Specifies the transparency of the color.
                        220, // Specifies the amount of red.
                        220, // specifies the amount of green.
                        220); // Specifies the amount of blue.
                SolidBrush mySolidBrush = new SolidBrush(myColor);
                using (Font myFont = new Font("Arial Rounded MT", fontSize))
                {
                    Size sizeOfText = TextRenderer.MeasureText(this.form1.TempProx.Text, new Font("Arial Rounded MT", fontSize));
                    int tempStartX = 530;
                    int tempStartY = 60;
                    Rectangle temperatureRectangle = new Rectangle(new Point(tempStartX, tempStartY), sizeOfText);
                    e.Graphics.FillRectangle(mySolidBrush, temperatureRectangle);
                    string temperatureString = this.form1.TempProxValue.ToString("N0");
                    // Draw the Temperature Proximate here
                    e.Graphics.DrawString(temperatureString + "°", myFont, Brushes.Black, new Point(tempStartX, tempStartY));
                }

            }

            // This draws the current value of firmware revision
            if ((this.CurrentScreen == 1))
            {
                float fontSize = 14;
                myColor =
                    Color.FromArgb(
                        255, // Specifies the transparency of the color.
                        245, // Specifies the amount of red.
                        245, // specifies the amount of green.
                        245); // Specifies the amount of blue.
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
            // Fill in the battery progress bar
            this.batteryCharge.Value = Convert.ToInt32(form1.BatteryCharge);
            if (this.batteryCharge.Value > 50) this.batteryCharge.ForeColor = Color.Green;
            else if (this.batteryCharge.Value > 30) this.batteryCharge.ForeColor = Color.Yellow;
            else if (this.batteryCharge.Value <= 30) this.batteryCharge.ForeColor = Color.Red;
        }
    }
}

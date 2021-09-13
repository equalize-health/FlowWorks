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
        private Form1 form1;
        private Thread stateChangeThread;
        private Color MediumGreyBackground;
        private Color LightGreyBackground;
        private Color DarkGreyBackground;

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
                    if ((this.CurrentScreen >= 1) && (this.CurrentScreen <= 40))
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
                    else if (button5)
                    {
                        this.form1.SendTerminalCommand("button(5)");
                        button5 = false;
                    }
                }
            }
        }

        private void changeScreen(int currentScreen)
        {
            string screenName;
            string[] screenImages = Assembly.GetEntryAssembly().GetManifestResourceNames();
            int screenImageBase = 23;
            switch (currentScreen)
            {
                case 1:
                    //Splash_START:
                    screenName = screenImages[screenImageBase];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
               // case 2:
                    //Splash_PROGRESS
                 //   screenName = screenImages[screenImageBase+2];
                 //   this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                 //   break;
                case 2:
                    //Splash_DONE
                    screenName = screenImages[screenImageBase+ currentScreen - 1];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 3:
                    //Fill_Humidifier
                    screenName = screenImages[screenImageBase + currentScreen - 1];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 4:
                    //Reinstall_Humidifier
                    screenName = screenImages[screenImageBase + currentScreen - 1];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 5:
                    //Connect_Exp
                    screenName = screenImages[screenImageBase + currentScreen - 1];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 6:
                    //connect_Heater_to_Insp
                    screenName = screenImages[screenImageBase + currentScreen - 1];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 7:
                    //connect_mid_temp_to_Insp
                    screenName = screenImages[screenImageBase + currentScreen - 1];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 8:
                    //connect_end_temp_to_Insp
                    screenName = screenImages[screenImageBase + currentScreen - 1];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 9:
                    //connect_heater_cable
                    screenName = screenImages[screenImageBase + currentScreen - 1];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 10:
                    //connect_temperature_cable
                    screenName = screenImages[screenImageBase + currentScreen - 1];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 11:
                    //connect_insp_tube
                    screenName = screenImages[screenImageBase + currentScreen - 1];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 34:
                    // CPAP below patient
                    screenName = screenImages[13];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 35:
                    // change filter
                    screenName = screenImages[9];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 12:
                    //self_test_start
                    screenName = screenImages[screenImageBase + currentScreen - 1];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 13:
                    //self_test_progress
                    screenName = screenImages[screenImageBase + currentScreen - 1];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 14:
                    //Pause, waiting to run
                    screenName = screenImages[screenImageBase + currentScreen - 1];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 15:
                    //Adjusting to new setpoint
                    screenName = screenImages[screenImageBase + currentScreen + 3];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 16:
                    //running  stable
                    screenName = screenImages[screenImageBase + currentScreen + 5];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 17:
                    // Low pressure alarm
                    screenName = screenImages[screenImageBase + currentScreen + 9];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 18:
                    // Low Fio2
                    screenName = screenImages[screenImageBase + currentScreen + 12];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
               // case 19:
                    // alarm low pressure
               //     screenName = screenImages[screenImageBase + currentScreen + 12];
               //     this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                //    break;
                case 19:
                    // alarm low battery
                    screenName = screenImages[screenImageBase + currentScreen + 14];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 20:
                    // High Pressure alarm
                    screenName = screenImages[screenImageBase + currentScreen + 17];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 21:
                    // occlusion
                    screenName = screenImages[screenImageBase + currentScreen + 14];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 36:
                    // Critically low battery alarm
                    screenName = screenImages[7];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 37:
                    // heater cable disconnected alarm
                    screenName = screenImages[10];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 38:
                    // high temperature alarm
                    screenName = screenImages[12];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 39:
                    // temp sensor disconnected alarm
                    screenName = screenImages[14];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 40:
                    // high FiO2 alarm
                    screenName = screenImages[11];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 22:
                    // lock button
                    screenName = screenImages[currentScreen - 5];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 23:
                    // unlock button
                    screenName = screenImages[60];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 24:
                    // mute button
                    screenName = screenImages[currentScreen - 6];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 25:
                    // unmute button
                    screenName = screenImages[currentScreen - 6];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 26:
                    // back button
                    screenName = screenImages[15];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 27:
                    // change button
                    screenName = screenImages[16];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 28:
                    // next button
                    screenName = screenImages[20];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 29:
                    // pause button
                    screenName = screenImages[21];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 30:
                    // run button
                    screenName = screenImages[22];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 31:
                    // skip setup button
                    screenName = screenImages[59];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 32:
                    // dismiss button
                    screenName = screenImages[8];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 33:
                    // complete button
                    screenName = screenImages[6];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 124:
                    // Maintenance screen
                    //screenName = screenImages[screenImageBase + currentScreen + 3];
                    //this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    using (Graphics g = Graphics.FromImage(this.simulationPictureBox.Image))
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
            else if ((e.Y > 320) && (e.X < 90))
            {
                // This is in the button 4 area
                Console.WriteLine("Mouseclick region 5");
                button5 = true;
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
            if (((this.CurrentScreen >= 14) && (this.CurrentScreen < 24)) || ((this.CurrentScreen >= 36) && (this.CurrentScreen <= 40)))
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
            if (((this.CurrentScreen >= 14) && (this.CurrentScreen < 24)) || ((this.CurrentScreen >= 36) && (this.CurrentScreen <= 40)))
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
                    string fio2String = this.form1.FiO2ScreenValue.ToString();
                    sizeOfText = TextRenderer.MeasureText(fio2String, new Font("Arial", fontSize));
                    Rectangle fio2Rectangle = new Rectangle(new Point(fio2StartX, startY), sizeOfText);
                    // Don't need the background box for the screen with no dashes
                    if (this.CurrentScreen != 18)
                    {
                        myColor = DarkGreyBackground;
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
            if ((this.CurrentScreen >= 15) && (this.CurrentScreen <= 40))
            {
                float fontSize = 22;
                myColor = LightGreyBackground;
                SolidBrush mySolidBrush = new SolidBrush(myColor);
                using (Font myFont = new Font("Arial Rounded MT", fontSize))
                {
                    Size sizeOfText = TextRenderer.MeasureText(this.form1.TempProx.Text, new Font("Arial Rounded MT", fontSize));
                    int tempStartX = 530;
                    int tempStartY = 60;
                    Rectangle temperatureRectangle = new Rectangle(new Point(tempStartX, tempStartY), sizeOfText);
                    e.Graphics.FillRectangle(mySolidBrush, temperatureRectangle);
                    string temperatureString;
                    if (this.form1.TempProxValue > -40.0)
                    {
                        // Temp probe connected
                        temperatureString = this.form1.TempProxValue.ToString("N0");
                    } else
                    {
                        // Temp probe disconnected
                        temperatureString = "- -";
                    }
                    // Draw the Temperature Proximate here
                    e.Graphics.DrawString(temperatureString + "°", myFont, Brushes.Black, new Point(tempStartX, tempStartY));
                }

            }

            // This draws the current value of firmware revision
            if ((this.CurrentScreen == 1))
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
            // This will draw the lock and mute buttons
            if (((this.CurrentScreen >= 14) && (this.CurrentScreen < 21)) || ((this.CurrentScreen >= 36) && (this.CurrentScreen <= 40)))
            {
                float buttonScaleFactorX = .79f; // Scale buttons to fit on simulation screen
                float buttonScaleFactorY = .88f; // Scale buttons to fit on simulation screen
                string[] screenImages = Assembly.GetEntryAssembly().GetManifestResourceNames();
                Bitmap tempImage = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenImages[17]));
                Bitmap LockImage = new Bitmap(tempImage, new Size((int)(tempImage.Width * buttonScaleFactorX), (int)(tempImage.Height * buttonScaleFactorY)));
                tempImage = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenImages[60]));
                Bitmap UnLockImage = new Bitmap(tempImage, new Size((int)(tempImage.Width * buttonScaleFactorX), (int)(tempImage.Height * buttonScaleFactorY)));
                tempImage = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenImages[18]));
                Bitmap MuteImage = new Bitmap(tempImage, new Size((int)(tempImage.Width * buttonScaleFactorX), (int)(tempImage.Height * buttonScaleFactorY)));
                tempImage = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenImages[19]));
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
            if (((this.CurrentScreen == 19) || (this.CurrentScreen == 21) || (this.CurrentScreen == 38) || (this.CurrentScreen == 39) || (this.CurrentScreen == 40)) && (this.form1.BabyPressureUnderPIDControl))
            {
                // This will draw the PAUSE button on the low-battery screen
                float buttonScaleFactorX = .79f; // Scale buttons to fit on simulation screen
                float buttonScaleFactorY = .88f; // Scale buttons to fit on simulation screen
                string[] screenImages = Assembly.GetEntryAssembly().GetManifestResourceNames();
                Bitmap tempImage = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenImages[21]));
                Bitmap PauseImage = new Bitmap(tempImage, new Size((int)(tempImage.Width * buttonScaleFactorX), (int)(tempImage.Height * buttonScaleFactorY)));
                e.Graphics.DrawImage(PauseImage, buttonXLocation, 224);
            } 
            else if (((this.CurrentScreen == 19) || (this.CurrentScreen == 21) || (this.CurrentScreen == 39)) 
                        && (!this.form1.BabyPressureUnderPIDControl))
            {
                // This will draw the RUN button on the low-battery screen
                float buttonScaleFactorX = .79f; // Scale buttons to fit on simulation screen
                float buttonScaleFactorY = .88f; // Scale buttons to fit on simulation screen
                string[] screenImages = Assembly.GetEntryAssembly().GetManifestResourceNames();
                Bitmap tempImage = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenImages[22]));
                Bitmap RunImage = new Bitmap(tempImage, new Size((int)(tempImage.Width * buttonScaleFactorX), (int)(tempImage.Height * buttonScaleFactorY)));
                e.Graphics.DrawImage(RunImage, buttonXLocation, 224);
            }
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
            myColor = MediumGreyBackground;
            SolidBrush plugSolidBrush = new SolidBrush(myColor);
            // If charging and not "Low Battery alarm" screen
            if ((form1.BatteryCurrent > -8.0) && (this.CurrentScreen != 24))
            {
                plugSolidBrush.Color = Color.Empty;
            } else if ((form1.BatteryCurrent < 0) && (this.CurrentScreen == 24))
            {
                // Not charging and alarm screen
                plugSolidBrush.Color = Color.Empty;
            }
            int plugStartX = 562;
            int plugStartY = 8;
            Size plugRectangle = new Size(32, 25);
            Rectangle plugTotalRectangle = new Rectangle(new Point(plugStartX, plugStartY), plugRectangle);
            e.Graphics.FillRectangle(plugSolidBrush, plugTotalRectangle);
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

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
                        changeScreen(this.form1.CurrentScreen);
                        this.CurrentScreen = this.form1.CurrentScreen;
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
            switch (currentScreen)
            {
                case 3:
                    //Splash_START:
                    screenName = Assembly.GetEntryAssembly().GetManifestResourceNames()[14];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 4:
                    //Splash_PROGRESS
                    screenName = Assembly.GetEntryAssembly().GetManifestResourceNames()[16];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 5:
                    //Splash_DONE
                    screenName = Assembly.GetEntryAssembly().GetManifestResourceNames()[15];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 6:
                    //Fill_Humidifier
                    screenName = Assembly.GetEntryAssembly().GetManifestResourceNames()[17];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 7:
                    //Reinstall_Humidifier
                    screenName = Assembly.GetEntryAssembly().GetManifestResourceNames()[18];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 8:
                    //Connect_Exp
                    screenName = Assembly.GetEntryAssembly().GetManifestResourceNames()[19];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 9:
                    //connect_Heater_to_Insp
                    screenName = Assembly.GetEntryAssembly().GetManifestResourceNames()[20];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 10:
                    //connect_mid_temp_to_Insp
                    screenName = Assembly.GetEntryAssembly().GetManifestResourceNames()[5];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 11:
                    //connect_end_temp_to_Insp
                    screenName = Assembly.GetEntryAssembly().GetManifestResourceNames()[6];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 12:
                    //connect_heater_cable
                    screenName = Assembly.GetEntryAssembly().GetManifestResourceNames()[7];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 13:
                    //connect_temperature_cable
                    screenName = Assembly.GetEntryAssembly().GetManifestResourceNames()[8];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 14:
                    //connect_insp_tube
                    screenName = Assembly.GetEntryAssembly().GetManifestResourceNames()[9];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 15:
                    //connect_nasal_interface
                    screenName = Assembly.GetEntryAssembly().GetManifestResourceNames()[10];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 16:
                    //connect_oxygen
                    screenName = Assembly.GetEntryAssembly().GetManifestResourceNames()[11];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 17:
                    //self_test_start
                    screenName = Assembly.GetEntryAssembly().GetManifestResourceNames()[12];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 18:
                    //self_test_progress
                    screenName = Assembly.GetEntryAssembly().GetManifestResourceNames()[13];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 19:
                    //running_01 encod_Screen1
                    screenName = Assembly.GetEntryAssembly().GetManifestResourceNames()[25];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 20:
                    //running_02 encod_Screen2
                    screenName = Assembly.GetEntryAssembly().GetManifestResourceNames()[26];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 21:
                    //running_03 encod_ScreenDASH
                    screenName = Assembly.GetEntryAssembly().GetManifestResourceNames()[27];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                case 22:
                    //running_04 encod_ScreenAdjusting
                    screenName = Assembly.GetEntryAssembly().GetManifestResourceNames()[28];
                    this.simulationPictureBox.Image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(screenName));
                    break;
                default:
                    string[] all = System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceNames();
                    screenName = Assembly.GetEntryAssembly().GetManifestResourceNames()[24]; // ALarm screen
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
    }
}

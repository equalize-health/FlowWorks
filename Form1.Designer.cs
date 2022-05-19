using System.Reflection;

namespace FlowWorks
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ToolStripMenuItem cOM1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOM2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOM3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOM4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOM5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOM6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOM7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOM8ToolStripMenuItem;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.setupMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.comportMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.enableLoggingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.startFirwmareDownloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startFirmwareDownloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutFirmwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VersionString = new System.Windows.Forms.ToolStripMenuItem();
            this.helpDocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOM1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOM2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOM3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOM4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOM5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOM6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOM7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOM8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectedTextBox = new System.Windows.Forms.TextBox();
            this.commandBox = new System.Windows.Forms.TextBox();
            this.firmwareVersionLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.responseBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BlowerSpeed = new System.Windows.Forms.Label();
            this.BabyPressure = new System.Windows.Forms.Label();
            this.FlowLeak = new System.Windows.Forms.Label();
            this.PressExp = new System.Windows.Forms.Label();
            this.PressCkt = new System.Windows.Forms.Label();
            this.FlowExp = new System.Windows.Forms.Label();
            this.TempProx = new System.Windows.Forms.Label();
            this.TempDist = new System.Windows.Forms.Label();
            this.TempPlate = new System.Windows.Forms.Label();
            this.PressInsp = new System.Windows.Forms.Label();
            this.FlowInsp = new System.Windows.Forms.Label();
            this.FlowOx = new System.Windows.Forms.Label();
            this.TempAmb = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.PressBabySetpt = new System.Windows.Forms.NumericUpDown();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Fio2Setpt = new System.Windows.Forms.NumericUpDown();
            this.StartBabyPressure = new System.Windows.Forms.Button();
            this.StartFiO2 = new System.Windows.Forms.Button();
            this.SetBlower = new System.Windows.Forms.NumericUpDown();
            this.SetPropValve = new System.Windows.Forms.NumericUpDown();
            this.Calibrate = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cFactor = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.StartHeatPlate = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.StartHeatWire = new System.Windows.Forms.Button();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.HeatPlateSetting = new System.Windows.Forms.NumericUpDown();
            this.HeatWireSetting = new System.Windows.Forms.NumericUpDown();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.FiO2 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.StartSimulation = new System.Windows.Forms.Button();
            this.o2SensorAvg = new System.Windows.Forms.Label();
            this.o2SensorStatusDescription = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.batteryVolts = new System.Windows.Forms.Label();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.TempInsp = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PressBabySetpt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Fio2Setpt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetBlower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetPropValve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeatPlateSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeatWireSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupMenu,
            this.toolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(5170, 150);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // setupMenu
            // 
            this.setupMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comportMenu,
            this.enableLoggingToolStripMenuItem});
            this.setupMenu.Name = "setupMenu";
            this.setupMenu.Size = new System.Drawing.Size(119, 146);
            this.setupMenu.Text = "Setup";
            this.setupMenu.Click += new System.EventHandler(this.RefreshComList);
            // 
            // comportMenu
            // 
            this.comportMenu.Name = "comportMenu";
            this.comportMenu.Size = new System.Drawing.Size(411, 54);
            this.comportMenu.Text = "COM Port";
            // 
            // enableLoggingToolStripMenuItem
            // 
            this.enableLoggingToolStripMenuItem.Name = "enableLoggingToolStripMenuItem";
            this.enableLoggingToolStripMenuItem.Size = new System.Drawing.Size(411, 54);
            this.enableLoggingToolStripMenuItem.Text = "Enable Logging...";
            this.enableLoggingToolStripMenuItem.Click += new System.EventHandler(this.enableLoggingToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startFirwmareDownloadToolStripMenuItem,
            this.startFirmwareDownloadToolStripMenuItem,
            this.aboutFirmwareToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(178, 146);
            this.toolStripMenuItem1.Text = "Download";
            // 
            // startFirwmareDownloadToolStripMenuItem
            // 
            this.startFirwmareDownloadToolStripMenuItem.Name = "startFirwmareDownloadToolStripMenuItem";
            this.startFirwmareDownloadToolStripMenuItem.Size = new System.Drawing.Size(576, 54);
            this.startFirwmareDownloadToolStripMenuItem.Text = "Start Firwmare Download";
            this.startFirwmareDownloadToolStripMenuItem.Click += new System.EventHandler(this.startFirwmareDownloadToolStripMenuItem_Click);
            // 
            // startFirmwareDownloadToolStripMenuItem
            // 
            this.startFirmwareDownloadToolStripMenuItem.Name = "startFirmwareDownloadToolStripMenuItem";
            this.startFirmwareDownloadToolStripMenuItem.Size = new System.Drawing.Size(576, 54);
            this.startFirmwareDownloadToolStripMenuItem.Text = "Start Firmware J19 Download ";
            this.startFirmwareDownloadToolStripMenuItem.Click += new System.EventHandler(this.startFirmwareDownloadToolStripMenuItem_Click);
            // 
            // aboutFirmwareToolStripMenuItem
            // 
            this.aboutFirmwareToolStripMenuItem.Name = "aboutFirmwareToolStripMenuItem";
            this.aboutFirmwareToolStripMenuItem.Size = new System.Drawing.Size(576, 54);
            this.aboutFirmwareToolStripMenuItem.Text = "About Firmware";
            this.aboutFirmwareToolStripMenuItem.Click += new System.EventHandler(this.aboutFirmwareToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VersionString,
            this.helpDocToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(124, 146);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // VersionString
            // 
            this.VersionString.Name = "VersionString";
            this.VersionString.Size = new System.Drawing.Size(352, 54);
            this.VersionString.Text = "Version 1.0.0";
            // 
            // helpDocToolStripMenuItem
            // 
            this.helpDocToolStripMenuItem.Name = "helpDocToolStripMenuItem";
            this.helpDocToolStripMenuItem.Size = new System.Drawing.Size(352, 54);
            this.helpDocToolStripMenuItem.Text = "Help Doc";
            this.helpDocToolStripMenuItem.Click += new System.EventHandler(this.helpDocToolStripMenuItem_Click);
            // 
            // cOM1ToolStripMenuItem
            // 
            this.cOM1ToolStripMenuItem.Name = "cOM1ToolStripMenuItem";
            this.cOM1ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // cOM2ToolStripMenuItem
            // 
            this.cOM2ToolStripMenuItem.Name = "cOM2ToolStripMenuItem";
            this.cOM2ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // cOM3ToolStripMenuItem
            // 
            this.cOM3ToolStripMenuItem.Name = "cOM3ToolStripMenuItem";
            this.cOM3ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // cOM4ToolStripMenuItem
            // 
            this.cOM4ToolStripMenuItem.Name = "cOM4ToolStripMenuItem";
            this.cOM4ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // cOM5ToolStripMenuItem
            // 
            this.cOM5ToolStripMenuItem.Name = "cOM5ToolStripMenuItem";
            this.cOM5ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // cOM6ToolStripMenuItem
            // 
            this.cOM6ToolStripMenuItem.Name = "cOM6ToolStripMenuItem";
            this.cOM6ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // cOM7ToolStripMenuItem
            // 
            this.cOM7ToolStripMenuItem.Name = "cOM7ToolStripMenuItem";
            this.cOM7ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // cOM8ToolStripMenuItem
            // 
            this.cOM8ToolStripMenuItem.Name = "cOM8ToolStripMenuItem";
            this.cOM8ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // connectedTextBox
            // 
            this.connectedTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.connectedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.connectedTextBox.Location = new System.Drawing.Point(202, 70);
            this.connectedTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.connectedTextBox.Name = "connectedTextBox";
            this.connectedTextBox.ReadOnly = true;
            this.connectedTextBox.Size = new System.Drawing.Size(32, 38);
            this.connectedTextBox.TabIndex = 18;
            // 
            // commandBox
            // 
            this.commandBox.AcceptsReturn = true;
            this.commandBox.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commandBox.Location = new System.Drawing.Point(52, 865);
            this.commandBox.Margin = new System.Windows.Forms.Padding(5);
            this.commandBox.Multiline = true;
            this.commandBox.Name = "commandBox";
            this.commandBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.commandBox.Size = new System.Drawing.Size(646, 119);
            this.commandBox.TabIndex = 20;
            this.commandBox.Click += new System.EventHandler(this.commandBox_Click);
            this.commandBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.commandBox_KeyDown);
            // 
            // firmwareVersionLabel
            // 
            this.firmwareVersionLabel.AutoSize = true;
            this.firmwareVersionLabel.Location = new System.Drawing.Point(605, 75);
            this.firmwareVersionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.firmwareVersionLabel.Name = "firmwareVersionLabel";
            this.firmwareVersionLabel.Size = new System.Drawing.Size(93, 32);
            this.firmwareVersionLabel.TabIndex = 30;
            this.firmwareVersionLabel.Text = "v0.0.0";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(908, 75);
            this.dateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(127, 32);
            this.dateLabel.TabIndex = 49;
            this.dateLabel.Text = "00/00/00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(820, 75);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 32);
            this.label7.TabIndex = 50;
            this.label7.Text = "Date:";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(1220, 75);
            this.timeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(127, 32);
            this.timeLabel.TabIndex = 51;
            this.timeLabel.Text = "00:00:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1118, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 32);
            this.label1.TabIndex = 52;
            this.label1.Text = "Time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 32);
            this.label2.TabIndex = 53;
            this.label2.Text = "Connected:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 812);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 32);
            this.label3.TabIndex = 54;
            this.label3.Text = "Command:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(460, 75);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 32);
            this.label4.TabIndex = 55;
            this.label4.Text = "Firmware:";
            // 
            // responseBox
            // 
            this.responseBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.responseBox.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.responseBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.responseBox.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.responseBox.Location = new System.Drawing.Point(52, 1090);
            this.responseBox.Margin = new System.Windows.Forms.Padding(5);
            this.responseBox.MaximumSize = new System.Drawing.Size(1782, 1000);
            this.responseBox.MaxLength = 1200;
            this.responseBox.Multiline = true;
            this.responseBox.Name = "responseBox";
            this.responseBox.ReadOnly = true;
            this.responseBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.responseBox.Size = new System.Drawing.Size(1782, 480);
            this.responseBox.TabIndex = 56;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 1012);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(207, 32);
            this.label5.TabIndex = 57;
            this.label5.Text = "Response Box:";
            // 
            // BlowerSpeed
            // 
            this.BlowerSpeed.AutoSize = true;
            this.BlowerSpeed.ForeColor = System.Drawing.SystemColors.Highlight;
            this.BlowerSpeed.Location = new System.Drawing.Point(382, 500);
            this.BlowerSpeed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BlowerSpeed.Name = "BlowerSpeed";
            this.BlowerSpeed.Size = new System.Drawing.Size(31, 32);
            this.BlowerSpeed.TabIndex = 59;
            this.BlowerSpeed.Text = "0";
            // 
            // BabyPressure
            // 
            this.BabyPressure.AutoSize = true;
            this.BabyPressure.ForeColor = System.Drawing.Color.Maroon;
            this.BabyPressure.Location = new System.Drawing.Point(1240, 300);
            this.BabyPressure.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BabyPressure.Name = "BabyPressure";
            this.BabyPressure.Size = new System.Drawing.Size(71, 32);
            this.BabyPressure.TabIndex = 60;
            this.BabyPressure.Text = "0.00";
            this.BabyPressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FlowLeak
            // 
            this.FlowLeak.AutoSize = true;
            this.FlowLeak.ForeColor = System.Drawing.Color.Maroon;
            this.FlowLeak.Location = new System.Drawing.Point(1042, 247);
            this.FlowLeak.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FlowLeak.Name = "FlowLeak";
            this.FlowLeak.Size = new System.Drawing.Size(55, 32);
            this.FlowLeak.TabIndex = 61;
            this.FlowLeak.Text = "0.0";
            this.FlowLeak.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PressExp
            // 
            this.PressExp.AutoSize = true;
            this.PressExp.ForeColor = System.Drawing.SystemColors.Highlight;
            this.PressExp.Location = new System.Drawing.Point(1420, 535);
            this.PressExp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PressExp.Name = "PressExp";
            this.PressExp.Size = new System.Drawing.Size(55, 32);
            this.PressExp.TabIndex = 62;
            this.PressExp.Text = "0.0";
            this.PressExp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PressCkt
            // 
            this.PressCkt.AutoSize = true;
            this.PressCkt.ForeColor = System.Drawing.Color.Maroon;
            this.PressCkt.Location = new System.Drawing.Point(1160, 544);
            this.PressCkt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PressCkt.Name = "PressCkt";
            this.PressCkt.Size = new System.Drawing.Size(55, 32);
            this.PressCkt.TabIndex = 63;
            this.PressCkt.Text = "0.0";
            this.PressCkt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FlowExp
            // 
            this.FlowExp.AutoSize = true;
            this.FlowExp.ForeColor = System.Drawing.Color.Maroon;
            this.FlowExp.Location = new System.Drawing.Point(1465, 290);
            this.FlowExp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FlowExp.Name = "FlowExp";
            this.FlowExp.Size = new System.Drawing.Size(55, 32);
            this.FlowExp.TabIndex = 64;
            this.FlowExp.Text = "0.0";
            this.FlowExp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TempProx
            // 
            this.TempProx.AutoSize = true;
            this.TempProx.ForeColor = System.Drawing.SystemColors.Highlight;
            this.TempProx.Location = new System.Drawing.Point(1007, 322);
            this.TempProx.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TempProx.Name = "TempProx";
            this.TempProx.Size = new System.Drawing.Size(55, 32);
            this.TempProx.TabIndex = 65;
            this.TempProx.Text = "0.0";
            this.TempProx.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TempDist
            // 
            this.TempDist.AutoSize = true;
            this.TempDist.ForeColor = System.Drawing.SystemColors.Highlight;
            this.TempDist.Location = new System.Drawing.Point(735, 308);
            this.TempDist.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TempDist.Name = "TempDist";
            this.TempDist.Size = new System.Drawing.Size(55, 32);
            this.TempDist.TabIndex = 66;
            this.TempDist.Text = "0.0";
            this.TempDist.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TempPlate
            // 
            this.TempPlate.AutoSize = true;
            this.TempPlate.ForeColor = System.Drawing.SystemColors.Highlight;
            this.TempPlate.Location = new System.Drawing.Point(820, 500);
            this.TempPlate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TempPlate.Name = "TempPlate";
            this.TempPlate.Size = new System.Drawing.Size(55, 32);
            this.TempPlate.TabIndex = 67;
            this.TempPlate.Text = "0.0";
            this.TempPlate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PressInsp
            // 
            this.PressInsp.AutoSize = true;
            this.PressInsp.ForeColor = System.Drawing.SystemColors.Highlight;
            this.PressInsp.Location = new System.Drawing.Point(455, 235);
            this.PressInsp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PressInsp.Name = "PressInsp";
            this.PressInsp.Size = new System.Drawing.Size(55, 32);
            this.PressInsp.TabIndex = 68;
            this.PressInsp.Text = "0.0";
            this.PressInsp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FlowInsp
            // 
            this.FlowInsp.AutoSize = true;
            this.FlowInsp.ForeColor = System.Drawing.SystemColors.Highlight;
            this.FlowInsp.Location = new System.Drawing.Point(382, 339);
            this.FlowInsp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FlowInsp.Name = "FlowInsp";
            this.FlowInsp.Size = new System.Drawing.Size(55, 32);
            this.FlowInsp.TabIndex = 69;
            this.FlowInsp.Text = "0.0";
            this.FlowInsp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FlowOx
            // 
            this.FlowOx.AutoSize = true;
            this.FlowOx.ForeColor = System.Drawing.SystemColors.Highlight;
            this.FlowOx.Location = new System.Drawing.Point(284, 279);
            this.FlowOx.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FlowOx.Name = "FlowOx";
            this.FlowOx.Size = new System.Drawing.Size(55, 32);
            this.FlowOx.TabIndex = 70;
            this.FlowOx.Text = "0.0";
            this.FlowOx.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TempAmb
            // 
            this.TempAmb.AutoSize = true;
            this.TempAmb.ForeColor = System.Drawing.SystemColors.Highlight;
            this.TempAmb.Location = new System.Drawing.Point(890, 200);
            this.TempAmb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TempAmb.Name = "TempAmb";
            this.TempAmb.Size = new System.Drawing.Size(55, 32);
            this.TempAmb.TabIndex = 71;
            this.TempAmb.Text = "0.0";
            this.TempAmb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(392, 668);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(242, 31);
            this.textBox1.TabIndex = 72;
            this.textBox1.Text = "Set Baby Pressure:";
            // 
            // PressBabySetpt
            // 
            this.PressBabySetpt.Location = new System.Drawing.Point(638, 665);
            this.PressBabySetpt.Margin = new System.Windows.Forms.Padding(2);
            this.PressBabySetpt.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PressBabySetpt.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.PressBabySetpt.Name = "PressBabySetpt";
            this.PressBabySetpt.Size = new System.Drawing.Size(85, 38);
            this.PressBabySetpt.TabIndex = 73;
            this.PressBabySetpt.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.PressBabySetpt.ValueChanged += new System.EventHandler(this.PressBabySetpt_ValueChanged);
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(980, 665);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(125, 31);
            this.textBox2.TabIndex = 74;
            this.textBox2.Text = "Set FiO₂:";
            // 
            // Fio2Setpt
            // 
            this.Fio2Setpt.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.Fio2Setpt.Location = new System.Drawing.Point(1110, 662);
            this.Fio2Setpt.Margin = new System.Windows.Forms.Padding(2);
            this.Fio2Setpt.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.Fio2Setpt.Name = "Fio2Setpt";
            this.Fio2Setpt.Size = new System.Drawing.Size(95, 38);
            this.Fio2Setpt.TabIndex = 75;
            this.Fio2Setpt.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.Fio2Setpt.ValueChanged += new System.EventHandler(this.Fio2Setpt_ValueChanged);
            // 
            // StartBabyPressure
            // 
            this.StartBabyPressure.BackColor = System.Drawing.Color.LightGray;
            this.StartBabyPressure.Location = new System.Drawing.Point(625, 715);
            this.StartBabyPressure.Margin = new System.Windows.Forms.Padding(2);
            this.StartBabyPressure.Name = "StartBabyPressure";
            this.StartBabyPressure.Size = new System.Drawing.Size(110, 50);
            this.StartBabyPressure.TabIndex = 76;
            this.StartBabyPressure.Text = "Start";
            this.StartBabyPressure.UseVisualStyleBackColor = false;
            this.StartBabyPressure.Click += new System.EventHandler(this.StartBabyPressure_Click);
            // 
            // StartFiO2
            // 
            this.StartFiO2.BackColor = System.Drawing.Color.LightGray;
            this.StartFiO2.Location = new System.Drawing.Point(1105, 715);
            this.StartFiO2.Margin = new System.Windows.Forms.Padding(2);
            this.StartFiO2.Name = "StartFiO2";
            this.StartFiO2.Size = new System.Drawing.Size(110, 52);
            this.StartFiO2.TabIndex = 77;
            this.StartFiO2.Text = "Start";
            this.StartFiO2.UseVisualStyleBackColor = false;
            this.StartFiO2.Click += new System.EventHandler(this.StartFiO2_Click);
            // 
            // SetBlower
            // 
            this.SetBlower.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.SetBlower.Location = new System.Drawing.Point(350, 548);
            this.SetBlower.Margin = new System.Windows.Forms.Padding(2);
            this.SetBlower.Maximum = new decimal(new int[] {
            511,
            0,
            0,
            0});
            this.SetBlower.Name = "SetBlower";
            this.SetBlower.Size = new System.Drawing.Size(110, 38);
            this.SetBlower.TabIndex = 79;
            this.SetBlower.ValueChanged += new System.EventHandler(this.SetBlower_ValueChanged);
            // 
            // SetPropValve
            // 
            this.SetPropValve.DecimalPlaces = 1;
            this.SetPropValve.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.SetPropValve.Location = new System.Drawing.Point(158, 402);
            this.SetPropValve.Margin = new System.Windows.Forms.Padding(2);
            this.SetPropValve.Name = "SetPropValve";
            this.SetPropValve.Size = new System.Drawing.Size(118, 38);
            this.SetPropValve.TabIndex = 81;
            this.SetPropValve.ValueChanged += new System.EventHandler(this.SetPropValve_ValueChanged);
            // 
            // Calibrate
            // 
            this.Calibrate.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Calibrate.FlatAppearance.BorderSize = 2;
            this.Calibrate.Location = new System.Drawing.Point(1632, 162);
            this.Calibrate.Margin = new System.Windows.Forms.Padding(2);
            this.Calibrate.Name = "Calibrate";
            this.Calibrate.Size = new System.Drawing.Size(288, 105);
            this.Calibrate.TabIndex = 82;
            this.Calibrate.Text = "Calibrate";
            this.Calibrate.UseVisualStyleBackColor = false;
            this.Calibrate.Click += new System.EventHandler(this.Calibrate_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1640, 280);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(263, 80);
            this.label6.TabIndex = 83;
            this.label6.Text = "c_leak:";
            // 
            // cFactor
            // 
            this.cFactor.AutoSize = true;
            this.cFactor.ForeColor = System.Drawing.Color.Maroon;
            this.cFactor.Location = new System.Drawing.Point(1780, 280);
            this.cFactor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cFactor.Name = "cFactor";
            this.cFactor.Size = new System.Drawing.Size(87, 32);
            this.cFactor.TabIndex = 84;
            this.cFactor.Text = "0.000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1628, 362);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(277, 32);
            this.label8.TabIndex = 86;
            this.label8.Text = "Set Heat Plate Temp";
            // 
            // StartHeatPlate
            // 
            this.StartHeatPlate.BackColor = System.Drawing.Color.LightGray;
            this.StartHeatPlate.Location = new System.Drawing.Point(1785, 402);
            this.StartHeatPlate.Margin = new System.Windows.Forms.Padding(2);
            this.StartHeatPlate.Name = "StartHeatPlate";
            this.StartHeatPlate.Size = new System.Drawing.Size(110, 52);
            this.StartHeatPlate.TabIndex = 88;
            this.StartHeatPlate.Text = "Start";
            this.StartHeatPlate.UseVisualStyleBackColor = false;
            this.StartHeatPlate.Click += new System.EventHandler(this.StartHeatPlate_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1628, 475);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(269, 32);
            this.label9.TabIndex = 89;
            this.label9.Text = "Set Heat Wire Temp";
            // 
            // StartHeatWire
            // 
            this.StartHeatWire.BackColor = System.Drawing.Color.LightGray;
            this.StartHeatWire.Location = new System.Drawing.Point(1785, 515);
            this.StartHeatWire.Margin = new System.Windows.Forms.Padding(2);
            this.StartHeatWire.Name = "StartHeatWire";
            this.StartHeatWire.Size = new System.Drawing.Size(110, 52);
            this.StartHeatWire.TabIndex = 91;
            this.StartHeatWire.Text = "Start";
            this.StartHeatWire.UseVisualStyleBackColor = false;
            this.StartHeatWire.Click += new System.EventHandler(this.StartHeatWire_Click);
            // 
            // textBox8
            // 
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.Location = new System.Drawing.Point(958, 192);
            this.textBox8.Margin = new System.Windows.Forms.Padding(2);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(50, 42);
            this.textBox8.TabIndex = 96;
            this.textBox8.Text = "℃";
            // 
            // textBox9
            // 
            this.textBox9.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox9.Location = new System.Drawing.Point(1315, 300);
            this.textBox9.Margin = new System.Windows.Forms.Padding(2);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(98, 31);
            this.textBox9.TabIndex = 97;
            this.textBox9.Text = "cmH₂O";
            // 
            // textBox11
            // 
            this.textBox11.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox11.Location = new System.Drawing.Point(1222, 668);
            this.textBox11.Margin = new System.Windows.Forms.Padding(2);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(98, 31);
            this.textBox11.TabIndex = 99;
            this.textBox11.Text = "%O₂";
            // 
            // textBox12
            // 
            this.textBox12.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox12.Location = new System.Drawing.Point(1742, 405);
            this.textBox12.Margin = new System.Windows.Forms.Padding(2);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(38, 42);
            this.textBox12.TabIndex = 100;
            this.textBox12.Text = "℃";
            // 
            // textBox13
            // 
            this.textBox13.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox13.Location = new System.Drawing.Point(1742, 515);
            this.textBox13.Margin = new System.Windows.Forms.Padding(2);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(38, 42);
            this.textBox13.TabIndex = 101;
            this.textBox13.Text = "℃";
            // 
            // HeatPlateSetting
            // 
            this.HeatPlateSetting.DecimalPlaces = 1;
            this.HeatPlateSetting.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.HeatPlateSetting.Location = new System.Drawing.Point(1618, 405);
            this.HeatPlateSetting.Margin = new System.Windows.Forms.Padding(2);
            this.HeatPlateSetting.Name = "HeatPlateSetting";
            this.HeatPlateSetting.Size = new System.Drawing.Size(120, 38);
            this.HeatPlateSetting.TabIndex = 104;
            this.HeatPlateSetting.ValueChanged += new System.EventHandler(this.HeatPlateSetting_ValueChanged);
            // 
            // HeatWireSetting
            // 
            this.HeatWireSetting.DecimalPlaces = 1;
            this.HeatWireSetting.Location = new System.Drawing.Point(1618, 515);
            this.HeatWireSetting.Margin = new System.Windows.Forms.Padding(2);
            this.HeatWireSetting.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.HeatWireSetting.Name = "HeatWireSetting";
            this.HeatWireSetting.Size = new System.Drawing.Size(120, 38);
            this.HeatWireSetting.TabIndex = 105;
            this.HeatWireSetting.ValueChanged += new System.EventHandler(this.HeatWireSetting_ValueChanged);
            // 
            // textBox17
            // 
            this.textBox17.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox17.Location = new System.Drawing.Point(881, 490);
            this.textBox17.Margin = new System.Windows.Forms.Padding(2);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(50, 42);
            this.textBox17.TabIndex = 107;
            this.textBox17.Text = "℃";
            // 
            // textBox14
            // 
            this.textBox14.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox14.Location = new System.Drawing.Point(1067, 316);
            this.textBox14.Margin = new System.Windows.Forms.Padding(2);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(50, 42);
            this.textBox14.TabIndex = 108;
            this.textBox14.Text = "℃";
            // 
            // textBox16
            // 
            this.textBox16.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox16.Location = new System.Drawing.Point(796, 300);
            this.textBox16.Margin = new System.Windows.Forms.Padding(2);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(50, 42);
            this.textBox16.TabIndex = 109;
            this.textBox16.Text = "℃";
            // 
            // textBox7
            // 
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Location = new System.Drawing.Point(1226, 546);
            this.textBox7.Margin = new System.Windows.Forms.Padding(2);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(98, 31);
            this.textBox7.TabIndex = 110;
            this.textBox7.Text = "cmH₂O";
            // 
            // textBox15
            // 
            this.textBox15.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox15.Location = new System.Drawing.Point(732, 668);
            this.textBox15.Margin = new System.Windows.Forms.Padding(2);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(98, 31);
            this.textBox15.TabIndex = 111;
            this.textBox15.Text = "cmH₂O";
            // 
            // textBox5
            // 
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Location = new System.Drawing.Point(528, 235);
            this.textBox5.Margin = new System.Windows.Forms.Padding(2);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(82, 31);
            this.textBox5.TabIndex = 112;
            this.textBox5.Text = "cmH₂O";
            // 
            // textBox6
            // 
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Location = new System.Drawing.Point(1488, 535);
            this.textBox6.Margin = new System.Windows.Forms.Padding(2);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(98, 31);
            this.textBox6.TabIndex = 113;
            this.textBox6.Text = "cmH₂O";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label10.Location = new System.Drawing.Point(72, 688);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 32);
            this.label10.TabIndex = 114;
            this.label10.Text = "Blue Text";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.Window;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(210, 688);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 32);
            this.label11.TabIndex = 115;
            this.label11.Text = "- Sensor";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Maroon;
            this.label12.Location = new System.Drawing.Point(78, 730);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(129, 32);
            this.label12.TabIndex = 116;
            this.label12.Text = "Red Text";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.Window;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(212, 730);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(179, 32);
            this.label13.TabIndex = 117;
            this.label13.Text = "- Calculated";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.Window;
            this.label14.Font = new System.Drawing.Font("Lucida Console", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Firebrick;
            this.label14.Location = new System.Drawing.Point(1392, 170);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 28);
            this.label14.TabIndex = 118;
            this.label14.Text = "FiO₂";
            // 
            // FiO2
            // 
            this.FiO2.AutoSize = true;
            this.FiO2.ForeColor = System.Drawing.Color.Maroon;
            this.FiO2.Location = new System.Drawing.Point(1420, 202);
            this.FiO2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FiO2.Name = "FiO2";
            this.FiO2.Size = new System.Drawing.Size(55, 32);
            this.FiO2.TabIndex = 119;
            this.FiO2.Text = "0.0";
            this.FiO2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox10
            // 
            this.textBox10.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox10.Location = new System.Drawing.Point(1480, 200);
            this.textBox10.Margin = new System.Windows.Forms.Padding(2);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(40, 31);
            this.textBox10.TabIndex = 120;
            this.textBox10.Text = "%";
            // 
            // StartSimulation
            // 
            this.StartSimulation.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.StartSimulation.FlatAppearance.BorderSize = 2;
            this.StartSimulation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartSimulation.Location = new System.Drawing.Point(1618, 675);
            this.StartSimulation.Margin = new System.Windows.Forms.Padding(2);
            this.StartSimulation.Name = "StartSimulation";
            this.StartSimulation.Size = new System.Drawing.Size(288, 105);
            this.StartSimulation.TabIndex = 121;
            this.StartSimulation.Text = "Simulation";
            this.StartSimulation.UseVisualStyleBackColor = false;
            this.StartSimulation.Click += new System.EventHandler(this.StartSimulation_Click);
            // 
            // o2SensorAvg
            // 
            this.o2SensorAvg.AutoSize = true;
            this.o2SensorAvg.ForeColor = System.Drawing.SystemColors.Highlight;
            this.o2SensorAvg.Location = new System.Drawing.Point(605, 535);
            this.o2SensorAvg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.o2SensorAvg.Name = "o2SensorAvg";
            this.o2SensorAvg.Size = new System.Drawing.Size(55, 32);
            this.o2SensorAvg.TabIndex = 122;
            this.o2SensorAvg.Text = "0.0";
            this.o2SensorAvg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.o2SensorAvg.Click += new System.EventHandler(this.o2SensorAvg_Click);
            // 
            // o2SensorStatusDescription
            // 
            this.o2SensorStatusDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.o2SensorStatusDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.o2SensorStatusDescription.Location = new System.Drawing.Point(675, 578);
            this.o2SensorStatusDescription.Margin = new System.Windows.Forms.Padding(2);
            this.o2SensorStatusDescription.Name = "o2SensorStatusDescription";
            this.o2SensorStatusDescription.Size = new System.Drawing.Size(600, 31);
            this.o2SensorStatusDescription.TabIndex = 126;
            this.o2SensorStatusDescription.Text = "Inactive";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(52, 135);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1548, 490);
            this.pictureBox1.TabIndex = 58;
            this.pictureBox1.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1430, 72);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(218, 32);
            this.label15.TabIndex = 127;
            this.label15.Text = "Battery Voltage:";
            // 
            // batteryVolts
            // 
            this.batteryVolts.AutoSize = true;
            this.batteryVolts.Location = new System.Drawing.Point(1652, 72);
            this.batteryVolts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.batteryVolts.Name = "batteryVolts";
            this.batteryVolts.Size = new System.Drawing.Size(71, 32);
            this.batteryVolts.TabIndex = 128;
            this.batteryVolts.Text = "24.0";
            // 
            // textBox19
            // 
            this.textBox19.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox19.Location = new System.Drawing.Point(865, 162);
            this.textBox19.Margin = new System.Windows.Forms.Padding(2);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(175, 31);
            this.textBox19.TabIndex = 129;
            this.textBox19.Text = "Temp Ambient";
            // 
            // textBox20
            // 
            this.textBox20.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox20.Location = new System.Drawing.Point(685, 535);
            this.textBox20.Margin = new System.Windows.Forms.Padding(2);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(42, 31);
            this.textBox20.TabIndex = 130;
            this.textBox20.Text = "%";
            // 
            // textBox22
            // 
            this.textBox22.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox22.Location = new System.Drawing.Point(354, 279);
            this.textBox22.Margin = new System.Windows.Forms.Padding(2);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(50, 31);
            this.textBox22.TabIndex = 134;
            this.textBox22.Text = "lpm";
            // 
            // textBox23
            // 
            this.textBox23.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox23.Location = new System.Drawing.Point(460, 339);
            this.textBox23.Margin = new System.Windows.Forms.Padding(2);
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(50, 31);
            this.textBox23.TabIndex = 135;
            this.textBox23.Text = "lpm";
            // 
            // textBox24
            // 
            this.textBox24.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox24.Location = new System.Drawing.Point(1535, 290);
            this.textBox24.Margin = new System.Windows.Forms.Padding(2);
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(50, 31);
            this.textBox24.TabIndex = 136;
            this.textBox24.Text = "lpm";
            // 
            // textBox25
            // 
            this.textBox25.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox25.Location = new System.Drawing.Point(1124, 248);
            this.textBox25.Margin = new System.Windows.Forms.Padding(2);
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(50, 31);
            this.textBox25.TabIndex = 137;
            this.textBox25.Text = "lpm";
            // 
            // TempInsp
            // 
            this.TempInsp.AutoSize = true;
            this.TempInsp.ForeColor = System.Drawing.SystemColors.Highlight;
            this.TempInsp.Location = new System.Drawing.Point(579, 422);
            this.TempInsp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TempInsp.Name = "TempInsp";
            this.TempInsp.Size = new System.Drawing.Size(55, 32);
            this.TempInsp.TabIndex = 138;
            this.TempInsp.Text = "0.0";
            this.TempInsp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(632, 414);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(50, 42);
            this.textBox3.TabIndex = 139;
            this.textBox3.Text = "℃";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(2068, 1643);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.TempInsp);
            this.Controls.Add(this.textBox25);
            this.Controls.Add(this.textBox24);
            this.Controls.Add(this.textBox23);
            this.Controls.Add(this.textBox22);
            this.Controls.Add(this.textBox20);
            this.Controls.Add(this.textBox19);
            this.Controls.Add(this.batteryVolts);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.o2SensorStatusDescription);
            this.Controls.Add(this.o2SensorAvg);
            this.Controls.Add(this.StartSimulation);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.FiO2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox15);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox16);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.textBox17);
            this.Controls.Add(this.HeatWireSetting);
            this.Controls.Add(this.HeatPlateSetting);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.StartHeatWire);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.StartHeatPlate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cFactor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Calibrate);
            this.Controls.Add(this.SetPropValve);
            this.Controls.Add(this.SetBlower);
            this.Controls.Add(this.StartFiO2);
            this.Controls.Add(this.StartBabyPressure);
            this.Controls.Add(this.Fio2Setpt);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.PressBabySetpt);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.TempAmb);
            this.Controls.Add(this.FlowOx);
            this.Controls.Add(this.FlowInsp);
            this.Controls.Add(this.PressInsp);
            this.Controls.Add(this.TempPlate);
            this.Controls.Add(this.TempDist);
            this.Controls.Add(this.TempProx);
            this.Controls.Add(this.FlowExp);
            this.Controls.Add(this.PressCkt);
            this.Controls.Add(this.PressExp);
            this.Controls.Add(this.FlowLeak);
            this.Controls.Add(this.BabyPressure);
            this.Controls.Add(this.BlowerSpeed);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.responseBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.firmwareVersionLabel);
            this.Controls.Add(this.commandBox);
            this.Controls.Add(this.connectedTextBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "FlowWorks App ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PressBabySetpt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Fio2Setpt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetBlower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetPropValve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeatPlateSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeatWireSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem setupMenu;
        private System.Windows.Forms.ToolStripMenuItem comportMenu;
        private System.Windows.Forms.TextBox connectedTextBox;
        private System.Windows.Forms.TextBox commandBox;
        public System.Windows.Forms.Label firmwareVersionLabel;
        public System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox responseBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label BlowerSpeed;
        public System.Windows.Forms.Label BabyPressure;
        private System.Windows.Forms.Label FlowLeak;
        private System.Windows.Forms.Label PressExp;
        private System.Windows.Forms.Label PressCkt;
        private System.Windows.Forms.Label FlowExp;
        public System.Windows.Forms.Label TempProx;
        private System.Windows.Forms.Label TempDist;
        private System.Windows.Forms.Label TempPlate;
        private System.Windows.Forms.Label PressInsp;
        private System.Windows.Forms.Label FlowInsp;
        private System.Windows.Forms.Label FlowOx;
        private System.Windows.Forms.Label TempAmb;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.NumericUpDown PressBabySetpt;
        private System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.NumericUpDown Fio2Setpt;
        private System.Windows.Forms.Button StartBabyPressure;
        private System.Windows.Forms.Button StartFiO2;
        private System.Windows.Forms.NumericUpDown SetBlower;
        private System.Windows.Forms.NumericUpDown SetPropValve;
        private System.Windows.Forms.Button Calibrate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label cFactor;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VersionString;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button StartHeatPlate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button StartHeatWire;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.NumericUpDown HeatPlateSetting;
        private System.Windows.Forms.NumericUpDown HeatWireSetting;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem startFirwmareDownloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutFirmwareToolStripMenuItem;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label FiO2;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Button StartSimulation;
        private System.Windows.Forms.ToolStripMenuItem enableLoggingToolStripMenuItem;
        private System.Windows.Forms.Label o2SensorAvg;
        private System.Windows.Forms.TextBox o2SensorStatusDescription;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.Label batteryVolts;
        private System.Windows.Forms.ToolStripMenuItem startFirmwareDownloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpDocToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.TextBox textBox23;
        private System.Windows.Forms.TextBox textBox24;
        private System.Windows.Forms.TextBox textBox25;
        private System.Windows.Forms.Label TempInsp;
        private System.Windows.Forms.TextBox textBox3;
    }
}
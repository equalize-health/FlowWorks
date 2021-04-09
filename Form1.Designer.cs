
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressBabySetpt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Fio2Setpt)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(2044, 60);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // setupMenu
            // 
            this.setupMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comportMenu});
            this.setupMenu.Name = "setupMenu";
            this.setupMenu.Size = new System.Drawing.Size(119, 45);
            this.setupMenu.Text = "Setup";
            this.setupMenu.Click += new System.EventHandler(this.RefreshComList);
            // 
            // comportMenu
            // 
            this.comportMenu.Name = "comportMenu";
            this.comportMenu.Size = new System.Drawing.Size(314, 54);
            this.comportMenu.Text = "COM Port";
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
            this.connectedTextBox.Location = new System.Drawing.Point(203, 70);
            this.connectedTextBox.Name = "connectedTextBox";
            this.connectedTextBox.ReadOnly = true;
            this.connectedTextBox.Size = new System.Drawing.Size(31, 38);
            this.connectedTextBox.TabIndex = 18;
            // 
            // commandBox
            // 
            this.commandBox.AcceptsReturn = true;
            this.commandBox.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commandBox.Location = new System.Drawing.Point(52, 792);
            this.commandBox.Margin = new System.Windows.Forms.Padding(4);
            this.commandBox.Multiline = true;
            this.commandBox.Name = "commandBox";
            this.commandBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.commandBox.Size = new System.Drawing.Size(647, 119);
            this.commandBox.TabIndex = 20;
            this.commandBox.Click += new System.EventHandler(this.commandBox_Click);
            this.commandBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.commandBox_KeyDown);
            // 
            // firmwareVersionLabel
            // 
            this.firmwareVersionLabel.AutoSize = true;
            this.firmwareVersionLabel.Location = new System.Drawing.Point(606, 76);
            this.firmwareVersionLabel.Name = "firmwareVersionLabel";
            this.firmwareVersionLabel.Size = new System.Drawing.Size(93, 32);
            this.firmwareVersionLabel.TabIndex = 30;
            this.firmwareVersionLabel.Text = "v0.0.0";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(1153, 834);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(127, 32);
            this.dateLabel.TabIndex = 49;
            this.dateLabel.Text = "00/00/00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(995, 834);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 32);
            this.label7.TabIndex = 50;
            this.label7.Text = "Date:";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(1153, 866);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(127, 32);
            this.timeLabel.TabIndex = 51;
            this.timeLabel.Text = "00:00:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(995, 866);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 32);
            this.label1.TabIndex = 52;
            this.label1.Text = "Time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 32);
            this.label2.TabIndex = 53;
            this.label2.Text = "Connected:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 756);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 32);
            this.label3.TabIndex = 54;
            this.label3.Text = "Command:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(460, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 32);
            this.label4.TabIndex = 55;
            this.label4.Text = "Firmware:";
            // 
            // responseBox
            // 
            this.responseBox.AcceptsReturn = true;
            this.responseBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.responseBox.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.responseBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.responseBox.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.responseBox.Location = new System.Drawing.Point(52, 995);
            this.responseBox.Margin = new System.Windows.Forms.Padding(4);
            this.responseBox.Multiline = true;
            this.responseBox.Name = "responseBox";
            this.responseBox.ReadOnly = true;
            this.responseBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.responseBox.Size = new System.Drawing.Size(1782, 187);
            this.responseBox.TabIndex = 56;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 959);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(207, 32);
            this.label5.TabIndex = 57;
            this.label5.Text = "Response Box:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(42, 125);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1548, 602);
            this.pictureBox1.TabIndex = 58;
            this.pictureBox1.TabStop = false;
            // 
            // BlowerSpeed
            // 
            this.BlowerSpeed.AutoSize = true;
            this.BlowerSpeed.Location = new System.Drawing.Point(435, 547);
            this.BlowerSpeed.Name = "BlowerSpeed";
            this.BlowerSpeed.Size = new System.Drawing.Size(31, 32);
            this.BlowerSpeed.TabIndex = 59;
            this.BlowerSpeed.Text = "0";
            // 
            // BabyPressure
            // 
            this.BabyPressure.AutoSize = true;
            this.BabyPressure.Location = new System.Drawing.Point(1275, 298);
            this.BabyPressure.Name = "BabyPressure";
            this.BabyPressure.Size = new System.Drawing.Size(71, 32);
            this.BabyPressure.TabIndex = 60;
            this.BabyPressure.Text = "0.00";
            // 
            // FlowLeak
            // 
            this.FlowLeak.AutoSize = true;
            this.FlowLeak.Location = new System.Drawing.Point(1134, 298);
            this.FlowLeak.Name = "FlowLeak";
            this.FlowLeak.Size = new System.Drawing.Size(55, 32);
            this.FlowLeak.TabIndex = 61;
            this.FlowLeak.Text = "0.0";
            // 
            // PressExp
            // 
            this.PressExp.AutoSize = true;
            this.PressExp.Location = new System.Drawing.Point(1450, 237);
            this.PressExp.Name = "PressExp";
            this.PressExp.Size = new System.Drawing.Size(55, 32);
            this.PressExp.TabIndex = 62;
            this.PressExp.Text = "0.0";
            // 
            // PressCkt
            // 
            this.PressCkt.AutoSize = true;
            this.PressCkt.Location = new System.Drawing.Point(1200, 604);
            this.PressCkt.Name = "PressCkt";
            this.PressCkt.Size = new System.Drawing.Size(55, 32);
            this.PressCkt.TabIndex = 63;
            this.PressCkt.Text = "0.0";
            // 
            // FlowExp
            // 
            this.FlowExp.AutoSize = true;
            this.FlowExp.Location = new System.Drawing.Point(1518, 337);
            this.FlowExp.Name = "FlowExp";
            this.FlowExp.Size = new System.Drawing.Size(55, 32);
            this.FlowExp.TabIndex = 64;
            this.FlowExp.Text = "0.0";
            // 
            // TempProx
            // 
            this.TempProx.AutoSize = true;
            this.TempProx.Location = new System.Drawing.Point(1082, 427);
            this.TempProx.Name = "TempProx";
            this.TempProx.Size = new System.Drawing.Size(55, 32);
            this.TempProx.TabIndex = 65;
            this.TempProx.Text = "0.0";
            // 
            // TempDist
            // 
            this.TempDist.AutoSize = true;
            this.TempDist.Location = new System.Drawing.Point(798, 313);
            this.TempDist.Name = "TempDist";
            this.TempDist.Size = new System.Drawing.Size(55, 32);
            this.TempDist.TabIndex = 66;
            this.TempDist.Text = "0.0";
            // 
            // TempPlate
            // 
            this.TempPlate.AutoSize = true;
            this.TempPlate.Location = new System.Drawing.Point(776, 593);
            this.TempPlate.Name = "TempPlate";
            this.TempPlate.Size = new System.Drawing.Size(55, 32);
            this.TempPlate.TabIndex = 67;
            this.TempPlate.Text = "0.0";
            // 
            // PressInsp
            // 
            this.PressInsp.AutoSize = true;
            this.PressInsp.Location = new System.Drawing.Point(576, 249);
            this.PressInsp.Name = "PressInsp";
            this.PressInsp.Size = new System.Drawing.Size(55, 32);
            this.PressInsp.TabIndex = 68;
            this.PressInsp.Text = "0.0";
            // 
            // FlowInsp
            // 
            this.FlowInsp.AutoSize = true;
            this.FlowInsp.Location = new System.Drawing.Point(533, 465);
            this.FlowInsp.Name = "FlowInsp";
            this.FlowInsp.Size = new System.Drawing.Size(55, 32);
            this.FlowInsp.TabIndex = 69;
            this.FlowInsp.Text = "0.0";
            // 
            // FlowOx
            // 
            this.FlowOx.AutoSize = true;
            this.FlowOx.Location = new System.Drawing.Point(295, 408);
            this.FlowOx.Name = "FlowOx";
            this.FlowOx.Size = new System.Drawing.Size(55, 32);
            this.FlowOx.TabIndex = 70;
            this.FlowOx.Text = "0.0";
            // 
            // TempAmb
            // 
            this.TempAmb.AutoSize = true;
            this.TempAmb.Location = new System.Drawing.Point(1026, 237);
            this.TempAmb.Name = "TempAmb";
            this.TempAmb.Size = new System.Drawing.Size(55, 32);
            this.TempAmb.TabIndex = 71;
            this.TempAmb.Text = "0.0";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(379, 652);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(251, 38);
            this.textBox1.TabIndex = 72;
            this.textBox1.Text = "Set Baby Pressure:";
            // 
            // PressBabySetpt
            // 
            this.PressBabySetpt.Location = new System.Drawing.Point(645, 652);
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
            this.PressBabySetpt.Size = new System.Drawing.Size(120, 38);
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
            this.textBox2.Location = new System.Drawing.Point(980, 652);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(144, 38);
            this.textBox2.TabIndex = 74;
            this.textBox2.Text = "Set FiO2:";
            // 
            // Fio2Setpt
            // 
            this.Fio2Setpt.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.Fio2Setpt.Location = new System.Drawing.Point(1140, 652);
            this.Fio2Setpt.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.Fio2Setpt.Name = "Fio2Setpt";
            this.Fio2Setpt.Size = new System.Drawing.Size(120, 38);
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
            this.StartBabyPressure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.StartBabyPressure.Location = new System.Drawing.Point(782, 652);
            this.StartBabyPressure.Name = "StartBabyPressure";
            this.StartBabyPressure.Size = new System.Drawing.Size(110, 51);
            this.StartBabyPressure.TabIndex = 76;
            this.StartBabyPressure.Text = "Start";
            this.StartBabyPressure.UseVisualStyleBackColor = false;
            this.StartBabyPressure.Click += new System.EventHandler(this.StartBabyPressure_Click);
            // 
            // StartFiO2
            // 
            this.StartFiO2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.StartFiO2.Location = new System.Drawing.Point(1281, 650);
            this.StartFiO2.Name = "StartFiO2";
            this.StartFiO2.Size = new System.Drawing.Size(110, 53);
            this.StartFiO2.TabIndex = 77;
            this.StartFiO2.Text = "Start";
            this.StartFiO2.UseVisualStyleBackColor = false;
            this.StartFiO2.Click += new System.EventHandler(this.StartFiO2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2044, 1313);
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
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "FlowWorks App";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressBabySetpt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Fio2Setpt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem setupMenu;
        private System.Windows.Forms.ToolStripMenuItem comportMenu;
        private System.Windows.Forms.TextBox connectedTextBox;
        private System.Windows.Forms.TextBox commandBox;
        private System.Windows.Forms.Label firmwareVersionLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox responseBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label BlowerSpeed;
        private System.Windows.Forms.Label BabyPressure;
        private System.Windows.Forms.Label FlowLeak;
        private System.Windows.Forms.Label PressExp;
        private System.Windows.Forms.Label PressCkt;
        private System.Windows.Forms.Label FlowExp;
        private System.Windows.Forms.Label TempProx;
        private System.Windows.Forms.Label TempDist;
        private System.Windows.Forms.Label TempPlate;
        private System.Windows.Forms.Label PressInsp;
        private System.Windows.Forms.Label FlowInsp;
        private System.Windows.Forms.Label FlowOx;
        private System.Windows.Forms.Label TempAmb;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown PressBabySetpt;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.NumericUpDown Fio2Setpt;
        private System.Windows.Forms.Button StartBabyPressure;
        private System.Windows.Forms.Button StartFiO2;
    }
}

namespace FlowWorks
{
    partial class Simulation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Simulation));
            this.simulationPictureBox = new System.Windows.Forms.PictureBox();
            this.batteryCharge = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxPrevious = new System.Windows.Forms.PictureBox();
            this.pictureBoxCircuitTest = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBoxMute = new System.Windows.Forms.PictureBox();
            this.pictureBoxPower = new System.Windows.Forms.PictureBox();
            this.pictureBoxPause = new System.Windows.Forms.PictureBox();
            this.pictureBoxNext = new System.Windows.Forms.PictureBox();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.O2Setpoint = new System.Windows.Forms.NumericUpDown();
            this.PressSetpt = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.simulationPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPrevious)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCircuitTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.O2Setpoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressSetpt)).BeginInit();
            this.SuspendLayout();
            // 
            // simulationPictureBox
            // 
            this.simulationPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simulationPictureBox.Location = new System.Drawing.Point(0, 0);
            this.simulationPictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simulationPictureBox.Name = "simulationPictureBox";
            this.simulationPictureBox.Size = new System.Drawing.Size(1693, 1282);
            this.simulationPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.simulationPictureBox.TabIndex = 0;
            this.simulationPictureBox.TabStop = false;
            this.simulationPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.simulationPictureBox_Paint);
            // 
            // batteryCharge
            // 
            this.batteryCharge.Location = new System.Drawing.Point(1403, 31);
            this.batteryCharge.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.batteryCharge.Maximum = 24;
            this.batteryCharge.Minimum = 17;
            this.batteryCharge.Name = "batteryCharge";
            this.batteryCharge.Size = new System.Drawing.Size(77, 29);
            this.batteryCharge.TabIndex = 1;
            this.batteryCharge.Value = 18;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBoxPrevious);
            this.panel1.Controls.Add(this.pictureBoxCircuitTest);
            this.panel1.Controls.Add(this.pictureBox6);
            this.panel1.Controls.Add(this.pictureBoxMute);
            this.panel1.Controls.Add(this.pictureBoxPower);
            this.panel1.Controls.Add(this.pictureBoxPause);
            this.panel1.Controls.Add(this.pictureBoxNext);
            this.panel1.Controls.Add(this.pictureBoxMain);
            this.panel1.Location = new System.Drawing.Point(0, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1694, 1053);
            this.panel1.TabIndex = 2;
            // 
            // pictureBoxPrevious
            // 
            this.pictureBoxPrevious.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPrevious.Image")));
            this.pictureBoxPrevious.Location = new System.Drawing.Point(42, 858);
            this.pictureBoxPrevious.Name = "pictureBoxPrevious";
            this.pictureBoxPrevious.Size = new System.Drawing.Size(225, 191);
            this.pictureBoxPrevious.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPrevious.TabIndex = 7;
            this.pictureBoxPrevious.TabStop = false;
            this.pictureBoxPrevious.Click += new System.EventHandler(this.pictureBoxPrevious_Click);
            // 
            // pictureBoxCircuitTest
            // 
            this.pictureBoxCircuitTest.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxCircuitTest.Image")));
            this.pictureBoxCircuitTest.Location = new System.Drawing.Point(316, 862);
            this.pictureBoxCircuitTest.Name = "pictureBoxCircuitTest";
            this.pictureBoxCircuitTest.Size = new System.Drawing.Size(225, 191);
            this.pictureBoxCircuitTest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCircuitTest.TabIndex = 6;
            this.pictureBoxCircuitTest.TabStop = false;
            this.pictureBoxCircuitTest.Click += new System.EventHandler(this.pictureBoxCircuitTest_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(58, 2155);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(225, 191);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 5;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBoxMute
            // 
            this.pictureBoxMute.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxMute.Image")));
            this.pictureBoxMute.Location = new System.Drawing.Point(595, 862);
            this.pictureBoxMute.Name = "pictureBoxMute";
            this.pictureBoxMute.Size = new System.Drawing.Size(225, 191);
            this.pictureBoxMute.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMute.TabIndex = 4;
            this.pictureBoxMute.TabStop = false;
            this.pictureBoxMute.Click += new System.EventHandler(this.pictureBoxMute_Click);
            // 
            // pictureBoxPower
            // 
            this.pictureBoxPower.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPower.Image")));
            this.pictureBoxPower.Location = new System.Drawing.Point(894, 862);
            this.pictureBoxPower.Name = "pictureBoxPower";
            this.pictureBoxPower.Size = new System.Drawing.Size(225, 191);
            this.pictureBoxPower.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPower.TabIndex = 3;
            this.pictureBoxPower.TabStop = false;
            this.pictureBoxPower.Click += new System.EventHandler(this.pictureBoxPower_Click);
            // 
            // pictureBoxPause
            // 
            this.pictureBoxPause.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPause.Image")));
            this.pictureBoxPause.Location = new System.Drawing.Point(1171, 862);
            this.pictureBoxPause.Name = "pictureBoxPause";
            this.pictureBoxPause.Size = new System.Drawing.Size(225, 191);
            this.pictureBoxPause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPause.TabIndex = 2;
            this.pictureBoxPause.TabStop = false;
            this.pictureBoxPause.Click += new System.EventHandler(this.pictureBoxPause_Click);
            // 
            // pictureBoxNext
            // 
            this.pictureBoxNext.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxNext.Image")));
            this.pictureBoxNext.Location = new System.Drawing.Point(1448, 862);
            this.pictureBoxNext.Name = "pictureBoxNext";
            this.pictureBoxNext.Size = new System.Drawing.Size(225, 191);
            this.pictureBoxNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxNext.TabIndex = 1;
            this.pictureBoxNext.TabStop = false;
            this.pictureBoxNext.Click += new System.EventHandler(this.pictureBoxNext_Click);
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxMain.Image")));
            this.pictureBoxMain.Location = new System.Drawing.Point(12, 3);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(1655, 849);
            this.pictureBoxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMain.TabIndex = 0;
            this.pictureBoxMain.TabStop = false;
            this.pictureBoxMain.Paint += new System.Windows.Forms.PaintEventHandler(this.simulationPictureBox_Paint);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(805, 1167);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(250, 91);
            this.textBox1.TabIndex = 2;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "O₂%:";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(150, 1158);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(256, 91);
            this.textBox2.TabIndex = 6;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "Press:";
            // 
            // O2Setpoint
            // 
            this.O2Setpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.O2Setpoint.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.O2Setpoint.Location = new System.Drawing.Point(1092, 1122);
            this.O2Setpoint.Maximum = new decimal(new int[] {
            97,
            0,
            0,
            0});
            this.O2Setpoint.Minimum = new decimal(new int[] {
            21,
            0,
            0,
            0});
            this.O2Setpoint.Name = "O2Setpoint";
            this.O2Setpoint.Size = new System.Drawing.Size(212, 143);
            this.O2Setpoint.TabIndex = 7;
            this.O2Setpoint.Value = new decimal(new int[] {
            21,
            0,
            0,
            0});
            this.O2Setpoint.ValueChanged += new System.EventHandler(this.O2Setpoint_ValueChanged);
            // 
            // PressSetpt
            // 
            this.PressSetpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PressSetpt.Location = new System.Drawing.Point(436, 1122);
            this.PressSetpt.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PressSetpt.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.PressSetpt.Name = "PressSetpt";
            this.PressSetpt.Size = new System.Drawing.Size(212, 143);
            this.PressSetpt.TabIndex = 8;
            this.PressSetpt.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.PressSetpt.ValueChanged += new System.EventHandler(this.PressSetpt_ValueChanged);
            // 
            // Simulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1693, 1282);
            this.Controls.Add(this.PressSetpt);
            this.Controls.Add(this.O2Setpoint);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.batteryCharge);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.simulationPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Simulation";
            this.Text = "Simulation";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Simulation_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.simulationPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPrevious)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCircuitTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.O2Setpoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressSetpt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox simulationPictureBox;
        private System.Windows.Forms.ProgressBar batteryCharge;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxNext;
        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.PictureBox pictureBoxCircuitTest;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBoxMute;
        private System.Windows.Forms.PictureBox pictureBoxPower;
        private System.Windows.Forms.PictureBox pictureBoxPause;
        private System.Windows.Forms.PictureBox pictureBoxPrevious;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.NumericUpDown O2Setpoint;
        private System.Windows.Forms.NumericUpDown PressSetpt;
        //private FlowWorks fwViewer;

    }
}
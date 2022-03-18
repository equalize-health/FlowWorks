
namespace FlowWorks
{
    partial class o2Sensor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(o2Sensor));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.O2SensorOn = new System.Windows.Forms.Button();
            this.O2SensorOff = new System.Windows.Forms.Button();
            this.O2SensorCalibrate = new System.Windows.Forms.Button();
            this.O2SensorCancel = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.measurementMode = new System.Windows.Forms.Button();
            this.measurementModeText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(59, 24);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(661, 105);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "Select desired function of Oxygen Sensor device\r\n";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // O2SensorOn
            // 
            this.O2SensorOn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.O2SensorOn.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.O2SensorOn.Location = new System.Drawing.Point(261, 117);
            this.O2SensorOn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.O2SensorOn.Name = "O2SensorOn";
            this.O2SensorOn.Size = new System.Drawing.Size(267, 62);
            this.O2SensorOn.TabIndex = 5;
            this.O2SensorOn.Text = "Turn On";
            this.O2SensorOn.UseVisualStyleBackColor = false;
            // 
            // O2SensorOff
            // 
            this.O2SensorOff.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.O2SensorOff.DialogResult = System.Windows.Forms.DialogResult.No;
            this.O2SensorOff.Location = new System.Drawing.Point(267, 193);
            this.O2SensorOff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.O2SensorOff.Name = "O2SensorOff";
            this.O2SensorOff.Size = new System.Drawing.Size(267, 62);
            this.O2SensorOff.TabIndex = 6;
            this.O2SensorOff.Text = "Turn Off";
            this.O2SensorOff.UseVisualStyleBackColor = false;
            // 
            // O2SensorCalibrate
            // 
            this.O2SensorCalibrate.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.O2SensorCalibrate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.O2SensorCalibrate.Location = new System.Drawing.Point(267, 279);
            this.O2SensorCalibrate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.O2SensorCalibrate.Name = "O2SensorCalibrate";
            this.O2SensorCalibrate.Size = new System.Drawing.Size(267, 62);
            this.O2SensorCalibrate.TabIndex = 7;
            this.O2SensorCalibrate.Text = "Calibrate";
            this.O2SensorCalibrate.UseVisualStyleBackColor = false;
            // 
            // O2SensorCancel
            // 
            this.O2SensorCancel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.O2SensorCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.O2SensorCancel.Location = new System.Drawing.Point(267, 362);
            this.O2SensorCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.O2SensorCancel.Name = "O2SensorCancel";
            this.O2SensorCancel.Size = new System.Drawing.Size(267, 62);
            this.O2SensorCancel.TabIndex = 8;
            this.O2SensorCancel.Text = "Cancel";
            this.O2SensorCancel.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(72, 440);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(307, 46);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "Commands";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // measurementMode
            // 
            this.measurementMode.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.measurementMode.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.measurementMode.Location = new System.Drawing.Point(82, 490);
            this.measurementMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.measurementMode.Name = "measurementMode";
            this.measurementMode.Size = new System.Drawing.Size(267, 83);
            this.measurementMode.TabIndex = 11;
            this.measurementMode.Text = "Measurement Mode";
            this.measurementMode.UseVisualStyleBackColor = false;
            this.measurementMode.Click += new System.EventHandler(this.measurementMode_Click);
            // 
            // measurementModeText
            // 
            this.measurementModeText.Location = new System.Drawing.Point(386, 502);
            this.measurementModeText.Name = "measurementModeText";
            this.measurementModeText.Size = new System.Drawing.Size(75, 38);
            this.measurementModeText.TabIndex = 12;
            this.measurementModeText.Text = "0";
            // 
            // o2Sensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 751);
            this.Controls.Add(this.measurementModeText);
            this.Controls.Add(this.measurementMode);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.O2SensorCancel);
            this.Controls.Add(this.O2SensorCalibrate);
            this.Controls.Add(this.O2SensorOff);
            this.Controls.Add(this.O2SensorOn);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "o2Sensor";
            this.Text = "o2Sensor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button O2SensorOn;
        private System.Windows.Forms.Button O2SensorOff;
        private System.Windows.Forms.Button O2SensorCalibrate;
        private System.Windows.Forms.Button O2SensorCancel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button measurementMode;
        private System.Windows.Forms.TextBox measurementModeText;
    }
}
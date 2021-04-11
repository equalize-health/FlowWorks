
namespace FlowWorks
{
    partial class Form2
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CalibrateOK = new System.Windows.Forms.Button();
            this.CalibrateCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(71, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(662, 190);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Before continuing, prepare the circuit for calibration\r\n\r\nFor the test setup with" +
    " a plastic bottle, remove the cap\r\nof the bottle before clicking \"OK\" below.";
            // 
            // CalibrateOK
            // 
            this.CalibrateOK.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.CalibrateOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CalibrateOK.Location = new System.Drawing.Point(263, 243);
            this.CalibrateOK.Name = "CalibrateOK";
            this.CalibrateOK.Size = new System.Drawing.Size(268, 63);
            this.CalibrateOK.TabIndex = 2;
            this.CalibrateOK.Text = "OK (to continue)";
            this.CalibrateOK.UseVisualStyleBackColor = false;
            this.CalibrateOK.Click += new System.EventHandler(this.CalibrateOK_Click);
            // 
            // CalibrateCancel
            // 
            this.CalibrateCancel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.CalibrateCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CalibrateCancel.Location = new System.Drawing.Point(263, 324);
            this.CalibrateCancel.Name = "CalibrateCancel";
            this.CalibrateCancel.Size = new System.Drawing.Size(268, 63);
            this.CalibrateCancel.TabIndex = 3;
            this.CalibrateCancel.Text = "Cancel";
            this.CalibrateCancel.UseVisualStyleBackColor = false;
            this.CalibrateCancel.Click += new System.EventHandler(this.CalibrateCancel_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CalibrateCancel);
            this.Controls.Add(this.CalibrateOK);
            this.Controls.Add(this.textBox1);
            this.Name = "Form2";
            this.Text = "Start Calibration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button CalibrateOK;
        private System.Windows.Forms.Button CalibrateCancel;
    }
}
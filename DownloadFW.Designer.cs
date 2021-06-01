
namespace FlowWorks
{
    partial class DownloadFW
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadFW));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.StartDownload = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(53, 17);
            this.textBox1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(186, 77);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Before Proceeding:  connect an Atmel ICE emulator to the connector on the FlowLit" +
    "e product.\r\nDuring Firmware Download, application will be unresponsive\r\n";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StartDownload
            // 
            this.StartDownload.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.StartDownload.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.StartDownload.Location = new System.Drawing.Point(130, 95);
            this.StartDownload.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.StartDownload.Name = "StartDownload";
            this.StartDownload.Size = new System.Drawing.Size(35, 32);
            this.StartDownload.TabIndex = 1;
            this.StartDownload.Text = "OK";
            this.StartDownload.UseVisualStyleBackColor = false;
            this.StartDownload.Click += new System.EventHandler(this.StartDownload_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(123, 136);
            this.button1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // DownloadFW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 189);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.StartDownload);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "DownloadFW";
            this.Text = "Start Firmware Download";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button StartDownload;
        private System.Windows.Forms.Button button1;
    }
}
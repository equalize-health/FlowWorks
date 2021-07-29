
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
            ((System.ComponentModel.ISupportInitialize)(this.simulationPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // simulationPictureBox
            // 
            this.simulationPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simulationPictureBox.Image = global::FlowWorks.Properties.Resources._1_Splash_START_REV02_800x480_COMPRESSED_RGBA_ASTC_8x8_KHR_Converted;
            this.simulationPictureBox.Location = new System.Drawing.Point(0, 0);
            this.simulationPictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simulationPictureBox.Name = "simulationPictureBox";
            this.simulationPictureBox.Size = new System.Drawing.Size(1600, 985);
            this.simulationPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.simulationPictureBox.TabIndex = 0;
            this.simulationPictureBox.TabStop = false;
            this.simulationPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.simulationPictureBox_Paint);
            this.simulationPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.simulationPictureBox_MouseClick);
            // 
            // batteryCharge
            // 
            this.batteryCharge.Location = new System.Drawing.Point(1402, 30);
            this.batteryCharge.Maximum = 25;
            this.batteryCharge.Minimum = 18;
            this.batteryCharge.Name = "batteryCharge";
            this.batteryCharge.Size = new System.Drawing.Size(80, 27);
            this.batteryCharge.TabIndex = 1;
            this.batteryCharge.Value = 18;
            // 
            // Simulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 985);
            this.Controls.Add(this.batteryCharge);
            this.Controls.Add(this.simulationPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Simulation";
            this.Text = "Simulation";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Simulation_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.simulationPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox simulationPictureBox;
        private System.Windows.Forms.ProgressBar batteryCharge;
        //private FlowWorks fwViewer;

    }
}

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
            ((System.ComponentModel.ISupportInitialize)(this.simulationPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // simulationPictureBox
            // 
            this.simulationPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simulationPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("simulationPictureBox.Image")));
            this.simulationPictureBox.Location = new System.Drawing.Point(0, 0);
            this.simulationPictureBox.Name = "simulationPictureBox";
            this.simulationPictureBox.Size = new System.Drawing.Size(1600, 986);
            this.simulationPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.simulationPictureBox.TabIndex = 0;
            this.simulationPictureBox.TabStop = false;
            this.simulationPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.simulationPictureBox_MouseClick);
            // 
            // Simulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 986);
            this.Controls.Add(this.simulationPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Simulation";
            this.Text = "Simulation";
            ((System.ComponentModel.ISupportInitialize)(this.simulationPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox simulationPictureBox;
        //private FlowWorks fwViewer;

    }
}
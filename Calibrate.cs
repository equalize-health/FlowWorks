using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowWorks
{
    public partial class Calibrate : Form
    {
        public bool continueCalibrate;
        public bool cancelCalibrate;
        public Calibrate()
        {
            InitializeComponent();
            continueCalibrate = false;
            cancelCalibrate = false;
        }

        private void CalibrateOK_Click(object sender, EventArgs e)
        {
            this.continueCalibrate = true;
        }

        private void CalibrateCancel_Click(object sender, EventArgs e)
        {
            this.cancelCalibrate = true;
        }
    }
}

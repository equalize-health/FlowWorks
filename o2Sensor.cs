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
    public partial class o2Sensor : Form
    {
        private Form1 mainScreen;

        public o2Sensor()
        {
            InitializeComponent();
        }

        public o2Sensor(Form1 form1)
        {
            this.mainScreen = form1;
        }

        private void measurementMode_Click(object sender, EventArgs e)
        {
            // Send measurement mode update to Oxycell
            byte mode = Byte.Parse(measurementModeText.Text);
            byte[] message = new byte[30];
            int byteCount = 0;
            message[byteCount++] = 0x10;
            message[byteCount++] = 0x2;    //length
            message[byteCount++] = 0x3;    // ID for "Operating Mode" command
            message[byteCount++] = mode;     // Operating mode 
            message[byteCount] = checksum(message, byteCount);    // Checksum

            //this.mainScreen.writer.AddTerminalCommand(message);
        }

        private byte checksum(byte[] byteArray, int Len)
        {
            byte cs = 0;
            for (int i=0; i < Len; i++)
            {
                cs += byteArray[i];
            }
            byteArray[Len-1] = (byte)(~cs + 1);

            return cs;
        }
    }
}

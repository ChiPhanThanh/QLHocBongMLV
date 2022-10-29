using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLHocBongMLV
{
    public partial class ProgressBarInterface : Form
    {
        public ProgressBarInterface()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            progressBar1.Increment(4);
            if(progressBar1.Value == 100)
            {
                timer1.Enabled = false;
                this.Hide();
                Login login = new Login();
                login.ShowDialog();
                
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            progressBar1.ForeColor = Color.Orange;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

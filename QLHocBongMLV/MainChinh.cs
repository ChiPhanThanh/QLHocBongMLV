using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLHocBongMLV
{
    public partial class MainChinh : Form
    {

        private Form currenChildForm;
        public MainChinh()
        {
            InitializeComponent();
        }

        private void MainChinh_Load(object sender, EventArgs e)
        {
          
        }

        private void OpenChildForm(Form childForm)
        {
            if (currenChildForm != null)
            {
                //open only form
                currenChildForm.Close();
            }
            currenChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(childForm);
            this.panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void btnQLSV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QlSinhVien());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

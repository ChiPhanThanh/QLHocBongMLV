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
            childForm.BackColor = BackColor; 
            this.panel1.Controls.Add(childForm);
            this.panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
           
            label1.Text = childForm.Text;

        }

        private void btnQLSV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QlSinhVien());
        }

        private void btnHS_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QLHocSinh());
        }

        private void btnAN_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QLAnNhan());

        }

        private void tbnTS_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QLTuSi());

        }

        private void btnDH_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QLDuHoc());
        }

        private void btnCum_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QLCum());

        }

        private void btnCV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QLChuVu());

        }

        private void btnDiem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đang cập nhật", "Thông bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }

        private void btnQLCuu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QLCuu());
        }

        private void btnTaiChinh_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đang cập nhật", "Thông bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }

       
        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QLTaiKhoan());
        }
        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(" Bạn có muốn đăng xuất không", "Thông báo...", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("http://mlv2011.com/");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/hocbongmlv2011");
        }

        private void bunifuToggleSwitch1_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuToggleSwitch1_CheckedChanged_1(object sender, Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e)
        {
            if (bunifuToggleSwitch1.Value == true)
            {
                this.BackColor = Color.FromArgb(34, 36, 49);
            }
            else
            {
                this.BackColor = Color.White;
            }
        }
    }
}

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
    public partial class panelMain : Form
    {
        private Form currenChildForm;
        public panelMain()
        {
            InitializeComponent();
        }


        //Open childForm trong penalMain
        private void OpenChildForm( Form childForm)
        {
            if(currenChildForm != null)
            {
                //open only form
                currenChildForm.Close();
            }
            currenChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDestop.Controls.Add(childForm);
            panelDestop.Tag = childForm;
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

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QLTaiKhoan());
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

        private void btnTaiChinh_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đang cập nhật", "Thông bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đang cập nhật", "Thông bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }

        private void panel1Menu_Paint(object sender, PaintEventArgs e)
        {

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

     
    }
}

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
    public partial class Login : Form
    {

        //khoi tạo Modifi
        Modify modify = new Modify();
        public Login()
        {
            InitializeComponent();
        }

        private void linkQuenMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            ResetPassWord resetPass = new ResetPassWord();
            resetPass.ShowDialog();
        }

        private void linkDangKi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Sign_in sign_In = new Sign_in();
            sign_In.ShowDialog();
            
        }


        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            //kiem tra nguoi dung 
            string tenTK = txtTenTaikhoan.Text;
            string matkhau = txtPassword.Text;
            if( tenTK.Trim() == "")
            {
                MessageBox.Show(" Vui lòng nhập tài khoản", " Thông báo");
            }

            else if(matkhau.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo"); 
            }
            else
            {
                //truy vấn csdl
                string query = " Select * from tblQuanlitaikhoan where TenTK = '" + tenTK + "' and MatKhau = '" + matkhau + "'";
                if (modify.TaiKhoans(query).Count != 0)
                {
                    // MessageBox.Show(" Đăng nhập thành công", " Thông báo..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    // khoi tạo dối tượng panelMain
                    panelMain main = new panelMain(); 
                    main.ShowDialog();
                    
                }
                else   
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác", " Thông báo..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void bbtnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(" Bạn có muốn thoát không", "Thông báo...", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                button2.BringToFront();
                txtPassword.PasswordChar = '\0';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                button1.BringToFront();
                txtPassword.PasswordChar = '*';
            }
        }
    }
}

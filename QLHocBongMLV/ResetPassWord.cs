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
    public partial class ResetPassWord : Form
    {
        public ResetPassWord()
        {
            InitializeComponent();
            txtKetQua.Text = "";
        }


        //goi Modyfi
        Modify modify = new Modify();

        private void btnReset_Click(object sender, EventArgs e)
        {
            string Email = txtEmail.Text;
            if( Email.Trim() == "")
            {
                MessageBox.Show(" Vui lòng nhập Email đã đăng ký");
            }
            else
            {
                string query = " Select * from tblQuanlitaikhoan  Where Email = '" + Email + "'";
                if(modify.TaiKhoans(query).Count != 0)
                {
                    txtKetQua.ForeColor = Color.Blue; ;
                    txtKetQua.Text = " Mật khẩu là: " + modify.TaiKhoans(query)[0].MatKhau;

                    DialogResult dr = MessageBox.Show(" Bạn có muốn đăng nhập luôn không?", "Thông báo...", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        Login login = new Login();
                        login.ShowDialog();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    txtKetQua.ForeColor = Color.Red;
                    txtKetQua.Text = "Email này chưa được đăng kí";
                }

            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(" Bạn có muốn thoát không", "Thông báo...", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                Login login = new Login();
                login.ShowDialog();
                Application.Exit();
            }
            else
            {
                return;
            }
        }
    }
}

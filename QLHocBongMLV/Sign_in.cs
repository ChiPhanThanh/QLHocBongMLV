using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace QLHocBongMLV
{
    public partial class Sign_in : Form
    {
        public Sign_in()
        {
            InitializeComponent();
        }

        //Check password và name
        public bool CheckAccount(string check)
        {
            return Regex.IsMatch(check, "^[a-zA-Z0-9]{6,20}$");
        }

        //check Email
        public bool CheckEmail(string email)
        {
            return Regex.IsMatch(email, @"^[\w]{3,20}@gmail.com(.vn|)$");
        }

        //gọi Modufy
        Modify modify = new Modify();

        private void btnDangKi_Click(object sender, EventArgs e)
        {

            //Gán biến 
            string tenTK = txtNhapUser.Text;
            string matKhau = txtPassword.Text;
            string xacnhanMatKhau = txtPasswordAgain.Text;
            string Email = txtEmail.Text; 

            //Kiểm tra CheckAccount
            if (!CheckAccount(tenTK))
            {
                MessageBox.Show(" Vui lòng nhập tên tài khoản dài 6 - 20 kí tự \n Gồm các ký tự chữ và số \n Chữ hoa và chữ thường"); 
                return;
            }
            //check password
            if (!CheckAccount(matKhau))
            {
                MessageBox.Show(" Vui lòng nhập mật khẩu dài 3 - 20 kí tự \n Gồm các ký tự chữ và số \n Chữ hoa và chữ thường");
                return;
            }
            //check-xac nhan mật khẩu
            if( xacnhanMatKhau != matKhau)
            {
                MessageBox.Show(" Vui lòng xác nhận mật khẩu chính xác"); 
                return;
            }

            //check email
            if (!CheckEmail(Email))
            {
                MessageBox.Show(" Vui lòng nhập đúng định dạng Email");
                return;
            }

            //Confirm 1 Email for all - chỉ cho đăng kí một Email một lần duy nhất
            if( modify.TaiKhoans(" Select * from tblQuanlitaikhoan where Email = '" + Email + "'" ).Count != 0)
            {
                MessageBox.Show(" Email này đã được đăng kí, vui lòng đăng kí Email khác");
                return;
            }

            //inset vào bảng
            try
            {
                string query = "Insert into tblQuanlitaikhoan values ('" + tenTK + "','"+matKhau+"', '"+Email+"')";
                modify.Command(query);
                if (MessageBox.Show("Đăng kí thành công", " Thông báo..", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Tên tài khoản này đã được đăng kí!\n Vui lòng đăng kí tên tài khoản khác ");

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
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

     
    }
}

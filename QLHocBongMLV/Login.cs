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
        public Login()
        {
            InitializeComponent();
        }

        private void linkQuenMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Sign_in sign_in = new Sign_in();
            sign_in.ShowDialog();
        }

        private void linkDangKi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetPassWord resetPass = new ResetPassWord();
            resetPass.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelMain pMAin = new panelMain();
            pMAin.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

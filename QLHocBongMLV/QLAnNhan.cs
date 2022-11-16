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
    //khai báo biến lưu bản sao của QLAnNhan
    public partial class QLAnNhan : Form
    {
        //khai báo biến để truy cấn cơ sở dữ liêu
        private DataServices myDataServices;

        //Khai báo biến lưu bản sao của QLAnNhan trong csdl
        private DataTable dtAnNhan;

        //khai báo biến để kiểm tra đã chon <thêm> hay <sửa>
        private bool modeNew;

        //khi báo biến lưu lại Phone
        private string _PhoneAN;
        public QLAnNhan()
        {
            InitializeComponent();
        }
        private void QLAnNhan_Load(object sender, EventArgs e)
        {
            myDataServices = new DataServices();
            Display();
            SetControl(false);
        }

        private void Display()
        {
            string sSql = " select * from tblAnNhan Order By MaAN";
            dtAnNhan = myDataServices.RunQuery(sSql);
            //hiện thị dữ liệu lên lưới
            dataGridViewAN.DataSource = dtAnNhan;
        }

        //hàm hiện thị trạng thái Enable của các điều khiển
        private void SetControl(bool edit)
        {
            txtMaAN.Enabled = edit;
            txtHoTenAN.Enabled = edit;
            txtNamSinhAN.Enabled = edit;
            txtNgheNghiepAN.Enabled = edit;
            txtGioiTinhAN.Enabled = edit;
            txtQueQuanAN.Enabled = edit;
            txtSDT_AN.Enabled = edit;
            labelGhiChuAN.Enabled = edit;


            btnThemAN.Enabled = !edit;
            btnSuaAN.Enabled = !edit;
            btnXoaAN.Enabled = !edit;

            btnGhiAN.Enabled = edit;
            btnHuyAN.Enabled = edit;
        }

        private void btnThemAN_Click(object sender, EventArgs e)
        {

            modeNew = true;
            SetControl(true);
            //xóa các texBox
            txtMaAN.Clear();
            txtHoTenAN.Clear();
            txtNamSinhAN.Clear();
            txtNgheNghiepAN.Clear();
            txtGioiTinhAN.Clear();
            txtQueQuanAN.Clear();
            txtSDT_AN.Clear();
            txtGhiChuAN.Clear();

            txtHoTenAN.Focus();
        }

        private void dataGridViewAN_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtMaAN.Text = dataGridViewAN.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtHoTenAN.Text = dataGridViewAN.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtNamSinhAN.Text = dataGridViewAN.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtNgheNghiepAN.Text = dataGridViewAN.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtGioiTinhAN.Text = dataGridViewAN.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtQueQuanAN.Text = dataGridViewAN.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtSDT_AN.Text = dataGridViewAN.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtGhiChuAN.Text = dataGridViewAN.Rows[e.RowIndex].Cells[7].Value.ToString();
            //Lưu lại biến Phone để tránh trùng
            _PhoneAN = txtSDT_AN.Text;
        }

        private void btnSuaAN_Click(object sender, EventArgs e)
        {
            modeNew = false;
            SetControl(true);
            //chuyển con trỏ về txtHoTen
            txtHoTenAN.Focus();
        }

        private void btnXoaAN_Click(object sender, EventArgs e)
        {
            //Hiện thị hộp chắc chắn xóa không
            DialogResult dr;
            dr = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", " Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.No) return;

            //Lấy dòng dữ liệu hiện thời trên lứoi
            int r = dataGridViewAN.CurrentRow.Index;

            //Xóa dòng tương ứng trong dtAnNhan
            dtAnNhan.Rows[r].Delete();

            //Cập nhật lại dữ liệu
            myDataServices.Update(dtAnNhan);
        }

        private void btnGhiAN_Click(object sender, EventArgs e)
        {
            
            //Tạo mã tự dộng MaAN
            int count = 0;
            count = dataGridViewAN.Rows.Count;
            //đến tất các các dòng có trong datagridviewAN
            string maAn1 = "";
            int maAN2 = 0;
            maAn1 = Convert.ToString(dataGridViewAN.Rows[count - 2].Cells[0].Value);
            maAN2 = Convert.ToInt32((maAn1.Remove(0,3)));
            //ở đây là loại bỏ kí tự AN001 thì loại bỏ remove(0,3)
            if (maAN2 + 1 < 10)
                txtMaAN.Text = "AN00" + (maAN2 + 1).ToString();
            else if (maAN2 + 1 < 100)
                txtMaAN.Text = "AN" + (maAN2 + 1).ToString();   
            

            if (txtHoTenAN.Text.Trim() == " ")
            {
                MessageBox.Show("Đề nghị nhập tên Ân Nhân", " Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoTenAN.Focus();
                return;
            }
            if (txtSDT_AN.Text.Trim() == " ")
            {
                MessageBox.Show("Đề nghị nhập số điện thoại", " THông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT_AN.Focus();
            }

            string sSql;
            //Kiểm tra dữ liệu trùng khi thêm hoặc xóa 
            if ((modeNew == true) || ((modeNew == false) && (txtSDT_AN.Text != _PhoneAN)))
            {
                //truy vấn dữ liệu và kiểm tra trùng
                sSql = " Select SoDienThoai from tblAnNhan Where SoDienThoai = N'" + txtSDT_AN.Text + "'";
                //Tạo 1 DataServices khác
                DataServices myDataServices1 = new DataServices();
                DataTable dtSearch = myDataServices1.RunQuery(sSql);
                if (dtSearch.Rows.Count > 0)
                {
                    MessageBox.Show("Đã trùng số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSDT_AN.Focus();
                    return;
                }
            }

            if (modeNew == true)
            {
                //1. Tạo một dòng dữ liệu
                DataRow myDataRow = dtAnNhan.NewRow();
                //2.Gán dữ liệu  
                myDataRow["MaAn"] = txtMaAN.Text;
                myDataRow["HoTen"] = txtHoTenAN.Text;
                myDataRow["NamSinh"] = txtNamSinhAN.Text;
                myDataRow["NgheNghiep"] = txtNgheNghiepAN.Text;
                myDataRow["GioiTinh"] = txtGioiTinhAN.Text;
                myDataRow["QueQuan"] = txtQueQuanAN.Text;
                myDataRow["SoDienThoai"] = txtSDT_AN.Text;
                myDataRow["GhiChu"] = txtGhiChuAN.Text;

                //3.Thêm dòng vào Customer
                dtAnNhan.Rows.Add(myDataRow);
                //4. Cập nhật lại csdl
                myDataServices.Update(dtAnNhan);

            }
            else
            {
                //Sửa dữ liệu
                //1. lấy dòng hiện thời cần sửa
                int r = dataGridViewAN.CurrentRow.Index;
                //2. Khởi tạo 1 dognf dữ iệu
                DataRow myDataRow = dtAnNhan.Rows[r];
                //3.Gán dữ liệu
                myDataRow["MaAN"] = txtMaAN.Text;
                myDataRow["HoTen"] = txtHoTenAN.Text;
                myDataRow["NamSinh"] = txtNamSinhAN.Text;
                myDataRow["NgheNghiep"] = txtNgheNghiepAN.Text;
                myDataRow["GioiTinh"] = txtQueQuanAN.Text;
                myDataRow["QueQuan"] = txtGioiTinhAN.Text;
                myDataRow["SoDienThoai"] = txtSDT_AN.Text;
                myDataRow["GhiChu"] = txtGhiChuAN.Text;

                //4. cập nhật lại dữ liệu
                myDataServices.Update(dtAnNhan);

            }
            Display();
            SetControl(false);
        }

        private void btnTimkiemAN_Click(object sender, EventArgs e)
        {
            //truy vấn dữu liệu
            string sSql = " select * from tblAnNhan where MaAN like % " + txtTImKiemAN + "%";
            if( rbTenAN.Checked == true)
            {
                sSql = " select * from tblAnNhan where HoTen like N'" + txtTImKiemAN + "%'";
            }

            DataServices myDataServices3 = new DataServices();
            DataTable TimkiemAN = myDataServices3.RunQuery(sSql);
            dataGridViewAN.DataSource = TimkiemAN;
        }

        private void btnHuyAN_Click(object sender, EventArgs e)
        {
            SetControl(false);
        }
    }
}

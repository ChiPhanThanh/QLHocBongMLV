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
    public partial class QLDuHoc : Form
    {

        //khai báo biến để truy vấn và cập nhật dữ liêu
        private DataServices myDataServices;

        //khai báo biến lưu bản sao của QLDuHoc trong csdl
        private DataTable dtDuHoc;

        //khai báo biến để kiểm tra đã chojnjnut <thêm> hay <sửa>
        private bool modeNew;

        //Khai báo biến lưu lại Phone

        private string _Phone;

        public QLDuHoc()
        {
            InitializeComponent();
        }

        //Tạo mã tăng tự động

        private void QLDuHoc_Load(object sender, EventArgs e)
        {
            myDataServices = new DataServices();
            //truy vấn dữ liệu lên lưới
            Display();

            //setcontrol- Điều khiển trạng thái các nút
            SetControl(false);


            // mã tăng tự dộng
      
        }       

        //hàm hiên thị
        private void Display()
        {
            //truy vấn dữ liệu
            string sSql = " select * from tblDuHoc Order By MaDH";
            dtDuHoc = myDataServices.RunQuery(sSql);
            //Hiện thị dữ liệu lên lứoi
            dataGridViewDH.DataSource = dtDuHoc;
        }

        //Hàm điều khiển trạng thái Enable của các điều khiển
        private void SetControl(bool edit)
        {
            txtHoTenDH.Enabled = edit;
            txtNamSinhDH.Enabled = edit;
            txtNoiDH.Enabled = edit;
            txtQueQuanDH.Enabled = edit;
            txtGioiTinhDH.Enabled = edit;
            txtSDT.Enabled = edit;
            txtGhiChuDH.Enabled = edit;
           

            btnThemDH.Enabled = !edit;
            btnSuaDH.Enabled = !edit;
            btnXoaDH.Enabled = !edit;

            btnGhiDH.Enabled = edit;
           // btnCancel.Enabled = edit;
        }

      
        private void btnThemDH_Click(object sender, EventArgs e)
        {
            modeNew = true;
            SetControl(true);
            //xáo trắng các textbox
            txtMaDH.Clear();
            txtHoTenDH.Clear();
            txtNamSinhDH.Clear();
            txtNoiDH.Clear();
            txtQueQuanDH.Clear();
            txtGioiTinhDH.Clear();
            txtSDT.Clear();
            txtGhiChuDH.Clear();

            //chuyển con trỏ về txthoten để nhâp
            txtHoTenDH.Focus();
        }

        private void dataGridViewDH_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDH.Text = dataGridViewDH.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtHoTenDH.Text = dataGridViewDH.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtNamSinhDH.Text = dataGridViewDH.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtNoiDH.Text = dataGridViewDH.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtQueQuanDH.Text = dataGridViewDH.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtGioiTinhDH.Text = dataGridViewDH.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtSDT.Text = dataGridViewDH.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtGhiChuDH.Text = dataGridViewDH.Rows[e.RowIndex].Cells[7].Value.ToString();
            //Lưu lại biến Phone để tránh trùng
            _Phone = txtSDT.Text;
        }
        private void btnSuaDH_Click(object sender, EventArgs e)
        {
            modeNew = false;
            SetControl(true);
            //Chuyển con trỏ về txtHoTen
            txtHoTenDH.Focus();
        }
        private void btnXoaDH_Click(object sender, EventArgs e)
        {
            //Hiện thị hộp chắc chắn xóa không
            DialogResult dr;
            dr = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", " Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.No) return;

            //Lấy dòng dữ liệu hiện thời trên lứoi
            int r = dataGridViewDH.CurrentRow.Index;

            //Xóa dòng tương ứng trong dtDuHoc
            dtDuHoc.Rows[r].Delete();

            //Cập nhật lại dữ liệu
            myDataServices.Update(dtDuHoc);
        }

        private void btnGhiDH_Click(object sender, EventArgs e)
        {
            //Tạo mã tự dộng Du Học
            int count = 0;
            count = dataGridViewDH.Rows.Count;
            //đến tất các các dòng có trong datagridviewAN
            string maDH1 = "";
            int maDH2 = 0;
            maDH1 = Convert.ToString(dataGridViewDH.Rows[count - 2].Cells[0].Value);
            maDH2 = Convert.ToInt32((maDH1.Remove(0, 3)));

            //ở đây là loại bỏ kí tự DH001 thì loại bỏ remove(0,3)
            if (maDH2 + 1 < 10)
                txtMaDH.Text = "DH00" + (maDH2 + 1).ToString();
            else if (maDH2 + 1 < 100)
                txtMaDH.Text = "DH" + (maDH2 + 1).ToString();

            if ( txtHoTenDH.Text.Trim() == " ")
            {
                MessageBox.Show("Đề nghị nhập tên du học", " Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoTenDH.Focus();
                return;
            }
            if (txtSDT.Text.Trim() == " "){
                MessageBox.Show("Đề nghị nhập số điện thoại", " THông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Focus();
            }

            string sSql;
            //Kiểm tra dữ liệu trùng khi thêm hoặc xóa 
            if ((modeNew == true) || ((modeNew == false) && (txtSDT.Text != _Phone)))
            {
                //truy vấn dữ liệu và kiểm tra trùng
                sSql = " Select SoDienThoai from tblDuHoc Where SoDienThoai = N'" + txtSDT.Text + "'";
                //Tạo 1 DataServices khác
                DataServices myDataServices1 = new DataServices();
                DataTable dtSearch = myDataServices1.RunQuery(sSql);
                if( dtSearch.Rows.Count > 0)
                {
                    MessageBox.Show("Đã trùng số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSDT.Focus();
                    return;
                }
            }    

            if( modeNew == true)
            {
                //1. Tạo một dòng dữ liệu
                DataRow myDataRow = dtDuHoc.NewRow();
                //2.Gán dữ liệu  
                myDataRow["MaDH"] = txtMaDH.Text;
                myDataRow["HoTen"] = txtHoTenDH.Text;
                myDataRow["NamSinh"] = txtNamSinhDH.Text;
                myDataRow["NoiDuHoc"] = txtNoiDH.Text;
                myDataRow["QueQuan"] = txtQueQuanDH.Text;
                myDataRow["GioiTinh"] = txtGioiTinhDH.Text;
                myDataRow["SoDienThoai"] = txtSDT.Text;
                myDataRow["GhiChu"] = txtGhiChuDH.Text;

                //3.Thêm dòng vào Customer
                dtDuHoc.Rows.Add(myDataRow);
                //4. Cập nhật lại csdl
                myDataServices.Update(dtDuHoc);

            }
            else
            {
                //Sửa dữ liệu
                //1. lấy dòng hiện thời cần sửa
                int r = dataGridViewDH.CurrentRow.Index;
                //2. Khởi tạo 1 dognf dữ iệu
                DataRow myDataRow = dtDuHoc.Rows[r];
                //3.Gán dữ liệu
                myDataRow["MaDH"] = txtMaDH.Text;
                myDataRow["HoTen"] = txtHoTenDH.Text;
                myDataRow["NamSinh"] = txtNamSinhDH.Text;
                myDataRow["NoiDuHoc"] = txtNoiDH.Text;
                myDataRow["QueQuan"] = txtQueQuanDH.Text;
                myDataRow["GioiTinh"] = txtGioiTinhDH.Text;
                myDataRow["SoDienThoai"] = txtSDT.Text;
                myDataRow["GhiChu"] = txtGhiChuDH.Text;

                //4. cập nhật lại dữ liệu
                myDataServices.Update(dtDuHoc);

            }
            Display();
            SetControl(false);
        }

        private void btnThoatDH_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTimkiemDH_Click(object sender, EventArgs e)
        {
            // truy vấn dữ liệu
            string sSql = " select * from tblDuHoc Where MaDH Like %" + txtTImKiemDH.Text + "%";
            if (rbHoTenDH.Checked == true)
            {
                sSql = " select * from tblDuHoc Where HoTen Like N'" + txtTImKiemDH.Text + "%'";
            }
            DataServices myDataServices2 = new DataServices();
            DataTable TimkiemDH = myDataServices2.RunQuery(sSql);
            dataGridViewDH.DataSource = TimkiemDH;
        }

        private void btnHuyDH_Click(object sender, EventArgs e)
        {
            SetControl(false);
        }
    }
}

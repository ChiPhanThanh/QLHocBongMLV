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
    public partial class QLTuSi : Form
    {
        //khai báo biến để truy cấn cơ sở dữ liêu
        private DataServices myDataServices;

        //Khai báo biến lưu bản sao của QLAnNhan trong csdl
        private DataTable dtAnNhan;

        //khai báo biến để kiểm tra đã chon <thêm> hay <sửa>
        private bool modeNew;

        //khi báo biến lưu lại Phone
        private string _PhoneTS;

        public QLTuSi()
        {
            InitializeComponent();
        }

        private void QLTuSi_Load(object sender, EventArgs e)
        {
            myDataServices = new DataServices();
            Display();
            SetControl(false);
        }

        private void Display()
        {
            string sSql = " select * from tblTuSi Order By MaTS";
            dtAnNhan = myDataServices.RunQuery(sSql);
            //hiện thị dữ liệu lên lưới
            dataGridViewTS.DataSource = dtAnNhan;
        }

        private void SetControl(bool edit)
        {
            txtMaTS.Enabled = edit;
            txtHoTenTS.Enabled = edit;
            txtNamSinhTS.Enabled = edit;
            txtGiaoXuTS.Enabled = edit;
            textNoiTuHoc.Enabled = edit;
            txtQueQuanTS.Enabled = edit;
            txtGhichuTS.Enabled = edit;


            btnThemTS.Enabled = !edit;
            btnSuaTS.Enabled = !edit;
            btnXoaTS.Enabled = !edit;

            btnGhiTS.Enabled = edit;
            btnHuyTS.Enabled = edit;
        }

        private void btnThemTS_Click(object sender, EventArgs e)
        {
            modeNew = true;
            SetControl(true);
            //xóa các texBox
            txtMaTS.Clear();
            txtHoTenTS.Clear();
            txtNamSinhTS.Clear();
            txtGiaoXuTS.Clear();
            textNoiTuHoc.Clear();
            txtQueQuanTS.Clear();
            txtGhichuTS.Clear();
         
        }

        private void dataGridViewTS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

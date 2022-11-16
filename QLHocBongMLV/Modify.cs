using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace QLHocBongMLV
{
    class Modify
    {
        public Modify()
        {

        }
        SqlCommand sqlCommand; //khoi tạo SQL Commant // dùng để truy vấn csdl
        SqlDataReader dataReader; // dùng để đọc dữ liệu trong bảng

        //Khoi tao List Taihoan
        public List<TaiKhoan> TaiKhoans(string query)
        {
            List<TaiKhoan> taiKhoans = new List<TaiKhoan>(); //check tài khoản
            //hoi tao doi tuong SQL Connection
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    taiKhoans.Add(new TaiKhoan(dataReader.GetString(0), dataReader.GetString(1)));
                }
                sqlConnection.Close();
            }
                return taiKhoans;
        }


        //dung để đăng kí tài khoản
        public void Command(string query)
        {
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery();// thực thi câu truy vấn
                sqlConnection.Close();
            }
        }
    }
}

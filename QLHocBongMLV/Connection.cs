using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLHocBongMLV
{
    class Connection
    {
        private static string conStr = "Data Source=ITPhan;Initial Catalog = HOCBONG_MLV; Integrated Security = True";

        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(conStr);
        }


    }
}

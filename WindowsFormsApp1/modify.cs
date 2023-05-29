using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class modify
    {
        SqlDataAdapter dataAdapter;// sẽ truy xuất toàn bộ dữ liệu vào bảng
        public modify()
        {
        }
        public DataTable getALLSinhVien()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from SinhVien";
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);

                sqlConnection.Close();


            }
                return dataTable;
        }
    }
}

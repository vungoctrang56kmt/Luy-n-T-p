using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLiTT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=HGIA;Initial Catalog=QuanLyThongTin;Integrated Security=True");
        private void OpenCon()
        {
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        private void CloseCon()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        private Boolean Exe(string cmd)
        {
            OpenCon();
            Boolean check;
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                sc.ExecuteNonQuery();
                check = true;
            }
            catch (Exception ex)
            {
                check = false;
                throw;
            }
            CloseCon();
            return check;
        }
        private DataTable Red(String cmd)
        {
            OpenCon();
            DataTable ret = new DataTable();
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con)
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

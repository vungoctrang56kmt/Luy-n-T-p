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

namespace ThemXoaSua
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string chuoiketnoi = @"Data Source=HGIA;Initial Catalog=SinhVienTNUT;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
        DataTable dt;
      

        private void textgioitinh_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadSinhVienTnut();
        }
        private void loadSinhVienTnut()
        {
            ketnoi = new SqlConnection(chuoiketnoi);

            ketnoi.Open();
            sql = "select* from SinhVienTnut ";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();
        }
        public void hienthi()
        {
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            dt = new DataTable();
            dt.Load(docdulieu);
        }
        public void xoa()
        {
            txtmasv.Clear();
            txttensv.Clear();
            txtdiachi.Clear();
            txtdienthoai.Clear();
            txtgioitinh.Clear();
            txtnamsinh.Clear();
        }
        string masv;

        private void btnxoasv_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string lenhxoa = "delete from SinhVienTnut where MaSV ='" + masv + "'";

            thuchien = new SqlCommand(lenhxoa, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();

            loadSinhVienTnut();
        }

        private void btnsuasv_Click(object sender, EventArgs e)
        {
            // Lấy tất cả thông tin muốn thêm
            string MaSV = txtmasv.Text;
            string HoTen = txttensv.Text;
            string NamSinh = txtnamsinh.Text;
            string GioiTinh = txtgioitinh.Text;
            string DiaChi = txtdienthoai.Text;
            string DienThoai = txtdiachi.Text;

            // check gia tri nguời dùng nhập có đúng không - ví dụ là nhập chưa đủ thông tin:

            ketnoi.Open();




            sql = @"update SinhVienTnut
	     SET
            masosv =N'" + MaSV + "' ,hoten=  N'" + HoTen + "' ,namsinh= N'" + NamSinh + "'  ,gioitinh= N'" + GioiTinh + "'  ,dienthoai=N'" + DiaChi + "' , diachi= N'" + DienThoai + "' where MaSV='" + masv + "'";
            MessageBox.Show(sql);

            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();

            loadSinhVienTnut();

        }

        private void btnthemsv_Click(object sender, EventArgs e)
        {
            // Lấy tất cả thông tin muốn thêm
            string MaSV = txtmasv.Text;
            string HoTen = txttensv.Text;
            string NamSinh = txtnamsinh.Text;
            string GioiTinh = txtgioitinh.Text;
            string DiaChi = txtdienthoai.Text;
            string DienThoai = txtdiachi.Text;


            // check gia tri nguời dùng nhập có đúng không - ví dụ là nhập chưa đủ thông tin:

            ketnoi.Open();

            sql = @"insert into SinhVieTnut
	        values 
            (N'" + MaSV + "' , N'" + HoTen + "' , N'" + NamSinh + "'  , N'" + GioiTinh + "'  , N'" + DiaChi + "' , N'" + DienThoai + "')";
            MessageBox.Show("THÊM THÀNH CÔNG!!");

            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();

            loadSinhVienTnut();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            masv = row.Cells[0].Value.ToString();
        }
    }
}

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
namespace C_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string chuoiketnoi = @"Data Source=HGIA;Initial Catalog = SinhVien; Integrated Security = True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
        DataTable dt;
        private void Form1_Load(object sender, EventArgs e)
        {
            loadKhoa();
            loadSV();
            loadPhong();
        }

        private void loadKhoa()
        {
            ketnoi = new SqlConnection(chuoiketnoi);

            ketnoi.Open();
            sql = "select* from Khoa  ";
            hienthi();
            dataGridView2.DataSource = dt;
            ketnoi.Close();
        }

        private void loadSV()
        {
            ketnoi = new SqlConnection(chuoiketnoi);

            ketnoi.Open();
            sql = "select* from SV ";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();
        }
        private void loadPhong()
        {
            ketnoi = new SqlConnection(chuoiketnoi);

            ketnoi.Open();
            sql = "select* from Phong  ";
            hienthi();
            dataGridView3.DataSource = dt;
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
            txtten.Clear();
            txtnamsinh.Clear();
            txtgioitinh.Clear();
            txtdiachi.Clear();
            txtdienthoai.Clear();
        }
        String MaSinhVien;
        string MaKhoa;

        private void xoasv_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string lenhxoa = "delete from SinhVien where MaSinhVien ='" + MaSinhVien + "'";

            thuchien = new SqlCommand(lenhxoa, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();

            loadSV();

        }

        private void suasv_Click(object sender, EventArgs e)
        {
            // Lấy tất cả thông tin muốn thêm
            string MaSinhVien = txtmasv.Text;
            string HoTen = txtten.Text;
            string NamSinh = txtnamsinh.Text;
            string GioiTinh = txtgioitinh.Text;
            string DienThoai = txtdienthoai.Text;
            string DiaChi = txtdiachi.Text;

            // check gia tri nguời dùng nhập có đúng không - ví dụ là nhập chưa đủ thông tin:

            ketnoi.Open();




            sql = @"update SinhVien
	     SET
            MaSinhVien =N'" + MaSinhVien + "' ,HoTen=  N'" + HoTen + "' ,NamSinh= N'" + NamSinh + "'  ,GioiTinh= N'" + GioiTinh + "'  ,DienThoai=N'" + DienThoai + "' , DiaChi= N'" + DiaChi + "' where MSSV='" + MaSinhVien + "'";
            MessageBox.Show(sql);

            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();

            loadSV();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void themsv_Click(object sender, EventArgs e)
        {

            // Lấy tất cả thông tin muốn thêm
            string MaSinhVien = txtmasv.Text;
            string HoTen = txtten.Text;
            string NamSinh = txtnamsinh.Text;
            string GioiTinh = txtgioitinh.Text;
            string DiaChi = txtdiachi.Text;
            string DienThoai = txtdienthoai.Text;

            // check gia tri nguời dùng nhập có đúng không - ví dụ là nhập chưa đủ thông tin:

            ketnoi.Open();

            sql = @"insert into SinhVien
	        values 
            (N'" + MaSinhVien + "' , N'" + HoTen + "' , N'" + NamSinh + "'  , N'" + GioiTinh + "'  , N'" + DiaChi + "' , N'" + DienThoai + "')";
            MessageBox.Show("THÊM THÀNH CÔNG!!");

            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();

            loadSV();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            MaSinhVien = row.Cells[0].Value.ToString();
        }


        private void themk_Click(object sender, EventArgs e)
        {
            string MaKhoa = txtmakhoa.Text;
            string TenKhoa = txttenkhoa.Text;
            string TenLop = txttenlop.Text;


            ketnoi.Open();

            sql = @"insert into Khoa
            values 
               (N'" + MaKhoa + "' , N'" + TenKhoa + "' , N'" + TenLop +"')";
            MessageBox.Show("THÊM THÀNH CÔNG!!");

            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();
        }

        private void suak_Click(object sender, EventArgs e)
        {
            string Makhoa = txtmakhoa.Text;
            string TenLop = txttenlop.Text;
            string TenKhoa = txttenkhoa.Text;
            // check gia tri nguời dùng nhập có đúng không - ví dụ là nhập chưa đủ thông tin:

            ketnoi.Open();




            sql = @"update SinhVien
	     SET
            Makhoa =N'" + Makhoa + "')";
            MessageBox.Show(sql);
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();

            loadKhoa();

        }

        private void xoaak_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string lenhxoakhoa = "delete from Khoa where MaKhoa ='" + MaKhoa + "'";

            thuchien = new SqlCommand(lenhxoakhoa, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();

            loadKhoa();
        }


        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            DataGridViewRow row = dataGridView3.Rows[e.RowIndex];
            MaSinhVien = row.Cells[0].Value.ToString();
        }

        private void themp_Click(object sender, EventArgs e)
        {
            string DiaChi = txtdiachi.Text;


            // check gia tri nguời dùng nhập có đúng không - ví dụ là nhập chưa đủ thông tin:
            string MaPhong = txtmakhoa.Text;
            string TenPhong = txttenphong.Text;
            string LoaiPhong = txtloaiphong.Text;
            ketnoi.Open();

            sql = @"insert into Phong
	        values 
            (N'" + MaPhong + "' , N'" + TenPhong + "' )";
            MessageBox.Show("THÊM THÀNH CÔNG!!");

            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();
            loadPhong();
        }

        private void suap_Click(object sender, EventArgs e)
{

}

private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
{

}

private void label7_Click(object sender, EventArgs e)
{

}

private void pictureBox1_Click(object sender, EventArgs e)
{

}

private void groupBox2_Enter(object sender, EventArgs e)
{

}

private void groupBox1_Enter(object sender, EventArgs e)
{

}

private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
{

}

private void txtdienthoai_TextChanged(object sender, EventArgs e)
{

}

private void txtdiachi_TextChanged(object sender, EventArgs e)
{

}

private void txtgioitinh_TextChanged(object sender, EventArgs e)
{

}

private void txtnamsinh_TextChanged(object sender, EventArgs e)
{

}

private void txtten_TextChanged(object sender, EventArgs e)
{

}

private void txtmasv_TextChanged(object sender, EventArgs e)
{

}

private void label6_Click(object sender, EventArgs e)
{

}

private void label5_Click(object sender, EventArgs e)
{

}

private void label4_Click(object sender, EventArgs e)
{

}

private void label3_Click(object sender, EventArgs e)
{

}

private void label2_Click(object sender, EventArgs e)
{

}

private void label1_Click(object sender, EventArgs e)
{

}

private void tabPage2_Click(object sender, EventArgs e)
{

}

private void groupBox4_Enter(object sender, EventArgs e)
{

}

private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
{

}

private void label8_Click(object sender, EventArgs e)
{

}

private void groupBox3_Enter(object sender, EventArgs e)
{

}

private void textBox3_TextChanged(object sender, EventArgs e)
{

}

private void textBox2_TextChanged(object sender, EventArgs e)
{

}

private void label9_Click(object sender, EventArgs e)
{

}

private void lable2_Click(object sender, EventArgs e)
{

}

private void textBox1_TextChanged(object sender, EventArgs e)
{

}

private void txtmakhoa_Click(object sender, EventArgs e)
{

}

private void tabPage3_Click(object sender, EventArgs e)
{

}

private void groupBox5_Enter(object sender, EventArgs e)
{

}

private void label10_Click(object sender, EventArgs e)
{

}

private void groupBox6_Enter(object sender, EventArgs e)
{

}

private void xoap_Click(object sender, EventArgs e)
{

}

private void txtloaiphong_TextChanged(object sender, EventArgs e)
{

}

private void txttenphong_TextChanged(object sender, EventArgs e)
{

}

private void label11_Click(object sender, EventArgs e)
{

}

private void label12_Click(object sender, EventArgs e)
{

}

private void txtmaphong_TextChanged(object sender, EventArgs e)
{

}

private void label13_Click(object sender, EventArgs e)
{

}

private void label10_Click_1(object sender, EventArgs e)
{

}

private void groupBox3_Enter_1(object sender, EventArgs e)
{

}

private void txtgioitinh_TextChanged_1(object sender, EventArgs e)
{

}

private void button1_Click(object sender, EventArgs e)
{

}

        private void themsv_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}




using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Luyện_Tập
{
    public partial class Form1 : Form
    {
        List<string> listGioiTinh = new List<string>() { "Nam", "Nữ", "Không Xác Định" };
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboGioiTinh.DataSource = listGioiTinh;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn Muốn Thoát Chương Trình","Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                e.Cancel = true;
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            String hoten = txbHoTen.Text;
            String diachi = txbDiaChi.Text;

            if (KiemTraNhap())
            {
                Xu_Ly.suaChuoi(ref hoten);
                Xu_Ly.suaChuoi(ref diachi);
                txbThongTin.Text = "Họ Tên: " + hoten + Environment.NewLine
                    + "Ngày Sinh: " + dtpkNgaysinh.Value.ToShortDateString() + Environment.NewLine
                    + "Giới Tính: " + cboGioiTinh.SelectedItem + Environment.NewLine
                    + "Địa Chỉ: " + diachi + Environment.NewLine
                    + "CCCD: " + txbCCCD.Text;
            }
            foreach(var iteam in groupBox1.Controls)

            {
                TextBox iteam1 = iteam as TextBox;
                if(iteam1 != null)
                {
                    iteam1.Clear();
                }    
            }
            dtpkNgaysinh.Value = DateTime.Now;
        }
           
            bool KiemTraNhap()

        {
            String cccd = txbCCCD.Text;
            long ketqua;
            char[] mangCCCD = cccd.ToCharArray();
   
        if (txbHoTen.Text == "")
            { 
                MessageBox.Show("Nhập Họ Tên Đi Bạn Êi", "Thông Báo");
                txbHoTen.Focus();
                return false;
            }
            if (txbDiaChi.Text == "")
            {
                MessageBox.Show("Nhập Địa Chỉ Đi Bạn Êi", "Thông Báo");
                txbDiaChi.Focus();
                return false;
            }
            if (txbCCCD.Text == "")
            {
                MessageBox.Show("Nhập CCCD Đi Bạn Êi", "Thông Báo");
                txbCCCD.Focus();
                return false;
            }
            if (!(long.TryParse(cccd, out ketqua)))
            {
                MessageBox.Show("Hãy Nhập Đúng Định Dạng Số Căn Cướp Công Dân", "Thông Báo");
                txbCCCD.Focus();
                return false;
            }
            if (ketqua < 0)
            {
                MessageBox.Show("Số CCCD không được âm", "Thông Báo");
                txbCCCD.Focus();
                return false;
            }
            if (mangCCCD.Length != 12)
            {
                MessageBox.Show("Số CCCD Phải Đúng 12 Số", "Thông Báo");
                txbCCCD.Focus();
                return false;
            }
            return true;
            }
        }

    }

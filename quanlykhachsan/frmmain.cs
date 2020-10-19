using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using System.Data.SqlClient;

namespace quanlykhachsan
{
    public partial class frmmain : Form
    {
        public frmmain()
        {
            InitializeComponent();
        }
        private void hienthikhachhang()
        {
            khachhangBLL pbll = new khachhangBLL();
            dgkhachhang.DataSource = pbll.hienthikhachhang();
        }

        private void hienthiphong()
        {
            phongBLL pbll = new phongBLL();
            dtgvDanhSachphong.DataSource = pbll.hienthithongtinphong();
        }

        private void hienthitraphong()
        {
            thuephongBLL tpBLL = new thuephongBLL();
            dgtraphong.DataSource = tpBLL.hienthi_thuetheophong();
        }

        private void btThuePhongOK_Click(object sender, EventArgs e)
        {
            thuephongBLL tpBLL = new thuephongBLL();
            tpBLL.them_thuephong(int.Parse(txtmakhtp.Text.Trim()), dtTuNgaytp.Value, int.Parse(txtPhongtp.Text.Trim()));
            MessageBox.Show("thuê phòng thàng công", "Thông báo");
        }

        private void bHuyBo_Click(object sender, EventArgs e)
        {
            txtPhongtp.Clear();
            txtphongdt.Clear();
            txtmakhtp.Clear();
        }

        private void dgkhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgkhachhang.Rows[e.RowIndex];
            txtmakhtp.Text = row.Cells["maKhachHang"].Value.ToString();
        }

        private void trangthai(bool t)
        {
            txtPhongtp.Enabled = t;
            dtTuNgaytp.Enabled = t;
            txtphongdt.Enabled = !t;
            dtngaydattruoc.Enabled = !t;
        }

        private void frmmain_Load(object sender, EventArgs e)
        {
            hienthiphong();
            hienthikhachhang();
            dtTuNgaytp.Value = DateTime.Now;
        }

        private void btndangxuat_Click(object sender, EventArgs e)
        {
            frmmainquanlykhachsan.ActiveForm.Close();
            frmdangnhap frm = new frmdangnhap();
            frm.Show();
        }
        private void thanhtoan()
        {
            TimeSpan Time = (dttpngayketthucthue.Value - dttpngaybatdauthue.Value);
            int TongSoNgay = Time.Days + 1;
            int ngaybatdau = dttpngaybatdauthue.Value.Day;
            int ngayketthuc = dttpngayketthucthue.Value.Day;

            if (ngaybatdau > ngayketthuc)/// vào từ sáng đén tối vẫn tính là 1 ngày
                MessageBox.Show("nhập sai ngày!! vui long nhập lại", "Thông báo");
            else
                txttongtien.Text = (TongSoNgay * int.Parse(txtdongiatp.Text)).ToString();
        }

        private void TPTinhTien_Click(object sender, EventArgs e)
        {
            thanhtoan();
            // thuephongBLL tpBLL = new thuephongBLL();
            //   tpBLL.tinhtien(dttpngayketthucthue.Value, float.Parse(txttongtien.Text.Trim()),int.Parse(txtmathuephong.Text.Trim()),int.Parse(txtTPPhong.Text.Trim()));
            hienthitraphong();
            MessageBox.Show("Số tiền phải trả là : " + txttongtien.Text, "Tổng tiền");
        }
    }
}

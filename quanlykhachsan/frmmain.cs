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
            Load_Phong();
            Load_PhongTrong();
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

        #region Thuê phòng
        //Tab Thue phong
        private void Tabphong_Click(object sender, EventArgs e)
        {
            hienthiphong();
            hienthitraphong();
        }


        private void btThuePhongOK_Click(object sender, EventArgs e)
        {
            thuephongBLL tpBLL = new thuephongBLL();
            tpBLL.them_thuephong(int.Parse(txtmakhtp.Text.Trim()), dtTuNgaytp.Value, int.Parse(comboBox1.Text.Trim()));
            MessageBox.Show("thuê phòng thành công", "Thông báo");
        }
        public void Load_Phong()
        {
            thuephongBLL tpBLL = new thuephongBLL();

            DataTable dt = tpBLL.hienthi_maphong();
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox2.Items.Add(dt.Rows[i][0]);
            }
        }
        public void Load_PhongTrong()
        {
            thuephongBLL tpBLL = new thuephongBLL();

            DataTable dt = tpBLL.hienthi_maphongtrong();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i][0]);
            }
        }
        private void bHuyBo_Click(object sender, EventArgs e)
        {
            //comboBox1.Clear();
            //comboBox2.Clear();
            txtmakhtp.Clear();
        }


        private void trangthai(bool t)
        {
            comboBox1.Enabled = t;
            dtTuNgaytp.Enabled = t;
            comboBox2.Enabled = !t;
            dtngaydattruoc.Enabled = !t;
        }


        private void thanhtoan()
        {
            TimeSpan Time = (dttpngayketthucthue.Value - dttpngaybatdauthue.Value);
            int TongSoNgay = Time.Days + 1;
            //int ngaybatdau = dttpngaybatdauthue.Value.Day;
            //int ngayketthuc = dttpngayketthucthue.Value.Day;

            if(dttpngaybatdauthue.Value.Year > dttpngayketthucthue.Value.Year)
                MessageBox.Show("Nhập sai ngày!! vui lòng nhập lại", "Thông báo");
            if (dttpngaybatdauthue.Value.Month > dttpngayketthucthue.Value.Month)
            {
                if(dttpngaybatdauthue.Value.Year > dttpngayketthucthue.Value.Year)
                    MessageBox.Show("Nhập sai ngày!! vui lòng nhập lại", "Thông báo");
            }
                
            if (dttpngaybatdauthue.Value.Day > dttpngayketthucthue.Value.Day)/// vào từ sáng đén tối vẫn tính là 1 ngày
            {
                if (dttpngaybatdauthue.Value.Month > dttpngayketthucthue.Value.Month)
                    if (dttpngaybatdauthue.Value.Year > dttpngayketthucthue.Value.Year)
                        MessageBox.Show("Nhập sai ngày!! vui lòng nhập lại", "Thông báo");
            }
                
            
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

        private void checkBDatPhongTruoc_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBDatPhongTruoc.Checked == true)
                trangthai(false);
            else
                trangthai(true);
        }

        
        private void dgkhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgkhachhang.Rows[e.RowIndex];
            txtmakhtp.Text = row.Cells["maKhachHang"].Value.ToString();

        }

       

        private void dtgvTraPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow(); 
            row = dgtraphong.Rows[e.RowIndex];           
            txtTPPhong.Text = row.Cells["maPhong"].Value.ToString();
            txtTPTenKH.Text = row.Cells["tenKhachHang"].Value.ToString();
            txtTPSoCMND.Text = row.Cells["chungMinhNhanDan"].Value.ToString();
            txtTPSoDT.Text = row.Cells["soDienThoai"].Value.ToString();
            txtTPDiaChi.Text = row.Cells["diaChi"].Value.ToString();
            txtdongiatp.Text = row.Cells["donGia"].Value.ToString();
            txtmathuephong.Text = row.Cells["maThuePhong"].Value.ToString();
            dtngaysinh.Value = Convert.ToDateTime(row.Cells["ngaySinh"].Value.ToString());
            dttpngaybatdauthue.Value = Convert.ToDateTime(row.Cells["ngayDen"].Value.ToString());
        }

        #endregion
    }
}

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

namespace quanlykhachsan
{
    public partial class frmthongtinphong : Form
    {
        int temp;
        public frmthongtinphong()
        {
            InitializeComponent();
        }
        private void hienthi()
        {
            phongBLL pbll = new phongBLL();
            GridView.DataSource = pbll.hienthithongtinphong();
        }
        private void trangthai(bool t)
        {
            txtphong.Enabled = t;
            txtdongiaphong.Enabled = t;
            cbloaiphong.Enabled = t;
            cbtinhtrang.Enabled = t;
        }


        private void GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = GridView.Rows[e.RowIndex];
            txtphong.Text = row.Cells["maPhong"].Value.ToString();
            txtdongiaphong.Text = row.Cells["donGia"].Value.ToString();
            cbloaiphong.Text = row.Cells["loaiPhong"].Value.ToString();
            cbtinhtrang.Text = row.Cells["tinhTrang"].Value.ToString();

        }

        private void btnthemphong_Click(object sender, EventArgs e)
        {
            temp = 1;
            trangthai(true);
            txtphong.Clear();
            cbloaiphong.ResetText();
            cbtinhtrang.ResetText();
            txtdongiaphong.Clear();
            btnluuphong.Enabled = true;
            btnsuaphong.Enabled = false;
            btnxoaphong.Enabled = false;
            btnthoatphong.Enabled = true;

        }

        private void frmthongtinphong_Load(object sender, EventArgs e)
        {
            hienthi();
            trangthai(false);
        }

        private void btnsuaphong_Click(object sender, EventArgs e)
        {
            trangthai(true);
            temp = 2;
            btnluuphong.Enabled = true;
            btnthemphong.Enabled = false;
            btnxoaphong.Enabled = false;
            btnthoatphong.Enabled = true;
        }

        private void btnxoaphong_Click(object sender, EventArgs e)
        {
            phongBLL pBLL = new phongBLL();
            DialogResult luu = MessageBox.Show("Bạn chắc chắn xoá?", "Thông báo thêm mới", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (luu == DialogResult.Yes)
            {
                pBLL.xoa_phong(int.Parse(txtphong.Text));
                hienthi();
            }
        }
        //private bool traveloaiphong()
        //{
        //    if (cbloaiphong.Text == "Bận")
        //        return true;
        //    else
        //        return false;
        //}
        private bool traveTinhtrang()
        {
            if (cbtinhtrang.Text == "Bận")
                return true;
            else
                return false;
        }
        private void btnluuphong_Click(object sender, EventArgs e)
        {
            trangthai(false);
            if (temp == 1)
            {
                phongBLL pBLL = new phongBLL();
                pBLL.them_phong(Convert.ToInt32(txtphong.Text),traveTinhtrang(), cbloaiphong.Text, Convert.ToInt32(txtdongiaphong.Text));
                hienthi();
            }
            else
            {
                phongBLL pBLL = new phongBLL();
                pBLL.sua_phong(Convert.ToInt32(txtphong.Text), traveTinhtrang(), cbloaiphong.Text, Convert.ToInt32(txtdongiaphong.Text));
               // nvBLL.sua_phong(txttennv.Text, travegioitinh(), dtngaysinh.Value, txtscm.Text, txtdiachi.Text, txtsdt.Text, dtngayvaolam.Value, int.Parse(txtmanv.Text));
                hienthi();
            }
            btnluuphong.Enabled = false;
            btnthemphong.Enabled = true;
            btnxoaphong.Enabled = true;
            btnthoatphong.Enabled = true;

        }

        private void btnthoatphong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

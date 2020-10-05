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
            //BLL
        }
        private void hienthiphong()
        {
            //BLL
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
    }
}


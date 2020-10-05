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
    public partial class frmmainquanlykhachsan : Form
    {
        public frmmainquanlykhachsan()
        {
            InitializeComponent();
        }
        private void frmmainquanlykhachsan_Load(object sender, EventArgs e)
        {
            frmmain frm = new frmmain();
            frm.MdiParent = this;
            frm.Show();
        }
        //điều hướng trên form quản lý
        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmmain frm = new frmmain();
            frm.MdiParent = this;
            frm.Show();
        }

        private void quảnLýPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmthongtinphong frm = new frmthongtinphong();
            frm.MdiParent = this;
            frm.Show();
        }

        private void quảnLýThôngTinKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmkhachhang frm = new frmkhachhang();
            frm.MdiParent = this;
            frm.Show();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmnhanvien frm = new frmnhanvien();
            frm.MdiParent = this;
            frm.Show();
        }


    }
}


﻿using System;
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
    public partial class frmthongtinpphongkh : Form
    {
        public frmthongtinpphongkh()
        {
            InitializeComponent();
        }

        //Load du lieu len datagridview thong tin phong kh
        private void frm_load(object sender, EventArgs e)
        {
            phongBLL pbll = new phongBLL();
            dataGridView1.DataSource = pbll.hienthithongtinphong();
        }

        //Thoat khỏi form hien tai, tro lai form dang nhap
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmdangnhap frm = new frmdangnhap();
            frm.Show();
        }

        //Thoat khoi chuong trinh
        private void thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

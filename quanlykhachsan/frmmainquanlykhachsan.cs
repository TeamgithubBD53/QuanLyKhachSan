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

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmmain frm = new frmmain();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}

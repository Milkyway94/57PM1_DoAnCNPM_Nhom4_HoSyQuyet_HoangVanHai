using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNPM_QLCH__VTNN.Views
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_Hoadonxuat f = new frm_Hoadonxuat();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_Quanlythongtinchung f = new frm_Quanlythongtinchung();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm_Thongke f = new frm_Thongke();
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }
    }
}

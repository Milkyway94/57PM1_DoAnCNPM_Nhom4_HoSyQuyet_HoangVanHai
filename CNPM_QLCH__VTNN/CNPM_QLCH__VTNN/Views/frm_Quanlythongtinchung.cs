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
    public partial class frm_Quanlythongtinchung : Form
    {
        public frm_Quanlythongtinchung()
        {
            InitializeComponent();
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            frm_Quanlykhachhang f = new frm_Quanlykhachhang();           
            f.Show();
            f.WindowState = FormWindowState.Maximized;
       }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_Quanlynhanvien f = new frm_Quanlynhanvien();
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_Quanlysanpham f = new frm_Quanlysanpham();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm_Quanlyhoadonban f = new frm_Quanlyhoadonban();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using CNPM_QLCH__VTNN.Controllers;
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
    public partial class frm_Quanlysanpham : Form
    {
        public frm_Quanlysanpham()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        LoaiSP_ctrl ls = new LoaiSP_ctrl();
        Nhanvien_ctrl n = new Nhanvien_ctrl();
        Sanpham_ctrl s = new Sanpham_ctrl();
        private void dtg_update()
        {
            dataGridView1.DataSource = s.Select_all_SP().data;
            dataGridView2.DataSource = ls.Select_all_LoaiSP().data;
        }
        private void frm_Quanlysanpham_Load(object sender, EventArgs e)
        {
            dtg_update();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            masp.Text = null;
            tensp.Text = null;
            gia.Text = null;
            donvi.Text = null;
            cb_loaisp.Text = null;

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            var rs = s.Insert(masp.Text, tensp.Text, cb_loaisp.Text, donvi.Text, double.Parse(gia.Text),double.Parse(giaban.Text),int.Parse( sl.Text));
            switch (rs.errCode)
            {
                case Shareds.ErrorCode.Success:
                    MessageBox.Show(rs.errInfo);
                    break;
                case Shareds.ErrorCode.Fail:
                    break;
                case Shareds.ErrorCode.Exists:
                    break;
                case Shareds.ErrorCode.NotExists:
                    break;
                case Shareds.ErrorCode.NoData:
                    break;
                case Shareds.ErrorCode.NaN:
                    MessageBox.Show(rs.errInfo);
                    break;
                case Shareds.ErrorCode.FormatFail:
                    break;
                default:
                    break;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

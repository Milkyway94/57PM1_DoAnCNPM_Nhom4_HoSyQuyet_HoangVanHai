using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CNPM_QLCH__VTNN.Controllers;
using CNPM_QLCH__VTNN.Models;
using CNPM_QLCH__VTNN.Database;
using CNPM_QLCH__VTNN.Shareds;
namespace CNPM_QLCH__VTNN.Views
{

    public partial class frm_Quanlykhachhang : Form
    {
        public frm_Quanlykhachhang()
        {
            InitializeComponent();
        }
        Khachhang_ctrls k = new Khachhang_ctrls();
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            frm_Quanlythongtinchung f = new frm_Quanlythongtinchung();
            f.Show();
            f.WindowState = FormWindowState.Maximized;

        }
        private void updatedata()
        {
            var rs = k.Select_all_Khachhang();
            switch (rs.errCode)
            {
                case Shareds.ErrorCode.Success:
                    dataGridView1.DataSource = rs.data;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.Columns[0].HeaderCell.Value = "Mã khách hàng";
                    dataGridView1.Columns[1].HeaderCell.Value = "Tên khách hàng";
                    dataGridView1.Columns[2].HeaderCell.Value = "Địa chỉ";
                    dataGridView1.Columns[3].HeaderCell.Value = "Số điện thoại";
                    break;
                case Shareds.ErrorCode.Fail:
                    MessageBox.Show(rs.errInfo);
                    break;
                case Shareds.ErrorCode.NoData:
                    MessageBox.Show(rs.errInfo);
                    break;
                default:
                    break;
            }
            dataGridView1.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void frm_Quanlykhachhang_Load(object sender, EventArgs e)
        {
            
            updatedata();      
            var dt = db.tbl_KHACHHANGs.Where(o => o.MaKH == getMakH());
            while (true)
            {
                txt_makh.Text = getMakH();
                if (dt.Count() == 0) { txt_makh.Text = getMakH(); break; }
            }           
            txt_tenkh.Focus();
        }
        private string getMakH()
        {

            Random rd = new Random();
            int i = rd.Next(1, 100000);
            string makh = "KH" + i.ToString();
            return makh;
        }
        private void button1_Click(object sender, EventArgs e)
        {           
            var rs = k.Insert(txt_makh.Text, txt_tenkh.Text, txt_diachi.Text, txt_sdt.Text);
            switch (rs.errCode)
            {
                case Shareds.ErrorCode.Success:
                    updatedata();
                    MessageBox.Show(rs.errInfo);
                    break;
                case Shareds.ErrorCode.Fail:
                    MessageBox.Show(rs.errInfo);
                    break;
                case Shareds.ErrorCode.Exists:
                    MessageBox.Show(txt_makh.Text + "already exists in database!");
                    txt_makh.Select();
                    txt_makh.Focus();
                    break;
                case Shareds.ErrorCode.NotExists:
                    break;
                case Shareds.ErrorCode.NoData:
                    break;
                case Shareds.ErrorCode.NaN:
                    if (txt_makh.Text == null || txt_makh.Text == "")
                    {
                        MessageBox.Show(rs.errInfo);
                        txt_makh.Focus();
                    }
                    if (txt_tenkh.Text == null || txt_tenkh.Text == "")
                    {
                        MessageBox.Show(rs.errInfo);
                        txt_tenkh.Focus();
                    }
                    if (txt_diachi.Text == null || txt_diachi.Text == "")
                    {
                        MessageBox.Show(  rs.errInfo);
                        txt_diachi.Focus();
                    }
                    if (txt_sdt.Text == null || txt_sdt.Text == "")
                    {
                        MessageBox.Show(rs.errInfo);
                        txt_sdt.Focus();
                    }

                    break;
                case Shareds.ErrorCode.FormatFail:
                    break;
                default:
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var rs = k.Update(txt_makh.Text, txt_tenkh.Text, txt_diachi.Text, txt_sdt.Text);
            switch (rs.errCode)
            {
                case Shareds.ErrorCode.Success:
                    MessageBox.Show(rs.errInfo);
                    updatedata();
                    break;
                case Shareds.ErrorCode.Fail:
                    MessageBox.Show(rs.errInfo);
                    break;
                case Shareds.ErrorCode.NotExists:
                    MessageBox.Show(rs.errInfo);
                    break;
                default:
                    break;
            }
        }
        DataClasses1DataContext db = new DataClasses1DataContext();
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Nếu xóa những khách hàng này sẽ có thể sẽ mất hết Hóa đơn của họ. Bạn có thực sự muốn xóa không?", "Canh bao", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var data = dataGridView1.SelectedRows;
                try
                {
                    if (data.Count > 0)
                    {
                        for (int i=0; i<data.Count;i++)
                        {
                                
                                var rs = k.Delete(data[i].Cells[0].Value.ToString());
                                switch (rs.errCode)
                                {
                                    case ErrorCode.Success:
                                        
                                        break;
                                    case ErrorCode.Fail:
                                        MessageBox.Show(rs.errInfo);
                                        break;
                                    case ErrorCode.NoData:
                                        MessageBox.Show(rs.errInfo);
                                        break;
                                    default:
                                        break;
                                

                            }
                            
                        }
                        updatedata();
                        MessageBox.Show(ErrorInfo.DeleteSuccess);                       
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ErrorInfo.Fail + ex.ToString());
                }
                //txt_diachi.Text = null;
                //txt_sdt.Text = null;
                //txt_tenkh.Text = null;
                //txt_makh = null;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frm_Hoadonxuat f = new frm_Hoadonxuat();
            f.TopLevel = false;
            this.Controls.Clear();
            f.Dock = DockStyle.Fill;
            this.Controls.Add(f);
            f.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txt_makh.Text= dataGridView1.Rows[i].Cells[0].Value.ToString();
            txt_tenkh.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txt_diachi.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txt_sdt.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txt_makh.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txt_tenkh.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txt_diachi.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txt_sdt.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txt_sdt.Text = null;
            txt_diachi.Text = null;
            txt_makh.Text = getMakH();
            txt_tenkh.Text = null;
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            var rs = k.Select_Khachhang_by_ID(textBox5.Text);
            switch (rs.errCode)
            {
                case ErrorCode.Success:
                    dataGridView1.DataSource = rs.data;
                    break;
                case ErrorCode.Fail:
                    MessageBox.Show(rs.errInfo);
                    break;
                case ErrorCode.Exists:
                    break;
                case ErrorCode.NotExists:
                    break;
                case ErrorCode.NoData:
                    
                    break;
                case ErrorCode.NaN:
                    break;
                case ErrorCode.FormatFail:
                    break;
                default:
                    break;
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txt_makh.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txt_tenkh.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txt_diachi.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txt_sdt.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
        }
    }
}

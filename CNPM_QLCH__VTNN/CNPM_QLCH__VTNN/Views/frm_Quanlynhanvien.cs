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
using CNPM_QLCH__VTNN.Database;
namespace CNPM_QLCH__VTNN.Views
{
    public partial class frm_Quanlynhanvien : Form
    {
        public frm_Quanlynhanvien()
        {
            InitializeComponent();
        }
        private void updatedata()
        {
            var rs = nv.Select_all_NV();
            switch (rs.errCode)
            {
                case Shareds.ErrorCode.Success:
                    dataGridView1.DataSource = rs.data;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.Columns[0].HeaderCell.Value = "Mã nhân viên";
                    dataGridView1.Columns[1].HeaderCell.Value = "Tên nhân viên";
                    dataGridView1.Columns[02].HeaderCell.Value = "Ngày sinh";
                    dataGridView1.Columns[03].HeaderCell.Value = "Địa chỉ";
                    dataGridView1.Columns[04].HeaderCell.Value = "Quê quán";
                    dataGridView1.Columns[5].HeaderCell.Value = "Số điện thoại";
                    dataGridView1.Columns[6].HeaderCell.Value = "Lương cơ bản";
                    break;
                case Shareds.ErrorCode.Fail:
                    MessageBox.Show(rs.errInfo);
                    break;
                case Shareds.ErrorCode.Exists:
                    break;
                case Shareds.ErrorCode.NotExists:
                    break;
                case Shareds.ErrorCode.NoData:
                    MessageBox.Show(rs.errInfo);
                    break;
                case Shareds.ErrorCode.NaN:
                    break;
                case Shareds.ErrorCode.FormatFail:
                    break;
                default:
                    break;
            }
        }
        Nhanvien_ctrl nv = new Nhanvien_ctrl();
        private void frm_Quanlynhanvien_Load(object sender, EventArgs e)
        {
            getMaNV();
            updatedata();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var selectedrows = dataGridView1.SelectedRows;
            if(MessageBox.Show("Bạn có chắc chắn muốn xóa những nhân viên đã chọn không?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                for (int i = selectedrows.Count - 1; i >= 0; i--)
                {
                    var rs = nv.Delete(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    switch (rs.errCode)
                    {
                        case Shareds.ErrorCode.Success:
                            MessageBox.Show("Xóa thành công "+selectedrows.Count+" nhân viên");
                            updatedata();
                            break;
                        case Shareds.ErrorCode.Fail:
                            MessageBox.Show(rs.errInfo);
                            break;
                        case Shareds.ErrorCode.Exists:
                            break;
                        case Shareds.ErrorCode.NotExists:
                            MessageBox.Show(rs.errInfo);
                            break;
                        case Shareds.ErrorCode.NoData:
                            break;
                        case Shareds.ErrorCode.NaN:
                            break;
                        case Shareds.ErrorCode.FormatFail:
                            break;
                        default:
                            break;
                    }
                }
            }
            
        }
        DataClasses1DataContext db = new DataClasses1DataContext();
        private void getMaNV()
        {
            Random r = new Random();
            int nv = r.Next(1, 9);
            string MaNV = "NV0" + nv.ToString();
            var i = db.tbl_HOADONs.Where(o => o.MaNV == MaNV);
            while (true)
            {
                //txt_MaHD.Text = mahd;
                if (i.Count() == 0)
                {
                    txt_MaNV.Text = MaNV;
                    break;
                }
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            getMaNV();
            txt_diachi.Text = null;
            txt_ngaysinh.Value = DateTime.Now;
            txt_quequan.Text = null;
            txt_sdt.Text = null;
            txt_TenNV.Text = null;
            txt_luongcb.Text = "0";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dt = nv.Select_NV_by_ID(txt_MaNV.Text);
            switch (dt.errCode)
            {
                case Shareds.ErrorCode.Success:
                    var rs = nv.Update(txt_MaNV.Text, txt_TenNV.Text, txt_ngaysinh.Value, txt_diachi.Text, txt_quequan.Text, txt_sdt.Text, double.Parse(txt_luongcb.Text));
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
                            break;
                        case Shareds.ErrorCode.NotExists:
                            MessageBox.Show(rs.errInfo);
                            break;
                        case Shareds.ErrorCode.NoData:
                            MessageBox.Show(rs.errInfo);
                            break;
                        case Shareds.ErrorCode.NaN:
                            MessageBox.Show(rs.errInfo);
                            break;
                        case Shareds.ErrorCode.FormatFail:
                            break;
                        default:
                            break;
                    }
                    break;
                case Shareds.ErrorCode.Fail:
                    break;
                case Shareds.ErrorCode.Exists:
                    break;
                case Shareds.ErrorCode.NotExists:
                    break;
                case Shareds.ErrorCode.NoData:
                    var dl = nv.Insert(txt_MaNV.Text, txt_TenNV.Text, txt_ngaysinh.Value, txt_diachi.Text, txt_quequan.Text, txt_sdt.Text, double.Parse(txt_luongcb.Text));
                    switch (dl.errCode)
                    {
                        case Shareds.ErrorCode.Success:
                            MessageBox.Show(dl.errInfo);
                            updatedata();
                            break;
                        case Shareds.ErrorCode.Fail:
                            MessageBox.Show(dl.errInfo);
                            break;
                        case Shareds.ErrorCode.Exists:
                            MessageBox.Show(dl.errInfo);
                            break;
                        case Shareds.ErrorCode.NotExists:
                            break;
                        case Shareds.ErrorCode.NoData:
                            MessageBox.Show(dl.errInfo);
                            break;
                        case Shareds.ErrorCode.NaN:
                            MessageBox.Show(dl.errInfo);
                            break;
                        case Shareds.ErrorCode.FormatFail:
                            break;
                        default:
                            break;
                    }
                    break;
                case Shareds.ErrorCode.NaN:
                    break;
                case Shareds.ErrorCode.FormatFail:
                    break;
                default:
                    break;
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i != -1)
            {
                txt_MaNV.Text=dataGridView1.Rows[i].Cells[0].Value.ToString();
                txt_TenNV.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                txt_ngaysinh.Value = Convert.ToDateTime(dataGridView1.Rows[i].Cells[2].Value);
                txt_diachi.Text = dataGridView1.Rows[i].Cells[03].Value.ToString();
                txt_quequan.Text = dataGridView1.Rows[i].Cells[04].Value.ToString();
                txt_sdt.Text = dataGridView1.Rows[i].Cells[05].Value.ToString();
                txt_luongcb.Text = dataGridView1.Rows[i].Cells[06].Value.ToString();
            }
        }
    }
}

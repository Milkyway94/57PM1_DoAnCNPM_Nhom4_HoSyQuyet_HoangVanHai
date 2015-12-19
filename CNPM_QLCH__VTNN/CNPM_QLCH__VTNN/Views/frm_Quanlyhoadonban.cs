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
    public partial class frm_Quanlyhoadonban : Form
    {
        public frm_Quanlyhoadonban()
        {
            InitializeComponent();
            txt_ngaylap.Format = DateTimePickerFormat.Custom;
            txt_ngaylap.CustomFormat = "dd/MM/yyyy";
        }

        private void txt_manv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void gridview()
        {
            DataGridViewColumn col0 = new DataGridViewColumn();
            col0.Name = "MaSP";
            col0.HeaderText = "Mã sản phẩm";
            col0.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(col0);

            DataGridViewColumn col1 = new DataGridViewColumn();
            col1.Name = "TenSP";
            col1.HeaderText = "Tên sản phẩm";
            col1.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(col1);

            DataGridViewColumn col6 = new DataGridViewColumn();
            col6.Name = "Tenloai";
            col6.HeaderText = "Loại sản phẩm";
            col6.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(col6);

            DataGridViewColumn col2 = new DataGridViewColumn();
            col2.Name = "GiaSP";
            col2.HeaderText = "Giá bán";
            col2.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(col2);

            DataGridViewColumn col3 = new DataGridViewColumn();
            col3.Name = "Soluong";
            col3.HeaderText = "Số lượng";
            col3.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(col3);

            DataGridViewColumn col4 = new DataGridViewColumn();
            col4.Name = "Donvi";
            col4.HeaderText = "Đơn vị";
            col4.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(col4);
            DataGridViewColumn col = new DataGridViewColumn();
            col.Name = "Thanhtien";
            col.HeaderText = "Thành tiền";
            col.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(col);
        }
        Chitiethoadon_ctrl ct = new Chitiethoadon_ctrl();
        Khachhang_ctrls k = new Khachhang_ctrls();
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MaHD.Text = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_kh.Text = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_ngaylap.Text = dataGridView3.Rows[e.RowIndex].Cells[03].Value.ToString();
            txt_nhanvien.Text = dataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString();
            txt_diachi.Text = k.get_DC(dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString()).data;
            txt_sdt.Text = k.get_Sdt(dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString()).data;
            dataGridView3.Visible = false;
            groupBox1.Top = 120;
            groupBox2.Top = 240;
            var dt = ct.Select_CTHD_by_MaHD(txt_MaHD.Text);
            int d = 0;
            switch (dt.errCode)
            {
                case Shareds.ErrorCode.Success:
                    var rs = ct.Select_CTHD_by_MaHD(txt_MaHD.Text);
                    switch (rs.errCode)
                    {
                        case Shareds.ErrorCode.Success:
                            dataGridView1.Columns.Clear();
                            dataGridView1.DataSource = rs.data;
                           
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
                    break;
                case Shareds.ErrorCode.FormatFail:
                    break;
                default:
                    break;
            }
        }
        Hoadon_ctrl hd = new Hoadon_ctrl();
        private void txt_searchcontent_TextChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex + 1)
            {
                case 1:
                    var rs1 = hd.Search_HD(txt_searchcontent.Text, 1);
                    switch (rs1.errCode)
                    {
                        case Shareds.ErrorCode.Success:
                            dataGridView3.Visible = true;
                            dataGridView3.DataSource = rs1.data;
                            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                            break;
                        case Shareds.ErrorCode.Fail:
                            break;
                        case Shareds.ErrorCode.Exists:
                            break;
                        case Shareds.ErrorCode.NotExists:
                            break;
                        case Shareds.ErrorCode.NoData:
                            dataGridView3.Visible = true;
                            dataGridView3.DataSource = rs1.data;
                            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            break;
                        case Shareds.ErrorCode.NaN:
                            break;
                        case Shareds.ErrorCode.FormatFail:
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
                    var rs2 = hd.Search_HD(txt_searchcontent.Text, 2);
                    switch (rs2.errCode)
                    {
                        case Shareds.ErrorCode.Success:
                            dataGridView3.Visible = true;
                            dataGridView3.DataSource = rs2.data;
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
                            dataGridView3.Visible = true;
                            dataGridView3.DataSource = rs2.data;
                            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            break;
                        case Shareds.ErrorCode.FormatFail:
                            break;
                        default:
                            break;
                    }
                    break;
                case 3:
                    var rs3 = hd.Search_HD(txt_searchcontent.Text, 3);
                    switch (rs3.errCode)
                    {
                        case Shareds.ErrorCode.Success:
                            dataGridView3.Visible = true;
                            dataGridView3.DataSource = rs3.data;

                            break;
                        case Shareds.ErrorCode.Fail:
                            break;
                        case Shareds.ErrorCode.Exists:
                            break;
                        case Shareds.ErrorCode.NotExists:
                            break;
                        case Shareds.ErrorCode.NoData:
                            dataGridView3.Visible = true;
                            dataGridView3.DataSource = rs3.data;
                            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            break;
                        case Shareds.ErrorCode.NaN:
                            break;
                        case Shareds.ErrorCode.FormatFail:
                            break;
                        default:
                            break;
                    }
                    break;
                case 4:
                    var rs = hd.Search_HD(txt_searchcontent.Text, 4);
                    switch (rs.errCode)
                    {
                        case Shareds.ErrorCode.Success:
                            dataGridView3.Visible = true;
                            dataGridView3.DataSource = rs.data;
                            break;
                        case Shareds.ErrorCode.Fail:
                            break;
                        case Shareds.ErrorCode.Exists:
                            break;
                        case Shareds.ErrorCode.NotExists:
                            break;
                        case Shareds.ErrorCode.NoData:
                            dataGridView3.Visible = true;
                            dataGridView3.DataSource = rs.data;
                            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            break;
                        case Shareds.ErrorCode.NaN:
                            break;
                        case Shareds.ErrorCode.FormatFail:
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
        private void updategrv()
        {
            var rs = hd.Select_all_hoadon();
            switch (rs.errCode)
            {
                case Shareds.ErrorCode.Success:
                    dataGridView1.DataSource = rs.data;                  
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
                    break;
                case Shareds.ErrorCode.FormatFail:
                    break;
                default:
                    break;
            }
        }
        private void frm_Quanlyhoadonban_Load(object sender, EventArgs e)
        {
            dataGridView3.DataSource = hd.Select_all_hoadon().data;
            gridview();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_Hoadonxuat f = new frm_Hoadonxuat();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip m = new ContextMenuStrip();


                int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {

                    m.Items.Add("Xóa dòng").Name = "Xoa";
                    m.Items.Add("Lưu").Name = "Luu";

                }

                m.Show(dataGridView1, new Point(e.X, e.Y));

                m.ItemClicked += new ToolStripItemClickedEventHandler(Menuclick1);
            }
        }
        Sanpham_ctrl s = new Sanpham_ctrl();
        private void Menuclick1(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name.ToString())
            {
                case "Xoa":
                    var dt = ct.Delete(txt_MaHD.Text, dataGridView1.CurrentRow.Cells[1].Value.ToString());
                    switch (dt.errCode)
                    {
                        case Shareds.ErrorCode.Success:
                            dataGridView1.DataSource = ct.Select_CTHD_by_MaHD(txt_MaHD.Text).data;
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
                            break;
                        case Shareds.ErrorCode.FormatFail:
                            break;
                        default:
                            break;
                    }
                    break;
                case "Luu":
                    var update = ct.Update(txt_MaHD.Text, dataGridView1.CurrentRow.Cells[0].Value.ToString(), int.Parse(dataGridView1.CurrentRow.Cells[04].Value.ToString()));
                    switch (update.errCode)
                    {
                        case Shareds.ErrorCode.Success:
                            MessageBox.Show(update.errInfo);
                            var rs = ct.Select_CTHD_by_MaHD(txt_MaHD.Text);
                            switch (rs.errCode)
                            {
                                case Shareds.ErrorCode.Success:
                                    dataGridView1.Columns.Clear();
                                    dataGridView1.DataSource = rs.data;
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
                            break;
                        case Shareds.ErrorCode.Fail:
                            MessageBox.Show(update.errInfo);
                            
                            break;
                        case Shareds.ErrorCode.Exists:
                            MessageBox.Show(update.errInfo);
                            break;
                        case Shareds.ErrorCode.NotExists:
                            MessageBox.Show(update.errInfo);
                            break;
                        case Shareds.ErrorCode.NoData:
                            MessageBox.Show(update.errInfo);
                            break;
                        case Shareds.ErrorCode.NaN:
                            MessageBox.Show(update.errInfo);
                            break;
                        case Shareds.ErrorCode.FormatFail:
                            MessageBox.Show(update.errInfo);
                            break;
                        default:
                            break;
                    }
                    break;
            }
        }
        private void thanhtien()
        {
            DataGridViewColumn col = new DataGridViewColumn();
            col.Name = "Thanhtien";
            col.HeaderText = "Thành tiền";
            col.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(col);
            
        }
        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            var rs = ct.Select_CTHD_by_MaHD(txt_MaHD.Text);
            switch (rs.errCode)
            {
                case Shareds.ErrorCode.Success:
                    List<double> l = new List<double>();
                    foreach (var item in rs.data)
                    {
                        l.Add(item.Thanhtien);
                    }
                    txt_tongtien.Text = l.Sum().ToString();
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
                    break;
                case Shareds.ErrorCode.FormatFail:
                    break;
                default:
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var rs = hd.Update(txt_MaHD.Text, k.get_MaKH(txt_kh.Text).data, txt_ngaylap.Value);
            switch (rs.errCode)
            {
                case Shareds.ErrorCode.Success:
                    MessageBox.Show(rs.errInfo);
                    break;
                case Shareds.ErrorCode.Fail:
                    MessageBox.Show(rs.errInfo);
                    break;
                case Shareds.ErrorCode.Exists:
                    break;
                case Shareds.ErrorCode.NotExists:
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

        private void button3_Click(object sender, EventArgs e)
        {
            Global.d = txt_MaHD.Text;
            hoadon f = new hoadon();
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void dataGridView1_DataMemberChanged(object sender, EventArgs e)
        {

        }
    }
}

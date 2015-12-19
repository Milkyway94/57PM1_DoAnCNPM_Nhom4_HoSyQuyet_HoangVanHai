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
    public partial class frm_Thongke : Form
    {
        public frm_Thongke()
        {
            InitializeComponent();
            combo_Nhanvien_data();
            combo_Khachhang_data();
            AutoCompleteStringCollection st = new AutoCompleteStringCollection();
            var rs = k.Select_all_Khachhang();
            switch (rs.errCode)
            {
                case Shareds.ErrorCode.Success:
                    foreach (var item in rs.data)
                    {
                        
                        st.Add(item.TenKH);
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
          
            khachhang.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            khachhang.AutoCompleteSource = AutoCompleteSource.CustomSource;
            khachhang.AutoCompleteCustomSource = st;
        }
        Khachhang_ctrls k = new Khachhang_ctrls();
        Nhanvien_ctrl nv = new Nhanvien_ctrl();
        private void combo_Nhanvien_data()
        {
            var rss = nv.Select_all_NV().data;
            DataTable d = new DataTable();
            d.Columns.Add("MaNV", typeof(string));
            d.Columns.Add("TenNV", typeof(string));

            foreach (var i in rss)
            {
                d.Rows.Add(i.MaNV, i.TenNV);
            }
            nhanvien.DataSource = d;
            nhanvien.DisplayMember = "TenNV";
            nhanvien.ValueMember = "MaNV";
            this.nhanvien.DrawMode = DrawMode.OwnerDrawFixed;

            this.nhanvien.DrawItem += delegate (object cmb, DrawItemEventArgs args)
            {
                args.DrawBackground();

                DataRowView drv = (DataRowView)nhanvien.Items[args.Index];

                string MaNV = drv["MaNV"].ToString();
                string TenNV = drv["TenNV"].ToString();


                Rectangle r2 = args.Bounds;
                r2.Width = 200;
                using (SolidBrush sb = new SolidBrush(args.ForeColor))
                {
                    args.Graphics.DrawString(TenNV, args.Font, sb, r2);
                }
                

            };
        }
        private void combo_Khachhang_data()
        {
            var rss = k.Select_all_Khachhang().data;
            DataTable d = new DataTable();
            d.Columns.Add("TenKH", typeof(string));
            d.Columns.Add("Sdt", typeof(string));

            foreach (var i in rss)
            {
                d.Rows.Add(i.TenKH, i.SDT);
            }
            khachhang.DataSource = d;
            khachhang.DisplayMember = "TenKH";
            khachhang.ValueMember = "TenKH";
            this.khachhang.DrawMode = DrawMode.OwnerDrawFixed;

            this.khachhang.DrawItem += delegate (object cmb, DrawItemEventArgs args)
            {
                args.DrawBackground();

                DataRowView drv = (DataRowView)khachhang.Items[args.Index];

                string TenKH = drv["TenKH"].ToString();
                string SDT = drv["Sdt"].ToString();


                Rectangle r2 = args.Bounds;
                r2.Width = 150;
                using (SolidBrush sb = new SolidBrush(args.ForeColor))
                {
                    args.Graphics.DrawString(TenKH, args.Font, sb, r2);
                }
                Rectangle r3 = args.Bounds;
                r3.X = 150;
                r3.Width = 100;
                using (SolidBrush sb = new SolidBrush(args.ForeColor))
                {
                    args.Graphics.DrawString(SDT, args.Font, sb, r3);
                }

            };
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(thang.Text==null || thang.Text == "")
            {
                startday.Enabled = true;
                endday.Enabled = true;
            }
            else
            {
                startday.Enabled = false;
                endday.Enabled = false;
            }
        }
        Thongke_ctrl tk = new Thongke_ctrl();
        private void datagidview()
        {
            var rs = tk.Thongke_all_Doanhthu();
            switch (rs.errCode)
            {
                case Shareds.ErrorCode.Success:
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = rs.data;
                    List<double?> thanhtien = new List<double?>();
                    foreach (var i in rs.data)
                    {
                        thanhtien.Add(i.Tổng_tiền);
                    }
                    tt.Text = thanhtien.Sum().ToString()+"VNĐ";
                    ts.Text = thanhtien.Count().ToString();
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
        Sanpham_ctrl s = new Sanpham_ctrl();
        private void frm_Thongke_Load(object sender, EventArgs e)
        {
            nam.Text = DateTime.Now.Year.ToString();
            datagidview();
            dataGridView2.DataSource = s.Select_all_SPs().data;
           
        }
        private void create_Dtg()
        {
            DataGridViewColumn col0 = new DataGridViewColumn();
            col0.Name = "MaHD";
            col0.HeaderText = "Mã hóa đơn";
            col0.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(col0);
            DataGridViewColumn col1 = new DataGridViewColumn();
            col1.Name = "Ngaylap";
            col1.HeaderText = "Ngày bán";
            col1.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(col1);

            DataGridViewColumn col2 = new DataGridViewColumn();
            col2.Name = "Tenkh";
            col2.HeaderText = "Tên khách hàng";
            col2.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(col2);
            DataGridViewColumn col3 = new DataGridViewColumn();
            col3.Name = "sdt";
            col3.HeaderText = "Số điện thoại";
            col3.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(col3);
            DataGridViewColumn col4 = new DataGridViewColumn();
            col4.Name = "count";
            col4.HeaderText = "Số mặt hàng";
            col4.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(col4);
            DataGridViewColumn col05 = new DataGridViewColumn();
            col05.Name = "tt";
            col05.HeaderText = "Tổng tiền";
            col05.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(col05);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (thang.Text != null && thang.Text != "")
            {
                var rs = tk.Thongke_Doanhthu_Theo_THang(int.Parse(thang.Text), int.Parse(nam.Text), nhanvien.Text, khachhang.Text, Convert.ToDateTime(startday.Value), Convert.ToDateTime(endday.Value));
                switch (rs.errCode)
                {
                    case Shareds.ErrorCode.Success:
                        dataGridView1.Columns.Clear();
                        dataGridView1.DataSource = rs.data;
                        List<double?> thanhtien = new List<double?>();
                        foreach (var i in rs.data)
                        {
                            thanhtien.Add(i.Tổng_tiền);
                        }
                        tt.Text = thanhtien.Sum().ToString()+" VNĐ";
                        ts.Text = thanhtien.Count().ToString();
                        break;
                    case Shareds.ErrorCode.Fail:
                        break;
                    case Shareds.ErrorCode.Exists:
                        break;
                    case Shareds.ErrorCode.NotExists:
                        break;
                    case Shareds.ErrorCode.NoData:
                        //MessageBox.Show("Không có dữ liệu được tìm thấy");
                        dataGridView1.Columns.Clear();
                        create_Dtg();
                        ts.Text = "0";
                        tt.Text = "0";
                        break;
                    case Shareds.ErrorCode.NaN:
                        break;
                    case Shareds.ErrorCode.FormatFail:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Mời bạn chọn tháng!");
                thang.Focus();
            }
            
            
        }

        private void thang_TextChanged(object sender, EventArgs e)
        {
            if (thang.Text == null || thang.Text == "")
            {
                startday.Enabled = true;
                endday.Enabled = true;
            }
            else
            {
                startday.Enabled = false;
                endday.Enabled = false;
            }
        }

        private void phamvi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (phamvi.SelectedIndex == 0)
            {
                lb_nv.Visible = false;
                nhanvien.Visible = false;
                lb_kh.Visible = false;
                khachhang.Visible = false;
            }
            if (phamvi.SelectedIndex ==1)
            {
                lb_nv.Visible = true;
                nhanvien.Visible = true;
                lb_kh.Visible = false;
                khachhang.Visible = false;
            }
            if (phamvi.SelectedIndex == 2)
            {
                lb_kh.Visible = true;
                khachhang.Visible = true;
                lb_nv.Visible = false;
                nhanvien.Visible = false;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}

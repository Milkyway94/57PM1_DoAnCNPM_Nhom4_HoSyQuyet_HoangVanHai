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
    public partial class hoadon : Form
    {
        public hoadon()
        {
            InitializeComponent();
        }
        Khachhang_ctrls k = new Khachhang_ctrls();
        private void hoadon_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLCH_VLNNDataSet.v_Chitiethoadon' table. You can move, or remove it, as needed.
           // this.v_ChitiethoadonTableAdapter.Fill(this.qLCH_VLNNDataSet.v_Chitiethoadon);

            this.reportViewer1.RefreshReport();
            textBox1.Text = Global.d;
            var rs = h.Select_hoadon_by_ID(textBox1.Text);
            switch (rs.errCode)
            {
                case Shareds.ErrorCode.Success:
                    textBox2.Text =k.get_tenkh(rs.data.SingleOrDefault().MaKH).data;
                    textBox3.Text = nv.Select_NV_by_ID(rs.data.SingleOrDefault().MaNV).data.SingleOrDefault().TenNV;
                    var dt1 = ct.Select_CTHD_by_MaHD(textBox1.Text);
                    switch (dt1.errCode)
                    {
                        case Shareds.ErrorCode.Success:
                            dataGridView1.DataSource = dt1.data;
                            List<double> l = new List<double>();
                            foreach (var item in dt1.data)
                            {
                                l.Add(item.Thanhtien);
                            }
                            tt.Text = l.Sum().ToString();
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
        Chitiethoadon_ctrl ct = new Chitiethoadon_ctrl();
        Nhanvien_ctrl nv = new Nhanvien_ctrl();
        Hoadon_ctrl h = new Hoadon_ctrl();
        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}

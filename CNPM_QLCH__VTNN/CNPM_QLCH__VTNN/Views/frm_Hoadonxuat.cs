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
using CNPM_QLCH__VTNN.Database;

namespace CNPM_QLCH__VTNN.Views
{
    public partial class frm_Hoadonxuat : Form
    {
       
        public frm_Hoadonxuat()
        {
            InitializeComponent();
            txt_ngaylap.Format = DateTimePickerFormat.Custom;
            txt_ngaylap.CustomFormat = "dd/MM/yyyy";          
        }
        LoaiSP_ctrl l = new LoaiSP_ctrl();  
        
        
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        
        Hoadon_ctrl hd = new Hoadon_ctrl();
        private string get_makh()
        {
            string makh;
            Random r = new Random();
            makh = "KH" + r.Next(1, 1000000);
           
           var kh = k.Select_Khachhang_by_ID(makh);
            switch (kh.errCode)
            {
                case Shareds.ErrorCode.Success:
                    get_makh();
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


            return makh;
        }
        LoaiSP_ctrl lsp = new LoaiSP_ctrl();
        private void them_HD()
        {
            bool b=true;
            var addHD = hd.Insert_HD(txt_MaHD.Text, k.get_MaKH(txt_kh.Text).data, txt_ngaylap.Value, nv.get_maNV(txt_manv.Text).data);
            switch (addHD.errCode)
            {
                case Shareds.ErrorCode.Success:
                    for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                    {
                        var row = dataGridView1.Rows[i];
                        var addCT = ct.Insert(txt_MaHD.Text, s.Get_MaSP_by_TenSP(row.Cells[0].Value.ToString()).data.ToString(), int.Parse(row.Cells[3].Value.ToString()));
                        switch (addCT.errCode)
                        {
                            case Shareds.ErrorCode.Success:
                                if (int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString()) > s.Get_Soluong_by_TenSP(dataGridView1.CurrentRow.Cells[0].Value.ToString()).data)
                                {
                                    MessageBox.Show("Không đủ hàng, Trong kho chỉ còn " + s.Get_Soluong_by_TenSP(dataGridView1.CurrentRow.Cells[0].Value.ToString()).data + " sản phẩm");
                                    row.Cells[3].Style.BackColor = Color.Red;
                                    b = false;
                                }
                                else
                                {
                                    var updateSL = s.Update(s.Get_MaSP_by_TenSP(row.Cells[0].Value.ToString()).data.ToString(), row.Cells[0].Value.ToString(), lsp.get_maloai_by_tenloai(s.Get_LoaiSP_by_TenSP(row.Cells[0].Value.ToString()).data).data, s.Get_Donvitinh_by_TenSP(row.Cells[0].Value.ToString()).data, 0, 0, Convert.ToInt32(s.Get_Soluong_by_TenSP(row.Cells[0].Value.ToString()).data) - Convert.ToInt32(row.Cells[3].Value.ToString()));
                                    switch (updateSL.errCode)
                                    {
                                        case Shareds.ErrorCode.Success:
                                            break;
                                        case Shareds.ErrorCode.Fail:
                                            MessageBox.Show(updateSL.errInfo);
                                            break;
                                        case Shareds.ErrorCode.Exists:
                                            break;
                                        case Shareds.ErrorCode.NotExists:
                                            MessageBox.Show(updateSL.errInfo);
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
                                
                                break;
                            case Shareds.ErrorCode.Fail:
                                MessageBox.Show(addCT.errInfo);
                                break;
                            case Shareds.ErrorCode.Exists:
                                break;
                            case Shareds.ErrorCode.NotExists:
                                break;
                            case Shareds.ErrorCode.NoData:
                                break;
                            case Shareds.ErrorCode.NaN:
                                MessageBox.Show(addCT.errInfo);
                                b = false;
                                break;
                            case Shareds.ErrorCode.FormatFail:
                                break;
                            default:
                                break;
                        }
                        if (b)
                        {
                            MessageBox.Show("Số tiền cẩn thanh toán: "+txt_tongtien.Text+" đồng");
                            Global.d = txt_MaHD.Text;
                            hoadon h = new hoadon();
                            h.Show();

                        }
                    }
                    
                    
                    break;
                case Shareds.ErrorCode.Fail:
                    MessageBox.Show(addHD.errInfo);
                    break;
                case Shareds.ErrorCode.Exists:
                    break;
                case Shareds.ErrorCode.NotExists:
                    break;
                case Shareds.ErrorCode.NoData:
                    break;
                case Shareds.ErrorCode.NaN:
                    MessageBox.Show(addHD.errInfo);
                    break;
                case Shareds.ErrorCode.FormatFail:
                    break;
                default:
                    break;
            }
            //get_mahd();
            //txt_kh.Text = null;
            //txt_diachi.Text = null;
            //txt_SDT.Text = null;
            //dataGridView1.Rows.Clear();
            //dataGridView1.Refresh();
            //txt_kh.Focus();
            dataGridView2.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                var themkh = k.Insert(get_makh(), txt_kh.Text, txt_diachi.Text, txt_SDT.Text);
                switch (themkh.errCode)
                {
                    case Shareds.ErrorCode.Success:
                        them_HD();
                        break;
                    case Shareds.ErrorCode.Fail:
                        MessageBox.Show(themkh.errInfo);
                        break;
                    case Shareds.ErrorCode.Exists:
                        break;
                    case Shareds.ErrorCode.NotExists:
                        break;
                    case Shareds.ErrorCode.NoData:
                        break;
                    case Shareds.ErrorCode.NaN:
                        MessageBox.Show(themkh.errInfo);
                        txt_kh.Focus();
                        break;
                    case Shareds.ErrorCode.FormatFail:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                them_HD();
            }
            
            
        }

        private void txt_MaHD_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_MaHD_Leave(object sender, EventArgs e)
        {
            
        }
        private void get_mahd()
        {
            Random r = new Random();
            int hd = r.Next(1, 1000000);
            string mahd = "HD" + hd.ToString();
            var i = db.tbl_HOADONs.Where(o => o.MaHD == mahd);
            while (true)
            {
                //txt_MaHD.Text = mahd;
                if (i.Count() == 0)
                {
                    txt_MaHD.Text = mahd;
                    break;                   
                }
            }
        }
        private AutoCompleteStringCollection tensp()
        {
            AutoCompleteStringCollection str = new AutoCompleteStringCollection();
            var data = s.Select_all_SP();
            switch (data.errCode)
            {
                case Shareds.ErrorCode.Success:
                    foreach (var item in data.data)
                    {
                        str.Add(item.TenSP);
                    }
                    break;
                case Shareds.ErrorCode.Fail:
                    MessageBox.Show(data.errInfo);
                    break;
                case Shareds.ErrorCode.NoData:
                    MessageBox.Show(data.errInfo);
                    break;
                default:
                    break;
            }
            return str;
        }
        private void frm_Hoadonxuat_Load(object sender, EventArgs e)
        {
            combo_Nhanvien_data();
            get_mahd();
            style_gridview();

        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            style_gridview();
            
        }
        Sanpham_ctrl s = new Sanpham_ctrl();
     
        private void style_gridview()
        {
            foreach (DataGridViewRow i in dataGridView1.Rows)
            {


                //i.Cells[3].Value = 0;
                i.Cells[01].Style.ForeColor = Color.Black;
                i.Cells[01].Style.BackColor = Color.WhiteSmoke;
                i.Cells[01].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                i.Cells[1].ReadOnly = true;

                i.Cells[2].Style.ForeColor = Color.Black;
                i.Cells[2].Style.BackColor = Color.WhiteSmoke;
                i.Cells[2].ReadOnly = true;
               
                i.Cells[3].Style.ForeColor = Color.Black;
                i.Cells[3].Style.BackColor = Color.WhiteSmoke;
                i.Cells[3].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                i.Cells[0].Style.ForeColor = Color.Black;
                i.Cells[0].Style.BackColor = Color.White;
                i.Cells[0].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                i.Cells[4].Style.ForeColor = Color.Black;
                i.Cells[4].Style.BackColor = Color.WhiteSmoke;
                i.Cells[4].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                i.Cells[4].ReadOnly = true;

                i.Cells[5].Style.ForeColor = Color.Black;
                i.Cells[5].Style.BackColor = Color.WhiteSmoke;
                i.Cells[5].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                i.Cells[5].ReadOnly = true;

            }
            //dataGridView1.Columns[0].Width = 270;
            //dataGridView1.Columns[1].Width = 200;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            get_mahd();
        }
        DataClasses1DataContext db = new DataClasses1DataContext();
        private void txt_MaKH_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_MaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            txt_manv.DataSource = d;
            txt_manv.DisplayMember = "TenNV";
            txt_manv.ValueMember = "MaNV";
            this.txt_manv.DrawMode = DrawMode.OwnerDrawFixed;

            this.txt_manv.DrawItem += delegate (object cmb, DrawItemEventArgs args)
            {
                args.DrawBackground();

                DataRowView drv = (DataRowView)txt_manv.Items[args.Index];

                string MaNV = drv["MaNV"].ToString();
                string TenNV = drv["TenNV"].ToString();
                

                Rectangle r2 = args.Bounds;
                r2.Width = 90;
                using (SolidBrush sb = new SolidBrush(args.ForeColor))
                {
                    args.Graphics.DrawString(MaNV, args.Font, sb, r2);
                }
                Rectangle r3 = args.Bounds;
                r3.X = 90;
                r3.Width = 170;
                using (SolidBrush sb = new SolidBrush(args.ForeColor))
                {
                    args.Graphics.DrawString(TenNV, args.Font, sb, r3);
                }

            };
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }
       
        private void txt_kh_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                var dt = k.Select_Khachhang_by_ID(txt_kh.Text);
                if (txt_kh.Text == null)
                {
                    dataGridView2.Visible = false;
                }
                else
                {
                    switch (dt.errCode)
                    {
                        case Shareds.ErrorCode.Success:
                            dataGridView2.Visible = true;
                            dataGridView2.DataSource = dt.data;
                            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                            break;
                        case Shareds.ErrorCode.Fail:
                            break;
                        case Shareds.ErrorCode.Exists:
                            break;
                        case Shareds.ErrorCode.NotExists:
                            dataGridView2.Visible = false;
                            break;
                        case Shareds.ErrorCode.NoData:
                            dataGridView2.Visible = false;
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

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex !=-1)
            {
                txt_diachi.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                txt_kh.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                txt_SDT.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            
            dataGridView2.Visible = false;
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
           
                this.dataGridView1.CurrentCell.Selected = false;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.dataGridView1.CurrentCell.Selected = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.CurrentCell.Selected = false;
        }

        private void txt_searchcontent_TextChanged(object sender, EventArgs e)
        {
            
        }
        Chitiethoadon_ctrl ct = new Chitiethoadon_ctrl();
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txt_searchcontent_Leave(object sender, EventArgs e)
        {
            //dataGridView3.Visible = false;
        }

        private void dataGridView1_CurrentCellChanged_1(object sender, EventArgs e)
        {
            style_gridview();
        }



        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                var dt = s.Select_all_SP();
                switch (dt.errCode)
                {
                    case Shareds.ErrorCode.Success:
                        foreach (var i in dt.data)
                        {
                            ((ComboBox)e.Control).Items.Add(i.TenSP);
                        }
                        //((ComboBox)e.Control).DataSource = d;
                        //((ComboBox)e.Control).ValueMember = "TenSP";
                        //((ComboBox)e.Control).DisplayMember = "TenSP";
                            
                        break;
                    case Shareds.ErrorCode.Fail:
                        break;
                    case Shareds.ErrorCode.Exists:
                        break;
                    case Shareds.ErrorCode.NotExists:
                        break;
                    case Shareds.ErrorCode.NoData:
                        MessageBox.Show(dt.errInfo);
                        break;
                    case Shareds.ErrorCode.NaN:
                        break;
                    case Shareds.ErrorCode.FormatFail:
                        break;
                    default:
                        break;
                }
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;

                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.CustomSource;
                ((ComboBox)e.Control).AutoCompleteCustomSource = tensp();
                ((ComboBox)e.Control).AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                e.Control.TextChanged += new EventHandler(tensp_textchange);
                cntObj = e.Control;
                cntObj.TextChanged += tensp_textchange;

            }
            else if(e.Control is DataGridViewTextBoxEditingControl)
            {
                e.Control.KeyPress += txt_Soluong_KeyPress;
                e.Control.KeyDown += new KeyEventHandler(checkNumber);
                e.Control.TextChanged += new EventHandler(soluong_textchange);
                cntObj = e.Control;
                cntObj.TextChanged += soluong_textchange;
            }           
        }



        private void txt_Soluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[5].Value== "" || dataGridView1.CurrentRow.Cells[5].Value == null)
            {
                dataGridView1.CurrentRow.Cells[5].Value = "0";
            }
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        void dgvCombo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
            {
                object value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (!((DataGridViewComboBoxColumn)dataGridView1.Columns[e.ColumnIndex]).Items.Contains(value))
                {
                    ((DataGridViewComboBoxColumn)dataGridView1.Columns[e.ColumnIndex]).Items.Add(value);
                    e.ThrowException = false;
                }
            }
        }
        Control cntObj;
        private bool nonNumberEntered = false;
        private void checkNumber(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;

            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.KeyCode != Keys.Back)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        nonNumberEntered = true;
                    }
                }
            }
            //If shift key was pressed, it's not a number.
            if (Control.ModifierKeys == Keys.Shift)
            {
                nonNumberEntered = true;
            }
        }
        private void soluong_textchange(object sender, EventArgs e)
        {
            if (cntObj.Text != string.Empty)
            {                           
                dataGridView1.CurrentRow.Cells[5].Value = double.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString()) * int.Parse(cntObj.Text);
            }
            else
            {
                dataGridView1.CurrentRow.Cells[5].Value = "0";
            }
        }
        private void tensp_textchange(object sender, EventArgs e)
        {
            if (cntObj.Text != string.Empty)
            {
                dataGridView1.CurrentRow.Cells[2].Value = s.Get_GiaSP_by_TenSP(cntObj.Text).data;
                dataGridView1.CurrentRow.Cells[4].Value = s.Get_Donvitinh_by_TenSP(cntObj.Text).data;
                dataGridView1.CurrentRow.Cells[1].Value = s.Get_LoaiSP_by_TenSP(cntObj.Text).data;
            }
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
       
            }
        int check;
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var data_check = dataGridView1.Rows;
                var cur_cell = dataGridView1[e.ColumnIndex, e.RowIndex];
                check = 0;

                //MessageBox.Show(cur_cell.Value.ToString());
                foreach (DataGridViewRow item in data_check)
                {
                    if (item.Cells[0].Value == cur_cell.Value)
                    {
                        check++;
                    }
                }
                if (check>1)
                {
                    MessageBox.Show("Sản phẩm này đã được chọn");
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                    cur_cell.Value = null;

                    //var x = dtgv_sachmuon.CanFocus;
                    //var y = dtgv_sachmuon.CurrentCellAddress;

                    //dtgv_sachmuon.CurrentCell = dtgv_sachmuon.Rows[y.Y].Cells[y.X];
                    //var z = dtgv_sachmuon.SelectedCells;
                    //cur_cell.Selected = true;
                    //dtgv_sachmuon.BeginEdit(true);
                    //return;
                }
            }
            if (e.ColumnIndex == 3)
            {
                txt_tongso.Text = (dataGridView1.Rows.Count - 1).ToString();
                double tong = 0;
                
                for(int i=0; i<dataGridView1.Rows.Count-1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[5].Value!=null)
                        tong += double.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                }
                txt_tongtien.Text = tong.ToString();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    ContextMenuStrip m = new ContextMenuStrip();


                    int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                    if (currentMouseOverRow >= 0)
                    {
                        m.Items.Add("Thêm dòng").Name = "Them";
                        m.Items.Add("Xóa dòng").Name = "Xoa";
                        m.Items.Add("Lưu").Name = "Luu";
                        
                    }

                    m.Show(dataGridView1, new Point(e.X, e.Y));

                    m.ItemClicked += new ToolStripItemClickedEventHandler(menuclick);
                }
            }
            
        }
        void menuclick(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name.ToString())
            {
                case "Luu":
                    var updateCT = ct.Update(txt_MaHD.Text, s.Get_MaSP_by_TenSP(dataGridView1.CurrentRow.Cells[0].Value.ToString()).data, int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString()));
                    switch (updateCT.errCode)
                    {
                        case Shareds.ErrorCode.Success:
                            MessageBox.Show("Sửa thành công");
                            break;
                        case Shareds.ErrorCode.Fail:
                            MessageBox.Show(updateCT.errInfo);
                            break;
                        case Shareds.ErrorCode.Exists:
                            break;
                        case Shareds.ErrorCode.NotExists:
                            MessageBox.Show(updateCT.errInfo);
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
                case "Xoa":
                    foreach (DataGridViewRow item in dataGridView1.Rows)
                    {
                        if(item.Selected)
                        dataGridView1.Rows.Remove(item);
                    }
                    dataGridView1.Refresh();
                    break;
                default:
                    break;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            



        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Main m = new Main();
            this.Close();
            m.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}

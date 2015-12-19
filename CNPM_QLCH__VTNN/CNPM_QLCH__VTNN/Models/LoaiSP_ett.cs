using CNPM_QLCH__VTNN.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNPM_QLCH__VTNN.Models
{
    public class LoaiSP_ett
    {
        public string Maloai { get; set; }
        public string Tenloai { get; set; }
        public string Ghichu { get; set; }
        public LoaiSP_ett(tbl_LOAISANPHAM l)
        {
            Maloai = l.MaloaiSP;
            Tenloai = l.Tenloai;
            Ghichu = l.Ghichu;
        }
        public LoaiSP_ett(string Maloai, string Tenloai, string Ghichu)
        {
            this.Maloai = Maloai;
            this.Tenloai = Tenloai;
            this.Ghichu = Ghichu;
        }
        public LoaiSP_ett() { }

    }
}

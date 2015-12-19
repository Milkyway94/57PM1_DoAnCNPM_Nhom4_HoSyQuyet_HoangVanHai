using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNPM_QLCH__VTNN.Database;
namespace CNPM_QLCH__VTNN.Models
{
    public class Sanpham_ett
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string MaloaiSP { get; set; }
        public string Dvtinh { get; set; }
        public double Gianhap { get; set; }
        public double Giaban { get; set; }
        public int? Soluong { get; set; }
        public Sanpham_ett(tbl_SANPHAM s)
        {
            MaSP = s.MaSP;
            TenSP = s.TenSP;
            MaloaiSP = s.MaloaiSP;
            Dvtinh = s.Donvitinh;
            Giaban = s.GiaSP;
            Gianhap = s.Gianhap;
            Soluong = s.Soluong;    
        }
        public Sanpham_ett(string masp, string tensp, string maloaisp, string dvitinh, double gianhap, double giaban, int soluong)
        {
            MaSP = masp;
            TenSP = tensp;
            MaloaiSP = maloaisp;
            Dvtinh = dvitinh;
            Giaban = giaban;
            Gianhap = gianhap;
            Soluong = soluong;
        }
        public Sanpham_ett()
        {

        }
        public bool Insert()
        {
            bool b;
            tbl_SANPHAM k = new tbl_SANPHAM();
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                k.MaSP = MaSP;
                k.TenSP = TenSP;
                k.MaloaiSP = MaloaiSP;
                k.Gianhap = Gianhap;
                k.GiaSP = Giaban;
                k.Donvitinh = Dvtinh;
                k.Soluong = Soluong;
                db.tbl_SANPHAMs.InsertOnSubmit(k);
                db.SubmitChanges();
                b = true;
            }
            catch (Exception)
            {
                b = false;
            }
            return b;
        }
        public bool update(tbl_SANPHAM k)
        {
            try
            {
                //tbl_KHACHHANG k = new tbl_KHACHHANG();
                DataClasses1DataContext db = new DataClasses1DataContext();
                if (TenSP.ToString() != null || TenSP.ToString() != "")
                {
                    k.TenSP = TenSP;
                    db.SubmitChanges();
                }
                if (MaloaiSP.ToString() != null || MaloaiSP.ToString() != "")
                {
                    k.MaloaiSP = MaloaiSP;
                    db.SubmitChanges();
                }
                if (Gianhap!= 0)
                {
                    k.Gianhap = Gianhap;
                    db.SubmitChanges();
                }
                if (Giaban != 0)
                {
                    k.GiaSP = Giaban;
                    db.SubmitChanges();
                }
                if (Soluong!=0)
                {
                    k.Soluong = Soluong;
                    db.SubmitChanges();
                }
                if (Dvtinh.ToString() != null || Dvtinh.ToString() != "")
                {
                    k.Donvitinh = Dvtinh;
                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                string t = e.ToString();
                return false;
            }
        }
        public bool Delete()
        {
            tbl_SANPHAM k = new tbl_SANPHAM();
            k.MaSP = MaSP;
            k.TenSP = TenSP;
            k.MaloaiSP = MaloaiSP;
            k.GiaSP = Giaban;
            k.Gianhap = Gianhap;
            k.Soluong = Soluong;
            k.Donvitinh = Dvtinh;
            bool b = true;
            DataClasses1DataContext db = new DataClasses1DataContext();
            try
            {
                db.tbl_SANPHAMs.Attach(k);
                db.tbl_SANPHAMs.DeleteOnSubmit(k);
                // db.SubmitChanges();
                b = true;
                //er = null;
            }
            catch (Exception e)
            {
                string er = e.ToString();
                b = false;

            }
            return b;
        }

    }
}

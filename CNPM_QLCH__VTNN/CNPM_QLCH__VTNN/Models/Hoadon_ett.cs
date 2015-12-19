using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNPM_QLCH__VTNN.Database;
namespace CNPM_QLCH__VTNN.Models
{
    public class Hoadon_ett
    {
       public string MaHD { get; set; }
       public string MaKH { get; set; }
       public DateTime Ngaylap { get; set; }
       public string MaNV { get; set; }
       public Hoadon_ett(tbl_HOADON h)
       {
            this.MaHD = h.MaHD;
            this.MaKH = h.MaKH;
            this.Ngaylap = h.Ngaylap;
            this.MaNV = h.MaNV;
        }
       public Hoadon_ett(string mahd, string makh, DateTime ngaylap, string manv)
       {
            this.MaKH = makh;
            this.MaHD = mahd;
            this.Ngaylap = ngaylap;
            this.MaNV = manv;
        }
       public bool Insert(tbl_HOADON h)
       {
            DataClasses1DataContext db = new DataClasses1DataContext();
            bool b=true;
            try
            {
                h.MaHD = MaHD;
                h.MaKH = MaKH;
                h.Ngaylap = Ngaylap;
                h.MaNV = MaNV;
                db.tbl_HOADONs.InsertOnSubmit(h);
                db.SubmitChanges();
                b = true;
            }
            catch (Exception e)
            {
                b = false;
                string er = e.ToString();
            }
            return b;
       }
       public bool Update(tbl_HOADON k)
       {
            try
            {
                //tbl_KHACHHANG k = new tbl_KHACHHANG();
                DataClasses1DataContext db = new DataClasses1DataContext();
                if (MaKH != null && MaKH != "")
                {
                    k.MaKH = MaKH;
                    db.SubmitChanges();
                }
                if (Ngaylap != null)
                {
                    k.Ngaylap = Ngaylap;
                    db.SubmitChanges();
                }
                if(MaNV!=null&&MaNV!="")
                {
                    k.MaNV = MaNV;
                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
       public bool Delete(tbl_HOADON k)
       {
            bool b = true;
            DataClasses1DataContext db = new DataClasses1DataContext();
            try
            {
                    db.tbl_HOADONs.DeleteOnSubmit(k);
                    db.SubmitChanges();
                    b = true;
                //er = null;
            }
            catch (Exception e)
            {
                //er = e.ToString();
                b = false;

            }
            return b;
        }
    }
}

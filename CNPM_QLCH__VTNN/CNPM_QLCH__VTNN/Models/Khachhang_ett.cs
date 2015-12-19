using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNPM_QLCH__VTNN.Database;
using CNPM_QLCH__VTNN.Shareds;

namespace CNPM_QLCH__VTNN.Models
{
    public class Khachhang_ett
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string Diachi { get; set; }
        public string SDT { get; set; }
        public Khachhang_ett(tbl_KHACHHANG k)
        {
            MaKH = k.MaKH;
            TenKH = k.TenKH;
            Diachi = k.Diachi;
            SDT = k.SDT;
        }
        public Khachhang_ett(string MaKH, string TenKH, string Diachi, string SDT)
        {
            this.MaKH = MaKH;
            this.TenKH = TenKH;
            this.Diachi = Diachi;
            this.SDT = SDT;
        }
        public Khachhang_ett() { }
        public bool Insert()
        {
            bool b;
            tbl_KHACHHANG k = new tbl_KHACHHANG();
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                k.MaKH = MaKH;
                k.SDT = SDT;
                k.Diachi = Diachi;
                k.TenKH = TenKH;
                db.tbl_KHACHHANGs.InsertOnSubmit(k);
                db.SubmitChanges();
                b = true;
            }
            catch (Exception)
            {
                b = false;
            }
            return b;
        }
        public bool update(tbl_KHACHHANG k)
        {
            try
            {
                //tbl_KHACHHANG k = new tbl_KHACHHANG();
                DataClasses1DataContext db = new DataClasses1DataContext();
                if (TenKH != null || TenKH != "")
                {
                    k.TenKH = TenKH;
                    db.SubmitChanges();
                }
                if (Diachi != null || Diachi != "")
                {
                    k.Diachi = Diachi;
                    db.SubmitChanges();
                }
                if (SDT != null || SDT != "")
                {
                    k.SDT = SDT;
                    db.SubmitChanges();
                }
                return true;               
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Delete()
        {
            tbl_KHACHHANG k = new tbl_KHACHHANG();
            k.MaKH = MaKH;
            k.Diachi = Diachi;
            k.TenKH = TenKH;
            k.SDT = SDT;
            bool b=true;
            DataClasses1DataContext db = new DataClasses1DataContext();
            try
            {
                    db.tbl_KHACHHANGs.Attach(k);
                    db.tbl_KHACHHANGs.DeleteOnSubmit(k);
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

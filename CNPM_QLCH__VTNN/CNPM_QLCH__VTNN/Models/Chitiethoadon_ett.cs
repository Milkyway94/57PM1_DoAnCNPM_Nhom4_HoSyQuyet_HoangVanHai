using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNPM_QLCH__VTNN.Database;
namespace CNPM_QLCH__VTNN.Models
{
    public class Chitiethoadon_ett
    {
        public string MaHD { get; set; }
        public string MaSP { get; set; }
        public int Soluong { get; set; }        
        public Chitiethoadon_ett(tbl_CHITIETHOADON c)
        {
            MaHD = c.MaHD;
            MaSP = c.MaSP;
            Soluong = c.Soluong;
        }
        public Chitiethoadon_ett(string mahd, string masp, int soluong)
        {
            MaSP = masp;
            MaHD = mahd;
            Soluong = soluong;
        }
        public Chitiethoadon_ett() { }
        public bool Insert(tbl_CHITIETHOADON c)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            try
            {
                c.MaHD = MaHD;
                c.MaSP = MaSP;
                c.Soluong = Soluong;
                db.tbl_CHITIETHOADONs.InsertOnSubmit(c);
                db.SubmitChanges();
                return true;


            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(tbl_CHITIETHOADON k)
        {
            bool b = true;
            DataClasses1DataContext db = new DataClasses1DataContext();
            try
            {
                db.tbl_CHITIETHOADONs.DeleteOnSubmit(k);
                db.SubmitChanges();
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
        public bool update(tbl_CHITIETHOADON k)
        {
            try
            {
                //tbl_KHACHHANG k = new tbl_KHACHHANG();
                DataClasses1DataContext db = new DataClasses1DataContext();
                
                if (Soluong != 0)
                {
                    k.Soluong = Soluong;
                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}

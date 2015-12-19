using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNPM_QLCH__VTNN.Database;
namespace CNPM_QLCH__VTNN.Models
{
    public class Nhanvien_ett
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public DateTime Ngaysinh { get; set; }
        public string Diachi { get; set; }
        public string Quequan { get; set; }
        public string SDT { get; set; }
        public double Luongcb { get; set; }
        public Nhanvien_ett(tbl_NHANVIEN n)
        {
            MaNV = n.MaNV;
            TenNV = n.TenNV;
            Ngaysinh = n.Ngaysinh;
            Diachi = n.Diachi;
            Quequan = n.Quequan;
            SDT = n.SDT;
            Luongcb = n.LuongCB;
        }
        public Nhanvien_ett(string manv, string tennv, DateTime ngaysinh, string diachi, string quequan, string sdt, double luongcb)
        {
            MaNV = manv;
            TenNV = tennv;
            Ngaysinh = ngaysinh;
            Diachi = diachi;
            Quequan = quequan;
            SDT = sdt;
            Luongcb = luongcb;
        }
        public Nhanvien_ett() { }
        public bool Insert(tbl_NHANVIEN n)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            try
            {
                n.MaNV = MaNV;
                n.TenNV = TenNV;
                n.Diachi = Diachi;
                n.Ngaysinh = Ngaysinh;
                n.Quequan = Quequan;
                n.SDT = SDT;
                n.LuongCB = Luongcb;
                db.tbl_NHANVIENs.InsertOnSubmit(n);
                db.SubmitChanges();
                return true;
            }
            catch(Exception e)
            {
                string er = e.ToString();
                return false;
            }
        }
        public bool update(tbl_NHANVIEN k)
        {
            try
            {
                //tbl_KHACHHANG k = new tbl_KHACHHANG();
                DataClasses1DataContext db = new DataClasses1DataContext();
                if (TenNV != null || TenNV != "")
                {
                    k.TenNV = TenNV;
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
                if (Ngaysinh != null )
                {
                    k.Ngaysinh = Ngaysinh;
                    db.SubmitChanges();
                }
                if (Luongcb != 0)
                {
                    k.LuongCB = Luongcb;
                    db.SubmitChanges();
                }
                if (Quequan != null || Quequan != "")
                {
                    k.Quequan = Quequan;
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
            tbl_NHANVIEN k = new tbl_NHANVIEN();
            k.MaNV = MaNV;
            k.TenNV = TenNV;
            k.Diachi = Diachi;
            k.Quequan = Quequan;
            k.SDT = SDT;
            k.Ngaysinh = Ngaysinh;
            k.LuongCB = Luongcb;
            bool b;
            DataClasses1DataContext db = new DataClasses1DataContext();
            try
            {
                db.tbl_NHANVIENs.Attach(k);
                db.tbl_NHANVIENs.DeleteOnSubmit(k);
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
    }
}

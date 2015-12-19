using CNPM_QLCH__VTNN.Models;
using CNPM_QLCH__VTNN.Shareds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNPM_QLCH__VTNN.Database;
using System.Data.Linq.SqlClient;

namespace CNPM_QLCH__VTNN.Controllers
{
    public class Nhanvien_ctrl
    {
        public Results<List<Nhanvien_ett>> Select_all_NV()
        {
            Results<List<Nhanvien_ett>> rs = new Results<List<Nhanvien_ett>>();
            List<Nhanvien_ett> ls = new List<Nhanvien_ett>();
            DataClasses1DataContext db = new DataClasses1DataContext();
            try
            {
                var dt = db.tbl_NHANVIENs;
                if (dt.Count() > 0)
                {
                    foreach (tbl_NHANVIEN i in dt)
                    {
                        Nhanvien_ett k = new Nhanvien_ett(i);
                        ls.Add(k);
                    }
                    rs.data = ls;
                    rs.errCode = ErrorCode.Success;
                    rs.errInfo = ErrorInfo.Sucess;
                }
                else
                {
                    rs.data = null;
                    rs.errInfo = ErrorInfo.NoData;
                    rs.errCode = ErrorCode.NoData;
                }
            }
            catch (Exception)
            {

                rs.data = null;
                rs.errCode = ErrorCode.Fail;
                rs.errInfo = ErrorInfo.Fail;
            }
            return rs;
        }
        public Results<List<Nhanvien_ett>> Select_NV_by_ID(string manv)
        {
            Results<List<Nhanvien_ett>> rs = new Results<List<Nhanvien_ett>>();
            List<Nhanvien_ett> ls = new List<Nhanvien_ett>();
            DataClasses1DataContext db = new DataClasses1DataContext();
            try
            {
                var dt = db.tbl_NHANVIENs.Where(o=>o.MaNV==manv);
                if (dt.Count() > 0)
                {
                    foreach (tbl_NHANVIEN i in dt)
                    {
                        Nhanvien_ett k = new Nhanvien_ett(i);
                        ls.Add(k);
                    }
                    rs.data = ls;
                    rs.errCode = ErrorCode.Success;
                    rs.errInfo = ErrorInfo.Sucess;
                }
                else
                {
                    rs.data = null;
                    rs.errInfo = ErrorInfo.NoData;
                    rs.errCode = ErrorCode.NoData;
                }
            }
            catch (Exception)
            {

                rs.data = null;
                rs.errCode = ErrorCode.Fail;
                rs.errInfo = ErrorInfo.Fail;
            }
            return rs;
        }
        public Results<List<Nhanvien_ett>> Select_Nhanvien_by_Name(string searchcontent)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            Results<List<Nhanvien_ett>> rs = new Results<List<Nhanvien_ett>>();
            List<Nhanvien_ett> ls = new List<Nhanvien_ett>();
            try
            {
                var dt = db.tbl_NHANVIENs.Where(o=>SqlMethods.Like(o.TenNV, searchcontent)||SqlMethods.Like(o.MaNV, searchcontent));
                if (dt.Count() > 0)
                {
                    foreach (tbl_NHANVIEN i in dt)
                    {
                        Nhanvien_ett k = new Nhanvien_ett(i);
                        ls.Add(k);
                    }
                    rs.data = ls;
                    rs.errCode = ErrorCode.Success;
                    rs.errInfo = ErrorInfo.Sucess;
                }
                else
                {
                    rs.data = null;
                    rs.errInfo = ErrorInfo.NoData;
                    rs.errCode = ErrorCode.NoData;
                }
            }
            catch (Exception)
            {

                rs.data = null;
                rs.errCode = ErrorCode.Fail;
                rs.errInfo = ErrorInfo.Fail;
            }
            return rs;
        }
        public Results<bool> Delete(string manv)
        {
            Results<bool> rs = new Results<bool>();
            DataClasses1DataContext db = new DataClasses1DataContext();
            try
            {
                var data = db.tbl_NHANVIENs.Where(o =>o.MaNV==manv);
                if (data.Count() > 0)
                {
                    foreach (tbl_NHANVIEN i in data)
                    {
                        Nhanvien_ett k = new Nhanvien_ett(i);
                        if (k.Delete())
                        {
                            rs.data = true;
                            rs.errCode = ErrorCode.Success;
                            rs.errInfo = ErrorInfo.DeleteSuccess;
                        }
                        else
                        {
                            rs.data = false;
                            rs.errCode = ErrorCode.Fail;
                            rs.errInfo = ErrorInfo.Fail;
                            break;
                        }
                    }
                    db.SubmitChanges();
                }
                else
                {
                    rs.data = false;
                    rs.errCode = ErrorCode.NotExists;
                    rs.errInfo = ErrorInfo.NotExists;
                }
            }
            catch (Exception e)
            {
                rs.data = false;
                rs.errInfo = ErrorInfo.Fail + e.ToString();
                rs.errCode = ErrorCode.Fail;
            }
            return rs;
        }
        public Results<bool> Insert(string manv, string tennv, DateTime ngaysinh, string diachi, string quequan, string sdt, double luongcb)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            Results<bool> rs = new Results<bool>();
            try
            {
                var data = db.tbl_NHANVIENs.Where(o=>o.MaNV==manv);
                if (data.Count() > 0)
                { 
                            rs.errCode = ErrorCode.Exists;
                            rs.errInfo = ErrorInfo.Exists;
                            rs.data = false;
                    throw new Exception("Đã tồn tại");
                        }
                        else
                        {
                            if (manv == null || manv == "")
                            {
                                rs.data = false;
                                rs.errInfo = ErrorInfo.NaN + " [Mã Nhân viên]";
                                rs.errCode = ErrorCode.NaN;
                            }
                            else
                            {
                                if (tennv == null || tennv == "")
                                {
                                    rs.data = false;
                                    rs.errInfo = ErrorInfo.NaN + " [Tên nhân viên]";
                                    rs.errCode = ErrorCode.NaN;
                                    return rs;
                                }
                                else
                                {
                                    if (diachi == null || diachi == "")
                                    {
                                        rs.data = false;
                                        rs.errInfo = ErrorInfo.NaN + " [Địa chỉ]";
                                        rs.errCode = ErrorCode.NaN;
                                        return rs;
                                    }
                                    else 
                                    {
                                        if(quequan == null || quequan == "")
                                        {
                                            rs.data = false;
                                            rs.errInfo = ErrorInfo.NaN + " [Quê Quán]";
                                            rs.errCode = ErrorCode.NaN;
                                            return rs;
                                         }
                                        else
                                        {
                                            if (sdt == null || sdt == "")
                                            {
                                                rs.data = false;
                                                rs.errInfo = ErrorInfo.NaN + " [Số điện thoại]";
                                                rs.errCode = ErrorCode.NaN;
                                                return rs;
                                            }
                                            else
                                            {
                                                Nhanvien_ett k = new Nhanvien_ett(manv, tennv, ngaysinh, diachi, quequan,sdt, luongcb);
                                                tbl_NHANVIEN t = new tbl_NHANVIEN();
                                                rs.data = k.Insert(t);
                                                rs.errCode = ErrorCode.Success;
                                                rs.errInfo = ErrorInfo.InsertSuccess;
                                            }
                                        }
                                        
                                    }
                                }
                            }
                        }
                    

                


            }
            catch (Exception)
            {
                rs.data = false;
                rs.errCode = ErrorCode.Fail;
                rs.errInfo = ErrorInfo.Fail;
            }
            db.SubmitChanges();
            return rs;

        }
        public Results<string> get_maNV(string tennv)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            Results<string> rs = new Results<string>();
            try
            {
                var dt = db.tbl_NHANVIENs.Where(o => o.TenNV == tennv);
                if (dt.Count() > 0)
                {
                    var dt1 = dt.SingleOrDefault();
                    rs.data = dt1.MaNV;
                    rs.errCode = ErrorCode.Success;
                    rs.errInfo = ErrorInfo.Sucess;
                }
                else
                {
                    rs.data = null;
                    rs.errInfo = ErrorInfo.NotExists;
                    rs.errCode = ErrorCode.NotExists;
                }
            }
            catch (Exception)
            {

                rs.errCode = ErrorCode.Fail;
                rs.data = null;
                rs.errInfo = ErrorInfo.Fail;
            }
            return rs;
            
        }
        public Results<bool> Update(string manv, string tennv, DateTime ngaysinh, string diachi, string quequan, string sdt, double luongcb)
        {
            Results<bool> rs = new Results<bool>();
            DataClasses1DataContext db = new DataClasses1DataContext();
            try
            {
                var data = db.tbl_NHANVIENs.Where(o => o.MaNV == manv);
                if (data.Count() > 0)
                {
                    foreach (tbl_NHANVIEN i in data)
                    {
                        Nhanvien_ett k = new Nhanvien_ett(manv, tennv, ngaysinh, diachi, quequan, sdt, luongcb);
                        rs.data = k.update(i);
                        rs.errCode = ErrorCode.Success;
                        rs.errInfo = ErrorInfo.UpdateSuccess;
                        db.SubmitChanges();
                    }

                }

                else
                {
                    rs.data = false;
                    rs.errInfo = ErrorInfo.NotExists;
                    rs.errCode = ErrorCode.NotExists;
                }
            }
            catch (Exception)
            {

                rs.data = false;
                rs.errCode = ErrorCode.Fail;
                rs.errInfo = ErrorInfo.Fail;
            }
            return rs;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNPM_QLCH__VTNN.Database;
using CNPM_QLCH__VTNN.Shareds;
using CNPM_QLCH__VTNN.Models;
using System.Data.Linq.SqlClient;

namespace CNPM_QLCH__VTNN.Controllers
{
    class Khachhang_ctrls
    {
        public Results<bool> Delete(string makh)
        {
            Results<bool> rs = new Results<bool>();
            DataClasses1DataContext db = new DataClasses1DataContext();
            try
            {
                var dtKH = db.tbl_KHACHHANGs.Where(o => o.MaKH == makh);
                if (dtKH.Count() > 0)
                {
                    tbl_KHACHHANG i= dtKH.SingleOrDefault();                    
                    var data = db.tbl_HOADONs.Where(o => o.MaKH == i.MaKH);
                    if (data.Count() > 0)
                    {
                        tbl_HOADON j = data.SingleOrDefault();
                        var dataCT = db.tbl_CHITIETHOADONs.Where(o => o.MaHD == j.MaHD);
                        if (dataCT.Count() > 0)
                        {

                            tbl_CHITIETHOADON ct = dataCT.SingleOrDefault();                                      
                            db.tbl_CHITIETHOADONs.DeleteOnSubmit(ct);
                                    
                        }
                    db.tbl_HOADONs.DeleteOnSubmit(j);
                    }                       
                    db.tbl_KHACHHANGs.DeleteOnSubmit(i);
                    rs.data = true;
                    rs.errInfo = ErrorInfo.DeleteSuccess;
                    rs.errCode = ErrorCode.Success;
                }                                                  
                else
                {
                    rs.data = false;
                    rs.errCode = ErrorCode.NotExists;
                    rs.errInfo = ErrorInfo.NotExists;
                }
            }
            catch (Exception ex)
            {

                rs.data = false;
                rs.errCode = ErrorCode.Fail;
                rs.errInfo = ErrorInfo.Fail+ex.ToString();
            }
            db.SubmitChanges();
            return rs;
        }
        public Results<bool> Update(string makh, string tenkh, string diachi, string sdt)
        {
            Results<bool> rs = new Results<bool>();
            DataClasses1DataContext db = new DataClasses1DataContext();
            try
            {
                var data = db.tbl_KHACHHANGs.Where(o => o.MaKH == makh);
                if (data.Count() > 0)
                {
                    foreach (tbl_KHACHHANG i in data)
                    {
                        Khachhang_ett k = new Khachhang_ett(makh, tenkh, diachi, sdt);
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
        public Results<List<Khachhang_ett>> Select_Khachhang_by_ID(string searchcontent)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            Results<List<Khachhang_ett>> rs = new Results<List<Khachhang_ett>>();
            List<Khachhang_ett> ls = new List<Khachhang_ett>();
            try
            {
                var dt = db.tbl_KHACHHANGs.Where(o=>o.MaKH.Contains(searchcontent)||o.TenKH.Contains(searchcontent));
                if (dt.Count() > 0)
                {
                    foreach (tbl_KHACHHANG i in dt)
                    {
                        Khachhang_ett k = new Khachhang_ett(i);
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
        public Results<List<Khachhang_ett>> Select_all_Khachhang()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            Results<List<Khachhang_ett>> rs = new Results<List<Khachhang_ett>>();
            List<Khachhang_ett> ls = new List<Khachhang_ett>();
            try
            {
                var dt = db.tbl_KHACHHANGs;
                if (dt.Count() > 0)
                {
                    foreach (tbl_KHACHHANG i in dt)
                    {
                        Khachhang_ett k = new Khachhang_ett(i);
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
        public Results<bool> Insert(string MaKH, string TenKH, string Diachi, string SDT)
        {

            DataClasses1DataContext db = new DataClasses1DataContext();
            Results<bool> rs = new Results<bool>();
            try
            {
                var data = db.tbl_KHACHHANGs;
                if (data.Count() > 0)
                {
                    foreach (var i in data)
                    {
                        if (MaKH == i.MaKH)
                        {
                            rs.errCode = ErrorCode.Exists;
                            rs.errInfo = ErrorInfo.Exists;
                            rs.data = false;
                            break;
                        }
                        else
                        {
                            if (MaKH == null || MaKH == "")
                            {
                                rs.data = false;
                                rs.errInfo = ErrorInfo.NaN + " [Mã khách hàng]";
                                rs.errCode = ErrorCode.NaN;
                            }
                            else
                            {
                                if (TenKH == null || TenKH == "")
                                {
                                    rs.data = false;
                                    rs.errInfo = ErrorInfo.NaN + " [Tên khách hàng]";
                                    rs.errCode = ErrorCode.NaN;
                                    return rs;
                                }
                                else
                                {
                                    if (Diachi == null || Diachi == "")
                                    {
                                        rs.data = false;
                                        rs.errInfo = ErrorInfo.NaN + " [Địa chỉ]";
                                        rs.errCode = ErrorCode.NaN;
                                        return rs;
                                    }
                                    else
                                    {
                                        if (SDT == null || SDT == "")
                                        {
                                            rs.data = false;
                                            rs.errInfo = ErrorInfo.NaN + " [Số điện thoại]";
                                            rs.errCode = ErrorCode.NaN;
                                            return rs;
                                        }
                                        else
                                        {
                                            Khachhang_ett k = new Khachhang_ett(MaKH, TenKH, Diachi, SDT);
                                            rs.data = k.Insert();
                                            rs.errCode = ErrorCode.Success;
                                            rs.errInfo = ErrorInfo.InsertSuccess;
                                        }
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
        public Results<string> get_DC(string MaKH)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            Results<string> rs = new Results<string>();
            var data = db.tbl_KHACHHANGs.Where(o => o.TenKH == MaKH);
            try
            {
                if (data.Count() > 0)
                {
                    var dl = data.SingleOrDefault();
                    rs.data = dl.Diachi;
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
            catch (Exception e)
            {

                rs.data = null;
                rs.errCode = ErrorCode.Fail;
                rs.errInfo = ErrorInfo.Fail + e.ToString();
            }
            return rs;
        }
        public Results<string> get_Sdt(string tenkh)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            Results<string> rs = new Results<string>();
            var data = db.tbl_KHACHHANGs.Where(o => o.TenKH == tenkh);
            try
            {
                if (data.Count() > 0)
                {
                    var dl = data.SingleOrDefault();
                    rs.data = dl.SDT;
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
            catch (Exception e)
            {

                rs.data = null;
                rs.errCode = ErrorCode.Fail;
                rs.errInfo = ErrorInfo.Fail + e.ToString();
            }
            return rs;
        }
        public Results<string> get_MaKH(string tenkh)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            Results<string> rs = new Results<string>();
            var data = db.tbl_KHACHHANGs.Where(o => o.TenKH == tenkh);
            try
            {
                if (data.Count() > 0)
                {
                    var dl = data.SingleOrDefault();
                    rs.data = dl.MaKH;
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
            catch (Exception e)
            {

                rs.data = null;
                rs.errCode = ErrorCode.Fail;
                rs.errInfo = ErrorInfo.Fail + e.ToString();
            }
            return rs;
        }
        public Results<string> get_tenkh(string makh)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            Results<string> rs = new Results<string>();
            var data = db.tbl_KHACHHANGs.Where(o => o.MaKH == makh);
            try
            {
                if (data.Count() > 0)
                {
                    var dl = data.SingleOrDefault();
                    rs.data = dl.TenKH;
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
            catch (Exception e)
            {

                rs.data = null;
                rs.errCode = ErrorCode.Fail;
                rs.errInfo = ErrorInfo.Fail + e.ToString();
            }
            return rs;
        }

    }

}


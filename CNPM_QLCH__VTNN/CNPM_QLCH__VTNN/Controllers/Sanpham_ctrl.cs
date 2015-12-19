using CNPM_QLCH__VTNN.Models;
using CNPM_QLCH__VTNN.Shareds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNPM_QLCH__VTNN.Database;
namespace CNPM_QLCH__VTNN.Controllers
{
    public class Sanpham_ctrl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public Results<List<Sanpham_ett>> Select_all_SP()
        {
            Results<List<Sanpham_ett>> rs = new Results<List<Sanpham_ett>>();
            List<Sanpham_ett> ls = new List<Sanpham_ett>();
            try
            {
               
                var dt = db.tbl_SANPHAMs;
                if (dt.Count() > 0)
                {
                    foreach (tbl_SANPHAM i in dt)
                    {
                        Sanpham_ett s = new Sanpham_ett(i);
                        ls.Add(s);
                    }
                    rs.data = ls;
                    rs.errCode = ErrorCode.Success;
                    rs.errInfo = ErrorInfo.Sucess;
                }
                else
                {
                    rs.errInfo = ErrorInfo.NoData;
                    rs.errCode = ErrorCode.NoData;
                    rs.data = null;
                }
            }
            catch (Exception e)
            {
                rs.data = null;
                rs.errCode = ErrorCode.Fail;
                rs.errInfo = ErrorInfo.Fail;
                
            }
            return rs;
        }
        public Results<List<Sanpham_ett>> Select_all_SPs()
        {
            Results<List<Sanpham_ett>> rs = new Results<List<Sanpham_ett>>();
            List<Sanpham_ett> ls = new List<Sanpham_ett>();
            try
            {

                var dt = db.tbl_SANPHAMs.Where(o=>o.Soluong>0);
                if (dt.Count() > 0)
                {
                    foreach (tbl_SANPHAM i in dt)
                    {
                        Sanpham_ett s = new Sanpham_ett(i);
                        ls.Add(s);
                    }
                    rs.data = ls;
                    rs.errCode = ErrorCode.Success;
                    rs.errInfo = ErrorInfo.Sucess;
                }
                else
                {
                    rs.errInfo = ErrorInfo.NoData;
                    rs.errCode = ErrorCode.NoData;
                    rs.data = null;
                }
            }
            catch (Exception e)
            {
                rs.data = null;
                rs.errCode = ErrorCode.Fail;
                rs.errInfo = ErrorInfo.Fail;

            }
            return rs;
        }
        public Results<List<string>> Select_TenSP_by_Loaisp(string tenloai)
        {
            Results<List<string>> rs = new Results<List<string>>();
            List<string> ls = new List<string>();
            DataClasses1DataContext db = new DataClasses1DataContext();
            try
            {
                var data = db.v_loaisps.Where(o => o.Tenloai == tenloai);
                if (data.Count() > 0)
                {
                    foreach (v_loaisp i in data)
                    {
                        ls.Add(i.TenSP);
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
        public Results<double> Get_GiaSP_by_TenSP(string tensp)
        {
            Results<double> rs = new Results<double>();
            try
            {
                var dt = db.tbl_SANPHAMs.Where(o => o.TenSP == tensp);
                if (dt.Count() > 0)
                {
                    rs.data = dt.SingleOrDefault().GiaSP;
                    rs.errCode = ErrorCode.Success;
                    rs.errInfo = ErrorInfo.Sucess;
                }
                else
                {
                    rs.data = 0;
                    rs.errInfo = ErrorInfo.NotExists;
                    rs.errCode = ErrorCode.NotExists;
                }
            }
            catch (Exception e)
            {

                rs.errCode = ErrorCode.Fail;
                rs.errInfo = ErrorInfo.Fail;
                rs.data = 0;
                string err = e.ToString();
            }
            return rs;   
        }
        public Results<string> Get_Donvitinh_by_TenSP(string ten)
        {
            Results<string> rs = new Results<string>();
            try
            {
                var dt = db.tbl_SANPHAMs.Where(o => o.TenSP == ten);
                if (dt.Count() > 0)
                {
                    rs.data = dt.SingleOrDefault().Donvitinh;
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
            catch (Exception e)
            {

                rs.errCode = ErrorCode.Fail;
                rs.errInfo = ErrorInfo.Fail;
                rs.data = null;
                string err = e.ToString();
            }
            return rs;
        }
        public Results<string> Get_LoaiSP_by_TenSP(string ten)
        {
            Results<string> rs = new Results<string>();
            try
            {
                var dt = db.tbl_SANPHAMs.Where(o => o.TenSP == ten);
                if (dt.Count() > 0)
                {
                        var dt1 = db.tbl_LOAISANPHAMs.Where(o => o.MaloaiSP == dt.SingleOrDefault().MaloaiSP);
                        if (dt1.Count()>0)
                        {
                            rs.data = dt1.SingleOrDefault().Tenloai;
                            rs.errCode = ErrorCode.Success;
                            rs.errInfo = ErrorInfo.Sucess;
                        }
    
                }
                else
                {
                    rs.data = null;
                    rs.errInfo = ErrorInfo.NotExists;
                    rs.errCode = ErrorCode.NotExists;
                }
            }
            catch (Exception e)
            {

                rs.errCode = ErrorCode.Fail;
                rs.errInfo = ErrorInfo.Fail;
                rs.data = null;
                string err = e.ToString();
            }
            return rs;
        }
        public Results<string> Get_MaSP_by_TenSP(string tensp)
        {
            Results<string> rs = new Results<string>();
            try
            {
                var dt = db.tbl_SANPHAMs.Where(o => o.TenSP==tensp);
                if (dt.Count() > 0)
                {
                        rs.data = dt.SingleOrDefault().MaSP;
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
            catch (Exception e)
            {

                rs.errCode = ErrorCode.Fail;
                rs.errInfo = ErrorInfo.Fail;
                rs.data = null;
                string err = e.ToString();
            }
            return rs;
        }
        public Results<int?> Get_Soluong_by_TenSP(string tensp)
        {
            Results<int?> rs = new Results<int?>();
            try
            {
                var dt = db.tbl_SANPHAMs.Where(o => o.TenSP == tensp);
                if (dt.Count() > 0)
                {
                    rs.data = dt.SingleOrDefault().Soluong;
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
            catch (Exception e)
            {

                rs.errCode = ErrorCode.Fail;
                rs.errInfo = ErrorInfo.Fail;
                rs.data = null;
                string err = e.ToString();
            }
            return rs;
        }
        public Results<bool> Update(string MaSP, string TenSP, string Maloai, string donvi, double Gianhap, double Giaban, int soluong )
        {
            Results<bool> rs = new Results<bool>();
            DataClasses1DataContext db = new DataClasses1DataContext();
            try
            {
                var data = db.tbl_SANPHAMs.Where(o => o.MaSP == MaSP);
                if (data.Count() > 0)
                {
                    foreach (tbl_SANPHAM i in data)
                    {
                        Sanpham_ett k = new Sanpham_ett(MaSP, TenSP, Maloai, donvi, Gianhap, Giaban, soluong);
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
        public Results<bool> Insert(string MaSP, string TenSP, string Maloai, string donvi, double Gianhap, double Giaban, int soluong)
        {

            DataClasses1DataContext db = new DataClasses1DataContext();
            Results<bool> rs = new Results<bool>();
            try
            {
                var data = db.tbl_SANPHAMs;
                if (data.Count() > 0)
                {
                    foreach (var i in data)
                    {
                        if (MaSP == i.MaSP)
                        {
                            rs.errCode = ErrorCode.Exists;
                            rs.errInfo = ErrorInfo.Exists;
                            rs.data = false;
                            break;
                        }
                        else
                        {
                            if (TenSP == null || TenSP == "")
                            {
                                rs.data = false;
                                rs.errInfo = ErrorInfo.NaN + " [Tên sản phẩm]";
                                rs.errCode = ErrorCode.NaN;
                            }
                            else
                            {
                                if (Maloai == null || Maloai == "")
                                {
                                    rs.data = false;
                                    rs.errInfo = ErrorInfo.NaN + " [Mã loại sp]";
                                    rs.errCode = ErrorCode.NaN;
                                    return rs;
                                }
                                else
                                {
                                    if (Giaban.ToString() == null || Giaban.ToString() == "")
                                    {
                                        rs.data = false;
                                        rs.errInfo = ErrorInfo.NaN + " [Giá Sản phẩm]";
                                        rs.errCode = ErrorCode.NaN;
                                        return rs;
                                    }
                                    else
                                    {
                                        if (Gianhap.ToString() == null || Gianhap.ToString() == "")
                                        {
                                            rs.data = false;
                                            rs.errInfo = ErrorInfo.NaN + " [Giá nhập]";
                                            rs.errCode = ErrorCode.NaN;
                                            return rs;
                                        }
                                        else
                                            if (donvi.ToString() == null || donvi.ToString() == "")
                                        {
                                            rs.data = false;
                                            rs.errInfo = ErrorInfo.NaN + " [Đơn vị]";
                                            rs.errCode = ErrorCode.NaN;
                                            return rs;
                                        }
                                        else
                                            if (soluong.ToString() == null || soluong.ToString() == "")
                                        {
                                            rs.data = false;
                                            rs.errInfo = ErrorInfo.NaN + " [Số lượng]";
                                            rs.errCode = ErrorCode.NaN;
                                            return rs;
                                        }
                                        else
                                        {
                                            Sanpham_ett k = new Sanpham_ett(MaSP, TenSP, Maloai, donvi, Gianhap, Giaban, soluong);
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
            catch (Exception e)
            {
                rs.data = false;
                rs.errCode = ErrorCode.Fail;
                rs.errInfo = ErrorInfo.Fail+e.ToString();
            }
            db.SubmitChanges();
            return rs;
        }
    }
}

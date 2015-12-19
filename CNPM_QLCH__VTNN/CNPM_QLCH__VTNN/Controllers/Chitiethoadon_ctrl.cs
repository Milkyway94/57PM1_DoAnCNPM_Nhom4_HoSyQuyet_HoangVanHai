using CNPM_QLCH__VTNN.Database;
using CNPM_QLCH__VTNN.Models;
using CNPM_QLCH__VTNN.Shareds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNPM_QLCH__VTNN.Controllers
{
    public class Chitiethoadon_ctrl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public Results<List<v_Chitiethoadon>> Select_CTHD_by_MaHD(string mahd)
        {
            Results<List<v_Chitiethoadon>> rs = new Results<List<v_Chitiethoadon>>();
            List<v_Chitiethoadon> ls = new List<v_Chitiethoadon>();
            DataClasses1DataContext db = new DataClasses1DataContext();
            try
            {
                var data = db.v_Chitiethoadons.Where(o => o.MaHD == mahd);
                if (data.Count() > 0)
                {
                    foreach (v_Chitiethoadon i in data)
                    {
                        ls.Add(i);
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
        public Results<bool> Update(string MaHD, string MaSP, int soluong)
        {
            Results<bool> rs = new Results<bool>();
            DataClasses1DataContext db = new DataClasses1DataContext();
            try
            {
                var data = db.tbl_CHITIETHOADONs.Where(o => o.MaHD == MaHD);
                if (data.Count() > 0)
                {
                    foreach (tbl_CHITIETHOADON i in data)
                    {
                        Chitiethoadon_ett k = new Chitiethoadon_ett(MaHD,MaSP,soluong);
                        
                        if (k.update(i))
                        {
                            rs.data = k.update(i);
                            rs.errCode = ErrorCode.Success;
                            rs.errInfo = ErrorInfo.UpdateSuccess;
                            db.SubmitChanges();
                        }
                        
                    }

                }

                else
                {
                    rs.data = false;
                    rs.errInfo = ErrorInfo.NotExists;
                    rs.errCode = ErrorCode.NotExists;
                }
            }
            catch (Exception e)
            {

                rs.data = false;
                rs.errCode = ErrorCode.Fail;
                rs.errInfo = ErrorInfo.Fail+e.ToString();
            }
            return rs;
        }
        public Results<bool> Insert(string MaHD, string MaSP, int soluong)
        {

            DataClasses1DataContext db = new DataClasses1DataContext();
            Results<bool> rs = new Results<bool>();
            try
            {
                var data = db.tbl_CHITIETHOADONs;
                if (data.Count() > 0)
                {
                    foreach (var i in data)
                    {
                        if (MaHD == i.MaHD&&MaSP==i.MaSP)
                        {
                            rs.errCode = ErrorCode.Exists;
                            rs.errInfo = ErrorInfo.Exists;
                            rs.data = false;
                            break;
                        }
                        else
                        {
                            if (MaSP == null || MaSP == "")
                            {
                                rs.data = false;
                                rs.errInfo = ErrorInfo.NaN + " [Mã sản phẩm]";
                                rs.errCode = ErrorCode.NaN;
                            }
                            else
                            {
                                if (soluong.ToString() == "")
                                {
                                    rs.data = false;
                                    rs.errInfo = ErrorInfo.NaN + " [Soluong]";
                                    rs.errCode = ErrorCode.NaN;
                                    return rs;
                                }
                                else
                                {
                                              
                                    Chitiethoadon_ett k = new Chitiethoadon_ett(MaHD, MaSP, soluong);
                                    tbl_CHITIETHOADON c = new tbl_CHITIETHOADON();
                                    c.MaSP = k.MaSP;
                                    c.MaHD = k.MaHD;
                                    c.Soluong = k.Soluong;
                                    rs.data = k.Insert(c);
                                    rs.errCode = ErrorCode.Success;
                                    rs.errInfo = ErrorInfo.InsertSuccess;
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
        public Results<bool> Delete(string MaHD, string MaSP)
        {
            Results<bool> rs = new Results<bool>();
            try
            {
                var dt = db.tbl_CHITIETHOADONs.Where(o => o.MaHD == MaHD && o.MaSP == MaSP);
                if (dt.Count() > 0)
                {
                    tbl_CHITIETHOADON del = dt.SingleOrDefault();
                    db.tbl_CHITIETHOADONs.DeleteOnSubmit(del);
                    db.SubmitChanges();
                    rs.errCode = ErrorCode.Success;
                    rs.errInfo = ErrorInfo.DeleteSuccess;
                    rs.data = false;
                }
                else
                {
                    rs.data = false;
                    rs.errInfo = ErrorInfo.NotExists;
                    rs.errCode = ErrorCode.NotExists;
                }
            }
            catch (Exception ex)
            {

                rs.data = false;
                rs.errCode = ErrorCode.Fail;
                rs.errInfo = ErrorInfo.Fail+ex.ToString();
            }
            
            return rs;
        }
    }
}

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
    class Hoadon_ctrl
    {
        public Results<List<v_tbl_HOADON>> Select_all_hoadon()
        {
            Results<List<v_tbl_HOADON>> rs = new Results<List<v_tbl_HOADON>>();
            List<v_tbl_HOADON> ls = new List<v_tbl_HOADON>();
            DataClasses1DataContext db = new DataClasses1DataContext();
            try
            {
                var data = db.v_tbl_HOADONs;
                if (data.Count() > 0)
                {
                    foreach (v_tbl_HOADON i in data)
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
        public Results<List<v_tbl_HOADON>> Search_HD(string searchcontent, int nd)
        // 1:Mã hóa đơn
        //2: Mã khách hàng
        //3: Tên khách hàng
        //4: Ngày lập
        //5: Cái gì cũng được

        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            Results<List<v_tbl_HOADON>> rs = new Results<List<v_tbl_HOADON>>();
            List<v_tbl_HOADON> ls = new List<v_tbl_HOADON>();
            switch (nd)
            {
                case 1:
                    try
                    {
                        var dt = db.v_tbl_HOADONs.Where(o => o.MaHD.Contains(searchcontent));
                        if (dt.Count() > 0)
                        {
                            foreach (v_tbl_HOADON i in dt)
                            {
                                
                                ls.Add(i);
                            }
                            rs.data = ls;
                            rs.errCode = ErrorCode.Success;
                            rs.errInfo = ErrorInfo.Sucess;
                        }
                        else
                        {
                            rs.errCode = ErrorCode.NoData;
                            rs.errInfo = ErrorInfo.NoData;
                            rs.data = null;
                        }
                    }
                    catch (Exception e)
                    {
                        rs.data = null;
                        rs.errInfo = ErrorInfo.Fail + e.ToString();
                        rs.errCode = ErrorCode.Fail;

                    }

                    break;
                case 2:
                    try
                    {
                        var dt = db.v_tbl_HOADONs.Where(o => o.MaKH.Contains(searchcontent));
                        if (dt.Count() > 0)
                        {
                            foreach (v_tbl_HOADON i in dt)
                            {
                               
                                ls.Add(i);
                            }
                            rs.data = ls;
                            rs.errCode = ErrorCode.Success;
                            rs.errInfo = ErrorInfo.Sucess;
                        }
                        else
                        {
                            rs.errInfo = ErrorInfo.NoData;
                            rs.data = null;
                            rs.errCode = ErrorCode.NoData;
                        }
                    }
                    catch (Exception e)
                    {
                        rs.data = null;
                        rs.errInfo = ErrorInfo.Fail + e.ToString();
                        rs.errCode = ErrorCode.Fail;

                    }
                    break;
                case 3:
                    try
                    {
                        
                                var dt = db.v_tbl_HOADONs.Where(o => o.TenKH.Contains(searchcontent));
                                if (dt.Count() > 0)
                                {
                                    foreach (v_tbl_HOADON j in dt)
                                    {
                                       
                                        ls.Add(j);
                                    }
                                    rs.data = ls;
                                    rs.errCode = ErrorCode.Success;
                                    rs.errInfo = ErrorInfo.Sucess;
                                }
                         
                        else
                        {
                            rs.errCode = ErrorCode.NoData;
                            rs.errInfo = ErrorInfo.NoData;
                            rs.data = null;
                        }

                    }
                    catch (Exception e)
                    {
                        rs.data = null;
                        rs.errInfo = ErrorInfo.Fail + e.ToString();
                        rs.errCode = ErrorCode.Fail;

                    }
                    break;
                case 4:
                    try
                    {
                        var dt = db.v_tbl_HOADONs.Where(o => o.Ngaylap.ToString().Contains(searchcontent));
                        if (dt.Count() > 0)
                        {
                            foreach (v_tbl_HOADON i in dt)
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
                            rs.errCode = ErrorCode.NoData;
                            rs.errInfo = ErrorInfo.NoData;
                        }
                    }
                    catch (Exception e)
                    {
                        rs.data = null;
                        rs.errInfo = ErrorInfo.Fail + e.ToString();
                        rs.errCode = ErrorCode.Fail;

                    }
                    break;
                default:
                    break;
            }
            return rs;
        }
        public Results<List<Hoadon_ett>> Search_Hoadon(string searchcontent, int nd)
            // 1:Mã hóa đơn
            //2: Mã khách hàng
            //3: Tên khách hàng
            //4: Ngày lập
            //5: Cái gì cũng được

        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            Results<List<Hoadon_ett>> rs = new Results<List<Hoadon_ett>>();
            List<Hoadon_ett> ls = new List<Hoadon_ett>();
            switch (nd)
            {
                case 1:
                    try
                    {
                        var dt = db.tbl_HOADONs.Where(o => o.MaHD.Contains(searchcontent));
                        if (dt.Count() > 0)
                        {
                            foreach (tbl_HOADON i in dt)
                            {
                                Hoadon_ett p = new Hoadon_ett(i);
                                ls.Add(p);
                            }
                            rs.data = ls;
                            rs.errCode = ErrorCode.Success;
                            rs.errInfo = ErrorInfo.Sucess;
                        }
                        else
                        {
                            rs.errCode = ErrorCode.NoData;
                            rs.errInfo = ErrorInfo.NoData;
                            rs.data = null;
                        }
                    }
                    catch (Exception e)
                    {
                        rs.data = null;
                        rs.errInfo = ErrorInfo.Fail + e.ToString();
                        rs.errCode = ErrorCode.Fail;

                    }

                    break;
                case 2:
                    try
                    {
                        var dt = db.tbl_HOADONs.Where(o => o.MaKH.Contains(searchcontent));
                        if (dt.Count() > 0)
                        {
                            foreach (tbl_HOADON i in dt)
                            {
                                Hoadon_ett p = new Hoadon_ett(i);
                                ls.Add(p);
                            }
                            rs.data = ls;
                            rs.errCode = ErrorCode.Success;
                            rs.errInfo = ErrorInfo.Sucess;
                        }
                        else
                        {
                            rs.errInfo = ErrorInfo.NoData;
                            rs.data = null;
                            rs.errCode = ErrorCode.NoData;
                        }
                    }
                    catch (Exception e)
                    {
                        rs.data = null;
                        rs.errInfo = ErrorInfo.Fail + e.ToString();
                        rs.errCode = ErrorCode.Fail;

                    }
                    break;
                case 3:
                    try
                    {
                        var dtkh = db.tbl_KHACHHANGs.Where(o =>o.TenKH.Contains(searchcontent));
                        if (dtkh.Count() > 0)
                        {
                            foreach (var i in dtkh)
                            {
                                var dt = db.tbl_HOADONs.Where(o => o.MaKH == i.MaKH);
                                if (dt.Count() > 0)
                                {
                                    foreach (tbl_HOADON j in dt)
                                    {
                                        Hoadon_ett p = new Hoadon_ett(j);
                                        ls.Add(p);
                                    }
                                    rs.data = ls;
                                    rs.errCode = ErrorCode.Success;
                                    rs.errInfo = ErrorInfo.Sucess;
                                }
                            }
                        }
                        else
                        {
                            rs.errCode = ErrorCode.NoData;
                            rs.errInfo = ErrorInfo.NoData;
                            rs.data = null;
                        }
                        
                    }
                    catch (Exception e)
                    {
                        rs.data = null;
                        rs.errInfo = ErrorInfo.Fail + e.ToString();
                        rs.errCode = ErrorCode.Fail;

                    }
                    break;
                case 4:
                    try
                    {
                        var dt = db.tbl_HOADONs.Where(o => o.Ngaylap.ToString().Contains(searchcontent));
                        if (dt.Count() > 0)
                        {
                            foreach (tbl_HOADON i in dt)
                            {
                                Hoadon_ett p = new Hoadon_ett(i);
                                ls.Add(p);
                            }
                            rs.data = ls;
                            rs.errCode = ErrorCode.Success;
                            rs.errInfo = ErrorInfo.Sucess;
                        }
                        else
                        {
                            rs.data = null;
                            rs.errCode = ErrorCode.NoData;
                            rs.errInfo = ErrorInfo.NoData;
                        }
                    }
                    catch (Exception e)
                    {
                        rs.data = null;
                        rs.errInfo = ErrorInfo.Fail + e.ToString();
                        rs.errCode = ErrorCode.Fail;

                    }
                    break;
                default:
                    break;
            }
            return rs;
        }
        public Results<List<Hoadon_ett>> Select_hoadon_by_ID(string mahd)
        {
            Results<List<Hoadon_ett>> rs = new Results<List<Hoadon_ett>>();
            List<Hoadon_ett> ls = new List<Hoadon_ett>();
            DataClasses1DataContext db = new DataClasses1DataContext();
            try
            {
                var data = db.tbl_HOADONs.Where(o=>o.MaHD==mahd);
                if (data.Count() > 0)
                {
                    foreach (tbl_HOADON i in data)
                    {
                        Hoadon_ett h = new Hoadon_ett(i);
                        ls.Add(h);
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
        public Results<bool> Insert_HD(string MaHD, string MaKH, DateTime Ngaylap, string MaNV)
        {
            Results<bool> rs = new Results<bool>();
            DataClasses1DataContext db = new DataClasses1DataContext();
            try
            {
                var data = db.tbl_HOADONs.Where(o => o.MaHD == MaHD);
                if (data.Count() > 0)
                {
                    rs.data = false;
                    rs.errInfo = MaHD + " " + ErrorInfo.Exists;
                    rs.errCode = ErrorCode.Exists;
                }
                else
                {
                    tbl_HOADON k = new tbl_HOADON();
                    k.MaHD = MaHD;
                    k.MaKH = MaKH;
                    k.Ngaylap = Ngaylap;
                    k.MaNV = MaNV;
                    Hoadon_ett h = new Hoadon_ett(k);
                    if (h.Insert(k))
                    {
                        rs.data = true;
                        rs.errCode = ErrorCode.Success;
                        rs.errInfo = ErrorInfo.InsertSuccess + "(" + MaHD + "," + MaKH + ")";
                    }
                    else
                    {
                        rs.errCode = ErrorCode.Fail;
                        rs.errInfo = ErrorInfo.Fail;
                    }
                }
            }
            catch (Exception e)
            {

                rs.errInfo = ErrorInfo.Fail + e.ToString();
                rs.errCode = ErrorCode.Fail;
                rs.data = false;
            }
            
            return rs;
        }
        public Results<bool> Update(string mahd, string makh, DateTime ngaylap)
        {
            Results<bool> rs = new Results<bool>();
            DataClasses1DataContext db = new DataClasses1DataContext();
            try
            {
                var data = db.tbl_HOADONs.Where(o => o.MaHD == mahd);
                if (data.Count() > 0)
                {
                    foreach (var i in data)
                    {
                        if (makh != null || makh != "")
                        {
                            tbl_HOADON h = new tbl_HOADON();
                            h = i;
                            h.MaKH = makh;
                            db.SubmitChanges();
                            rs.data = true;
                            rs.errCode = ErrorCode.Success;
                            rs.errInfo = ErrorInfo.UpdateSuccess + "(" + makh + ")";
                        }
                        if (ngaylap != null)
                        {
                            tbl_HOADON h = new tbl_HOADON();
                            h = i;
                            h.Ngaylap = ngaylap;
                            db.SubmitChanges();
                            rs.data = true;
                            rs.errCode = ErrorCode.Success;
                            rs.errInfo = ErrorInfo.UpdateSuccess + "(" + ngaylap + ")";
                        }
                    }

                }
                else
                {
                    rs.data = false;
                    rs.errInfo = mahd + " " + ErrorInfo.NotExists;
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
        public Results<bool> Delete_HD(string mahd)
        {
            Results<bool> rs = new Results<bool>();
            DataClasses1DataContext db = new DataClasses1DataContext();
            try
            {
                var data = db.tbl_HOADONs.Where(o => o.MaHD == mahd);
                if (data.Count() > 0)
                {
                    foreach (tbl_HOADON i in data)
                    {
                        Hoadon_ett k = new Hoadon_ett(i);
                        if (k.Delete(i))
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
    }
}

using CNPM_QLCH__VTNN.Database;
using CNPM_QLCH__VTNN.Shareds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNPM_QLCH__VTNN.Controllers
{
    public class LoaiSP_ctrl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public Results<List<tbl_LOAISANPHAM>> Select_all_LoaiSP()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            Results<List<tbl_LOAISANPHAM>> rs = new Results<List<tbl_LOAISANPHAM>>();
            List<tbl_LOAISANPHAM> ls = new List<tbl_LOAISANPHAM>();
            try
            {
                var dt = db.tbl_LOAISANPHAMs;
                if (dt.Count() > 0)
                {
                    foreach (tbl_LOAISANPHAM i in dt)
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
        public Results<string> get_maloai_by_tenloai(string tenlsp)
        {
            Results<string> rs = new Results<string>();
            try
            {
                var dt = db.tbl_LOAISANPHAMs.Where(o => o.Tenloai == tenlsp);
                if (dt.Count() > 0)
                {
                    rs.data = dt.SingleOrDefault().MaloaiSP;
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
    }
}

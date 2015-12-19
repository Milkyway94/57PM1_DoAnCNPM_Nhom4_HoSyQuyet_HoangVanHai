using CNPM_QLCH__VTNN.Database;
using CNPM_QLCH__VTNN.Shareds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNPM_QLCH__VTNN.Controllers
{
    public class Thongke_ctrl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public Results<List<v_Thongkedoanhthu>> Thongke_all_Doanhthu()
        {
            Results<List<v_Thongkedoanhthu>> rs = new Results<List<v_Thongkedoanhthu>>();
            List<v_Thongkedoanhthu> ls = new List<v_Thongkedoanhthu>();
            try
            {
                var dt = db.v_Thongkedoanhthus;
                if (dt.Count() > 0)
                {
                    foreach (v_Thongkedoanhthu i in dt)
                    {
                        ls.Add(i);
                    }
                    rs.errCode = ErrorCode.Success;
                    rs.errInfo = ErrorInfo.Sucess;
                    rs.data = ls;
                }
                else
                {
                    rs.data = null;
                    rs.errInfo = ErrorInfo.NoData;
                    rs.errCode = ErrorCode.NoData;
                }
            }
            catch (Exception ex)
            {

                rs.data=null;
                rs.errCode = ErrorCode.Fail;
                rs.errInfo = ErrorInfo.Fail + ex.ToString();
            }
            return rs;
        }
        public Results<List<v_Thongkedoanhthu>> Thongke_Doanhthu_Theo_THang(int thang, int nam, string tennv, string tenkh, DateTime startday, DateTime endday)
        {
            Results<List<v_Thongkedoanhthu>> rs = new Results<List<v_Thongkedoanhthu>>();
            List<v_Thongkedoanhthu> ls = new List<v_Thongkedoanhthu>();
            try
            {       
                    
                var dt = db.v_Thongkedoanhthus.Where(o => o.Ngày_bán.Month == thang && o.Ngày_bán.Year == nam);
                if (dt.Count() > 0)
                {
                    foreach (v_Thongkedoanhthu i in dt)
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
            catch (Exception ex)
            {

                rs.data = null;
                rs.errCode = ErrorCode.Fail;
                rs.errInfo = ErrorInfo.Fail + ex.ToString();
            }
            return rs;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNPM_QLCH__VTNN.Shareds
{
    public class Results<T>
    {
        public T data { get; set; }
        public ErrorCode errCode { get; set; }
        public string errInfo { get; set; }

    }
}

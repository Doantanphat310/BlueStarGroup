using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCommon.Models
{
    public class ReportInfo
    {
        public string ReportName { get; set; }

        public string ReportID { get; set; }

        public int PageStart { get; set; }

        public int PageEnd { get; set; }
    }
}

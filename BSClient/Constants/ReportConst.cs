using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSClient.Constants
{
    public class ReportConst
    {
        public const string RPT000001 = "RPT000001";
        public const string RPT000002 = "RPT000002";

        public Dictionary<string, string> ReportFile = new Dictionary<string, string>
        {
            { "RPT000001", "BangCanDoiSoPhatSinhTaiKhoan.repx"},
            { "RPT000002", "SoCaiChiTiet.repx"}
        };
    }
}

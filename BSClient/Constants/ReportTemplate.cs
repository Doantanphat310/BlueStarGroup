using System.Collections.Generic;

namespace BSClient.Constants
{
    public static class ReportTemplate
    {
        /// <summary>
        /// BangCanDoiSoPhatSinhTaiKhoan
        /// </summary>
        public const string RPT000001 = "ID_RPT000001";

        /// <summary>
        /// SoCaiChiTiet
        /// </summary>
        public const string RPT000002 = "ID_RPT000002";

        private static readonly Dictionary<string, string> ReportTempalteDictionary = new Dictionary<string, string>
        {
            { "ID_RPT000001", "BangCanDoiSoPhatSinhTaiKhoan"},
            { "ID_RPT000002", "SoCaiChiTiet"}
        };

        public static string GetTemplate(string reportID)
        {
            return ReportTempalteDictionary[reportID];
        }
    }
}

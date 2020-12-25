using System.Collections.Generic;

namespace BSClient.Constants
{
    public static class ReportTemplate
    {
        /// <summary>
        /// BangCanDoiSoPhatSinhTaiKhoan
        /// </summary>
        public const string RPT000001 = "RPT000001";

        /// <summary>
        /// SoCaiChiTiet
        /// </summary>
        public const string RPT000002 = "RPT000002";

        private static readonly Dictionary<string, string> ReportTempalteDictionary = new Dictionary<string, string>
        {
            { "RPT000001", "BangCanDoiSoPhatSinhTaiKhoan.repx"},
            { "RPT000002", "SoCaiChiTiet.repx"}
        };

        public static string GetTemplate(string reportID)
        {
            return ReportTempalteDictionary[reportID];
        }
    }
}

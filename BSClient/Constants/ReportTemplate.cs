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

        /// <summary>
        /// Báo Cáo Kế Toán Toàn Tập
        /// </summary>
        public const string RPT000003 = "ID_RPT000003";

        /// <summary>
        /// Sổ đăng kí chứng từ ghi sổ
        /// </summary>
        public const string RPT000004 = "ID_RPT000004";

        /// <summary>
        /// Chứng từ ghi sổ
        /// </summary>
        public const string RPT000005 = "ID_RPT000005";

        private static readonly Dictionary<string, string> TempalteDictionary = new Dictionary<string, string>
        {
            { "ID_RPT000001", "BangCanDoiSoPhatSinhTaiKhoan"},
            { "ID_RPT000002", "SoCaiChiTiet"},
            { "ID_RPT000003", "BaoCaoKeToanToanTap"},
            { "ID_RPT000004", "SoDangKiChungTuGhiSo"},
            { "ID_RPT000005", "ChungTuGhiSo"},
            { "ID_RPT000006", "BaoCaoKeToanToanTap"},
            { "ID_RPT000007", "BaoCaoKeToanToanTap"},
            { "ID_RPT000008", "BaoCaoKeToanToanTap"},
            { "ID_RPT000009", "BaoCaoKeToanToanTap"},
            { "ID_RPT000010", "BaoCaoKeToanToanTap"},
            { "ID_RPT000011", "BaoCaoKeToanToanTap"},
            { "ID_RPT000012", "BaoCaoKeToanToanTap"},
            { "ID_RPT000013", "BaoCaoKeToanToanTap"},
            { "ID_RPT000014", "BaoCaoKeToanToanTap"},
            { "ID_RPT000015", "BaoCaoKeToanToanTap"}
        };

        public static string GetTemplate(string reportID)
        {
            return TempalteDictionary[reportID];
        }
    }
}

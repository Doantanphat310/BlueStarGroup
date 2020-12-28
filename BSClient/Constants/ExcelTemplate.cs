using System.Collections.Generic;

namespace BSClient.Constants
{
    public static class ExcelTemplate
    {
        /// <summary>
        /// Khách Hàng
        /// </summary>
        public const string EXL000001 = "ID_EXL000001";

        /// <summary>
        /// Sản phẩm
        /// </summary>
        public const string EXL000002 = "ID_EXL000002";

        private static readonly Dictionary<string, string> TempalteDictionary = new Dictionary<string, string>
        {
            { "ID_EXL000001", "KhachHang"},
            { "ID_EXL000002", "SanPham"}
        };

        public static string GetTemplate(string tempalteID)
        {
            return TempalteDictionary[tempalteID];
        }
    }
}

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

        /// <summary>
        /// Loại Sản phẩm
        /// </summary>
        public const string EXL000003 = "ID_EXL000003";

        /// <summary>
        /// Đơn vị tính
        /// </summary>
        public const string EXL000004 = "ID_EXL000004";

        /// <summary>
        /// Hóa đơn S35
        /// </summary>
        public const string EXL000005 = "ID_EXL000005";


        private static readonly Dictionary<string, string> TempalteDictionary = new Dictionary<string, string>
        {
            { "ID_EXL000001", "KhachHang"},
            { "ID_EXL000002", "SanPham"},
            { "ID_EXL000003", "LoaiSanPham"},
            { "ID_EXL000004", "DVT"},
            { "ID_EXL000005", "S35"},
        };

        public static string GetTemplate(string tempalteID)
        {
            return TempalteDictionary[tempalteID];
        }
    }
}

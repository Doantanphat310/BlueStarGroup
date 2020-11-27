using BSServer._Core.Const;
using System;

namespace BSServer._Core.Utility
{
    public static class GenerateID
    {
        public static string CustomerID(long seq)
        {
            return GetGeneralID(BSServerConst.CustomerSymbol, seq);
        }

        public static string ItemID(long seq)
        {
            return GetGeneralID(BSServerConst.ItemSymbol, seq);
        }

        public static string CompanyID(long seq)
        {
            return GetGeneralID(BSServerConst.CompanySymbol, seq);
        }

        public static string GetVoucherID(long seq)
        {
            return GetGeneralIDWithDate(BSServerConst.VoucherSymbol, seq);
        }

        public static string VoucherDetailID(long seq)
        {
            return GetGeneralIDWithDate(BSServerConst.VoucherDetailSymbol, seq);
        }

        public static string InvoiceID(long seq)
        {
            return GetGeneralIDWithDate(BSServerConst.InvoiceSymbol, seq);
        }

        public static string ItemTypeID(long seq)
        {
            return GetGeneralID(BSServerConst.ItemTypeSymbol, seq);
        }

        private static string GetGeneralID(string type, long seq)
        {
            return $"{type}{seq.ToString("0000000000")}";
        }

        private static string GetGeneralIDWithDate(string type, long seq)
        {
            return $"{type}{DateTime.Now.ToString("yyyyMMdd")}{seq.ToString("000000")}";
        }

        public static string WareHouseID(long seq)
        {
            return GetGeneralIDWithDate(BSServerConst.WareHouseSymbol, seq);
        }
        public static string WareHouseDetailID(long seq)
        {
            return GetGeneralIDWithDate(BSServerConst.WareHouseDetailSymbol, seq);
        }
        public static string DepreciationID(long seq)
        {
            return GetGeneralIDWithDate(BSServerConst.DepreciationSymbol, seq);
        }

        public static string DepreciationDetailID(long seq)
        {
            return GetGeneralIDWithDate(BSServerConst.DepreciationDetailSymbol, seq);
        }
    }
}

using System;

namespace BSCommon.Models
{
    public class SoDangKyChungTuGhiSo
    {
        public string VouchersTypeID { get; set; }
        public string VouchersTypeName { get; set; }
        public long VoucherNo { get; set; }
        public DateTime VoucherDate { get; set; }
        public string VoucherDescription { get; set; }
        public decimal VoucherAmount { get; set; }
    }
}

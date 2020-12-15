using System;

namespace BSCommon.Models
{
    /// <summary>
    /// GetChiTietTaiKhoan infomation
    /// </summary>        
    public class GetChiTietTaiKhoan
    {
        /// <summary>
        /// AccountID
        /// </summary>
        public string AccountID { get; set; }

        /// <summary>
        /// VoucherDate
        /// </summary>
        public DateTime VoucherDate { get; set; }

        /// <summary>
        /// VouchersTypeID
        /// </summary>
        public string VouchersTypeID { get; set; }

        /// <summary>
        /// VoucherNo
        /// </summary>
        public long VoucherNo { get; set; }

        /// <summary>
        /// VoucherDescription
        /// </summary>
        public string VoucherDescription { get; set; }

        /// <summary>
        /// DebitAmount
        /// </summary>
        public decimal DebitAmount { get; set; }

        /// <summary>
        /// CreditAmount
        /// </summary>
        public decimal CreditAmount { get; set; }
    }
}

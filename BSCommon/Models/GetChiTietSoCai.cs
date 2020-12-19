using System;

namespace BSCommon.Models
{
    /// <summary>
    /// GetChiTietSoCai infomation
    /// </summary>        
    public class GetChiTietSoCai
    {
        /// <summary>
        /// AccountID
        /// </summary>
        public string AccountID { get; set; }

        /// <summary>
        /// AccountDetailID
        /// </summary>
        public string AccountDetailID { get; set; }

        /// <summary>
        /// AccountName
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// VoucherDate
        /// </summary>
        public DateTime VoucherDate { get; set; }

        /// <summary>
        /// VouchersID
        /// </summary>
        public string VouchersID { get; set; }

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
        /// CorrespondingAccountID
        /// </summary>
        public string CorrespondingAccountID { get; set; }

        /// <summary>
        /// CorrespondingAccountDetailID
        /// </summary>
        public string CorrespondingAccountDetailID { get; set; }

        /// <summary>
        /// DebitAmount
        /// </summary>
        public decimal DebitAmount { get; set; }

        /// <summary>
        /// CreditAmount
        /// </summary>
        public decimal CreditAmount { get; set; }

        /// <summary>
        /// DKNo
        /// </summary>
        public decimal DKNo { get; set; }

        /// <summary>
        /// DKCo
        /// </summary>
        public decimal DKCo { get; set; }


        /// <summary>
        /// PSNo
        /// </summary>
        public decimal PSNo { get; set; }

        /// <summary>
        /// PSCo
        /// </summary>
        public decimal PSCo { get; set; }

        /// <summary>
        /// CKNo
        /// </summary>
        public decimal CKNo { get; set; }

        /// <summary>
        /// CKCo
        /// </summary>
        public decimal CKCo { get; set; }
    }
}

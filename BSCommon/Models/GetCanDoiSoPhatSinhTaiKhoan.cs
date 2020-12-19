using System;

namespace BSCommon.Models
{
    /// <summary>
    /// BangCanDoiSoPhatSinhTK infomation
    /// </summary>        
    public class GetCanDoiSoPhatSinhTaiKhoan
    {
        /// <summary>
        /// AccountID
        /// </summary>
        public string AccountID { get; set; }

        /// <summary>
        /// AccountName
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// AccountDetailID
        /// </summary>
        public string AccountDetailID { get; set; }

        /// <summary>
        /// CustomerID
        /// </summary>
        public string CustomerID { get; set; }

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

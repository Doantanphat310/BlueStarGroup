using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSCommon.Models
{
    /// <summary>
    /// Accounts infomation
    /// </summary>        
    public class BangCanDoiSoPhatSinhTK : BaseModel
    {
        /// <summary>
        /// AccountID
        /// </summary>
        public string AccountID { get; set; }

        /// <summary>
        /// ThongKe
        /// </summary>
        public string ThongKe { get; set; }

        /// <summary>
        /// AccountName
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// AccountGroupID
        /// </summary>
        public DateTime NgayPS { get; set; }

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

using System;

namespace BSCommon.Models
{
    /// <summary>
    /// Accounts infomation
    /// </summary>        
    public class GetBalance
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
        /// BalanceDate
        /// </summary>
        public DateTime BalanceDate { get; set; }

        /// <summary>
        /// DebitBalance
        /// </summary>
        public decimal DebitBalance { get; set; }

        /// <summary>
        /// CreditBalance
        /// </summary>
        public decimal CreditBalance { get; set; }
    }
}

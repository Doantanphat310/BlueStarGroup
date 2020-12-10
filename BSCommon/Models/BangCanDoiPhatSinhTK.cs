using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSCommon.Models
{
    /// <summary>
    /// Accounts infomation
    /// </summary>        
    public class BangCanDoiPhatSinhTK : BaseModel
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
        /// AccountGroupID
        /// </summary>
        public string AccountGroupID { get; set; }
    }
}

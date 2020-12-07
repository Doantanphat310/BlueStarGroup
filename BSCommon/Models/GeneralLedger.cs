using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSCommon.Models
{
    /// <summary>
    /// GeneralLedger infomation
    /// </summary>        
    [Table("GeneralLedger")]
    public class GeneralLedger : BaseModel
    {
        /// <summary>
        /// GeneralLedgerID
        /// </summary>
        [Key]
        [Column("GeneralLedgerID", Order = 1)]
        public string GeneralLedgerID { get; set; }

        /// <summary>
        /// GeneralLedgerName
        /// </summary>
        [Column("GeneralLedgerName")]
        public string GeneralLedgerName { get; set; }

        /// <summary>
        /// AccountID
        /// </summary>
        [Column("AccountID")]
        public string AccountID { get; set; }

        /// <summary>
        /// CompanyID
        /// </summary>
        [Column("CompanyID")]
        public string CompanyID { get; set; }

        /// <summary>
        /// ParentID
        /// </summary>
        [Column("ParentID")]
        public string ParentID { get; set; }

        /// <summary>
        /// IsDelete
        /// </summary>
        [Column("IsDelete")]
        public bool? IsDelete { get; set; }
    }
}

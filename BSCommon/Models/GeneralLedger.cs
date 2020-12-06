using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSCommon.Models
{
    /// <summary>
    /// Item infomation
    /// </summary>
    [Table("GeneralLedger")]
    public class GeneralLedger : BaseModel
    {
        [Key]
        public string GeneralLedgerID { get; set; }
        public string GeneralLedgerName { get; set; }
        public string AccountID { get; set; }
        public string CompanyID { get; set; }
        public string ParentID { get; set; }
        public bool? IsDelete { get; set; }
    }
}

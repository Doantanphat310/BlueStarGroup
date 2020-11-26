using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSCommon.Models
{
    /// <summary>
    /// Item infomation
    /// </summary>        
    [Table("Accounts")]
    public class Accounts : BaseModel
    {
        [Key]
        public string AccountID { get; set; }
        public string AccountName { get; set; }
        public string AccountGroupID { get; set; }
        public byte AccountLevel { get; set; }
        public string ParentID { get; set; }
    }
}

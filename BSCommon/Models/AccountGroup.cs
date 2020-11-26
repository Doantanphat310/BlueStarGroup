using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSCommon.Models
{
    /// <summary>
    /// AccountGroup infomation
    /// </summary>        
    [Table("AccountGroup")]
    public class AccountGroup : BaseModel
    {
        [Key]
        public string AccountGroupID { get; set; }
        public string AccountGroupName { get; set; }
    }
}

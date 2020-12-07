using System;
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
        /// <summary>
        /// AccountGroupID
        /// </summary>
        [Key]
        [Column("AccountGroupID", Order = 1)]
        public string AccountGroupID { get; set; }

        /// <summary>
        /// AccountGroupName
        /// </summary>
        [Column("AccountGroupName")]
        public string AccountGroupName { get; set; }
    }
}

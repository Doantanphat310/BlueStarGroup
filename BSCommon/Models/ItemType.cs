using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSCommon.Models
{
    /// <summary>
    /// ItemType infomation
    /// </summary>        
    [Table("ItemType")]
    public class ItemType : BaseModel
    {
        /// <summary>
        /// ItemTypeID
        /// </summary>
        [Key]
        [Column("ItemTypeID", Order = 1)]
        public string ItemTypeID { get; set; }

        /// <summary>
        /// ItemTypeName
        /// </summary>
        [Column("ItemTypeName")]
        public string ItemTypeName { get; set; }

        /// <summary>
        /// ItemTypeSName
        /// </summary>
        [Column("ItemTypeSName")]
        public string ItemTypeSName { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSCommon.Models
{
    /// <summary>
    /// Items infomation
    /// </summary>        
    [Table("Items")]
    public class Items : BaseModel
    {
        /// <summary>
        /// ItemID
        /// </summary>
        [Key]
        [Column("ItemID", Order = 1)]
        public string ItemID { get; set; }

        /// <summary>
        /// ItemName
        /// </summary>
        [Column("ItemName")]
        public string ItemName { get; set; }

        /// <summary>
        /// ItemSName
        /// </summary>
        [Column("ItemSName")]
        public string ItemSName { get; set; }

        /// <summary>
        /// ItemTypeID
        /// </summary>
        [Column("ItemTypeID")]
        public string ItemTypeID { get; set; }

        /// <summary>
        /// ItemUnit
        /// </summary>
        [Column("ItemUnit")]
        public string ItemUnit { get; set; }

        /// <summary>
        /// ItemSpecification
        /// </summary>
        [Column("ItemSpecification")]
        public string ItemSpecification { get; set; }

        /// <summary>
        /// CreateDate
        /// </summary>
        [Column("CreateDate")]
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// UpdateDate
        /// </summary>
        [Column("UpdateDate")]
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// CreateUser
        /// </summary>
        [Column("CreateUser")]
        public string CreateUser { get; set; }

        /// <summary>
        /// UpdateUser
        /// </summary>
        [Column("UpdateUser")]
        public string UpdateUser { get; set; }

        /// <summary>
        /// IsDelete
        /// </summary>
        [Column("IsDelete")]
        public bool? IsDelete { get; set; }
    }
}

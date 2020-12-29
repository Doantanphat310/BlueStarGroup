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
        /// ItemUnitID
        /// </summary>
        [Column("ItemUnitID")]
        public string ItemUnitID { get; set; }

        /// <summary>
        /// ItemSpecification
        /// </summary>
        [Column("ItemSpecification")]
        public string ItemSpecification { get; set; }

        /// <summary>
        /// ItemPrice
        /// </summary>
        [Column("ItemPrice")]
        public decimal? ItemPrice { get; set; }

        /// <summary>
        /// CompanyID
        /// </summary>
        [Column("CompanyID")]
        public string CompanyID { get; set; }

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
    }
}

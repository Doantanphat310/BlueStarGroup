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
        /// CompanyID
        /// </summary>
        [Column("CompanyID")]
        public string CompanyID { get; set; }
    }
}

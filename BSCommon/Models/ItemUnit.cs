using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSCommon.Models
{
    /// <summary>
    /// ItemUnit infomation
    /// </summary>        
    [Table("ItemUnit")]
    public class ItemUnit : BaseModel
    {
        /// <summary>
        /// ItemUnitID
        /// </summary>
        [Key]
        [Column("ItemUnitID", Order = 1)]
        public string ItemUnitID { get; set; }

        /// <summary>
        /// ItemUnitName
        /// </summary>
        [Column("ItemUnitName")]
        public string ItemUnitName { get; set; }

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

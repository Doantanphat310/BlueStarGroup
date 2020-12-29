using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSCommon.Models
{
    /// <summary>
    /// ItemPriceCompany infomation
    /// </summary>        
    [Table("ItemPriceCompany")]
    public class ItemPriceCompany : BaseModel
    {
        /// <summary>
        /// ItemID
        /// </summary>
        [Key]
        [Column("ItemID", Order = 1)]
        public string ItemID { get; set; }

        /// <summary>
        /// CompanyID
        /// </summary>
        [Key]
        [Column("CompanyID", Order = 2)]
        public string CompanyID { get; set; }

        /// <summary>
        /// ItemPrice
        /// </summary>
        [Column("ItemPrice")]
        public decimal? ItemPrice { get; set; }

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

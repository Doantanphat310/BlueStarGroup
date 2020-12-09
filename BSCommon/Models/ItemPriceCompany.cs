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
        public string ItemID { get; set; }

        /// <summary>
        /// CompanyID
        /// </summary>
        public string CompanyID { get; set; }

        /// <summary>
        /// ItemPrice
        /// </summary>
        public decimal? ItemPrice { get; set; }

        /// <summary>
        /// ItemName
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// CompanyName
        /// </summary>
        public string CompanyName { get; set; }
    }
}

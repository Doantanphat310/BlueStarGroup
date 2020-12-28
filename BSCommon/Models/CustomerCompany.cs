using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSCommon.Models
{
    /// <summary>
    /// CustomerCompany infomation
    /// </summary>        
    [Table("CustomerCompany")]
    public class CustomerCompany : BaseModel
    {
        /// <summary>
        /// CompanyID
        /// </summary>
        [Key]
        [Column("CompanyID", Order = 1)]
        public string CompanyID { get; set; }

        /// <summary>
        /// CustomerID
        /// </summary>
        [Key]
        [Column("CustomerID", Order = 2)]
        public string CustomerID { get; set; }

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

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSCommon.Models
{
    /// <summary>
    /// AccountDetail infomation
    /// </summary>        
    [Table("AccountDetail")]
    public class AccountDetail : BaseModel
    {
        /// <summary>
        /// CompanyID
        /// </summary>
        [Key]
        [Column("CompanyID", Order = 1)]
        public string CompanyID { get; set; }

        /// <summary>
        /// AccountID
        /// </summary>
        [Key]
        [Column("AccountID", Order = 2)]
        public string AccountID { get; set; }

        /// <summary>
        /// AccountDetailID
        /// </summary>
        [Key]
        [Column("AccountDetailID", Order = 3)]
        public string AccountDetailID { get; set; }

        /// <summary>
        /// AccountDetailName
        /// </summary>
        [Column("AccountDetailName")]
        public string AccountDetailName { get; set; }

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

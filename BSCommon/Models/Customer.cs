using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSCommon.Models
{
    /// <summary>
    /// Customer infomation
    /// </summary>        
    [Table("Customer")]
    public class Customer : BaseModel
    {
        /// <summary>
        /// CustomerID
        /// </summary>
        [Key]
        [Column("CustomerID", Order = 1)]
        public string CustomerID { get; set; }

        /// <summary>
        /// CustomerName
        /// </summary>
        [Column("CustomerName")]
        public string CustomerName { get; set; }

        /// <summary>
        /// CustomerSName
        /// </summary>
        [Column("CustomerSName")]
        public string CustomerSName { get; set; }

        /// <summary>
        /// CustomerTIN
        /// </summary>
        [Column("CustomerTIN")]
        public string CustomerTIN { get; set; }

        /// <summary>
        /// CustomerAddress
        /// </summary>
        [Column("CustomerAddress")]
        public string CustomerAddress { get; set; }

        /// <summary>
        /// CustomerPhone
        /// </summary>
        [Column("CustomerPhone")]
        public string CustomerPhone { get; set; }

        /// <summary>
        /// ParentID
        /// </summary>
        [Column("ParentID")]
        public string ParentID { get; set; }

        /// <summary>
        /// InvoiceFormNo
        /// </summary>
        [Column("InvoiceFormNo")]
        public string InvoiceFormNo { get; set; }

        /// <summary>
        /// FormNo
        /// </summary>
        [Column("FormNo")]
        public string FormNo { get; set; }

        /// <summary>
        /// SerialNo
        /// </summary>
        [Column("SerialNo")]
        public string SerialNo { get; set; }

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

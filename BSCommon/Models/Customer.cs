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
        /// Address
        /// </summary>
        [Column("Address")]
        public string Address { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        [Column("Phone")]
        public string Phone { get; set; }

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
        /// IsDelete
        /// </summary>
        [Column("IsDelete")]
        public bool? IsDelete { get; set; }
    }
}

using BSCommon.Constant;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSCommon.Models
{
    /// <summary>
    /// Customer infomation
    /// </summary>        
    public class Customer : BaseModel
    {
        [Key]
        [Column(Order = 1)]
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSName { get; set; }
        public string ParentID { get; set; }
        public string InvoiceFormNo { get; set; }
        public string FormNo { get; set; }
        public string SerialNo { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}

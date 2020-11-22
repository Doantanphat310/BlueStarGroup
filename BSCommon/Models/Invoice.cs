using BSCommon.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCommon.Models
{
  public  class Invoice
    {
        private DateTime? dateCreated = null;
        public string InvoiceID { get; set; }
        public string VouchersID { get; set; }
        public string CustomerID { get; set; }
        public string Description { get; set; }
        public string MaSo { get; set; }
        public string MauSo { get; set; }
        public string KyHieu { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceType { get; set; }
        public DateTime InvoiceDate
        {
            get
            {
                return this.dateCreated.HasValue
                   ? this.dateCreated.Value
                   : DateTime.Now;
            }

            set { this.dateCreated = value; }
        }
        public decimal Amount { get; set; }
        public decimal VAT { get; set; }
        public decimal Discounts { get; set; }
        public string CreateUser { get; set; }
        public string CompanyID { get; set; }
        public decimal VATAmount { get { return this.VAT * (this.Amount - this.Discounts) / 100; } }
      //  public decimal DiscountAmount { get; set; }
        public decimal TotalAmount { get { return this.Amount  - Discounts + VATAmount; } }
        public ModifyMode Status { get; set; }
    }
}

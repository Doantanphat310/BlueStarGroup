using BSCommon.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCommon.Models
{
  public  class Invoice
    {
        public string InvoiceID { get; set; }
        public string VouchersID { get; set; }
        public string CustomerID { get; set; }
        public string Description { get; set; }
        public string MaSo { get; set; }
        public string MauSo { get; set; }
        public string KyHieu { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceType { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Amount { get; set; }
        public decimal VAT { get; set; }
        public string Discounts { get; set; }
        public string CreateUser { get; set; }
        public string CompanyID { get; set; }
        public ModifyMode Status { get; set; }
    }
}

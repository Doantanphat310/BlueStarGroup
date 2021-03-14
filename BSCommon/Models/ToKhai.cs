using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCommon.Models
{
    public class ToKhai
    {
        public string InvoiceType { get; set; }
        public string CTNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal Amount { get; set; }
        public decimal VAT { get; set; }
        public decimal VATAmount { get; set; }
        public string Description { get; set; }
        public string CustomerID { get; set; }
        public string CustomerTIN { get; set; }
        public string CustomerName { get; set; }
        public string VouchersID { get; set; }
    }
}

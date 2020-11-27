using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCommon.Models
{
  public  class MaterialCustomerInvoice
    {



            [DisplayName("Mã số")]
        public string InvoiceFormNo { get; set; }
        [DisplayName("Mẫu số")]
        public string FormNo { get; set; }
        [DisplayName("Ký hiệu")]
        public string SerialNo { get; set; }
            public string CustomerID { get; set; }
            public string CustomerName { get; set; }
            public string CustomerSName { get; set; }
    }
}

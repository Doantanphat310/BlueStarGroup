using BSCommon.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCommon.Models
{
   public class Voucher
    {
        public string VoucherDescription { get; set; }
        public decimal VoucherAmount { get; set; }
        public DateTime VoucherDate { get; set; }
        public string VouchersTypeID { get; set; }
        public string CreateUser { get; set; }
        public string VouchersID { get; set; }
        public string CompanyID { get; set; }
        public long VoucherNo { get; set; }
        public ModifyMode Status { get; set; }
    }
}

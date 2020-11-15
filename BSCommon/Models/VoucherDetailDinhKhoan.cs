using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCommon.Models
{
   public class VoucherDetailDinhKhoan
    {
        public string NV { get; set; }
        public string TKNumber { get; set; }
        public string CustomerName { get; set; }
        public string GeneralLedgerName { get; set; }
        public decimal Amount { get; set; }
    }
}

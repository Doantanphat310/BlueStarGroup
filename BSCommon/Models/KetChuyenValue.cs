using BSCommon.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCommon.Models
{
   public class KetChuyenValue
    {
        public string AccountID { get; set; }
        public string CustomerID { get; set; }
        public string AccountDetailID { get; set; }
        public Decimal DebitAmount { get; set; }
        public Decimal CreditAmount { get; set; }
        public Decimal Amount { get; set; }
        public Boolean DuNo { get; set; }
        public Boolean DuCo { get; set; }
        public string KetChuyenDebitAccountID { get; set; }
        public string KetChuyenCreditAccountID { get; set; }
        public string KetChuyenDebitAccountDetailID { get; set; }
        public string KetChuyenCreditAccountDetailID { get; set; }
        public ModifyMode Status { get; set; }
    }
}

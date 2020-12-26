using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCommon.Models
{
   public class KetChuyenValue
    {
        string AccountID { get; set; }
        string CustomerID { get; set; }
        string AccountDetailID { get; set; }
        Decimal DebitAmount { get; set; }
        Decimal CreditAmount { get; set; }
        Decimal Amount { get; set; }
        Boolean DuNo { get; set; }
        Boolean DuCo { get; set; }
        string KetChuyenDebitAccountID { get; set; }
        string KetChuyenCreditAccountID { get; set; }
        string KetChuyenDebitAccountDetailID { get; set; }
        string KetChuyenCreditAccountDetailID { get; set; }
    }
}

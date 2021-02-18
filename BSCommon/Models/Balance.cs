using BSCommon.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCommon.Models
{
   public class Balance
    {
        public string BalanceID { get; set; }
        public string AccountID { get; set; }
        public string AccountDetailID { get; set; }
        public string CompanyID { get; set; }
        public string CustomerID { get; set; }
        public string CustomersName { get; set; }
        public DateTime BalanceDate { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public DateTime CreateDate { get; set; }
        public string ItemID { get; set; }
        [System.ComponentModel.DefaultValue(1)]
        public decimal BalanceQuatity { get; set; }
        [System.ComponentModel.DefaultValue(0)]
        public decimal BalancePrice { get; set; }
        public string ItemUnitID { get; set; }
        public decimal Amount { get { return this.BalancePrice * this.BalanceQuatity; } }
        public ModifyMode Status { get; set; }
    }
}

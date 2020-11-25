using BSCommon.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCommon.Models
{
   public class WareHouse
    {
        public string WarehouseID { get; set; }
        public string VouchersID { get; set; }
        public string InvoiceID { get; set; }
        public string CustomerID { get; set; }
        public string GeneralLedgerID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string DebitAccountID { get; set; }
        public string CreditAccountID { get; set; }
        public string Type { get; set; }
        public string DeliverReceiver { get; set; }
        public string Description { get; set; }
        public string Attachfile { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string CreateUser { get; set; }
        public string UpdateUser { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public string CompanyID { get; set; }
        public ModifyMode Status { get; set; }
    }
}

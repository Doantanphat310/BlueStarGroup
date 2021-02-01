using BSCommon.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCommon.Models
{
    public class VoucherDetail
    {
        #region voucherDetail table Sql
        public string VouchersDetailID { get; set; }
        public string VouchersID { get; set; }
        public string AccountID { get; set; }
        public string AccountDetailID { get; set; }

        public string AccountIDFULL {
            get {
                if(!string.IsNullOrEmpty(this.AccountDetailID))
                {
                    return (this.AccountID + "/" + this.AccountDetailID);
                }
                return this.AccountID;
            }
            set
            {
                //  tes = value;
                int index = value.IndexOf('/');
                if (index >= 0)
                {
                    this.AccountID = value.Substring(0, index);
                    this.AccountDetailID = value.Substring(index + 1);
                }
                else this.AccountID = value;
            }
        }

        public string MyValue { get; set; }

        public string CustomerID { get; set; }
        public string CompanyID { get; set; }
        public string Descriptions { get; set; }
        #endregion VoucherDetail table Sql
        public string NV { get; set; }
        public string CustomerName { get; set; }
        public decimal Amount { get; set; }
        public ModifyMode Status { get; set; }
    }
}

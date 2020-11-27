using BSCommon.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCommon.Models
{
    public class DepreciationDetail
    {
        public string DepreciationDetailID { get; set; }
        public string DepreciationID { get; set; }
        public Nullable<int> PeriodCurrent { get; set; }
        public Nullable<System.DateTime> DepreciationDate { get; set; }
        public Nullable<int> QuantityPeriod { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string Descriptions { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string CreateUser { get; set; }
        public string UpdateUser { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public string CompanyID { get; set; }
        public ModifyMode StatusA { get; set; }
    }
}

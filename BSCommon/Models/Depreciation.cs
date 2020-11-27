using BSCommon.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCommon.Models
{
    public class Depreciation
    {
        public string DepreciationID { get; set; }
        public string WareHouseDetailID { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<int> UseMonth { get; set; }
        public Nullable<int> DepreciationMonth { get; set; }
        public Nullable<int> CurrentMonth { get; set; }
        public decimal DepreciationAmount { get; set; }
        public double DepreciationPercent { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string CreateUser { get; set; }
        public string UpdateUser { get; set; }
        public string CompanyID { get; set; }
        public ModifyMode StatusA { get; set; }
        public decimal DepreciationAmountMonth { get { return this.DepreciationAmount * (Decimal)this.DepreciationPercent /100 ; } }
    }
}

using BSCommon.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCommon.Models
{
  public  class WareHouseDetail
    {
        public string WareHouseDetailID { get; set; }
        public string WarehouseID { get; set; }
        public string ItemID { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
       // public decimal Amount { get; set; }
        public decimal Amount { get { return this.Price * this.Quantity; } }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreateUser { get; set; }
        public string UpdateUser { get; set; }
        public string CompanyID { get; set; }
        public ModifyMode Status { get; set; }
    }
}

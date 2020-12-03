﻿using BSCommon.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCommon.Models
{
  public  class WareHouseDetail
    {
        public string WareHouseDetailID { get; set; }
        public string WarehouseID { get; set; }
        
        [Required(ErrorMessage = "Mã hàng hóa không được để trống!")]
        public string ItemID { get; set; }
        [Required(ErrorMessage = "Số lượng không được để trống!")]
        public decimal Quantity { get; set; }
        [Required(ErrorMessage = "Đơn giá không được để trống!")]
        public decimal Price { get; set; }
        // public decimal Amount { get; set; }
        public decimal Amount { get { return this.Price * this.Quantity; } }
        public Nullable<DateTime>  CreateDate { get; set; }
        public Nullable<DateTime> UpdateDate { get; set; }
        public string CreateUser { get; set; }
        public string UpdateUser { get; set; }
        public string CompanyID { get; set; }
        public string ItemUnit { get; set; }
        public ModifyMode Status { get; set; }
    }
}
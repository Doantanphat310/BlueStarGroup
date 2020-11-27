using BSCommon.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCommon.Models
{
    public class Depreciation
    {
        public string DepreciationID { get; set; }
        public string WareHouseDetailID { get; set; }
        [Required(ErrorMessage = "Ngày bắt đầu sử dụng không được để trống!")]
        public Nullable<System.DateTime> StartDate { get; set; }
        [Required(ErrorMessage = "Số tháng sử dụng không được để trống!")]
        public Nullable<int> UseMonth { get; set; }
        [Required(ErrorMessage = "Số tháng khấu hao không được để trống!")]
        public Nullable<int> DepreciationMonth { get; set; }
        [Required(ErrorMessage = "Tháng hiện tại không được để trống!")]
        public Nullable<int> CurrentMonth { get; set; }
        [Required(ErrorMessage = "Tiền KH mỗi tháng không được để trống!")]
        public decimal DepreciationAmount { get; set; }
        [Required(ErrorMessage = "% khấu hao mỗi tháng không được để trống!")]
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

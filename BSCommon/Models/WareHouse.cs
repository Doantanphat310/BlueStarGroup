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
   public class WareHouse
    {
        public string WarehouseID { get; set; }
        public string VouchersID { get; set; }
        public string InvoiceID { get; set; }

        // [Range(0, 999.99, ErrorMessage = "Thuế GTGT phải >= 0 và <= 999.99")]
        public string CustomerID { get; set; }
        [DisplayName("Mã sổ cái")]
        [Required(ErrorMessage = "Sổ kho không được để trống!")]
        public string WarehouseListID { get; set; }
        [DisplayName("Ngày")]
        [Required(ErrorMessage = "Ngày không được để trống!")]
        public Nullable<System.DateTime> Date { get; set; }
        [DisplayName("TK Nợ")]
        [Required(ErrorMessage = "TK Nợ không được để trống!")]
        public string DebitAccountID { get; set; }
        [DisplayName("TK Có")]
        [Required(ErrorMessage = "TK Có không được để trống!")]
        public string CreditAccountID { get; set; }
        [DisplayName("Loại ghi kho")]
        [Required(ErrorMessage = "Loại ghi kho không được để trống!")]
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

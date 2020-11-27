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
  public  class Invoice
    {
        private DateTime? dateCreated = null;
        public string InvoiceID { get; set; }
        public string VouchersID { get; set; }
        [Required(ErrorMessage = "Khách hàng không được để trống!")]
        [DisplayName("Mã KH")]
        public string CustomerID { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Mã số HĐ không được để trống!")]
        [DisplayName("Mã số")]
        public string InvoiceFormNo { get; set; }
        [Required(ErrorMessage = "Mẫu số HĐ không được để trống!")]
        [DisplayName("Mẫu số")]
        public string FormNo { get; set; }
        [Required(ErrorMessage = "Ký hiệu HĐ không được để trống!")]
        [DisplayName("Ký hiệu")]
        public string SerialNo { get; set; }
        [Required(ErrorMessage = "Số HĐ không được để trống!")]
        [DisplayName("Số HĐ")]
        public string InvoiceNo { get; set; }
        [Required(ErrorMessage = "Loại HĐ không được để trống!")]
        [DisplayName("Loại HĐ")]
        public string InvoiceType { get; set; }
        [Required(ErrorMessage = "Ngày HĐ không được để trống!")]
        [DisplayName("Ngày HĐ")]
        public DateTime InvoiceDate
        {
            get
            {
                return this.dateCreated.HasValue
                   ? this.dateCreated.Value
                   : DateTime.Now;
            }

            set { this.dateCreated = value; }
        }
       
        [DisplayName("Tiền")]
        [Required(ErrorMessage = "Tiền hóa đơn không được để trống!")]
        public decimal Amount { get; set; }
        [Required]
        [DisplayName("Thuế GTGT")]
        [Range(0, 999.99, ErrorMessage = "Thuế GTGT phải >= 0 và <= 999.99")]
        public decimal VAT { get; set; }
        public decimal Discounts { get; set; }
        public string CreateUser { get; set; }
        public string CompanyID { get; set; }
        public decimal VATAmount { get { return this.VAT * (this.Amount - this.Discounts) / 100; } }
      //  public decimal DiscountAmount { get; set; }
        public decimal TotalAmount { get { return this.Amount  - Discounts + VATAmount; } }
        public ModifyMode Status { get; set; }
    }
}

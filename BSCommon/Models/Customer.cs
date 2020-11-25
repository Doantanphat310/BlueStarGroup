﻿using BSCommon.Constant;
using System;

namespace BSCommon.Models
{
    /// <summary>
    /// Customer infomation
    /// </summary>        
    public class Customer
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSName { get; set; }
        public string ParentID { get; set; }
        public string InvoiceFormNo { get; set; }
        public string FormNo { get; set; }
        public string SerialNo { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreateUser { get; set; }
        public string UpdateUser { get; set; }
        public ModifyMode Status { get; set; }
    }
}

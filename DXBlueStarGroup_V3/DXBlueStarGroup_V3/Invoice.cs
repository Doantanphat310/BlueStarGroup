//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DXBlueStarGroup_V3
{
    using System;
    using System.Collections.Generic;
    
    public partial class Invoice
    {
        public string RowID { get; set; }
        public long ID { get; set; }
        public string DateName { get; set; }
        public string InvoiceID { get; set; }
        public string VouchersIDetailD { get; set; }
        public string CustomerID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code1 { get; set; }
        public string Code2 { get; set; }
        public string Code3 { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceType { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> VAT { get; set; }
        public Nullable<decimal> Discounts { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string CreateUser { get; set; }
        public string UpdateUser { get; set; }
        public string Status { get; set; }
        public string CompanyID { get; set; }
    }
}

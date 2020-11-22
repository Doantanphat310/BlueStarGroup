using System;

namespace BSCommon.Models
{
    /// <summary>
    /// User infomation
    /// </summary>        
    public class Company
    {
        public string CompanyID { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string CompanySName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string MST { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreateUser { get; set; }
        public string UpdateUser { get; set; }
        public int? IsDelete { get; set; }
    }
}

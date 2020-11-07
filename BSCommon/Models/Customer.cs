using System;

namespace BSCommon.Models
{
    /// <summary>
    /// User infomation
    /// </summary>        
    public class Customer
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSName { get; set; }
        public string ParentID { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreateUser { get; set; }
        public string UpdateUser { get; set; }
        public int Status { get; set; }
    }
}

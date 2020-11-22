using BSCommon.Constant;

namespace BSCommon.Models
{
    /// <summary>
    /// ItemPriceCompany infomation
    /// </summary>        
    public class ItemPriceCompany
    {
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public string CompanyID { get; set; }
        public string CompanyName { get; set; }
        public decimal ItemPrice { get; set; }
        public ModifyMode Status { get; set; }
    }
}

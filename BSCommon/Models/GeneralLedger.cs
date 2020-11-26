using System.ComponentModel.DataAnnotations;

namespace BSCommon.Models
{
    /// <summary>
    /// Item infomation
    /// </summary>        
    public class GeneralLedger : BaseModel
    {
        [Key]
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemSName { get; set; }
        public string ItemSpecification { get; set; }
        public string ItemTypeID { get; set; }
        public string ItemUnit { get; set; }
        public int? IsDelete { get; set; }
    }
}

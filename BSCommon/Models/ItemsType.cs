using BSCommon.Constant;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSCommon.Models
{
    /// <summary>
    /// Item type infomation
    /// </summary>        
    [Table("ItemType")]
    public class ItemType : BaseModel
    {
        [Key]
        public string ItemTypeID { get; set; }
        public string ItemTypeName { get; set; }
        public string ItemTypeSName { get; set; }
    }
}

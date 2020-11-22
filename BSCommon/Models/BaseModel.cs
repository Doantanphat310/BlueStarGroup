using BSCommon.Constant;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSCommon.Models
{
    public class BaseModel
    {
        [NotMapped]
        public ModifyMode Status { get; set; }
    }
}

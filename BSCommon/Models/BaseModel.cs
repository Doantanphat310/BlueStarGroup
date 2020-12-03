using BSCommon.Constant;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSCommon.Models
{
    public class BaseModel
    {
        [NotMapped]
        public ModifyMode Status { get; set; }

        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreateUser { get; set; }
        public string UpdateUser { get; set; }
    }
}

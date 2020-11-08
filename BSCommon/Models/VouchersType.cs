using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCommon.Models
{
    [Table("VouchersType")]
    public class VouchersType
    {
        public string RowID { get; set; }
        public long ID { get; set; }
        public string Name { get; set; }
        public string SummaryName { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string CreateUser { get; set; }
        public string UpdateUser { get; set; }
        public string Status { get; set; }
        public string VouchersTypeID { get; set; }
    }
}

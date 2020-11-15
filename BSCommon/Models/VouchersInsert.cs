using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCommon.Models
{
   public class VouchersInsert
    {
        public string VouchersID { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public DateTime? Date { get; set; }
        public string VouchersTypeID { get; set; }
        public string VourchersTypeSumary { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateUser { get; set; }
        public string CompanyID { get; set; }
        public int Status { get; set; }
    }
}

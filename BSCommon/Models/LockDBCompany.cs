using BSCommon.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCommon.Models
{
   public class LockDBCompany
    {
       
         public string ClockDBID { get; set; }
        public string CompanyID { get; set; }
        public DateTime ClockDBDate { get; set; }
        public string ClockDBNote { get; set; }
        public Boolean ClockStatus { get; set; }
        public string CreateUser { get; set; }
        public Boolean? IsDelete { get; set; }
        public ModifyMode Status { get; set; }
    }
}

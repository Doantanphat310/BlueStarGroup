using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCommon.Models
{
   public class MaterialTK
    {
        public string AccountID { get; set; }
        public string AccountDetailID { get; set; }
        public string Name { get; set; }
        public Boolean DuNo { get; set; }
        public Boolean DuCo { get; set; }
        public Boolean HachToan { get; set; }
        public Boolean ThongKe { get; set; }
        public Boolean NgoaiTe { get; set; }
        public Boolean TK152_156 { get; set; }
        public Boolean VatTu { get; set; }
        public Boolean ThueVAT { get; set; }
        public Boolean HopDong { get; set; }
        public Boolean CongNo { get; set; }
    }
}

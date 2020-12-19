using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCommon.Models
{
    public class MaterialSoDuCuoiKyTK
    {
        public string AccountID { get; set; }
        public string AccountDetailID { get; set; }
        public string CustomerID { get; set; }
        public string CompanyID { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
        // MaHang,SL, DGia,
        // MaTSCD, So Thang khau hao, tien khau hao moi ky
        public string ItemID { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}

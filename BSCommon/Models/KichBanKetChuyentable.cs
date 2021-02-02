using BSCommon.Constant;

namespace BSCommon.Models
{
    public class KichBanKetChuyentable
    {
        public string GroupCode { get; set; }

        public string KetChuyenDebitAccountID { get; set; }

        public string KetChuyenCreditAccountID { get; set; }

        public string CompanyID { get; set; }

        public ModifyMode Status { get; set; }
    }
}

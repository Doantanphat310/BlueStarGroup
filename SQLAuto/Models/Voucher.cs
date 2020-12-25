namespace SQLAuto.Models
{
    public class Voucher
    {
        public string VoucherType { get; set; }
        public string VoucherNo { get; set; }
        public string VoucherDate { get; set; }
        public string VoucherDescription { get; set; }
        public double PSNo { get; set; }
        public double PSCo { get; set; }

        public string AccountID { get; set; }
        public string AccountDetailID { get; set; }
        public string CustomerID { get; set; }

        public string CompanyID { get; set; }
    }
}

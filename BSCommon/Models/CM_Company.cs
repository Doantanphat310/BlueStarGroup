namespace BSCommon.Models
{
    /// <summary>
    /// Company infomation
    /// </summary>        
    public class CM_Company : BaseModel
    {
        /// <summary>
        /// CompanyID
        /// </summary>
        public string CompanyID { get; set; }

        /// <summary>
        /// CompanyName
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// CompanySName
        /// </summary>
        public string CompanySName { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// MST
        /// </summary>
        public string MST { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Fax
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// BankAccount
        /// </summary>
        public string BankAccount { get; set; }

        /// <summary>
        /// BankName
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// BankBranch
        /// </summary>
        public string BankBranch { get; set; }
    }
}

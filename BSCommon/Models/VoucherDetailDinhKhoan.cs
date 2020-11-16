using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCommon.Models
{
   public class VoucherDetailDinhKhoan
    {
        public string VoucherDetailID { get; set; }
        public string NV { get; set; }
        public string TKNumber { get; set; }
        public string CustomerName { get; set; }
        public string GeneralLedgerName { get; set; }
        public decimal Amount { get; set; }
        #region voucherDetail table Sql
        //[VouchersID] [varchar] (50) NULL,
        //[AccountID] [varchar] (50) NULL,
        /*
[RowID] [varchar](36) NULL,
[ID] [bigint] IDENTITY(1,1) NOT NULL,
[VouchersID] [varchar](50) NULL,
[AccountID] [varchar](50) NULL,
[GeneralLedgerID] [varchar](50) NULL,
[CustomerID] [varchar](50) NULL,
[DebitAmount] [money] NULL,
[CreditAmount] [money] NULL,
[CreateDate] [datetime] NULL,
[UpdateDate] [datetime] NULL,
[CreateUser] [varchar](20) NULL,
[UpdateUser] [varchar](20) NULL,
[IsDelete] [bit] NULL,
[CompanyID] [varchar](50) NULL,
[VouchersDetailID] [varchar](50) NULL,
         */
        #endregion VoucherDetail table Sql
    }
}

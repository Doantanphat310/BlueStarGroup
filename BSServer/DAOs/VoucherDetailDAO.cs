using BSCommon.Models;
using BSCommon.Utility;
using BSServer._Core.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSServer.DAOs
{
   public class VoucherDetailDAO
    {
        public VoucherDetailDAO(BSContext context)
        {
            this.Context = context;
        }
        private BSContext Context { get; set; }

        public List<VoucherDetail> GetVouchersDetailSelectVoucherID(string voucherID,string CompanyID)
        {
            return this.Context.Database.SqlQuery<VoucherDetail>(
          "VouchersDetailSelectVoucherID @VouchersID, @CompanyID, @CreateUser",
          new SqlParameter("@VouchersID", voucherID),
          new SqlParameter("@CompanyID", CompanyID),
          new SqlParameter("@CreateUser", CommonInfo.UserInfo.UserName)
          ).ToList();
        }

        public bool InsertVouchersDetail(VoucherDetail voucherDetailInfo)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@VouchersID", voucherDetailInfo.VouchersID),
                    new SqlParameter("@VouchersDetailID", voucherDetailInfo.VouchersDetailID),
                    new SqlParameter("@NV", voucherDetailInfo.NV),
                    new SqlParameter("@AccountID", voucherDetailInfo.AccountID),
                    new SqlParameter("@CustomerID", voucherDetailInfo.CustomerID?? (object)DBNull.Value),
                    new SqlParameter("@GeneralLedgerID", voucherDetailInfo.GeneralLedgerID),
                    new SqlParameter("@Amount", voucherDetailInfo.Amount),
                    new SqlParameter("@CompanyID", voucherDetailInfo.CompanyID),
                    new SqlParameter("@CreateUser", CommonInfo.UserInfo.UserID),
                };
                this.Context.ExecuteDataFromProcedure("VouchersDetailInsert", sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert VoucherDetail Fail! " + ex.Message);
                return false;
            }
        }

        public bool DeleteVoucherDetail(string VouchersDetailID,string CompanyID)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
               {
                    new SqlParameter("@VouchersDetailID", VouchersDetailID),
                    new SqlParameter("@CompanyID", CompanyID),
                    new SqlParameter("@CreateUser", CommonInfo.UserInfo.UserID)
               };

                this.Context.ExecuteDataFromProcedure("VouchersDetailDelete", sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete Vouchers Detail Fail! " + ex.Message);
                return false;
            }
        }


        public bool UpdateVoucherDetail(VoucherDetail voucherDetailInfo)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@VouchersID", voucherDetailInfo.VouchersID),
                    new SqlParameter("@VouchersDetailID", voucherDetailInfo.VouchersDetailID),
                    new SqlParameter("@NV", voucherDetailInfo.NV),
                    new SqlParameter("@AccountID", voucherDetailInfo.AccountID),
                    new SqlParameter("@CustomerID", voucherDetailInfo.CustomerID?? (object)DBNull.Value),
                    new SqlParameter("@GeneralLedgerID", voucherDetailInfo.GeneralLedgerID),
                    new SqlParameter("@Amount", voucherDetailInfo.Amount),
                    new SqlParameter("@CompanyID", voucherDetailInfo.CompanyID),
                    new SqlParameter("@CreateUser", CommonInfo.UserInfo.UserID),
                };

                this.Context.ExecuteDataFromProcedure("VouchersDetailUpdate", sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update VoucherDetail Fail! " + ex.Message);
                return false;
            }
        }

    }
}

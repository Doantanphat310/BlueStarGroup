using BSServer._Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSCommon.Models;
using System.Data.SqlClient;
using BSCommon.Utility;

namespace BSServer.DAOs
{
   public class VoucherDAO
    {
        public VoucherDAO(BSContext context)
        {
            this.Context = context;
        }

        private BSContext Context { get; set; }

        public List<Voucher> GetVouchersCompany(string companyID)
        {
            SqlParameter param = new SqlParameter("@CompanyID", companyID);

            return this.Context.Database
                .SqlQuery<Voucher>("VoucherCompanySelect @CompanyID", param)
                .ToList();
        }
        

        public List<Voucher> GetVouchersCondition(string companyID,DateTime NgayBD, DateTime NgayKT, string voucherType)
        {
            return   this.Context.Database.SqlQuery<Voucher>(
            "VoucherConditionSelect @CompanyID, @NgayBD, @NgayKT, @VouchersTypeID, @UserName",
            new SqlParameter("@CompanyID", companyID),
            new SqlParameter("@NgayBD", NgayBD),
            new SqlParameter("@NgayKT", NgayKT),
            new SqlParameter("@VouchersTypeID", voucherType),
            new SqlParameter("@UserName", CommonInfo.UserInfo.UserID)
            ).ToList();
        }
        
        public bool InsertVouchers(Voucher voucherInfo)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@VouchersID", voucherInfo.VouchersID),
                    new SqlParameter("@Amount", voucherInfo.Amount),
                    new SqlParameter("@Description", voucherInfo.Description),
                    new SqlParameter("@VouchersTypeID", voucherInfo.VouchersTypeID),
                    new SqlParameter("@Date", voucherInfo.Date),
                    new SqlParameter("@CompanyID", voucherInfo.CompanyID),
                    new SqlParameter("@CreateUser", CommonInfo.UserInfo.UserID),
                };
                this.Context.ExecuteDataFromProcedure("VouchersInsert", sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert Voucher Fail! " + ex.Message);
                return false;
            }
        }
        
        public bool DeleteVoucher(string VoucherID, string CompanyID)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
               {
                    new SqlParameter("@VoucherID", VoucherID),
                    new SqlParameter("@CompanyID", CompanyID),
                    new SqlParameter("@UserId", CommonInfo.UserInfo.UserID)
               };

                this.Context.ExecuteDataFromProcedure("VoucherDelete", sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete Vouchers Fail! " + ex.Message);
                return false;
            }
        }
        
        public bool UpdateVoucher(Voucher voucherInfo)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@VouchersID", voucherInfo.VouchersID),
                    new SqlParameter("@Amount", voucherInfo.Amount),
                    new SqlParameter("@Description", voucherInfo.Description),
                    new SqlParameter("@CreateUser", CommonInfo.UserInfo.UserID),
                };

                this.Context.ExecuteDataFromProcedure("VoucherUpdate", sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update Voucher Fail! " + ex.Message);
                return false;
            }
        }
    }
}

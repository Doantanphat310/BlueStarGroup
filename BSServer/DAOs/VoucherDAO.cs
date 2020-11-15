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

        //public List<CustomerCompany> GetCustommers(string customerId)
        //{
        //    if (string.IsNullOrEmpty(customerId))
        //    {
        //        return GetCustommers();
        //    }
        //    else
        //    {
        //        return GetCustommersById(customerId);
        //    }
        //}

        //private List<CustomerCompany> GetCustommers()
        //{
        //    return this.Context.Customers.ToList();
        //}

        //private List<CustomerCompany> GetCustommersById(string customerId)
        //{
        //    return this.Context.Customers.Where(o => o.CustomerID == customerId).ToList();
        //}

        public List<Voucher> GetVouchers()
        {
            return Context.Database.SqlQuery<Voucher>("VoucherSelect").ToList();
        }

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
            "VoucherConditionSelect @CompanyID, @NgayBD, @NgayKT, @VouchersTypeSumary, @UserName",
            new SqlParameter("@CompanyID", companyID),
            new SqlParameter("@NgayBD", NgayBD),
            new SqlParameter("@NgayKT", NgayKT),
            new SqlParameter("@VouchersTypeSumary", voucherType),
            new SqlParameter("@UserName", CommonInfo.UserInfo.UserName)
            ).ToList();
        }

        public int InsertVouchersCompany(VouchersInsert vouchersInsert)
        {
            string sql = @"
VouchersInsert
@Amount,
@Description, 
@VouchersTypeID,
@VourchersTypeSumary,
@Date,
@CompanyID,
@CreateUser
            ";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Amount", vouchersInsert.Amount),
                new SqlParameter("@Description", vouchersInsert.Description ?? (object)DBNull.Value),
                new SqlParameter("@VouchersTypeID", vouchersInsert.VouchersTypeID ?? (object)DBNull.Value),
                new SqlParameter("@VourchersTypeSumary", vouchersInsert.VourchersTypeSumary ?? (object)DBNull.Value),
                new SqlParameter("@Date", vouchersInsert.Date ?? (object)DBNull.Value),
                new SqlParameter("@CompanyID", vouchersInsert.CompanyID ?? (object)DBNull.Value),
                new SqlParameter("@CreateUser", CommonInfo.UserInfo.UserID)
            };
            return this.Context.Database.ExecuteSqlCommand(sql, param);
        }




        public int UpdateVouchersCompany(VouchersInsert vouchersUpdate)
        {
            string sql = @"
VoucherUpdate
    @VouchersID, 
    @Amount,
    @Description, 
    @CreateUser
";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@VouchersID", vouchersUpdate.VouchersID),
                new SqlParameter("@Amount", vouchersUpdate.Amount),
                new SqlParameter("@Description", vouchersUpdate.Description ?? (object)DBNull.Value),
                new SqlParameter("@CreateUser", CommonInfo.UserInfo.UserID)
            };

            return this.Context.Database.ExecuteSqlCommand(sql, param);
        }

        public int DeleteVouchersCompany(VouchersInsert voucherUpdate)
        {
            string sql = @"
VoucherDelete
    @VoucherID, 
    @UserId
";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("VoucherID", voucherUpdate.VouchersID),
                new SqlParameter("UserId", CommonInfo.UserInfo.UserID)
            };

            return this.Context.Database.ExecuteSqlCommand(sql, param);
        }
    }
}

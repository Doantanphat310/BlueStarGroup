using BSCommon.Constant;
using BSCommon.Models;
using BSCommon.Utility;
using BSServer._Core.Base;
using BSServer._Core.Const;
using BSServer._Core.Context;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BSServer.DAOs
{
    public class CompanyDAO: BaseDAO
    {
        public CompanyDAO(BSContext context):base(context)
        {
        }

        public List<Company> GetCompanys()
        {
            return this.Context.Database
               .SqlQuery<Company>("CompanySelect")
               .ToList();
        }

        public long GetCompanySEQ()
        {
            return this.GetMaxSEQ(BSServerConst.CompanySymbol);
        }

        public int InsertCompany(Company data)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CompanyID", data.CompanyID),
                new SqlParameter("@CompanyName", data.CompanyName),
                new SqlParameter("@CompanySName", data.CompanySName),
                new SqlParameter("@Address", data.Address),
                new SqlParameter("@MST", data.MST),
                new SqlParameter("@Phone", data.Phone),
                new SqlParameter("@UserId", CommonInfo.UserInfo.UserID)
            };

            return this.Context.ExecuteDataFromProcedure("CompanyInsert", param);
        }

        public int UpdateCompany(Company data)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CompanyID", data.CompanyID),
                new SqlParameter("@CompanyName", data.CompanyName),
                new SqlParameter("@CompanySName", data.CompanySName),
                new SqlParameter("@Address", data.Address),
                new SqlParameter("@MST", data.MST),
                new SqlParameter("@Phone", data.Phone),
                new SqlParameter("@UserId", CommonInfo.UserInfo.UserID)
            };

            return this.Context.ExecuteDataFromProcedure("CompanyUpdate", param);
        }

        public int DeleteCompany(Company data)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CustomerID", data.CompanyID),
                new SqlParameter("UserId", CommonInfo.UserInfo.UserID)
            };

            return this.Context.ExecuteDataFromProcedure("CompanyDelete", param);
        }
    }
}

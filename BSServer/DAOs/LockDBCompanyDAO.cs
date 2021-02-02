using BSCommon.Models;
using BSCommon.Utility;
using BSServer._Core.Base;
using BSServer._Core.Const;
using BSServer._Core.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSServer.DAOs
{
  public  class LockDBCompanyDAO : BaseDAO
    {
        public LockDBCompanyDAO(BSContext context) : base(context) { }

        public List<LockDBCompany> GetLockDBCompany(DateTime StartDate, DateTime EndDate, string CompanyID)
        {
            return this.Context.Database.SqlQuery<LockDBCompany>("LockDBCompanySelect @StartDate, @EndDate, @CompanyID, @UserCreate",
                new SqlParameter("@StartDate", StartDate),
                new SqlParameter("@EndDate", EndDate),
                new SqlParameter("@CompanyID", CompanyID),
                new SqlParameter("@UserCreate", UserInfo.UserID)
                ).ToList();
        }
        
        public List<LockDBCompany> LockDBCompanyCheck(DateTime LockDate, string CompanyID)
        {
            return this.Context.Database.SqlQuery<LockDBCompany>("LockDBCompanyCheck @LockDate, @CompanyID",
                new SqlParameter("@LockDate", LockDate),
                new SqlParameter("@CompanyID", CompanyID)
                ).ToList();
        }

        public long GetLockDBCompanySEQ()
        {
            return this.GetMaxSEQ(BSServerConst.LockDBCompanySymbol);
        }

        public bool InsertLockDB(LockDBCompany data)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                new SqlParameter("@ClockDBID", data.ClockDBID),
                new SqlParameter("@CompanyID", data.CompanyID),
                new SqlParameter("@ClockDBDate", data.ClockDBDate),
                new SqlParameter("@ClockDBNote", data.ClockDBNote),
                new SqlParameter("@ClockStatus", data.ClockStatus),
                new SqlParameter("@CreateUser", UserInfo.UserID)
                };
                this.Context.ExecuteDataFromProcedure("LockDBCompanyInsert", sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return false;
            }
        }

        public bool UpdateLockDB(LockDBCompany data)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                new SqlParameter("@ClockDBID", data.ClockDBID),
                new SqlParameter("@CompanyID", data.CompanyID),
                new SqlParameter("@ClockDBDate", data.ClockDBDate),
                new SqlParameter("@ClockDBNote", data.ClockDBNote),
                new SqlParameter("@ClockStatus", data.ClockStatus),
                new SqlParameter("@CreateUser", UserInfo.UserID)
                };
                this.Context.ExecuteDataFromProcedure("LockDBCompanyUpdate", sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return false;
            }

        }

        public bool DeleteLockDB(LockDBCompany data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@ClockDBID", data.ClockDBID),
                 new SqlParameter("@CompanyID", data.CompanyID),
                new SqlParameter("@CreateUser", UserInfo.UserID),
                new SqlParameter("@IsDelete", data.IsDelete)
            };
            this.Context.ExecuteDataFromProcedure("LockDBCompanyDelete", sqlParameters);
            return true;
        }
    }
}

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
   public class DepreciationDAO: BaseDAO
    {
        public DepreciationDAO(BSContext context) : base(context)
        {
        }

        public List<Depreciation> GetDepreciationSelect(string WareHouseDetailID, string CompanyID)
        {
            return this.Context.Database.SqlQuery<Depreciation>(
          "DepreciationSelect @WareHouseDetailID, @CreateUser, @CompanyID",
          new SqlParameter("@VouchersID", WareHouseDetailID),
          new SqlParameter("@CreateUser", CommonInfo.UserInfo.UserName),
          new SqlParameter("@CompanyID", CompanyID)
          ).ToList();
        }

        public long GetDepreciationSEQ()
        {
            return this.GetMaxSEQ(BSServerConst.DepreciationSymbol);
        }

        public bool InsertDepreciation(Depreciation depreciation)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@DepreciationID", depreciation.DepreciationID),
                    new SqlParameter("@WareHouseDetailID", depreciation.WareHouseDetailID),
                    new SqlParameter("@StartDate", depreciation.StartDate),
                    new SqlParameter("@UseMonth", depreciation.UseMonth),
                    new SqlParameter("@DepreciationMonth", depreciation.DepreciationMonth?? (object)DBNull.Value),
                    new SqlParameter("@CurrentMonth", depreciation.CurrentMonth),
                    new SqlParameter("@DepreciationAmount", depreciation.DepreciationAmount),
                    new SqlParameter("@DepreciationPercent", depreciation.DepreciationPercent),
                    new SqlParameter("@Status", depreciation.Status),
                    new SqlParameter("@CreateUser",  CommonInfo.UserInfo.UserID),
                    new SqlParameter("@CompanyID", depreciation.CompanyID),
                };
                this.Context.ExecuteDataFromProcedure("DepreciationInsert", sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert Depreciation Fail! " + ex.Message);
                return false;
            }
        }

        public bool DeleteDepreciation(string DepreciationID, string CompanyID)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
               {
                    new SqlParameter("@DepreciationID", DepreciationID),
                    new SqlParameter("@CreateUser", CommonInfo.UserInfo.UserID ),
                    new SqlParameter("@CompanyID", CompanyID)
               };

                this.Context.ExecuteDataFromProcedure("DepreciationDelete", sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete Depreciation Fail! " + ex.Message);
                return false;
            }
        }


        public bool UpdateDepreciation(Depreciation depreciation)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@DepreciationID", depreciation.DepreciationID),
                    new SqlParameter("@StartDate", depreciation.StartDate),
                    new SqlParameter("@UseMonth", depreciation.UseMonth),
                    new SqlParameter("@DepreciationMonth", depreciation.DepreciationMonth),
                    new SqlParameter("@CurrentMonth", depreciation.CurrentMonth?? (object)DBNull.Value),
                    new SqlParameter("@DepreciationAmount", depreciation.DepreciationMonth),
                    new SqlParameter("@DepreciationPercent", depreciation.DepreciationPercent),
                    new SqlParameter("@Status", depreciation.Status),
                    new SqlParameter("@CreateUser", CommonInfo.UserInfo.UserID ),
                    new SqlParameter("@CompanyID", depreciation.CompanyID),
                };

                this.Context.ExecuteDataFromProcedure("DepreciationUpdate", sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update Depreciation Fail! " + ex.Message);
                return false;
            }
        }
    }
}

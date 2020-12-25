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
   public class DepreciationDetailDAO: BaseDAO
    {
        public DepreciationDetailDAO(BSContext context): base(context)
        {
        }

        public List<DepreciationDetail> GetDepreciationDetailSelect(string DepreciationID, string CompanyID)
        {
            return this.Context.Database.SqlQuery<DepreciationDetail>(
          "DepreciationDetailSelect @DepreciationID, @CreateUser, @CompanyID",
          new SqlParameter("@DepreciationID", DepreciationID),
          new SqlParameter("@CreateUser", UserInfo.UserID),
          new SqlParameter("@CompanyID", CompanyID)
          ).ToList();
        }

        public long GetDepreciationDetailSEQ()
        {
            return this.GetMaxSEQ(BSServerConst.DepreciationDetailSymbol);
        }

        public bool InsertDepreciationDetail(DepreciationDetail depreciationdetail)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@DepreciationDetailID", depreciationdetail.DepreciationDetailID),
                    new SqlParameter("@DepreciationID", depreciationdetail.DepreciationID),
                    new SqlParameter("@PeriodCurrent", depreciationdetail.PeriodCurrent),
                    new SqlParameter("@DepreciationDate", depreciationdetail.DepreciationDate),
                    new SqlParameter("@QuantityPeriod", depreciationdetail.QuantityPeriod),
                    new SqlParameter("@Amount", depreciationdetail.Amount),
                    new SqlParameter("@Descriptions", depreciationdetail.Descriptions?? (object)DBNull.Value),
                    new SqlParameter("@CreateUser", UserInfo.UserID),
                    new SqlParameter("@CompanyID", depreciationdetail.CompanyID),
                };
                this.Context.ExecuteDataFromProcedure("DepreciationDetailInsert", sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert DepreciationDetail Fail! " + ex.Message);
                return false;
            }
        }

        public bool DeleteDepreciationDetail(string DepreciationDetailID, string CompanyID)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
               {
                    new SqlParameter("@DepreciationDetailID", DepreciationDetailID),
                    new SqlParameter("@CreateUser", UserInfo.UserID ),
                    new SqlParameter("@CompanyID", CompanyID)
               };

                this.Context.ExecuteDataFromProcedure("DepreciationDetailDelete", sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete DepreciationDetail Fail! " + ex.Message);
                return false;
            }
        }


        public bool UpdateDepreciationDetail(DepreciationDetail depreciationdetail)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@DepreciationDetailID", depreciationdetail.DepreciationDetailID),
                    new SqlParameter("@PeriodCurrent", depreciationdetail.PeriodCurrent),
                    new SqlParameter("@DepreciationDate", depreciationdetail.DepreciationDate),
                    new SqlParameter("@QuantityPeriod", depreciationdetail.QuantityPeriod),
                    new SqlParameter("@Amount", depreciationdetail.Amount),
                    new SqlParameter("@Descriptions", depreciationdetail.Descriptions?? (object)DBNull.Value),
                    new SqlParameter("@CreateUser",  UserInfo.UserID ),
                    new SqlParameter("@CompanyID", depreciationdetail.CompanyID),
                };

                this.Context.ExecuteDataFromProcedure("DepreciationDetailUpdate", sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update DepreciationDetail Fail! " + ex.Message);
                return false;
            }
        }
    }
}

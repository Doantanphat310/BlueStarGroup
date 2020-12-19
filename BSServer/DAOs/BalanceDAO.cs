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
  public  class BalanceDAO : BaseDAO
    {
        public BalanceDAO(BSContext context) : base(context) {}

        public List<Balance> GetBalance(DateTime BalanceDate, string CompanyID)
        {
            return this.Context.Database.SqlQuery<Balance>("BalanceSelect @BalanceDate, @CompanyID",
                new SqlParameter("@BalanceDate", BalanceDate),
                new SqlParameter("@CompanyID", CompanyID)
                ).ToList();
        }

        public List<Balance> BalanceSelectWarehouse(DateTime BalanceDate, string CompanyID, string AccountID,string AccountDetailID,string CustomerID)
        {
            return this.Context.Database.SqlQuery<Balance>("BalanceSelectWarehouse @BalanceDate, @CompanyID, @AccountID, @AccountDetailID, @CustomerID",
                new SqlParameter("@BalanceDate", BalanceDate),
                new SqlParameter("@CompanyID", CompanyID),
                new SqlParameter("@AccountID", AccountID),
                new SqlParameter("@AccountDetailID", AccountDetailID),
                new SqlParameter("@CustomerID", CustomerID)
                ).ToList();
        }

        public long GetBalanceSEQ()
        {
            return this.GetMaxSEQ(BSServerConst.BalanceSymbol);
        }

        public bool InsertBalance(Balance data)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                new SqlParameter("@BalanceID", data.BalanceID),
                new SqlParameter("@AccountID", data.AccountID),
                new SqlParameter("@AccountDetailID", data.AccountDetailID),
                new SqlParameter("@CustomerID", data.CustomerID),
                new SqlParameter("@CompanyID", data.CompanyID),
                new SqlParameter("@BalanceDate", data.BalanceDate),
                new SqlParameter("@DebitAmount", data.DebitAmount),
                new SqlParameter("@CreditAmount", data.CreditAmount),
                new SqlParameter("@CreateUser", CommonInfo.UserInfo.UserID),
                new SqlParameter("@ItemID", data.ItemID),
                new SqlParameter("@BalanceQuatity", data.BalanceQuatity),
                new SqlParameter("@BalancePrice", data.BalancePrice)
                };
                this.Context.ExecuteDataFromProcedure("BalanceInsert", sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return false;
            }
        }

        public bool UpdateBalance(Balance data)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                new SqlParameter("@BalanceID", data.BalanceID),
                new SqlParameter("@AccountID", data.AccountID),
                new SqlParameter("@AccountDetailID", data.AccountDetailID),
                new SqlParameter("@CustomerID", data.CustomerID),
                new SqlParameter("@CompanyID", data.CompanyID),
                new SqlParameter("@BalanceDate", data.BalanceDate),
                new SqlParameter("@DebitAmount", data.DebitAmount),
                new SqlParameter("@CreditAmount", data.CreditAmount),
                new SqlParameter("@CreateUser", CommonInfo.UserInfo.UserID),
                new SqlParameter("@ItemID", data.ItemID),
                new SqlParameter("@BalanceQuatity", data.BalanceQuatity),
                new SqlParameter("@BalancePrice", data.BalancePrice)
                };
                this.Context.ExecuteDataFromProcedure("BalanceUpdate", sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return false;
            }

        }

        public bool DeleteBalance(Balance data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@BalanceID", data.BalanceID),
                 new SqlParameter("@CompanyID", data.CompanyID),
                new SqlParameter("@CreateUser", CommonInfo.UserInfo.UserID)
            };
            this.Context.ExecuteDataFromProcedure("BalanceDelete", sqlParameters);
            return true;
        }
    }
}

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
    public class AccountsDAO : BaseDAO
    {
        public AccountsDAO(BSContext context) : base(context)
        { }

        public long GetAccountGroupSEQ()
        {
            return this.GetMaxSEQ(BSServerConst.AccountGroupSymbol);
        }

        public long GetGeneralLedgerSEQ()
        {
            return this.GetMaxSEQ(BSServerConst.GeneralLedgerSymbol);
        }

        public List<AccountGroup> GetAccountGroup()
        {
            return this.Context.AccountGroup.OrderBy(o => o.AccountGroupID).ToList();
        }

        public List<Accounts> GetAccounts()
        {
            return this.Context.Accounts.OrderBy(o => o.AccountGroupID).ThenBy(o => o.AccountID).ToList();
        }
        public List<GeneralLedger> GetGeneralLedger()
        {
            return this.Context.GeneralLedger.OrderBy(o => o.GeneralLedgerName).ToList();
        }

        public bool InsertAccountGroup(AccountGroup data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@AccountGroupID", data.AccountGroupID),
                new SqlParameter("@AccountGroupName", data.AccountGroupName),
                new SqlParameter("@UpdateUser", CommonInfo.UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("AccountGroupInsert", sqlParameters);

            return true;
        }

        public bool DeleteAccountGroup(string AccountGroupID)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
               {
                    new SqlParameter("@AccountGroupID", AccountGroupID)
               };

            this.Context.ExecuteDataFromProcedure("AccountGroupDelete", sqlParameters);
            return true;
        }

        public bool UpdateAccountGroup(AccountGroup data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@AccountGroupID", data.AccountGroupID),
                new SqlParameter("@AccountGroupName", data.AccountGroupName),
                new SqlParameter("@UpdateUser", CommonInfo.UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("AccountGroupUpdate", sqlParameters);
            return true;
        }

        public bool InsertAccounts(Accounts data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@AccountID", data.AccountID),
                new SqlParameter("@AccountName", data.AccountName),
                new SqlParameter("@AccountGroupID", data.AccountGroupID),
                new SqlParameter("@AccountLevel", data.AccountLevel),
                new SqlParameter("@ParentID", data.ParentID),
                new SqlParameter("@UpdateUser", CommonInfo.UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("AccountsInsert", sqlParameters);

            return true;
        }

        public bool DeleteAccounts(string AccountID)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
               {
                    new SqlParameter("@AccountID", AccountID),
                    new SqlParameter("@UpdateUser", CommonInfo.UserInfo.UserID)
               };

            this.Context.ExecuteDataFromProcedure("AccountsDelete", sqlParameters);
            return true;
        }

        public bool UpdateAccounts(Accounts data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@AccountID", data.AccountID),
                new SqlParameter("@AccountName", data.AccountName),
                new SqlParameter("@AccountGroupID", data.AccountGroupID),
                new SqlParameter("@AccountLevel", data.AccountLevel),
                new SqlParameter("@ParentID", data.ParentID),
                new SqlParameter("@UpdateUser", CommonInfo.UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("AccountsUpdate", sqlParameters);
            return true;
        }

        public bool InsertGeneralLedger(GeneralLedger data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
            new SqlParameter("@GeneralLedgerID", data.GeneralLedgerID),
            new SqlParameter("@GeneralLedgerName", data.GeneralLedgerName),
            new SqlParameter("@AccountID", data.AccountID),
            new SqlParameter("@CompanyID", data.CompanyID),
            new SqlParameter("@ParentID", data.ParentID),
            new SqlParameter("@UpdateUser", CommonInfo.UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("GeneralLedgerInsert", sqlParameters);

            return true;
        }


        public bool UpdateGeneralLedger(GeneralLedger data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
            new SqlParameter("@GeneralLedgerID", data.GeneralLedgerID),
            new SqlParameter("@GeneralLedgerName", data.GeneralLedgerName),
            new SqlParameter("@AccountID", data.AccountID),
            new SqlParameter("@CompanyID", data.CompanyID),
            new SqlParameter("@ParentID", data.ParentID),
            new SqlParameter("@UpdateUser", CommonInfo.UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("GeneralLedgerUpdate", sqlParameters);

            return true;
        }


        public bool DeleteGeneralLedger(GeneralLedger data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
            new SqlParameter("@GeneralLedgerID", data.GeneralLedgerID),
            new SqlParameter("@UpdateUser", CommonInfo.UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("GeneralLedgerDelete", sqlParameters);

            return true;
        }
    }
}

using BSCommon.Models;
using BSCommon.Utility;
using BSServer._Core.Base;
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

        public List<AccountGroup> GetAccountGroup()
        {
            return this.Context.AccountGroup.OrderBy(o => o.AccountGroupID).ToList();
        }

        public List<Accounts> GetAccounts()
        {
            return this.Context.Accounts.OrderBy(o => o.AccountGroupID).ThenBy(o => o.AccountID).ToList();
        }

        public bool InsertAccountGroup(AccountGroup data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@AccountGroupID", data.AccountGroupID),
                new SqlParameter("@AccountGroupName", data.AccountGroupName),
                new SqlParameter("@UserID", CommonInfo.UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("AccountGroupInsert", sqlParameters);

            return true;
        }

        public bool DeleteAccountGroup(string AccountGroupID)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
               {
                    new SqlParameter("@AccountGroupID", AccountGroupID),
                    new SqlParameter("@UserID", CommonInfo.UserInfo.UserID)
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
                new SqlParameter("@UserID", CommonInfo.UserInfo.UserID)
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
                new SqlParameter("@UserID", CommonInfo.UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("AccountsInsert", sqlParameters);

            return true;
        }

        public bool DeleteAccounts(string AccountID)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
               {
                    new SqlParameter("@AccountID", AccountID),
                    new SqlParameter("@UserID", CommonInfo.UserInfo.UserID)
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
                new SqlParameter("@UserID", CommonInfo.UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("AccountsUpdate", sqlParameters);
            return true;
        }
    }
}

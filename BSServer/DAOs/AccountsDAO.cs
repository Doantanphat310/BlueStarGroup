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

        public List<AccountDetail> GetAccountDetail(string companyId = "")
        {
            return this.Context.AccountDetail
                .Where(o => o.CompanyID == companyId || string.IsNullOrEmpty(companyId))
                .ToList();
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

        public bool DeleteAccountGroup(AccountGroup data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@AccountGroupID", data.AccountGroupID)
            };

            this.Context.ExecuteDataFromProcedure("AccountGroupDelete", sqlParameters);

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
                new SqlParameter("@HachToan", data.HachToan),
                new SqlParameter("@DuNo", data.DuNo),
                new SqlParameter("@DuCo", data.DuCo),
                new SqlParameter("@ThongKe", data.ThongKe),
                new SqlParameter("@NgoaiTe", data.NgoaiTe),
                new SqlParameter("@TK152_156", data.TK152_156),
                new SqlParameter("@VatTu", data.VatTu),
                new SqlParameter("@ThueVAT", data.ThueVAT),
                new SqlParameter("@HopDong", data.HopDong),
                new SqlParameter("@CongNo", data.CongNo),
                new SqlParameter("@UpdateUser", CommonInfo.UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("AccountsInsert", sqlParameters);

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
                new SqlParameter("@HachToan", data.HachToan),
                new SqlParameter("@DuNo", data.DuNo),
                new SqlParameter("@DuCo", data.DuCo),
                new SqlParameter("@ThongKe", data.ThongKe),
                new SqlParameter("@NgoaiTe", data.NgoaiTe),
                new SqlParameter("@TK152_156", data.TK152_156),
                new SqlParameter("@VatTu", data.VatTu),
                new SqlParameter("@ThueVAT", data.ThueVAT),
                new SqlParameter("@HopDong", data.HopDong),
                new SqlParameter("@CongNo", data.CongNo),
                new SqlParameter("@UpdateUser", CommonInfo.UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("AccountsUpdate", sqlParameters);

            return true;
        }

        public bool DeleteAccounts(Accounts data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@AccountID", data.AccountID)
            };

            this.Context.ExecuteDataFromProcedure("AccountsDelete", sqlParameters);

            return true;
        }

        public bool InsertAccountDetail(AccountDetail data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@AccountDetailID", data.AccountDetailID),
                new SqlParameter("@AccountDetailName", data.AccountDetailName),
                new SqlParameter("@AccountID", data.AccountID),
                new SqlParameter("@CompanyID", data.CompanyID),
                new SqlParameter("@UpdateUser", CommonInfo.UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("AccountDetailInsert", sqlParameters);

            return true;
        }

        public bool UpdateAccountDetail(AccountDetail data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@AccountDetailID", data.AccountDetailID),
                new SqlParameter("@AccountDetailName", data.AccountDetailName),
                new SqlParameter("@AccountID", data.AccountID),
                new SqlParameter("@CompanyID", data.CompanyID),
                new SqlParameter("@UpdateUser", CommonInfo.UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("AccountDetailUpdate", sqlParameters);

            return true;
        }

        public bool DeleteAccountDetail(AccountDetail data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@AccountDetailID", data.AccountDetailID)
            };

            this.Context.ExecuteDataFromProcedure("AccountDetailDelete", sqlParameters);

            return true;
        }

        public List<BangCanDoiSoPhatSinhTK> GetBangCanDoiSoPhatSinhTK()
        {
            return this.Context.GetDataFromProcedure<BangCanDoiSoPhatSinhTK>("BangCanDoiSoPhatSinhTKSelect");
        }
    }
}

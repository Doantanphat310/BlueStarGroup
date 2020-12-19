using BSCommon.Models;
using BSServer._Core.Base;
using BSServer.DAOs;
using BSServer.Logics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BSServer.Controllers
{
    public class AccountsController : BaseController
    {

        private AccountsDAO AccountsDAO { get; set; }

        private AccountsLogic AccountsLogic { get; set; }

        public AccountsController()
        {
            this.AccountsDAO = new AccountsDAO(this.Context);
            this.AccountsLogic = new AccountsLogic(this.Context);
        }

        public List<AccountGroup> GetAccountGroup()
        {
            return this.AccountsDAO.GetAccountGroup();
        }

        public List<Accounts> GetAccounts()
        {
            return this.AccountsDAO.GetAccounts();
        }

        public List<AccountDetail> GetAccountDetail(string companyID = "")
        {
            return this.AccountsDAO.GetAccountDetail(companyID);
        }

        public bool SaveAccountGroup(List<AccountGroup> dataList)
        {
            return this.AccountsLogic.SaveAccountGroup(dataList);
        }

        public bool SaveAccounts(List<Accounts> dataList)
        {
            return this.AccountsLogic.SaveAccounts(dataList);
        }

        public bool SaveAccountDetail(List<AccountDetail> dataList)
        {
            return this.AccountsLogic.SaveAccountDetail(dataList);
        }

        public List<GetCanDoiSoPhatSinhTaiKhoan> GetBangCanDoiSoPhatSinhChiTiet(DateTime fromDate, DateTime toDate)
        {
            return this.AccountsLogic.GetBangCanDoiSoPhatSinhChiTiet(fromDate, toDate);
        }

        public List<GetChiTietTaiKhoan> GetChiTietTaiKhoan(string accountID, string accountDetailID, DateTime fromDate, DateTime toDate)
        {
            return this.AccountsDAO.GetChiTietTaiKhoan(accountID, accountDetailID, fromDate, toDate);
        }

        public List<GetChiTietSoCai> GetChiTietSoCai(DateTime fromDate, DateTime toDate)
        {
            return this.AccountsLogic.GetChiTietSoCai(fromDate, toDate);
        }
    }
}

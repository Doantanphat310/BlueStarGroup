using BSCommon.Models;
using BSServer._Core.Base;
using BSServer.DAOs;
using BSServer.Logics;
using System.Collections.Generic;

namespace BSServer.Controllers
{
    public class AccountsController: BaseController
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

        public List<GeneralLedger> GetGeneralLedger()
        {
            return this.AccountsDAO.GetGeneralLedger();
        }

        public bool SaveAccountGroup(List<AccountGroup> dataList)
        {
            return this.AccountsLogic.SaveAccountGroup(dataList);
        }

        public bool SaveAccounts(List<Accounts> dataList)
        {
            return this.AccountsLogic.SaveAccounts(dataList);
        }

        public bool SaveGeneralLedger(List<GeneralLedger> dataList)
        {
            return this.AccountsLogic.SaveGeneralLedger(dataList);
        }

        public List<BangCanDoiSoPhatSinhTK> GetBangCanDoiSoPhatSinhTK()
        {
            return this.AccountsDAO.GetBangCanDoiSoPhatSinhTK();
        }
    }
}

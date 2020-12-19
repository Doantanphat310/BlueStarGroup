using BSCommon.Models;
using BSServer._Core.Context;
using BSServer.DAOs;
using BSServer.Logics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSServer.Controllers
{
  public class BalanceController
    {
        private BSContext Context { get; set; }

        private BalanceLogic BalanceLogic { get; set; }

        private BalanceDAO BalanceDAO { get; set; }

        public BalanceController()
        {
            this.Context = new BSContext();
            this.BalanceDAO = new BalanceDAO(this.Context);
            this.BalanceLogic = new BalanceLogic(this.Context);
        }

        public List<Balance> GetBalance(DateTime balanceDate, string companyID)
        {
            return this.BalanceDAO.GetBalance(balanceDate, companyID);
        }

        public List<Balance> GetBalance(DateTime balanceDate, string companyID, string AccountID, string AccountDetailID, string CustomerID)
        {
            return this.BalanceDAO.BalanceSelectWarehouse(balanceDate, companyID,AccountID,  AccountDetailID,  CustomerID);
        }

        public bool InsertBalance(Balance balance)
        {
            return this.BalanceDAO.InsertBalance(balance);
        }

        public bool UpdateBalance(Balance balance)
        {
            return this.BalanceDAO.UpdateBalance(balance);
        }

        public bool DeleteBalance(Balance balance)
        {
            return this.BalanceDAO.DeleteBalance(balance);
        }

        public bool SaveBalance(List<Balance> dataList)
        {
            return this.BalanceLogic.SaveBalance(dataList);
        }
    }
}

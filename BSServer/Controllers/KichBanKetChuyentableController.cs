using BSCommon.Models;
using BSServer._Core.Context;
using BSServer.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSServer.Controllers
{
    public class KichBanKetChuyentableController
    {
        private BSContext Context { get; set; }

       // private BalanceLogic BalanceLogic { get; set; }

        private KichBanKetChuyentableDAO KichBanKetChuyentableDAO { get; set; }

        public KichBanKetChuyentableController()
        {
            this.Context = new BSContext();
            this.KichBanKetChuyentableDAO = new KichBanKetChuyentableDAO(this.Context);
          //  this.BalanceLogic = new BalanceLogic(this.Context);
        }

        public List<KichBanKetChuyentable> KichBanKetChuyentableSelect(string companyID)
        {
            return this.KichBanKetChuyentableDAO.KichBanKetChuyentableSelect(companyID);
        }

        //public List<Balance> GetBalance(DateTime balanceDate, string companyID, string AccountID, string AccountDetailID, string CustomerID)
        //{
        //    return this.BalanceDAO.BalanceSelectWarehouse(balanceDate, companyID, AccountID, AccountDetailID, CustomerID);
        //}

        //public bool InsertBalance(Balance balance)
        //{
        //    return this.BalanceDAO.InsertBalance(balance);
        //}

        //public bool UpdateBalance(Balance balance)
        //{
        //    return this.BalanceDAO.UpdateBalance(balance);
        //}

        //public bool DeleteBalance(Balance balance)
        //{
        //    return this.BalanceDAO.DeleteBalance(balance);
        //}

        //public bool SaveBalance(List<Balance> dataList)
        //{
        //    return this.BalanceLogic.SaveBalance(dataList);
        //}
    }
}

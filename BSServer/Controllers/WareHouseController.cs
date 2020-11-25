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
  public class WareHouseController
    {
        private BSContext Context { get; set; }

        private WareHouseLogic WareHouseLogic { get; set; }

        private WareHouseDAO WareHouseDAO { get; set; }

        public WareHouseController()
        {
            this.Context = new BSContext();
            this.WareHouseDAO = new WareHouseDAO(this.Context);
            this.WareHouseLogic = new WareHouseLogic(this.Context);
        }

        public List<WareHouse> GetWareHouseSelectVoucherID(string voucherID, string companyID)
        {
            return this.WareHouseDAO.GetWareHouseSelectVoucherID(voucherID, companyID);
        }

        public List<WareHouse> GetWareHouseSelectInvoiceID(string invoiceID, string companyID)
        {
            return this.WareHouseDAO.GetWareWareHouseSelectInvoiceID(invoiceID, companyID);
        }


        public bool InsertInvoice(WareHouse WareHouse)
        {
            return this.WareHouseDAO.InsertWareHouse(WareHouse);
        }

        public bool UpdateWareHouse(WareHouse WareHouse)
        {
            return this.WareHouseDAO.UpdateWareHouse(WareHouse);
        }

        public bool DeleteWareHouseDetail(string WareHouseID, string companyID)
        {
            return this.WareHouseDAO.DeleteWareHouse(WareHouseID, companyID);
        }

        public bool SaveWareHouse(List<WareHouse> dataList)
        {
            return this.WareHouseLogic.SaveWareHouse(dataList);
        }
    }
}

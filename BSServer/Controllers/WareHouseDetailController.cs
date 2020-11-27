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
   public class WareHouseDetailController
    {
        private BSContext Context { get; set; }

        private WareHouseDetailLogic WareHouseDetailLogic { get; set; }

        private WareHouseDetailDAO  WareHouseDetailDAO { get; set; }

        public WareHouseDetailController()
        {
            this.Context = new BSContext();
            this.WareHouseDetailDAO = new WareHouseDetailDAO(this.Context);
            this.WareHouseDetailLogic = new WareHouseDetailLogic(this.Context);
        }

        public List<WareHouseDetail> GetWareHouseDetailSelect(string warehouseDetailID, string companyID)
        {
            return this.WareHouseDetailDAO.GetWareHouseDetailSelect(warehouseDetailID, companyID);
        }

        

        public List<WareHouseDetail> GetWareHouseDetailSelectWahouseID(string warehouseID, string companyID)
        {
            return this.WareHouseDetailDAO.GetWareHouseDetailSelectWahouseID(warehouseID, companyID);
        }

        public bool InsertWareHouseDetail(WareHouseDetail WareHouseDetail)
        {
            return this.WareHouseDetailDAO.InsertWareHouseDetail(WareHouseDetail);
        }

        public bool UpdateWareHouseDetail(WareHouseDetail WareHouseDetail)
        {
            return this.WareHouseDetailDAO.UpdateWareHouseDetail(WareHouseDetail);
        }

        public bool DeleteWareHouseDetail(string WareHouseDetailID, string companyID)
        {
            return this.WareHouseDetailDAO.DeleteWareHouseDetail(WareHouseDetailID, companyID);
        }

        public bool SaveWareHouseDetail(List<WareHouseDetail> dataList)
        {
            return this.WareHouseDetailLogic.SaveWareHouseDetail(dataList);
        }
    }
}

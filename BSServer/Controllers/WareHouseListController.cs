using BSCommon.Models;
using BSCommon.Utility;
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
    public class WareHouseListController
    {
        private _Core.Context.BSContext Context { get; set; }

        private WareHouseListLogic WareHouseListLogic { get; set; }

        private WareHouseListDAO WareHouseListDAO { get; set; }

        public WareHouseListController()
        {
            this.Context = new BSContext();
            this.WareHouseListDAO = new WareHouseListDAO(this.Context);
            this.WareHouseListLogic = new WareHouseListLogic(this.Context);
        }

        public List<WarehouseList> GetWareHouseListSelect(string companyID)
        {
            return this.WareHouseListDAO.GetWareHouseListSelect(companyID);
        }
        
        public bool InsertWareHouseList(WarehouseList WareHouseList)
        {
            return this.WareHouseListDAO.InsertWareHouseList(WareHouseList);
        }
        
        public bool DeleteWareHouseList(WarehouseList WareHouseList)
        {
            return this.WareHouseListDAO.DeleteWareHouseList(WareHouseList.WarehouseListID, CommonInfo.CompanyInfo.CompanyID);
        }

        public bool UpdateWareHouseList(WarehouseList WareHouseList)
        {
            return this.WareHouseListDAO.UpdateWareHouseList(WareHouseList);
        }

        public bool SaveWareHouseList(List<WarehouseList> dataList)
        {
            return this.WareHouseListLogic.SaveWareHouseList(dataList);
        }
    }
}

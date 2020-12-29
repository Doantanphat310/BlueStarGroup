using BSCommon.Models;
using BSServer._Core.Base;
using BSServer._Core.Context;
using BSServer.DAOs;
using BSServer.Logics;
using System.Collections.Generic;

namespace BSServer.Controllers
{
    public class ItemsController: BaseController
    {
        private ItemsDAO ItemsDAO { get; set; }

        private ItemsLogic ItemsLogic { get; set; }

        public ItemsController()
        {
            this.ItemsDAO = new ItemsDAO(this.Context);
            this.ItemsLogic = new ItemsLogic(this.Context);
        }

        public List<ItemType> GetItemType()
        {
            return this.ItemsDAO.GetItemType();
        }

        public List<Items> GetItems()
        {
            return this.ItemsDAO.GetItems();
        }

        public List<ItemUnit> GetItemUnit()
        {
            return this.ItemsDAO.GetItemUnit();
        }

        public bool SaveItemType(List<ItemType> dataList)
        {
            return this.ItemsLogic.SaveItemType(dataList);
        }

        public bool SaveItems(List<Items> dataList)
        {
            return this.ItemsLogic.SaveItems(dataList);
        }

        public bool SaveItemUnit(List<ItemUnit> dataList)
        {
            return this.ItemsLogic.SaveItemUnit(dataList);
        }
    }
}

using BSCommon.Models;
using BSServer._Core.Base;
using BSServer._Core.Context;
using BSServer.DAOs;
using BSServer.Logics;
using System;
using System.Collections.Generic;

namespace BSServer.Controllers
{
    public class ItemsController: BaseController
    {
        private BSContext Context { get; set; }

        private ItemsDAO ItemsDAO { get; set; }

        private ItemsLogic ItemsLogic { get; set; }

        public ItemsController()
        {
            this.Context = new BSContext();
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

        public List<ItemPriceCompany> GetItemsCompany()
        {
            return this.ItemsDAO.GetItemsCompany();
        }

        public bool InsertItems(Items items)
        {
            return this.ItemsDAO.InsertItems(items);
        }

        public bool UpdateUser(Items items)
        {
            return this.ItemsDAO.UpdateItems(items);
        }

        public bool DeleteUser(string itemsID)
        {
            return this.ItemsDAO.DeleteItems(itemsID);
        }

        public bool SaveItemType(List<ItemType> dataList)
        {
            return this.ItemsLogic.SaveItemType(dataList);
        }

        public bool SaveItems(List<Items> dataList)
        {
            return this.ItemsLogic.SaveItems(dataList);
        }

        public bool SaveItemsCompany(List<ItemPriceCompany> dataList)
        {
            return this.ItemsLogic.SaveItemsCompany(dataList);
        }
    }
}

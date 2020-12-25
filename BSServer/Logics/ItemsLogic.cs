﻿using BSCommon.Constant;
using BSCommon.Models;
using BSServer._Core.Base;
using BSServer._Core.Context;
using BSServer._Core.Utility;
using BSServer.DAOs;
using System.Collections.Generic;
using System.Data.Entity;

namespace BSServer.Logics
{
    public class ItemsLogic : BaseLogic
    {
        public ItemsLogic(BSContext context) : base(context)
        {
            this.Context = context;
            this.ItemsDAO = new ItemsDAO(this.Context);
        }

        private ItemsDAO ItemsDAO { get; set; }

        public bool SaveItemType(List<ItemType> saveData)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    long seq = this.ItemsDAO.GetItemTypeSEQ();
                    foreach (ItemType data in saveData)
                    {
                        switch (data.Status)
                        {
                            // Add new
                            case ModifyMode.Insert:
                                seq++;
                                data.ItemTypeID = GenerateID.ItemTypeID(seq);

                                this.ItemsDAO.InsertItemType(data);
                                break;

                            // Update
                            case ModifyMode.Update:
                                this.ItemsDAO.UpdateItemType(data);
                                break;

                            // Delete
                            case ModifyMode.Delete:
                                this.ItemsDAO.DeleteItemType(data);
                                break;
                        }
                    }

                    transaction.Commit();

                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool SaveItems(List<Items> saveData)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    long seq = this.ItemsDAO.GetItemSEQ();
                    foreach (Items data in saveData)
                    {
                        switch (data.Status)
                        {
                            // Add new
                            case ModifyMode.Insert:
                                seq++;
                                data.ItemID = GenerateID.ItemID(seq);

                                this.ItemsDAO.InsertItems(data);
                                break;

                            // Update
                            case ModifyMode.Update:
                                this.ItemsDAO.UpdateItems(data);
                                break;

                            // Delete
                            case ModifyMode.Delete:
                                this.ItemsDAO.DeleteItems(data);
                                break;
                        }
                    }

                    transaction.Commit();

                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool SaveItemsCompany(List<ItemPriceCompany> saveData)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    foreach (ItemPriceCompany data in saveData)
                    {
                        switch (data.Status)
                        {
                            // Add new
                            case ModifyMode.Insert:
                                this.ItemsDAO.InsertItemPriceCompany(data);
                                break;

                            // Update
                            case ModifyMode.Update:
                                this.ItemsDAO.UpdateItemPriceCompany(data);
                                break;

                            // Delete
                            case ModifyMode.Delete:
                                this.ItemsDAO.DeleteItemPriceCompany(data);
                                break;
                        }
                    }

                    transaction.Commit();

                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }
}

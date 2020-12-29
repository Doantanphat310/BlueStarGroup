using BSCommon.Constant;
using BSCommon.Models;
using BSCommon.Utility;
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

                                this.ItemsDAO.InsertItemPriceCompany(new ItemPriceCompany
                                {
                                    CompanyID = CommonInfo.CompanyInfo.CompanyID,
                                    ItemID = data.ItemID,
                                    ItemPrice = data.ItemPrice
                                });

                                break;

                            // Update
                            case ModifyMode.Update:
                                this.ItemsDAO.UpdateItems(data);

                                this.ItemsDAO.UpdateItemPriceCompany(new ItemPriceCompany
                                {
                                    CompanyID = CommonInfo.CompanyInfo.CompanyID,
                                    ItemID = data.ItemID,
                                    ItemPrice = data.ItemPrice
                                });

                                break;

                            // Delete
                            case ModifyMode.Delete:
                                this.ItemsDAO.DeleteItems(data);

                                this.ItemsDAO.DeleteItemPriceCompany(new ItemPriceCompany
                                {
                                    CompanyID = CommonInfo.CompanyInfo.CompanyID,
                                    ItemID = data.ItemID,
                                    ItemPrice = data.ItemPrice
                                });

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

        public bool SaveItemUnit(List<ItemUnit> saveData)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    foreach (ItemUnit data in saveData)
                    {
                        switch (data.Status)
                        {
                            // Add new
                            case ModifyMode.Insert:
                                this.ItemsDAO.InsertItemUnit(data);
                                break;

                            // Update
                            case ModifyMode.Update:
                                this.ItemsDAO.UpdateItemUnit(data);
                                break;

                            // Delete
                            case ModifyMode.Delete:
                                this.ItemsDAO.DeleteItemUnit(data);
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

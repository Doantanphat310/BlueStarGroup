using BSCommon.Constant;
using BSCommon.Models;
using BSServer._Core.Context;
using BSServer._Core.Utility;
using BSServer.DAOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSServer.Logics
{
  public  class InvoiceLogic
    {
        public InvoiceLogic(BSContext context)
        {
            this.Context = context;
            this.InvoiceDAO = new InvoiceDAO(this.Context);
            this.WareHouseDAO = new WareHouseDAO(this.Context);
            this.WareHouseDetailDAO = new WareHouseDetailDAO(this.Context);
        }

        private BSContext Context { get; set; }

        private InvoiceDAO InvoiceDAO { get; set; }

        private WareHouseDAO WareHouseDAO { get; set; }

        private WareHouseDetailDAO WareHouseDetailDAO { get; set; }

        public bool SaveInvoice(List<Invoice> saveData)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    long seq = InvoiceDAO.GetInvoiceSEQ();
                    foreach (Invoice data in saveData)
                    {
                        switch (data.Status)
                        {
                            // Add new
                            case ModifyMode.Insert:
                                seq++;
                                data.InvoiceID = GenerateID.InvoiceID(seq);
                                this.InvoiceDAO.InsertInvoice(data);
                                break;

                            // Update
                            case ModifyMode.Update:
                                this.InvoiceDAO.UpdateInvoice(data);
                                break;

                            // Delete
                            case ModifyMode.Delete:
                                this.InvoiceDAO.DeleteInvoice(data.InvoiceID, data.CompanyID);
                                break;
                        }
                    }

                    transaction.Commit();

                    return true;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    Console.WriteLine("Update data fail.\r\n" + e.Message);
                    return false;
                }
            }
        }

        public bool SaveInvoiceExcel(Invoice data, List<WareHouseDetail> detailData)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    long seq = InvoiceDAO.GetInvoiceSEQ();
                    long seqWareHouse =  WareHouseDAO.GetWareHouseSEQ();
                    long seqWareHouseDetail = WareHouseDetailDAO.GetWareHouseDetailSEQ();
                    
                        switch (data.Status)
                        {
                            // Add new
                            case ModifyMode.Insert:
                                seq++;
                                data.InvoiceID = GenerateID.InvoiceID(seq);
                                this.InvoiceDAO.InsertInvoice(data);
                            if(detailData.Count > 0)
                            {
                                //thêm warehousedata
                                #region insert warehouseData

                                WareHouse wareHouseItem = new WareHouse();
                                wareHouseItem.CompanyID = data.CompanyID;
                                wareHouseItem.InvoiceID = data.InvoiceID;
                                wareHouseItem.CustomerID = data.CustomerID;
                                wareHouseItem.Type = "X";

                                seqWareHouse++;
                                wareHouseItem.WarehouseID = GenerateID.WareHouseID(seqWareHouse);
                                this.WareHouseDAO.InsertWareHouse(wareHouseItem);

                                #endregion insert warehouseData
                                #region insert warehouseDetail
                                foreach (WareHouseDetail wareHouseDetail in detailData)
                                {
                                    if (string.IsNullOrEmpty(wareHouseDetail.WarehouseID))
                                    {
                                        wareHouseDetail.WarehouseID = wareHouseItem.WarehouseID;
                                        wareHouseDetail.CompanyID = wareHouseItem.CompanyID;
                                        seqWareHouseDetail++;
                                        wareHouseDetail.WareHouseDetailID = GenerateID.WareHouseDetailID(seqWareHouseDetail);
                                        this.WareHouseDetailDAO.InsertWareHouseDetail(wareHouseDetail);
                                    }
                                }
                                #endregion insert warehouseDetail
                            }
                            break;
                            // Update
                            case ModifyMode.Update:
                                this.InvoiceDAO.UpdateInvoice(data);
                                break;

                            // Delete
                            case ModifyMode.Delete:
                                this.InvoiceDAO.DeleteInvoice(data.InvoiceID, data.CompanyID);
                                break;
                        }
                    transaction.Commit();

                    return true;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    Console.WriteLine("Update data fail.\r\n" + e.Message);
                    return false;
                }
            }
        }

    }
}

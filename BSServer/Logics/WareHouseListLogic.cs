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
  public  class WareHouseListLogic
    {
        public WareHouseListLogic(BSContext context)
        {
            this.Context = context;
            this.WareHouseListDAO = new WareHouseListDAO(this.Context);
        }

        private BSContext Context { get; set; }

        private WareHouseListDAO WareHouseListDAO { get; set; }

        public bool SaveWareHouseList(List<WarehouseList> saveData)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    long seq = WareHouseListDAO.GetWareHouseListSEQ();
                    foreach (WarehouseList data in saveData)
                    {
                        switch (data.Status)
                        {
                            // Add new
                            case ModifyMode.Insert:
                                seq++;
                                data.WarehouseListID = GenerateID.WareHouseListID(seq);
                                this.WareHouseListDAO.InsertWareHouseList(data);
                                break;
                            // Update
                            case ModifyMode.Update:
                                this.WareHouseListDAO.UpdateWareHouseList(data);
                                break;
                            // Delete
                            case ModifyMode.Delete:
                                this.WareHouseListDAO.DeleteWareHouseList(data.WarehouseListID, data.CompanyID);
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
    }
}

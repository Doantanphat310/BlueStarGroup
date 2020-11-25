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
   public class WareHouseLogic
    {
        public WareHouseLogic(BSContext context)
        {
            this.Context = context;
            this.WareHouseDAO = new WareHouseDAO(this.Context);
        }

        private BSContext Context { get; set; }

        private WareHouseDAO WareHouseDAO { get; set; }

        public bool SaveWareHouse(List<WareHouse> saveData)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    long seq = WareHouseDAO.GetWareHouseSEQ();
                    foreach (WareHouse data in saveData)
                    {
                        switch (data.Status)
                        {
                            // Add new
                            case ModifyMode.Insert:
                                seq++;
                                data.WarehouseID = GenerateID.WareHouseID(seq);
                                this.WareHouseDAO.InsertWareHouse(data);
                                break;
                            // Update
                            case ModifyMode.Update:
                                this.WareHouseDAO.UpdateWareHouse(data);
                                break;
                            // Delete
                            case ModifyMode.Delete:
                                this.WareHouseDAO.DeleteWareHouse(data.WarehouseID, data.CompanyID);
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

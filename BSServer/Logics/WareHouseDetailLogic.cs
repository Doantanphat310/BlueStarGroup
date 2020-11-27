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
    public class WareHouseDetailLogic
    {
        public WareHouseDetailLogic(BSContext context)
        {
            this.Context = context;
            this.WareHouseDetailDAO = new WareHouseDetailDAO(this.Context);
        }

        private BSContext Context { get; set; }

        private WareHouseDetailDAO WareHouseDetailDAO { get; set; }

        public bool SaveWareHouseDetail(List<WareHouseDetail> saveData)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    long seq = WareHouseDetailDAO.GetWareHouseDetailSEQ();
                    foreach (WareHouseDetail data in saveData)
                    {
                        switch (data.Status)
                        {
                            // Add new
                            case ModifyMode.Insert:
                                seq++;
                                data.WareHouseDetailID = GenerateID.WareHouseDetailID(seq);
                                this.WareHouseDetailDAO.InsertWareHouseDetail(data);
                                break;
                            // Update
                            case ModifyMode.Update:
                                this.WareHouseDetailDAO.UpdateWareHouseDetail(data);
                                break;
                            // Delete
                            case ModifyMode.Delete:
                                this.WareHouseDetailDAO.DeleteWareHouseDetail(data.WareHouseDetailID, data.CompanyID);
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

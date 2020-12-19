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
   public class BalanceLogic
    {
        public BalanceLogic(BSContext context)
        {
            this.Context = context;
            this.BalanceDAO = new BalanceDAO(this.Context);
        }
        private BSContext Context { get; set; }
        private BalanceDAO BalanceDAO { get; set; }
        public bool SaveBalance(List<Balance> saveData)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    long seq = BalanceDAO.GetBalanceSEQ();
                    foreach (Balance data in saveData)
                    {
                        switch (data.Status)
                        {
                            // Add new
                            case ModifyMode.Insert:
                                seq++;
                                data.BalanceID = GenerateID.BalanceID(seq);
                                this.BalanceDAO.InsertBalance(data);
                                break;
                            // Update
                            case ModifyMode.Update:
                                this.BalanceDAO.UpdateBalance(data);
                                break;
                            // Delete
                            case ModifyMode.Delete:
                                this.BalanceDAO.DeleteBalance(data);
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

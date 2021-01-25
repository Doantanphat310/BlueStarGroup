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
  public class LockDBCompanyLogic
    {
        public LockDBCompanyLogic(BSContext context)
        {
            this.Context = context;
            this.LockDBCompanyDAO = new LockDBCompanyDAO(this.Context);
        }
        private BSContext Context { get; set; }
        private LockDBCompanyDAO LockDBCompanyDAO { get; set; }
        public bool SaveLockDB(List<LockDBCompany> saveData)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    long seq = LockDBCompanyDAO.GetLockDBCompanySEQ();
                    foreach (LockDBCompany data in saveData)
                    {
                        switch (data.Status)
                        {
                            // Add new
                            case ModifyMode.Insert:
                                seq++;
                                data.ClockDBID = GenerateID.LockDBID(seq);
                                this.LockDBCompanyDAO.InsertLockDB(data);
                                break;
                            // Update
                            case ModifyMode.Update:
                                this.LockDBCompanyDAO.UpdateLockDB(data);
                                break;
                            // Delete
                            case ModifyMode.Delete:
                                this.LockDBCompanyDAO.DeleteLockDB(data);
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

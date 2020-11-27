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
    public class DepreciationLogic
    {
        public DepreciationLogic(BSContext context)
        {
            this.Context = context;
            this.DepreciationDAO = new DepreciationDAO(this.Context);
        }

        private BSContext Context { get; set; }

        private DepreciationDAO DepreciationDAO { get; set; }

        public bool SaveDepreciation(List<Depreciation> saveData)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    long seq = DepreciationDAO.GetDepreciationSEQ();
                    foreach (Depreciation data in saveData)
                    {
                        switch (data.StatusA)
                        {
                            // Add new
                            case ModifyMode.Insert:
                                seq++;
                                data.DepreciationID = GenerateID.DepreciationID(seq);
                                this.DepreciationDAO.InsertDepreciation(data);
                                break;
                            // Update
                            case ModifyMode.Update:
                                this.DepreciationDAO.UpdateDepreciation(data);
                                break;
                            // Delete
                            case ModifyMode.Delete:
                                this.DepreciationDAO.DeleteDepreciation(data.DepreciationID, data.CompanyID);
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

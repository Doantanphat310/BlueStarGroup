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
    public class DepreciationDetailLogic
    {
        public DepreciationDetailLogic(BSContext context)
        {
            this.Context = context;
            this.DepreciationDetailDAO = new DepreciationDetailDAO(this.Context);
        }

        private BSContext Context { get; set; }

        private DepreciationDetailDAO DepreciationDetailDAO { get; set; }

        public bool SaveDepreciationDetail(List<DepreciationDetail> saveData)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    long seq = DepreciationDetailDAO.GetDepreciationDetailSEQ();
                    foreach (DepreciationDetail data in saveData)
                    {
                        switch (data.StatusA)
                        {
                            // Add new
                            case ModifyMode.Insert:
                                seq++;
                                data.DepreciationDetailID = GenerateID.DepreciationDetailID(seq);
                                this.DepreciationDetailDAO.InsertDepreciationDetail(data);
                                break;
                            // Update
                            case ModifyMode.Update:
                                this.DepreciationDetailDAO.UpdateDepreciationDetail(data);
                                break;
                            // Delete
                            case ModifyMode.Delete:
                                this.DepreciationDetailDAO.DeleteDepreciationDetail(data.DepreciationDetailID, data.CompanyID);
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

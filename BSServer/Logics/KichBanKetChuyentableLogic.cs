using BSCommon.Constant;
using BSCommon.Models;
using BSServer._Core.Context;
using BSServer.DAOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSServer.Logics
{
    public class KichBanKetChuyentableLogic
    {
        public KichBanKetChuyentableLogic(BSContext context)
        {
            this.Context = context;
            this.KichBanKetChuyentableDAO = new KichBanKetChuyentableDAO(this.Context);
        }
        private BSContext Context { get; set; }
        private KichBanKetChuyentableDAO KichBanKetChuyentableDAO { get; set; }
        public bool SaveKichBanKetChuyentable(List<KichBanKetChuyentable> saveData)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    foreach (KichBanKetChuyentable data in saveData)
                    {
                        switch (data.Status)
                        {
                            // Add new
                            case ModifyMode.Insert:
                                this.KichBanKetChuyentableDAO.InsertKichBanKetChuyentable(data);
                                break;
                            // Delete
                            case ModifyMode.Delete:
                                this.KichBanKetChuyentableDAO.DeleteKichBanKetChuyentable(data);
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

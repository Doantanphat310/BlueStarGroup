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
   public  class VoucherDetailLogic
    {
        public VoucherDetailLogic(BSContext context)
        {
            this.Context = context;
            this.VoucherDetailDAO = new VoucherDetailDAO(this.Context);
        }

        private BSContext Context { get; set; }

        private VoucherDetailDAO VoucherDetailDAO { get; set; }

        public bool SaveVoucherDetail(List<VoucherDetail> saveData)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    foreach (VoucherDetail data in saveData)
                    {
                        switch (data.Status)
                        {
                            // Add new
                            case ModifyMode.Insert:
                                this.VoucherDetailDAO.InsertVouchersDetail(data);
                                break;

                            // Update
                            case ModifyMode.Update:
                                this.VoucherDetailDAO.UpdateVoucherDetail(data);
                                break;

                            // Delete
                            case ModifyMode.Delete:
                                this.VoucherDetailDAO.DeleteVoucherDetail(data.VouchersDetailID,data.CompanyID);
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

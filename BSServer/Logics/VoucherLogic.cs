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
    public class VoucherLogic
    {
        public VoucherLogic(BSContext context)
        {
            this.Context = context;
            this.VoucherDAO = new VoucherDAO(this.Context);
        }

        private BSContext Context { get; set; }

        private VoucherDAO VoucherDAO { get; set; }

        public bool SaveVouchersCompany(List<VouchersInsert> vouchersInsert)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    foreach (VouchersInsert voucher in vouchersInsert)
                    {
                        switch (voucher.Status)
                        {
                            // Add new
                            case 1:
                                this.VoucherDAO.InsertVouchersCompany(voucher);
                                break;

                            // Update
                            case 2:
                                this.VoucherDAO.UpdateVouchersCompany(voucher);
                                break;

                            // Delete
                            case 3:
                                this.VoucherDAO.DeleteVouchersCompany(voucher);
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

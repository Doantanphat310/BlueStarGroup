﻿using BSCommon.Constant;
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

        public bool SaveVoucher(List<Voucher> saveData)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    foreach (Voucher data in saveData)
                    {
                        switch (data.Status)
                        {
                            // Add new
                            case ModifyMode.Insert:
                                this.VoucherDAO.InsertVouchers(data);
                                break;

                            // Update
                            case ModifyMode.Update:
                                this.VoucherDAO.UpdateVoucher(data);
                                break;

                            // Delete
                            case ModifyMode.Delete:
                                this.VoucherDAO.DeleteVoucher(data.VouchersID,data.CompanyID);
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

﻿using BSCommon.Constant;
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
  public  class InvoiceLogic
    {
        public InvoiceLogic(BSContext context)
        {
            this.Context = context;
            this.InvoiceDAO = new InvoiceDAO(this.Context);
        }

        private BSContext Context { get; set; }

        private InvoiceDAO InvoiceDAO { get; set; }

        public bool SaveInvoice(List<Invoice> saveData)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    long seq = InvoiceDAO.GetInvoiceSEQ();
                    foreach (Invoice data in saveData)
                    {
                        switch (data.Status)
                        {
                            // Add new
                            case ModifyMode.Insert:
                                seq++;
                                data.InvoiceID = GenerateID.InvoiceID(seq);
                                this.InvoiceDAO.InsertInvoice(data);
                                break;

                            // Update
                            case ModifyMode.Update:
                                this.InvoiceDAO.UpdateInvoice(data);
                                break;

                            // Delete
                            case ModifyMode.Delete:
                                this.InvoiceDAO.DeleteInvoice(data.InvoiceID, data.CompanyID);
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

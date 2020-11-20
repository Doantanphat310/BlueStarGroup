﻿using BSCommon.Models;
using BSServer._Core.Context;
using BSServer.DAOs;
using BSServer.Logics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSServer.Controllers
{
   public class InvoiceController
    {

        private BSContext Context { get; set; }

        private InvoiceLogic InvoiceLogic { get; set; }

        private InvoiceDAO InvoiceDAO { get; set; }

        public InvoiceController()
        {
            this.Context = new BSContext();
            this.InvoiceDAO = new InvoiceDAO(this.Context);
            this.InvoiceLogic = new InvoiceLogic(this.Context);
        }

        public List<Invoice> GetInvoiceSelectVoucherID(string voucherID, string companyID)
        {
            return this.InvoiceDAO.GetInvoiceSelectVoucherID(voucherID, companyID);
        }


        public bool InsertInvoice(Invoice Invoice)
        {
            return this.InvoiceDAO.InsertInvoice(Invoice);
        }

        public bool UpdateInvoice(Invoice Invoice)
        {
            return this.InvoiceDAO.UpdateInvoice(Invoice);
        }

        public bool DeleteVoucherDetail(string invoiceID, string companyID)
        {
            return this.InvoiceDAO.DeleteInvoice(invoiceID, companyID);
        }

        public bool SaveVoucherDetail(List<Invoice> dataList)
        {
            return this.InvoiceLogic.SaveInvoice(dataList);
        }
    }
}

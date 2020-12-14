using BSCommon.Models;
using BSServer._Core.Context;
using BSServer.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSServer.Controllers
{
    public class MaterialNVController
    {
        private BSContext Context { get; set; }
        private MaterialNVDAO MaterialNVDAO { get; set; }
        public MaterialNVController()
        {
            this.Context = new BSContext();
            this.Context.Database.Log = Console.Write;
            this.MaterialNVDAO = new MaterialNVDAO(this.Context);
        }
        public List<MaterialNV> GetMaterialNV()
        {
            return this.MaterialNVDAO.GetMaterialNV();
        }

        public List<MaterialInvoiceType> GetMaterialInvoiceType()
        {
            return this.MaterialNVDAO.GetMaterialInvoiceType();
        }

        public List<MaterialWareHouseType> GetMaterialWareHouseType()
        {
            return this.MaterialNVDAO.GetMaterialWareHouseType();
        }

        public List<MaterialTK> GetMaterialTK(string companyID)
        {
            return this.MaterialNVDAO.GetMaterialTK(companyID);
        }

        public List<MaterialDT> GetMaterialDT( string companyID)
        {
            return this.MaterialNVDAO.GetMaterialDT(companyID);
        }


        public List<MaterialCustomerInvoice> GetMaterialCustomerInvoice(string customerID)
        {
            return this.MaterialNVDAO.GetMaterialCustomerInvoice(customerID);
        }

        public List<MaterialCheck> GetMaterialCheck(string accountID, string GLID)
        {
            return this.MaterialNVDAO.GetMaterialCheck(accountID,GLID);
        }

        public List<MaterialCheck> GetMaterialCheckInvoiceNo(string InvoiceID,string CustomerID, string InvoiceFormNo, string FormNo, string SerialNo, string InvoiceNo)
        {
            return this.MaterialNVDAO.GetMaterialCheckInvoiceNo(InvoiceID,CustomerID, InvoiceFormNo,FormNo,SerialNo,InvoiceNo);
        }

        public void Dispose()
        {
        }
    }
}

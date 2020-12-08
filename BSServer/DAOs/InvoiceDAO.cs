using BSCommon.Models;
using BSCommon.Utility;
using BSServer._Core.Base;
using BSServer._Core.Const;
using BSServer._Core.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSServer.DAOs
{
    public class InvoiceDAO : BaseDAO
    {
        public InvoiceDAO(BSContext context) : base(context)
        {
        }

        public List<Invoice> GetInvoiceSelectVoucherID(string voucherID, string CompanyID)
        {
            return this.Context.Database.SqlQuery<Invoice>(
          "InvoiceSelectVoucherID @VouchersID, @CompanyID, @CreateUser",
          new SqlParameter("@VouchersID", voucherID),
          new SqlParameter("@CompanyID", CompanyID),
          new SqlParameter("@CreateUser", CommonInfo.UserInfo.UserName)
          ).ToList();
        }

        public List<Invoice> GetInvoiceSameDaySamCustomer(string CompanyID)
        {
            return this.Context.Database.SqlQuery<Invoice>(
          "InvoiceSameDaySamCustomer @CompanyID",
          new SqlParameter("@CompanyID", CompanyID)
          ).ToList();
        }

        public long GetInvoiceSEQ()
        {
            return this.GetMaxSEQ(BSServerConst.InvoiceSymbol);
        }

        public bool InsertInvoice(Invoice invoice)
        {

            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@InvoiceID", invoice.InvoiceID),
                    new SqlParameter("@VouchersID", invoice.VouchersID),
                    new SqlParameter("@CustomerID", invoice.CustomerID),
                    new SqlParameter("@Description", invoice.Description),
                    new SqlParameter("@MaSo",invoice.InvoiceFormNo?? (object)DBNull.Value),
                    new SqlParameter("@MauSo", invoice.FormNo),
                    new SqlParameter("@KyHieu", invoice.SerialNo),
                    new SqlParameter("@InvoiceNo", invoice.InvoiceNo),
                    new SqlParameter("@InvoiceType", invoice.InvoiceType),
                    new SqlParameter("@InvoiceDate", invoice.InvoiceDate),
                    new SqlParameter("@Amount", invoice.Amount),
                    new SqlParameter("@VAT",  invoice.VAT.ToString("000.00")),
                    new SqlParameter("@Discounts", invoice.Discounts),
                    new SqlParameter("@CreateUser", CommonInfo.UserInfo.UserID),
                    new SqlParameter("@CompanyID", invoice.CompanyID),
                };
                this.Context.ExecuteDataFromProcedure("InvoiceInsert", sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert Invoice Fail! " + ex.Message);
                return false;
            }
        }

        public bool DeleteInvoice(string InvoiceID, string CompanyID)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
               {
                    new SqlParameter("@InvoiceID", InvoiceID),
                    new SqlParameter("@CreateUser", CommonInfo.UserInfo.UserID),
                    new SqlParameter("@CompanyID", CompanyID)
                    
               };

                this.Context.ExecuteDataFromProcedure("InvoiceDelete", sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete Invoice Fail! " + ex.Message);
                return false;
            }
        }


        public bool UpdateInvoice(Invoice invoice)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@InvoiceID", invoice.InvoiceID),
                    new SqlParameter("@CustomerID", invoice.CustomerID),
                    new SqlParameter("@Description", invoice.Description),
                    new SqlParameter("@MaSo",invoice.InvoiceFormNo?? (object)DBNull.Value),
                    new SqlParameter("@MauSo", invoice.FormNo),
                    new SqlParameter("@KyHieu", invoice.SerialNo),
                    new SqlParameter("@InvoiceNo", invoice.InvoiceNo),
                    new SqlParameter("@InvoiceType", invoice.InvoiceType),
                    new SqlParameter("@InvoiceDate", invoice.InvoiceDate),
                    new SqlParameter("@Amount", invoice.Amount),
                    new SqlParameter("@VAT", invoice.VAT),
                    new SqlParameter("@Discounts", invoice.Discounts),
                    new SqlParameter("@CreateUser", CommonInfo.UserInfo.UserID),
                    new SqlParameter("@CompanyID", invoice.CompanyID)
                };

                this.Context.ExecuteDataFromProcedure("InvoiceUpdate", sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update Invoice Fail! " + ex.Message);
                return false;
            }
        }
    }
}

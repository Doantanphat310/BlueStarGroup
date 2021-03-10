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
          new SqlParameter("@CreateUser", UserInfo.UserID)
          ).ToList();
        }

        public List<Invoice> GetInvoiceSameDaySamCustomer(string CompanyID)
        {
            return this.Context.Database.SqlQuery<Invoice>(
          "InvoiceSameDaySamCustomer @CompanyID",
          new SqlParameter("@CompanyID", CompanyID)
          ).ToList();
        }

        public List<Invoice> GetInvoiceSelectS35(DateTime startDate, DateTime endDate, string companyID, int StatusLink)
        {
            return this.Context.Database.SqlQuery<Invoice>(
          "InvoiceSelectS35 @StartDate, @EndDate, @CompanyID, @StatusLink",
          new SqlParameter("@StartDate", startDate),
          new SqlParameter("@EndDate", endDate),
          new SqlParameter("@CompanyID", companyID),
          new SqlParameter("@StatusLink", StatusLink)
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
                    new SqlParameter("@VATAmount",  invoice.VATAmount),
                    new SqlParameter("@Discounts", invoice.Discounts),
                    new SqlParameter("@CreateUser", UserInfo.UserID), 
                    new SqlParameter("@CompanyID", invoice.CompanyID),
                    new SqlParameter("@PaymentType", invoice.PaymentType?? (object)DBNull.Value),
                    new SqlParameter("@S35Type", invoice.S35Type?? (object)DBNull.Value),
                    new SqlParameter("@InvoiceAccountID", invoice.InvoiceAccountID?? (object)DBNull.Value),
                    new SqlParameter("@InvoiceAccountDetailID", invoice.InvoiceAccountDetailID?? (object)DBNull.Value),
                    new SqlParameter("@InvoiceVATAccountID",invoice.InvoiceVATAccountID?? (object)DBNull.Value),
                     new SqlParameter("@MST", invoice.MST?? (object)DBNull.Value),
                    new SqlParameter("@CustomerName",invoice.CustomerName?? (object)DBNull.Value),
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
                    new SqlParameter("@CreateUser", UserInfo.UserID),
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
                    new SqlParameter("@VAT", invoice.VAT),
                    new SqlParameter("@VATAmount", invoice.VATAmount),
                    new SqlParameter("@Discounts", invoice.Discounts),
                    new SqlParameter("@CreateUser", UserInfo.UserID),
                    new SqlParameter("@CompanyID", invoice.CompanyID),
                    new SqlParameter("@PaymentType", invoice.PaymentType?? (object)DBNull.Value),
                    new SqlParameter("@S35Type", invoice.S35Type?? (object)DBNull.Value),
                    new SqlParameter("@InvoiceAccountID", invoice.InvoiceAccountID?? (object)DBNull.Value),
                    new SqlParameter("@InvoiceAccountDetailID", invoice.InvoiceAccountDetailID?? (object)DBNull.Value),
                    new SqlParameter("@InvoiceVATAccountID",invoice.InvoiceVATAccountID?? (object)DBNull.Value),
                    new SqlParameter("@MST", invoice.MST?? (object)DBNull.Value),
                    new SqlParameter("@CustomerName",invoice.CustomerName?? (object)DBNull.Value),
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

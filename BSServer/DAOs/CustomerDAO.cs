using BSCommon.Models;
using BSCommon.Utility;
using BSServer._Core.Base;
using BSServer._Core.Const;
using BSServer._Core.Context;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BSServer.DAOs
{
    public class CustomerDAO : BaseDAO
    {
        public CustomerDAO(BSContext context) : base(context)
        {
        }

        public long GetCustomerSEQ()
        {
            return this.GetMaxSEQ(BSServerConst.CustomerSymbol);
        }

        public List<Customer> GetCustommers()
        {
            return this.Context.GetDataFromProcedure<Customer>(
                "SP_GetCustomers",
                new SqlParameter("@CompanyID", CommonInfo.CompanyInfo.CompanyID));
        }

        public bool InsertCustomer(Customer data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@CustomerID", data.CustomerID),
                new SqlParameter("@CustomerName", data.CustomerName),
                new SqlParameter("@CustomerSName", data.CustomerSName),
                new SqlParameter("@CustomerTIN", data.CustomerTIN),
                new SqlParameter("@CustomerAddress", data.CustomerAddress),
                new SqlParameter("@CustomerPhone", data.CustomerPhone),
                new SqlParameter("@ParentID", data.ParentID),
                new SqlParameter("@InvoiceFormNo", data.InvoiceFormNo),
                new SqlParameter("@FormNo", data.FormNo),
                new SqlParameter("@SerialNo", data.SerialNo),
                new SqlParameter("@UpdateUser", UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("CustomerInsert", sqlParameters);

            return true;
        }

        public bool UpdateCustomer(Customer data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@CustomerID", data.CustomerID),
                new SqlParameter("@CustomerName", data.CustomerName),
                new SqlParameter("@CustomerSName", data.CustomerSName),
                new SqlParameter("@CustomerTIN", data.CustomerTIN),
                new SqlParameter("@CustomerAddress", data.CustomerAddress),
                new SqlParameter("@CustomerPhone", data.CustomerPhone),
                new SqlParameter("@ParentID", data.ParentID),
                new SqlParameter("@InvoiceFormNo", data.InvoiceFormNo),
                new SqlParameter("@FormNo", data.FormNo),
                new SqlParameter("@SerialNo", data.SerialNo),
                new SqlParameter("@UpdateUser", UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("CustomerUpdate", sqlParameters);

            return true;
        }

        public bool DeleteCustomer(Customer data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@CustomerID", data.CustomerID)
            };

            this.Context.ExecuteDataFromProcedure("CustomerDelete", sqlParameters);

            return true;
        }

        public bool InsertCustomerCompany(CustomerCompany data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@CompanyID", data.CompanyID),
                new SqlParameter("@CustomerID", data.CustomerID),
                new SqlParameter("@UpdateUser", UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("CustomerCompanyInsert", sqlParameters);

            return true;
        }

        public bool DeleteCustomerCompany(CustomerCompany data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@CompanyID", data.CompanyID),
                new SqlParameter("@CustomerID", data.CustomerID)
            };

            this.Context.ExecuteDataFromProcedure("CustomerCompanyDelete", sqlParameters);

            return true;
        }
    }
}

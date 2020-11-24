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
            return this.Context.Database
                .SqlQuery<Customer>("CustomerSelect")
                .ToList();
        }

        public int InsertCustommer(Customer customer)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CustomerID", customer.CustomerID),
                new SqlParameter("@CustomerName", customer.CustomerName),
                new SqlParameter("@CustomerSName", customer.CustomerSName),
                new SqlParameter("@InvoiceFormNo", customer.InvoiceFormNo),
                new SqlParameter("@FormNo", customer.FormNo),
                new SqlParameter("@SerialNo", customer.SerialNo),
                new SqlParameter("@Address", customer.Address),
                new SqlParameter("@Phone", customer.Phone),
                new SqlParameter("@UserId", CommonInfo.UserInfo.UserID)
            };

            return this.Context.ExecuteDataFromProcedure("CustomerInsert", param);
        }

        public int UpdateCustommer(Customer customer)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CustomerID", customer.CustomerID),
                new SqlParameter("@CustomerName", customer.CustomerName),
                new SqlParameter("@CustomerSName", customer.CustomerSName),
                new SqlParameter("@InvoiceFormNo", customer.InvoiceFormNo),
                new SqlParameter("@FormNo", customer.FormNo),
                new SqlParameter("@SerialNo", customer.SerialNo),
                new SqlParameter("@Address", customer.Address),
                new SqlParameter("@Phone", customer.Phone),
                new SqlParameter("@UserId", CommonInfo.UserInfo.UserID)
            };

            return this.Context.ExecuteDataFromProcedure("CustomerUpdate", param);
        }

        public int DeleteCustommer(Customer customer)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CustomerID", customer.CustomerID),
                new SqlParameter("UserId", CommonInfo.UserInfo.UserID)
            };

            return this.Context.ExecuteDataFromProcedure("CustomerDelete", param);
        }
    }
}

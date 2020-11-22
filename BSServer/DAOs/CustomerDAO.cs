using BSCommon.Models;
using BSCommon.Utility;
using BSServer._Core.Base;
using BSServer._Core.Const;
using BSServer._Core.Context;
using System;
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

        //public List<CustomerCompany> GetCustommers(string customerId)
        //{
        //    if (string.IsNullOrEmpty(customerId))
        //    {
        //        return GetCustommers();
        //    }
        //    else
        //    {
        //        return GetCustommersById(customerId);
        //    }
        //}

        //private List<CustomerCompany> GetCustommers()
        //{
        //    return this.Context.Customers.ToList();
        //}

        //private List<CustomerCompany> GetCustommersById(string customerId)
        //{
        //    return this.Context.Customers.Where(o => o.CustomerID == customerId).ToList();
        //}

        public List<Customer> GetCustommers()
        {
            return this.Context.Database
                .SqlQuery<Customer>("CustomerSelect")
                .ToList();
        }

        public List<Customer> GetCustommersCompany(string companyID)
        {
            SqlParameter param = new SqlParameter("@CustomerID", companyID);

            return this.Context.Database
                .SqlQuery<Customer>("CustomerCompanySelect @CustomerID", param)
                .ToList();
        }

        public List<Customer> GetCustommerNotCompany(string companyID)
        {
            SqlParameter param = new SqlParameter("@CustomerID", companyID);

            return this.Context.Database
                .SqlQuery<Customer>("CustomerNotCompanySelect @CustomerID", param)
                .ToList();
        }

        public int InsertCustommer(Customer customer)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CustomerID", customer.CustomerID),
                new SqlParameter("@CustomerName", customer.CustomerName),
                new SqlParameter("@CustomerSName", customer.CustomerSName),
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

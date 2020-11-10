using BSCommon.Models;
using BSCommon.Utility;
using BSServer._Core.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BSServer.DAOs
{
    public class CustomerDAO
    {
        public CustomerDAO(BSContext context)
        {
            this.Context = context;
        }

        private BSContext Context { get; set; }

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

        public int InsertCustommersCompany(Customer customer)
        {
            string sql = @"
            CustomerInsert
            @CustomerName,
            @CustomerSName, 
            @Address,
            @Phone,
            @UserId
            ";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CustomerName", customer.CustomerName),
                new SqlParameter("@CustomerSName", customer.CustomerSName ?? (object)DBNull.Value),
                new SqlParameter("@Address", customer.Address ?? (object)DBNull.Value),
                new SqlParameter("@Phone", customer.Phone ?? (object)DBNull.Value),
                new SqlParameter("@UserId", CommonInfo.UserInfo.UserID)
            };

            return this.Context.Database.ExecuteSqlCommand(sql, param);
        }

        public int UpdateCustommersCompany(Customer customer)
        {
            string sql = @"
CustomerUpdate
    @CustomerID, 
    @CustomerName,
    @CustomerSName, 
    @Address,
    @Phone,
    @UserId
";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CustomerID", customer.CustomerID),
                new SqlParameter("@CustomerName", customer.CustomerName),
                new SqlParameter("@CustomerSName", customer.CustomerSName ?? (object)DBNull.Value),
                new SqlParameter("@Address", customer.Address ?? (object)DBNull.Value),
                new SqlParameter("@Phone", customer.Phone ?? (object)DBNull.Value),
                new SqlParameter("@UserId", CommonInfo.UserInfo.UserID)
            };

            return this.Context.Database.ExecuteSqlCommand(sql, param);
        }

        public int DeleteCustommersCompany(Customer customer)
        {
            string sql = @"
CustomerDelete
    @CustomerID, 
    @UserId
";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CustomerID", customer.CustomerID),
                new SqlParameter("UserId", CommonInfo.UserInfo.UserID)
            };

            return this.Context.Database.ExecuteSqlCommand(sql, param);
        }
    }
}

using BSCommon.Constant;
using BSCommon.Models;
using BSCommon.Utility;
using BSServer._Core.Base;
using BSServer._Core.Context;
using BSServer.DAOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace BSServer.Logics
{
    public class CustomerLogic : BaseLogic
    {
        public CustomerLogic(BSContext context) : base(context)
        {
            this.CommonDAO = new CommonDAO(this.Context);
            this.CustomerDAO = new CustomerDAO(this.Context);
        }

        private CommonDAO CommonDAO { get; set; }

        private CustomerDAO CustomerDAO { get; set; }

        public bool SaveCustommersCompany(List<Customer> customers)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    foreach (Customer customer in customers)
                    {
                        switch (customer.Status)
                        {
                            // Add new
                            case ModifyMode.Insert:
                                customer.CustomerID = this.CommonDAO.GetCustomerID();

                                this.CustomerDAO.InsertCustommer(customer);
                                break;

                            // Update
                            case ModifyMode.Update:
                                this.CustomerDAO.UpdateCustommer(customer);
                                break;

                            // Delete
                            case ModifyMode.Delete:
                                this.CustomerDAO.DeleteCustommer(customer);
                                break;
                        }
                    }

                    transaction.Commit();

                    return true;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    Console.WriteLine("Lưu dữ liệu thất bại.\r\n" + e.Message);
                    return false;
                }
            }
        }
    }
}

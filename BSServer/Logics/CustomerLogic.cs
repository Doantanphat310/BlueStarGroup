using BSCommon.Models;
using BSServer._Core.Context;
using BSServer.DAOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace BSServer.Logics
{
    public class CustomerLogic
    {
        public CustomerLogic(BSContext context)
        {
            this.Context = context;
            this.CustomerDAO = new CustomerDAO(this.Context);
        }

        private BSContext Context { get; set; }

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
                            case 1:
                                this.CustomerDAO.InsertCustommersCompany(customer);
                                break;

                            // Update
                            case 2:
                                this.CustomerDAO.UpdateCustommersCompany(customer);
                                break;

                            // Delete
                            case 3:
                                this.CustomerDAO.DeleteCustommersCompany(customer);
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

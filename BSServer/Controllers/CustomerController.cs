using BSCommon.Models;
using BSServer._Core.Context;
using BSServer.DAOs;
using BSServer.Logics;
using System;
using System.Collections.Generic;

namespace BSServer.Controllers
{
    public class CustomerController
    {
        private BSContext Context { get; set; }

        private CustomerDAO CustomerDAO { get; set; }

        private CustomerLogic CustomerLogic { get; set; }

        public CustomerController()
        {
            this.Context = new BSContext();
            this.Context.Database.Log = Console.Write;

            this.CustomerDAO = new CustomerDAO(this.Context);
            this.CustomerLogic = new CustomerLogic(this.Context);
        }

        public List<Customer> GetCustomers()
        {
            
            return this.CustomerDAO.GetCustommers();
        }

        public bool SaveCustommers(List<Customer> customerCompanies)
        {
            return this.CustomerLogic.SaveCustommersCompany(customerCompanies);
        }

        public void Dispose()
        {
        }
    }
}

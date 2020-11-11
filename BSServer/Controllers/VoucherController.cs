using BSServer._Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSServer.Controllers
{
    public class VoucherController
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

        public List<Customer> GetCustommerNotCompany(string companyID)
        {
            return this.CustomerDAO.GetCustommerNotCompany(companyID);
        }

        public List<Customer> GetCustommersCompany(string companyID)
        {
            return this.CustomerDAO.GetCustommersCompany(companyID);
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

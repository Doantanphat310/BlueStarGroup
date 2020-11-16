using BSCommon.Models;
using BSServer._Core.Base;
using BSServer._Core.Context;
using BSServer.DAOs;
using System.Collections.Generic;

namespace BSServer.Controllers
{
    public class CompanyController : BaseController
    {
        private BSContext Context { get; set; }

        private CompanyDAO CompanyDAO { get; set; }

        public CompanyController() : base()
        {
            this.Context = new BSContext();
            this.CompanyDAO = new CompanyDAO(this.Context);
        }

        public List<Company> GetCompanys()
        {
            return this.CompanyDAO.GetCompanys();
        }
    }
}

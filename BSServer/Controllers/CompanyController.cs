using BSCommon.Models;
using BSServer._Core.Base;
using BSServer._Core.Context;
using BSServer._Core.Utility;
using BSServer.DAOs;
using System.Collections.Generic;
using System.Linq;

namespace BSServer.Controllers
{
    public class CompanyController : BaseController
    {
        private CompanyDAO CompanyDAO { get; set; }

        public CompanyController() : base()
        {
            this.CompanyDAO = new CompanyDAO(this.Context);
        }

        public List<Company> GetCompanys()
        {
            return this.CompanyDAO.GetCompanys();
        }

        public Company GetCompanyInfo(string companyID)
        {
            return this.CompanyDAO.GetCompanyInfo(companyID);
        }

        public bool InsertCompany(Company data)
        {
            long seq = this.CompanyDAO.GetCompanySEQ() + 1;
            data.CompanyID = GenerateID.CompanyID(seq);

            return this.CompanyDAO.InsertCompany(data);
        }

        public bool UpdateCompany(Company data)
        {
            return this.CompanyDAO.UpdateCompany(data);
        }

        public bool DeleteCompany(Company data)
        {
            return this.CompanyDAO.DeleteCompany(data);
        }
    }
}

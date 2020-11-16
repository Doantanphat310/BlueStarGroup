using BSCommon.Constant;
using BSCommon.Models;
using BSServer._Core.Context;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BSServer.DAOs
{
    public class CompanyDAO
    {
        public CompanyDAO(BSContext context)
        {
            this.Context = context;
        }

        private BSContext Context { get; set; }

        public List<Company> GetCompanys()
        {
            return this.Context.Database
               .SqlQuery<Company>("CompanySelect")
               .ToList();
        }
    }
}

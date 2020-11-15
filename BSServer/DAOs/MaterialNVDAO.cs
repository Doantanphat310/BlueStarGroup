using BSCommon.Models;
using BSServer._Core.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSServer.DAOs
{
   public class MaterialNVDAO
    {
        public MaterialNVDAO(BSContext context)
        {
            this.Context = context;
        }
        private BSContext Context { get; set; }

        public List<MaterialNV> GetMaterialNV()
        {
            return this.Context.Database
                .SqlQuery<MaterialNV>("SPSelectMaterialNV")
                .ToList();
        }

        public List<MaterialTK> GetMaterialTK()
        {
            return this.Context.Database
                .SqlQuery<MaterialTK>("SPSelectMaterialTK")
                .ToList();
        }

        public List<MaterialDT> GetMaterialDT(string companyID)
        {
            SqlParameter param = new SqlParameter("@CompanyID", companyID);
            return this.Context.Database
                .SqlQuery<MaterialDT>("SPSelectMaterialDoiTuong @CompanyID", param)
                .ToList();
        }

        public List<MaterialGL> GetMaterialGL(string companyID)
        {
            SqlParameter param = new SqlParameter("@CompanyID", companyID);
            return this.Context.Database
                .SqlQuery<MaterialGL>("SPSelectMaterialGL @CompanyID", param)
                .ToList();
        }


    }
}

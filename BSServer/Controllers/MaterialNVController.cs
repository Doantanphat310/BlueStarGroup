using BSCommon.Models;
using BSServer._Core.Context;
using BSServer.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSServer.Controllers
{
    public class MaterialNVController
    {
        private BSContext Context { get; set; }
        private MaterialNVDAO MaterialNVDAO { get; set; }
        public MaterialNVController()
        {
            this.Context = new BSContext();
            this.Context.Database.Log = Console.Write;
            this.MaterialNVDAO = new MaterialNVDAO(this.Context);
        }
        public List<MaterialNV> GetMaterialNV()
        {
            return this.MaterialNVDAO.GetMaterialNV();
        }

        public List<MaterialTK> GetMaterialTK()
        {
            return this.MaterialNVDAO.GetMaterialTK();
        }

        public List<MaterialDT> GetMaterialDT( string companyID)
        {
            return this.MaterialNVDAO.GetMaterialDT(companyID);
        }

        public List<MaterialGL> GetMaterialGL(string companyID)
        {
            return this.MaterialNVDAO.GetMaterialGL(companyID);
        }
        public void Dispose()
        {
        }
    }
}

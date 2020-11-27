using BSCommon.Models;
using BSServer._Core.Context;
using BSServer.DAOs;
using BSServer.Logics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSServer.Controllers
{
   public  class DepreciationController
    {
        private BSContext Context { get; set; }

        private DepreciationLogic DepreciationLogic { get; set; }

        private DepreciationDAO DepreciationDAO { get; set; }

        public DepreciationController()
        {
            this.Context = new BSContext();
            this.DepreciationDAO = new DepreciationDAO(this.Context);
            this.DepreciationLogic = new DepreciationLogic(this.Context);
        }

        public List<Depreciation> GetDepreciationSelect(string DepreciationID, string companyID)
        {
            return this.DepreciationDAO.GetDepreciationSelect(DepreciationID, companyID);
        }


        public bool InsertDepreciation(Depreciation depreciation)
        {
            return this.DepreciationDAO.InsertDepreciation(depreciation);
        }

        public bool UpdateDepreciation(Depreciation depreciation)
        {
            return this.DepreciationDAO.UpdateDepreciation(depreciation);
        }

        public bool DeleteDepreciation(string DepreciationID, string companyID)
        {
            return this.DepreciationDAO.DeleteDepreciation(DepreciationID, companyID);
        }

        public bool SaveDepreciation(List<Depreciation> dataList)
        {
            return this.DepreciationLogic.SaveDepreciation(dataList);
        }
    }
}

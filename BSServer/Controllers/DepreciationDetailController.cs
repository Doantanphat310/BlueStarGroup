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
   public class DepreciationDetailController
    {
        private BSContext Context { get; set; }

        private DepreciationDetailLogic DepreciationDetailLogic { get; set; }

        private DepreciationDetailDAO DepreciationDetailDAO { get; set; }

        public DepreciationDetailController()
        {
            this.Context = new BSContext();
            this.DepreciationDetailDAO = new DepreciationDetailDAO(this.Context);
            this.DepreciationDetailLogic = new DepreciationDetailLogic(this.Context);
        }

        public List<DepreciationDetail> GetDepreciationDetailSelect(string DepreciationDetailID, string companyID)
        {
            return this.DepreciationDetailDAO.GetDepreciationDetailSelect(DepreciationDetailID, companyID);
        }


        public bool InsertDepreciationDetail(DepreciationDetail depreciationdetail)
        {
            return this.DepreciationDetailDAO.InsertDepreciationDetail(depreciationdetail);
        }

        public bool UpdateDepreciationDetail(DepreciationDetail depreciationdetail)
        {
            return this.DepreciationDetailDAO.UpdateDepreciationDetail(depreciationdetail);
        }

        public bool DeleteDepreciationDetail(string DepreciationDetailID, string companyID)
        {
            return this.DepreciationDetailDAO.DeleteDepreciationDetail(DepreciationDetailID, companyID);
        }

        public bool SaveDepreciationDetail(List<DepreciationDetail> dataList)
        {
            return this.DepreciationDetailLogic.SaveDepreciationDetail(dataList);
        }
    }
}

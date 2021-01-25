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
   public class LockDBCompanyController
    {
        private BSContext Context { get; set; }

        private LockDBCompanyLogic LockDBCompanyLogic { get; set; }

        private LockDBCompanyDAO LockDBCompanyDAO { get; set; }

        public LockDBCompanyController()
        {
            this.Context = new BSContext();
            this.LockDBCompanyDAO = new LockDBCompanyDAO(this.Context);
            this.LockDBCompanyLogic = new LockDBCompanyLogic(this.Context);
        }

        public List<LockDBCompany> GetLockDBCompany(DateTime StartDate, DateTime EndDate, string CompanyID)
        {
            return this.LockDBCompanyDAO.GetLockDBCompany(StartDate, EndDate, CompanyID);
        }

        
       public List<LockDBCompany> LockDBCompanyCheck(DateTime LockDBDate, string CompanyID)
        {
            return this.LockDBCompanyDAO.LockDBCompanyCheck(LockDBDate, CompanyID);
        }


        public bool InsertLockDB(LockDBCompany lockDB)
        {
            return this.LockDBCompanyDAO.InsertLockDB(lockDB);
        }

        public bool UpdateLockDB(LockDBCompany lockDB)
        {
            return this.LockDBCompanyDAO.UpdateLockDB(lockDB);
        }

        public bool DeleteLockDB(LockDBCompany lockDB)
        {
            return this.LockDBCompanyDAO.DeleteLockDB(lockDB);
        }

        public bool SaveLockDB(List<LockDBCompany> dataList)
        {
            return this.LockDBCompanyLogic.SaveLockDB(dataList);
        }
    }
}

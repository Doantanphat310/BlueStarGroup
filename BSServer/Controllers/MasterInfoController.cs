using BSCommon.Models;
using BSServer._Core.Context;
using BSServer.DAOs;
using System.Collections.Generic;

namespace BSServer.Controllers
{
    public class MasterInfoController
    {
        private BSContext Context { get; set; }

        private MasterInfoDAO MasterInfoDAO { get; set; }

        public MasterInfoController()
        {
            this.Context = new BSContext();
            this.MasterInfoDAO = new MasterInfoDAO(this.Context);
        }

        public List<MasterInfo> GetMasterInfos(string masterCd)
        {
            return this.MasterInfoDAO.GetMasterInfos(masterCd);
        }
    }
}

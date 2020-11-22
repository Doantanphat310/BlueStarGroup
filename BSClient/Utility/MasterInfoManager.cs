using BSCommon.Constant;
using BSCommon.Models;
using BSServer.Controllers;
using System.Collections.Generic;

namespace BSClient.Utility
{
    public static class MasterInfoManager
    {
        public static List<MasterInfo> GetUserRoles()
        {
            MasterInfoController masterInfoController = new MasterInfoController();

            return masterInfoController.GetMasterInfos(MasterType.USERROLE);
        }

        public static List<MasterInfo> GetItemUnit()
        {
            MasterInfoController masterInfoController = new MasterInfoController();

            return masterInfoController.GetMasterInfos(MasterType.ITEMUNIT);
        }
    }
}

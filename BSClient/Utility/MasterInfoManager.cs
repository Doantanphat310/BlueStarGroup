using BSCommon.Models;
using BSCommon.Utility;
using BSServer.Controllers;
using System.Collections.Generic;

namespace BSClient.Utility
{
    public static class MasterInfoManager
    {
        public static List<MasterInfo> GetUserRoles()
        {
            MasterInfoController masterInfoController = new MasterInfoController();

            return masterInfoController.GetMasterInfos(MasterType.UserRole);
        }
    }
}

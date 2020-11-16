using BSCommon.Constant;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSCommon.Models
{
    /// <summary>
    /// User role infomation
    /// </summary>
    public class UserRoleInfo
    {
        public string UserID { get; set; }

        public string UserRoleID { get; set; }

        public string UserRoleName { get; set; }

        public string CompanyID { get; set; }

        public string CompanyName { get; set; }

        public ModifyMode Status { get; set; }
    }
}

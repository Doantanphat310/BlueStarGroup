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

        public string UserRole { get; set; }

        public string CompanyID { get; set; }

        public string CompanyName { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSCommon.Models
{
    /// <summary>
    /// UserRoleCompany infomation
    /// </summary>        
    public class UserRoleCompany : BaseModel
    {
        /// <summary>
        /// CompanyID
        /// </summary>
        public string CompanyID { get; set; }

        /// <summary>
        /// UserID
        /// </summary>
        public string UserID { get; set; }


        /// <summary>
        /// RoleID
        /// </summary>
        public string UserRoleID { get; set; }

        /// <summary>
        /// UserRoleName
        /// </summary>
        public string UserRoleName { get; set; }

        /// <summary>
        /// RoleValue
        /// </summary>
        public string UserRoleValue { get; set; }

        /// <summary>
        /// CompanyName
        /// </summary>
        public string CompanyName { get; set; }
    }
}

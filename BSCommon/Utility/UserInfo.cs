using BSCommon.Models;
using System.Collections.Generic;

namespace BSCommon.Utility
{
    public static class UserInfo
    {
        /// <summary>
        /// UserID
        /// </summary>
        public static string UserID { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public static string Password { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        public static string UserName { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        public static string Phone { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public static string Address { get; set; }

        /// <summary>
        /// UserRole
        /// </summary>
        public static string UserRole { get; set; }

        /// <summary>
        /// CompanyID
        /// </summary>
        public static string CompanyID { get; set; }

        public static List<UserRoleCompany> Companies { get; set; }
    }
}

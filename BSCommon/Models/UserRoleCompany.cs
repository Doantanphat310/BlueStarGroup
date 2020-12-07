using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSCommon.Models
{
    /// <summary>
    /// UserRoleCompany infomation
    /// </summary>        
    [Table("UserRoleCompany")]
    public class UserRoleCompany : BaseModel
    {
        /// <summary>
        /// UserID
        /// </summary>
        [Key]
        [Column("UserID", Order = 1)]
        public string UserID { get; set; }

        /// <summary>
        /// CompanyID
        /// </summary>
        [Key]
        [Column("CompanyID", Order = 2)]
        public string CompanyID { get; set; }

        /// <summary>
        /// RoleID
        /// </summary>
        [Key]
        [Column("RoleID", Order = 3)]
        public string UserRoleID { get; set; }

        /// <summary>
        /// UserRoleName
        /// </summary>
        [Column("UserRoleName")]
        public string UserRoleName { get; set; }

        /// <summary>
        /// CompanyName
        /// </summary>
        [Column("CompanyName")]
        public string CompanyName { get; set; }
    }
}

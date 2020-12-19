using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSCommon.Models
{
    /// <summary>
    /// UserList infomation
    /// </summary>        
    [Table("UserList")]
    public class UserInfo : BaseModel
    {
        /// <summary>
        /// UserID
        /// </summary>
        [Key]
        [Column("UserID", Order = 1)]
        public string UserID { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Column("Password")]
        public string Password { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        [Column("UserName")]
        public string UserName { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        [Column("Phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        [Column("Address")]
        public string Address { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [NotMapped]
        public string PasswordDisplay { get; set; }

        /// <summary>
        /// UserRole
        /// </summary>
        [NotMapped]
        public string UserRole { get; set; }
    }
}

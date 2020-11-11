using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSCommon.Models
{
    /// <summary>
    /// User infomation
    /// </summary>
    [Table("User")]
    public class User
    {
        [Key]
        public string UserID { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

        public int? IsDelete { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string CreateUser { get; set; }

        public string UpdateUser { get; set; }
        
        public int UserRole { get; set; }
    }
}

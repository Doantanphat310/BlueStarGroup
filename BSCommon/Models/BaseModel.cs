using BSCommon.Constant;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSCommon.Models
{
    public class BaseModel
    {
        /// <summary>
        /// Status
        /// </summary>
        [NotMapped]
        public ModifyMode Status { get; set; }

        /// <summary>
        /// ItemName
        /// </summary>
        [Column("CreateDate")]
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// ItemName
        /// </summary>
        [Column("UpdateDate")]
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// ItemName
        /// </summary>
        [Column("CreateUser")]
        public string CreateUser { get; set; }

        /// <summary>
        /// ItemName
        /// </summary>
        [Column("UpdateUser")]
        public string UpdateUser { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSCommon.Models
{
    /// <summary>
    /// MasterInfo infomation
    /// </summary>        
    [Table("MasterInfo")]
    public class MasterInfo : BaseModel
    {
        /// <summary>
        /// MasterCd
        /// </summary>
        [Key]
        [Column("MasterCd", Order = 1)]
        public string Key { get; set; }

        /// <summary>
        /// DetailCd
        /// </summary>
        [Key]
        [Column("DetailCd", Order = 2)]
        public string Id { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        [Column("Value")]
        public string Value { get; set; }

        /// <summary>
        /// Value2
        /// </summary>
        [Column("Value2")]
        public string Value2 { get; set; }

        /// <summary>
        /// Value3
        /// </summary>
        [Column("Value3")]
        public string Value3 { get; set; }

        /// <summary>
        /// Value4
        /// </summary>
        [Column("Value4")]
        public string Value4 { get; set; }

        /// <summary>
        /// Value5
        /// </summary>
        [Column("Value5")]
        public string Value5 { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSCommon.Models
{
    /// <summary>
    /// Accounts infomation
    /// </summary>        
    [Table("Accounts")]
    public class Accounts : BaseModel
    {
        /// <summary>
        /// AccountID
        /// </summary>
        [Key]
        [Column("AccountID", Order = 1)]
        public string AccountID { get; set; }

        /// <summary>
        /// AccountName
        /// </summary>
        [Column("AccountName")]
        public string AccountName { get; set; }

        /// <summary>
        /// AccountGroupID
        /// </summary>
        [Column("AccountGroupID")]
        public string AccountGroupID { get; set; }

        /// <summary>
        /// AccountLevel
        /// </summary>
        [Column("AccountLevel")]
        public byte AccountLevel { get; set; }

        /// <summary>
        /// ParentID
        /// </summary>
        [Column("ParentID")]
        public string ParentID { get; set; }

        /// <summary>
        /// HachToan
        /// </summary>
        [Column("HachToan")]
        public bool HachToan { get; set; }

        /// <summary>
        /// DuNo
        /// </summary>
        [Column("DuNo")]
        public bool DuNo { get; set; }

        /// <summary>
        /// DuCo
        /// </summary>
        [Column("DuCo")]
        public bool DuCo { get; set; }

        /// <summary>
        /// ThongKe
        /// </summary>
        [Column("ThongKe")]
        public bool ThongKe { get; set; }

        /// <summary>
        /// NgoaiTe
        /// </summary>
        [Column("NgoaiTe")]
        public bool NgoaiTe { get; set; }

        /// <summary>
        /// TK152_156
        /// </summary>
        [Column("TK152_156")]
        public bool TK152_156 { get; set; }

        /// <summary>
        /// VatTu
        /// </summary>
        [Column("VatTu")]
        public bool VatTu { get; set; }

        /// <summary>
        /// ThueVAT
        /// </summary>
        [Column("ThueVAT")]
        public bool ThueVAT { get; set; }

        /// <summary>
        /// HopDong
        /// </summary>
        [Column("HopDong")]
        public bool HopDong { get; set; }

        /// <summary>
        /// CongNo
        /// </summary>
        [Column("CongNo")]
        public bool CongNo { get; set; }
    }
}

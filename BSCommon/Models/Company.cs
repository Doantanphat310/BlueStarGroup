using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSCommon.Models
{
    /// <summary>
    /// Company infomation
    /// </summary>        
    [Table("Company")]
    public class Company : BaseModel
    {
        /// <summary>
        /// CompanyID
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public string CompanyID { get; set; }

        /// <summary>
        /// CompanyCode
        /// </summary>
        public string CompanyCode { get; set; }

        /// <summary>
        /// CompanyName
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// CompanySName
        /// </summary>
        public string CompanySName { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// MST
        /// </summary>
        public string MST { get; set; }

        /// <summary>
        /// District
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// Province
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Fax
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// AccountBank
        /// </summary>
        public string AccountBank { get; set; }

        /// <summary>
        /// Bank
        /// </summary>
        public string Bank { get; set; }

        /// <summary>
        /// BranchBank
        /// </summary>
        public string BranchBank { get; set; }

        /// <summary>
        /// Logo
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// BackGround
        /// </summary>
        public string BackGround { get; set; }

        /// <summary>
        /// StampCircel
        /// </summary>
        public string StampCircel { get; set; }

        /// <summary>
        /// StampSquare
        /// </summary>
        public string StampSquare { get; set; }

        /// <summary>
        /// SoQuyetDinh
        /// </summary>
        public string SoQuyetDinh { get; set; }

        /// <summary>
        /// MaSoHD
        /// </summary>
        public string MaSoHD { get; set; }

        /// <summary>
        /// NoiQLThue
        /// </summary>
        public string NoiQLThue { get; set; }

        /// <summary>
        /// NHKhoBac
        /// </summary>
        public string NHKhoBac { get; set; }

        /// <summary>
        /// TKThuThue
        /// </summary>
        public string TKThuThue { get; set; }

        /// <summary>
        /// LapBieu
        /// </summary>
        public string LapBieu { get; set; }

        /// <summary>
        /// KTTruong
        /// </summary>
        public string KTTruong { get; set; }

        /// <summary>
        /// KTVien
        /// </summary>
        public string KTVien { get; set; }

        /// <summary>
        /// LanhDao
        /// </summary>
        public string LanhDao { get; set; }

        /// <summary>
        /// ThuQuy
        /// </summary>
        public string ThuQuy { get; set; }

        /// <summary>
        /// ChucDanhLanhDao
        /// </summary>
        public string ChucDanhLanhDao { get; set; }

        /// <summary>
        /// ChukyLapBieu
        /// </summary>
        public string ChukyLapBieu { get; set; }

        /// <summary>
        /// ChuKyKTTruong
        /// </summary>
        public string ChuKyKTTruong { get; set; }

        /// <summary>
        /// ChuKyKeToanVien
        /// </summary>
        public string ChuKyKeToanVien { get; set; }

        /// <summary>
        /// ChuKyLanhDao
        /// </summary>
        public string ChuKyLanhDao { get; set; }

        /// <summary>
        /// ChuKyThuQuy
        /// </summary>
        public string ChuKyThuQuy { get; set; }
    }
}

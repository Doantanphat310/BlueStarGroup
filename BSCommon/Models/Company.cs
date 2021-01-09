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
        [Column("CompanyID", Order = 1)]
        public string CompanyID { get; set; }

        /// <summary>
        /// CompanyName
        /// </summary>
        [Column("CompanyName")]
        public string CompanyName { get; set; }

        /// <summary>
        /// CompanySName
        /// </summary>
        [Column("CompanySName")]
        public string CompanySName { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        [Column("Address")]
        public string Address { get; set; }

        /// <summary>
        /// MST
        /// </summary>
        [Column("MST")]
        public string MST { get; set; }

        /// <summary>
        /// District
        /// </summary>
        [Column("District")]
        public string District { get; set; }

        /// <summary>
        /// Province
        /// </summary>
        [Column("Province")]
        public string Province { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        [Column("Phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Fax
        /// </summary>
        [Column("Fax")]
        public string Fax { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Column("Email")]
        public string Email { get; set; }

        /// <summary>
        /// CurrencyUnit
        /// </summary>
        [Column("CurrencyUnit")]
        public string CurrencyUnit { get; set; }

        /// <summary>
        /// BankAccount
        /// </summary>
        [Column("BankAccount")]
        public string BankAccount { get; set; }

        /// <summary>
        /// BankName
        /// </summary>
        [Column("BankName")]
        public string BankName { get; set; }

        /// <summary>
        /// BankBranch
        /// </summary>
        [Column("BankBranch")]
        public string BankBranch { get; set; }

        /// <summary>
        /// Logo
        /// </summary>
        [Column("Logo")]
        public string Logo { get; set; }

        /// <summary>
        /// SoQuyetDinh
        /// </summary>
        [Column("SoQuyetDinh")]
        public string SoQuyetDinh { get; set; }

        /// <summary>
        /// MaSoHD
        /// </summary>
        [Column("MaSoHD")]
        public string MaSoHD { get; set; }

        /// <summary>
        /// NoiQLThue
        /// </summary>
        [Column("NoiQLThue")]
        public string NoiQLThue { get; set; }

        /// <summary>
        /// NHKhoBac
        /// </summary>
        [Column("NHKhoBac")]
        public string NHKhoBac { get; set; }

        /// <summary>
        /// TKThuThue
        /// </summary>
        [Column("TKThuThue")]
        public string TKThuThue { get; set; }

        /// <summary>
        /// LapBieu
        /// </summary>
        [Column("LapBieu")]
        public string LapBieu { get; set; }

        /// <summary>
        /// KTTruong
        /// </summary>
        [Column("KTTruong")]
        public string KTTruong { get; set; }

        /// <summary>
        /// KTVien
        /// </summary>
        [Column("KTVien")]
        public string KTVien { get; set; }

        /// <summary>
        /// LanhDao
        /// </summary>
        [Column("LanhDao")]
        public string LanhDao { get; set; }

        /// <summary>
        /// ThuQuy
        /// </summary>
        [Column("ThuQuy")]
        public string ThuQuy { get; set; }

        /// <summary>
        /// ChucDanhLanhDao
        /// </summary>
        [Column("ChucDanhLanhDao")]
        public string ChucDanhLanhDao { get; set; }

        /// <summary>
        /// ChuKyLapBieu
        /// </summary>
        [Column("ChuKyLapBieu")]
        public string ChuKyLapBieu { get; set; }

        /// <summary>
        /// ChuKyKTTruong
        /// </summary>
        [Column("ChuKyKTTruong")]
        public string ChuKyKTTruong { get; set; }

        /// <summary>
        /// ChuKyKeToanVien
        /// </summary>
        [Column("ChuKyKeToanVien")]
        public string ChuKyKeToanVien { get; set; }

        /// <summary>
        /// ChuKyLanhDao
        /// </summary>
        [Column("ChuKyLanhDao")]
        public string ChuKyLanhDao { get; set; }

        /// <summary>
        /// ChuKyThuQuy
        /// </summary>
        [Column("ChuKyThuQuy")]
        public string ChuKyThuQuy { get; set; }

        /// <summary>
        /// CreateDate
        /// </summary>
        [Column("CreateDate")]
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// UpdateDate
        /// </summary>
        [Column("UpdateDate")]
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// CreateUser
        /// </summary>
        [Column("CreateUser")]
        public string CreateUser { get; set; }

        /// <summary>
        /// UpdateUser
        /// </summary>
        [Column("UpdateUser")]
        public string UpdateUser { get; set; }

        /// <summary>
        /// InvoiceFormNo
        /// </summary>
        [Column("InvoiceFormNo")]
        public string InvoiceFormNo { get; set; }

        /// <summary>
        /// FormNo
        /// </summary>
        [Column("FormNo")]
        public string FormNo { get; set; }

        /// <summary>
        /// SerialNo
        /// </summary>
        [Column("SerialNo")]
        public string SerialNo { get; set; }
    }
}

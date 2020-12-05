using BSCommon.Constant;
using BSCommon.Models;
using BSCommon.Utility;
using BSServer._Core.Base;
using BSServer._Core.Const;
using BSServer._Core.Context;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BSServer.DAOs
{
    public class CompanyDAO: BaseDAO
    {
        public CompanyDAO(BSContext context):base(context)
        {
        }

        public List<Company> GetCompanys()
        {
            return this.Context.Database
               .SqlQuery<Company>("CompanySelect")
               .ToList();
        }

        public long GetCompanySEQ()
        {
            return this.GetMaxSEQ(BSServerConst.CompanySymbol);
        }

        public int InsertCompany(Company data)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CompanyID", data.CompanyID),
                new SqlParameter("@CompanyName", data.CompanyName),
                new SqlParameter("@CompanySName", data.CompanySName),
                new SqlParameter("@Address", data.Address),
                new SqlParameter("@MST", data.MST),
                new SqlParameter("@District", data.District),
                new SqlParameter("@Province", data.Province),
                new SqlParameter("@Phone", data.Phone),
                new SqlParameter("@Fax", data.Fax),
                new SqlParameter("@Email", data.Email),
                new SqlParameter("@BankAccount", data.BankAccount),
                new SqlParameter("@BankName", data.BankName),
                new SqlParameter("@BankBranch", data.BankBranch),
                new SqlParameter("@Logo", data.Logo),
                new SqlParameter("@SoQuyetDinh", data.SoQuyetDinh),
                new SqlParameter("@MaSoHD", data.MaSoHD),
                new SqlParameter("@NoiQLThue", data.NoiQLThue),
                new SqlParameter("@NHKhoBac", data.NHKhoBac),
                new SqlParameter("@TKThuThue", data.TKThuThue),
                new SqlParameter("@LapBieu", data.LapBieu),
                new SqlParameter("@KTTruong", data.KTTruong),
                new SqlParameter("@KTVien", data.KTVien),
                new SqlParameter("@LanhDao", data.LanhDao),
                new SqlParameter("@ThuQuy", data.ThuQuy),
                new SqlParameter("@ChucDanhLanhDao", data.ChucDanhLanhDao),
                new SqlParameter("@ChuKyLapBieu", data.ChuKyLapBieu),
                new SqlParameter("@ChuKyKTTruong", data.ChuKyKTTruong),
                new SqlParameter("@ChuKyKeToanVien", data.ChuKyKeToanVien),
                new SqlParameter("@ChuKyLanhDao", data.ChuKyLanhDao),
                new SqlParameter("@ChuKyThuQuy", data.ChuKyThuQuy),
                new SqlParameter("@UserId", CommonInfo.UserInfo.UserID)
            };

            return this.Context.ExecuteDataFromProcedure("CompanyInsert", param);
        }

        public int UpdateCompany(Company data)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CompanyID", data.CompanyID),
                new SqlParameter("@CompanyName", data.CompanyName),
                new SqlParameter("@CompanySName", data.CompanySName),
                new SqlParameter("@Address", data.Address),
                new SqlParameter("@MST", data.MST),
                new SqlParameter("@District", data.District),
                new SqlParameter("@Province", data.Province),
                new SqlParameter("@Phone", data.Phone),
                new SqlParameter("@Fax", data.Fax),
                new SqlParameter("@Email", data.Email),
                new SqlParameter("@BankAccount", data.BankAccount),
                new SqlParameter("@BankName", data.BankName),
                new SqlParameter("@BankBranch", data.BankBranch),
                new SqlParameter("@Logo", data.Logo),
                new SqlParameter("@SoQuyetDinh", data.SoQuyetDinh),
                new SqlParameter("@MaSoHD", data.MaSoHD),
                new SqlParameter("@NoiQLThue", data.NoiQLThue),
                new SqlParameter("@NHKhoBac", data.NHKhoBac),
                new SqlParameter("@TKThuThue", data.TKThuThue),
                new SqlParameter("@LapBieu", data.LapBieu),
                new SqlParameter("@KTTruong", data.KTTruong),
                new SqlParameter("@KTVien", data.KTVien),
                new SqlParameter("@LanhDao", data.LanhDao),
                new SqlParameter("@ThuQuy", data.ThuQuy),
                new SqlParameter("@ChucDanhLanhDao", data.ChucDanhLanhDao),
                new SqlParameter("@ChuKyLapBieu", data.ChuKyLapBieu),
                new SqlParameter("@ChuKyKTTruong", data.ChuKyKTTruong),
                new SqlParameter("@ChuKyKeToanVien", data.ChuKyKeToanVien),
                new SqlParameter("@ChuKyLanhDao", data.ChuKyLanhDao),
                new SqlParameter("@ChuKyThuQuy", data.ChuKyThuQuy),
                new SqlParameter("@UserId", CommonInfo.UserInfo.UserID)
            };

            return this.Context.ExecuteDataFromProcedure("CompanyUpdate", param);
        }

        public int DeleteCompany(Company data)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CompanyID", data.CompanyID),
                new SqlParameter("UserId", CommonInfo.UserInfo.UserID)
            };

            return this.Context.ExecuteDataFromProcedure("CompanyDelete", param);
        }
    }
}

using BSCommon.Models;
using BSCommon.Utility;
using BSServer._Core.Base;
using BSServer._Core.Const;
using BSServer._Core.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BSServer.DAOs
{
    public class ReportDAO : BaseDAO
    {
        public ReportDAO(BSContext context) : base(context)
        { }

        public List<GetCanDoiSoPhatSinhTaiKhoan> GetCanDoiSoPhatSinhTaiKhoanByKH(DateTime fromDate, DateTime toDate)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@CompanyID", CommonInfo.CompanyInfo.CompanyID),
                new SqlParameter("@FromDate", fromDate.ToString("yyyy/MM/dd 00:00:00")),
                new SqlParameter("@ToDate", toDate.ToString("yyyy/MM/dd 23:59:59"))
            };

            return this.Context
                .GetDataFromProcedure<GetCanDoiSoPhatSinhTaiKhoan>("SP_BangCanDoiSoPhatSinhTK", sqlParameters);
        }

        public List<GetBalance> GetSoDuDauKy(DateTime fromDate)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@CompanyID", CommonInfo.CompanyInfo.CompanyID),
                new SqlParameter("@FromDate", fromDate.Date)
            };

            return this.Context.GetDataFromProcedure<GetBalance>("SP_GetBalance", sqlParameters);
        }

        public List<GetChiTietTaiKhoan> GetChiTietTaiKhoan(string accountID, string accountDetailID, string customerID, DateTime fromDate, DateTime toDate)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@CompanyID", CommonInfo.CompanyInfo.CompanyID),
                new SqlParameter("@AccountID", accountID),
                new SqlParameter("@AccountDetailID", accountDetailID),
                new SqlParameter("@CustomerID", customerID),
                new SqlParameter("@FromDate", fromDate.ToString("yyyy/MM/dd 00:00:00")),
                new SqlParameter("@ToDate", toDate.ToString("yyyy/MM/dd 23:59:59"))
            };

            return this.Context.GetDataFromProcedure<GetChiTietTaiKhoan>("SP_GetChiTietTaiKhoan", sqlParameters);
        }

        public List<GetChiTietSoCai> GetChiTietSoCai(DateTime fromDate, DateTime toDate)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@CompanyID", CommonInfo.CompanyInfo.CompanyID),
                new SqlParameter("@FromDate", fromDate.Date),
                new SqlParameter("@ToDate", toDate.Date)
            };

            return this.Context.GetDataFromProcedure<GetChiTietSoCai>("SP_ChiTietSoCai", sqlParameters);
        }

        public List<ChungTuGhiSo> GetChungTuGhiSo(DateTime fromDate, DateTime toDate)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@CompanyID", CommonInfo.CompanyInfo.CompanyID),
                new SqlParameter("@FromDate", fromDate.Date),
                new SqlParameter("@ToDate", toDate.Date)
            };

            return this.Context.GetDataFromProcedure<ChungTuGhiSo>("SP_ChungTuGhiSo", sqlParameters);
        }

        public List<SoDangKyChungTuGhiSo> GetSoDangKyChungTuGhiSo(DateTime fromDate, DateTime toDate)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@CompanyID", CommonInfo.CompanyInfo.CompanyID),
                new SqlParameter("@FromDate", fromDate.Date),
                new SqlParameter("@ToDate", toDate.Date)
            };

            return this.Context.GetDataFromProcedure<SoDangKyChungTuGhiSo>("SP_SoDangKyChungTuGhiSo", sqlParameters);
        }
        
        public List<GetChiTietSoCai> GetSoQuyTienMat(DateTime fromDate, DateTime toDate)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@CompanyID", CommonInfo.CompanyInfo.CompanyID),
                new SqlParameter("@FromDate", fromDate.Date),
                new SqlParameter("@ToDate", toDate.Date)
            };

            return this.Context.GetDataFromProcedure<GetChiTietSoCai>("SP_SoQuyTienMat", sqlParameters);
        }
    }
}

using BSCommon.Models;
using BSServer._Core.Base;
using BSServer.DAOs;
using BSServer.Logics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BSServer.Controllers
{
    public class ReportController : BaseController
    {

        private ReportDAO ReportDAO { get; set; }

        private AccountsDAO AccountsDAO { get; set; }

        private AccountsLogic AccountsLogic { get; set; }

        public ReportController()
        {
            this.ReportDAO = new ReportDAO(this.Context);
            this.AccountsDAO = new AccountsDAO(this.Context);
            this.AccountsLogic = new AccountsLogic(this.Context);
        }

        public List<GetCanDoiSoPhatSinhTaiKhoan> GetBangCanDoiSoPhatSinh(DateTime fromDate, DateTime toDate, int type)
        {
            return this.AccountsLogic.GetBangCanDoiSoPhatSinh(fromDate, toDate, type);
        }

        public List<GetChiTietTaiKhoan> GetChiTietTaiKhoan(string accountID, string accountDetailID, string CustomerID, DateTime fromDate, DateTime toDate)
        {
            return this.ReportDAO.GetChiTietTaiKhoan(accountID, accountDetailID, CustomerID, fromDate, toDate);
        }

        public List<GetChiTietSoCai> GetChiTietSoCai(DateTime fromDate, DateTime toDate)
        {
            return this.ReportDAO.GetChiTietSoCai(fromDate, toDate);
        }

        public List<ChungTuGhiSo> GetChungTuGhiSo(DateTime fromDate, DateTime toDate)
        {
            return this.ReportDAO.GetChungTuGhiSo(fromDate, toDate);
        }

        public List<SoDangKyChungTuGhiSo> GetSoDangKyChungTuGhiSo(DateTime fromDate, DateTime toDate)
        {
            return this.ReportDAO.GetSoDangKyChungTuGhiSo(fromDate, toDate);
        }

        public List<GetChiTietSoCai> GetSoQuyTienMat(DateTime fromDate, DateTime toDate)
        {
            return this.ReportDAO.GetSoQuyTienMat(fromDate, toDate);
        }
    }
}

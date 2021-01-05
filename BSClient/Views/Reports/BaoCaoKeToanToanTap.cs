using BSClient.Constants;
using BSClient.Utility;
using BSCommon.Models;
using BSCommon.Utility;
using BSServer.Controllers;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;

namespace BSClient.Views.Reports
{
    public partial class BaoCaoToanTap : DevExpress.XtraEditors.XtraForm
    {
        public BaoCaoToanTap()
        {
            InitializeComponent();

            Year_DateEdit.EditValue = DateTime.Now.Date;
        }

        private void Print_Button_Click(object sender, EventArgs e)
        {
            DateTime fromDate, toDate;

            fromDate = new DateTime(Year_DateEdit.DateTime.Year, 1, 1);
            toDate = new DateTime(Year_DateEdit.DateTime.Year, 12, 31);

            List<GetChiTietSoCai> chiTietSoCais = GetChiTietSoCais(fromDate, toDate);

            List<ReportParam> param = new List<ReportParam>
            {
                new ReportParam { ParamID = "CurrencyUnit", ParamValue = CommonInfo.CompanyInfo.CurrencyUnit },
                new ReportParam { ParamID = "FromDate", ParamValue = fromDate },
                new ReportParam { ParamID = "ToDate", ParamValue = toDate },
                new ReportParam { ParamID = "PrintDate", ParamValue = DateTime.Now.Date },
                new ReportParam { ParamID = "CompanyName", ParamValue = CommonInfo.CompanyInfo.CompanyName },
                new ReportParam { ParamID = "CompanyAddress", ParamValue = CommonInfo.CompanyInfo.Address },
                new ReportParam { ParamID = "Scheduler", ParamValue = CommonInfo.CompanyInfo.LapBieu },
                new ReportParam { ParamID = "SchedulerSignature", ParamValue = CommonInfo.CompanyInfo.ChuKyLapBieu },
                new ReportParam { ParamID = "ChiefaAcountant", ParamValue = CommonInfo.CompanyInfo.KTTruong },
                new ReportParam { ParamID = "ChiefaAcountantSignture", ParamValue = CommonInfo.CompanyInfo.ChuKyKTTruong },
                new ReportParam { ParamID = "Director", ParamValue = CommonInfo.CompanyInfo.LanhDao }
            };
            XtraReport chiTietSoCai = ReportHelper.CreateDocument(ReportTemplate.RPT000002, chiTietSoCais, param);

            List<GetCanDoiSoPhatSinhTaiKhoan> canDoiSoPhatSinhTaiKhoans = GetCanDoiSoPhatSinhTaiKhoan(fromDate, toDate);
            param = new List<ReportParam>
            {
                new ReportParam { ParamID = "CurrencyUnit", ParamValue =CommonInfo.CompanyInfo.CurrencyUnit },
                new ReportParam { ParamID = "FromDate", ParamValue = fromDate },
                new ReportParam { ParamID = "ToDate", ParamValue = toDate },
                new ReportParam { ParamID = "PrintDate", ParamValue =DateTime.Now.Date },
                new ReportParam { ParamID = "CompanyName", ParamValue =CommonInfo.CompanyInfo.CompanyName },
                new ReportParam { ParamID = "CompanyAddress", ParamValue =CommonInfo.CompanyInfo.Address },
                new ReportParam { ParamID = "Scheduler", ParamValue =CommonInfo.CompanyInfo.LapBieu },
                new ReportParam { ParamID = "SchedulerSignature", ParamValue =CommonInfo.CompanyInfo.ChuKyLapBieu },
                new ReportParam { ParamID = "ChiefaAcountant", ParamValue =CommonInfo.CompanyInfo.KTTruong },
                new ReportParam { ParamID = "ChiefaAcountantSignture", ParamValue =CommonInfo.CompanyInfo.ChuKyKTTruong },
                new ReportParam { ParamID = "Director", ParamValue =CommonInfo.CompanyInfo.LanhDao }
            };

            XtraReport bangCanDoi = ReportHelper.CreateDocument(ReportTemplate.RPT000001, canDoiSoPhatSinhTaiKhoans, param);

            // Add all pages of the second report to the end of the first report.
            chiTietSoCai.ModifyDocument(x =>
            {
                x.AddPages(bangCanDoi.Pages);
            });

            chiTietSoCai.PrintingSystem.ContinuousPageNumbering = true;

            // Preview the modified report.
            ReportPrintTool reportPrintTool = new ReportPrintTool(chiTietSoCai)
            {
                AutoShowParametersPanel = false
            };
            reportPrintTool.ShowPreview();
        }

        private List<GetChiTietSoCai> GetChiTietSoCais(DateTime fromDate, DateTime toDate)
        {
            using (AccountsController controller = new AccountsController())
            {
                return controller.GetChiTietSoCai(fromDate, toDate);
            }
        }

        private List<GetCanDoiSoPhatSinhTaiKhoan> GetCanDoiSoPhatSinhTaiKhoan(DateTime fromDate, DateTime toDate)
        {
            using (AccountsController controller = new AccountsController())
            {
                return controller.GetBangCanDoiSoPhatSinh(fromDate, toDate, 1);
            }
        }
    }
}
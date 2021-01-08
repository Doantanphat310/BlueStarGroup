using BSClient.Constants;
using BSClient.Utility;
using BSCommon.Models;
using BSCommon.Utility;
using BSServer.Controllers;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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

            this.Cursor = Cursors.WaitCursor;

            List<ReportInfoView> reportInfos = GetReportInfos();

            List<ReportParam> param = new List<ReportParam>
            {
                new ReportParam("FromDate",  fromDate ),
                new ReportParam("ToDate",  toDate ),
                new ReportParam("PrintDate",  DateTime.Now.Date ),
                new ReportParam("CompanyName",  CommonInfo.CompanyInfo.CompanyName ),
                new ReportParam("CompanyAddress",  CommonInfo.CompanyInfo.Address ),
                new ReportParam("CompanyTIN",  CommonInfo.CompanyInfo.MST ),
            };

            XtraReport trangBia = ReportHelper.CreateDocument(ReportTemplate.RPT000003, reportInfos, param);
            if(trangBia == null)
            {
                return;
            }

            foreach (ReportInfoView item in reportInfos)
            {
                // Add all pages of the second report to the end of the first report.
                trangBia.ModifyDocument(x =>
                {
                    x.AddPages(item.Report.Pages);
                });

                trangBia.PrintingSystem.ContinuousPageNumbering = false;
            }

            // Preview the modified report.
            ReportPrintTool reportPrintTool = new ReportPrintTool(trangBia)
            {
                AutoShowParametersPanel = false
            };
            reportPrintTool.ShowPreview();

            this.Cursor = Cursors.Default;
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

        private List<ReportInfoView> GetReportInfos()
        {
            DateTime fromDate, toDate;
            int pageCount;

            fromDate = new DateTime(Year_DateEdit.DateTime.Year, 1, 1);
            toDate = new DateTime(Year_DateEdit.DateTime.Year, 12, 31);

            List<ReportInfoView> result = new List<ReportInfoView>();
            XtraReport report;

            if (BangCanDoiSoPhatSinhTK_CheckBox.Checked)
            {
                report = GetBangCanDoiSoPSTKReport(fromDate, toDate);
                pageCount = report.Pages.Count;

                result.Add(new ReportInfoView
                {
                    ReportID = ReportTemplate.RPT000001,
                    ReportName = BangCanDoiSoPhatSinhTK_CheckBox.Text,
                    PageStart = pageCount > 0 ? 1 : 0,
                    PageEnd = pageCount,
                    Report = report
                });
            }

            if (SoCaiTaiKhoan_CheckBox.Checked)
            {
                report = GetSoCaiTaiKhoanReport(fromDate, toDate);
                pageCount = report.Pages.Count;

                result.Add(new ReportInfoView
                {
                    ReportID = ReportTemplate.RPT000002,
                    ReportName = SoCaiTaiKhoan_CheckBox.Text,
                    PageStart = pageCount > 0 ? 1 : 0,
                    PageEnd = pageCount,
                    Report = report
                });
            }

            return result;
        }

        private XtraReport GetSoCaiTaiKhoanReport(DateTime fromDate, DateTime toDate)
        {
            List<GetChiTietSoCai> reportSource = GetChiTietSoCais(fromDate, toDate);

            List<ReportParam> param = new List<ReportParam>
            {
                new ReportParam ("CurrencyUnit",  CommonInfo.CompanyInfo.CurrencyUnit ),
                new ReportParam ("FromDate",  fromDate ),
                new ReportParam ("ToDate",  toDate ),
                new ReportParam ("PrintDate",  DateTime.Now.Date ),
                new ReportParam ("CompanyName",  CommonInfo.CompanyInfo.CompanyName ),
                new ReportParam ("CompanyAddress",  CommonInfo.CompanyInfo.Address ),
                new ReportParam ("Scheduler",  CommonInfo.CompanyInfo.LapBieu ),
                new ReportParam ("SchedulerSignature",  CommonInfo.CompanyInfo.ChuKyLapBieu ),
                new ReportParam ("ChiefaAcountant",  CommonInfo.CompanyInfo.KTTruong ),
                new ReportParam ("ChiefaAcountantSignture",  CommonInfo.CompanyInfo.ChuKyKTTruong ),
                new ReportParam ("Director",  CommonInfo.CompanyInfo.LanhDao )
            };

            return ReportHelper.CreateDocument(ReportTemplate.RPT000002, reportSource, param);
        }

        private XtraReport GetBangCanDoiSoPSTKReport(DateTime fromDate, DateTime toDate)
        {
            List<GetCanDoiSoPhatSinhTaiKhoan> reportSource = GetCanDoiSoPhatSinhTaiKhoan(fromDate, toDate);

            var param = new List<ReportParam>
            {
                new ReportParam("CurrencyUnit", CommonInfo.CompanyInfo.CurrencyUnit ),
                new ReportParam("FromDate", fromDate ),
                new ReportParam("ToDate", toDate ),
                new ReportParam("PrintDate", DateTime.Now.Date ),
                new ReportParam("CompanyName", CommonInfo.CompanyInfo.CompanyName ),
                new ReportParam("CompanyAddress", CommonInfo.CompanyInfo.Address ),
                new ReportParam("Scheduler", CommonInfo.CompanyInfo.LapBieu ),
                new ReportParam("SchedulerSignature", CommonInfo.CompanyInfo.ChuKyLapBieu ),
                new ReportParam("ChiefaAcountant", CommonInfo.CompanyInfo.KTTruong ),
                new ReportParam("ChiefaAcountantSignture", CommonInfo.CompanyInfo.ChuKyKTTruong ),
                new ReportParam("Director", CommonInfo.CompanyInfo.LanhDao)
            };

            return ReportHelper.CreateDocument(ReportTemplate.RPT000001, reportSource, param);
        }
    }

    internal class ReportInfoView : ReportInfo
    {
        public XtraReport Report { get; set; }
    }
}
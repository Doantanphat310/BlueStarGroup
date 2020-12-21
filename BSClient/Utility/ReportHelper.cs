using BSClient.Constants;
using BSCommon.Models;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSClient.Utility
{
    public static class ReportHelper
    {
        private const string ReportDir = "Reports";

        public static string GetReportDirectory()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), ReportDir);
        }

        public static void ShowPreview(this XtraReport xtraReport, string reportID, object dataSource)
        {
            xtraReport.DataSource = dataSource;
            xtraReport.RequestParameters = false;

            ReportPrintTool reportPrintTool = new ReportPrintTool(xtraReport)
            {
                AutoShowParametersPanel = false
            };

            reportPrintTool.ShowPreview();
        }

        public static void ShowPreview(string reportID, object dataSource, List<ReportParam> reportParams)
        {
            XtraReport report = new XtraReport
            {
                DataSource = dataSource,
                RequestParameters = false
            };

            foreach (var param in reportParams)
            {
                report.Parameters[param.ParamID].Value = param.ParamValue;
            }

            //report.Parameters["CurrencyUnit"].Value = "Đồng";
            //report.Parameters["FromDate"].Value = FromDate;
            //report.Parameters["ToDate"].Value = ToDate;
            //report.Parameters["PrintDate"].Value = DateTime.Now.Date;
            //report.Parameters["CompanyName"].Value = CommonInfo.CompanyInfo.CompanyName;
            //report.Parameters["CompanyAddress"].Value = CommonInfo.CompanyInfo.Address;
            //report.Parameters["Scheduler"].Value = CommonInfo.CompanyInfo.LapBieu;
            //report.Parameters["SchedulerSignature"].Value = CommonInfo.CompanyInfo.ChuKyLapBieu;
            //report.Parameters["ChiefaAcountant"].Value = CommonInfo.CompanyInfo.KTTruong;
            //report.Parameters["ChiefaAcountantSignture"].Value = CommonInfo.CompanyInfo.ChuKyKTTruong;
            //report.Parameters["Director"].Value = CommonInfo.CompanyInfo.LanhDao;

            ReportPrintTool reportPrintTool = new ReportPrintTool(report)
            {
                AutoShowParametersPanel = false
            };

            reportPrintTool.ShowPreview();
        }
    }
}

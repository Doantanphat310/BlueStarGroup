using BSClient.Constants;
using BSCommon.Models;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using System.IO;

namespace BSClient.Utility
{
    public static class ReportHelper
    {
        private const string ReportDir = @"Template\Reports";

        public static string GetReportDirectory()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), ReportDir);
        }

        public static void ShowPreview(this XtraReport xtraReport, string reportID, object dataSource)
        {
            string filePath = GetReportPath(reportID);

            if (!File.Exists(filePath))
            {
                MessageBoxHelper.ShowErrorMessage($"Mẫu báo cáo không tồn tại!\r\n{filePath}");
                return;
            }

            xtraReport.LoadLayout(filePath);
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
            string filePath = GetReportPath(reportID);

            if (!File.Exists(filePath))
            {
                MessageBoxHelper.ShowErrorMessage($"Mẫu báo cáo không tồn tại!\r\n{filePath}");
                return;
            }

            XtraReport report = new XtraReport()
            {
                RequestParameters = false
            };
            report.LoadLayout(filePath);
            report.DataSource = dataSource;

            foreach (var param in reportParams)
            {
                report.Parameters[param.ParamID].Value = param.ParamValue;
            }

            ReportPrintTool reportPrintTool = new ReportPrintTool(report)
            {
                AutoShowParametersPanel = false
            };

            reportPrintTool.ShowPreview();
        }

        private static string GetReportPath(string reportID)
        {
            string dir = GetReportDirectory();
            string reportPath = Path.Combine(dir, $"{ReportTemplate.GetTemplate(reportID)}.repx");

            return reportPath;
        }
    }
}

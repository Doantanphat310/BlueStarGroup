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
        private const string ReportDir = @"Template\Reports";

        public static string GetReportDirectory()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), ReportDir);
        }

        //public static void ShowPreview(this XtraReport xtraReport, string reportID, object dataSource)
        //{
        //    xtraReport.DataSource = dataSource;
        //    xtraReport.RequestParameters = false;

        //    ReportPrintTool reportPrintTool = new ReportPrintTool(xtraReport)
        //    {
        //        AutoShowParametersPanel = false
        //    };

        //    reportPrintTool.ShowPreview();
        //}

        public static void ShowPreview(string reportID, object dataSource, List<ReportParam> reportParams)
        {
            string dir = GetReportDirectory();
            string template = ReportTemplate.GetTemplate(reportID);
            string filePath = Path.Combine(dir, template);

            if (File.Exists(filePath))
            {
                MessageBoxHelper.ShowErrorMessage($"Mẫu báo cáo không tồn tại!\r\n{filePath}");
                return;
            }

            XtraReport report = new XtraReport()
            {
                DataSource = dataSource,
                RequestParameters = false
            };
            report.LoadLayout(filePath);

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
            string reportPath = Path.Combine(dir, ReportTemplate.GetTemplate(reportID));

            return reportPath;
        }
    }
}

using BSClient.Report;
using BSClient.Utility;
using BSCommon.Models;
using BSCommon.Utility;
using BSServer.Controllers;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace BSClient.Views
{
    public partial class BangCanDoiSoPhatSinhTKReport : XtraForm
    {
        public BindingList<BangCanDoiSoPhatSinhTK> ReportData { get; set; }

        private DateTime FromDate { get; set; }

        private DateTime ToDate { get; set; }

        public BangCanDoiSoPhatSinhTKReport()
        {
            InitializeComponent();

            FromDate = new DateTime(DateTime.Now.Year, 01, 01);
            ToDate = new DateTime(DateTime.Now.Year, 12, 31);
            From_DateEdit.DateTime = FromDate;
            To_DateEdit.DateTime = ToDate;

            LoadGrid();

            InitComboBox();
        }

        private void InitComboBox()
        {
            TypeSearch_LookUpEdit.Properties.DataSource = new string[] { "Tài khoản", "Tài khoản - Thống kê" };
        }

        private void LoadGrid()
        {
            InitGridView();

            SetupGridView();

            LoadDataGridView();
        }

        private void InitGridView()
        {
            Main_GridView.Columns.Clear();
            this.Main_GridView.AddColumn("AccountID", "Mã Tài Khoản", 90, false);
            this.Main_GridView.AddColumn("AccountName", "Tên Tài Khoản", 300, false, fixedWidth: false);
            this.Main_GridView.AddColumn("AccountDetailID", "T.kê", 50, false);
            this.Main_GridView.AddColumn("CustomerID", "Mã KH", 90, false);
            this.Main_GridView.AddSpinEditColumn("DKNo", "Nợ", 120, false, summaryType: DevExpress.Data.SummaryItemType.Sum);
            this.Main_GridView.AddSpinEditColumn("DKCo", "Có", 120, false, summaryType: DevExpress.Data.SummaryItemType.Sum);
            this.Main_GridView.AddSpinEditColumn("PSNo", "Nợ", 120, false, summaryType: DevExpress.Data.SummaryItemType.Sum);
            this.Main_GridView.AddSpinEditColumn("PSCo", "Có", 120, false, summaryType: DevExpress.Data.SummaryItemType.Sum);
            this.Main_GridView.AddSpinEditColumn("CKNo", "Nợ", 120, false, summaryType: DevExpress.Data.SummaryItemType.Sum);
            this.Main_GridView.AddSpinEditColumn("CKCo", "Có", 120, false, summaryType: DevExpress.Data.SummaryItemType.Sum);
        }

        private void SetupGridView()
        {
            this.Main_GridView.SetupGridView(multiSelect: false, checkBoxSelectorColumnWidth: 0, showAutoFilterRow: false, newItemRow: NewItemRowPosition.None, showFooter: true);
        }

        private void LoadDataGridView()
        {
            using (AccountsController controller = new AccountsController())
            {
                ReportData = new BindingList<BangCanDoiSoPhatSinhTK>(controller.GetBangCanDoiSoPhatSinhByThongKe(FromDate, ToDate));

                Main_GridControl.DataSource = ReportData;
            }
        }

        private void Print_Button_Click(object sender, EventArgs e)
        {
            //string path = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "BangCanDoiSoPhatSinhTaiKhoan.repx");
            //XtraReport report = new XtraReport();
            //report.LoadLayout(path);

            BangCanDoiSoPhatSinhTaiKhoanReport report = new BangCanDoiSoPhatSinhTaiKhoanReport();

            report.DataSource = ReportData;

            report.RequestParameters = false;
            report.Parameters["CurrencyUnit"].Value = "Đồng";
            report.Parameters["FromDate"].Value = FromDate;
            report.Parameters["ToDate"].Value = ToDate;
            report.Parameters["PrintDate"].Value = DateTime.Now.Date;
            report.Parameters["CompanyName"].Value = CommonInfo.CompanyInfo.CompanyName;
            report.Parameters["CompanyAddress"].Value = CommonInfo.CompanyInfo.Address;
            report.Parameters["Scheduler"].Value = CommonInfo.CompanyInfo.LapBieu;
            report.Parameters["SchedulerSignature"].Value = CommonInfo.CompanyInfo.ChuKyLapBieu;
            report.Parameters["ChiefaAcountant"].Value = CommonInfo.CompanyInfo.KTTruong;
            report.Parameters["ChiefaAcountantSignture"].Value = CommonInfo.CompanyInfo.ChuKyKTTruong;
            report.Parameters["Director"].Value = CommonInfo.CompanyInfo.LanhDao;
            ReportPrintTool reportPrintTool = new ReportPrintTool(report);
            reportPrintTool.AutoShowParametersPanel = false;
            reportPrintTool.ShowPreview();
        }

        private void SearchData_Button_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Refresh();
            FromDate = From_DateEdit.DateTime;
            ToDate = To_DateEdit.DateTime;
            LoadDataGridView();
            this.Cursor = Cursors.Default;
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExportExcel_Button_Click(object sender, EventArgs e)
        {
            SaveFileDialog openFileDialog = new SaveFileDialog
            {
                Filter = "Excel file(*.xlsx)|*.xlsx"
            };

            string path = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
            }

            Main_GridControl.ExportToXlsx(path);
        }

        private void Main_GridControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Main_GridControl_MouseDoubleClick");
        }

        private void Main_GridView_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {
                Console.WriteLine("Main_GridView_RowClick");
            }
        }
    }
}

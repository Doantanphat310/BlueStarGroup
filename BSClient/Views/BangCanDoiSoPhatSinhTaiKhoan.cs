using BSClient.Utility;
using BSCommon.Models;
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

        public BangCanDoiSoPhatSinhTKReport()
        {
            InitializeComponent();

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
            this.Main_GridView.AddColumn("AccountID", "Mã Tài Khoản", 100, false);
            this.Main_GridView.AddColumn("AccountName", "Tên Tài Khoản", 250, false);
            this.Main_GridView.AddColumn("AccountDetailID", "T.kê", 70, false);
            this.Main_GridView.AddColumn("CustomerID", "Mã KH", 70, false);
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
                DateTime fromDate = From_DateEdit.DateTime;
                DateTime toDate = To_DateEdit.DateTime;
                ReportData = new BindingList<BangCanDoiSoPhatSinhTK>(controller.GetBangCanDoiSoPhatSinhByThongKe(fromDate, toDate));

                Main_GridControl.DataSource = ReportData;
            }
        }

        private void Print_Button_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "BangCanDoiSoPhatSinhTaiKhoan.repx");
            XtraReport report = new XtraReport();

            report.LoadLayout(path);
            report.DataSource = ReportData;

            report.RequestParameters = false;
            //report.Parameters["CurrencyUnit"].Value = "USD";
            ReportPrintTool reportPrintTool = new ReportPrintTool(report);
            reportPrintTool.ShowPreview();
        }

        private void SearchData_Button_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Refresh();
            LoadDataGridView();
            this.Cursor = Cursors.Default;
        }

        private void LoadData()
        {

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

            string path = "BangCanDoiPS.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
            }

            Main_GridControl.ExportToXlsx(path);
        }
    }
}

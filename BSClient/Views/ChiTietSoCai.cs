using BSClient.Report;
using BSClient.Utility;
using BSCommon.Constant;
using BSCommon.Models;
using BSCommon.Utility;
using BSServer.Controllers;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace BSClient.Views
{
    public partial class ChiTietSoCai : XtraForm
    {
        public BindingList<GetChiTietSoCai> ReportData { get; set; }

        private DateTime FromDate { get; set; }

        private DateTime ToDate { get; set; }

        public ChiTietSoCai()
        {
            InitializeComponent();

            FromDate = new DateTime(DateTime.Now.Year, 01, 01);
            ToDate = new DateTime(DateTime.Now.Year, 12, 31);
            From_DateEdit.DateTime = FromDate;
            To_DateEdit.DateTime = ToDate;

            LoadGrid();
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
            this.Main_GridView.AddColumn("AccountID", "Mã TK", 60, false);
            this.Main_GridView.AddColumn("AccountDetailID", "T.kê", 50, false);
            this.Main_GridView.AddColumn("AccountName", "Tên Tài Khoản", 200, false, fixedWidth: false);

            this.Main_GridView.AddColumn("VoucherDate", "Ngày GS", 80, false);
            this.Main_GridView.AddColumn("VoucherstypeID", "Loại CT", 50, false);
            this.Main_GridView.AddColumn("VoucherNo", "Số CT", 50, false);
            this.Main_GridView.AddColumn("VoucherDescription", "Nội dung", 200, false);

            this.Main_GridView.AddColumn("CorrespondingAccountID", "Mã TK Đ.ứng", 70, false);
            this.Main_GridView.AddColumn("CorrespondingAccountDetailID", "T.kê Đ.ứng", 50, false);
            this.Main_GridView.AddSpinEditColumn("PSNo", "Nợ", 110, false, summaryType: DevExpress.Data.SummaryItemType.Sum);
            this.Main_GridView.AddSpinEditColumn("PSCo", "Có", 110, false, summaryType: DevExpress.Data.SummaryItemType.Sum);
        }

        private void SetupGridView()
        {
            this.Main_GridView.SetupGridView(multiSelect: false, checkBoxSelectorColumnWidth: 0, showAutoFilterRow: false, newItemRow: NewItemRowPosition.None, showFooter: true);
        }

        private void LoadDataGridView()
        {
            using (AccountsController controller = new AccountsController())
            {
                ReportData = new BindingList<GetChiTietSoCai>(controller.GetChiTietSoCai(FromDate, ToDate));

                Main_GridControl.DataSource = ReportData;
            }
        }

        private void Print_Button_Click(object sender, EventArgs e)
        {
            //string path = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "BangCanDoiSoPhatSinhTaiKhoan.repx");
            //XtraReport report = new XtraReport();
            //report.LoadLayout(path);

            SoCaiChiTietReport report = new SoCaiChiTietReport();

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
                Filter = "Excel file(*.xlsx)|*.xlsx",
                FileName = this.Name
            };

            string path = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
            }

            Main_GridControl.ExportToXlsx(path);
        }

        private void Main_GridView_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {
                var selected = Main_GridView.GetFocusedRow().CastTo<GetCanDoiSoPhatSinhTaiKhoan>();

                if (selected == null)
                {
                    MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000026);
                    return;
                }

                ChiTietTaiKhoan.ChiTietTaiKhoanInput input = new ChiTietTaiKhoan.ChiTietTaiKhoanInput
                {
                    FromDate = this.FromDate,
                    ToDate = this.ToDate,
                    SelectedData = selected
                };
                ChiTietTaiKhoan chiTietTaiKhoan = new ChiTietTaiKhoan(input);
                chiTietTaiKhoan.ShowDialog();
            }
        }
    }
}

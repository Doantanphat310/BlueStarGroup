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
    public partial class ChiTietTaiKhoan : XtraForm
    {
        public BindingList<GetChiTietTaiKhoan> MainData { get; set; }

        private DateTime FromDate { get; set; }

        private DateTime ToDate { get; set; }

        private ChiTietTaiKhoanInput InputData { get; set; }

        public ChiTietTaiKhoan(ChiTietTaiKhoanInput input)
        {
            InitializeComponent();

            InputData = input;

            DKNo_SpinEdit.Value = input.SelectedData.DKNo;
            DKCo_SpinEdit.Value = input.SelectedData.DKCo;
            PSNo_SpinEdit.Value = input.SelectedData.PSNo;
            PSCo_SpinEdit.Value = input.SelectedData.PSCo;
            CKNo_SpinEdit.Value = input.SelectedData.CKNo;
            CKCo_SpinEdit.Value = input.SelectedData.CKCo;

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
            this.Main_GridView.AddColumn("VoucherDate", "Ngày", 90, false);
            this.Main_GridView.AddColumn("VouchersTypeID", "Loại", 70, false);
            this.Main_GridView.AddColumn("VoucherNo", "Số CT", 50, false);
            this.Main_GridView.AddColumn("VoucherDescription", "Nội dung", 90, false, fixedWidth: false);
            this.Main_GridView.AddSpinEditColumn("DebitAmount", "Nợ", 120, false, summaryType: DevExpress.Data.SummaryItemType.Sum);
            this.Main_GridView.AddSpinEditColumn("CreditAmount", "Có", 120, false, summaryType: DevExpress.Data.SummaryItemType.Sum);
        }

        private void SetupGridView()
        {
            this.Main_GridView.SetupGridView(columnAutoWidth: true, multiSelect: false, checkBoxSelectorColumnWidth: 0, showAutoFilterRow: false, newItemRow: NewItemRowPosition.None, showFooter: true);
        }

        private void LoadDataGridView()
        {
            using (AccountsController controller = new AccountsController())
            {
                MainData = new BindingList<GetChiTietTaiKhoan>(controller.GetChiTietTaiKhoan(InputData.SelectedData.AccountID, InputData.SelectedData.AccountDetailID, InputData.FromDate, InputData.ToDate));

                Main_GridControl.DataSource = MainData;
            }
        }

        private void Print_Button_Click(object sender, EventArgs e)
        {
            //string path = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "BangCanDoiSoPhatSinhTaiKhoan.repx");
            //XtraReport report = new XtraReport();
            //report.LoadLayout(path);

            //BangCanDoiSoPhatSinhTaiKhoanReport report = new BangCanDoiSoPhatSinhTaiKhoanReport();

            //report.DataSource = MainData;

            //report.RequestParameters = false;
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
            //ReportPrintTool reportPrintTool = new ReportPrintTool(report);
            //reportPrintTool.AutoShowParametersPanel = false;
            //reportPrintTool.ShowPreview();
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

        public class ChiTietTaiKhoanInput
        {
            public DateTime FromDate { get; set; }

            public DateTime ToDate { get; set; }

            public BangCanDoiSoPhatSinhTK SelectedData { get; set; }
        }
    }
}

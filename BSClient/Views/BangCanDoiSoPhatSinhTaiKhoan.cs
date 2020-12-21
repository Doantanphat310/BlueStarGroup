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
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace BSClient.Views
{
    public partial class BangCanDoiSoPhatSinhTaiKhoan : XtraForm
    {
        public BindingList<GetCanDoiSoPhatSinhTaiKhoan> ReportData { get; set; }

        private DateTime FromDate { get; set; }

        private DateTime ToDate { get; set; }

        public BangCanDoiSoPhatSinhTaiKhoan()
        {
            InitializeComponent();

            FromDate = new DateTime(2019, 01, 01);
            ToDate = new DateTime(2019, 12, 31);
            From_DateEdit.DateTime = FromDate;
            To_DateEdit.DateTime = ToDate;           
        }

        private void InitComboBox()
        {
            List<string> typeSource = new List<string> 
            {
                "Tài khoản", 
                "Tài khoản - Thống kê", 
                "Tài khoản - Thống kê - Khách hàng"
            };
            TypeSearch_LookUpEdit.Properties.DataSource = typeSource;
            TypeSearch_LookUpEdit.ItemIndex = 1;
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
            this.Main_GridView.AddColumn("AccountID", "Mã TK", 70, false);
            this.Main_GridView.AddColumn("AccountName", "Tên Tài Khoản", 300, false, fixedWidth: false);

            if (TypeSearch_LookUpEdit.ItemIndex == 0)
            {
            }
            else if (TypeSearch_LookUpEdit.ItemIndex == 1)
            {
                this.Main_GridView.AddColumn("AccountDetailID", "T.kê", 50, false);
            }
            else
            {
                this.Main_GridView.AddColumn("AccountDetailID", "T.kê", 50, false);
                this.Main_GridView.AddColumn("CustomerID", "Mã KH", 90, false);
            }

            this.Main_GridView.AddSpinEditColumn("DKNo", "Nợ", 110, false, summaryType: DevExpress.Data.SummaryItemType.Sum);
            this.Main_GridView.AddSpinEditColumn("DKCo", "Có", 110, false, summaryType: DevExpress.Data.SummaryItemType.Sum);
            this.Main_GridView.AddSpinEditColumn("PSNo", "Nợ", 110, false, summaryType: DevExpress.Data.SummaryItemType.Sum);
            this.Main_GridView.AddSpinEditColumn("PSCo", "Có", 110, false, summaryType: DevExpress.Data.SummaryItemType.Sum);
            this.Main_GridView.AddSpinEditColumn("CKNo", "Nợ", 110, false, summaryType: DevExpress.Data.SummaryItemType.Sum);
            this.Main_GridView.AddSpinEditColumn("CKCo", "Có", 110, false, summaryType: DevExpress.Data.SummaryItemType.Sum);
        }

        private void SetupGridView()
        {
            this.Main_GridView.SetupGridView(multiSelect: false, checkBoxSelectorColumnWidth: 0, showAutoFilterRow: false, newItemRow: NewItemRowPosition.None, showFooter: true, columnAutoWidth: true);
        }

        private void LoadDataGridView()
        {
            using (AccountsController controller = new AccountsController())
            {
                List<GetCanDoiSoPhatSinhTaiKhoan> data = controller.GetBangCanDoiSoPhatSinhChiTiet(FromDate, ToDate); ;
                ReportData = new BindingList<GetCanDoiSoPhatSinhTaiKhoan>();

                if (TypeSearch_LookUpEdit.ItemIndex == 0)
                {
                    data = GetBangCanDoiSoPhatSinhTKByTK(data);
                }
                else if (TypeSearch_LookUpEdit.ItemIndex == 1)
                {
                    data = GetBangCanDoiSoPhatSinhTKByThongKe(data);
                }
                else
                {
                }

                ReportData = new BindingList<GetCanDoiSoPhatSinhTaiKhoan>(data);

                Main_GridControl.DataSource = ReportData;
            }
        }

        public List<GetCanDoiSoPhatSinhTaiKhoan> GetBangCanDoiSoPhatSinhTKByTK(List<GetCanDoiSoPhatSinhTaiKhoan> data)
        {
            data = data.GroupBy(o => o.AccountID)
                .Select(o => new GetCanDoiSoPhatSinhTaiKhoan
                {
                    AccountID = o.Key,
                    AccountName = o.Max(s => s.AccountName),
                    DKNo = o.Sum(s => s.DKNo),
                    DKCo = o.Sum(s => s.DKCo),
                    PSNo = o.Sum(s => s.PSNo),
                    PSCo = o.Sum(s => s.PSCo),
                    CKNo = o.Sum(s => s.CKNo),
                    CKCo = o.Sum(s => s.CKCo)
                }).ToList();

            return data;
        }

        public List<GetCanDoiSoPhatSinhTaiKhoan> GetBangCanDoiSoPhatSinhTKByThongKe(List<GetCanDoiSoPhatSinhTaiKhoan> data)
        {
            data = data
                .GroupBy(o => new
                {
                    o.AccountID,
                    o.AccountDetailID
                })
                .Select(o => new GetCanDoiSoPhatSinhTaiKhoan
                {
                    AccountID = o.Key.AccountID,
                    AccountDetailID = o.Key.AccountDetailID,
                    AccountName = o.Max(s => s.AccountName),
                    DKNo = o.Sum(s => s.DKNo),
                    DKCo = o.Sum(s => s.DKCo),
                    PSNo = o.Sum(s => s.PSNo),
                    PSCo = o.Sum(s => s.PSCo),
                    CKNo = o.Sum(s => s.CKNo),
                    CKCo = o.Sum(s => s.CKCo)
                }).ToList();

            return data;
        }

        private void Print_Button_Click(object sender, EventArgs e)
        {
            BangCanDoiSoPhatSinhTaiKhoanReport report = new BangCanDoiSoPhatSinhTaiKhoanReport
            {
                DataSource = ReportData,
                RequestParameters = false
            };

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

            ReportPrintTool reportPrintTool = new ReportPrintTool(report)
            {
                AutoShowParametersPanel = false
            };
            reportPrintTool.ShowPreview();
        }

        private void SearchData_Button_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Refresh();

            FromDate = From_DateEdit.DateTime.Date;
            ToDate = To_DateEdit.DateTime.Date;

            LoadGrid();

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

        private void SoCai_Button_Click(object sender, EventArgs e)
        {
            //XtraReport report = new XtraReport();
            //report.LoadLayout(ClientCommon.GetReportDirectory());

            //ReportHelper.ShowPreview()

            SoCaiChiTietReport report = new SoCaiChiTietReport
            {
                DataSource = this.GetChiTietSoCais(),
                RequestParameters = false
            };

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

            ReportPrintTool reportPrintTool = new ReportPrintTool(report)
            {
                AutoShowParametersPanel = false
            };
            reportPrintTool.ShowPreview();
        }

        private List<GetChiTietSoCai> GetChiTietSoCais()
        {
            using (AccountsController controller = new AccountsController())
            {
                return controller.GetChiTietSoCai(FromDate, ToDate);
            }
        }

        private void BangCanDoiSoPhatSinhTaiKhoan_Load(object sender, EventArgs e)
        {
            InitComboBox();

            LoadGrid();
        }
    }
}

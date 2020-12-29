using BSClient.Constants;
using BSClient.Utility;
using BSCommon.Constant;
using BSCommon.Models;
using BSCommon.Utility;
using BSServer.Controllers;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace BSClient.Views.Reports
{
    public partial class BangCanDoiSoPhatSinhTaiKhoanReport : XtraForm
    {
        public bool IsScreenShow { get; set; } = true;

        private BindingList<GetCanDoiSoPhatSinhTaiKhoan> ReportData { get; set; }

        private DateTime FromDate { get; set; }

        private DateTime ToDate { get; set; }

        public BangCanDoiSoPhatSinhTaiKhoanReport()
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
            this.Main_GridView.SetupGridView(
                multiSelect: false,
                checkBoxSelectorColumnWidth: 0,
                showAutoFilterRow: false,
                newItemRow: NewItemRowPosition.None,
                showFooter: true,
                columnAutoWidth: true,
                hasShowRowHeader: true);
        }

        private void LoadDataGridView()
        {
            using (AccountsController controller = new AccountsController())
            {
                ReportData = new BindingList<GetCanDoiSoPhatSinhTaiKhoan>();
                var data = controller.GetBangCanDoiSoPhatSinh(FromDate, ToDate, TypeSearch_LookUpEdit.ItemIndex);

                ReportData = new BindingList<GetCanDoiSoPhatSinhTaiKhoan>(data);

                Main_GridControl.DataSource = ReportData;
            }
        }

        private void Print_Button_Click(object sender, EventArgs e)
        {
            List<ReportParam> param = new List<ReportParam>
            {
                new ReportParam { ParamID = "CurrencyUnit", ParamValue =CommonInfo.CompanyInfo.CurrencyUnit },
                new ReportParam { ParamID = "FromDate", ParamValue =FromDate },
                new ReportParam { ParamID = "ToDate", ParamValue =ToDate },
                new ReportParam { ParamID = "PrintDate", ParamValue =DateTime.Now.Date },
                new ReportParam { ParamID = "CompanyName", ParamValue =CommonInfo.CompanyInfo.CompanyName },
                new ReportParam { ParamID = "CompanyAddress", ParamValue =CommonInfo.CompanyInfo.Address },
                new ReportParam { ParamID = "Scheduler", ParamValue =CommonInfo.CompanyInfo.LapBieu },
                new ReportParam { ParamID = "SchedulerSignature", ParamValue =CommonInfo.CompanyInfo.ChuKyLapBieu },
                new ReportParam { ParamID = "ChiefaAcountant", ParamValue =CommonInfo.CompanyInfo.KTTruong },
                new ReportParam { ParamID = "ChiefaAcountantSignture", ParamValue =CommonInfo.CompanyInfo.ChuKyKTTruong },
                new ReportParam { ParamID = "Director", ParamValue =CommonInfo.CompanyInfo.LanhDao }
            };

            ReportHelper.ShowPreview(ReportTemplate.RPT000001, ReportData, param);
        }

        private void SearchData_Button_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

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
            Main_GridControl.ExportExcel(ReportTemplate.GetTemplate(ReportTemplate.RPT000001));
        }

        private void Main_GridView_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2 && this.IsScreenShow)
            {
                ShowChiTietTaiKhoanForm();
            }
        }

        private void ShowChiTietTaiKhoanForm()
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

        private void SoCai_Button_Click(object sender, EventArgs e)
        {
            if (this.IsScreenShow)
            {
                ShowChiTietTaiKhoanForm();
            }
            else
            {
                ShowSoCaiReport();
            }
        }

        private void ShowSoCaiReport()
        {
            List<GetChiTietSoCai> reportData = GetChiTietSoCais();

            List<ReportParam> param = new List<ReportParam>
            {
                new ReportParam { ParamID = "CurrencyUnit", ParamValue = CommonInfo.CompanyInfo.CurrencyUnit },
                new ReportParam { ParamID = "FromDate", ParamValue = FromDate },
                new ReportParam { ParamID = "ToDate", ParamValue = ToDate },
                new ReportParam { ParamID = "PrintDate", ParamValue = DateTime.Now.Date },
                new ReportParam { ParamID = "CompanyName", ParamValue = CommonInfo.CompanyInfo.CompanyName },
                new ReportParam { ParamID = "CompanyAddress", ParamValue = CommonInfo.CompanyInfo.Address },
                new ReportParam { ParamID = "Scheduler", ParamValue = CommonInfo.CompanyInfo.LapBieu },
                new ReportParam { ParamID = "SchedulerSignature", ParamValue = CommonInfo.CompanyInfo.ChuKyLapBieu },
                new ReportParam { ParamID = "ChiefaAcountant", ParamValue = CommonInfo.CompanyInfo.KTTruong },
                new ReportParam { ParamID = "ChiefaAcountantSignture", ParamValue = CommonInfo.CompanyInfo.ChuKyKTTruong },
                new ReportParam { ParamID = "Director", ParamValue = CommonInfo.CompanyInfo.LanhDao }
            };

            ReportHelper.ShowPreview(ReportTemplate.RPT000002, reportData, param);
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

            SetVisibleControl();
        }

        private void SetVisibleControl()
        {
            KetChuyen_Button.Visible = this.IsScreenShow;
        }

        private void KetChuyen_Button_Click(object sender, EventArgs e)
        {

        }
    }
}

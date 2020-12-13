using BSClient.Utility;
using BSCommon.Models;
using BSServer.Controllers;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using System;
using System.ComponentModel;
using System.IO;

namespace BSClient.Views
{
    public partial class BangCanDoiSoPhatSinhTKReport : XtraForm
    {
        public BindingList<BangCanDoiSoPhatSinhTK> ReportData { get; set; }

        public BangCanDoiSoPhatSinhTKReport()
        {
            InitializeComponent();

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
            this.Main_GridView.AddColumn("AccountID", "Mã Tài Khoản", 100, false);
            this.Main_GridView.AddColumn("AccountName", "Tên Tài Khoản", 250, false);
            this.Main_GridView.AddColumn("ThongKe", "Thống Kê", 70, false);
            this.Main_GridView.AddColumn("NgayPS", "Ngày PS", 100, false);
            this.Main_GridView.AddColumn("DKNo", "Nợ", 120, false);
            this.Main_GridView.AddColumn("DKCo", "Có", 120, false);
            this.Main_GridView.AddColumn("PSNo", "Nợ", 120, false);
            this.Main_GridView.AddColumn("PSCo", "Có", 120, false);
            this.Main_GridView.AddColumn("CKNo", "Nợ", 120, false);
            this.Main_GridView.AddColumn("CKCo", "Có", 120, false);
        }

        private void SetupGridView()
        {
            this.Main_GridView.SetupGridView(multiSelect: false, checkBoxSelectorColumnWidth: 0, showAutoFilterRow: false, newItemRow: NewItemRowPosition.None);
        }

        private void LoadDataGridView()
        {
            using (AccountsController controller = new AccountsController())
            {
                ReportData = new BindingList<BangCanDoiSoPhatSinhTK>(controller.GetBangCanDoiSoPhatSinhTK());

                decimal dkNo, dkCo, psNo, psCo, ckNo, ckCo, ck;
                Random random = new Random();
                foreach (var item in ReportData)
                {
                    dkNo = dkCo = psCo = ckNo = ckCo = 0;
                    int isDk = random.Next(0, 1);
                    double dk = random.NextDouble();
                    if (isDk > 0)
                    {
                        dkCo = RoundToNextDime(Math.Round(dk * 100000));
                    }
                    else
                    {
                        dkNo = RoundToNextDime(Math.Round(dk * 100000));
                    }

                    dk = random.NextDouble();
                    psNo = RoundToNextDime(Math.Round(dk * 100000));

                    dk = random.NextDouble();
                    psCo = RoundToNextDime(Math.Round(dk * 100000));

                    ck = dkCo + psCo + dkNo * (-1) + psNo * (-1);
                    if (ck > 0)
                    {
                        ckCo = ck;
                    }
                    else
                    {
                        ckNo = -1 * ck;
                    }

                    item.ThongKe = "01";
                    item.DKNo = dkNo;
                    item.DKCo = dkCo;
                    item.PSNo = psNo;
                    item.PSCo = psCo;
                    item.CKNo = ckNo;
                    item.CKCo = ckCo;
                }

                Main_GridControl.DataSource = ReportData;
            }
        }

        private decimal RoundToNextDime(double d, int degit = 3)
        {
            double value = Math.Pow(10, degit);
            double temp = Math.Floor(d / value);
            return Convert.ToDecimal(temp * value);
        }

        private void Print_Button_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Report", "BangCanDoiSoPhatSinhTaiKhoan.repx");
            XtraReport report = new XtraReport();

            report.LoadLayout(path);
            report.DataSource = ReportData;

            report.RequestParameters = false;
            //report.Parameters["CurrencyUnit"].Value = "USD";
            ReportPrintTool reportPrintTool = new ReportPrintTool(report);
            reportPrintTool.ShowPreview();
        }
    }
}

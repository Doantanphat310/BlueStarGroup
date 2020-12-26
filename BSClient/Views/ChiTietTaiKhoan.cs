using BSClient.Utility;
using BSCommon.Models;
using BSCommon.Utility;
using BSServer.Controllers;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BSClient.Views
{
    public partial class ChiTietTaiKhoan : XtraForm
    {
        private BindingList<GetChiTietTaiKhoan> MainData { get; set; }

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
            this.Main_GridView.AddDateEditColumn("VoucherDate", "Ngày", 90, false);
            this.Main_GridView.AddColumn("VouchersTypeID", "Loại", 70, false);
            this.Main_GridView.AddColumn("VoucherNo", "Số CT", 50, false);
            this.Main_GridView.AddColumn("VoucherDescription", "Nội dung", 90, false, fixedWidth: false);
            this.Main_GridView.AddSpinEditColumn("DebitAmount", "Nợ", 120, false, summaryType: DevExpress.Data.SummaryItemType.Sum);
            this.Main_GridView.AddSpinEditColumn("CreditAmount", "Có", 120, false, summaryType: DevExpress.Data.SummaryItemType.Sum);
        }

        private void SetupGridView()
        {
            this.Main_GridView.SetupGridView(
                columnAutoWidth: true, 
                multiSelect: false, 
                checkBoxSelectorColumnWidth: 0, 
                showAutoFilterRow: false, 
                newItemRow: NewItemRowPosition.None, 
                showFooter: true);
        }

        private void LoadDataGridView()
        {
            using (AccountsController controller = new AccountsController())
            {
                var data = controller.GetChiTietTaiKhoan(
                    InputData.SelectedData.AccountID, 
                    InputData.SelectedData.AccountDetailID, 
                    InputData.SelectedData.CustomerID, 
                    InputData.FromDate, 
                    InputData.ToDate);
                MainData = new BindingList<GetChiTietTaiKhoan>(data);

                Main_GridControl.DataSource = MainData;
            }
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

            try
            {
                Main_GridControl.ExportToXlsx(path);
                System.Diagnostics.Process.Start(path);
            }
            catch (Exception ex)
            {
                BSLog.Logger.Warn(ex.Message);
                MessageBoxHelper.ShowErrorMessage($"Xuất excel thất bại!\r\n{ex.Message}");
            }
        }

        public class ChiTietTaiKhoanInput
        {
            public DateTime FromDate { get; set; }

            public DateTime ToDate { get; set; }

            public GetCanDoiSoPhatSinhTaiKhoan SelectedData { get; set; }
        }
    }
}

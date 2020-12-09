using BSClient.Utility;
using BSCommon.Models;
using BSServer.Controllers;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;

namespace BSClient.Views
{
    public partial class BangCanDoiPhatSinhTK : XtraUserControl
    {
        public BindingList<Company> CompanyData { get; set; }

        public BangCanDoiPhatSinhTK()
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
            this.Main_GridView.AddColumn("ThongKe", "Thống Kê", 250, false);
            this.Main_GridView.AddColumn("NgayPS", "Ngày PS", 250, false);
            this.Main_GridView.AddColumn("DKNo", "Nợ", 80, false);
            this.Main_GridView.AddColumn("DKCo", "Có", 100, false);
            this.Main_GridView.AddColumn("PSNo", "Nợ", 100, false);
            this.Main_GridView.AddColumn("PSCo", "Có", 100, false);
            this.Main_GridView.AddColumn("CKNo", "Nợ", 100, false);
            this.Main_GridView.AddColumn("CKCo", "Có", 100, false);
        }

        private void SetupGridView()
        {
            this.Main_GridView.SetupGridView(multiSelect: false, checkBoxSelectorColumnWidth: 0, showAutoFilterRow: false, newItemRow: NewItemRowPosition.None);
        }

        private void LoadDataGridView()
        {
            //using (CompanyController controller = new CompanyController())
            //{
            //    CompanyData = new BindingList<Company>(controller.GetCompanys());
            //    Main_GridControl.DataSource = CompanyData;
            //}
        }

        private void Print_Button_Click(object sender, EventArgs e)
        {

        }
    }
}

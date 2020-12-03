using BSClient.Base;
using BSClient.Utility;
using BSCommon.Constant;
using BSCommon.Models;
using BSCommon.Utility;
using BSServer.Controllers;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BSClient.Views
{
    public partial class CompanyList : XtraUserControl
    {
        public BindingList<Company> CompanyData { get; set; }

        public List<Company> CompanyDeleteData { get; set; } = new List<Company>();

        public CompanyList()
        {
            InitializeComponent();

            LoadGrid();
        }

        private void LoadGrid()
        {
            InitGridView();

            SetupGridView();

            LoadGridView();
        }

        private void InitGridView()
        {
            Company_GridView.Columns.Clear();
            this.Company_GridView.AddColumn("CompanyID", "Mã Khách hàng", 100, false);
            this.Company_GridView.AddColumn("CompanyName", "Tên Khách hàng", 250, false);
            this.Company_GridView.AddColumn("CompanySName", "Tên viết tắt", 100, false);
            this.Company_GridView.AddColumn("Phone", "Điện thoại", 80, false);
            this.Company_GridView.AddColumn("Address", "Địa chỉ", 350);
            this.Company_GridView.AddColumn("MST", "MST", 350);
            this.Company_GridView.AddColumn("District", "Quận", 350);
            this.Company_GridView.AddColumn("Province", "Tỉnh", 350);
            this.Company_GridView.AddColumn("Fax", "FAX", 350);
            this.Company_GridView.AddColumn("Email", "Email", 350);
            this.Company_GridView.AddColumn("AccountBank", "Tài khoản NH", 100);
            this.Company_GridView.AddColumn("Bank", "Ngân hàng", 100);
            this.Company_GridView.AddColumn("BranchBank", "Chi nhánh ngân hàng", 100);
        }

        private void SetupGridView()
        {
            this.Company_GridView.SetupGridView();
        }

        private void LoadGridView()
        {
            CompanyController controller = new CompanyController();
            CompanyData = new BindingList<Company>(controller.GetCompanys());
            Company_GridControl.DataSource = CompanyData;
        }

        private void Company_GridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            Company row = e.Row.CastTo<Company>();
            bool isNewRow = Company_GridView.IsNewItemRow(e.RowHandle);
            if (isNewRow)
            {
                row.Status = ModifyMode.Insert;
                return;
            }

            if (row.Status == ModifyMode.Insert)
            {
                return;
            }

            row.Status = ModifyMode.Update;
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            this.Company_GridView.DeleteSelectedRows();
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            List<Company> saveData = this.CompanyData.Where(o => o.Status == ModifyMode.Insert || o.Status == ModifyMode.Update).ToList();

            if (this.CompanyDeleteData != null)
            {
                saveData?.AddRange(this.CompanyDeleteData);
            }

            if (saveData?.Count > 0)
            {
                //CompanyController controller = new CompanyController();
                //if (controller.SaveCompany(saveData))
                //{
                //    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                //    CompanyDeleteData = new List<Company>();
                //    this.LoadGridView();
                //}
                //else
                //{
                //    MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000002);
                //}
            }
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.LoadGridView();
        }

        private void Company_GridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            Company delete = e.Row.CastTo<Company>();
            if (delete.Status == ModifyMode.Insert)
            {
                return;
            }

            delete.Status = ModifyMode.Delete;
            CompanyDeleteData.Add(delete);
        }

        private void Company_GridView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void Company_GridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            Company_GridView.ClearColumnErrors();

            Company row = e.Row.CastTo<Company>();
            GridView view = sender as GridView;

            if (string.IsNullOrEmpty(row.CompanyName))
            {
                e.Valid = false;
                //Set errors with specific descriptions for the columns
                GridColumn column = view.Columns[nameof(row.CompanyName)];
                view.SetColumnError(column, BSMessage.BSM000015);
            }

            if (string.IsNullOrEmpty(row.CompanySName))
            {
                e.Valid = false;
                //Set errors with specific descriptions for the columns
                GridColumn column = view.Columns[nameof(row.CompanySName)];
                view.SetColumnError(column, BSMessage.BSM000012);
            }

            // Kiểm tra tồn tại trong grid
            if (CompanyData.ToList().Count(o => o.CompanySName == row.CompanySName) > 1)
            {
                e.Valid = false;
                //Set errors with specific descriptions for the columns
                GridColumn column = view.Columns[nameof(row.CompanySName)];
                view.SetColumnError(column, BSMessage.BSM000010);
            }
        }
    }
}

using BSClient.Constants;
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
using System.Text;

namespace BSClient.Views
{
    public partial class CustomerList : XtraUserControl
    {
        public BindingList<Customer> CustommersData { get; set; }

        public List<Customer> CustomersDeleteData { get; set; } = new List<Customer>();

        public CustomerList()
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
            Customer_GridView.Columns.Clear();
            this.Customer_GridView.AddColumn("CustomerID", "Mã Khách hàng", 100, false);
            this.Customer_GridView.AddColumn("CustomerName", "Tên Khách hàng", 300);
            this.Customer_GridView.AddColumn("CustomerSName", "Tên viết tắt", 120);
            this.Customer_GridView.AddColumn("CustomerTIN", "MST", 100);
            this.Customer_GridView.AddColumn("InvoiceFormNo", "Mã số", 100);
            this.Customer_GridView.AddColumn("FormNo", "Mẫu số", 100);
            this.Customer_GridView.AddColumn("SerialNo", "Ký hiệu", 100);
            this.Customer_GridView.AddColumn("CustomerPhone", "Điện thoại", 80);
            this.Customer_GridView.AddColumn("CustomerAddress", "Địa chỉ", 350);
        }

        private void SetupGridView()
        {
            this.Customer_GridView.SetupGridView();
        }

        private void LoadGridView()
        {
            using (CustomerController controller = new CustomerController())
            {
                try
                {
                    CustommersData = new BindingList<Customer>(controller.GetCustomers());
                    Customer_GridControl.DataSource = CustommersData;
                }
                catch (Exception ex)
                {
                    BSLog.Logger.Error(ex.Message);
                    MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000028, "<Danh Mục Khách Hàng>");
                }
            }
        }

        private void Customer_GridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            Customer row = e.Row.CastTo<Customer>();
            bool isNewRow = Customer_GridView.IsNewItemRow(e.RowHandle);
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
            this.Customer_GridView.DeleteSelectedRows();
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            List<Customer> saveData = this.CustommersData.Where(o => o.Status == ModifyMode.Insert || o.Status == ModifyMode.Update).ToList();

            if (this.CustomersDeleteData != null)
            {
                saveData?.AddRange(this.CustomersDeleteData);
            }

            if (saveData?.Count > 0)
            {
                CustomerController controller = new CustomerController();
                if (controller.SaveCustommers(saveData))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    CustomersDeleteData = new List<Customer>();
                    this.LoadGridView();
                }
                else
                {
                    MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000002);
                }
            }
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.LoadGridView();
        }

        private void Customer_GridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            Customer delete = e.Row.CastTo<Customer>();
            if (delete.Status == ModifyMode.Insert)
            {
                return;
            }

            delete.Status = ModifyMode.Delete;
            CustomersDeleteData.Add(delete);
        }

        private void Customer_GridView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void Customer_GridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            Customer_GridView.ClearColumnErrors();

            Customer row = e.Row.CastTo<Customer>();
            GridView view = sender as GridView;

            if (string.IsNullOrEmpty(row.CustomerName))
            {
                e.Valid = false;
                //Set errors with specific descriptions for the columns
                GridColumn column = view.Columns[nameof(row.CustomerName)];
                view.SetColumnError(column, BSMessage.BSM000015);
            }

            if (string.IsNullOrEmpty(row.CustomerSName))
            {
                e.Valid = false;
                //Set errors with specific descriptions for the columns
                GridColumn column = view.Columns[nameof(row.CustomerSName)];
                view.SetColumnError(column, BSMessage.BSM000012);
            }

            // Kiểm tra tồn tại trong grid
            if (CustommersData.ToList().Count(o => o.CustomerSName == row.CustomerSName) > 1)
            {
                e.Valid = false;
                //Set errors with specific descriptions for the columns
                GridColumn column = view.Columns[nameof(row.CustomerSName)];
                view.SetColumnError(column, BSMessage.BSM000010);
            }
        }

        private void Customer_GroupControl_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == ClientConst.ImportSymbol)
            {
                ImportData();
            }
            else if (e.Button.Properties.Caption == ClientConst.ExportSymbol)
            {
                ExportData();
            }
        }

        private void ImportData()
        {
            List<Customer> customers = ExcelHelper.LoadCustomer(out StringBuilder error);
            foreach (var item in customers)
            {
                item.Status = ModifyMode.Insert;
                CustommersData.Add(item);
            }

            if (error != null && error.Length > 0)
            {
                ClientCommon.ShowErrorBox(error.ToString());
            }
        }

        private void ExportData()
        {
            Customer_GridControl.ExportExcel(ExcelTemplate.EXL000001);
        }
    }
}

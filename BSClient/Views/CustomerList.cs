using BSClient.Base;
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
using System.Linq;

namespace BSClient.Views
{
    public partial class CustomerList : XtraUserControl
    {
        public BindingList<Customer> Custommers { get; set; }

        public List<Customer> CustomersDelete { get; set; } = new List<Customer>();

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
            this.Customer_GridView.AddColumn("CustomerName", "Tên Khách hàng", 250);
            this.Customer_GridView.AddColumn("CustomerSName", "Tên viết tắt", 100);
            this.Customer_GridView.AddColumn("Phone", "Điện thoại", 80);
            this.Customer_GridView.AddColumn("Address", "Địa chỉ", 350);
        }

        private void SetupGridView()
        {
            this.Customer_GridView.SetupGridView();
            this.Customer_GridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            this.Customer_GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
        }

        private void LoadGridView()
        {
            CustomerController controller = new CustomerController();
            Custommers = new BindingList<Customer>(controller.GetCustomers());
            Customer_GridControl.DataSource = Custommers;
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
            List<Customer> saveData = this.Custommers.Where(o => o.Status == ModifyMode.Insert || o.Status == ModifyMode.Update).ToList();

            if (this.CustomersDelete != null)
            {
                saveData?.AddRange(this.CustomersDelete);
            }

            if (saveData?.Count > 0)
            {
                CustomerController controller = new CustomerController();
                if (controller.SaveCustommers(saveData))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    CustomersDelete = new List<Customer>();
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
            CustomersDelete.Add(delete);
        }
    }
}

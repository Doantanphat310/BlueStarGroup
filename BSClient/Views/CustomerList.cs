using BSClient.Base;
using BSClient.Utility;
using BSCommon.Models;
using BSCommon.Utility;
using BSServer.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BSClient.Views
{
    public partial class CustomerList : BaseFormList
    {
        public BindingList<Customer> Custommers { get; set; }

        public List<Customer> CustomersDelete { get; set; } = new List<Customer>();

        public CustomerList()
        {
            InitializeComponent();

            LoadGrid();

            this.Save_Click += CustomerList_Save_Click;
            this.Delete_Click += CustomerList_Delete_Click;
            this.AddNew_Click += CustomerList_AddNew_Click;
        }

        private void LoadGrid()
        {
            InitGridView();

            SetupGridView();

            LoadGridView();
        }

        private void CustomerList_AddNew_Click(object sender, EventArgs e)
        {
            Customer_GridView.AddNewRow();
        }

        private void CustomerList_Delete_Click(object sender, EventArgs e)
        {
            int[] selectIndex = Customer_GridView.GetSelectedRows();

            foreach (int index in selectIndex)
            {
                Customer delete = Customer_GridView.GetRow(index) as Customer;
                if (string.IsNullOrWhiteSpace(delete.CustomerID))
                {
                    continue;
                }

                delete.Status = 3;
                CustomersDelete.Add(delete);
            }

            Customer_GridView.DeleteSelectedRows();
        }

        private void CustomerList_Save_Click(object sender, EventArgs e)
        {
            List<Customer> customersSave = new List<Customer>();

            foreach (var row in this.Custommers)
            {
                if (string.IsNullOrWhiteSpace(row.CustomerID) && !string.IsNullOrWhiteSpace(row.CustomerName))
                {
                    row.Status = 1;
                    customersSave.Add(row);
                    continue;
                }

                if (row.Status == 2 && !string.IsNullOrWhiteSpace(row.CustomerID))
                {
                    row.Status = 2;
                    customersSave.Add(row);
                    continue;
                }
            }

            if (CustomersDelete != null)
            {
                customersSave.AddRange(CustomersDelete);
            }

            if (customersSave.Count > 0)
            {
                CustomerController controller = new CustomerController();
                if (controller.SaveCustommers(customersSave))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    CustomersDelete = new List<Customer>();
                    this.LoadGridView();
                }
                else
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }
        }

        private void InitGridView()
        {
            Customer_GridView.Columns.Clear();

            ClientCommon.AddColumn(this.Customer_GridView, "CustomerID", "Mã Khách hàng", 100, false);
            ClientCommon.AddColumn(this.Customer_GridView, "CustomerName", "Tên Khách hàng", 250);
            ClientCommon.AddColumn(this.Customer_GridView, "CustomerSName", "Tên viết tắt", 100);
            ClientCommon.AddColumn(this.Customer_GridView, "Phone", "Điện thoại", 80);
            ClientCommon.AddColumn(this.Customer_GridView, "Address", "Địa chỉ", 350);
        }

        private void SetupGridView()
        {
            ClientCommon.SetupGridView(this.Customer_GridView);
            this.Customer_GridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.Customer_GridView.OptionsView.ShowAutoFilterRow = true;
            this.Customer_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            this.Customer_GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
        }

        private void LoadGridView()
        {
            CustomerController controller = new CustomerController();
            Custommers = new BindingList<Customer>(controller.GetCustomers());
            Customer_GridControl.DataSource = Custommers;
        }

        private void Customer_GridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (e.Row == null)
            {
                return;
            }

            Customer row = e.Row as Customer;
            if (!string.IsNullOrWhiteSpace(row.CustomerID))
            {
                row.Status = 2;
            }
        }
    }
}

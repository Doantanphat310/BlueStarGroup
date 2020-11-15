using BSClient.Base;
using BSClient.Utility;
using BSCommon.Models;
using BSCommon.Utility;
using BSServer.Controllers;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BSClient.Views
{
    public partial class UserList : XtraUserControl
    {
        public BindingList<UserInfo> MasterData { get; set; }

        public BindingList<UserRoleInfo> DetailData { get; set; }

        private int EntryMode = 0;

        public UserList()
        {
            InitializeComponent();

            InitComboBox();

            LoadGrid();
        }

        private void InitComboBox()
        {
            List<MasterInfo> userRoles = MasterInfoManager.GetUserRoles();
            UserRole_ComboBox.Properties.DataSource = userRoles;
            UserRole_ComboBox.Properties.ValueMember = "DetailCd";
            UserRole_ComboBox.Properties.DisplayMember = "Value";

            UserRole_ComboBox.Properties.Columns.Add(new LookUpColumnInfo("DetailCd", "Code", 50));
            UserRole_ComboBox.Properties.Columns.Add(new LookUpColumnInfo("Value", "Role", 100));

            List<Company> companys = GetCompanyList();
            CompanyID_ComboBox.Properties.DataSource = companys;
            CompanyID_ComboBox.Properties.ValueMember = "CompanyID";
            CompanyID_ComboBox.Properties.DisplayMember = "CompanyName";

            CompanyID_ComboBox.Properties.Columns.Add(new LookUpColumnInfo("CompanyID", 50));
            CompanyID_ComboBox.Properties.Columns.Add(new LookUpColumnInfo("CompanyName", 100));
        }

        private List<Company> GetCompanyList()
        {
            using (CompanyController controller = new CompanyController())
            {
                return controller.GetCompanys();
            }
        }

        private void LoadGrid()
        {
            InitGridView();

            SetupGridView();

            LoadGridView();
        }

        private void CustomerList_AddNew_Click(object sender, EventArgs e)
        {
            Users_GridView.AddNewRow();
        }

        private void CustomerList_Delete_Click(object sender, EventArgs e)
        {
            //int[] selectIndex = User_GridView.GetSelectedRows();

            //foreach (int index in selectIndex)
            //{
            //    Customer delete = User_GridView.GetRow(index) as Customer;
            //    if (string.IsNullOrWhiteSpace(delete.CustomerID))
            //    {
            //        continue;
            //    }

            //    delete.Status = 3;
            //    CustomersDelete.Add(delete);
            //}

            //User_GridView.DeleteSelectedRows();
        }

        private void CustomerList_Save_Click(object sender, EventArgs e)
        {
            //List<Customer> customersSave = new List<Customer>();

            //foreach (var row in this.Custommers)
            //{
            //    if (string.IsNullOrWhiteSpace(row.CustomerID) && !string.IsNullOrWhiteSpace(row.CustomerName))
            //    {
            //        row.Status = 1;
            //        customersSave.Add(row);
            //        continue;
            //    }

            //    if (row.Status == 2 && !string.IsNullOrWhiteSpace(row.CustomerID))
            //    {
            //        row.Status = 2;
            //        customersSave.Add(row);
            //        continue;
            //    }
            //}

            //if (CustomersDelete != null)
            //{
            //    customersSave.AddRange(CustomersDelete);
            //}

            //if (customersSave.Count > 0)
            //{
            //    CustomerController controller = new CustomerController();
            //    if (controller.SaveCustommers(customersSave))
            //    {
            //        MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
            //        CustomersDelete = new List<Customer>();
            //        this.LoadGridView();
            //    }
            //    else
            //    {
            //        MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
            //    }
            //}
        }

        private void InitGridView()
        {
            this.Users_GridView.Columns.Clear();

            this.Users_GridView.AddColumn("UserID", "Tên đăng nhập", 100, false);
            this.Users_GridView.AddColumn("UserName", "Tên người dùng", 250, false);
            this.Users_GridView.AddColumn("Phone", "Điện thoại", 80, false);
            this.Users_GridView.AddColumn("Address", "Địa chỉ", 350, false);

            InitDetailGridView();
        }

        private void InitDetailGridView()
        {
            this.UserRole_GridView.Columns.Clear();

            this.UserRole_GridView.AddColumn("CompanyID", "Mã Công ty", 100, false);
            this.UserRole_GridView.AddColumn("CompanyName", "Tên Công ty", 250, false);
            this.UserRole_GridView.AddColumn("UserRoleName", "Quyền", 100, false);
        }

        private void SetupGridView()
        {
            this.Users_GridView.SetupGridView(multiSelect: false);

            this.SetupDetailGridView();
        }

        private void SetupDetailGridView()
        {
            UserRole_GridView.SetupGridView();
        }

        private void LoadGridView()
        {
            UserController controller = new UserController();
            MasterData = new BindingList<UserInfo>(controller.GetUsers());
            Users_GridControl.DataSource = MasterData;

            this.LoadDetailGridView();
        }

        private void LoadDetailGridView()
        {
            UserController controller = new UserController();
            DetailData = new BindingList<UserRoleInfo>(controller.GetUserRoleCompany());
            UserRole_GridControl.DataSource = DetailData;
        }

        private void Customer_GridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            //if (e.Row == null)
            //{
            //    return;
            //}

            //Customer row = e.Row as Customer;
            //if (!string.IsNullOrWhiteSpace(row.CustomerID))
            //{
            //    row.Status = 2;
            //}
        }

        private void UserRole_GridView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {

        }

        private void UserAdd_Button_Click(object sender, EventArgs e)
        {
            EntryMode = 1;
            SetEnabelEdit();
        }

        private void UserDelete_Button_Click(object sender, EventArgs e)
        {
            if (Users_GridView.SelectedRowsCount <= 0)
            {
                return;
            }

            using (UserController controller = new UserController())
            {
                controller.DeleteUser(UserID_TextBox.Text);
            };

            Users_GridView.DeleteSelectedRows();
        }

        private void UserUpdate_Button_Click(object sender, EventArgs e)
        {
            if (EntryMode == 1)
            {
                this.InsertUser();
            }
            else if (EntryMode == 2)
            {
                this.UpdateUser();
            }

            EntryMode = 0;
            SetEnabelEdit();
        }

        private void Users_GridView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var selected = Users_GridView.GetSelectedRows();

            if (selected == null || selected.Length == 0)
            {
                return;
            }

            UserInfo selectedRow = Users_GridView.GetRow(selected[0]) as UserInfo;
            Role_UserName_TextBox.Text = selectedRow.UserID;
            UserName_TextBox.Text = selectedRow.UserName;
            UserID_TextBox.Text = selectedRow.UserID;
            Phone_TextBox.Text = selectedRow.Phone;
            Address_TextBox.Text = selectedRow.Address;
            Password_TextBox.Text = string.Empty;
        }

        private void New_Button_Click(object sender, EventArgs e)
        {

        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {

        }

        private void UserEdit_Button_Click(object sender, EventArgs e)
        {
            EntryMode = 2;
            SetEnabelEdit();
        }

        private void SetEnabelEdit()
        {
            UserAdd_Button.Enabled = false;
            UserEdit_Button.Enabled = false;
            User_LayoutGroup.Enabled = true;
            UserCancel_Button.Enabled = true;
            UserUpdate_Button.Enabled = true;
            UserDelete_Button.Enabled = false;

            if (EntryMode == 1)
            {
                UserID_TextBox.Enabled = true;
            }
            else if (EntryMode == 2)
            {
                UserID_TextBox.Enabled = false;
            }
            else if (EntryMode == 0)
            {
                User_LayoutGroup.Enabled = false;

                UserAdd_Button.Enabled = true;
                UserEdit_Button.Enabled = true;
                UserDelete_Button.Enabled = true;
                UserCancel_Button.Enabled = false;
                UserUpdate_Button.Enabled = false;
            }
        }

        private void UpdateUser()
        {
            var selected = Users_GridView.GetSelectedRows();
            if (selected == null || selected.Length == 0)
            {
                return;
            }

            var selectedRow = Users_GridView.GetRow(selected[0]) as UserInfo;
            UserInfo userInfo = new UserInfo
            {
                UserID = UserID_TextBox.Text,
                Password = ClientCommon.IsCheckPass(Password_TextBox.Text, selectedRow.Password) ? null : Password_TextBox.Text,
                UserName = UserName_TextBox.Text,
                Phone = Phone_TextBox.Text,
                Address = Address_TextBox.Text,
            };

            using (UserController controller = new UserController())
            {
                controller.UpdateUser(userInfo);
            };
        }

        private void InsertUser()
        {
            UserInfo userInfo = new UserInfo
            {
                UserID = UserID_TextBox.Text,
                Password = Password_TextBox.Text,
                UserName = UserName_TextBox.Text,
                Phone = Phone_TextBox.Text,
                Address = Address_TextBox.Text,
            };

            using (UserController controller = new UserController())
            {
                controller.InsertUser(userInfo);
            };
        }

        private void UserCancel_Button_Click(object sender, EventArgs e)
        {
            EntryMode = 0;
            SetEnabelEdit();
        }
    }
}

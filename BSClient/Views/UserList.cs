﻿using BSClient.Utility;
using BSCommon.Constant;
using BSCommon.Models;
using BSCommon.Utility;
using BSServer.Controllers;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BSClient.Views
{
    public partial class UserList : XtraUserControl
    {
        public BindingList<UserInfo> MasterData { get; set; }

        public BindingList<UserRoleCompany> DetailData { get; set; }

        public List<UserInfo> MasterDataDelete { get; set; } = new List<UserInfo>();

        public List<UserRoleCompany> DetailDataDelete { get; set; } = new List<UserRoleCompany>();

        public UserList()
        {
            InitializeComponent();

            InitComboBox();

            LoadGrid();
        }

        private void InitComboBox()
        {
            List<Company> companys = GetCompanyList();
            CompanyID_ComboBox.Properties.DataSource = companys;
            CompanyID_ComboBox.Properties.ValueMember = "CompanyID";
            CompanyID_ComboBox.Properties.DisplayMember = "CompanyName";
            CompanyID_ComboBox.Properties.ShowHeader = false;
            CompanyID_ComboBox.Properties.NullText = "Chọn Công ty";
            CompanyID_ComboBox.Properties.PopupFilterMode = PopupFilterMode.Contains;

            CompanyID_ComboBox.Properties.Columns.Add(new LookUpColumnInfo("CompanyID", 50));
            CompanyID_ComboBox.Properties.Columns.Add(new LookUpColumnInfo("CompanyName", 100));

            List<MasterInfo> userRoles = MasterInfoManager.GetUserRoles();
            UserRole_ComboBox.Properties.DataSource = userRoles;
            UserRole_ComboBox.Properties.ValueMember = "Id";
            UserRole_ComboBox.Properties.DisplayMember = "Value";
            UserRole_ComboBox.Properties.ShowHeader = false;
            UserRole_ComboBox.Properties.NullText = "Chọn quyền";

            UserRole_ComboBox.Properties.Columns.Add(new LookUpColumnInfo("Id", 50));
            UserRole_ComboBox.Properties.Columns.Add(new LookUpColumnInfo("Value", 100));
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
            LoadMasterGrid();

            LoadDetailGrid();
        }

        private void LoadMasterGrid()
        {
            InitGridView();

            SetupGridView();

            LoadGridView();
        }

        private void LoadDetailGrid()
        {
            InitDetailGridView();

            SetupDetailGridView();

            LoadDetailGridView();
        }

        private void InitGridView()
        {
            this.Users_GridView.Columns.Clear();

            this.Users_GridView.AddColumn("UserID", "Tên đăng nhập", 100, true);
            this.Users_GridView.AddColumn("PasswordDisplay", "Mật khẩu", 100, true);
            this.Users_GridView.AddColumn("UserName", "Tên người dùng", 250, true);
            this.Users_GridView.AddColumn("Phone", "Điện thoại", 80, true);
            this.Users_GridView.AddColumn("Address", "Địa chỉ", 350, true);
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
            this.Users_GridView.SetupGridView(multiSelect: true, checkBoxSelectorColumnWidth: 30);

            this.Users_GridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            this.Users_GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
        }

        private void SetupDetailGridView()
        {
            UserRole_GridView.SetupGridView();

            UserRole_GridView.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
        }

        private void LoadGridView()
        {
            UserController controller = new UserController();
            MasterData = new BindingList<UserInfo>(controller.GetUsers());
            Users_GridControl.DataSource = MasterData;
        }

        private void LoadDetailGridView()
        {
            UserController controller = new UserController();
            DetailData = new BindingList<UserRoleCompany>(controller.GetUserRoleCompany());
            UserRole_GridControl.DataSource = DetailData;
        }

        private void UserDelete_Button_Click(object sender, EventArgs e)
        {
            Users_GridView.DeleteSelectedRows();
        }

        private void UserSave_Button_Click(object sender, EventArgs e)
        {
            List<UserInfo> saveData = this.MasterData.Where(o => o.Status == ModifyMode.Insert || o.Status == ModifyMode.Update).ToList();

            if (MasterDataDelete != null && MasterDataDelete.Count > 0)
            {
                saveData?.AddRange(MasterDataDelete);
            }

            if (saveData?.Count > 0)
            {
                UserController controller = new UserController();
                if (controller.SaveUser(saveData))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    MasterDataDelete = new List<UserInfo>();
                    this.LoadGridView();
                }
                else
                {
                    MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000002);
                }
            }
        }

        private void UserRoleAddNew_Button_Click(object sender, EventArgs e)
        {
            string userID = Role_UserName_TextBox.Text;
            string companyID = CompanyID_ComboBox.GetSelectedDataRow().CastTo<Company>().CompanyID;
            string userRoleID = UserRole_ComboBox.GetSelectedDataRow().CastTo<MasterInfo>().Id;

            if (string.IsNullOrEmpty(userID))
            {
                MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000003);
                return;
            }

            if (string.IsNullOrEmpty(companyID))
            {
                MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000003);
                return;
            }

            if (string.IsNullOrEmpty(userRoleID))
            {
                MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000003);
                return;
            }

            if (DetailData.ToList().Find(o => o.UserID == userID && o.CompanyID == companyID && o.UserRoleID == userRoleID) != null)
            {
                MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000004);
                return;
            }

            DetailData.Add(new UserRoleCompany
            {
                UserID = Role_UserName_TextBox.Text,
                CompanyID = CompanyID_ComboBox.GetSelectedDataRow().CastTo<Company>().CompanyID,
                CompanyName = CompanyID_ComboBox.GetSelectedDataRow().CastTo<Company>().CompanyName,
                UserRoleID = UserRole_ComboBox.GetSelectedDataRow().CastTo<MasterInfo>().Id,
                UserRoleName = UserRole_ComboBox.GetSelectedDataRow().CastTo<MasterInfo>().Value,
                Status = ModifyMode.Insert
            });
        }

        private void UserRoleDelete_Button_Click(object sender, EventArgs e)
        {
            UserRole_GridView.DeleteSelectedRows();
        }

        private void UserCancel_Button_Click(object sender, EventArgs e)
        {
            LoadGridView();
        }

        private void Users_GridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int index = e.FocusedRowHandle;

            if (Users_GridView.IsNewItemRow(index))
            {
                return;
            }

            UserInfo selectedRow = Users_GridView.GetRow(index).CastTo<UserInfo>();
            if (selectedRow == null)
            {
                return;
            }

            Role_UserName_TextBox.Text = selectedRow.UserID;

            // filter grid
            UserRole_GridView.ActiveFilterString = $"[UserID] = '{selectedRow.UserID}'";
        }

        private void Users_GridView_ShowingEditor(object sender, CancelEventArgs e)
        {
            string col = Users_GridView.FocusedColumn.FieldName;
            int rowIndex = Users_GridView.FocusedRowHandle;
            bool isNewRow = Users_GridView.IsNewItemRow(rowIndex);
            if (col == "UserID" && !isNewRow)
            {
                e.Cancel = true;
            }
        }

        private void Users_GridView_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            Users_GridView.ClearColumnErrors();
            int rowIndex = Users_GridView.FocusedRowHandle;
            bool isNewRow = Users_GridView.IsNewItemRow(rowIndex);
            if (isNewRow)
            {
                GridView view = sender as GridView;
                GridColumn column;
                UserInfo row = e.Row.CastTo<UserInfo>();
                string userID = row.UserID;

                // Kiểm tra user empty
                if (string.IsNullOrEmpty(userID))
                {
                    e.Valid = false;
                    //Set errors with specific descriptions for the columns
                    column = view.Columns[nameof(row.UserID)];
                    view.SetColumnError(column, "Tên đăng nhập không được trống.");
                }

                // Kiểm tra tồn tại trong grid
                if (MasterData.ToList().Count(o => o.UserID == userID) > 1)
                {
                    e.Valid = false;
                    //Set errors with specific descriptions for the columns
                    column = view.Columns[nameof(row.UserID)];
                    view.SetColumnError(column, "Tên đăng nhập đã tồn tại!");
                }

                // Kiểm tra mật khẩu empty
                if (string.IsNullOrEmpty(row.PasswordDisplay))
                {
                    e.Valid = false;
                    //Set errors with specific descriptions for the columns
                    column = view.Columns[nameof(row.PasswordDisplay)];
                    view.SetColumnError(column, "Mật khẩu không được trống.");
                }
            }
        }

        private void Users_GridView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            // Suppress displaying the error message box
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void Users_GridView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            UserInfo row = e.Row.CastTo<UserInfo>();
            if (!string.IsNullOrEmpty(row.PasswordDisplay))
            {
                row.Password = SHA1Helper.GetHash(row.PasswordDisplay);
            }

            bool isNewRow = Users_GridView.IsNewItemRow(e.RowHandle);
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

        private void Users_GridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            var delete = e.Row.CastTo<UserInfo>();
            Console.WriteLine(delete.UserID);

            if (delete.Status == ModifyMode.Insert)
            {
                return;
            }

            delete.Status = ModifyMode.Delete;
            MasterDataDelete.Add(delete);
        }

        private void UserRoleCancel_Button_Click(object sender, EventArgs e)
        {
            LoadDetailGridView();
        }

        private void UserRoleSave_Button_Click(object sender, EventArgs e)
        {
            List<UserRoleCompany> saveData = this.DetailData.Where(o => o.Status == ModifyMode.Insert || o.Status == ModifyMode.Update).ToList();

            if (DetailDataDelete != null && DetailDataDelete.Count > 0)
            {
                saveData?.AddRange(DetailDataDelete);
            }

            if (saveData?.Count > 0)
            {
                UserController controller = new UserController();
                if (controller.SaveUserRoleCompany(saveData))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    DetailDataDelete = new List<UserRoleCompany>();
                    this.LoadDetailGridView();
                }
                else
                {
                    MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000002);
                }
            }
        }

        private void UserRole_GridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            UserRoleCompany delete = e.Row.CastTo<UserRoleCompany>();
            if (delete.Status == ModifyMode.Insert)
            {
                return;
            }

            delete.Status = ModifyMode.Delete;
            DetailDataDelete.Add(delete);
        }
    }
}

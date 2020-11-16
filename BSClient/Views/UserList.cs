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

        public BindingList<UserRoleInfo> DetailData { get; set; }

        public List<UserInfo> MasterDelete { get; set; }

        public List<UserRoleInfo> DetailDelete { get; set; }

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
            UserRole_ComboBox.Properties.ValueMember = "DetailCd";
            UserRole_ComboBox.Properties.DisplayMember = "Value";
            UserRole_ComboBox.Properties.ShowHeader = false;
            UserRole_ComboBox.Properties.NullText = "Chọn quyền";

            UserRole_ComboBox.Properties.Columns.Add(new LookUpColumnInfo("DetailCd", 50));
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
            DetailData = new BindingList<UserRoleInfo>(controller.GetUserRoleCompany());
            UserRole_GridControl.DataSource = DetailData;
        }

        private void UserDelete_Button_Click(object sender, EventArgs e)
        {
            int[] selectIndex = Users_GridView.GetSelectedRows();

            foreach (int index in selectIndex)
            {
                UserInfo delete = Users_GridView.GetRow(index) as UserInfo;
                if (delete.Status == ModifyMode.Insert)
                {
                    continue;
                }

                delete.Status = ModifyMode.Delete;
                MasterDelete.Add(delete);
            }

            Users_GridView.DeleteSelectedRows();
        }

        private void UserSave_Button_Click(object sender, EventArgs e)
        {
            List<UserInfo> saveData = this.MasterData.Where(o => o.Status == ModifyMode.Insert || o.Status == ModifyMode.Update).ToList();

            if (MasterDelete != null)
            {
                saveData?.AddRange(MasterDelete);
            }

            if (saveData?.Count > 0)
            {
                UserController controller = new UserController();
                if (controller.SaveUser(saveData))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    MasterDelete = new List<UserInfo>();
                    this.LoadGridView();
                }
                else
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }
        }

        private void UserRoleAddNew_Button_Click(object sender, EventArgs e)
        {
            string userID = Role_UserName_TextBox.Text;
            string companyID = CompanyID_ComboBox.GetSelectedDataRow().CastTo<Company>().CompanyID;
            string userRoleID = UserRole_ComboBox.GetSelectedDataRow().CastTo<MasterInfo>().DetailCd;

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

            DetailData.Add(new UserRoleInfo
            {
                UserID = Role_UserName_TextBox.Text,
                CompanyID = CompanyID_ComboBox.GetSelectedDataRow().CastTo<Company>().CompanyID,
                CompanyName = CompanyID_ComboBox.GetSelectedDataRow().CastTo<Company>().CompanyName,
                UserRoleID = UserRole_ComboBox.GetSelectedDataRow().CastTo<MasterInfo>().DetailCd,
                UserRoleName = UserRole_ComboBox.GetSelectedDataRow().CastTo<MasterInfo>().Value,
                Status = ModifyMode.Insert
            });
        }

        private void UserRoleDelete_Button_Click(object sender, EventArgs e)
        {
            int[] selectIndex = UserRole_GridView.GetSelectedRows();

            foreach (int index in selectIndex)
            {
                UserRoleInfo delete = UserRole_GridView.GetRow(index).CastTo<UserRoleInfo>();
                if (delete.Status == ModifyMode.Insert)
                {
                    continue;
                }

                delete.Status = ModifyMode.Delete;
                DetailDelete.Add(delete);
            }

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
            Console.WriteLine("edit");
            string col = Users_GridView.FocusedColumn.FieldName;
            int rowIndex = Users_GridView.FocusedRowHandle;
            bool isNewRow = Users_GridView.IsNewItemRow(rowIndex);
            if (col == "UserID" && !isNewRow)
            {
                e.Cancel = true;
            }
        }

        private void Users_GridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            int rowIndex = Users_GridView.FocusedRowHandle;
            bool isNewRow = Users_GridView.IsNewItemRow(rowIndex);
            GridView view = sender as GridView;
            GridColumn column = view.Columns["UserID"];
            UserInfo row = (e.Row as UserInfo);
            if (isNewRow)
            {
                string userID = row.UserID;
                // Kiểm tra tồn tại trong grid
                if (MasterData.ToList().Count(o => o.UserID == userID) > 1)
                {
                    e.Valid = false;
                    //Set errors with specific descriptions for the columns
                    view.SetColumnError(column, "Tên đăng nhập đã tồn tại!");
                }
            }

            if (string.IsNullOrEmpty(row.Password))
            {
                string userID = row.UserID;
                // Kiểm tra tồn tại trong grid
                if (MasterData.ToList().Count(o => o.UserID == userID) > 1)
                {
                    e.Valid = false;
                    //Set errors with specific descriptions for the columns
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
            bool isNewRow = Users_GridView.IsNewItemRow(e.RowHandle);
            if (isNewRow)
            {
                return;
            }

            UserInfo row = e.Row as UserInfo;
            if (row.Status == ModifyMode.Insert)
            {
                return;
            }

            if (!string.IsNullOrEmpty(row.PasswordDisplay))
            {
                row.Password = SHA1Helper.GetHash(row.PasswordDisplay);
            }

            row.Status = ModifyMode.Update;
        }

        private void Users_GridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            var item = e.CastTo<UserInfo>();
            Console.WriteLine(item.UserID);
        }

        private void UserRoleCancel_Button_Click(object sender, EventArgs e)
        {
            LoadDetailGridView();
        }

        private void UserRoleSave_Button_Click(object sender, EventArgs e)
        {
            List<UserRoleInfo> saveData = this.DetailData.Where(o => o.Status == ModifyMode.Insert || o.Status == ModifyMode.Update).ToList();

            if (DetailDelete != null)
            {
                saveData?.AddRange(DetailDelete);
            }

            if (saveData?.Count > 0)
            {
                UserController controller = new UserController();
                if (controller.SaveUserRoleCompany(saveData))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    DetailDelete = new List<UserRoleInfo>();
                    this.LoadDetailGridView();
                }
                else
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }
        }
    }
}

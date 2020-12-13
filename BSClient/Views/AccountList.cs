using BSClient.Utility;
using BSCommon.Constant;
using BSCommon.Models;
using BSCommon.Utility;
using BSServer.Controllers;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BSClient.Views
{
    public partial class AccountList : UserControl
    {
        public BindingList<AccountGroup> AccountGroupData { get; set; }

        public BindingList<Accounts> AccountsData { get; set; }

        public BindingList<AccountDetail> AccountDetailData { get; set; }

        public List<AccountGroup> AccountGroupDeleteData { get; set; } = new List<AccountGroup>();

        public List<Accounts> AccountsDeleteData { get; set; } = new List<Accounts>();

        public List<AccountDetail> AccountDetailDeleteData { get; set; } = new List<AccountDetail>();

        private BindingSource AccountBinSource { get; set; } = new BindingSource();

        public AccountList()
        {
            InitializeComponent();

            LoadGrid();

            InitComboBox();

            SetBindingData();

            CompanyID_SearchLookUpEdit.EditValue = CommonInfo.CompanyInfo.CompanyID;
            if (CommonInfo.UserInfo.UserRole != "Full")
            {
                CompanyID_SearchLookUpEdit.ReadOnly = true;
            }
        }

        private void SetBindingData()
        {
            DataBindingHelper.BindingCheckEdit(this.HachToan_CheckEdit, AccountBinSource);
            DataBindingHelper.BindingCheckEdit(this.DuNo_CheckEdit, AccountBinSource);
            DataBindingHelper.BindingCheckEdit(this.DuCo_CheckEdit, AccountBinSource);
            DataBindingHelper.BindingCheckEdit(this.ThongKe_CheckEdit, AccountBinSource);
            DataBindingHelper.BindingCheckEdit(this.NgoaiTe_CheckEdit, AccountBinSource);
            DataBindingHelper.BindingCheckEdit(this.TK152_156_CheckEdit, AccountBinSource);
            DataBindingHelper.BindingCheckEdit(this.VatTu_CheckEdit, AccountBinSource);
            DataBindingHelper.BindingCheckEdit(this.ThueVAT_CheckEdit, AccountBinSource);
            DataBindingHelper.BindingCheckEdit(this.HopDong_CheckEdit, AccountBinSource);
            DataBindingHelper.BindingCheckEdit(this.CongNo_CheckEdit, AccountBinSource);
        }

        private void InitComboBox()
        {
            List<Company> companys = GetCompanyList();
            List<ColumnInfo> columns = new List<ColumnInfo>
            {
                new ColumnInfo ("CompanyID", "Mã Công ty", 100),
                new ColumnInfo ("CompanyName", "Tên Công ty", 250)
            };

            this.CompanyID_SearchLookUpEdit.SetupLookUpEdit("CompanyID", "CompanyName", companys, columns);

            columns = new List<ColumnInfo>
            {
                new ColumnInfo ("AccountID", "Mã TK", 90),
                new ColumnInfo ("AccountName", "Tên TK", 250)
            };

            this.AccountID_SearchLookUpEdit.SetupLookUpEdit("AccountID", "AccountName", AccountsData, columns);
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
            LoadAccountGroupGrid();

            LoadAccountsGrid();

            LoadAccountDetailGrid();
        }

        private void LoadAccountsGrid()
        {
            InitAccountsGridView();
            SetupAccountsGridView();
            LoadAccountsGridView();
        }

        private void LoadAccountDetailGrid()
        {
            InitAccountDetailGridView();

            SetupAccountDetailGridView();

            LoadAccountDetailGridView();
        }

        private void LoadAccountGroupGrid()
        {
            InitAccountGroupGridView();

            SetupAccountGroupGridView();

            LoadAccountGroupGridView();
        }

        private void InitAccountGroupGridView()
        {
            this.AccountGroup_GridView.Columns.Clear();

            this.AccountGroup_GridView.AddColumn("AccountGroupID", "Mã Loại TK", 70, false);
            this.AccountGroup_GridView.AddColumn("AccountGroupName", "Tên Loại TK", 150, true, fixedWidth: false);
        }

        private void InitAccountsGridView()
        {
            this.Account_TreeList.Columns.Clear();
            Account_TreeList.KeyFieldName = "AccountID";
            Account_TreeList.ParentFieldName = "ParentID";
            this.Account_TreeList.AddColumn("AccountID", "Mã TK", 100, true);
            this.Account_TreeList.AddColumn("ThongKeID", "Thống kê", 80, true);
            this.Account_TreeList.AddColumn("AccountName", "Tên TK", 250, true, fixedWidth: false);
            this.Account_TreeList.AddLookupEditColumn("AccountGroupID", "Loại TK", 120,
                AccountGroupData, "AccountGroupID", "AccountGroupName");
        }

        private void InitAccountDetailGridView()
        {
            this.AccountDetail_GridView.Columns.Clear();

            this.AccountDetail_GridView.AddColumn("CompanyID", "Công ty", 100, false);
            this.AccountDetail_GridView.AddColumn("AccountID", "Tài khoản", 100, false);
            this.AccountDetail_GridView.AddColumn("AccountDetailID", "Thống kê", 80, false);
            this.AccountDetail_GridView.AddColumn("AccountDetailName", "Mô tả", 250, true, fixedWidth: false);
        }

        private void SetupAccountGroupGridView()
        {
            this.AccountGroup_GridView.SetupGridView(columnAutoWidth: true);
        }

        private void SetupAccountsGridView()
        {
            Account_TreeList.SetupTreeList();
        }

        private void SetupAccountDetailGridView()
        {
            AccountDetail_GridView.SetupGridView(newItemRow: NewItemRowPosition.None, columnAutoWidth: true);
        }

        private void LoadAccountGroupGridView()
        {
            AccountsController controller = new AccountsController();
            AccountGroupData = new BindingList<AccountGroup>(controller.GetAccountGroup());
            AccountGroup_GridControl.DataSource = AccountGroupData;

            if (this.Account_TreeList.Columns["AccountGroupID"] != null)
            {
                var column = this.Account_TreeList.Columns["AccountGroupID"].ColumnEdit.CastTo<RepositoryItemLookUpEdit>();
                column.DataSource = AccountGroupData;
            }
        }

        private void LoadAccountsGridView()
        {
            AccountsController controller = new AccountsController();
            AccountsData = new BindingList<Accounts>(controller.GetAccounts());
            AccountBinSource.DataSource = AccountsData;
            Account_TreeList.DataSource = AccountBinSource;
            Account_TreeList.ExpandAll();

            if (AccountID_SearchLookUpEdit != null)
            {
                AccountID_SearchLookUpEdit.Properties.DataSource = AccountsData;
            }
        }

        private void LoadAccountDetailGridView()
        {
            AccountsController controller = new AccountsController();
            AccountDetailData = new BindingList<AccountDetail>(controller.GetAccountDetail());
            AccountDetail_GridControl.DataSource = AccountDetailData;
        }

        private void AccountGroup_Delete_Button_Click(object sender, EventArgs e)
        {
            AccountGroup_GridView.DeleteSelectedRows();
        }

        private void AccountGroup_Save_Button_Click(object sender, EventArgs e)
        {
            List<AccountGroup> saveData = this.AccountGroupData.Where(o => o.Status == ModifyMode.Insert || o.Status == ModifyMode.Update).ToList();

            if (AccountGroupDeleteData != null && AccountGroupDeleteData.Count > 0)
            {
                saveData?.AddRange(AccountGroupDeleteData);
            }

            if (saveData?.Count > 0)
            {
                AccountsController controller = new AccountsController();
                if (controller.SaveAccountGroup(saveData))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    AccountGroupDeleteData = new List<AccountGroup>();
                    this.LoadAccountGroupGridView();
                }
                else
                {
                    MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000002);
                }
            }
        }

        private void AccountGroup_Cancel_Button_Click(object sender, EventArgs e)
        {
            LoadAccountGroupGridView();
        }

        private void Accounts_Delete_Button_Click(object sender, EventArgs e)
        {
            Account_TreeList.DeleteSelectedNodes();
        }

        private void Accounts_Save_Button_Click(object sender, EventArgs e)
        {
            List<Accounts> saveData = this.AccountsData.Where(o => o.Status == ModifyMode.Insert || o.Status == ModifyMode.Update).ToList();

            if (AccountsDeleteData != null && AccountsDeleteData.Count > 0)
            {
                saveData?.AddRange(AccountsDeleteData);
            }

            if (saveData?.Count > 0)
            {
                AccountsController controller = new AccountsController();
                if (controller.SaveAccounts(saveData))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    AccountsDeleteData = new List<Accounts>();
                    this.LoadAccountsGridView();
                }
                else
                {
                    MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000002);
                }
            }
        }

        private void Accounts_Cancel_Button_Click(object sender, EventArgs e)
        {
            LoadAccountsGridView();
        }

        private void AccountDetail_AddNew_Button_Click(object sender, EventArgs e)
        {
            Accounts account = AccountID_SearchLookUpEdit.GetSelectedDataRow().CastTo<Accounts>();
            Company company = CompanyID_SearchLookUpEdit.GetSelectedDataRow().CastTo<Company>();

            if (string.IsNullOrEmpty(company.CompanyID))
            {
                MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000005);
                return;
            }

            if (string.IsNullOrEmpty(account.AccountID))
            {
                MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000023);
                return;
            }

            string accountDetailID = AccountDetailID_TextEdit.Text;
            if (string.IsNullOrWhiteSpace(accountDetailID))
            {
                MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000029);
                return;
            }

            if (AccountDetailData.ToList().Find(o => o.CompanyID == company.CompanyID && o.AccountID == account.AccountID && o.AccountDetailID == accountDetailID) != null)
            {
                MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000030);
                return;
            }

            string accountDetailName = AccountDetailName_TextEdit.Text;
            if (string.IsNullOrWhiteSpace(accountDetailName))
            {
                MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000025);
                return;
            }

            //if (AccountDetailData.ToList().Find(o => o.AccountDetailName == accountDetailName) != null)
            //{
            //    MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000024);
            //    return;
            //}

            AccountDetailData.Add(new AccountDetail
            {
                CompanyID = company.CompanyID,
                AccountID = account.AccountID,
                AccountDetailID = accountDetailID,
                AccountDetailName = accountDetailName,
                Status = ModifyMode.Insert
            });
        }

        private void AccountDetail_Delete_Button_Click(object sender, EventArgs e)
        {
            AccountDetail_GridView.DeleteSelectedRows();
        }

        private void AccountDetail_Save_Button_Click(object sender, EventArgs e)
        {
            List<AccountDetail> saveData = this.AccountDetailData.Where(o => o.Status == ModifyMode.Insert || o.Status == ModifyMode.Update).ToList();

            if (AccountDetailDeleteData != null && AccountDetailDeleteData.Count > 0)
            {
                saveData?.AddRange(AccountDetailDeleteData);
            }

            if (saveData?.Count > 0)
            {
                AccountsController controller = new AccountsController();
                if (controller.SaveAccountDetail(saveData))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    AccountDetailDeleteData = new List<AccountDetail>();
                    this.LoadAccountDetailGridView();
                }
                else
                {
                    MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000002);
                }
            }
        }

        private void AccountDetail_Cancel_Button_Click(object sender, EventArgs e)
        {
            LoadAccountDetailGridView();
        }

        private void AccountGroup_GridView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            AccountGroup row = e.Row.CastTo<AccountGroup>();
            bool isNewRow = AccountGroup_GridView.IsNewItemRow(e.RowHandle);
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

        private void AccountGroup_GridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            AccountGroup delete = e.Row.CastTo<AccountGroup>();
            if (delete.Status == ModifyMode.Insert)
            {
                return;
            }

            delete.Status = ModifyMode.Delete;
            AccountGroupDeleteData.Add(delete);
        }

        private void Accounts_GridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            Accounts delete = e.Row.CastTo<Accounts>();
            if (delete.Status == ModifyMode.Insert)
            {
                return;
            }

            delete.Status = ModifyMode.Delete;
            AccountsDeleteData.Add(delete);
        }

        private void AccountDetail_GridView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            AccountDetail row = e.Row.CastTo<AccountDetail>();
            if (row.Status == ModifyMode.Insert)
            {
                return;
            }

            row.Status = ModifyMode.Update;
        }

        private void AccountDetail_GridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            AccountDetail delete = e.Row.CastTo<AccountDetail>();
            if (delete.Status == ModifyMode.Insert)
            {
                return;
            }

            delete.Status = ModifyMode.Delete;
            AccountDetailDeleteData.Add(delete);
        }

        private void AccountGroup_GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            AccountGroup selectedRow = AccountGroup_GridView.GetFocusedRow().CastTo<AccountGroup>();
            if (selectedRow == null)
            {
                return;
            }

            // filter grid
            this.Account_TreeList.ClearColumnsFilter();
            Account_TreeList.ActiveFilterString = $"[AccountGroupID] = '{selectedRow.AccountGroupID}'";
        }

        private void AccountGroup_GridView_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            AccountGroup_GridView.ClearColumnErrors();

            AccountGroup row = e.Row.CastTo<AccountGroup>();
            GridView view = sender as GridView;
            GridColumn column;

            if (AccountGroup_GridView.IsNewItemRow(e.RowHandle))
            {
                string accountGroupID = row.AccountGroupID;

                // Kiểm tra tồn tại trong grid
                if (AccountGroupData.ToList().Count(o => o.AccountGroupID == accountGroupID) > 1)
                {
                    e.Valid = false;
                    column = view.Columns[nameof(row.AccountGroupID)];
                    view.SetColumnError(column, BSMessage.BSM000018);
                }
            }

            if (string.IsNullOrEmpty(row.AccountGroupName))
            {
                e.Valid = false;
                column = view.Columns[nameof(row.AccountGroupName)];
                view.SetColumnError(column, BSMessage.BSM000017);
            }
        }

        private void AccountGroup_GridView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void Accounts_Add_Button_Click(object sender, EventArgs e)
        {
            string AccountGroupID = AccountGroup_GridView.GetFocusedRow().CastTo<AccountGroup>().AccountGroupID;
            if (string.IsNullOrEmpty(AccountGroupID))
            {
                MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000009);
                return;
            }

            AccountsData.Add(new Accounts
            {
                AccountGroupID = AccountGroupID,
                Status = ModifyMode.Insert
            });
        }

        private void AddAccount(bool isSameLevel = true)
        {
            string accountGroupID = AccountGroup_GridView.GetFocusedRow().CastTo<AccountGroup>().AccountGroupID;
            if (string.IsNullOrEmpty(accountGroupID))
            {
                MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000022);
                return;
            }

            Accounts selected = Account_TreeList.GetFocusedRow().CastTo<Accounts>();
            string parentID;
            byte level;
            if (selected == null)
            {
                if (!isSameLevel)
                {
                    MessageBoxHelper.ShowErrorMessage("Chưa chọn TK cha.");
                    return;
                }
                else
                {
                    parentID = string.Empty;
                    level = 1;
                }
            }
            else
            {
                if (isSameLevel)
                {
                    parentID = selected.ParentID;
                    level = selected.AccountLevel;
                    if (string.IsNullOrEmpty(selected.ParentID))
                    {
                        // nothing
                    }
                    else
                    {
                        accountGroupID = selected.AccountGroupID;
                    }
                }
                else
                {
                    parentID = selected.AccountID;
                    level = (byte)(selected.AccountLevel + 1);
                    accountGroupID = selected.AccountGroupID;
                }
            }

            AccountsData.Add(new Accounts
            {
                AccountGroupID = accountGroupID,
                ParentID = parentID,
                AccountLevel = level,
                Status = ModifyMode.Insert
            });
        }

        private void CompanyID_SearchLookUpEdit_Popup(object sender, EventArgs e)
        {
            SearchLookUpEdit edit = sender.CastTo<SearchLookUpEdit>();
            var popupForm = edit.GetPopupEditForm();
            popupForm.KeyPreview = true;
            popupForm.KeyPress += PopupForm_KeyPress;
        }

        private void PopupForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PopupSearchLookUpEditForm popupForm = sender as PopupSearchLookUpEditForm;
                var view = popupForm.OwnerEdit.Properties.View;
                view.FocusedRowHandle = 0;
                popupForm.OwnerEdit.ClosePopup();
            }
        }

        private void AccountGroup_GridView_ShowingEditor(object sender, CancelEventArgs e)
        {
            string colName = AccountGroup_GridView.FocusedColumn.FieldName;
            int rowIndex = AccountGroup_GridView.FocusedRowHandle;
            bool isNewRow = AccountGroup_GridView.IsNewItemRow(rowIndex);
            if (colName == "AccountGroupID" && !isNewRow)
            {
                e.Cancel = true;
            }
        }

        private void Account_TreeList_ShowingEditor(object sender, CancelEventArgs e)
        {
            string colName = Account_TreeList.FocusedColumn.FieldName;
            var row = Account_TreeList.GetFocusedRow().CastTo<Accounts>();
            if (colName == "AccountID" && !(string.IsNullOrEmpty(row.AccountID) || row.Status == ModifyMode.Insert))
            {
                e.Cancel = true;
            }
        }

        private void AddAccount_Item_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddAccount();
        }

        private void Add_ChildAccount_Item_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddAccount(false);
        }

        private void Account_TreeList_ValidateNode(object sender, ValidateNodeEventArgs e)
        {
            Account_TreeList.ClearColumnErrors();

            Accounts selected = Account_TreeList.GetFocusedRow().CastTo<Accounts>();
            TreeList view = sender as TreeList;
            TreeListColumn column;

            if (selected == null) return;

            string accountID = selected.AccountID;

            if (string.IsNullOrWhiteSpace(accountID))
            {
                e.Valid = false;
                //Set errors with specific descriptions for the columns
                column = view.Columns[nameof(selected.AccountID)];
                view.SetColumnError(column, BSMessage.BSM000019);
            }

            // Kiểm tra tồn tại trong grid
            if (AccountsData.ToList().Count(o => o.AccountID == accountID) > 1)
            {
                e.Valid = false;
                column = view.Columns[nameof(selected.AccountID)];
                view.SetColumnError(column, BSMessage.BSM000021);
            }

            if (string.IsNullOrEmpty(selected.AccountName))
            {
                e.Valid = false;
                column = view.Columns[nameof(selected.AccountName)];
                view.SetColumnError(column, BSMessage.BSM000020);
            }

            if (string.IsNullOrEmpty(selected.AccountGroupID))
            {
                e.Valid = false;
                column = view.Columns[nameof(selected.AccountGroupID)];
                view.SetColumnError(column, BSMessage.BSM000016);
            }

            if (selected.Status != ModifyMode.Insert)
            {
                selected.Status = ModifyMode.Update;
            }
        }

        private void Account_TreeList_InvalidNodeException(object sender, DevExpress.XtraTreeList.InvalidNodeExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void CompanyID_SearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            // filter grid            
            FilterAccountDetail();
        }

        private void AccountDetail_GridView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void AccountDetail_GridView_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            //this.AccountDetail_GridView.ClearColumnErrors();
            //var row = e.Row.CastTo<AccountDetail>();
            //if (this.AccountDetailData.Count(o => o.AccountDetailName == row.AccountDetailName) > 1)
            //{
            //    e.Valid = false;
            //    //Set errors with specific descriptions for the columns
            //    GridView view = sender as GridView;
            //    GridColumn column = view.Columns["AccountDetailName"];
            //    view.SetColumnError(column, BSMessage.BSM000024);
            //}
        }

        private void AccountID_SearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            // filter grid            
            FilterAccountDetail();
        }

        /// <summary>
        /// Thực hiện lọc tài khoản chi tiết
        /// </summary>
        private void FilterAccountDetail()
        {
            this.AccountDetail_GridView.ClearColumnsFilter();
            string filter = string.Empty;

            string companyID = CompanyID_SearchLookUpEdit.EditValue.ToString();
            if (!string.IsNullOrEmpty(companyID))
            {
                filter = $"[CompanyID] = '{companyID}'";
            }

            Accounts account = AccountID_SearchLookUpEdit.GetSelectedDataRow().CastTo<Accounts>();
            if (account != null)
            {
                AccountDetailName_TextEdit.Text = account.AccountName;
                if (string.IsNullOrEmpty(filter))
                {
                    filter += $"[AccountID] = '{account.AccountID}'";
                }
                else
                {
                    filter += $" AND [AccountID] = '{account.AccountID}'";
                }
            }

            // filter grid            
            if (!string.IsNullOrEmpty(filter))
            {
                AccountDetail_GridView.ActiveFilterString = filter;
            }
        }

        private void Account_CheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            Accounts selected = Account_TreeList.GetFocusedRow().CastTo<Accounts>();

            if (selected.Status != ModifyMode.Insert)
            {
                selected.Status = ModifyMode.Update;
            }
        }

        private void AddAccount_MenuItem_Click(object sender, EventArgs e)
        {
            AddAccount();
        }

        private void AddDetailAccount_MenuItem_Click(object sender, EventArgs e)
        {
            AddAccount(false);
        }

        private void Account_TreeList_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            Accounts selected = Account_TreeList.GetFocusedRow().CastTo<Accounts>();
            AccountID_SearchLookUpEdit.EditValue = selected.AccountID;
        }

        private void AllCompanies_CheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            Company_Label.Enabled = !AllCompanies_CheckEdit.Checked;
        }
    }
}

using BSClient.Utility;
using BSCommon.Constant;
using BSCommon.Models;
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

        public BindingList<GeneralLedger> GeneralLedgerData { get; set; }

        public List<AccountGroup> AccountGroupDeleteData { get; set; } = new List<AccountGroup>();

        public List<Accounts> AccountsDeleteData { get; set; } = new List<Accounts>();

        public List<GeneralLedger> GeneralLedgerDeleteData { get; set; } = new List<GeneralLedger>();

        public AccountList()
        {
            InitializeComponent();

            LoadGrid();

            InitComboBox();
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
                new ColumnInfo ("GeneralLedgerID", "Mã Sổ cái", 90),
                new ColumnInfo ("GeneralLedgerName", "Tên Sổ cái", 250),
                new ColumnInfo ("AccountID", "Tài khoản", 90)
            };

            this.GeneralLedger_SearchLookUpEdit.SetupLookUpEdit("GeneralLedgerID", "GeneralLedgerName", GetGeneralLedgerDataComboBox(), columns);
        }

        private List<GeneralLedger> GetGeneralLedgerDataComboBox()
        {
            return GeneralLedgerData.Where(o => string.IsNullOrEmpty(o.ParentID)).ToList();
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

            LoadGeneralLedgerGrid();
        }

        private void LoadAccountsGrid()
        {
            InitAccountsGridView();
            SetupAccountsGridView();
            LoadAccountsGridView();
        }

        private void LoadGeneralLedgerGrid()
        {
            InitGeneralLedgerGridView();

            SetupGeneralLedgerGridView();

            LoadGeneralLedgerGridView();
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
            this.Account_TreeList.AddColumn("AccountID", "Mã TK", 90, true);
            this.Account_TreeList.AddColumn("AccountName", "Tên TK", 250, true, fixedWidth: false);
            this.Account_TreeList.AddLookupEditColumn("AccountGroupID", "Loại TK", 220,
                AccountGroupData, "AccountGroupID", "AccountGroupName");
        }

        private void InitGeneralLedgerGridView()
        {
            this.GeneralLedger_GridView.Columns.Clear();

            this.GeneralLedger_GridView.AddColumn("GeneralLedgerID", "Mã Sổ cái", 90, false);
            this.GeneralLedger_GridView.AddColumn("GeneralLedgerName", "Tên Sổ cái", 250, true, fixedWidth: false);
            this.GeneralLedger_GridView.AddColumn("AccountID", "Tài khoản", 90, false);
            this.GeneralLedger_GridView.AddColumn("CompanyID", "Công ty", 90, false);
            this.GeneralLedger_GridView.AddColumn("ParentID", "Sổ cái chính", 90, false);
        }

        private void SetupAccountGroupGridView()
        {
            this.AccountGroup_GridView.SetupGridView(columnAutoWidth: true);
        }

        private void SetupAccountsGridView()
        {
            Account_TreeList.SetupTreeList();
        }

        private void SetupGeneralLedgerGridView()
        {
            GeneralLedger_GridView.SetupGridView(newItemRow: NewItemRowPosition.None, columnAutoWidth: true);
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
            Account_TreeList.DataSource = AccountsData;
            Account_TreeList.ExpandAll();
        }

        private void LoadGeneralLedgerGridView()
        {
            AccountsController controller = new AccountsController();
            GeneralLedgerData = new BindingList<GeneralLedger>(controller.GetGeneralLedger());
            GeneralLedger_GridControl.DataSource = GeneralLedgerData;

            this.GeneralLedger_SearchLookUpEdit.Properties.DataSource = GetGeneralLedgerDataComboBox();
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
                    this.LoadGeneralLedgerGridView();
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

        private void GeneralLedger_AddNew_Button_Click(object sender, EventArgs e)
        {
            GeneralLedger generalLedger = GeneralLedger_SearchLookUpEdit.GetSelectedDataRow().CastTo<GeneralLedger>();
            Company company = CompanyID_SearchLookUpEdit.GetSelectedDataRow().CastTo<Company>();

            if (string.IsNullOrEmpty(company.CompanyID))
            {
                MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000005);
                return;
            }

            if (string.IsNullOrEmpty(generalLedger.GeneralLedgerID))
            {
                MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000023);
                return;
            }

            string generalLedgerName = GeneralLedgerDetailName_TextBox.Text;
            if (string.IsNullOrWhiteSpace(generalLedgerName))
            {
                MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000025);
                return;
            }

            if (GeneralLedgerData.ToList().Find(o => o.GeneralLedgerName == generalLedgerName) != null)
            {
                MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000024);
                return;
            }

            GeneralLedgerData.Add(new GeneralLedger
            {
                GeneralLedgerName = generalLedgerName,
                CompanyID = company.CompanyID,
                ParentID = generalLedger.GeneralLedgerID,
                AccountID = generalLedger.AccountID,
                Status = ModifyMode.Insert
            });
        }

        private void GeneralLedger_Delete_Button_Click(object sender, EventArgs e)
        {
            GeneralLedger_GridView.DeleteSelectedRows();
        }

        private void GeneralLedger_Save_Button_Click(object sender, EventArgs e)
        {
            List<GeneralLedger> saveData = this.GeneralLedgerData.Where(o => o.Status == ModifyMode.Insert || o.Status == ModifyMode.Update).ToList();

            if (GeneralLedgerDeleteData != null && GeneralLedgerDeleteData.Count > 0)
            {
                saveData?.AddRange(GeneralLedgerDeleteData);
            }

            if (saveData?.Count > 0)
            {
                AccountsController controller = new AccountsController();
                if (controller.SaveGeneralLedger(saveData))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    GeneralLedgerDeleteData = new List<GeneralLedger>();
                    this.LoadGeneralLedgerGridView();
                }
                else
                {
                    MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000002);
                }
            }
        }

        private void GeneralLedger_Cancel_Button_Click(object sender, EventArgs e)
        {
            LoadGeneralLedgerGridView();
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

        private void GeneralLedger_GridView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            GeneralLedger row = e.Row.CastTo<GeneralLedger>();
            if (row.Status == ModifyMode.Insert)
            {
                return;
            }

            row.Status = ModifyMode.Update;
        }

        private void GeneralLedger_GridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            GeneralLedger delete = e.Row.CastTo<GeneralLedger>();
            if (delete.Status == ModifyMode.Insert)
            {
                return;
            }

            delete.Status = ModifyMode.Delete;
            GeneralLedgerDeleteData.Add(delete);
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

        private void GeneralLedger_GridView_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void GeneralLedger_GridView_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            if (GeneralLedger_GridView.FocusedColumn.FieldName == "GeneralLedgerName" && e.Valid)
            {
                e.Valid = false;
                //Set errors with specific descriptions for the columns
                GridView view = sender as GridView;
                GridColumn column = view.Columns["GeneralLedgerName"];
                view.SetColumnError(column, BSMessage.BSM000024);
            }
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
            if (colName == "AccountID" && !string.IsNullOrEmpty(row.AccountID))
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

            Accounts row = Account_TreeList.GetFocusedRow().CastTo<Accounts>();
            TreeList view = sender as TreeList;
            TreeListColumn column;

            if (row == null) return;

            string accountID = row.AccountID;

            if (string.IsNullOrWhiteSpace(accountID))
            {
                e.Valid = false;
                //Set errors with specific descriptions for the columns
                column = view.Columns[nameof(row.AccountID)];
                view.SetColumnError(column, BSMessage.BSM000019);
            }

            // Kiểm tra tồn tại trong grid
            if (AccountsData.ToList().Count(o => o.AccountID == accountID) > 1)
            {
                e.Valid = false;
                column = view.Columns[nameof(row.AccountID)];
                view.SetColumnError(column, BSMessage.BSM000021);
            }

            if (string.IsNullOrEmpty(row.AccountName))
            {
                e.Valid = false;
                column = view.Columns[nameof(row.AccountName)];
                view.SetColumnError(column, BSMessage.BSM000020);
            }

            if (string.IsNullOrEmpty(row.AccountGroupID))
            {
                e.Valid = false;
                column = view.Columns[nameof(row.AccountGroupID)];
                view.SetColumnError(column, BSMessage.BSM000016);
            }

            if (row.Status != ModifyMode.Insert)
            {
                row.Status = ModifyMode.Update;
            }
        }

        private void Account_TreeList_InvalidNodeException(object sender, DevExpress.XtraTreeList.InvalidNodeExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void CompanyID_SearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            Company selectedRow = CompanyID_SearchLookUpEdit.GetSelectedDataRow().CastTo<Company>();
            if (selectedRow == null)
            {
                return;
            }

            // filter grid
            this.GeneralLedger_GridView.ClearColumnsFilter();
            GeneralLedger_GridView.ActiveFilterString = $"[CompanyID] = '{selectedRow.CompanyID}' OR IsNullOrEmpty([CompanyID])";
        }

        private void GeneralLedger_GridView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void GeneralLedger_GridView_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            this.GeneralLedger_GridView.ClearColumnErrors();
            var row = e.Row.CastTo<GeneralLedger>();
            if (this.GeneralLedgerData.Count(o => o.GeneralLedgerName == row.GeneralLedgerName) > 1)
            {
                e.Valid = false;
                //Set errors with specific descriptions for the columns
                GridView view = sender as GridView;
                GridColumn column = view.Columns["GeneralLedgerName"];
                view.SetColumnError(column, BSMessage.BSM000024);
            }
        }

        private void GeneralLedger_SearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            GeneralLedger selectedRow = GeneralLedger_SearchLookUpEdit.GetSelectedDataRow().CastTo<GeneralLedger>();
            if (selectedRow == null)
            {
                return;
            }

            GeneralLedgerDetailName_TextBox.Text = selectedRow.GeneralLedgerName;
        }
    }
}

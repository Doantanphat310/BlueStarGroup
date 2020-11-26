using BSClient.Utility;
using BSCommon.Constant;
using BSCommon.Models;
using BSServer.Controllers;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
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

        public BindingList<ItemPriceCompany> GeneralLedgerData { get; set; }

        public List<AccountGroup> AccountGroupDeleteData { get; set; } = new List<AccountGroup>();

        public List<Accounts> AccountsDeleteData { get; set; } = new List<Accounts>();

        public List<ItemPriceCompany> GeneralLedgerDeleteData { get; set; } = new List<ItemPriceCompany>();

        public BindingSource accountsBindingSource { get; set; }

        public AccountList()
        {
            InitializeComponent();

            LoadGrid();

            InitComboBox();
        }

        private void InitComboBox()
        {
            List<Company> companys = GetCompanyList();
            CompanyID_SearchLookUpEdit.Properties.DataSource = companys;
            CompanyID_SearchLookUpEdit.Properties.ValueMember = "CompanyID";
            CompanyID_SearchLookUpEdit.Properties.DisplayMember = "CompanyName";
            CompanyID_SearchLookUpEdit.Properties.NullText = "Chọn Công ty";

            CompanyID_SearchLookUpEdit.Properties.View.AddColumn("CompanyID", "Mã Công ty", 100, false);
            CompanyID_SearchLookUpEdit.Properties.View.AddColumn("CompanyName", "Tên Công ty", 250, false);
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

            LoadAccountsCompanyGrid();
        }

        private void LoadAccountsGrid()
        {
            SetupAccountsGridView();
            InitAccountsGridView();
            LoadAccountsGridView();
        }

        private void LoadAccountsCompanyGrid()
        {
            InitAccountsCompanyGridView();

            SetupAccountsCompanyGridView();

            LoadAccountsCompanyGridView();
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

            this.AccountGroup_GridView.AddColumn("AccountGroupID", "Mã Loại TK", 90, true);
            this.AccountGroup_GridView.AddColumn("AccountGroupName", "Tên Loại TK", 120, true, fixedWidth: false);
        }

        private void InitAccountsGridView()
        {
            this.Account_TreeList.Columns.Clear();
            this.Account_TreeList.AddColumn("AccountID", "Mã TK", 90, true);
            this.Account_TreeList.AddColumn("AccountName", "Tên TK", 250, true, fixedWidth: false);

            var columns = new Dictionary<string, string>
            {
                {"AccountGroupName", "Tên nhóm TK" }
            };
            this.Account_TreeList.AddLookupEditColumn("AccountGroupID", "Loại TK", 220,
                accountsBindingSource, "AccountGroupID", "AccountGroupName", columnNames: columns);
            //this.Account_TreeList.AddColumn("AccountLevel", "Cấp TK", 90, true);
        }

        private void InitAccountsCompanyGridView()
        {
            //this.GeneralLedger_GridView.Columns.Clear();

            //this.GeneralLedger_GridView.AddColumn("AccountID", "Mã SP", 90, false);
            //this.GeneralLedger_GridView.AddColumn("AccountName", "Tên SP", 160, false, fixedWidth: false);
            //this.GeneralLedger_GridView.AddColumn("CompanyID", "Mã Công ty", 90, false);
            //this.GeneralLedger_GridView.AddColumn("CompanyName", "Tên Công ty", 160, false, fixedWidth: false);
            //this.GeneralLedger_GridView.AddSpinEditColumn("ItemPrice", "Giá", 120, true, "#,#######0.00");
        }

        private void SetupAccountGroupGridView()
        {
            this.AccountGroup_GridView.SetupGridView();
        }

        private void SetupAccountsGridView()
        {
            Account_TreeList.KeyFieldName = "AccountID";
            Account_TreeList.ParentFieldName = "ParentID";
            Account_TreeList.OptionsNavigation.AutoFocusNewNode = true;
        }

        private void SetupAccountsCompanyGridView()
        {
            //GeneralLedger_GridView.SetupGridView(allowAddRows: false);
        }

        private void LoadAccountGroupGridView()
        {
            AccountsController controller = new AccountsController();
            AccountGroupData = new BindingList<AccountGroup>(controller.GetAccountGroup());
            AccountGroup_GridControl.DataSource = AccountGroupData;
            accountsBindingSource = new BindingSource
            {
                DataSource = AccountGroupData
            };
        }

        private void LoadAccountsGridView()
        {
            AccountsController controller = new AccountsController();
            AccountsData = new BindingList<Accounts>(controller.GetAccounts());
            this.accountsBindingSource = new BindingSource
            {
                DataSource = AccountsData
            };

            Account_TreeList.DataSource = AccountsData;
            Account_TreeList.ExpandAll();
        }

        private void LoadAccountsCompanyGridView()
        {
            //AccountsController controller = new AccountsController();
            //GeneralLedgerData = new BindingList<ItemPriceCompany>(controller.GetAccountsCompany());
            //GeneralLedger_GridControl.DataSource = GeneralLedgerData;
        }

        private void AccountGroup_Delete_Button_Click(object sender, EventArgs e)
        {
            AccountGroup_GridView.DeleteSelectedRows();
        }

        private void AccountGroup_Save_Button_Click(object sender, EventArgs e)
        {
            List<AccountGroup> saveData = this.AccountGroupData.Where(o => o.Status == ModifyMode.Insert || o.Status == ModifyMode.Update).ToList();

            if (AccountGroupDeleteData != null)
            {
                saveData?.AddRange(AccountGroupDeleteData);
            }

            if (saveData?.Count > 0)
            {
                AccountsController controller = new AccountsController();
                if (controller.SaveAccountGroup(saveData))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    AccountsDeleteData = new List<Accounts>();
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

            if (AccountsDeleteData != null)
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

        private void ItemCompany_AddNew_Button_Click(object sender, EventArgs e)
        {
            //Accounts item = Accounts_GridView.GetFocusedRow().CastTo<Accounts>();
            //Company company = CompanyID_SearchLookUpEdit.GetSelectedDataRow().CastTo<Company>();

            //if (string.IsNullOrEmpty(item.ItemID))
            //{
            //    MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000007);
            //    return;
            //}

            //if (string.IsNullOrEmpty(company.CompanyID))
            //{
            //    MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000005);
            //    return;
            //}

            //if (GeneralLedgerData.ToList().Find(o => o.ItemID == item.ItemID && o.CompanyID == company.CompanyID) != null)
            //{
            //    MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000008);
            //    return;
            //}

            ////if (ItemPrice_Number.Value <= 0)
            ////{
            ////    MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000014);
            ////    return;
            ////}

            //GeneralLedgerData.Add(new ItemPriceCompany
            //{
            //    ItemID = item.ItemID,
            //    ItemName = item.ItemName,
            //    CompanyID = company.CompanyID,
            //    CompanyName = company.CompanyName,
            //    //ItemPrice = ItemPrice_Number.Value,
            //    Status = ModifyMode.Insert
            //});
        }

        private void ItemCompany_Delete_Button_Click(object sender, EventArgs e)
        {
            //GeneralLedger_GridView.DeleteSelectedRows();
        }

        private void ItemCompany_Save_Button_Click(object sender, EventArgs e)
        {
            //List<ItemPriceCompany> saveData = this.GeneralLedgerData.Where(o => o.Status == ModifyMode.Insert || o.Status == ModifyMode.Update).ToList();

            //if (GeneralLedgerDeleteData != null)
            //{
            //    saveData?.AddRange(GeneralLedgerDeleteData);
            //}

            //if (saveData?.Count > 0)
            //{
            //    AccountsController controller = new AccountsController();
            //    if (controller.SaveAccountsCompany(saveData))
            //    {
            //        MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
            //        GeneralLedgerDeleteData = new List<ItemPriceCompany>();
            //        this.LoadAccountsCompanyGridView();
            //    }
            //    else
            //    {
            //        MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000002);
            //    }
            //}
        }

        private void ItemCompany_Cancel_Button_Click(object sender, EventArgs e)
        {
            //LoadAccountsCompanyGridView();
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

        private void Accounts_GridView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            //Accounts row = e.Row.CastTo<Accounts>();
            //bool isNewRow = Accounts_GridView.IsNewItemRow(e.RowHandle);
            //if (isNewRow)
            //{
            //    row.Status = ModifyMode.Insert;
            //    return;
            //}

            //if (row.Status == ModifyMode.Insert)
            //{
            //    return;
            //}

            //row.Status = ModifyMode.Update;
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

        private void AccountsCompany_GridView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            //ItemPriceCompany row = e.Row.CastTo<ItemPriceCompany>();
            //bool isNewRow = GeneralLedger_GridView.IsNewItemRow(e.RowHandle);
            //if (isNewRow)
            //{
            //    row.Status = ModifyMode.Insert;
            //    return;
            //}

            //if (row.Status == ModifyMode.Insert)
            //{
            //    return;
            //}

            //row.Status = ModifyMode.Update;
        }

        private void AccountsCompany_GridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            //ItemPriceCompany delete = e.Row.CastTo<ItemPriceCompany>();
            //if (delete.Status == ModifyMode.Insert)
            //{
            //    return;
            //}

            //delete.Status = ModifyMode.Delete;
            //GeneralLedgerDeleteData.Add(delete);
        }

        private void Accounts_GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            //Accounts selectedRow = Accounts_GridView.GetFocusedRow().CastTo<Accounts>();
            //if (selectedRow == null)
            //{
            //    return;
            //}

            //// filter grid
            //GeneralLedger_GridView.ActiveFilterString = $"[ItemID] = '{selectedRow.ItemID}'";
        }

        private void Accounts_GridView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void Accounts_GridView_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            //Accounts_GridView.ClearColumnErrors();

            //Accounts row = e.Row.CastTo<Accounts>();
            //GridView view = sender as GridView;
            //GridColumn column;

            //if (Accounts_GridView.IsNewItemRow(e.RowHandle))
            //{
            //    string accountID = row.AccountID;

            //    if (string.IsNullOrWhiteSpace(accountID))
            //    {
            //        e.Valid = false;
            //        //Set errors with specific descriptions for the columns
            //        column = view.Columns[nameof(row.AccountID)];
            //        view.SetColumnError(column, BSMessage.BSM000019);
            //    }

            //    // Kiểm tra tồn tại trong grid
            //    if (AccountsData.ToList().Count(o => o.AccountID == accountID) > 1)
            //    {
            //        e.Valid = false;
            //        column = view.Columns[nameof(row.AccountID)];
            //        view.SetColumnError(column, BSMessage.BSM000021);
            //    }
            //}

            //if (string.IsNullOrEmpty(row.AccountName))
            //{
            //    e.Valid = false;
            //    column = view.Columns[nameof(row.AccountName)];
            //    view.SetColumnError(column, BSMessage.BSM000020);
            //}

            //if (string.IsNullOrEmpty(row.AccountGroupID))
            //{
            //    e.Valid = false;
            //    column = view.Columns[nameof(row.AccountGroupID)];
            //    view.SetColumnError(column, BSMessage.BSM000016);
            //}
        }

        private void AccountGroup_GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            AccountGroup selectedRow = AccountGroup_GridView.GetFocusedRow().CastTo<AccountGroup>();
            if (selectedRow == null)
            {
                return;
            }

            // filter grid
            Account_TreeList.ActiveFilterString = $"[AccountGroupID] = '{selectedRow.AccountGroupID}'";
            Account_TreeList.OptionsView.ShowFilterPanelMode = DevExpress.XtraTreeList.ShowFilterPanelMode.Never;
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

                if (string.IsNullOrWhiteSpace(accountGroupID))
                {
                    e.Valid = false;
                    //Set errors with specific descriptions for the columns
                    column = view.Columns[nameof(row.AccountGroupID)];
                    view.SetColumnError(column, BSMessage.BSM000016);
                }

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
            }); ;
        }

        private void AccountsCompany_GridView_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            //e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void AccountsCompany_GridView_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            //if (GeneralLedger_GridView.FocusedColumn.FieldName == "ItemPrice" && Convert.ToDecimal(e.Value) <= 0)
            //{
            //    e.Valid = false;
            //    //Set errors with specific descriptions for the columns
            //    GridView view = sender as GridView;
            //    GridColumn column = view.Columns["ItemPrice"];
            //    view.SetColumnError(column, BSMessage.BSM000014);
            //}
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
        }

        private void Account_TreeList_InvalidNodeException(object sender, DevExpress.XtraTreeList.InvalidNodeExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void Account_TreeList_NodeChanged(object sender, DevExpress.XtraTreeList.NodeChangedEventArgs e)
        {
            Console.WriteLine("Account_TreeList_NodeChanged");
        }
    }
}

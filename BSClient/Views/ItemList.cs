using BSClient.Utility;
using BSCommon.Constant;
using BSCommon.Models;
using BSCommon.Utility;
using BSServer.Controllers;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BSClient.Views
{
    public partial class ItemList : UserControl
    {
        public BindingList<ItemType> ItemTypeData { get; set; }

        public BindingList<Items> ItemsData { get; set; }

        public BindingList<ItemPriceCompany> ItemCompanyData { get; set; }

        public List<ItemType> ItemTypeDeleteData { get; set; } = new List<ItemType>();

        public List<Items> ItemsDeleteData { get; set; } = new List<Items>();

        public List<ItemPriceCompany> ItemsCompanyDeleteData { get; set; } = new List<ItemPriceCompany>();

        public ItemList()
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
            LoadItemTypeGrid();

            LoadItemsGrid();

            LoadItemsCompanyGrid();
        }

        private void LoadItemsGrid()
        {
            InitItemsGridView();

            SetupItemsGridView();

            LoadItemsGridView();
        }

        private void LoadItemsCompanyGrid()
        {
            InitItemsCompanyGridView();

            SetupItemsCompanyGridView();

            LoadItemsCompanyGridView();
        }

        private void LoadItemTypeGrid()
        {
            InitItemTypeGridView();

            SetupItemTypeGridView();

            LoadItemTypeGridView();
        }

        private void InitItemTypeGridView()
        {
            this.ItemType_GridView.Columns.Clear();

            this.ItemType_GridView.AddColumn("ItemTypeID", "Mã Loại SP", 90, false);
            this.ItemType_GridView.AddColumn("ItemTypeName", "Tên Loại SP", 120, true, fixedWidth: false);
            this.ItemType_GridView.AddColumn("ItemTypeSName", "Tên viết tắt", 60, true);
        }

        private void InitItemsGridView()
        {
            this.Items_GridView.Columns.Clear();

            this.Items_GridView.AddColumn("ItemID", "Mã SP", 90, false);
            this.Items_GridView.AddColumn("ItemName", "Tên SP", 160, true, fixedWidth: false);
            this.Items_GridView.AddColumn("ItemSName", "Tên viết tắt", 80, true);
            this.Items_GridView.AddColumn("ItemTypeID", "Loại SP", 90, false);

            var itemSource = MasterInfoManager.GetItemUnit();
            var columnShow = new Dictionary<string, string>
            {
                {"DetailCd", "Mã ĐVT" },
                {"Value", "Tên ĐVT" },
            };

            this.Items_GridView.AddLookupEditColumn("ItemUnit", "ĐVT", 80, itemSource, "DetailCd", "Value", columnNames: columnShow);
        }

        private void InitItemsCompanyGridView()
        {
            this.ItemsCompany_GridView.Columns.Clear();

            this.ItemsCompany_GridView.AddColumn("ItemID", "Mã SP", 90, false);
            this.ItemsCompany_GridView.AddColumn("ItemName", "Tên SP", 160, false, fixedWidth: false);
            this.ItemsCompany_GridView.AddColumn("CompanyID", "Mã Công ty", 90, false);
            this.ItemsCompany_GridView.AddColumn("CompanyName", "Tên Công ty", 160, false, fixedWidth: false);
            this.ItemsCompany_GridView.AddSpinEditColumn("ItemPrice", "Giá", 120, true, "#,#######0.00");
        }

        private void SetupItemTypeGridView()
        {
            this.ItemType_GridView.SetupGridView();
        }

        private void SetupItemsGridView()
        {
            this.Items_GridView.SetupGridView(allowAddRows: false);
        }

        private void SetupItemsCompanyGridView()
        {
            ItemsCompany_GridView.SetupGridView(allowAddRows: false);
        }

        private void LoadItemTypeGridView()
        {
            ItemsController controller = new ItemsController();
            ItemTypeData = new BindingList<ItemType>(controller.GetItemType());
            ItemType_GridControl.DataSource = ItemTypeData;
        }

        private void LoadItemsGridView()
        {
            ItemsController controller = new ItemsController();
            ItemsData = new BindingList<Items>(controller.GetItems());
            Items_GridControl.DataSource = ItemsData;
        }

        private void LoadItemsCompanyGridView()
        {
            ItemsController controller = new ItemsController();
            ItemCompanyData = new BindingList<ItemPriceCompany>(controller.GetItemsCompany());
            ItemsCompany_GridControl.DataSource = ItemCompanyData;
        }

        private void ItemType_Delete_Button_Click(object sender, EventArgs e)
        {
            ItemType_GridView.DeleteSelectedRows();
        }

        private void ItemType_Save_Button_Click(object sender, EventArgs e)
        {
            List<ItemType> saveData = this.ItemTypeData.Where(o => o.Status == ModifyMode.Insert || o.Status == ModifyMode.Update).ToList();

            if (ItemTypeDeleteData != null)
            {
                saveData?.AddRange(ItemTypeDeleteData);
            }

            if (saveData?.Count > 0)
            {
                ItemsController controller = new ItemsController();
                if (controller.SaveItemType(saveData))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    ItemsDeleteData = new List<Items>();
                    this.LoadItemTypeGridView();
                }
                else
                {
                    MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000002);
                }
            }
        }

        private void ItemType_Cancel_Button_Click(object sender, EventArgs e)
        {
            LoadItemTypeGridView();
        }

        private void Items_Delete_Button_Click(object sender, EventArgs e)
        {
            Items_GridView.DeleteSelectedRows();
        }

        private void Items_Save_Button_Click(object sender, EventArgs e)
        {
            List<Items> saveData = this.ItemsData.Where(o => o.Status == ModifyMode.Insert || o.Status == ModifyMode.Update).ToList();

            if (ItemsDeleteData != null)
            {
                saveData?.AddRange(ItemsDeleteData);
            }

            if (saveData?.Count > 0)
            {
                ItemsController controller = new ItemsController();
                if (controller.SaveItems(saveData))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    ItemsDeleteData = new List<Items>();
                    this.LoadItemsGridView();
                }
                else
                {
                    MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000002);
                }
            }
        }

        private void Items_Cancel_Button_Click(object sender, EventArgs e)
        {
            LoadItemsGridView();
        }

        private void ItemCompany_AddNew_Button_Click(object sender, EventArgs e)
        {
            Items item = Items_GridView.GetFocusedRow().CastTo<Items>();
            Company company = CompanyID_SearchLookUpEdit.GetSelectedDataRow().CastTo<Company>();

            if (string.IsNullOrEmpty(item.ItemID))
            {
                MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000007);
                return;
            }

            if (string.IsNullOrEmpty(company.CompanyID))
            {
                MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000005);
                return;
            }

            if (ItemCompanyData.ToList().Find(o => o.ItemID == item.ItemID && o.CompanyID == company.CompanyID) != null)
            {
                MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000008);
                return;
            }

            if (ItemPrice_Number.Value <= 0)
            {
                MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000014);
                return;
            }

            ItemCompanyData.Add(new ItemPriceCompany
            {
                ItemID = item.ItemID,
                ItemName = item.ItemName,
                CompanyID = company.CompanyID,
                CompanyName = company.CompanyName,
                ItemPrice = ItemPrice_Number.Value,
                Status = ModifyMode.Insert
            });
        }

        private void ItemCompany_Delete_Button_Click(object sender, EventArgs e)
        {
            ItemsCompany_GridView.DeleteSelectedRows();
        }

        private void ItemCompany_Save_Button_Click(object sender, EventArgs e)
        {
            List<ItemPriceCompany> saveData = this.ItemCompanyData.Where(o => o.Status == ModifyMode.Insert || o.Status == ModifyMode.Update).ToList();

            if (ItemsCompanyDeleteData != null)
            {
                saveData?.AddRange(ItemsCompanyDeleteData);
            }

            if (saveData?.Count > 0)
            {
                ItemsController controller = new ItemsController();
                if (controller.SaveItemsCompany(saveData))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    ItemsCompanyDeleteData = new List<ItemPriceCompany>();
                    this.LoadItemsCompanyGridView();
                }
                else
                {
                    MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000002);
                }
            }
        }

        private void ItemCompany_Cancel_Button_Click(object sender, EventArgs e)
        {
            LoadItemsCompanyGridView();
        }

        private void ItemType_GridView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            ItemType row = e.Row.CastTo<ItemType>();
            bool isNewRow = ItemType_GridView.IsNewItemRow(e.RowHandle);
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

        private void ItemType_GridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            ItemType delete = e.Row.CastTo<ItemType>();
            if (delete.Status == ModifyMode.Insert)
            {
                return;
            }

            delete.Status = ModifyMode.Delete;
            ItemTypeDeleteData.Add(delete);
        }

        private void Items_GridView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            Items row = e.Row.CastTo<Items>();
            bool isNewRow = Items_GridView.IsNewItemRow(e.RowHandle);
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

        private void Items_GridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            Items delete = e.Row.CastTo<Items>();
            if (delete.Status == ModifyMode.Insert)
            {
                return;
            }

            delete.Status = ModifyMode.Delete;
            ItemsDeleteData.Add(delete);
        }

        private void ItemsCompany_GridView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            ItemPriceCompany row = e.Row.CastTo<ItemPriceCompany>();
            bool isNewRow = ItemsCompany_GridView.IsNewItemRow(e.RowHandle);
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

        private void ItemsCompany_GridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            ItemPriceCompany delete = e.Row.CastTo<ItemPriceCompany>();
            if (delete.Status == ModifyMode.Insert)
            {
                return;
            }

            delete.Status = ModifyMode.Delete;
            ItemsCompanyDeleteData.Add(delete);
        }

        private void Items_GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            Items selectedRow = Items_GridView.GetFocusedRow().CastTo<Items>();
            if (selectedRow == null)
            {
                return;
            }

            // filter grid
            ItemsCompany_GridView.ActiveFilterString = $"[ItemID] = '{selectedRow.ItemID}'";
        }

        private void Items_GridView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void Items_GridView_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            Items_GridView.ClearColumnErrors();

            Items row = e.Row.CastTo<Items>();
            GridView view = sender as GridView;

            if (string.IsNullOrEmpty(row.ItemName))
            {
                e.Valid = false;
                //Set errors with specific descriptions for the columns
                GridColumn column = view.Columns[nameof(row.ItemName)];
                view.SetColumnError(column, BSMessage.BSM000011);
            }

            if (string.IsNullOrEmpty(row.ItemSName))
            {
                e.Valid = false;
                //Set errors with specific descriptions for the columns
                GridColumn column = view.Columns[nameof(row.ItemName)];
                view.SetColumnError(column, BSMessage.BSM000012);
            }

            // Kiểm tra tồn tại trong grid
            if (ItemsData.ToList().Count(o => o.ItemSName == row.ItemSName) > 1)
            {
                e.Valid = false;
                //Set errors with specific descriptions for the columns
                GridColumn column = view.Columns[nameof(row.ItemSName)];
                view.SetColumnError(column, BSMessage.BSM000010);
            }
        }

        private void ItemType_GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            ItemType selectedRow = ItemType_GridView.GetFocusedRow().CastTo<ItemType>();
            if (selectedRow == null)
            {
                return;
            }

            // filter grid
            Items_GridView.ActiveFilterString = $"[ItemTypeID] = '{selectedRow.ItemTypeID}'";

            Items_GridView_FocusedRowChanged(sender, e);
        }

        private void ItemType_GridView_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            ItemType_GridView.ClearColumnErrors();

            ItemType row = e.Row.CastTo<ItemType>();
            GridView view = sender as GridView;

            if (string.IsNullOrEmpty(row.ItemTypeName))
            {
                e.Valid = false;
                //Set errors with specific descriptions for the columns
                GridColumn column = view.Columns[nameof(row.ItemTypeName)];
                view.SetColumnError(column, BSMessage.BSM000013);
            }

            if (string.IsNullOrEmpty(row.ItemTypeSName))
            {
                e.Valid = false;
                //Set errors with specific descriptions for the columns
                GridColumn column = view.Columns[nameof(row.ItemTypeSName)];
                view.SetColumnError(column, BSMessage.BSM000012);
            }

            // Kiểm tra tồn tại trong grid
            if (ItemTypeData.ToList().Count(o => o.ItemTypeSName == row.ItemTypeSName) > 1)
            {
                e.Valid = false;
                //Set errors with specific descriptions for the columns
                GridColumn column = view.Columns[nameof(row.ItemTypeSName)];
                view.SetColumnError(column, BSMessage.BSM000010);
            }
        }

        private void ItemType_GridView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void Items_Add_Button_Click(object sender, EventArgs e)
        {
            string itemTypeID = ItemType_GridView.GetFocusedRow().CastTo<ItemType>().ItemTypeID;
            if (string.IsNullOrEmpty(itemTypeID))
            {
                MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000009);
                return;
            }

            ItemsData.Add(new Items
            {
                ItemTypeID = itemTypeID,
                Status = ModifyMode.Insert
            });
        }

        private void ItemsCompany_GridView_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void ItemsCompany_GridView_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            if (ItemsCompany_GridView.FocusedColumn.FieldName == "ItemPrice" && Convert.ToDecimal(e.Value) <= 0)
            {
                e.Valid = false;
                //Set errors with specific descriptions for the columns
                GridView view = sender as GridView;
                GridColumn column = view.Columns["ItemPrice"];
                view.SetColumnError(column, BSMessage.BSM000014);
            }
        }
    }
}

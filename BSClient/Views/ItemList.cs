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

        public BindingList<ItemUnit> ItemUnitData { get; set; }

        public List<ItemType> ItemTypeDeleteData { get; set; } = new List<ItemType>();

        public List<Items> ItemsDeleteData { get; set; } = new List<Items>();

        public List<ItemUnit> ItemUnitDeleteData { get; set; } = new List<ItemUnit>();

        public ItemList()
        {
            InitializeComponent();

            LoadGrid();
        }

        private void LoadGrid()
        {
            LoadItemTypeGrid();

            LoadItemUnitGrid();

            LoadItemsGrid();
        }

        private void LoadItemsGrid()
        {
            InitItemsGridView();

            SetupItemsGridView();

            LoadItemsGridView();
        }

        private void LoadItemUnitGrid()
        {
            InitItemUnitGridView();

            SetupItemUnitGridView();

            LoadItemUnitGridView();
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
            this.Items_GridView.AddColumn("ItemName", "Tên SP", 500, true, fixedWidth: false);
            this.Items_GridView.AddColumn("ItemSName", "Tên viết tắt", 80, true);
            this.Items_GridView.AddColumn("ItemSpecification", "Quy cách", 80, true);
            //this.Items_GridView.AddColumn("ItemTypeID", "Loại SP", 90, true);
            List<ColumnInfo> columns = new List<ColumnInfo>
            {
                new ColumnInfo("ItemTypeName", "Tên Loại SP", 160),
                new ColumnInfo("ItemTypeSName", "Tên Viết Tắt", 90),
            };
            this.Items_GridView.AddLookupEditColumn(
                "ItemTypeID", "Loại SP", 90, 
                ItemTypeData, 
                "ItemTypeID", "ItemTypeSName", 
                columns: columns, 
                isAllowEdit: true,
                showHearder: true);
            //this.Items_GridView.AddSpinEditColumn("ItemPrice", "Giá SP", 90, false);
            this.Items_GridView.AddSpinEditColumn("ItemPrice", "Giá SP", 120, true, "#,#######0.00");

            this.Items_GridView.AddLookupEditColumn("ItemUnitID", "ĐVT", 80, ItemUnitData, "ItemUnitID", "ItemUnitName");
        }

        private void InitItemUnitGridView()
        {
            this.ItemUnit_GridView.Columns.Clear();

            this.ItemUnit_GridView.AddColumn("ItemUnitID", "Mã ĐVT", 90, false);
            this.ItemUnit_GridView.AddColumn("ItemUnitName", "Tên ĐVT", 160, true, fixedWidth: false);
        }

        private void SetupItemTypeGridView()
        {
            this.ItemType_GridView.SetupGridView();
        }

        private void SetupItemsGridView()
        {
            this.Items_GridView.SetupGridView(columnAutoWidth: false, newItemRow: NewItemRowPosition.None);
        }

        private void SetupItemUnitGridView()
        {
            ItemUnit_GridView.SetupGridView();
        }

        private void LoadItemTypeGridView()
        {
            using (ItemsController controller = new ItemsController())
            {
                try
                {
                    ItemTypeData = new BindingList<ItemType>(controller.GetItemType());
                    ItemType_GridControl.DataSource = ItemTypeData;
                }
                catch (Exception ex)
                {
                    BSLog.Logger.Error(ex.Message);
                    MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000028, "<Danh Mục Loại Sản Phẩm>");
                }
            }
        }

        private void LoadItemsGridView()
        {
            using (ItemsController controller = new ItemsController())
            {
                try
                {
                    ItemsData = new BindingList<Items>(controller.GetItems());
                    Items_GridControl.DataSource = ItemsData;
                }
                catch(Exception ex)
                {
                    BSLog.Logger.Error(ex.Message);
                    MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000028, "<Danh Mục Sản Phẩm>");
                }
            }
        }

        private void LoadItemUnitGridView()
        {
            using (ItemsController controller = new ItemsController())
            {
                try
                {
                    ItemUnitData = new BindingList<ItemUnit>(controller.GetItemUnit());
                    ItemUnit_GridControl.DataSource = ItemUnitData;
                }
                catch (Exception ex)
                {
                    BSLog.Logger.Error(ex.Message);
                    MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000028, "<Danh mục Đơn vị tính>");
                }
            }
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

            if (ItemsDeleteData != null && ItemsDeleteData.Count > 0)
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

        private void ItemUnit_Delete_Button_Click(object sender, EventArgs e)
        {
            ItemUnit_GridView.DeleteSelectedRows();
        }

        private void ItemUnit_Save_Button_Click(object sender, EventArgs e)
        {
            List<ItemUnit> saveData = this.ItemUnitData.Where(o => o.Status == ModifyMode.Insert || o.Status == ModifyMode.Update).ToList();

            if (ItemUnitDeleteData != null && ItemUnitDeleteData.Count > 0)
            {
                saveData?.AddRange(ItemUnitDeleteData);
            }

            if (saveData?.Count > 0)
            {
                ItemsController controller = new ItemsController();
                if (controller.SaveItemUnit(saveData))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    ItemUnitDeleteData = new List<ItemUnit>();
                    this.LoadItemUnitGridView();
                }
                else
                {
                    MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000002);
                }
            }
        }

        private void ItemCompany_Cancel_Button_Click(object sender, EventArgs e)
        {
            LoadItemUnitGridView();
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

        private void ItemUnit_GridView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            ItemUnit row = e.Row.CastTo<ItemUnit>();
            bool isNewRow = ItemUnit_GridView.IsNewItemRow(e.RowHandle);
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

        private void ItemUnit_GridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            ItemUnit delete = e.Row.CastTo<ItemUnit>();
            if (delete.Status == ModifyMode.Insert)
            {
                return;
            }

            delete.Status = ModifyMode.Delete;
            ItemUnitDeleteData.Add(delete);
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
                GridColumn column = view.Columns[nameof(row.ItemSName)];
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
            Items_GridView.ClearColumnsFilter();
            ItemType selectedRow = ItemType_GridView.GetFocusedRow().CastTo<ItemType>();
            if (selectedRow == null)
            {
                return;
            }

            // filter grid
            Items_GridView.ActiveFilterString = $"[ItemTypeID] = '{selectedRow.ItemTypeID}'";
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

        private void ItemUnit_GridView_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void ItemUnit_GridView_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            if (ItemUnit_GridView.FocusedColumn.FieldName == "ItemPrice" && Convert.ToDecimal(e.Value) <= 0)
            {
                e.Valid = false;
                //Set errors with specific descriptions for the columns
                GridView view = sender as GridView;
                GridColumn column = view.Columns["ItemPrice"];
                view.SetColumnError(column, BSMessage.BSM000014);
            }
        }

        private void ItemUnit_GroupControl_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
           
        }
    }
}

using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections.Generic;

namespace BSClient.Utility
{
    public static class GridViewHelper
    {
        public static void AddSpinEditColumn(
            this GridView gridView,
            string fieldName,
            string caption,
            int width,
            bool isAllowEdit = true,
            string formatString = "")
        {
            RepositoryItemSpinEdit itemCtrl = new RepositoryItemSpinEdit();

            if (!string.IsNullOrEmpty(formatString))
            {
                FormatInfo formatInfo = new FormatInfo
                {
                    FormatString = formatString,
                    FormatType = FormatType.Numeric
                };
                itemCtrl.EditFormat.Assign(formatInfo);
                itemCtrl.DisplayFormat.Assign(formatInfo);
            }

            gridView.AddColumn(fieldName, caption, width, isAllowEdit, itemCtrl);
        }

        public static void AddCheckBoxColumn(
            this GridView gridView,
            string fieldName,
            string caption,
            int width,
            bool isAllowEdit = true)
        {
            RepositoryItemCheckEdit itemCtrl = new RepositoryItemCheckEdit();

            gridView.AddColumn(fieldName, caption, width, isAllowEdit, itemCtrl);
        }

        public static void AddComboBoxColumn(
            this GridView gridView,
            string fieldName,
            string caption,
            int width,
            object itemSource,
            bool isAllowEdit = true,
            Dictionary<string, string> columnNames = null)
        {
            var itemCtrl = new RepositoryItemLookUpEdit
            {
                DataSource = itemSource
            };

            if (columnNames != null)
            {
                foreach (var col in columnNames)
                {
                    itemCtrl.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(col.Key, col.Value));
                }
            }

            gridView.AddColumn(fieldName, caption, width, isAllowEdit, itemCtrl);
        }

        public static void AddDateEditColumn(
            this GridView gridView,
            string fieldName,
            string caption,
            int width,
            bool isAllowEdit = true,
            string formatString = "")
        {
            RepositoryItemDateEdit itemCtrl = new RepositoryItemDateEdit();

            if (!string.IsNullOrEmpty(formatString))
            {
                FormatInfo formatInfo = new FormatInfo
                {
                    FormatString = formatString,
                    FormatType = FormatType.DateTime
                };
                itemCtrl.EditFormat.Assign(formatInfo);
                itemCtrl.DisplayFormat.Assign(formatInfo);
            }

            gridView.AddColumn(fieldName, caption, width, isAllowEdit, itemCtrl);
        }

        public static void AddColumn(
            this GridView gridView,
            string fieldName,
            string caption,
            int width,
            bool isAllowEdit = true,
            RepositoryItem itemCtrl = null)
        {
            GridColumn col = new GridColumn
            {
                Caption = caption,
                Name = fieldName,
                FieldName = fieldName,
                Visible = true,
                Width = width
            };

            col.OptionsColumn.AllowEdit = isAllowEdit;
            col.AppearanceHeader.Options.UseTextOptions = true;
            col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;

            if (itemCtrl != null)
            {
                col.ColumnEdit = itemCtrl;
            }

            gridView.Columns.Add(col);
        }

        public static void SetupGridView(
            this GridView gridView,
            bool columnAutoWidth = true,
            bool multiSelect = true,
            int checkBoxSelectorColumnWidth = 40,
            bool showAutoFilterRow = true)
        {
            gridView.NewItemRowText = "Chọn vào đây để thêm dòng mới";
            gridView.OptionsBehavior.AutoPopulateColumns = true;

            gridView.OptionsNavigation.AutoFocusNewRow = true;

            gridView.OptionsSelection.MultiSelect = multiSelect;
            if (multiSelect && checkBoxSelectorColumnWidth > 0)
            {
                gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
                gridView.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
                gridView.OptionsSelection.CheckBoxSelectorColumnWidth = checkBoxSelectorColumnWidth;
            }

            gridView.OptionsView.ColumnAutoWidth = columnAutoWidth;
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            gridView.OptionsView.ShowAutoFilterRow = showAutoFilterRow;
        }
    }
}

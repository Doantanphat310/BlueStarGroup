using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace BSClient.Utility
{
    public static class GridViewHelper
    {
        public static void AddSpinEditColumn(
            this GridView gridView,
            string fieldName,
            string caption,
            int width,
            bool isAllowEdit = true)
        {
            RepositoryItemSpinEdit itemCtrl = new RepositoryItemSpinEdit();

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
            params string[] ColumnNames)
        {
            var itemCtrl = new RepositoryItemLookUpEdit
            {
                DataSource = itemSource
            };

            foreach (string col in ColumnNames)
            {
                itemCtrl.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(col, col));
            }

            gridView.AddColumn(fieldName, caption, width, isAllowEdit, itemCtrl);
        }

        public static void AddDateEditColumn(
            this GridView gridView,
            string fieldName,
            string caption,
            int width,
            bool isAllowEdit = true)
        {
            RepositoryItemDateEdit itemCtrl = new RepositoryItemDateEdit();

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
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

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
            gridView.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            gridView.OptionsBehavior.AutoPopulateColumns = true;

            gridView.OptionsSelection.MultiSelect = multiSelect;
            if (multiSelect && checkBoxSelectorColumnWidth > 0)
            {
                gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
                gridView.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
                gridView.OptionsSelection.CheckBoxSelectorColumnWidth = checkBoxSelectorColumnWidth;
            }

            gridView.OptionsPrint.EnableAppearanceOddRow = true;

            gridView.OptionsView.ColumnAutoWidth = columnAutoWidth;
            //gridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            gridView.OptionsView.ShowAutoFilterRow = showAutoFilterRow;
        }
    }
}

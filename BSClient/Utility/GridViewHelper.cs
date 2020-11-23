using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;

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
            string formatString = "#,###0",
            SummaryItemType summaryType = SummaryItemType.None,
            string summaryFormat = ""
            )
        {
            RepositoryItemSpinEdit itemCtrl = new RepositoryItemSpinEdit();
            //itemCtrl.Mask.MaskType = MaskType.Numeric;
            //itemCtrl.Mask.EditMask = formatString;
            itemCtrl.DisplayFormat.FormatString = formatString;
            itemCtrl.DisplayFormat.FormatType = FormatType.Custom;
            itemCtrl.EditFormat.FormatString = formatString;
            itemCtrl.EditFormat.FormatType = FormatType.Custom;

            GridColumnSummaryItem summaryItem = new GridColumnSummaryItem();

            if (summaryType != SummaryItemType.None)
            {
                summaryFormat = string.IsNullOrEmpty(summaryFormat) ? formatString : summaryFormat;
                summaryItem = new GridColumnSummaryItem(summaryType, fieldName, summaryFormat);
            }


            gridView.AddColumn(fieldName, caption, width, isAllowEdit, itemCtrl: itemCtrl, summaryItem: summaryItem);
        }

        public static void AddCheckBoxColumn(
            this GridView gridView,
            string fieldName,
            string caption,
            int width,
            bool isAllowEdit = true)
        {
            RepositoryItemCheckEdit itemCtrl = new RepositoryItemCheckEdit();

            gridView.AddColumn(fieldName, caption, width, isAllowEdit, itemCtrl: itemCtrl);
        }

        public static void AddLookupEditColumn(
            this GridView gridView,
            string fieldName,
            string caption,
            int width,
            object itemSource,
            string valueMember,
            string displayMember,
            bool isAllowEdit = true,
            Dictionary<string, string> columnNames = null,
            string nullText = "",
            EventHandler editValueChanged = null)
        {
            var itemCtrl = new RepositoryItemLookUpEdit
            {
                DataSource = itemSource,
                DisplayMember = displayMember,
                ValueMember = valueMember,
                NullText = nullText
            };

            if (editValueChanged != null)
            {
                itemCtrl.EditValueChanged += editValueChanged;
            }

            if (columnNames != null)
            {
                foreach (var col in columnNames)
                {
                    itemCtrl.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(col.Key, col.Value));
                }
            }

            gridView.AddColumn(fieldName, caption, width, isAllowEdit, itemCtrl: itemCtrl);
        }

        public static void AddSearchLookupEditColumn(
            this GridView gridView,
            string fieldName,
            string caption,
            int width,
            object itemSource,
            string valueMember,
            string displayMember,
            bool isAllowEdit = true,
            Dictionary<string, string> columnNames = null,
            string nullText = "",
            EventHandler editValueChanged = null)
        {
            var itemCtrl = new RepositoryItemSearchLookUpEdit
            {
                DataSource = itemSource,
                DisplayMember = displayMember,
                ValueMember = valueMember,
                NullText = nullText
            };

            if (editValueChanged != null)
            {
                itemCtrl.EditValueChanged += editValueChanged;
            }

            if (columnNames != null)
            {
                foreach (var col in columnNames)
                {
                    var gridCol = new GridColumn
                    {
                        FieldName = col.Key,
                        Caption = col.Value,
                        Visible = true,
                    };

                    itemCtrl.View.Columns.Add(gridCol);
                }
            }

            gridView.AddColumn(fieldName, caption, width, isAllowEdit, itemCtrl: itemCtrl);
        }

        public static void AddDateEditColumn(
            this GridView gridView,
            string fieldName,
            string caption,
            int width,
            bool isAllowEdit = true,
            string formatString = "dd/MM/yyyy")
        {
            RepositoryItemDateEdit itemCtrl = new RepositoryItemDateEdit();

            itemCtrl.DisplayFormat.FormatString = formatString;
            itemCtrl.DisplayFormat.FormatType = FormatType.DateTime;

            gridView.AddColumn(fieldName, caption, width, isAllowEdit, itemCtrl: itemCtrl);
        }

        public static void AddColumn(
            this GridView gridView,
            string fieldName,
            string caption,
            int width,
            bool isAllowEdit = true,
            bool fixedWidth = true,
            RepositoryItem itemCtrl = null,
            GridColumnSummaryItem summaryItem = null
            )
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
            col.OptionsColumn.FixedWidth = fixedWidth;

            if (itemCtrl != null)
            {
                col.ColumnEdit = itemCtrl;
            }

            // Add Summary Item
            if (summaryItem != null)
            {
                col.Summary.Add(summaryItem);
            }

            gridView.Columns.Add(col);
        }

        private static GridColumn GetColumn(
            string fieldName,
            string caption,
            int width,
            bool isAllowEdit = true,
            bool fixedWidth = true,
            RepositoryItem itemCtrl = null,
            GridSummaryItem summaryItem = null
            )
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
            col.OptionsColumn.FixedWidth = fixedWidth;

            if (itemCtrl != null)
            {
                col.ColumnEdit = itemCtrl;
            }

            // Add Summary Item
            if (summaryItem != null)
            {
                col.Summary.Add(summaryItem);
            }

            return col;
        }

        public static void SetupGridView(
            this GridView gridView,
            bool columnAutoWidth = true,
            bool multiSelect = true,
            int checkBoxSelectorColumnWidth = 30,
            bool showAutoFilterRow = true,
            bool showFooter = false,
            bool allowAddRows = true)
        {
            gridView.NewItemRowText = "Chọn vào đây để thêm dòng mới";
            gridView.OptionsBehavior.AutoPopulateColumns = true;

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

            if (allowAddRows)
            {
                gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
                gridView.OptionsBehavior.AllowAddRows = DefaultBoolean.True;
            }

            gridView.OptionsView.ShowFooter = showFooter;
        }
    }
}

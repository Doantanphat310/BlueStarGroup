using DevExpress.Utils;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BSClient.Utility
{
    public static class TreeListHelper
    {
        //public static void AddSpinEditColumn(
        //    this GridView gridView,
        //    string fieldName,
        //    string caption,
        //    int width,
        //    bool isAllowEdit = true,
        //    string formatString = "#,###0",
        //    SummaryItemType summaryType = SummaryItemType.None,
        //    string summaryFormat = ""
        //    )
        //{
        //    RepositoryItemSpinEdit itemCtrl = new RepositoryItemSpinEdit();
        //    itemCtrl.DisplayFormat.FormatString = formatString;
        //    itemCtrl.DisplayFormat.FormatType = FormatType.Custom;
        //    itemCtrl.EditFormat.FormatString = formatString;
        //    itemCtrl.EditFormat.FormatType = FormatType.Custom;

        //    GridColumnSummaryItem summaryItem = new GridColumnSummaryItem();

        //    if (summaryType != SummaryItemType.None)
        //    {
        //        summaryFormat = string.IsNullOrEmpty(summaryFormat) ? formatString : summaryFormat;
        //        summaryItem = new GridColumnSummaryItem(summaryType, fieldName, summaryFormat);
        //    }


        //    gridView.AddColumn(fieldName, caption, width, isAllowEdit, itemCtrl: itemCtrl, summaryItem: summaryItem);
        //}

        //public static void AddCheckBoxColumn(
        //    this GridView gridView,
        //    string fieldName,
        //    string caption,
        //    int width,
        //    bool isAllowEdit = true)
        //{
        //    RepositoryItemCheckEdit itemCtrl = new RepositoryItemCheckEdit();

        //    gridView.AddColumn(fieldName, caption, width, isAllowEdit, itemCtrl: itemCtrl);
        //}

        public static void AddLookupEditColumn(
            this TreeList gridView,
            string fieldName,
            string caption,
            int width,
            object itemSource,
            string valueMember,
            string displayMember,
            bool isAllowEdit = true,
            Dictionary<string, string> columnNames = null,
            string nullText = "",
            bool showHearder = false,
            EventHandler editValueChanged = null)
        {
            var itemCtrl = new RepositoryItemLookUpEdit
            {
                DataSource = itemSource,
                DisplayMember = displayMember,
                ValueMember = valueMember,
                NullText = nullText,
                ShowHeader = showHearder
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

        private static void ItemCtrl_SearchLookUpEdit_Popup(object sender, EventArgs e)
        {
            SearchLookUpEdit edit = sender.CastTo<SearchLookUpEdit>();
            PopupSearchLookUpEditForm popupForm = edit.GetPopupEditForm();
            popupForm.KeyPreview = true;
            popupForm.KeyPress += PopupForm_KeyPress;
        }

        private static void PopupForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PopupSearchLookUpEditForm popupForm = sender as PopupSearchLookUpEditForm;
                GridView view = popupForm.OwnerEdit.Properties.View;
                view.FocusedRowHandle = 0;
                popupForm.OwnerEdit.ClosePopup();
            }
        }

        //public static void AddDateEditColumn(
        //    this GridView gridView,
        //    string fieldName,
        //    string caption,
        //    int width,
        //    bool isAllowEdit = true,
        //    string formatString = "dd/MM/yyyy")
        //{
        //    RepositoryItemDateEdit itemCtrl = new RepositoryItemDateEdit();

        //    itemCtrl.DisplayFormat.FormatString = formatString;
        //    itemCtrl.DisplayFormat.FormatType = FormatType.DateTime;

        //    gridView.AddColumn(fieldName, caption, width, isAllowEdit, itemCtrl: itemCtrl);
        //}

        //public static void AddColumn(
        //    this GridView gridView,
        //    string fieldName,
        //    string caption,
        //    int width,
        //    bool isAllowEdit = true,
        //    bool fixedWidth = true,
        //    RepositoryItem itemCtrl = null,
        //    GridColumnSummaryItem summaryItem = null
        //    )
        //{
        //    GridColumn col = new GridColumn
        //    {
        //        Caption = caption,
        //        Name = fieldName,
        //        FieldName = fieldName,
        //        Visible = true,
        //        Width = width
        //    };

        //    col.OptionsColumn.AllowEdit = isAllowEdit;
        //    col.AppearanceHeader.Options.UseTextOptions = true;
        //    col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
        //    col.OptionsColumn.FixedWidth = fixedWidth;

        //    if (itemCtrl != null)
        //    {
        //        col.ColumnEdit = itemCtrl;
        //    }

        //    // Add Summary Item
        //    if (summaryItem != null)
        //    {
        //        col.Summary.Add(summaryItem);
        //    }

        //    gridView.Columns.Add(col);
        //}

        public static void AddColumn(
            this TreeList gridView,
            string fieldName,
            string caption,
            int width,
            bool isAllowEdit = true,
            bool fixedWidth = true,
            RepositoryItem itemCtrl = null
            )
        {
            TreeListColumn col = new TreeListColumn
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
            //if (summaryItem != null)
            //{
            //    col.SummaryFooter..Add(summaryItem);
            //}

            gridView.Columns.Add(col);
        }

        public static void AddSearchLookupEditColumn(
            this TreeList gridView,
            string fieldName,
            string caption,
            int width,
            object itemSource,
            string valueMember,
            string displayMember,
            bool isAllowEdit = true,
            Dictionary<string, string> columns = null,
            string nullText = "",
            EventHandler editValueChanged = null)
        {
            RepositoryItemSearchLookUpEdit itemCtrl = new RepositoryItemSearchLookUpEdit
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

            if (columns != null)
            {
                foreach (var col in columns)
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

            itemCtrl.Popup += ItemCtrl_SearchLookUpEdit_Popup;


            gridView.AddColumn(fieldName, caption, width, isAllowEdit, itemCtrl: itemCtrl);
        }

        //private static GridColumn GetColumn(
        //    string fieldName,
        //    string caption,
        //    int width,
        //    bool isAllowEdit = true,
        //    bool fixedWidth = true,
        //    RepositoryItem itemCtrl = null,
        //    GridSummaryItem summaryItem = null
        //    )
        //{
        //    GridColumn col = new GridColumn
        //    {
        //        Caption = caption,
        //        Name = fieldName,
        //        FieldName = fieldName,
        //        Visible = true,
        //        Width = width
        //    };

        //    col.OptionsColumn.AllowEdit = isAllowEdit;
        //    col.AppearanceHeader.Options.UseTextOptions = true;
        //    col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
        //    col.OptionsColumn.FixedWidth = fixedWidth;

        //    if (itemCtrl != null)
        //    {
        //        col.ColumnEdit = itemCtrl;
        //    }

        //    // Add Summary Item
        //    if (summaryItem != null)
        //    {
        //        col.Summary.Add(summaryItem);
        //    }

        //    return col;
        //}

        public static void SetupGridView(
            this TreeList gridView,
            bool multiSelect = true)
        {
            gridView.OptionsBehavior.AutoPopulateColumns = true;

            gridView.OptionsSelection.MultiSelect = multiSelect;
            gridView.OptionsSelection.MultiSelectMode = TreeListMultiSelectMode.RowSelect;
           
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.OptionsView.ShowAutoFilterRow = false;
        }
    }
}

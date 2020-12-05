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
using System.Drawing;
using System.Windows.Forms;

namespace BSClient.Utility
{
    public static class TreeListHelper
    {
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
            else
            {
                itemCtrl.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(displayMember));
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
            col.OptionsColumn.AllowSize = false;

            if (itemCtrl != null)
            {
                col.ColumnEdit = itemCtrl;
            }

            gridView.Columns.Add(col);
        }

        public static void AddSearchLookupEditColumn(
            this TreeList treeList,
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


            treeList.AddColumn(fieldName, caption, width, isAllowEdit, itemCtrl: itemCtrl);
        }

        public static void SetupTreeList(
            this TreeList treeList,
            bool multiSelect = true)
        {
            treeList.OptionsBehavior.AutoPopulateColumns = true;

            treeList.OptionsSelection.MultiSelect = multiSelect;
            treeList.OptionsSelection.MultiSelectMode = TreeListMultiSelectMode.RowSelect;

            treeList.OptionsView.EnableAppearanceEvenRow = true;
            treeList.OptionsView.ShowAutoFilterRow = true;

            treeList.OptionsNavigation.AutoFocusNewNode = true;
            treeList.OptionsView.ShowFilterPanelMode = DevExpress.XtraTreeList.ShowFilterPanelMode.Never;

            treeList.Appearance.FocusedRow.BackColor = ColorTranslator.FromHtml("#80bfff"); ;
            treeList.Appearance.FocusedRow.Options.UseBackColor = true;
            treeList.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFocus;
        }
    }
}

using BSCommon.Models;
using DevExpress.Utils;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
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
            List<ColumnInfo> columnNames = null,
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
                    var colInfo = new LookUpColumnInfo
                    {
                        FieldName = col.FieldName,
                        Caption = col.Caption,
                        Visible = true,
                    };

                    if (col.Width > 0)
                    {
                        colInfo.Width = col.Width;
                    }

                    itemCtrl.Columns.Add(colInfo);
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
            RepositoryItem itemCtrl = null)
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
                gridView.RepositoryItems.AddRange(
                    new RepositoryItem[] { itemCtrl });
            }

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
           List<ColumnInfo> columns,
           bool isAllowEdit = true,
           string nullText = "",
           EventHandler editValueChanged = null,
           int popupFormWidth = -1,
           bool enterChoiceFirstRow = true)
        {
            RepositoryItemSearchLookUpEdit itemCtrl = new RepositoryItemSearchLookUpEdit();

            itemCtrl.SetupLookUpEdit(
                valueMember,
                displayMember,
                itemSource,
                columns,
                nullText: nullText,
                enterChoiceFirstRow: enterChoiceFirstRow,
                popupFormWidth: popupFormWidth);

            if (editValueChanged != null)
            {
                itemCtrl.EditValueChanged += editValueChanged;
            }

            gridView.AddColumn(fieldName, caption, width, isAllowEdit, itemCtrl: itemCtrl);
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

            treeList.NodeCellStyle += TreeList_NodeCellStyle;
        }

        private static void TreeList_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            var gridView = sender as TreeList;
            if (e.Node.Focused == true)
            {
                e.Appearance.BackColor = gridView.Appearance.FocusedRow.BackColor;
            }
        }
    }
}

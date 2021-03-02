using BSClient.Constants;
using BSCommon.Models;
using BSCommon.Utility;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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
            string summaryFormat = "",
            KeyEventHandler keyDown = null)
        {
            RepositoryItemSpinEdit itemCtrl = new RepositoryItemSpinEdit();
            itemCtrl.DisplayFormat.FormatString = formatString;
            itemCtrl.DisplayFormat.FormatType = FormatType.Custom;
            itemCtrl.EditFormat.FormatString = formatString;
            itemCtrl.EditFormat.FormatType = FormatType.Custom;
            itemCtrl.EditMask = formatString;

            GridColumnSummaryItem summaryItem = new GridColumnSummaryItem();

            if (summaryType != SummaryItemType.None)
            {
                summaryFormat = string.IsNullOrEmpty(summaryFormat) ? "{0: " + formatString + "}" : summaryFormat;
                summaryItem = new GridColumnSummaryItem(summaryType, fieldName, summaryFormat);
            }

            if (keyDown != null)
            {
                itemCtrl.KeyDown += new KeyEventHandler(keyDown);
            }

            gridView.AddColumn(fieldName, caption, width, isAllowEdit, itemCtrl: itemCtrl, summaryItem: summaryItem);
        }

        public static void AddTextEditColumn(
            this GridView gridView,
            string fieldName,
            string caption,
            int width,
            bool isAllowEdit = true,
            KeyEventHandler keyDown = null)
        {
            RepositoryItemTextEdit itemCtrl = new RepositoryItemTextEdit();

            if (keyDown != null)
            {
                itemCtrl.KeyDown += new KeyEventHandler(keyDown);
            }

            gridView.AddColumn(fieldName, caption, width, isAllowEdit, itemCtrl: itemCtrl);
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
            List<ColumnInfo> columns = null,
            string nullText = "",
            bool showHearder = false,
            EventHandler editValueChanged = null,
            KeyEventHandler keyDown = null)
        {
            RepositoryItemLookUpEdit itemCtrl = new RepositoryItemLookUpEdit
            {
                DataSource = itemSource,
                DisplayMember = displayMember,
                ValueMember = valueMember,
                NullText = nullText,
                ShowHeader = showHearder,
                TextEditStyle = TextEditStyles.Standard,
                AllowNullInput = DefaultBoolean.True
            };

            if (editValueChanged != null)
            {
                itemCtrl.EditValueChanged += editValueChanged;
            }

            if (keyDown != null)
            {
                itemCtrl.KeyDown += new KeyEventHandler(keyDown);
            }

            if (columns != null)
            {
                foreach (var col in columns)
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
                itemCtrl.Columns.Add(new LookUpColumnInfo(displayMember));
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
           List<ColumnInfo> columns = null,
           bool isAllowEdit = true,
           string nullText = "",
           EventHandler editValueChanged = null,
           int popupFormWidth = -1,
           bool enterChoiceFirstRow = true,
           KeyEventHandler keyDown = null)
        {
            RepositoryItemSearchLookUpEdit itemCtrl = new RepositoryItemSearchLookUpEdit();

            itemCtrl.SetupLookUpEdit(
                valueMember,
                displayMember,
                itemSource, columns,
                nullText: nullText,
                enterChoiceFirstRow: enterChoiceFirstRow,
                popupFormWidth: popupFormWidth);

            if (editValueChanged != null)
            {
                itemCtrl.EditValueChanged += editValueChanged;
            }

            if (keyDown != null)
            {
                itemCtrl.KeyDown += new KeyEventHandler(keyDown);
            }

            gridView.AddColumn(fieldName, caption, width, isAllowEdit, itemCtrl: itemCtrl);
        }

        //private static void ItemCtrl_SearchLookUpEdit_Popup(object sender, EventArgs e)
        //{
        //    SearchLookUpEdit edit = sender.CastTo<SearchLookUpEdit>();
        //    PopupSearchLookUpEditForm popupForm = edit.GetPopupEditForm();
        //    popupForm.KeyPreview = true;
        //    popupForm.KeyPress += PopupForm_KeyPress;
        //}

        //private static void PopupForm_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        PopupSearchLookUpEditForm popupForm = sender as PopupSearchLookUpEditForm;
        //        GridView view = popupForm.OwnerEdit.Properties.View;
        //        view.FocusedRowHandle = 0;
        //        popupForm.OwnerEdit.ClosePopup();
        //    }
        //}

        public static void AddDateEditColumn(
            this GridView gridView,
            string fieldName,
            string caption,
            int width,
            bool isAllowEdit = true,
            HorzAlignment textAlignment = HorzAlignment.Center,
            string formatString = "dd/MM/yyyy")
        {
            RepositoryItemDateEdit itemCtrl = new RepositoryItemDateEdit();

            itemCtrl.DisplayFormat.FormatString = formatString;
            itemCtrl.DisplayFormat.FormatType = FormatType.Custom;
            itemCtrl.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;

            gridView.AddColumn(fieldName, caption, width, isAllowEdit: isAllowEdit, itemCtrl: itemCtrl, textAlignment: textAlignment);
        }

        public static void AddColumn(
            this GridView gridView,
            string fieldName,
            string caption,
            int width,
            bool? isAllowEdit = null,
            bool fixedWidth = true,
            HorzAlignment textAlignment = HorzAlignment.Default,
            RepositoryItem itemCtrl = null,
            GridColumnSummaryItem summaryItem = null)
        {
            GridColumn col = new GridColumn
            {
                Caption = caption,
                Name = fieldName,
                FieldName = fieldName,
                Visible = true
            };

            if (width > 0)
            {
                col.Width = width;
            }

            if (isAllowEdit != null)
            {
                col.OptionsColumn.AllowEdit = isAllowEdit.Value;
            }

            col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            col.AppearanceHeader.Options.UseTextOptions = true;
            col.OptionsColumn.FixedWidth = fixedWidth;

            col.AppearanceCell.TextOptions.HAlignment = textAlignment;
            col.AppearanceCell.Options.UseTextOptions = true;

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

        public static GridColumn GetColumn(
            string fieldName,
            string caption,
            int width,
            bool isAllowEdit = true,
            bool fixedWidth = true,
            RepositoryItem itemCtrl = null,
            GridSummaryItem summaryItem = null)
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
            bool columnAutoWidth = false,
            bool multiSelect = true,
            int checkBoxSelectorColumnWidth = 30,
            bool showAutoFilterRow = true,
            bool showFooter = false,
            NewItemRowPosition newItemRow = NewItemRowPosition.Top,
            bool editable = true,
            bool hasShowRowHeader = false,
            int rowHeaderWidth = 30)
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

            gridView.OptionsNavigation.AutoFocusNewRow = true;
            gridView.OptionsNavigation.AutoMoveRowFocus = true;
            gridView.OptionsView.ColumnAutoWidth = columnAutoWidth;
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            gridView.OptionsView.ShowAutoFilterRow = showAutoFilterRow;

            gridView.OptionsCustomization.AllowColumnResizing = true;

            if (newItemRow != NewItemRowPosition.None)
            {
                gridView.OptionsView.NewItemRowPosition = newItemRow;
            }

            gridView.OptionsView.ShowFooter = showFooter;
            gridView.OptionsBehavior.Editable = editable;

            gridView.Appearance.FocusedRow.BackColor = ColorTranslator.FromHtml("#80bfff"); ;
            gridView.Appearance.FocusedRow.Options.UseBackColor = true;
            gridView.FocusRectStyle = DrawFocusRectStyle.RowFocus;

            gridView.RowStyle += GridView_RowStyle;

            if (hasShowRowHeader)
            {
                gridView.IndicatorWidth = rowHeaderWidth;
                gridView.CustomDrawRowIndicator += GridView_CustomDrawRowIndicator;
            }

            gridView.InvalidRowException += GridView_InvalidRowException;
            gridView.InvalidValueException += GridView_InvalidValueException;
        }

        private static void GridView_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            // Suppress displaying the error message box
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private static void GridView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            // Suppress displaying the error message box
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private static void GridView_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private static void GridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            var gridView = sender as GridView;
            if (e.RowHandle == gridView.FocusedRowHandle)
            {
                e.Appearance.BackColor = gridView.Appearance.FocusedRow.BackColor;
                e.HighPriority = true;
            }
        }

        public static void ExportExcel(
            this GridControl gridControl,
            string templateID,
            bool hasOpened = true)
        {
            string sheetName = ExcelTemplate.GetTemplate(templateID);
            SaveFileDialog openFileDialog = new SaveFileDialog
            {
                Filter = "Excel file(*.xlsx)|*.xlsx",
                FileName = sheetName
            };

            string path;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
            }
            else
            {
                return;
            }

            try
            {
                XlsxExportOptions xlsxExportOptions = new XlsxExportOptions
                {
                    SheetName = sheetName
                };
                gridControl.ExportToXlsx(path, xlsxExportOptions);

                if (hasOpened)
                {
                    System.Diagnostics.Process.Start(path);
                }
            }
            catch (Exception ex)
            {
                BSLog.Logger.Warn(ex.Message);
                MessageBoxHelper.ShowErrorMessage($"Xuất excel thất bại!\r\n{ex.Message}");
            }
        }
    }
        
}

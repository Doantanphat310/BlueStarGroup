using BSCommon.Models;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace BSClient.Utility
{
    public static class BandedGridViewHelper
    {
        public static void AddSpinEditColumn(
            this BandedGridView gridView,
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

            gridView.AddColumn(fieldName, caption, width, isAllowEdit, itemCtrl: itemCtrl, summaryItem: summaryItem);
        }

        public static void AddLookupEditColumn(
            this BandedGridView gridView,
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
            EventHandler editValueChanged = null)
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

        public static void AddColumn(
            this BandedGridView gridView,
            string fieldName,
            string caption,
            int width,
            bool? isAllowEdit = null,
            bool fixedWidth = true,
            HorzAlignment textAlignment = HorzAlignment.Default,
            RepositoryItem itemCtrl = null,
            GridColumnSummaryItem summaryItem = null)
        {
            BandedGridColumn col = new BandedGridColumn
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
            col.OptionsColumn.AllowSize = false;

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

        public static void SetupGridView(
            this BandedGridView gridView,
            bool columnAutoWidth = false,
            bool showAutoFilterRow = true,
            bool showFooter = false,
            bool editable = true,
            bool hasShowRowHeader = false)
        {
            gridView.OptionsBehavior.AutoPopulateColumns = true;

            gridView.OptionsNavigation.AutoFocusNewRow = true;
            gridView.OptionsNavigation.AutoMoveRowFocus = true;
            gridView.OptionsView.ColumnAutoWidth = columnAutoWidth;
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            gridView.OptionsView.ShowAutoFilterRow = showAutoFilterRow;

            gridView.OptionsView.ShowFooter = showFooter;
            gridView.OptionsBehavior.Editable = editable;

            gridView.Appearance.FocusedRow.BackColor = ColorTranslator.FromHtml("#80bfff"); ;
            gridView.Appearance.FocusedRow.Options.UseBackColor = true;
            gridView.FocusRectStyle = DrawFocusRectStyle.RowFocus;

            if (hasShowRowHeader)
            {
                gridView.CustomDrawRowIndicator += GridView_CustomDrawRowIndicator;
            }

            gridView.RowStyle += GridView_RowStyle;
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

        private static void GridView_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        public static void AddBand(
            this BandedGridView gridView,
            string caption,
            params string[] columns)
        {
            GridBand band = new GridBand
            {
                Caption = caption
            };

            band.AppearanceHeader.Options.UseTextOptions = true;
            band.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;

            BandedGridColumn col;

            foreach (string column in columns)
            {
                col = gridView.Columns[column];
                band.Columns.Add(col);
            }

            gridView.Bands.Add(band);
        }
    }
}

﻿using BSCommon.Utility;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSClient.Utility
{
    public static class ClientCommon
    {
        [Obsolete("Chuyển qua dùng BaseForm")]
        public static void ShowControl(System.Windows.Forms.Control control, System.Windows.Forms.Control Content)
        {
            Content.Controls.Clear();
            control.Dock = System.Windows.Forms.DockStyle.Fill;
            control.BringToFront();
            control.Focus();
            Content.Controls.Add(control);
        }

        [Obsolete("Chuyển qua dùng GridViewHelper")]
        public static void AddColumn(GridView gridView, string fieldName, string caption, int width, bool isAllowEdit = true)
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

            gridView.Columns.Add(col);
        }

        [Obsolete("Chuyển qua dùng GridViewHelper")]
        public static void SetupGridView(
            GridView gridView,
            bool columnAutoWidth = true,
            bool multiSelect = true)
        {
            gridView.OptionsView.ColumnAutoWidth = columnAutoWidth;
            gridView.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            gridView.OptionsBehavior.AutoPopulateColumns = true;
            gridView.OptionsPrint.EnableAppearanceOddRow = true;
            gridView.OptionsSelection.MultiSelect = multiSelect;
            gridView.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            gridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
        }

        public static bool IsCheckPass(string password, string hashPassword)
        {
            return SHA1Helper.IsCheck(password, hashPassword);
        }
    }
}

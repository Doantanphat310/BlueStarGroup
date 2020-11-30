using BSCommon.Models;
using DevExpress.Utils;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BSClient.Utility
{
    public static class LookUpEditHelper
    {
        public static void SetupLookUpEdit(
            this LookUpEdit lookUpEdit,
            string valueMember,
            string displayMember,
            object itemSource,
            string nullText = "")
        {
            lookUpEdit.Properties.DataSource = itemSource;
            lookUpEdit.Properties.ValueMember = valueMember;
            lookUpEdit.Properties.DisplayMember = displayMember;
            lookUpEdit.Properties.NullText = nullText;
            lookUpEdit.Properties.ShowHeader = false;
            lookUpEdit.Properties.Columns.Add(new LookUpColumnInfo
            {
                FieldName = displayMember
            });
        }

        public static void SetupLookUpEdit(
            this SearchLookUpEdit lookUpEdit,
            string valueMember,
            string displayMember,
            object itemSource,
            Dictionary<string, string> columns,
            string nullText = "",
            bool enterChoiceFirstRow = true)
        {
            lookUpEdit.Properties.DataSource = itemSource;
            lookUpEdit.Properties.ValueMember = valueMember;
            lookUpEdit.Properties.DisplayMember = displayMember;
            lookUpEdit.Properties.NullText = nullText;

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

                    lookUpEdit.Properties.View.Columns.Add(gridCol);
                }
            }

            if (enterChoiceFirstRow)
            {
                lookUpEdit.Popup += LookUpEdit_Popup;
            }
        }

        public static void SetupLookUpEdit(
           this SearchLookUpEdit lookUpEdit,
           string valueMember,
           string displayMember,
           object itemSource,
           List<ColumnInfo> columns,
           string nullText = "",
           bool enterChoiceFirstRow = true)
        {
            lookUpEdit.Properties.DataSource = itemSource;
            lookUpEdit.Properties.ValueMember = valueMember;
            lookUpEdit.Properties.DisplayMember = displayMember;
            lookUpEdit.Properties.NullText = nullText;

            if (columns != null)
            {
                foreach (var col in columns)
                {
                    var gridCol = new GridColumn
                    {
                        FieldName = col.FieldName,
                        Caption = col.Caption,
                        Width = col.Width,
                        Visible = true,
                    };

                    lookUpEdit.Properties.View.Columns.Add(gridCol);
                }
            }

            if (enterChoiceFirstRow)
            {
                lookUpEdit.Popup += LookUpEdit_Popup;
            }
        }

        private static void LookUpEdit_Popup(object sender, System.EventArgs e)
        {
            SearchLookUpEdit edit = sender.CastTo<SearchLookUpEdit>();
            var popupForm = edit.GetPopupEditForm();
            popupForm.KeyPreview = true;
            popupForm.KeyPress += PopupForm_KeyPress;
        }

        private static void PopupForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PopupSearchLookUpEditForm popupForm = sender as PopupSearchLookUpEditForm;
                var view = popupForm.OwnerEdit.Properties.View;
                view.FocusedRowHandle = 0;
                popupForm.OwnerEdit.ClosePopup();
            }
        }
    }
}

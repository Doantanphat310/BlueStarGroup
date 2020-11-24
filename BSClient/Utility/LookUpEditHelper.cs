using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections.Generic;

namespace BSClient.Utility
{
    public static class LookUpEditHelper
    {
        public static void SetupLookUpEdit(
            this LookUpEdit lookUpEdit,
            string valueMember,
            string displayMember,
            object itemSource,
            string nullText = "",
            Dictionary<string, string> columns = null)
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
           string nullText = "",
           Dictionary<string, string> columns = null)
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
        }
    }
}

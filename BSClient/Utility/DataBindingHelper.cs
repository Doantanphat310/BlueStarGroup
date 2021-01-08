using BSCommon.Utility;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace BSClient.Utility
{
    public static class DataBindingHelper
    {
        public static void BindingCheckEdit(CheckEdit edit, BindingSource bindingSource)
        {
            try
            {
                edit.DataBindings.Clear();
                Binding b = new Binding("EditValue", bindingSource, edit.Tag?.ToString(), true);
                edit.DataBindings.Add(b);
            }
            catch (Exception ex)
            {
                BSLog.Logger.Debug("Lỗi BindingCheckEdit: " + ex.Message);
            }
        }

        public static void BindingTextEdit(TextEdit edit, BindingSource bindingSource)
        {
            try
            {
                edit.DataBindings.Clear();
                Binding b = new Binding("EditValue", bindingSource, edit.Tag?.ToString(), true);
                edit.DataBindings.Add(b);
            }
            catch (Exception ex)
            {
                BSLog.Logger.Debug("Lỗi BindingTextEdit: " + ex.Message);
            }
        }

        public static void BindingrichTextBox(RichTextBox edit, BindingSource bindingSource)
        {
            try
            {
                edit.DataBindings.Clear();
                Binding b = new Binding("Text", bindingSource, edit.Tag?.ToString(), true);
                edit.DataBindings.Add(b);
            }
            catch (Exception ex)
            {
                BSLog.Logger.Debug("Lỗi BindingrichTextBox: " + ex.Message);
            }
        }

        

        public static void BindingPictureEdit(PictureEdit edit, BindingSource bindingSource)
        {
            try
            {
                edit.DataBindings.Clear();
                Binding b = new Binding("Image", bindingSource, $"{edit.Tag?.ToString()}Image", true);
                edit.DataBindings.Add(b);
            }
            catch (Exception ex)
            {
                BSLog.Logger.Debug("Lỗi BindingPictureEdit: " + ex.Message);
            }
        }

        public static void BindingSearchLookUpEdit(SearchLookUpEdit searchLookUpEdit, BindingSource bindingSource)
        {
            try
            {
                searchLookUpEdit.DataBindings.Clear();
                Binding b = new Binding("EditValue", bindingSource, searchLookUpEdit.Tag?.ToString(), true);
                searchLookUpEdit.DataBindings.Add(b);
            }
            catch (Exception ex)
            {
                BSLog.Logger.Debug("Lỗi BindingSearchLookUpEdit: " + ex.Message);
            }
        }
    }
}

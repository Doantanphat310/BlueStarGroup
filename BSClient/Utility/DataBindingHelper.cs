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
                Console.WriteLine("Lỗi BindingCheckEdit: " + ex.Message);
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
                Console.WriteLine("Lỗi BindingTextEdit: " + ex.Message);
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
                Console.WriteLine("Lỗi BindingPictureEdit: " + ex.Message);
            }
        }
    }
}

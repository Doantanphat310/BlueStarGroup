using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSClient.Utility
{
    public static class MessageBoxHelper
    {
        public static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowConfirmMessage(string message, MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo, MessageBoxDefaultButton messageBoxDefaultButton = MessageBoxDefaultButton.Button2)
        {
            MessageBox.Show(message, "Confirm", messageBoxButtons, MessageBoxIcon.Question, messageBoxDefaultButton);
        }

        public static void ShowInfoMessage(string message)
        {
            MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowMessage(
            string message,
            string caption = "",
            MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK,
            MessageBoxIcon messageBoxIcon = MessageBoxIcon.None,
            MessageBoxDefaultButton messageBoxDefaultButton = MessageBoxDefaultButton.Button2)
        {
            MessageBox.Show(message, caption, messageBoxButtons, messageBoxIcon, messageBoxDefaultButton);
        }
    }
}

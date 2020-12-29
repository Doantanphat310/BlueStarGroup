using System;

namespace BSClient.Controls
{
    public partial class ErrorBox : DevExpress.XtraEditors.XtraForm
    {
        public ErrorBox(string error)
        {
            InitializeComponent();

            this.Error_MemoEdit.Text = error;
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
using DevExpress.XtraBars.FluentDesignSystem;
using System.Windows.Forms;

namespace BSClient.Base
{
    public partial class BaseForm : FluentDesignForm
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        public void ShowControl(Control control, Control Content)
        {
            Content.Controls.Clear();
            control.Dock = System.Windows.Forms.DockStyle.Fill;
            control.BringToFront();
            control.Focus();
            Content.Controls.Add(control);
        }

        public string GetTitle(string subTitle)
        {
            return $" Blue Star Group - {subTitle}";
        }

        public void SetTitle(string subTitle)
        {
            this.Text = $" Blue Star Group - {subTitle}";
        }
    }
}

using DevExpress.XtraBars.FluentDesignSystem;

namespace BSClient.Base
{
    public partial class BaseForm : FluentDesignForm
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        public void ShowControl(System.Windows.Forms.Control control, FluentDesignFormContainer Content)
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

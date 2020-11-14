using DevExpress.XtraBars;
using DevExpress.XtraBars.FluentDesignSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
    }
}

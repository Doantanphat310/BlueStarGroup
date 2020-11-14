using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BSClient.Controls
{
    public partial class ButtonGroup : XtraUserControl
    {
        public ButtonGroup()
        {
            InitializeComponent();
        }

        [Category("Buttons")]
        public bool SaveButon
        {
            get { return this.Save_Button.Visible; }
            set { this.Save_Button.Visible = value; }
        }

        [Category("Buttons")]
        public bool NewButton
        {
            get { return this.New_Button.Visible; }
            set { this.New_Button.Visible = value; }
        }

        [Category("Buttons")]
        public bool EditButton
        {
            get { return this.Edit_Button.Visible; }
            set { this.Edit_Button.Visible = value; }
        }

        [Category("Buttons")]
        public bool DeleteButton
        {
            get { return this.Delete_Button.Visible; }
            set { this.Delete_Button.Visible = value; }
        }

        [Category("Buttons")]
        public bool CancelButton
        {
            get { return this.Cancel_Button.Visible; }
            set { this.Cancel_Button.Visible = value; }
        }
    }
}

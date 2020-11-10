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

namespace BSClient.Base
{
    public partial class BaseFormList : XtraUserControl
    {
        public event EventHandler Save_Click;
        public event EventHandler Delete_Click;
        public event EventHandler AddNew_Click;

        public BaseFormList()
        {
            InitializeComponent();
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            AddNew_Click?.Invoke(sender, e);
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            Delete_Click?.Invoke(sender, e);
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            Save_Click?.Invoke(sender, e);
        }
    }
}

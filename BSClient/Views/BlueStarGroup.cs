using BSClient.Base;
using BSClient.Utility;
using System;

using System.Windows.Forms;

namespace BSClient.Views
{
    public partial class BlueStarGroup : BaseForm
    {
        public BlueStarGroup()
        {
            InitializeComponent();
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {

        }

        private void NhapChungTuaccordionControlElement_Click(object sender, EventArgs e)
        {
            VoucherControl voucher = new VoucherControl();
            this.ShowControl(voucher, Content);
            
            this.Text = " Blue Star Group - Nhập chứng từ";
        }
    }
}

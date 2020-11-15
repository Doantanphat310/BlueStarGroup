using BSClient.Utility;
using System;

using System.Windows.Forms;

namespace BSClient.Views
{
    public partial class BlueStarGroup : Form
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
            ClientCommon.ShowControl(voucher, Content);
            this.Text = " Blue Star Group - Nhập chứng từ";
        }
    }
}

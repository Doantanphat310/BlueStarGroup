using BSClient.Base;
using BSClient.Utility;
using BSClient.Views;
using BSCommon.Utility;
using System;

namespace BSClient
{
    public partial class MainForm : BaseForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ACE_Voucher_Click(object sender, EventArgs e)
        {
            VoucherControl voucher = new VoucherControl();
            ClientCommon.ShowControl(voucher, Content);
            this.Text = " Blue Star Group - Nhập chứng từ";
        }

        private void UserList_Button_Click(object sender, EventArgs e)
        {
            UserList user = new UserList();
            this.ShowControl(user, Content);
            this.Text = this.GetTitle(BSTitle.UserList);
        }

        private void ACE_Company_Click(object sender, EventArgs e)
        {
            CompanyControl company = new CompanyControl();
            ClientCommon.ShowControl(company, Content);
            this.Text = " Blue Star Group - Nhập thông tin công ty";
        }

        private void Custommers_Button_Click(object sender, EventArgs e)
        {
            CustomerList control = new CustomerList();
            this.ShowControl(control, Content);
            this.Text = this.GetTitle(BSTitle.CustomerList);
        }
    }
}

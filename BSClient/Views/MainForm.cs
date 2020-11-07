using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.FluentDesignSystem;
using BSClient.Utility;
using BSClient.Base;
using BSClient.Views;

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

        private void ACE_User_Click(object sender, EventArgs e)
        {
            UserManageControl user = new UserManageControl();
            ClientCommon.ShowControl(user, Content);
            this.Text = " Blue Star Group - Quản lý người dùng";
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
            this.Text = " Blue Star Group - Danh mục Khách hàng";
        }
    }
}

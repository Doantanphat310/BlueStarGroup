using BSClient.Base;
using BSClient.Views;
using BSClient.Views.Reports;
using BSCommon.Constant;
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
            this.ShowControl(voucher, Content);
            this.Text = " Blue Star Group - Nhập chứng từ";
        }

        private void UserList_Button_Click(object sender, EventArgs e)
        {
            UserList user = new UserList();
            this.ShowControl(user, Content);
            this.SetTitle(BSTitle.UserList);
        }

        private void Company_Button_Click(object sender, EventArgs e)
        {
            CompanyList company = new CompanyList();
            this.ShowControl(company, Content);
            this.SetTitle("Nhập thông tin công ty");
        }

        private void Custommers_Button_Click(object sender, EventArgs e)
        {
            CustomerList control = new CustomerList();
            this.ShowControl(control, Content);
            this.SetTitle(BSTitle.CustomerList);
        }

        private void ItemList_Button_Click(object sender, EventArgs e)
        {
            ItemList control = new ItemList();
            this.ShowControl(control, Content);
            this.Text = this.GetTitle(BSTitle.ItemList);
        }

        private void AccountList_Button_Click(object sender, EventArgs e)
        {
            AccountList control = new AccountList();
            this.ShowControl(control, Content);
            this.SetTitle("Thông tin hệ thống tài khoản");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CompanyList company = new CompanyList();
            this.ShowControl(company, Content);
            this.SetTitle("Thông tin công ty đang được quản lý");
        }

        private void BangCanDoiSoPhatSinh_Item_Click(object sender, EventArgs e)
        {
            BangCanDoiSoPhatSinhTaiKhoanReport form = new BangCanDoiSoPhatSinhTaiKhoanReport();
            form.ShowDialog();
        }

        private void NhapSoDuaccordionControlElement_Click(object sender, EventArgs e)
        {
             InputBalance BalanceForm = new InputBalance();
             BalanceForm.Show();
        }

        private void WarehouseList_accordionControlElement_Click(object sender, EventArgs e)
        {
            WareHouseList WareHouseListForm = new WareHouseList();
            WareHouseListForm.Show();
        }
    }
}

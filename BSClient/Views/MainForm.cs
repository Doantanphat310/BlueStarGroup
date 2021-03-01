using BSClient.Base;
using BSClient.Views;
using BSClient.Views.Reports;
using BSCommon.Constant;
using System;
using System.Windows.Forms;

namespace BSClient
{
    public partial class MainForm : BaseForm
    {
        public MainForm()
        {
            InitializeComponent();
            Version ver = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            Version_TextBox.Caption =$"V{ver.ToString()}";
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
            BangCanDoiSoPhatSinhTaiKhoanReport form = new BangCanDoiSoPhatSinhTaiKhoanReport() { IsScreenShow = false };
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

        private void BaoCaoKeToanToanTap_MenuItem_Click(object sender, EventArgs e)
        {
            BaoCaoToanTap form = new BaoCaoToanTap();
            form.ShowDialog();
        }

        private void ChangeCompany_Button_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Login login = new Login(LoginMode.ChangeCompany);

            this.Hide();
            DialogResult result = login.ShowDialog();
            if (result == DialogResult.Yes)
            {
                MainForm_Load(null, null);
                this.Show();
            }
            else if (result == DialogResult.No)
            {
                Application.Exit();
            }
            else
            {
                // Nothing
                this.Show();
            }
        }
    }
}

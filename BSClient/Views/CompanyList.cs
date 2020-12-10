using BSClient.Utility;
using BSCommon.Constant;
using BSCommon.Models;
using BSServer.Controllers;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BSClient.Views
{
    public partial class CompanyList : XtraUserControl
    {
        public BindingList<Company> CompanyData { get; set; }

        public CompanyList()
        {
            InitializeComponent();

            LoadGrid();
        }

        private void LoadGrid()
        {
            InitGridView();

            SetupGridView();

            LoadDataGridView();
        }

        private void InitGridView()
        {
            Company_GridView.Columns.Clear();
            this.Company_GridView.AddColumn("CompanyID", "Mã Công ty", 100, false);
            this.Company_GridView.AddColumn("CompanyName", "Tên Công ty", 250, false);
            this.Company_GridView.AddColumn("CompanySName", "Tên viết tắt", 100, false);
            this.Company_GridView.AddColumn("Phone", "Điện thoại", 80, false);
            this.Company_GridView.AddColumn("Address", "Địa chỉ", 350, false);
            this.Company_GridView.AddColumn("MST", "MST", 100, false);
            this.Company_GridView.AddColumn("Fax", "FAX", 100, false);
            this.Company_GridView.AddColumn("Email", "Email", 100, false);
            this.Company_GridView.AddColumn("BankAccount", "Tài khoản NH", 100, false);
            this.Company_GridView.AddColumn("BankName", "Ngân hàng", 100, false);
            this.Company_GridView.AddColumn("BankBranch", "Chi nhánh NH", 100, false);
        }

        private void SetupGridView()
        {
            this.Company_GridView.SetupGridView(multiSelect: false, checkBoxSelectorColumnWidth: 0, showAutoFilterRow: false, newItemRow: NewItemRowPosition.None);
        }

        private void LoadDataGridView()
        {
            using (CompanyController controller = new CompanyController())
            {
                CompanyData = new BindingList<Company>(controller.GetCompanys());
                Company_GridControl.DataSource = CompanyData;
            }
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            Company company = Company_GridView.GetFocusedRow().CastTo<Company>();

            if (company == null)
            {
                MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000026);
                return;
            }

            using (CompanyController controller = new CompanyController())
            {
                try
                {
                    controller.DeleteCompany(company);
                    MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000027);

                    CompanyData = new BindingList<Company>(controller.GetCompanys());
                    Company_GridControl.DataSource = CompanyData;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000002);
                    return;
                }
            }
        }

        private void AddNew_Button_Click(object sender, EventArgs e)
        {
            CompanyNew form = new CompanyNew();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                LoadDataGridView();
            }
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            ExcuteUpdate();
        }

        private void Company_GridView_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {
                ExcuteUpdate();
            }
        }

        private void ExcuteUpdate()
        {
            Company company = Company_GridView.GetFocusedRow().CastTo<Company>();

            if (company == null)
            {
                MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000026);
                return;
            }

            CompanyNew form = new CompanyNew(company);

            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                LoadDataGridView();
            }
        }
    }
}

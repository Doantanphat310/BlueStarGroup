using BSClient.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSClient.Views
{
    public partial class InputBalance : Form
    {
        public InputBalance()
        {
            InitializeComponent();
        }

        #region Init gridview
        private void LoadVoucherGrid()
        {
            InitGridView();

            SetupGridView();

            LoadGridView();
        }

        private void InitGridView()
        {
            this.InputBalance_gridView.Columns.Clear();
            this.InputBalance_gridView.AddColumn("AccountID", "Mã tài khoản", 120, false);
            this.InputBalance_gridView.AddColumn("AccountDetailID", "Mã thống kê", 120, false);
            this.InputBalance_gridView.AddColumn("CustomerID", "Mã khách hàng", 120, false);
            this.InputBalance_gridView.AddSpinEditColumn("DebitAmount", "Nợ đầu kỳ", 180, false, "c2");
            this.InputBalance_gridView.AddSpinEditColumn("CreditAmount", "Có đầu kỳ", 180, false, "c2");
        }

        private void SetupGridView()
        {
            this.InputBalance_gridView.SetupGridView(columnAutoWidth: false, multiSelect: false, checkBoxSelectorColumnWidth: 30, showAutoFilterRow: true, newItemRow: DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None, editable: false);
        }

        private void LoadGridView()
        {
            //VoucherController controller = new VoucherController();
            //VoucherData = new BindingList<Voucher>(controller.GetVouchersCompany(GlobalVarient.CompanyIDChoice));
            //Voucher_gridControl.DataSource = VoucherData;
        }
        #endregion Init gridview

    }
}

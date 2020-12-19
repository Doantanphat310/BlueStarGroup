using BSClient.Utility;
using BSCommon.Constant;
using BSCommon.Models;
using BSCommon.Utility;
using BSServer.Controllers;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
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
            LoadVoucherGrid();
            LoadSearchEditlookup();
        }

        #region Init gridview
        private void LoadVoucherGrid()
        {
            InitGridView();

            SetupGridView();

            LoadGridView();
        }

        private void LoadSearchEditlookup()
        {

            initsearcheditlookupAccount();

            initsearcheditlookupAccountDetail();

            initsearcheditlookupCustomer();
        }


        private void InitGridView()
        {
            this.InputBalance_gridView.Columns.Clear();
            this.InputBalance_gridView.AddColumn("AccountID", "Mã tài khoản", 120, false);
            this.InputBalance_gridView.AddColumn("AccountDetailID", "Mã thống kê", 120, false);
            this.InputBalance_gridView.AddSearchLookupEditColumn("CustomerID", "Mã khách hàng", 120, materialDT, "CustomerID", "CustomerSName", isAllowEdit: false);
            this.InputBalance_gridView.AddSpinEditColumn("DebitAmount", "Nợ đầu kỳ", 180, false, "c2");
            this.InputBalance_gridView.AddSpinEditColumn("CreditAmount", "Có đầu kỳ", 180, false, "c2");
            this.InputBalance_gridView.AddColumn("BalanceID", "BalanceID", 120, false);
        }

        private void SetupGridView()
        {
            this.InputBalance_gridView.SetupGridView(columnAutoWidth: false, multiSelect: false, checkBoxSelectorColumnWidth: 30, showAutoFilterRow: true, newItemRow: DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None, editable: false);
        }

        public BindingList<Balance> BalanceData { get; set; }
        public BindingList<Balance> BalanceDataWareHouse { get; set; }
        public List<Balance> BalanceDataList { get; set; }

        public List<Balance> BalanceDelete { get; set; }

        private void LoadGridView()
        {
            BalanceController controller = new BalanceController();
            BalanceData = new BindingList<Balance>(controller.GetBalance(Balance_dateEdit.DateTime, CommonInfo.CompanyInfo.CompanyID));
            InputBalance_gridControl.DataSource = BalanceData;
            BalanceDataList = BalanceData.ToList();
        }
        #endregion Init gridview

        #region init search editlookup

        public static MaterialNVController MaterialTK = new MaterialNVController();
        List<MaterialTK> materialTK = MaterialTK.GetMaterialTK(CommonInfo.CompanyInfo.CompanyID);
        List<MaterialTK> materialAccountDetail = new List<MaterialTK>();

        public static MaterialNVController MaterialDT = new MaterialNVController();
        List<MaterialDT> materialDT = MaterialDT.GetMaterialDT(CommonInfo.CompanyInfo.CompanyID);

        public static ItemsController Items = new ItemsController();
        List<Items> items = Items.GetItems();

        void initsearcheditlookupAccount()
        {
            List<ColumnInfo> columns = new List<ColumnInfo>
            {
                new ColumnInfo("AccountID", "Tài khoản",140),
                new ColumnInfo("AccountDetailID", "Mã TK",80),
                new ColumnInfo("Name", "Tên",180 ),
            };
            materialAccountDetail = materialTK;
           this.InputBalanceAccount_searchLookUpEdit.SetupLookUpEdit("AccountID", "AccountID", materialTK, columns,nullText:"",enterChoiceFirstRow: true);
        }

        void initsearcheditlookupAccountDetail()
        {
            
            List<ColumnInfo> columns = new List<ColumnInfo>
            {
                new ColumnInfo("AccountID", "Tài khoản",140),
                new ColumnInfo("AccountDetailID", "Mã TK",80),
                new ColumnInfo("Name", "Tên",180 ),
            };
            this.InputBalanceAccountDetail_searchLookUpEdit.SetupLookUpEdit("AccountDetailID", "AccountDetailID", materialAccountDetail, columns, nullText: "", enterChoiceFirstRow: true);
        }

        void initsearcheditlookupCustomer()
        {

            List<ColumnInfo> columns = new List<ColumnInfo>
            {
                new ColumnInfo("CustomerID", "ID khách hàng",140),
                new ColumnInfo("CustomerSName", "Mã khách hàng",140),
                new ColumnInfo("CustomerName", "Tên khách hàng",300),
            };
            this.BalanceCustomer_searchLookUpEdit.SetupLookUpEdit("CustomerID", "CustomerSName", materialDT, columns, nullText: "", enterChoiceFirstRow: true);
        }

        void initsearcheditlookupItem()
        {

            List<ColumnInfo> columns = new List<ColumnInfo>
            {
                new ColumnInfo("ItemID", "ID Hàng hóa",140),
                new ColumnInfo("ItemSName", "Mã hàng hóa",140),
                new ColumnInfo("ItemName", "Tên hàng hóa",300),
            };
            this.BalanceCustomer_searchLookUpEdit.SetupLookUpEdit("ItemID", "ItemSName", Items, columns, nullText: "", enterChoiceFirstRow: true);
        }

        #endregion init search editlookup

        #region init Balance WareHouse
        public BindingList<Balance> BalanceWarehouseDetailData { get; set; }

        private void InitLoadBalanceWarehouse()
        {
            InitBalanceWareHouse_gridView();
            SetupBalanceWareHouse_gridView();
        }
        private void InitBalanceWareHouse_gridView()
        {
            //Mã hàng hóa
            //Số lượng
            //Đơn giá
            // Thành tiền
            // Đơn vị tính
            this.BalanceWareHouse_gridView.Columns.Clear();
            this.BalanceWareHouse_gridView.AddSearchLookupEditColumn("ItemID", "Hàng hóa", 80, items, "ItemID", "ItemSName", isAllowEdit: false, editValueChanged: BalanceWareHouseDetail_EditValueChanged);
            this.BalanceWareHouse_gridView.AddColumn("ItemUnit", "ĐVT", 35, isAllowEdit: false);
            this.BalanceWareHouse_gridView.AddSpinEditColumn("Quantity", "Số lượng", 60, false, "###,###,###.##");
            this.BalanceWareHouse_gridView.AddSpinEditColumn("Price", "Đơn giá", 120, false, "c2");
            this.BalanceWareHouse_gridView.AddSpinEditColumn("Amount", "Thành tiền", 110, false, "c2");
        }

        public void BalanceWareHouseDetail_EditValueChanged(object sender, EventArgs e)
        {
            var selectRow = ((SearchLookUpEdit)sender).Properties.View.GetFocusedRow().CastTo<Items>();
            BalanceWareHouse_gridView.SetFocusedRowCellValue("ItemUnit", selectRow.ItemUnit);
        }

        private void SetupBalanceWareHouse_gridView()
        {
            this.BalanceWareHouse_gridView.SetupGridView(columnAutoWidth: false, multiSelect: false, checkBoxSelectorColumnWidth: 30, showAutoFilterRow: true, newItemRow: DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None, editable: false);
        }

        private void Load_BalanceWareHouseDetail_GridView(List<Balance> data, string AccountID, string AccountDetailID)
        {
            BalanceWarehouseDetailData = new BindingList<Balance>(data.Where(b => b.AccountID == AccountID && b.AccountDetailID == AccountDetailID).ToList());
            BalanceWareHouse_gridControl.DataSource = BalanceWarehouseDetailData;
        }

        private void LoadBalanceWareHouseGridView(DateTime balanceDate, string companyID, string AccountID, string AccountDetailID, string CustomerID)
        {
            BalanceController controller = new BalanceController();
            BalanceDataWareHouse = new BindingList<Balance>(controller.GetBalance(balanceDate, companyID, AccountID, AccountDetailID, CustomerID));
            InputBalance_gridControl.DataSource = BalanceDataWareHouse;
            BalanceDataList = BalanceDataWareHouse.ToList();
        }

        #endregion init Balance WareHouse
        private void InputBalanceThem_simpleButton_Click(object sender, EventArgs e)
        {
            // kiểm tra loại tk kho
            int count = materialTK.Where(q => q.TK152_156 == true && q.AccountID == InputBalanceAccount_searchLookUpEdit.EditValue.ToString()).Select(x => x.AccountID).Count();
            if (count > 0) //Kho
            {
                BalanceWarehouse_panel.Enabled = true;
                Balance BalanceDataInsert = new Balance();
                BalanceDataInsert.AccountID = this.InputBalanceAccount_searchLookUpEdit.EditValue.ToString();
                BalanceDataInsert.AccountDetailID = this.InputBalanceAccountDetail_searchLookUpEdit.EditValue.ToString();
                BalanceDataInsert.BalanceDate = this.Balance_dateEdit.DateTime.Date;
                BalanceDataInsert.DebitAmount = decimal.Parse(this.BalanceDebitAmount_textEdit.EditValue.ToString());
                BalanceDataInsert.CreditAmount = decimal.Parse(this.BalanceCreditAmount_textEdit.EditValue.ToString());
                BalanceDataInsert.CustomerID = this.BalanceCustomer_searchLookUpEdit.EditValue.ToString();
                BalanceDataInsert.CompanyID = CommonInfo.CompanyInfo.CompanyID;
                BalanceDataInsert.Status = ModifyMode.Insert;
                BalanceDataInsert.ItemID = BalanceHangHoa_searchLookUpEdit.EditValue.ToString();
                BalanceDataInsert.BalanceQuatity = decimal.Parse(BalanceQuantity_textEdit.EditValue.ToString());
                BalanceDataInsert.BalancePrice = decimal.Parse(BalancePrice_textEdit.EditValue.ToString());
                List<Balance> ListBalance = new List<Balance>();
                ListBalance.Add(BalanceDataInsert);
                if (ListBalance?.Count > 0)
                {
                    BalanceController controller = new BalanceController();
                    if (controller.SaveBalance(ListBalance))
                    {
                        MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                        LoadBalanceWareHouseGridView(this.Balance_dateEdit.DateTime.Date,CommonInfo.CompanyInfo.CompanyID, this.InputBalanceAccount_searchLookUpEdit.EditValue.ToString(), this.InputBalanceAccountDetail_searchLookUpEdit.EditValue.ToString(), this.BalanceCustomer_searchLookUpEdit.EditValue.ToString());
                    }
                    else
                    {
                        MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                    }
                }
            }
            else // khong phai kho
            {
                BalanceWarehouse_panel.Enabled = false;
                Balance BalanceDataInsert = new Balance();
                BalanceDataInsert.AccountID = this.InputBalanceAccount_searchLookUpEdit.EditValue.ToString();
                BalanceDataInsert.AccountDetailID = this.InputBalanceAccountDetail_searchLookUpEdit.EditValue.ToString();
                BalanceDataInsert.BalanceDate = this.Balance_dateEdit.DateTime.Date;
                BalanceDataInsert.DebitAmount = decimal.Parse(this.BalanceDebitAmount_textEdit.EditValue.ToString());
                BalanceDataInsert.CreditAmount = decimal.Parse(this.BalanceCreditAmount_textEdit.EditValue.ToString());
                BalanceDataInsert.CustomerID = this.BalanceCustomer_searchLookUpEdit.EditValue.ToString();
                BalanceDataInsert.CompanyID = CommonInfo.CompanyInfo.CompanyID;
                BalanceDataInsert.Status = ModifyMode.Insert;
                List<Balance> ListBalance = new List<Balance>();
                ListBalance.Add(BalanceDataInsert);
                if (ListBalance?.Count > 0)
                {
                    BalanceController controller = new BalanceController();
                    if (controller.SaveBalance(ListBalance))
                    {
                        MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                        this.LoadGridView();
                    }
                    else
                    {
                        MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                    }
                }
            }
        }

        private void InputBalanceAccount_searchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            var selectRow = ((SearchLookUpEdit)sender).Properties.View.GetFocusedRow().CastTo<MaterialTK>();
            if (selectRow != null)
            {
                this.InputBalanceAccountDetail_searchLookUpEdit.EditValue = selectRow.AccountDetailID;
                materialAccountDetail = materialTK.Where(item => item.AccountID == InputBalanceAccount_searchLookUpEdit.EditValue.ToString()).ToList();
                this.InputBalanceAccountDetail_searchLookUpEdit.Properties.DataSource = materialAccountDetail;
                InputBalanceAccountDetail_searchLookUpEdit.Refresh();
                OnOffControl(selectRow.DuNo, selectRow.DuCo, selectRow.ThongKe);
                //TK lien quan kho
                int count = materialTK.Where(q => q.TK152_156 == true && q.AccountID == InputBalanceAccount_searchLookUpEdit.EditValue.ToString()).Select(x => x.AccountID).Count();
                if(count > 0)
                {
                    BalanceWarehouse_panel.Enabled = true;
                    Load_BalanceWareHouseDetail_GridView(BalanceDataList, InputBalanceAccount_searchLookUpEdit.EditValue.ToString(), selectRow.AccountDetailID);
                }
                else{
                    BalanceWarehouse_panel.Enabled = false;
                }
            }
        }

        void OnOffControl(Boolean DuNo, Boolean DuCo, Boolean ThongKe)
        {
            this.InputBalanceAccountDetail_searchLookUpEdit.Enabled = ThongKe;
            this.BalanceDebitAmount_textEdit.Enabled = DuNo;
            this.BalanceCreditAmount_textEdit.Enabled = DuCo;
        }

        private void InputBalanceXoa_simpleButton_Click(object sender, EventArgs e)
        {
            Balance BalanceDataDelete = new Balance();
            BalanceDataDelete.AccountID = this.InputBalanceAccount_searchLookUpEdit.EditValue.ToString();
            BalanceDataDelete.AccountDetailID = this.InputBalanceAccountDetail_searchLookUpEdit.EditValue.ToString();
            BalanceDataDelete.BalanceDate = this.Balance_dateEdit.DateTime;
            BalanceDataDelete.DebitAmount = decimal.Parse(this.BalanceDebitAmount_textEdit.EditValue.ToString());
            BalanceDataDelete.CreditAmount = decimal.Parse(this.BalanceCreditAmount_textEdit.EditValue.ToString());
            BalanceDataDelete.CustomerID = this.BalanceCustomer_searchLookUpEdit.EditValue.ToString();
            BalanceDataDelete.CompanyID = CommonInfo.CompanyInfo.CompanyID;
            BalanceDataDelete.BalanceID = this.BalanceID_textBox.Text;

            BalanceController controller = new BalanceController();
            if (controller.DeleteBalance(BalanceDataDelete))
            {
                MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000027);
                this.LoadGridView();
            }
            else
            {
                MessageBoxHelper.ShowInfoMessage("Xóa dữ liệu thất bại!");
            }
        }

        private void InputBalanceSua_simpleButton_Click(object sender, EventArgs e)
        {
            int count = materialTK.Where(q => q.TK152_156 == true && q.AccountID == InputBalanceAccount_searchLookUpEdit.EditValue.ToString()).Select(x => x.AccountID).Count();
            if(count > 0) //kho
            {
                Balance BalanceDataUpdate = new Balance();
                BalanceDataUpdate.AccountID = this.InputBalanceAccount_searchLookUpEdit.EditValue.ToString();
                BalanceDataUpdate.AccountDetailID = this.InputBalanceAccountDetail_searchLookUpEdit.EditValue.ToString();
                BalanceDataUpdate.BalanceDate = this.Balance_dateEdit.DateTime;
                BalanceDataUpdate.DebitAmount = decimal.Parse(this.BalanceDebitAmount_textEdit.EditValue.ToString());
                BalanceDataUpdate.CreditAmount = decimal.Parse(this.BalanceCreditAmount_textEdit.EditValue.ToString());
                BalanceDataUpdate.CustomerID = this.BalanceCustomer_searchLookUpEdit.EditValue.ToString();
                BalanceDataUpdate.CompanyID = CommonInfo.CompanyInfo.CompanyID;
                BalanceDataUpdate.BalanceID = this.BalanceID_textBox.Text;
                BalanceDataUpdate.ItemID = BalanceHangHoa_searchLookUpEdit.EditValue.ToString();
                BalanceDataUpdate.BalanceQuatity = decimal.Parse(BalanceQuantity_textEdit.EditValue.ToString());
                BalanceDataUpdate.BalancePrice = decimal.Parse(BalancePrice_textEdit.EditValue.ToString());

                BalanceController controller = new BalanceController();
                if (controller.UpdateBalance(BalanceDataUpdate))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    LoadBalanceWareHouseGridView(this.Balance_dateEdit.DateTime.Date, CommonInfo.CompanyInfo.CompanyID, this.InputBalanceAccount_searchLookUpEdit.EditValue.ToString(), this.InputBalanceAccountDetail_searchLookUpEdit.EditValue.ToString(), this.BalanceCustomer_searchLookUpEdit.EditValue.ToString());
                }
                else
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }
            else
            {
                Balance BalanceDataUpdate = new Balance();
                BalanceDataUpdate.AccountID = this.InputBalanceAccount_searchLookUpEdit.EditValue.ToString();
                BalanceDataUpdate.AccountDetailID = this.InputBalanceAccountDetail_searchLookUpEdit.EditValue.ToString();
                BalanceDataUpdate.BalanceDate = this.Balance_dateEdit.DateTime;
                BalanceDataUpdate.DebitAmount = decimal.Parse(this.BalanceDebitAmount_textEdit.EditValue.ToString());
                BalanceDataUpdate.CreditAmount = decimal.Parse(this.BalanceCreditAmount_textEdit.EditValue.ToString());
                BalanceDataUpdate.CustomerID = this.BalanceCustomer_searchLookUpEdit.EditValue.ToString();
                BalanceDataUpdate.CompanyID = CommonInfo.CompanyInfo.CompanyID;
                BalanceDataUpdate.BalanceID = this.BalanceID_textBox.Text;
                BalanceController controller = new BalanceController();
                if (controller.UpdateBalance(BalanceDataUpdate))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    this.LoadGridView();
                }
                else
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }
        }

        private void InputBalance_gridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            Balance balance = InputBalance_gridView.GetRow(e.RowHandle).CastTo<Balance>();
            this.InputBalanceAccount_searchLookUpEdit.EditValue = balance.AccountID;
            this.InputBalanceAccountDetail_searchLookUpEdit.EditValue = balance.AccountDetailID;
            this.Balance_dateEdit.DateTime = balance.BalanceDate;
            this.BalanceDebitAmount_textEdit.EditValue = balance.DebitAmount;
            this.BalanceCreditAmount_textEdit.EditValue = balance.CreditAmount;
            this.BalanceCustomer_searchLookUpEdit.EditValue = balance.CustomerID;
            this.BalanceID_textBox.Text = balance.BalanceID;
            List<MaterialTK> onoff = new List<MaterialTK>();
            onoff = materialTK.Where(item => item.AccountID == balance.AccountID).ToList();
            if (onoff.Count > 0)
            {
                OnOffControl(onoff[0].DuNo, onoff[0].DuCo, onoff[0].ThongKe);
            }
        }

        private void BalanceGetDate_simpleButton_Click(object sender, EventArgs e)
        {
            this.LoadGridView();
        }
        
    }
}

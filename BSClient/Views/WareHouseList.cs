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
    public partial class WareHouseList : Form
    {
        public WareHouseList()
        {
            InitializeComponent();
            initsearcheditlookupDebitAccount();
            initsearcheditlookupDebitAccountDetail();
            initsearcheditlookupCreditAccount();
            initsearcheditlookupCreditAccountDetail();
            initsearcheditlookupManageCode();
            LoadWareHouseListGrid();
        }

        #region Init gridview
        public BindingList<WarehouseList> WareHouseListData { get; set; }
        public List<WarehouseList> WareHouseListDataList { get; set; }
        public List<WarehouseList> WareHouseListDelete { get; set; }
        private void LoadWareHouseListGrid()
        {
            InitGridView();

            SetupGridView();

            LoadGridView();
        }
        
        private void InitGridView()
        {
            this.WarehouseList_gridView.Columns.Clear();
            this.WarehouseList_gridView.AddColumn("WarehouseListID", "Mã/Code", 120, false);
            this.WarehouseList_gridView.AddColumn("WarehouseListName", "Tên/Name", 380, false);
        }

        private void SetupGridView()
        {
            this.WarehouseList_gridView.SetupGridView(columnAutoWidth: false, multiSelect: false, checkBoxSelectorColumnWidth: 30, showAutoFilterRow: true, newItemRow: DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None, editable: false);
        }

        private void LoadGridView()
        {
            WareHouseListController controller = new WareHouseListController();
            WareHouseListData = new BindingList<WarehouseList>(controller.GetWareHouseListSelect(CommonInfo.CompanyInfo.CompanyID));
            WarehouseList__gridControl.DataSource = WareHouseListData;
            WareHouseListDataList = WareHouseListData.ToList();
        }
        #endregion Init gridview



        #region init search editlookup

        public static MaterialNVController MaterialTK = new MaterialNVController();
        List<MaterialTK> materialTK = MaterialTK.GetMaterialTK(CommonInfo.CompanyInfo.CompanyID);
        List<MaterialTK> materialDebitAccountDetail = new List<MaterialTK>();
        List<MaterialTK> materialCreditAccountDetail = new List<MaterialTK>();

        public static MaterialNVController MaterialDT = new MaterialNVController();
        List<MaterialDT> materialDT = MaterialDT.GetMaterialDT(CommonInfo.CompanyInfo.CompanyID);

        public static ItemsController Items = new ItemsController();
        List<Items> items = Items.GetItems();

        void initsearcheditlookupDebitAccount()
        {
            List<ColumnInfo> columns = new List<ColumnInfo>
            {
                new ColumnInfo("AccountID", "Tài khoản",140),
                new ColumnInfo("AccountDetailID", "Mã TK",80),
                new ColumnInfo("Name", "Tên",180 ),
            };
            materialDebitAccountDetail = materialTK;
            materialCreditAccountDetail = materialTK;
            this.WarehouseListDebitAccount_searchLookUpEdit.SetupLookUpEdit("AccountID", "AccountID", materialTK, columns, nullText: "", enterChoiceFirstRow: true);
        }

        void initsearcheditlookupDebitAccountDetail()
        {

            List<ColumnInfo> columns = new List<ColumnInfo>
            {
                new ColumnInfo("AccountID", "Tài khoản",140),
                new ColumnInfo("AccountDetailID", "Mã TK",80),
                new ColumnInfo("Name", "Tên",180 ),
            };
            this.WarehouseListDebitAccountDetail_searchLookUpEdit.SetupLookUpEdit("AccountDetailID", "AccountDetailID", materialDebitAccountDetail, columns, nullText: "", enterChoiceFirstRow: true);
        }

        void initsearcheditlookupCreditAccount()
        {
            List<ColumnInfo> columns = new List<ColumnInfo>
            {
                new ColumnInfo("AccountID", "Tài khoản",140),
                new ColumnInfo("AccountDetailID", "Mã TK",80),
                new ColumnInfo("Name", "Tên",180 ),
            };
            materialDebitAccountDetail = materialTK;
            materialCreditAccountDetail = materialTK;
            this.WarehouseListCreditAccount_searchLookUpEdit.SetupLookUpEdit("AccountID", "AccountID", materialTK, columns, nullText: "", enterChoiceFirstRow: true);
        }

        void initsearcheditlookupCreditAccountDetail()
        {

            List<ColumnInfo> columns = new List<ColumnInfo>
            {
                new ColumnInfo("AccountID", "Tài khoản",140),
                new ColumnInfo("AccountDetailID", "Mã TK",80),
                new ColumnInfo("Name", "Tên",180 ),
            };
            this.WarehouseListCreditAccountDetail_searchLookUpEdit.SetupLookUpEdit("AccountDetailID", "AccountDetailID", materialCreditAccountDetail, columns, nullText: "", enterChoiceFirstRow: true);
        }
        void initsearcheditlookupManageCode()
        {
            List<ManageCode> ManageCodes = new List<ManageCode>
            {
                new ManageCode { Code = "1", Name = "Kho"},
                new ManageCode { Code = "4", Name = "Kho"},
                new ManageCode { Code = "2", Name = "CP chờ phân bổ"},
                new ManageCode { Code = "3", Name = "TSCĐ"},
                new ManageCode { Code = "35", Name = "Chi tiết bán hàng"}
            };

            List<ColumnInfo> columns = new List<ColumnInfo>
            {
                new ColumnInfo("Code", "Mã",80),
                new ColumnInfo("Name", "Tên",140),
            };

            BindingList<ManageCode> manageCodes =  new BindingList<ManageCode>(ManageCodes);
          this.WarehouseListManageCode_searchLookUpEdit.SetupLookUpEdit("Code", "Code", manageCodes, columns, nullText: "", enterChoiceFirstRow: true);
        }


        #endregion init search editlookup

        private void WarehouseListDebitAccount_searchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            var selectRow = ((SearchLookUpEdit)sender).Properties.View.GetFocusedRow().CastTo<MaterialTK>();
            if (selectRow != null)
            {
                this.WarehouseListDebitAccountDetail_searchLookUpEdit.EditValue = selectRow.AccountDetailID;
                materialDebitAccountDetail = materialTK.Where(item => item.AccountID == WarehouseListDebitAccount_searchLookUpEdit.EditValue.ToString()).ToList();
                this.WarehouseListDebitAccountDetail_searchLookUpEdit.Properties.DataSource = materialDebitAccountDetail;
                WarehouseListDebitAccountDetail_searchLookUpEdit.Refresh();
            }
        }

        private void WarehouseListCreditAccount_searchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            var selectRow = ((SearchLookUpEdit)sender).Properties.View.GetFocusedRow().CastTo<MaterialTK>();
            if (selectRow != null)
            {
                this.WarehouseListCreditAccountDetail_searchLookUpEdit.EditValue = selectRow.AccountDetailID;
                materialCreditAccountDetail = materialTK.Where(item => item.AccountID == WarehouseListCreditAccount_searchLookUpEdit.EditValue.ToString()).ToList();
                this.WarehouseListCreditAccountDetail_searchLookUpEdit.Properties.DataSource = materialCreditAccountDetail;
                WarehouseListCreditAccountDetail_searchLookUpEdit.Refresh();
            }
        }

        private void WarehouseListThem_simpleButton_Click(object sender, EventArgs e)
        {
            WarehouseList WarehouseListDataInsert = new WarehouseList();
            WarehouseListDataInsert.WarehouseListName = this.WarehouseListName_textEdit.EditValue.ToString().Trim();
            WarehouseListDataInsert.WarehouseListDebitAccountID = this.WarehouseListDebitAccount_searchLookUpEdit.EditValue?.ToString() ?? "";
            WarehouseListDataInsert.WarehouseListDebitAccountDetailID = this.WarehouseListDebitAccountDetail_searchLookUpEdit.EditValue?.ToString() ?? "";
            WarehouseListDataInsert.WarehouseListCreditAccountID = this.WarehouseListCreditAccount_searchLookUpEdit.EditValue?.ToString() ?? "";
            WarehouseListDataInsert.WarehouseListCreditAccountDetailID = this.WarehouseListCreditAccountDetail_searchLookUpEdit.EditValue?.ToString() ?? "";
            WarehouseListDataInsert.WarehouseListManageCode = this.WarehouseListManageCode_searchLookUpEdit.EditValue?.ToString() ?? "";
            WarehouseListDataInsert.WarehouseListTitle = this.WarehouseListTitle_textEdit.EditValue?.ToString() ?? "";
            WarehouseListDataInsert.WarehouseListAddress = this.WarehouseListAdd_textEdit.EditValue?.ToString() ?? "";
            WarehouseListDataInsert.WarehouseListNote = this.WarehouseListNote_richTextBoxVoucherContent.Text?.ToString() ?? "";
            WarehouseListDataInsert.CompanyID = CommonInfo.CompanyInfo.CompanyID;
            WarehouseListDataInsert.Status = ModifyMode.Insert;
            List<WarehouseList> ListWarehouseList = new List<WarehouseList>();
            ListWarehouseList.Add(WarehouseListDataInsert);
            if (ListWarehouseList?.Count > 0)
            {
                WareHouseListController controller = new WareHouseListController();
                if (controller.SaveWareHouseList(ListWarehouseList))
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

        private void WarehouseListSua_simpleButton_Click(object sender, EventArgs e)
        {
            WarehouseList WarehouseListDataUpdate = new WarehouseList();
            WarehouseListDataUpdate.WarehouseListID = this.WarehouseListCode_textEdit.EditValue.ToString();
            WarehouseListDataUpdate.WarehouseListName = this.WarehouseListName_textEdit.EditValue.ToString().Trim();
            WarehouseListDataUpdate.WarehouseListDebitAccountID = this.WarehouseListDebitAccount_searchLookUpEdit.EditValue?.ToString() ?? "";
            WarehouseListDataUpdate.WarehouseListDebitAccountDetailID = this.WarehouseListDebitAccountDetail_searchLookUpEdit.EditValue?.ToString() ?? "";
            WarehouseListDataUpdate.WarehouseListCreditAccountID = this.WarehouseListCreditAccount_searchLookUpEdit.EditValue?.ToString() ?? "";
            WarehouseListDataUpdate.WarehouseListCreditAccountDetailID = this.WarehouseListCreditAccountDetail_searchLookUpEdit.EditValue?.ToString() ?? "";
            WarehouseListDataUpdate.WarehouseListManageCode = this.WarehouseListManageCode_searchLookUpEdit.EditValue?.ToString() ?? "";
            WarehouseListDataUpdate.WarehouseListTitle = this.WarehouseListTitle_textEdit.EditValue?.ToString() ?? "";
            WarehouseListDataUpdate.WarehouseListAddress = this.WarehouseListAdd_textEdit.EditValue?.ToString() ?? "";
            WarehouseListDataUpdate.WarehouseListNote = this.WarehouseListNote_richTextBoxVoucherContent.Text?.ToString() ?? "";
            WarehouseListDataUpdate.CompanyID = CommonInfo.CompanyInfo.CompanyID;
                WareHouseListController controller = new WareHouseListController();
                if (controller.UpdateWareHouseList(WarehouseListDataUpdate))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    this.LoadGridView();
                }
                else
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
        }

        private void WarehouseListXoa_simpleButton_Click(object sender, EventArgs e)
        {
            WarehouseList  WareHouseListDataDelete = new WarehouseList();
            WareHouseListDataDelete.WarehouseListID = this.WarehouseListCode_textEdit.EditValue.ToString();
            WareHouseListController controller = new WareHouseListController();
            if (controller.DeleteWareHouseList(WareHouseListDataDelete))
            {
                MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000027);
                this.LoadGridView();
            }
            else
            {
                MessageBoxHelper.ShowInfoMessage("Xóa dữ liệu thất bại!");
            }
        }

        private void WarehouseList_gridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                WarehouseList warehouseList = this.WarehouseList_gridView.GetRow(e.RowHandle).CastTo<WarehouseList>();

                this.WarehouseListCode_textEdit.EditValue = warehouseList.WarehouseListID;
                this.WarehouseListName_textEdit.Text = warehouseList.WarehouseListName;
                this.WarehouseListDebitAccount_searchLookUpEdit.EditValue = warehouseList.WarehouseListDebitAccountID;
                this.WarehouseListDebitAccountDetail_searchLookUpEdit.EditValue = warehouseList.WarehouseListDebitAccountDetailID;
                this.WarehouseListCreditAccount_searchLookUpEdit.EditValue = warehouseList.WarehouseListCreditAccountID;
                this.WarehouseListCreditAccountDetail_searchLookUpEdit.EditValue = warehouseList.WarehouseListCreditAccountDetailID;
                this.WarehouseListManageCode_searchLookUpEdit.EditValue = warehouseList.WarehouseListManageCode??"";
                this.WarehouseListNote_richTextBoxVoucherContent.Text = warehouseList.WarehouseListNote??"";
                this.WarehouseListAdd_textEdit.Text = warehouseList.WarehouseListAddress??"";

               // this.WarehouseListDebitAccountDetail_searchLookUpEdit.EditValue = selectRow.AccountDetailID;
                materialDebitAccountDetail = materialTK.Where(item => item.AccountID == WarehouseListDebitAccount_searchLookUpEdit.EditValue.ToString()).ToList();
                this.WarehouseListDebitAccountDetail_searchLookUpEdit.Properties.DataSource = materialDebitAccountDetail;
                WarehouseListDebitAccountDetail_searchLookUpEdit.Refresh();

                materialCreditAccountDetail = materialTK.Where(item => item.AccountID == WarehouseListCreditAccount_searchLookUpEdit.EditValue.ToString()).ToList();
                this.WarehouseListCreditAccountDetail_searchLookUpEdit.Properties.DataSource = materialCreditAccountDetail;
                WarehouseListCreditAccountDetail_searchLookUpEdit.Refresh();

            }
            catch
            {

            }
        }
    }

    public class ManageCode
    {
        // Auto-Initialized properties  
        public string Code { get; set; }
        public string Name { get; set; }
    }
}

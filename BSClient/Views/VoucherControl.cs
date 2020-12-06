using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using BSServer.Controllers;
using BSCommon.Models;
using BSClient.Utility;
using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System.Drawing;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Win;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraGrid;
using System.Linq;
using BSCommon.Constant;
using BSCommon.Utility;
using DevExpress.Utils.Extensions;
using DevExpress.XtraGrid.Columns;
using System.Collections;
using System.Data;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace BSClient
{
    public partial class VoucherControl : DevExpress.XtraEditors.XtraUserControl
    {
        #region Final
        public BindingList<Voucher> VoucherData { get; set; }
        public BindingList<VoucherDetail> VoucherDetailData { get; set; }
        public BindingList<Invoice> InvoiceData { get; set; }
        //  public BindingList<WareHouse> WarehouseData { get; set; }
        public BindingList<WareHouse> InvoiceWarehouseData { get; set; }
        public BindingList<WareHouseDetail> InvoiceWarehouseDetailData { get; set; }

        public BindingList<WareHouse> WarehouseData { get; set; }
        public BindingList<WareHouseDetail> WarehouseDetailData { get; set; }

        public BindingList<WareHouseDetail> InvoiceWarehouseDetailDataBackup { get; set; }

        public BindingList<Depreciation> InvoiceDepreciationData { get; set; }
        public BindingList<DepreciationDetail> InvoiceDepreciationDetailData { get; set; }

        public BindingList<Depreciation> DepreciationData { get; set; }
        public BindingList<DepreciationDetail> DepreciationDetailData { get; set; }

        public List<Voucher> VoucherDelete { get; set; }
        public List<VoucherDetail> VoucherDetailDelete { get; set; }
        public List<Invoice> InvoiceDelete { get; set; }
        // public List<WareHouse> WareHouseDelete { get; set; }
        public List<WareHouse> InvoiceWareHouseDelete { get; set; }
        public List<WareHouseDetail> InvoiceWareHouseDetailDelete { get; set; }

        public List<WareHouse> WareHouseDelete { get; set; }
        public List<WareHouseDetail> WareHouseDetailDelete { get; set; }

        public List<Depreciation> InvoiceDepreciationDelete { get; set; }
        public List<DepreciationDetail> InvoiceDepreciationDetailDelete { get; set; }


        public List<Depreciation> DepreciationDelete { get; set; }
        public List<DepreciationDetail> DepreciationDetailDelete { get; set; }

        public static MaterialNVController MaterialGL = new MaterialNVController();
        List<MaterialGL> materialGL = MaterialGL.GetMaterialGL(GlobalVarient.CompanyIDChoice);
        public static MaterialNVController MaterialNV = new MaterialNVController();
        List<MaterialNV> materialNV = MaterialNV.GetMaterialNV();
        public static MaterialNVController MaterialTK = new MaterialNVController();
        List<MaterialTK> materialTK = MaterialTK.GetMaterialTK();
        public static MaterialNVController MaterialDT = new MaterialNVController();
        List<MaterialDT> materialDT = MaterialDT.GetMaterialDT(GlobalVarient.CompanyIDChoice);
        public static MaterialNVController MaterialCustomerInvoice = new MaterialNVController();
        List<MaterialCustomerInvoice> materialCustomerInvoice = MaterialCustomerInvoice.GetMaterialCustomerInvoice(GlobalVarient.CompanyIDChoice);
        public static MaterialNVController MaterialInvoiceType = new MaterialNVController();
        List<MaterialInvoiceType> materialInvoiceType = MaterialInvoiceType.GetMaterialInvoiceType();
        public static MaterialNVController MaterialWareHouseType = new MaterialNVController();
        List<MaterialWareHouseType> materialWareHouseType = MaterialWareHouseType.GetMaterialWareHouseType();
        public static ItemsController Items = new ItemsController();
        List<Items> items = Items.GetItems();
        #endregion Final
        public VoucherControl()
        {
            InitializeComponent();
            InitComboBox();
            LoadGrid();
            VoucherDetailDelete = new List<VoucherDetail>();
        }

        private void LoadGrid()
        {
            LoadVoucherGrid();

            LoadVoucherDetailGrid();
        }

        private void LoadVoucherGrid()
        {
            InitGridView();

            SetupGridView();

            LoadGridView();
        }

        private void LoadVoucherDetailGrid()
        {
            InitVoucherDetailGridView();

            SetupVoucherDetailGridView();

            LoadVoucherDetailGridView("00000000000000000LoadDefaulttoadnew");
        }

        private void InitComboBox()
        {
            VouchersTypeController voucherstype = new VouchersTypeController();
            List<VouchersType> vouchersT = voucherstype.GetVouchersTypeInfo("1");

            VoucherTypeXemChungTU_searchLookUpEdit.Properties.DataSource = vouchersT;
            VoucherTypeXemChungTU_searchLookUpEdit.Properties.NullText = "Chọn loại chứng từ";
            VoucherTypeXemChungTU_searchLookUpEdit.Properties.ValueMember = "VouchersTypeID";
            VoucherTypeXemChungTU_searchLookUpEdit.Properties.DisplayMember = "VouchersTypeName";

            VoucherTypeDK_searchLookUpEdit.Properties.DataSource = vouchersT;
            VoucherTypeDK_searchLookUpEdit.Properties.NullText = "Chọn loại chứng từ";
            VoucherTypeDK_searchLookUpEdit.Properties.ValueMember = "VouchersTypeID";
            VoucherTypeDK_searchLookUpEdit.Properties.DisplayMember = "VouchersTypeName";
        }

        #region init design
        private void InitGridView()
        {
            this.Voucher_gridView.Columns.Clear();
            this.Voucher_gridView.AddColumn("VouchersTypeID", "Loại", 30, false);
            this.Voucher_gridView.AddColumn("VouchersID", "CT ID", 110, false);
            this.Voucher_gridView.AddColumn("Date", "Ngày", 70, false);
            this.Voucher_gridView.AddSpinEditColumn("Amount", "Tiền", 120, false, "c2");
            this.Voucher_gridView.AddColumn("Description", "Nội dung", 180, false);
            this.Voucher_gridView.AddColumn("CreateUser", "Người tạo", 100, false);
        }

        private void SetupGridView()
        {
            this.Voucher_gridView.SetupGridView(multiSelect: true, checkBoxSelectorColumnWidth: 30);
            this.Voucher_gridView.SetupGridView(columnAutoWidth: false);
            this.Voucher_gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            this.Voucher_gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
        }

        private void LoadGridView()
        {
            VoucherController controller = new VoucherController();
            VoucherData = new BindingList<Voucher>(controller.GetVouchersCompany(GlobalVarient.CompanyIDChoice));
            Voucher_gridControl.DataSource = VoucherData;
        }

        private void InitVoucherDetailGridView()
        {
            this.VoucherDetail_gridView.Columns.Clear();
   
            this.VoucherDetail_gridView.AddSearchLookupEditColumn("NV", "NV", 40, materialNV, "NVSummary", "NVName", isAllowEdit: true);
            this.VoucherDetail_gridView.AddSearchLookupEditColumn("GeneralLedgerID", "Sổ cái", 140, materialGL, "GeneralLedgerID", "GeneralLedgerName", isAllowEdit: true, editValueChanged: GeneralLedger_EditValueChanged);
            this.VoucherDetail_gridView.AddSearchLookupEditColumn("AccountID", "Tài khoản", 60, materialTK, "AccountID", "AccountID", isAllowEdit: true);
            this.VoucherDetail_gridView.AddSearchLookupEditColumn("CustomerID", "Mã KH", 60, materialDT, "CustomerID", "CustomerSName", isAllowEdit: true);
            this.VoucherDetail_gridView.AddSpinEditColumn("Amount", "Tiền", 120, true, "C2");
            this.VoucherDetail_gridView.AddColumn("Descriptions", "Họ tên/Địa chỉ/CTKT", 200, true);
            this.VoucherDetail_gridView.AddColumn("VouchersDetailID", "DKID", 120, false);
        }

        public void GeneralLedger_EditValueChanged(object sender, EventArgs e)
        {
            var selectRow = ((SearchLookUpEdit)sender).Properties.View.GetFocusedRow().CastTo<MaterialGL>();
            VoucherDetail_gridView.SetFocusedRowCellValue("AccountID", selectRow.AccountID);
        }

        private void SetupVoucherDetailGridView()
        {
            this.VoucherDetail_gridView.SetupGridView(multiSelect: true, checkBoxSelectorColumnWidth: 30);
            this.VoucherDetail_gridView.SetupGridView(columnAutoWidth: false);
            this.VoucherDetail_gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            this.VoucherDetail_gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
        }

        private void LoadVoucherDetailGridView(string voucherID)
        {
            tabNavigationPageLKKho.PageVisible = false;
            tabNavigationPageLKVAT.PageVisible = false;
            VoucherDetailController controller = new VoucherDetailController();
            GlobalVarient.voucherDetailChoice = new List<VoucherDetail>();
            GlobalVarient.voucherDetailChoice = controller.GetVouchersDetailSelectVoucherID(voucherID, GlobalVarient.CompanyIDChoice);
            //  VoucherDetailData = new BindingList<VoucherDetail>(controller.GetVouchersDetailSelectVoucherID(voucherID, GlobalVarient.CompanyIDChoice));
            VoucherDetailData = null;
            VoucherDetailData = new BindingList<VoucherDetail>(GlobalVarient.voucherDetailChoice);
            VoucherDetail_gridControl.DataSource = VoucherDetailData;
            VoucherDetailDelete = new List<VoucherDetail>();
        }

        #endregion init design



        private void simpleButtonLoadVoucher_Click(object sender, EventArgs e)
        {
            string vouchertype = "";
            #region check value parameter
            if (dateEditBDKT.EditValue == null || dateEditNgayKT.EditValue == null)
            {
                MessageBoxHelper.ShowErrorMessage("Vui lòng chọn ngày cần tìm dữ liệu!");
                return;
            }
            if (VoucherTypeXemChungTU_searchLookUpEdit.EditValue == null)
            {
                //MessageBoxHelper.ShowErrorMessage("Vui lòng chọn loại chứng từ cần xem!");
                //return;
                vouchertype = "VOU000";

            }
            else
            {
                vouchertype = VoucherTypeXemChungTU_searchLookUpEdit.EditValue.ToString();
            }



            #endregion check value parameter
            #region search voucher
            VoucherController controller = new VoucherController();
            VoucherData = new BindingList<Voucher>(controller.GetVouchersCondition(GlobalVarient.CompanyIDChoice, (DateTime)dateEditBDKT.EditValue, (DateTime)dateEditNgayKT.EditValue, vouchertype));
            Voucher_gridControl.DataSource = VoucherData;
            #endregion search voucher

            LoadVoucherDetailGridView("00000000000000000LoadDefaulttoadnew");

        }

        #region design Repository for VoucherDetail
        RepositoryItemSearchLookUpEdit riLookup = new RepositoryItemSearchLookUpEdit();
        RepositoryItemSearchLookUpEdit rsItemlookup = new RepositoryItemSearchLookUpEdit();
        RepositoryItemSearchLookUpEdit rDTLookup = new RepositoryItemSearchLookUpEdit();
        RepositoryItemSearchLookUpEdit rGLLookup = new RepositoryItemSearchLookUpEdit();


        private void riLookup_Popup(object sender, EventArgs e)
        {
            var edit = sender as SearchLookUpEdit;
            var popupForm = edit.GetPopupEditForm();
            popupForm.KeyPreview = true;
            popupForm.KeyUp -= popupForm_KeyUp;
            popupForm.KeyUp += popupForm_KeyUp;
        }

        private void rsItemlookup_Popup(object sender, EventArgs e)
        {
            var edit = sender as SearchLookUpEdit;
            var popupForm = edit.GetPopupEditForm();
            popupForm.KeyPreview = true;
            popupForm.KeyUp -= popupForm_KeyUp;
            popupForm.KeyUp += popupForm_KeyUp;
        }

        private void rDTLookup_Popup(object sender, EventArgs e)
        {
            var edit = sender as SearchLookUpEdit;
            var popupForm = edit.GetPopupEditForm();
            popupForm.KeyPreview = true;
            popupForm.KeyUp -= popupForm_KeyUp;
            popupForm.KeyUp += popupForm_KeyUp;
        }

        private void rGLLookup_Popup(object sender, EventArgs e)
        {
            var edit = sender as SearchLookUpEdit;
            var popupForm = edit.GetPopupEditForm();
            popupForm.KeyPreview = true;
            popupForm.KeyUp -= popupForm_KeyUp;
            popupForm.KeyUp += popupForm_KeyUp;
        }

        void popupForm_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            PopupSearchLookUpEditForm popupForm = sender as PopupSearchLookUpEditForm;
            if (e.KeyData == System.Windows.Forms.Keys.Enter)
            {
                GridView view = popupForm.OwnerEdit.Properties.View;
                view.FocusedRowHandle = 0;
                popupForm.OwnerEdit.ClosePopup();
            }
        }




        private void rsItemlookup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rsItemlookup.PopupView.ShowFindPanel();
            }
        }
        #endregion design Repository for VoucherDetail



        static string NullToString(object Value)
        {
            return Value == null ? "" : Value.ToString();
        }


        //private void gridViewDinhKhoan_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        //{

        //}


        List<int> RowHandleList = new List<int>();

        private void gridViewDinhKhoan_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (RowHandleList.Contains(e.RowHandle))
                e.Appearance.BackColor = Color.Red;
            else
            {
                e.Appearance.BackColor = Color.White;
            }
        }

        private void simpleButtonLoadVoucher_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void simpleButtonLoadVoucher_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void searchLookUpEditVoucherTypeXemChungTU_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                VoucherTypeXemChungTU_searchLookUpEdit.ShowPopup();
            }
        }

        private void searchLookUpEditChungTuTypeDK_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                VoucherTypeDK_searchLookUpEdit.ShowPopup();
            }
        }

        private void searchLookUpEditVoucherTypeXemChungTU_Popup(object sender, EventArgs e)
        {
            PopupSearchLookUpEditForm form = (sender as IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            form.KeyPreview = true;
            form.KeyDown -= OnFormKeyDown;
            form.KeyDown += OnFormKeyDown;

        }
        private void searchLookUpEditChungTuTypeDK_Popup(object sender, EventArgs e)
        {
            PopupSearchLookUpEditForm form = (sender as IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            form.KeyPreview = true;
            form.KeyDown -= OnFormKeyDown;
            form.KeyDown += OnFormKeyDown;
        }

        void OnFormKeyDown(object sender, KeyEventArgs e)
        {
            PopupSearchLookUpEditForm form = sender as PopupSearchLookUpEditForm;
            if (e.KeyCode == Keys.Enter)
            {
                GridView view = form.OwnerEdit.Properties.View;
                if (view.FocusedRowHandle > 0)
                {
                    form.OwnerEdit.ClosePopup();
                }
                else
                {
                    view.FocusedRowHandle = 0;
                    form.OwnerEdit.ClosePopup();
                }
            }
        }

        private void simpleButtonNewSave_Click(object sender, EventArgs e)
        {
            if (dateEditNgayNhapChungTu.EditValue == null)
            {
                MessageBoxHelper.ShowErrorMessage("Ngày nhập chứng từ không được để trống!");
                return;
            }
            if (VoucherTypeDK_searchLookUpEdit.EditValue == null)
            {
                MessageBoxHelper.ShowErrorMessage("Vui lòng chọn loại chứng từ!");
                return;
            }
            if (!checkBoxThemDuLieu.Checked)
            {
                MessageBoxHelper.ShowErrorMessage("Vui lòng tick chọn thêm chứng từ trước khi lưu mới!");
                return;
            }
            decimal Debit = 0;
            decimal credit = 0;
            var result = VoucherDetailData.GroupBy(o => o.NV)
                    .Select(g => new { nv = g.Key, total = g.Sum(i => i.Amount) });
            foreach (var group in result)
            {
                Console.WriteLine("Membername = {0} Totalcost={1}", group.nv, group.total);
                if (group.nv == "N")
                {
                    Debit = group.total;
                }
                if (group.nv == "C")
                {
                    credit = group.total;
                }
            }
            if (Debit != credit && VoucherTypeDK_searchLookUpEdit.EditValue.ToString() != "DK")
            {
                MessageBoxHelper.ShowErrorMessage("Tổng tiền nợ có phải bằng nhau!\n" + "N: " + Debit.ToString() + "\nC: " + credit.ToString());
                return;
            }

            #region set value to Insert Voucher
            VoucherController voucherController = new VoucherController();
            GlobalVarient.VoucherID++;
            Voucher voucher = new Voucher();
            voucher.Amount = Debit;
            voucher.Description = richTextBoxVoucherContent.Text.ToString().Trim();
            voucher.VouchersTypeID = VoucherTypeDK_searchLookUpEdit.EditValue.ToString();
            voucher.Date = (DateTime)dateEditNgayNhapChungTu.EditValue;
            voucher.CompanyID = GlobalVarient.CompanyIDChoice;
            voucher.Status = ModifyMode.Insert;
            #endregion set value to Insert Voucher
            VoucherDetailController voucherDetailController = new VoucherDetailController();
            for (int i = 0; i < VoucherDetailData.Count; i++)
            {
                VoucherDetailData[i].CompanyID = GlobalVarient.CompanyIDChoice;
                VoucherDetailData[i].Status = ModifyMode.Insert;
            }
            List<VoucherDetail> saveData = this.VoucherDetailData.Where(o => o.Status == ModifyMode.Insert).ToList();
            if (saveData?.Count > 0)
            {
                VoucherDetailController controller = new VoucherDetailController();
                if (controller.SaveVoucher_Detail(saveData, voucher))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    VoucherDetailDelete = new List<VoucherDetail>();
                    this.LoadVoucherDetailGridView(voucher.VouchersID);
                    this.LoadGridView();
                }
                else
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }
        }

        private void Delete_VoucherDetailsimpleButton_Click(object sender, EventArgs e)
        {
            int[] selectIndex = VoucherDetail_gridView.GetSelectedRows();

            foreach (int index in selectIndex)
            {
                VoucherDetail delete = VoucherDetail_gridView.GetRow(index) as VoucherDetail;
                if (!string.IsNullOrEmpty(delete.VouchersDetailID))
                {
                    VoucherDetailData[index].Status = ModifyMode.Delete;
                    VoucherDetailDelete.Add(delete);
                }
            }

            VoucherDetail_gridView.DeleteSelectedRows();

        }

        private void VoucherDetail_gridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            int index = e.FocusedRowHandle;

            if (VoucherDetail_gridView.IsNewItemRow(index))
            {
                return;
            }

            VoucherDetail selectedRow = VoucherDetail_gridView.GetRow(index).CastTo<VoucherDetail>();
            if (selectedRow == null)
            {
                return;
            }
        }


        private void VoucherDetail_gridView_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            int rowIndex = VoucherDetail_gridView.FocusedRowHandle;
            bool isNewRow = VoucherDetail_gridView.IsNewItemRow(rowIndex);
            GridView view = sender as GridView;
            GridColumn columnAccountID = view.Columns["AccountID"];
            GridColumn columnGeneralLedgerID = view.Columns["GeneralLedgerID"];
            GridColumn columnNV = view.Columns["NV"];
            GridColumn columnAmount = view.Columns["Amount"];
            VoucherDetail row = (e.Row as VoucherDetail);
            Decimal number1 = row.Amount;
            Decimal number2 = 0.1111m;
            number1 = Decimal.Round(number1, 2);
            number2 = Decimal.Round(number2, 2);
            Boolean CompareAmount = number1 > number2;

            if (isNewRow)
            {
                if (string.IsNullOrEmpty(row.AccountID))
                {
                    e.Valid = false;
                    //Set errors with specific descriptions for the columns
                    view.SetColumnError(columnAccountID, "Tài khoản không được để trống!");
                }
                if (string.IsNullOrEmpty(row.GeneralLedgerID))
                {
                    e.Valid = false;
                    //Set errors with specific descriptions for the columns
                    view.SetColumnError(columnGeneralLedgerID, "Sổ cái không được để trống!");
                }
                if (string.IsNullOrEmpty(row.NV))
                {
                    e.Valid = false;
                    //Set errors with specific descriptions for the columns
                    view.SetColumnError(columnNV, "NV không được để trống!");
                }
                if (!CompareAmount)
                {
                    e.Valid = false;
                    //Set errors with specific descriptions for the columns
                    view.SetColumnError(columnAmount, "Tiền phải lớn hơn 0!");
                }
            }
            
            if (!string.IsNullOrEmpty(row.AccountID) && !string.IsNullOrEmpty(row.GeneralLedgerID) && !string.IsNullOrEmpty(row.NV) && (CompareAmount))
            {
                //Tất cả dữ liệu đều có giá trị
                // so khớp sổ cái và tài khoản
                MaterialNVController controller = new MaterialNVController();
                List<MaterialCheck> MaterialCheckData = controller.GetMaterialCheck(row.AccountID.ToString(), row.GeneralLedgerID.ToString());
                bool msgCode = MaterialCheckData.Exists(s => s.msgCode == "0");
                if (msgCode)
                {
                    // view.Appearance.Row.BackColor = Color.Red;
                    e.Valid = false;
                    //Set errors with specific descriptions for the columns
                    view.SetColumnError(columnGeneralLedgerID, "Sổ cái không phù hợp với tài khoản!");
                }
               
            }

        }

        private void VoucherDetail_gridView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void VoucherDetail_gridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
        }



        private void VoucherDetail_gridView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            bool isNewRow = VoucherDetail_gridView.IsNewItemRow(e.RowHandle);
            if (isNewRow)
            {
                return;
            }

            VoucherDetail row = e.Row as VoucherDetail;
            if (row.Status == ModifyMode.Insert)
            {
                return;
            }
            row.Status = ModifyMode.Update;
        }

        private void VoucherDetail_gridView_ShowingEditor(object sender, CancelEventArgs e)
        {
            Console.WriteLine("edit");
            string col = VoucherDetail_gridView.FocusedColumn.FieldName;
            int rowIndex = VoucherDetail_gridView.FocusedRowHandle;
            bool isNewRow = VoucherDetail_gridView.IsNewItemRow(rowIndex);
            if (col == "VoucherDetailID" && !isNewRow)
            {
                e.Cancel = true;
            }
        }



        private void Voucher_gridView_RowClick(object sender, RowClickEventArgs e)
        {
            VoucherDetail_groupControl.Enabled = true;
            Voucher voucher = Voucher_gridView.GetRow(e.RowHandle).CastTo<Voucher>();
            LoadVoucherDetailGridView(voucher.VouchersID);
            richTextBoxVoucherContent.Text = voucher.Description;
            dateEditNgayNhapChungTu.EditValue = voucher.Date;
            VoucherTypeDK_searchLookUpEdit.EditValue = voucher.VouchersTypeID;
            GlobalVarient.VoucherIDChoice = voucher.VouchersID;
            GlobalVarient.voucherChoice = voucher;
            Voucher_gridView.FocusRectStyle = DrawFocusRectStyle.RowFocus;
        }

        private void simpleButtonCapNhat_Click(object sender, EventArgs e)
        {
            if (dateEditNgayNhapChungTu.EditValue == null)
            {
                MessageBoxHelper.ShowErrorMessage("Ngày nhập chứng từ không được để trống!");
                return;
            }
            if (VoucherTypeDK_searchLookUpEdit.EditValue == null)
            {
                MessageBoxHelper.ShowErrorMessage("Vui lòng chọn loại chứng từ!");
                return;
            }
            //if (!checkBoxThemDuLieu.Checked)
            //{
            //    MessageBoxHelper.ShowErrorMessage("Vui lòng tick chọn thêm chứng từ trước khi lưu mới!");
            //    return;
            //}
            decimal Debit = 0;
            decimal credit = 0;
            var result = VoucherDetailData.GroupBy(o => o.NV)
                    .Select(g => new { nv = g.Key, total = g.Sum(i => i.Amount) });
            foreach (var group in result)
            {
                Console.WriteLine("Membername = {0} Totalcost={1}", group.nv, group.total);
                if (group.nv == "N")
                {
                    Debit = group.total;
                }
                if (group.nv == "C")
                {
                    credit = group.total;
                }
            }
            if (Debit != credit)
            {
                MessageBoxHelper.ShowErrorMessage("Tổng tiền nợ có phải bằng nhau!\n" + "N: " + Debit.ToString() + "\nC: " + credit.ToString());
                return;
            }

            #region update Voucher
            VoucherController voucherController = new VoucherController();
            //GlobalVarient.VoucherID++;
            Voucher voucher = new Voucher();
            voucher.VouchersID = GlobalVarient.VoucherIDChoice;
            voucher.Amount = Debit;
            voucher.Description = richTextBoxVoucherContent.Text.ToString().Trim();
            voucherController.UpdateVoucherDetail(voucher);
            LoadGridView();
            #endregion update Voucher

            #region set VoucherDetailID
            VoucherDetailController voucherDetailController = new VoucherDetailController();
            for (int i = 0; i < VoucherDetailData.Count; i++)
            {
                if (string.IsNullOrEmpty(VoucherDetailData[i].VouchersDetailID))
                {
                    VoucherDetailData[i].Status = ModifyMode.Insert;
                    VoucherDetailData[i].VouchersID = GlobalVarient.VoucherIDChoice;
                    GlobalVarient.VoucherDetailID++;
                    // VoucherDetailData[i].VouchersDetailID = "VOD" + DateTime.Now.ToString("yyyyMMddhhmmssff") + GlobalVarient.VoucherDetailID.ToString();
                    VoucherDetailData[i].CompanyID = GlobalVarient.CompanyIDChoice;
                }
            }
            #endregion set VoucherDetailID

            int checkAction = 0;

            List<VoucherDetail> saveData = this.VoucherDetailData.Where(o => o.Status == ModifyMode.Insert || o.Status == ModifyMode.Update || o.Status == ModifyMode.Delete).ToList();
            if (saveData?.Count > 0)
            {
                VoucherDetailController controller = new VoucherDetailController();
                if (controller.SaveVoucherDetail(saveData))
                {
                    // MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    checkAction++;
                    // VoucherDetailDelete = new List<VoucherDetail>();
                }
                else
                {
                    checkAction = 0;
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

            #region delete VoucherDetail
            if (VoucherDetailDelete?.Count > 0)
            {
                VoucherDetailController controller = new VoucherDetailController();
                if (controller.SaveVoucherDetail(VoucherDetailDelete))
                {
                    checkAction++;
                    // MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                }
                else
                {
                    checkAction = 0;
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

            if (checkAction > 0)
            {
                MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
            }
            #endregion delete VoucherDetail

            this.LoadVoucherDetailGridView(GlobalVarient.VoucherIDChoice);
            LoadGridView();
        }

        private void checkBoxThemDuLieu_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxThemDuLieu.Checked)
            {
                Voucher_groupControl.Enabled = false;
            }
            else Voucher_groupControl.Enabled = true;
        }
        private void LKKhosimpleButton_Click(object sender, EventArgs e)
        {
            Showtabpane(2);
        }

        private void LKVATsimpleButton_Click(object sender, EventArgs e)
        {
            Showtabpane(1);
        }

        private void tabPaneVouchers_SelectedPageIndexChanged(object sender, EventArgs e)
        {
            // Showtabpane(tabPaneVouchers.SelectedPageIndex);
        }

        void Showtabpane(int SelectedIndexTabPane)
        {
            switch (SelectedIndexTabPane)
            {
                case 1:
                    #region check TK
                    //152, 156 Mở liên kết kho(Nhập, xuất)
                    //1331, 3331 Mở liên kết VAT(Nhập, Xuất)
                    int checkLKVAT = 0;
                    foreach (VoucherDetail voucherDetail in GlobalVarient.voucherDetailChoice)
                    {
                        string checkAccountID = voucherDetail.AccountID.ToString().Substring(0, 3);
                        if (checkAccountID == "133" || checkAccountID == "333")
                        {
                            tabNavigationPageLKVAT.PageVisible = true;
                            tabPaneVouchers.SelectedPageIndex = 1;
                            LoadInvoiceGridviewFull();
                            checkLKVAT = 1;
                            break;
                        }
                    }
                    if (checkLKVAT == 0)
                    {
                        tabNavigationPageLKVAT.PageVisible = false;
                        tabPaneVouchers.SelectedPageIndex = 0;


                    }
                    break;
                #endregion check TK

                case 2:
                    int checkLKkho = 0;
                    foreach (VoucherDetail voucherDetail in GlobalVarient.voucherDetailChoice)
                    {
                        string checkAccountID = voucherDetail.AccountID.ToString().Substring(0, 3);
                        if (checkAccountID == "152" || checkAccountID == "156")
                        {
                            tabNavigationPageLKKho.PageVisible = true;
                            tabPaneVouchers.SelectedPageIndex = 2;
                            LoadWareHouseGridviewFull();
                            checkLKkho = 1;
                            break;
                        }
                    }
                    if (checkLKkho == 0)
                    {
                        tabNavigationPageLKKho.PageVisible = false;
                        tabPaneVouchers.SelectedPageIndex = 0;
                    }
                    break;
            }
        }

        #region init Invoice TabPane


        void LoadInvoiceGridviewFull()
        {
            Init_Invoice_GridView();
            Setup_Invoice_GridView();
            Load_Invoice_GridView();
        }

        void LoadInvoiceWareHouseGridviewFull()
        {
            Init_InvoiceWareHouse_GridView();
            Setup_InvoiceWareHouse_GridView();
            Load_InvoiceWareHouse_GridView();
        }

        private void Init_InvoiceWareHouse_GridView()
        {
            this.InvoiceWareHouse_gridView.Columns.Clear();
            this.InvoiceWareHouse_gridView.AddColumn("Date", "Ngày", 80, false);
            this.InvoiceWareHouse_gridView.AddColumn("DeliverReceiver", "Người giao nhận", 80, true);
            this.InvoiceWareHouse_gridView.AddColumn("Description", "Nội dung", 100, true);
            this.InvoiceWareHouse_gridView.AddColumn("Attachfile", "File đính kèm", 60, true);
            this.InvoiceWareHouse_gridView.AddSearchLookupEditColumn("GeneralLedgerID", "Sổ cái", 120, materialGL, "GeneralLedgerID", "GeneralLedgerName", isAllowEdit: true);
            this.InvoiceWareHouse_gridView.AddSearchLookupEditColumn("Type", "Loại", 80, materialWareHouseType, "WareHouseTypeSummary", "WareHouseTypeSummary", isAllowEdit: false);
            this.InvoiceWareHouse_gridView.AddSearchLookupEditColumn("DebitAccountID", "TK Nợ", 80, materialTK, "AccountID", "AccountID", isAllowEdit: true);
            this.InvoiceWareHouse_gridView.AddSearchLookupEditColumn("CreditAccountID", "TK Có", 80, materialTK, "AccountID", "AccountID", isAllowEdit: true);
            this.InvoiceWareHouse_gridView.AddSearchLookupEditColumn("CustomerID", "KH", 80, materialDT, "CustomerID", "CustomerSName", isAllowEdit: true);
            this.InvoiceWareHouse_gridView.AddColumn("CreateUser", "Người tạo", 60, false);
        }

        private void Setup_InvoiceWareHouse_GridView()
        {
            this.InvoiceWareHouse_gridView.SetupGridView(multiSelect: true, checkBoxSelectorColumnWidth: 30);
            this.InvoiceWareHouse_gridView.SetupGridView(columnAutoWidth: false);
            this.InvoiceWareHouse_gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            this.InvoiceWareHouse_gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
        }

        private void Load_InvoiceWareHouse_GridView()
        {
            WareHouseController controller = new WareHouseController();
            if (GlobalVarient.invoiceChoice == null || GlobalVarient.invoiceChoice.InvoiceID == null)
            {
                GlobalVarient.warehouseInvoice = controller.GetWareHouseSelectInvoiceID("00000", GlobalVarient.CompanyIDChoice);
            }
            else
            {
                GlobalVarient.warehouseInvoice = controller.GetWareHouseSelectInvoiceID(GlobalVarient.invoiceChoice.InvoiceID, GlobalVarient.CompanyIDChoice);
            }

            InvoiceWarehouseData = new BindingList<WareHouse>(GlobalVarient.warehouseInvoice);
            InvoiceWareHouse_gridControl.DataSource = InvoiceWarehouseData;
            InvoiceWareHouseDelete = new List<WareHouse>();
        }

        #region init invoice Depreciation
        void LoadInvoiceDepreciationGridviewFull()
        {
            Init_InvoiceDepreciation_GridView();
            Setup_InvoiceDepreciation_GridView();
            Load_InvoiceDepreciation_GridView();
        }

        private void Init_InvoiceDepreciation_GridView()
        {
            this.InvoiceDepreciation_gridView.Columns.Clear();
            this.InvoiceDepreciation_gridView.AddColumn("StartDate", "Ngày BĐSD", 80, true);
            this.InvoiceDepreciation_gridView.AddColumn("UseMonth", "Số tháng SD", 70, true);
            this.InvoiceDepreciation_gridView.AddColumn("DepreciationMonth", "Số tháng KH", 70, true);
            this.InvoiceDepreciation_gridView.AddColumn("CurrentMonth", "Tháng HT", 60, true);
            this.InvoiceDepreciation_gridView.AddSpinEditColumn("DepreciationAmount", "Tiền KH", 120, true, "C2");
            this.InvoiceDepreciation_gridView.AddSpinEditColumn("DepreciationAmountPerMonth", "Tiền/Tháng", 120, false, "C2");
        }

        private void Setup_InvoiceDepreciation_GridView()
        {
            this.InvoiceDepreciation_gridView.SetupGridView(multiSelect: true, checkBoxSelectorColumnWidth: 30);
            this.InvoiceDepreciation_gridView.SetupGridView(columnAutoWidth: false);
            this.InvoiceDepreciation_gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            this.InvoiceDepreciation_gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
        }

        private void Load_InvoiceDepreciation_GridView()
        {

            DepreciationController controller = new DepreciationController();
            if (GlobalVarient.warehouseDetailInvoiceChoice == null || GlobalVarient.warehouseDetailInvoiceChoice.WareHouseDetailID == null)
            {
                GlobalVarient.InvoiceDepreciations = controller.GetDepreciationSelect("00000", GlobalVarient.CompanyIDChoice);
            }
            else
            {
                GlobalVarient.InvoiceDepreciations = controller.GetDepreciationSelect(GlobalVarient.warehouseDetailInvoiceChoice.WareHouseDetailID, GlobalVarient.CompanyIDChoice);
            }

            InvoiceDepreciationData = new BindingList<Depreciation>(GlobalVarient.InvoiceDepreciations);
            InvoiceDepreciation_gridControl.DataSource = InvoiceDepreciationData;
            InvoiceDepreciationDelete = new List<Depreciation>();
        }


        void LoadInvoiceDepreciationDetailGridviewFull()
        {
            Init_InvoiceDepreciationDetail_GridView();
            Setup_InvoiceDepreciationDetail_GridView();
            Load_InvoiceDepreciationDetail_GridView();
        }

        private void Init_InvoiceDepreciationDetail_GridView()
        {
            this.InvoiceDepreciationDetail_gridView.Columns.Clear();
            this.InvoiceDepreciationDetail_gridView.AddColumn("PeriodCurrent", "kỳ HT", 40, true);
            this.InvoiceDepreciationDetail_gridView.AddColumn("DepreciationDate", "Ngày của kỳ", 80, true);
            this.InvoiceDepreciationDetail_gridView.AddColumn("QuantityPeriod", "SL kỳ", 40, true);
            this.InvoiceDepreciationDetail_gridView.AddSpinEditColumn("Amount", "Tiền", 110, true, "C2");
            this.InvoiceDepreciationDetail_gridView.AddColumn("Descriptions", "Nội dung", 120, true);
        }

        private void Setup_InvoiceDepreciationDetail_GridView()
        {
            this.InvoiceDepreciationDetail_gridView.SetupGridView(multiSelect: true, checkBoxSelectorColumnWidth: 30);
            this.InvoiceDepreciationDetail_gridView.SetupGridView(columnAutoWidth: false);
            this.InvoiceDepreciationDetail_gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            this.InvoiceDepreciationDetail_gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
        }

        private void Load_InvoiceDepreciationDetail_GridView()
        {

            DepreciationDetailController controller = new DepreciationDetailController();
            if (GlobalVarient.InvoiceDepreciationsChoice == null || GlobalVarient.InvoiceDepreciationsChoice.DepreciationID == null)
            {
                GlobalVarient.InvoiceDepreciationsDetail = controller.GetDepreciationDetailSelect("00000", GlobalVarient.CompanyIDChoice);
            }
            else
            {
                GlobalVarient.InvoiceDepreciationsDetail = controller.GetDepreciationDetailSelect(GlobalVarient.InvoiceDepreciationsChoice.DepreciationID, GlobalVarient.CompanyIDChoice);
            }

            InvoiceDepreciationDetailData = new BindingList<DepreciationDetail>(GlobalVarient.InvoiceDepreciationsDetail);
            InvoiceDepreciationDetail_gridControl.DataSource = InvoiceDepreciationDetailData;
            InvoiceDepreciationDetailDelete = new List<DepreciationDetail>();
        }
        #endregion init invoice De


        #region init invoice warehouse detail
        void LoadInvoiceWareHouseDetailGridviewFull()
        {
            Init_InvoiceWareHouseDetail_GridView();
            Setup_InvoiceWareHouseDetail_GridView();
            Load_InvoiceWareHouseDetail_GridView();
        }

        private void Init_InvoiceWareHouseDetail_GridView()
        {
            this.InvoiceWareHouseDetail_gridView.Columns.Clear();
            this.InvoiceWareHouseDetail_gridView.AddSearchLookupEditColumn("ItemID", "Sản phẩm", 80, items, "ItemID", "ItemSName", isAllowEdit: true, editValueChanged: invoiceWareHouseDetail_EditValueChanged);
            this.InvoiceWareHouseDetail_gridView.AddColumn("ItemUnit", "ĐVT", 35, isAllowEdit: true);
            this.InvoiceWareHouseDetail_gridView.AddSpinEditColumn("Quantity", "Số lượng", 60, true, "#0.00");
            this.InvoiceWareHouseDetail_gridView.AddSpinEditColumn("Price", "Đơn giá", 120, true, "c2");
            this.InvoiceWareHouseDetail_gridView.AddSpinEditColumn("Amount", "Thành tiền", 110, true, "c2");
        }

        private void Setup_InvoiceWareHouseDetail_GridView()
        {
            this.InvoiceWareHouseDetail_gridView.SetupGridView(multiSelect: true, checkBoxSelectorColumnWidth: 30);
            this.InvoiceWareHouseDetail_gridView.SetupGridView(columnAutoWidth: false);
            this.InvoiceWareHouseDetail_gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            this.InvoiceWareHouseDetail_gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
        }

        private void Load_InvoiceWareHouseDetail_GridView()
        {
            WareHouseDetailController controller = new WareHouseDetailController();
            if (GlobalVarient.warehouseInvoiceChoice == null || GlobalVarient.warehouseInvoiceChoice.WarehouseID == null)
            {
                GlobalVarient.warehouseDetailInvoice = controller.GetWareHouseDetailSelectWahouseID("00000", GlobalVarient.CompanyIDChoice);
            }
            else
            {
                GlobalVarient.warehouseDetailInvoice = controller.GetWareHouseDetailSelectWahouseID(GlobalVarient.warehouseInvoiceChoice.WarehouseID, GlobalVarient.CompanyIDChoice);
            }

            InvoiceWarehouseDetailData = new BindingList<WareHouseDetail>(GlobalVarient.warehouseDetailInvoice);
            InvoiceWareHouseDetail_gridControl.DataSource = InvoiceWarehouseDetailData;
            InvoiceWareHouseDetailDelete = new List<WareHouseDetail>();
        }
        #endregion init invoice warehouse detail

        private void Init_Invoice_GridView()
        {
            this.Invoice_gridView.Columns.Clear();
            this.Invoice_gridView.AddColumn("InvoiceDate", "Ngày HĐ", 80, true);
            this.Invoice_gridView.AddSearchLookupEditColumn(
                "CustomerID", "Mã KH", 120, materialCustomerInvoice, "CustomerID", "CustomerSName",
                isAllowEdit: true, editValueChanged: invoice_EditValueChanged, popupFormWidth: 800);
            this.Invoice_gridView.AddColumn("InvoiceFormNo", "Mã số", 80, true);
            this.Invoice_gridView.AddColumn("FormNo", "Mẫu số", 80, true);
            this.Invoice_gridView.AddColumn("SerialNo", "Kí hiệu", 80, true);
            this.Invoice_gridView.AddColumn("InvoiceNo", "Số HĐ", 80, true);
            this.Invoice_gridView.AddSpinEditColumn("Amount", "Tiền", 120, true, "c2");
            this.Invoice_gridView.AddSpinEditColumn("VAT", "%GTGT", 60, true, "{0}%");
            this.Invoice_gridView.AddSpinEditColumn("VATAmount", "Tiền GTGT", 120, true, "c2");
            this.Invoice_gridView.AddSpinEditColumn("Discounts", "CK", 80, true, "c2");
            this.Invoice_gridView.AddSpinEditColumn("TotalAmount", "Thành Tiền", 120, true, "c2");
            //this.Invoice_gridView.AddColumn("InvoiceType", "Loại HĐ", 60, true);
            this.Invoice_gridView.AddSearchLookupEditColumn(
                "InvoiceType", "Loại HĐ", 60, materialInvoiceType, "InvoiceTypeSummary", "InvoiceTypeName", isAllowEdit: true);
            this.Invoice_gridView.AddColumn("Description", "Nội dung", 150, true);
            this.Invoice_gridView.AddColumn("CreateUser", "Người tạo", 60, false);
        }


        private void Setup_Invoice_GridView()
        {
            this.Invoice_gridView.SetupGridView(multiSelect: true, checkBoxSelectorColumnWidth: 30);
            this.Invoice_gridView.SetupGridView(columnAutoWidth: false);
            this.Invoice_gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            this.Invoice_gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
        }

        private void Load_Invoice_GridView()
        {
            InvoiceController controller = new InvoiceController();
            GlobalVarient.invoices = controller.GetInvoiceSelectVoucherID(GlobalVarient.voucherChoice.VouchersID, GlobalVarient.CompanyIDChoice);
            //  VoucherDetailData = new BindingList<VoucherDetail>(controller.GetVouchersDetailSelectVoucherID(voucherID, GlobalVarient.CompanyIDChoice));
            InvoiceData = new BindingList<Invoice>(GlobalVarient.invoices);
            Invoice_gridControl.DataSource = InvoiceData;
            InvoiceDelete = new List<Invoice>();
        }




        public void invoice_EditValueChanged(object sender, EventArgs e)
        {
            var selectRow = ((SearchLookUpEdit)sender).Properties.View.GetFocusedRow().CastTo<MaterialCustomerInvoice>();
            Invoice_gridView.SetFocusedRowCellValue("InvoiceFormNo", selectRow.InvoiceFormNo);
            Invoice_gridView.SetFocusedRowCellValue("FormNo", selectRow.FormNo);
            Invoice_gridView.SetFocusedRowCellValue("SerialNo", selectRow.SerialNo);
            // Muon lay gi ra thif dung selectRow.
        }


        public void invoiceWareHouseDetail_EditValueChanged(object sender, EventArgs e)
        {
            var selectRow = ((SearchLookUpEdit)sender).Properties.View.GetFocusedRow().CastTo<Items>();
            InvoiceWareHouseDetail_gridView.SetFocusedRowCellValue("ItemUnit", selectRow.ItemUnit);
        }



        #endregion init Invoice TabPane

        Boolean CheckInvoiceCondition()
        {
             //Trong một ngày, cùng xuất hóa đơn cho 1 công ty không được lớn hơn 20 triệu
            List<Invoice> groupedList = InvoiceData
                            .GroupBy(c => new
                            {
                                c.InvoiceDate,
                                c.CustomerID
                            })
                            .Select(i =>
                                new Invoice()
                                {
                                    InvoiceDate = i.First().InvoiceDate,
                                    CustomerID = i.First().CustomerID,
                                    Amount = i.Sum(k => k.Amount)
                                }
                            ).ToList();
            for(int i =0; i<groupedList.Count;i++)
            {
                if(groupedList[i].Amount > 20000000)
                {
                    //check tồn tại tk ngân hàng
                    List<VoucherDetail> groupedListVoucherDetail = VoucherDetailData
                        .GroupBy(c => new
                        {
                            c.NV,
                            c.AccountID,
                            c.Amount
                        })
                        .Select(j =>
                            new VoucherDetail()
                            {
                                NV = j.First().NV,
                                AccountID = j.First().AccountID,
                                Amount = j.Sum(k => k.Amount)
                            }
                        ).ToList();
                    for(int ij =0; ij< groupedListVoucherDetail.Count; ij++)
                    {
                        //Tiền hóa đơn trong 1 ngày của cùng 1 khách hàng lớn hơn 20 triệu thì phải được thanh toán bằng tiền ngân hàng.
                        if(groupedListVoucherDetail[ij].AccountID.Substring(0,3) == "112" && groupedListVoucherDetail[ij].Amount >= groupedList[i].Amount)
                        {
                            return true;
                        }
                    }
                    ///Không tồn tại tk ngân hàng mà có tiền của hóa đơn cùng 1 công ty cùng 1 ngày lớn hơn 20 triệu.
                    return false;
                }
            }
            return true;
        }
        private void InvoiceSaveNew_simpleButton_Click(object sender, EventArgs e)
        {
            if (!InvoiceAddNew_checkBox.Checked)
            {
                MessageBoxHelper.ShowErrorMessage("Vui lòng tick chọn thêm hóa đơn trước khi lưu mới!");
                return;
            }
            if (!CheckInvoiceCondition())
            {
                MessageBoxHelper.ShowErrorMessage("Tổng tiền hóa đơn của cùng một khách hàng trong một ngày lớn hơn 20 triệu thì phải định khoản tài khoản ngân hàng!");
                return;
            }

            #region set VoucherID to invoice
            InvoiceController invoiceController = new InvoiceController();
            for (int i = 0; i < InvoiceData.Count; i++)
            {
                InvoiceData[i].CompanyID = GlobalVarient.CompanyIDChoice;
                InvoiceData[i].VouchersID = GlobalVarient.voucherChoice.VouchersID;
                InvoiceData[i].Status = ModifyMode.Insert;
            }
            #endregion set VoucherID to invoice

            List<Invoice> saveData = this.InvoiceData.Where(o => o.Status == ModifyMode.Insert).ToList();
            if (saveData?.Count > 0)
            {
                InvoiceController controller = new InvoiceController();
                if (controller.SaveInvoice(saveData))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    InvoiceDelete = new List<Invoice>();
                    this.Load_Invoice_GridView();
                }
                else
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

        }

        private void InvoiceSave_simpleButton_Click(object sender, EventArgs e)
        {
            if (!CheckInvoiceCondition())
            {
                MessageBoxHelper.ShowErrorMessage("Tổng tiền hóa đơn của cùng một khách hàng trong một ngày lớn hơn 20 triệu thì phải định khoản tài khoản ngân hàng!");
                return;
            }
            #region set invoice
            InvoiceController InvoiceController = new InvoiceController();
            for (int i = 0; i < InvoiceData.Count; i++)
            {
                if (string.IsNullOrEmpty(InvoiceData[i].InvoiceID))
                {
                    InvoiceData[i].Status = ModifyMode.Insert;
                    InvoiceData[i].VouchersID = GlobalVarient.voucherChoice.VouchersID;
                    InvoiceData[i].CompanyID = GlobalVarient.CompanyIDChoice;
                }
            }
            #endregion set invoice

            int checkAction = 0;

            List<Invoice> saveData = this.InvoiceData.Where(o => o.Status == ModifyMode.Insert || o.Status == ModifyMode.Update || o.Status == ModifyMode.Delete).ToList();
            if (saveData?.Count > 0)
            {
                InvoiceController controller = new InvoiceController();
                if (controller.SaveInvoice(saveData))
                {
                    checkAction++;
                }
                else
                {
                    checkAction = 0;
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

            #region delete Invoice
            if (InvoiceDelete?.Count > 0)
            {
                InvoiceController controller = new InvoiceController();
                if (controller.SaveInvoice(InvoiceDelete))
                {
                    checkAction++;
                }
                else
                {
                    checkAction = 0;
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

            if (checkAction > 0)
            {
                MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
            }
            #endregion delete Invoice

            this.Load_Invoice_GridView();
        }

        private void InvoiceDelete_simpleButton_Click(object sender, EventArgs e)
        {
            int[] selectIndex = Invoice_gridView.GetSelectedRows();
            foreach (int index in selectIndex)
            {
                Invoice delete = Invoice_gridView.GetRow(index) as Invoice;
                if (!string.IsNullOrEmpty(delete.InvoiceID))
                {
                    InvoiceData[index].Status = ModifyMode.Delete;
                    InvoiceDelete.Add(delete);
                }
            }
            Invoice_gridView.DeleteSelectedRows();
        }

        private void InvoiceCancel_simpleButton_Click(object sender, EventArgs e)
        {
            this.Load_Invoice_GridView();
        }

        private void WareHouseSaveNew_simpleButton_Click(object sender, EventArgs e)
        {
            #region insert Phiếu kho cho hóa đơn.
            //1 hóa đơn có thể có nhiều phiếu kho
            if (!WareHouseAddNew_checkBox.Checked)
            {
                MessageBoxHelper.ShowErrorMessage("Vui lòng tick chọn thêm phiếu kho trước khi lưu mới!");
                return;
            }
            #region set InvoiceID to WareHouse
            for (int i = 0; i < InvoiceWarehouseData.Count; i++)
            {
                InvoiceWarehouseData[i].CompanyID = GlobalVarient.CompanyIDChoice;
                InvoiceWarehouseData[i].VouchersID = GlobalVarient.voucherChoice.VouchersID;
                InvoiceWarehouseData[i].InvoiceID = GlobalVarient.invoiceChoice.InvoiceID;
                InvoiceWarehouseData[i].Date = GlobalVarient.voucherChoice.Date;

                InvoiceWarehouseData[i].Status = ModifyMode.Insert;
            }
            #endregion set VoucherID to invoice

            List<WareHouse> saveData = this.InvoiceWarehouseData.Where(o => o.Status == ModifyMode.Insert).ToList();
            if (saveData?.Count > 0)
            {
                WareHouseController controller = new WareHouseController();
                if (controller.SaveWareHouse(saveData))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    InvoiceWareHouseDelete = new List<WareHouse>();
                    this.LoadInvoiceWareHouseGridviewFull();
                }
                else
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

            #endregion insert Phiếu kho cho hóa đơn.
        }


        int ChoiceInvoice = 0;

        private void Invoice_gridView_RowClick(object sender, RowClickEventArgs e)
        {
            InvoiceWareHouse_groupControl.Enabled = true;
            Invoice invoice = Invoice_gridView.GetRow(e.RowHandle).CastTo<Invoice>();
            GlobalVarient.invoiceChoice = invoice;
            if (ChoiceInvoice == 0)
            {
                LoadInvoiceWareHouseGridviewFull();
                ChoiceInvoice = 1;
            }
            else
            {
                Load_InvoiceWareHouse_GridView();
            }
        }

        private void WareHouseSave_simpleButton_Click(object sender, EventArgs e)
        {
            #region set InvoiceID to WareHouse
            for (int i = 0; i < InvoiceWarehouseData.Count; i++)
            {
                if (string.IsNullOrEmpty(InvoiceWarehouseData[i].WarehouseID))
                {
                    InvoiceWarehouseData[i].CompanyID = GlobalVarient.CompanyIDChoice;
                    InvoiceWarehouseData[i].VouchersID = GlobalVarient.voucherChoice.VouchersID;
                    InvoiceWarehouseData[i].InvoiceID = GlobalVarient.invoiceChoice.InvoiceID;
                    InvoiceWarehouseData[i].Date = GlobalVarient.voucherChoice.Date;
                    InvoiceWarehouseData[i].Status = ModifyMode.Insert;
                }
            }
            #endregion  set InvoiceID to WareHouse

            int checkAction = 0;

            List<WareHouse> saveData = this.InvoiceWarehouseData.Where(o => o.Status == ModifyMode.Insert || o.Status == ModifyMode.Update || o.Status == ModifyMode.Delete).ToList();
            if (saveData?.Count > 0)
            {
                //  InvoiceController controller = new InvoiceController();
                WareHouseController controller = new WareHouseController();
                if (controller.SaveWareHouse(saveData))
                {
                    checkAction++;
                }
                else
                {
                    checkAction = 0;
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

            #region delete Invoice
            if (InvoiceWareHouseDelete?.Count > 0)
            {
                WareHouseController controller = new WareHouseController();
                if (controller.SaveWareHouse(InvoiceWareHouseDelete))
                {
                    checkAction++;
                }
                else
                {
                    checkAction = 0;
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

            if (checkAction > 0)
            {
                MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
            }
            #endregion delete InvoiceWareHouse
            this.Load_InvoiceWareHouse_GridView();
        }



        private void Invoice_gridView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            bool isNewRow = Invoice_gridView.IsNewItemRow(e.RowHandle);
            if (isNewRow)
            {
                return;
            }

            Invoice row = e.Row as Invoice;
            if (row.Status == ModifyMode.Insert)
            {
                return;
            }
            row.Status = ModifyMode.Update;
        }

        private void InvoiceWareHouse_gridView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            bool isNewRow = InvoiceWareHouse_gridView.IsNewItemRow(e.RowHandle);
            if (isNewRow)
            {
                return;
            }

            WareHouse row = e.Row as WareHouse;
            if (row.Status == ModifyMode.Insert)
            {
                return;
            }
            row.Status = ModifyMode.Update;
        }

        private void WareHouseDelete_simpleButton_Click(object sender, EventArgs e)
        {
            int[] selectIndex = InvoiceWareHouse_gridView.GetSelectedRows();
            foreach (int index in selectIndex)
            {
                WareHouse delete = InvoiceWareHouse_gridView.GetRow(index) as WareHouse;
                if (!string.IsNullOrEmpty(delete.WarehouseID))
                {
                    InvoiceWarehouseData[index].Status = ModifyMode.Delete;
                    InvoiceWareHouseDelete.Add(delete);
                }
            }

            InvoiceWareHouse_gridView.DeleteSelectedRows();
        }






        private void InvoiceWareHouseCancel_simpleButton_Click(object sender, EventArgs e)
        {
            this.Load_InvoiceWareHouse_GridView();
        }

        int ChoiceWareHouse = 0;
        private void InvoiceWareHouse_gridView_RowClick(object sender, RowClickEventArgs e)
        {
            //InvoiceWareHouse_groupControl.Enabled = true;
            WareHouse wareHouse = InvoiceWareHouse_gridView.GetRow(e.RowHandle).CastTo<WareHouse>();
            GlobalVarient.warehouseInvoiceChoice = wareHouse;
            if (ChoiceWareHouse == 0)
            {
                // LoadInvoiceWareHouseGridviewFull();
                LoadInvoiceWareHouseDetailGridviewFull();
                ChoiceWareHouse = 1;
            }
            else
            {
                // Load_InvoiceWareHouse_GridView();
                Load_InvoiceWareHouseDetail_GridView();
            }
        }

        private void InvoiceWareHouseDetailSaveNew_simpleButton_Click(object sender, EventArgs e)
        {
            #region insert chi tiết hóa đơn Phiếu kho cho hóa đơn.
            //1 hóa đơn có thể có nhiều phiếu kho
            if (!InvoiceWareHouseDetailAddNew_checkBox.Checked)
            {
                MessageBoxHelper.ShowErrorMessage("Vui lòng tick chọn thêm chi tiết hóa đơn trước khi lưu mới!");
                return;
            }
            #region set warehouseID to WareHouseDetail
            for (int i = 0; i < InvoiceWarehouseDetailData.Count; i++)
            {
                InvoiceWarehouseDetailData[i].CompanyID = GlobalVarient.CompanyIDChoice;
                InvoiceWarehouseDetailData[i].WarehouseID = GlobalVarient.warehouseInvoiceChoice.WarehouseID;
                InvoiceWarehouseDetailData[i].Status = ModifyMode.Insert;
            }
            #endregion set warehouseID to WareHouseDetail

            List<WareHouseDetail> saveData = this.InvoiceWarehouseDetailData.Where(o => o.Status == ModifyMode.Insert).ToList();
            if (saveData?.Count > 0)
            {
                WareHouseDetailController controller = new WareHouseDetailController();
                if (controller.SaveWareHouseDetail(saveData))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    InvoiceWareHouseDetailDelete = new List<WareHouseDetail>();

                    this.LoadInvoiceWareHouseDetailGridviewFull();
                }
                else
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

            #endregion insert chi tiết hóa đơn Phiếu kho cho hóa đơn.
        }

        private void InvoiceWareHouseDetailSave_simpleButton_Click(object sender, EventArgs e)
        {
            #region set warehouseID to WareHouseDetail
            for (int i = 0; i < InvoiceWarehouseDetailData.Count; i++)
            {
                if (string.IsNullOrEmpty(InvoiceWarehouseDetailData[i].WareHouseDetailID))
                {
                    InvoiceWarehouseDetailData[i].CompanyID = GlobalVarient.CompanyIDChoice;
                    InvoiceWarehouseDetailData[i].WarehouseID = GlobalVarient.warehouseInvoiceChoice.WarehouseID;
                    InvoiceWarehouseDetailData[i].Status = ModifyMode.Insert;
                }
            }
            #endregion  set warehouseID to WareHouseDetail

            int checkAction = 0;

            List<WareHouseDetail> saveData = this.InvoiceWarehouseDetailData.Where(o => o.Status == ModifyMode.Insert || o.Status == ModifyMode.Update || o.Status == ModifyMode.Delete).ToList();
            if (saveData?.Count > 0)
            {
                //  InvoiceController controller = new InvoiceController();
                WareHouseDetailController controller = new WareHouseDetailController();
                if (controller.SaveWareHouseDetail(saveData))
                {
                    checkAction++;
                }
                else
                {
                    checkAction = 0;
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

            #region delete warehouseDetail
            if (InvoiceWareHouseDetailDelete?.Count > 0)
            {
                WareHouseDetailController controller = new WareHouseDetailController();
                if (controller.SaveWareHouseDetail(InvoiceWareHouseDetailDelete))
                {
                    checkAction++;
                }
                else
                {
                    checkAction = 0;
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

            if (checkAction > 0)
            {
                MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
            }
            #endregion delete warehouseDetail
            this.Load_InvoiceWareHouseDetail_GridView();
        }

        private void InvoiceWareHouseDetailDelete_simpleButton_Click(object sender, EventArgs e)
        {
            int[] selectIndex = InvoiceWareHouseDetail_gridView.GetSelectedRows();
            foreach (int index in selectIndex)
            {
                WareHouseDetail delete = InvoiceWareHouseDetail_gridView.GetRow(index) as WareHouseDetail;
                if (!string.IsNullOrEmpty(delete.WarehouseID))
                {
                    InvoiceWarehouseDetailData[index].Status = ModifyMode.Delete;
                    InvoiceWareHouseDetailDelete.Add(delete);
                }
            }

            InvoiceWareHouseDetail_gridView.DeleteSelectedRows();
        }

        int ChoiceWareHouseDetail = 0;
        private void InvoiceWareHouseDetail_gridView_RowClick(object sender, RowClickEventArgs e)
        {
            InvoiceDepreciationgroupControl.Enabled = true;
            //LoadInvoiceDepreciationGridviewFull()
            WareHouseDetail wareHouseDetail = InvoiceWareHouseDetail_gridView.GetRow(e.RowHandle).CastTo<WareHouseDetail>();
            GlobalVarient.warehouseDetailInvoiceChoice = wareHouseDetail;
            GlobalVarient.InvoiceDepreciationsChoice = null;
            if (ChoiceWareHouseDetail == 0)
            {
                LoadInvoiceDepreciationGridviewFull();
                LoadInvoiceDepreciationDetailGridviewFull();
                ChoiceWareHouseDetail = 1;
            }
            else
            {
                Load_InvoiceDepreciation_GridView();
                Load_InvoiceDepreciationDetail_GridView();
            }

        }

        private void InvoiceDepreciationSaveNew_simpleButton_Click(object sender, EventArgs e)
        {
            #region insert Khấu hao
            //1 hóa đơn có thể có nhiều phiếu kho
            if (!InvoiceDepreciationAddNew_checkBox.Checked)
            {
                MessageBoxHelper.ShowErrorMessage("Vui lòng tick chọn thêm khấu hao trước khi lưu mới!");
                return;
            }
            #region set warehouseDetailID to Depreciation
            for (int i = 0; i < InvoiceDepreciationData.Count; i++)
            {
                InvoiceDepreciationData[i].CompanyID = GlobalVarient.CompanyIDChoice;
                InvoiceDepreciationData[i].WareHouseDetailID = GlobalVarient.warehouseDetailInvoiceChoice.WareHouseDetailID;
                InvoiceDepreciationData[i].StatusA = ModifyMode.Insert;
            }
            #endregion set warehouseID to WareHouseDetail

            List<Depreciation> saveData = this.InvoiceDepreciationData.Where(o => o.StatusA == ModifyMode.Insert).ToList();
            if (saveData?.Count > 0)
            {
                DepreciationController controller = new DepreciationController();
                if (controller.SaveDepreciation(saveData))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    InvoiceDepreciationDelete = new List<Depreciation>();
                    this.Load_InvoiceDepreciation_GridView();
                }
                else
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

            #endregion insert Khấu hao
        }

        private void InvoiceDepreciationSave_simpleButton_Click(object sender, EventArgs e)
        {
            #region set warehouseDetailID to Depreciation
            for (int i = 0; i < InvoiceDepreciationData.Count; i++)
            {
                if (string.IsNullOrEmpty(InvoiceDepreciationData[i].WareHouseDetailID))
                {
                    InvoiceDepreciationData[i].CompanyID = GlobalVarient.CompanyIDChoice;
                    InvoiceDepreciationData[i].WareHouseDetailID = GlobalVarient.warehouseDetailInvoiceChoice.WareHouseDetailID;
                    InvoiceDepreciationData[i].StatusA = ModifyMode.Insert;
                }
            }
            #endregion  set warehouseDetailID to Depreciation

            int checkAction = 0;

            List<Depreciation> saveData = this.InvoiceDepreciationData.Where(o => o.StatusA == ModifyMode.Insert || o.StatusA == ModifyMode.Update || o.StatusA == ModifyMode.Delete).ToList();
            if (saveData?.Count > 0)
            {
                //  InvoiceController controller = new InvoiceController();
                DepreciationController controller = new DepreciationController();
                if (controller.SaveDepreciation(saveData))
                {
                    checkAction++;
                }
                else
                {
                    checkAction = 0;
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

            #region delete Depriciation
            if (InvoiceDepreciationDelete?.Count > 0)
            {
                DepreciationController controller = new DepreciationController();
                if (controller.SaveDepreciation(InvoiceDepreciationDelete))
                {
                    checkAction++;
                }
                else
                {
                    checkAction = 0;
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

            if (checkAction > 0)
            {
                MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
            }
            #endregion delete Depriciation
            this.Load_InvoiceDepreciation_GridView();
        }

        private void InvoiceDepreciationDelete_simpleButton_Click(object sender, EventArgs e)
        {
            int[] selectIndex = InvoiceDepreciation_gridView.GetSelectedRows();
            foreach (int index in selectIndex)
            {
                Depreciation delete = InvoiceDepreciation_gridView.GetRow(index) as Depreciation;
                if (!string.IsNullOrEmpty(delete.DepreciationID))
                {
                    InvoiceDepreciationData[index].StatusA = ModifyMode.Delete;
                    InvoiceDepreciationDelete.Add(delete);
                }
            }

            InvoiceDepreciation_gridView.DeleteSelectedRows();
        }

        private void InvoiceDepreciationCancel_simpleButton_Click(object sender, EventArgs e)
        {
            this.Load_InvoiceDepreciation_GridView();
        }

        int ChoiceDepreciation = 0;
        private void InvoiceDepreciation_gridView_RowClick(object sender, RowClickEventArgs e)
        {
            // InvoiceDepreciationgroupControl.Enabled = true;
            //LoadInvoiceDepreciationGridviewFull()
            Depreciation depreciation = InvoiceDepreciation_gridView.GetRow(e.RowHandle).CastTo<Depreciation>();
            GlobalVarient.InvoiceDepreciationsChoice = depreciation;
            if (ChoiceDepreciation == 0)
            {
                LoadInvoiceDepreciationDetailGridviewFull();
                ChoiceDepreciation = 1;
            }
            else
            {
                Load_InvoiceDepreciationDetail_GridView();
            }
        }

        private void VoucherDetail_gridView_RowClick(object sender, RowClickEventArgs e)
        {
            // LoadInvoiceDepreciationDetailGridviewFull()
        }

        private void InvoiceDepreciationDetailSaveNew_simpleButton_Click(object sender, EventArgs e)
        {
            #region insert Khấu hao
            //1 hóa đơn có thể có nhiều phiếu kho
            if (!InvoiceDepreciationDetailAddNew_checkBox.Checked)
            {
                MessageBoxHelper.ShowErrorMessage("Vui lòng tick chọn thêm chi tiết khấu hao trước khi lưu mới!");
                return;
            }

            #region check so luong ky khau hao
            //select gaa.Sum(aa => aa.Quantity)).FirstOrDefault();
            var result = InvoiceDepreciationDetailData.Select(o => o.QuantityPeriod).Sum();
            if (result > GlobalVarient.InvoiceDepreciationsChoice.DepreciationMonth)
            {
                MessageBoxHelper.ShowErrorMessage("Số kỳ khấu hao chi tiết phải nhỏ hơn số kỳ khấu hao của hàng hóa!\n" + "Tổng số kỳ khấu hao của chi tiết: " + result.ToString() + "\nSố kỳ khấu hao của hàng hóa: " + GlobalVarient.InvoiceDepreciationsChoice.DepreciationMonth.ToString());
            }
            #endregion check so luong ky khau hao
            #region set DepreciationID to DepreciationDetail
            for (int i = 0; i < InvoiceDepreciationDetailData.Count; i++)
            {
                InvoiceDepreciationDetailData[i].CompanyID = GlobalVarient.CompanyIDChoice;
                InvoiceDepreciationDetailData[i].DepreciationID = GlobalVarient.InvoiceDepreciationsChoice.DepreciationID;
                InvoiceDepreciationDetailData[i].StatusA = ModifyMode.Insert;
            }
            #endregion set warehouseID to WareHouseDetail

            List<DepreciationDetail> saveData = this.InvoiceDepreciationDetailData.Where(o => o.StatusA == ModifyMode.Insert).ToList();
            if (saveData?.Count > 0)
            {
                DepreciationDetailController controller = new DepreciationDetailController();
                if (controller.SaveDepreciationDetail(saveData))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    InvoiceDepreciationDetailDelete = new List<DepreciationDetail>();
                    this.Load_InvoiceDepreciationDetail_GridView();
                }
                else
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

            #endregion insert Khấu hao chi tiết
        }

        private void InvoiceDepreciationDetailSave_simpleButton_Click(object sender, EventArgs e)
        {
            #region set DepreciationID to DepreciationDetail

            var result = InvoiceDepreciationDetailData.Select(o => o.QuantityPeriod).Sum();
            if (result > GlobalVarient.InvoiceDepreciationsChoice.DepreciationMonth)
            {
                MessageBoxHelper.ShowErrorMessage("Số kỳ khấu hao chi tiết phải nhỏ hơn số kỳ khấu hao của hàng hóa!\n" + "Tổng số kỳ khấu hao của chi tiết: " + result.ToString() + "\nSố kỳ khấu hao của hàng hóa: " + GlobalVarient.InvoiceDepreciationsChoice.DepreciationMonth.ToString());
                return;
            }


            for (int i = 0; i < InvoiceDepreciationDetailData.Count; i++)
            {
                if (string.IsNullOrEmpty(InvoiceDepreciationDetailData[i].DepreciationDetailID))
                {
                    InvoiceDepreciationDetailData[i].CompanyID = GlobalVarient.CompanyIDChoice;
                    InvoiceDepreciationDetailData[i].DepreciationID = GlobalVarient.InvoiceDepreciationsChoice.DepreciationID;
                    InvoiceDepreciationDetailData[i].StatusA = ModifyMode.Insert;
                }
            }
            #endregion  set DepreciationID to DepreciationDetail

            int checkAction = 0;

            List<DepreciationDetail> saveData = this.InvoiceDepreciationDetailData.Where(o => o.StatusA == ModifyMode.Insert || o.StatusA == ModifyMode.Update || o.StatusA == ModifyMode.Delete).ToList();
            if (saveData?.Count > 0)
            {
                //  InvoiceController controller = new InvoiceController();
                DepreciationDetailController controller = new DepreciationDetailController();
                if (controller.SaveDepreciationDetail(saveData))
                {
                    checkAction++;
                }
                else
                {
                    checkAction = 0;
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

            #region delete Depriciation detail
            if (InvoiceDepreciationDetailDelete?.Count > 0)
            {
                DepreciationDetailController controller = new DepreciationDetailController();
                if (controller.SaveDepreciationDetail(InvoiceDepreciationDetailDelete))
                {
                    checkAction++;
                }
                else
                {
                    checkAction = 0;
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

            if (checkAction > 0)
            {
                MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
            }
            #endregion delete Depriciation
            this.Load_InvoiceDepreciationDetail_GridView();
        }

        private void InvoiceDepreciationDetailDelete_simpleButton_Click(object sender, EventArgs e)
        {
            int[] selectIndex = InvoiceDepreciationDetail_gridView.GetSelectedRows();
            foreach (int index in selectIndex)
            {
                DepreciationDetail delete = InvoiceDepreciationDetail_gridView.GetRow(index) as DepreciationDetail;
                if (!string.IsNullOrEmpty(delete.DepreciationDetailID))
                {
                    InvoiceDepreciationDetailData[index].StatusA = ModifyMode.Delete;
                    InvoiceDepreciationDetailDelete.Add(delete);
                }
            }

            InvoiceDepreciationDetail_gridView.DeleteSelectedRows();
        }

        private void InvoiceWareHouse_gridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {

            if (GlobalVarient.invoiceChoice.InvoiceType.ToString() == "V")
            {
                InvoiceWareHouse_gridView.SetFocusedRowCellValue("Type", "N");
            }
            else
            {
                InvoiceWareHouse_gridView.SetFocusedRowCellValue("Type", "X");
            }

            InvoiceWareHouse_gridView.SetFocusedRowCellValue("Date", GlobalVarient.voucherChoice.Date);

        }

        private void InvoiceWareHouseDetail_gridView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            bool isNewRow = InvoiceWareHouseDetail_gridView.IsNewItemRow(e.RowHandle);
            if (isNewRow)
            {
                return;
            }

            WareHouseDetail row = e.Row as WareHouseDetail;
            if (row.Status == ModifyMode.Insert)
            {
                return;
            }
            row.Status = ModifyMode.Update;
        }

        private void InvoiceDepreciation_gridView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            bool isNewRow = InvoiceDepreciation_gridView.IsNewItemRow(e.RowHandle);
            if (isNewRow)
            {
                return;
            }

            Depreciation row = e.Row as Depreciation;
            if (row.StatusA == ModifyMode.Insert)
            {
                return;
            }
            row.StatusA = ModifyMode.Update;
        }




        private void InvoiceDepreciationDetail_gridView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            bool isNewRow = InvoiceDepreciationDetail_gridView.IsNewItemRow(e.RowHandle);
            if (isNewRow)
            {
                return;
            }

            DepreciationDetail row = e.Row as DepreciationDetail;
            if (row.StatusA == ModifyMode.Insert)
            {
                return;
            }
            row.StatusA = ModifyMode.Update;
        }

        private void InvoiceWareHouseDetailCalculator_simpleButton_Click(object sender, EventArgs e)
        {
            decimal TienCK = (decimal)InvoiceWareHouseDetailDiscount_textEdit.EditValue;

            decimal TienFullDetail = InvoiceWarehouseDetailData.Select(o => o.Amount).Sum();
            decimal PercentDiscount = TienCK * 100 / TienFullDetail;
            for (int i = 0; i < InvoiceWarehouseDetailData.Count; i++)
            {

                InvoiceWarehouseDetailData[i].Price = (InvoiceWarehouseDetailData[i].Amount - (InvoiceWarehouseDetailData[i].Amount * PercentDiscount / 100)) / InvoiceWarehouseDetailData[i].Quantity;

            }
            InvoiceWareHouseDetail_gridControl.RefreshDataSource();
            // InvoiceWareHouseDetail_gridControl.DataSource = InvoiceWarehouseDetailData;
        }

        private void simpleButton24_Click(object sender, EventArgs e)
        {

        }

        #region WareHouse tabpanel
        void LoadWareHouseGridviewFull()
        {
            InvoiceController invoicecontroller = new InvoiceController();
            GlobalVarient.invoices = invoicecontroller.GetInvoiceSelectVoucherID(GlobalVarient.voucherChoice.VouchersID, GlobalVarient.CompanyIDChoice);
            Init_WareHouse_GridView();
            Setup_WareHouse_GridView();
            Load_WareHouse_GridView();
        }

        private void Init_WareHouse_GridView()
        {
            this.WareHouse_gridView.Columns.Clear();
            this.WareHouse_gridView.AddColumn("Date", "Ngày", 80, false);

            List<ColumnInfo> columns = new List<ColumnInfo>
            {
                new ColumnInfo("InvoiceDate", "Ngày HĐ"),
                new ColumnInfo("CustomerID", "Mã KH" ),
                new ColumnInfo("InvoiceFormNo", "Mã số" ),
                new ColumnInfo("FormNo", "Mẫu số" ),
                new ColumnInfo("SerialNo", "Ký hiệu" ),
                new ColumnInfo("InvoiceNo", "Số HĐ" ),
                new ColumnInfo("Amount", "Tiền" ),
                new ColumnInfo("VAT", "% GTGT" ),
                new ColumnInfo("VATAmount", "Tiền VAT" ),
                new ColumnInfo("Discounts", "CK" ),
                new ColumnInfo("TotalAmount", "Tổng tiền" ),
                new ColumnInfo("InvoiceType", "Loại HĐ" ),
                new ColumnInfo("Description", "Mô tả" ),
                new ColumnInfo("CreateUser", "Người tạo" )
            };

            this.WareHouse_gridView.AddSearchLookupEditColumn("InvoiceID", "Hóa Đơn ID", 120, GlobalVarient.invoices, "InvoiceID", "InvoiceID", isAllowEdit: true, columns: columns);

            this.WareHouse_gridView.AddColumn("DeliverReceiver", "Người giao nhận", 80, true);
            this.WareHouse_gridView.AddColumn("Description", "Nội dung", 100, true);
            this.WareHouse_gridView.AddColumn("Attachfile", "File đính kèm", 60, true);
            this.WareHouse_gridView.AddSearchLookupEditColumn("GeneralLedgerID", "Sổ cái", 120, materialGL, "GeneralLedgerID", "GeneralLedgerName", isAllowEdit: true);
            this.WareHouse_gridView.AddSearchLookupEditColumn("Type", "Loại", 80, materialWareHouseType, "WareHouseTypeSummary", "WareHouseTypeSummary", isAllowEdit: false);
            this.WareHouse_gridView.AddSearchLookupEditColumn("DebitAccountID", "TK Nợ", 80, materialTK, "AccountID", "AccountID", isAllowEdit: true);
            this.WareHouse_gridView.AddSearchLookupEditColumn("CreditAccountID", "TK Có", 80, materialTK, "AccountID", "AccountID", isAllowEdit: true);
            this.WareHouse_gridView.AddSearchLookupEditColumn("CustomerID", "KH", 80, materialDT, "CustomerID", "CustomerSName", isAllowEdit: true);
            this.WareHouse_gridView.AddColumn("CreateUser", "Người tạo", 60, false);
        }

        private void Setup_WareHouse_GridView()
        {
            this.WareHouse_gridView.SetupGridView(multiSelect: true, checkBoxSelectorColumnWidth: 30);
            this.WareHouse_gridView.SetupGridView(columnAutoWidth: false);
            this.WareHouse_gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            this.WareHouse_gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
        }

        private void Load_WareHouse_GridView()
        {

            WareHouseController controller = new WareHouseController();
            GlobalVarient.warehouse = controller.GetWareHouseSelectVoucherID(GlobalVarient.voucherChoice.VouchersID, GlobalVarient.CompanyIDChoice);
            WarehouseData = new BindingList<WareHouse>(GlobalVarient.warehouse);
            WareHouse_gridControl.DataSource = WarehouseData;
            WareHouseDelete = new List<WareHouse>();
        }


        void LoadWareHouseDetailGridviewFull()
        {
            Init_WareHouseDetail_GridView();
            Setup_WareHouseDetail_GridView();
            Load_WareHouseDetail_GridView();
        }

        private void Init_WareHouseDetail_GridView()
        {
            this.WareHouseDetail_gridView.Columns.Clear();
            this.WareHouseDetail_gridView.AddColumn("ItemUnit", "ĐVT", 35, true);
            this.WareHouseDetail_gridView.AddSpinEditColumn("Quantity", "Số lượng", 60, true, "{0.00}", DevExpress.Data.SummaryItemType.Sum, "{0.00}");
            this.WareHouseDetail_gridView.AddSpinEditColumn("Price", "Đơn giá", 120, true, "c2");
            this.WareHouseDetail_gridView.AddSpinEditColumn("Amount", "Thành tiền", 110, true, "c2", DevExpress.Data.SummaryItemType.Sum, "{0:C}");
            this.WareHouseDetail_gridView.AddSearchLookupEditColumn("ItemID", "Sản phẩm", 80, items, "ItemID", "ItemSName", isAllowEdit: true, editValueChanged: WareHouseDetail_EditValueChanged);
        }

        private void Setup_WareHouseDetail_GridView()
        {
            this.WareHouseDetail_gridView.SetupGridView(multiSelect: true, showFooter: true, newItemRow: NewItemRowPosition.Top);
        }

        private void Load_WareHouseDetail_GridView()
        {
            WareHouseDetailController controller = new WareHouseDetailController();
            if (GlobalVarient.warehouseChoice == null || GlobalVarient.warehouseChoice.WarehouseID == null)
            {
                GlobalVarient.warehouseDetail = controller.GetWareHouseDetailSelectWahouseID("00000", GlobalVarient.CompanyIDChoice);
            }
            else
            {
                GlobalVarient.warehouseDetail = controller.GetWareHouseDetailSelectWahouseID(GlobalVarient.warehouseChoice.WarehouseID, GlobalVarient.CompanyIDChoice);
            }

            WarehouseDetailData = new BindingList<WareHouseDetail>(GlobalVarient.warehouseDetail);
            WareHouseDetail_gridControl.DataSource = WarehouseDetailData;
            WareHouseDetailDelete = new List<WareHouseDetail>();
        }


        public void WareHouseDetail_EditValueChanged(object sender, EventArgs e)
        {
            var selectRow = ((SearchLookUpEdit)sender).Properties.View.GetFocusedRow().CastTo<Items>();
            WareHouseDetail_gridView.SetFocusedRowCellValue("ItemUnit", selectRow.ItemUnit);
        }

        void Load_DepreciationGridviewFull()
        {
            Init_Depreciation_GridView();
            Setup_Depreciation_GridView();
            Load_Depreciation_GridView();
        }

        private void Init_Depreciation_GridView()
        {
            this.WareHouseDepreciation_gridView.Columns.Clear();
            this.WareHouseDepreciation_gridView.AddColumn("StartDate", "Ngày BĐSD", 80, true);
            this.WareHouseDepreciation_gridView.AddColumn("UseMonth", "Số tháng SD", 70, true);
            this.WareHouseDepreciation_gridView.AddColumn("DepreciationMonth", "Số tháng KH", 70, true);
            this.WareHouseDepreciation_gridView.AddColumn("CurrentMonth", "Tháng HT", 60, true);
            this.WareHouseDepreciation_gridView.AddSpinEditColumn("DepreciationAmount", "Tiền KH", 120, true, "C2");
            this.WareHouseDepreciation_gridView.AddSpinEditColumn("DepreciationAmountPerMonth", "Tiền/Tháng", 120, false, "C2");
        }

        private void Setup_Depreciation_GridView()
        {
            this.WareHouseDepreciation_gridView.SetupGridView(multiSelect: true, checkBoxSelectorColumnWidth: 30);
            this.WareHouseDepreciation_gridView.SetupGridView(columnAutoWidth: false);
            this.WareHouseDepreciation_gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            this.WareHouseDepreciation_gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
        }

        private void Load_Depreciation_GridView()
        {

            DepreciationController controller = new DepreciationController();
            if (GlobalVarient.warehouseDetailChoice == null || GlobalVarient.warehouseDetailChoice.WareHouseDetailID == null)
            {
                GlobalVarient.Depreciations = controller.GetDepreciationSelect("00000", GlobalVarient.CompanyIDChoice);
            }
            else
            {
                GlobalVarient.Depreciations = controller.GetDepreciationSelect(GlobalVarient.warehouseDetailChoice.WareHouseDetailID, GlobalVarient.CompanyIDChoice);
            }

            DepreciationData = new BindingList<Depreciation>(GlobalVarient.Depreciations);
            WareHouseDepreciation_gridControl.DataSource = DepreciationData;
            DepreciationDelete = new List<Depreciation>();
        }


        void Load_DepreciationDetailGridviewFull()
        {
            Init_DepreciationDetail_GridView();
            Setup_DepreciationDetail_GridView();
            Load_DepreciationDetail_GridView();
        }

        private void Init_DepreciationDetail_GridView()
        {
            this.DepreciationDetail_gridView.Columns.Clear();
            this.DepreciationDetail_gridView.AddColumn("PeriodCurrent", "kỳ HT", 40, true);
            this.DepreciationDetail_gridView.AddColumn("DepreciationDate", "Ngày của kỳ", 80, true);
            this.DepreciationDetail_gridView.AddColumn("QuantityPeriod", "SL kỳ", 40, true);
            this.DepreciationDetail_gridView.AddSpinEditColumn("Amount", "Tiền", 110, true, "C2");
            this.DepreciationDetail_gridView.AddColumn("Descriptions", "Nội dung", 120, true);
        }

        private void Setup_DepreciationDetail_GridView()
        {
            this.DepreciationDetail_gridView.SetupGridView(multiSelect: true, checkBoxSelectorColumnWidth: 30);
            this.DepreciationDetail_gridView.SetupGridView(columnAutoWidth: false);
            this.DepreciationDetail_gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            this.DepreciationDetail_gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
        }

        private void Load_DepreciationDetail_GridView()
        {

            DepreciationDetailController controller = new DepreciationDetailController();
            if (GlobalVarient.DepreciationsChoice == null || GlobalVarient.DepreciationsChoice.DepreciationID == null)
            {
                GlobalVarient.DepreciationsDetail = controller.GetDepreciationDetailSelect("00000", GlobalVarient.CompanyIDChoice);
            }
            else
            {
                GlobalVarient.DepreciationsDetail = controller.GetDepreciationDetailSelect(GlobalVarient.DepreciationsChoice.DepreciationID, GlobalVarient.CompanyIDChoice);
            }

            DepreciationDetailData = new BindingList<DepreciationDetail>(GlobalVarient.DepreciationsDetail);
            DepreciationDetail_gridControl.DataSource = DepreciationDetailData;
            DepreciationDetailDelete = new List<DepreciationDetail>();
        }

        #endregion WareHouse tabpanel


        int ChoiceWWareHouse = 0;
        private void WareHouse_gridView_RowClick(object sender, RowClickEventArgs e)
        {
            //InvoiceWareHouse_groupControl.Enabled = true;
            WareHouse wareHouse = WareHouse_gridView.GetRow(e.RowHandle).CastTo<WareHouse>();
            GlobalVarient.warehouseChoice = wareHouse;
            if (ChoiceWWareHouse == 0)
            {
                // LoadInvoiceWareHouseGridviewFull();
                LoadWareHouseDetailGridviewFull();
                ChoiceWWareHouse = 1;
            }
            else
            {
                // Load_InvoiceWareHouse_GridView();
                Load_WareHouseDetail_GridView();
            }
        }

        private void WareHouse_gridView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            bool isNewRow = WareHouse_gridView.IsNewItemRow(e.RowHandle);
            if (isNewRow)
            {
                return;
            }

            WareHouse row = e.Row as WareHouse;
            if (row.Status == ModifyMode.Insert)
            {
                return;
            }
            row.Status = ModifyMode.Update;
        }

        private void WWareHouseSaveNew_simpleButton_Click(object sender, EventArgs e)
        {
            #region insert Phiếu kho.
            //1 hóa đơn có thể có nhiều phiếu kho
            if (!WareHouse_checkBox.Checked)
            {
                MessageBoxHelper.ShowErrorMessage("Vui lòng tick chọn thêm phiếu kho trước khi lưu mới!");
                return;
            }
            #region set VoucherID to WareHouse
            for (int i = 0; i < WarehouseData.Count; i++)
            {
                WarehouseData[i].CompanyID = GlobalVarient.CompanyIDChoice;
                WarehouseData[i].VouchersID = GlobalVarient.voucherChoice.VouchersID;
                WarehouseData[i].Date = GlobalVarient.voucherChoice.Date;

                WarehouseData[i].Status = ModifyMode.Insert;
            }
            #endregion set VoucherID to invoice

            List<WareHouse> saveData = this.WarehouseData.Where(o => o.Status == ModifyMode.Insert).ToList();
            if (saveData?.Count > 0)
            {
                WareHouseController controller = new WareHouseController();
                if (controller.SaveWareHouse(saveData))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    WareHouseDelete = new List<WareHouse>();
                    this.LoadWareHouseGridviewFull();
                }
                else
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

            #endregion insert Phiếu kho.
        }

        private void WWareHouseSave_simpleButton_Click(object sender, EventArgs e)
        {
            #region set Voucher to WareHouse
            for (int i = 0; i < WarehouseData.Count; i++)
            {
                if (string.IsNullOrEmpty(WarehouseData[i].WarehouseID))
                {
                    WarehouseData[i].CompanyID = GlobalVarient.CompanyIDChoice;
                    WarehouseData[i].VouchersID = GlobalVarient.voucherChoice.VouchersID;
                    WarehouseData[i].Date = GlobalVarient.voucherChoice.Date;
                    WarehouseData[i].Status = ModifyMode.Insert;
                }
            }
            #endregion  set VoucherID to WareHouse

            int checkAction = 0;

            List<WareHouse> saveData = this.WarehouseData.Where(o => o.Status == ModifyMode.Insert || o.Status == ModifyMode.Update || o.Status == ModifyMode.Delete).ToList();
            if (saveData?.Count > 0)
            {
                //  InvoiceController controller = new InvoiceController();
                WareHouseController controller = new WareHouseController();
                if (controller.SaveWareHouse(saveData))
                {
                    checkAction++;
                }
                else
                {
                    checkAction = 0;
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

            #region delete Invoice
            if (WareHouseDelete?.Count > 0)
            {
                WareHouseController controller = new WareHouseController();
                if (controller.SaveWareHouse(WareHouseDelete))
                {
                    checkAction++;
                }
                else
                {
                    checkAction = 0;
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

            if (checkAction > 0)
            {
                MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
            }
            #endregion delete WareHouse
            this.Load_WareHouse_GridView();
        }

        private void WWareHouseDelete_simpleButton_Click(object sender, EventArgs e)
        {
            int[] selectIndex = WareHouse_gridView.GetSelectedRows();
            foreach (int index in selectIndex)
            {
                WareHouse delete = WareHouse_gridView.GetRow(index) as WareHouse;
                if (!string.IsNullOrEmpty(delete.WarehouseID))
                {
                    WarehouseData[index].Status = ModifyMode.Delete;
                    WareHouseDelete.Add(delete);
                }
            }

            WareHouse_gridView.DeleteSelectedRows();
        }

        private void WWareHouseCancel_simpleButton_Click(object sender, EventArgs e)
        {
            this.Load_WareHouse_GridView();
        }


        int ChoiceWWareHouseDetail = 0;

        private void WareHouseDetail_gridView_RowClick(object sender, RowClickEventArgs e)
        {
            WareHouseDepreciation_groupControl.Enabled = true;
            //WareHouseDepreciation_gridControl
            //LoadInvoiceDepreciationGridviewFull()
            WareHouseDetail wareHouseDetail = WareHouseDetail_gridView.GetRow(e.RowHandle).CastTo<WareHouseDetail>();
            GlobalVarient.warehouseDetailChoice = wareHouseDetail;
            GlobalVarient.DepreciationsChoice = null;
            if (ChoiceWWareHouseDetail == 0)
            {
                Load_DepreciationGridviewFull();
                Load_DepreciationDetailGridviewFull();
                ChoiceWWareHouseDetail = 1;
            }
            else
            {
                Load_Depreciation_GridView();
                Load_DepreciationDetail_GridView();
            }
        }

        private void WareHouseDetail_gridView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            bool isNewRow = WareHouseDetail_gridView.IsNewItemRow(e.RowHandle);
            if (isNewRow)
            {
                return;
            }

            WareHouseDetail row = e.Row as WareHouseDetail;
            if (row.Status == ModifyMode.Insert)
            {
                return;
            }
            row.Status = ModifyMode.Update;
        }


        private void WWareHouseDetailSaveNew_simpleButton_Click(object sender, EventArgs e)
        {
            #region insert chi tiết Kho
            //1 hóa đơn có thể có nhiều phiếu kho
            if (!WareHouseDetailAddNew_checkBox.Checked)
            {
                MessageBoxHelper.ShowErrorMessage("Vui lòng tick chọn thêm chi tiết Kho trước khi lưu mới!");
                return;
            }
            #region set warehouseID to WareHouseDetail
            for (int i = 0; i < WarehouseDetailData.Count; i++)
            {
                WarehouseDetailData[i].CompanyID = GlobalVarient.CompanyIDChoice;
                WarehouseDetailData[i].WarehouseID = GlobalVarient.warehouseChoice.WarehouseID;
                WarehouseDetailData[i].Status = ModifyMode.Insert;
            }
            #endregion set warehouseID to WareHouseDetail

            List<WareHouseDetail> saveData = this.WarehouseDetailData.Where(o => o.Status == ModifyMode.Insert).ToList();
            if (saveData?.Count > 0)
            {
                WareHouseDetailController controller = new WareHouseDetailController();
                if (controller.SaveWareHouseDetail(saveData))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    WareHouseDetailDelete = new List<WareHouseDetail>();

                    this.LoadWareHouseDetailGridviewFull();
                }
                else
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

            #endregion insert chi tiết kho
        }

        private void WWareHouseDetailSave_simpleButton_Click(object sender, EventArgs e)
        {
            #region set warehouseID to WareHouseDetail
            for (int i = 0; i < WarehouseDetailData.Count; i++)
            {
                if (string.IsNullOrEmpty(WarehouseDetailData[i].WareHouseDetailID))
                {
                    WarehouseDetailData[i].CompanyID = GlobalVarient.CompanyIDChoice;
                    WarehouseDetailData[i].WarehouseID = GlobalVarient.warehouseChoice.WarehouseID;
                    WarehouseDetailData[i].Status = ModifyMode.Insert;
                }
            }
            #endregion  set warehouseID to WareHouseDetail

            int checkAction = 0;

            List<WareHouseDetail> saveData = this.WarehouseDetailData.Where(o => o.Status == ModifyMode.Insert || o.Status == ModifyMode.Update || o.Status == ModifyMode.Delete).ToList();
            if (saveData?.Count > 0)
            {
                //  InvoiceController controller = new InvoiceController();
                WareHouseDetailController controller = new WareHouseDetailController();
                if (controller.SaveWareHouseDetail(saveData))
                {
                    checkAction++;
                }
                else
                {
                    checkAction = 0;
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

            #region delete warehouseDetail
            if (WareHouseDetailDelete?.Count > 0)
            {
                WareHouseDetailController controller = new WareHouseDetailController();
                if (controller.SaveWareHouseDetail(WareHouseDetailDelete))
                {
                    checkAction++;
                }
                else
                {
                    checkAction = 0;
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

            if (checkAction > 0)
            {
                MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
            }
            #endregion delete warehouseDetail
            this.Load_WareHouseDetail_GridView();
        }

        private void WWareHouseDetailDelete_simpleButton_Click(object sender, EventArgs e)
        {
            int[] selectIndex = WareHouseDetail_gridView.GetSelectedRows();
            foreach (int index in selectIndex)
            {
                WareHouseDetail delete = WareHouseDetail_gridView.GetRow(index) as WareHouseDetail;
                if (!string.IsNullOrEmpty(delete.WarehouseID))
                {
                    WarehouseDetailData[index].Status = ModifyMode.Delete;
                    WareHouseDetailDelete.Add(delete);
                }
            }

            WareHouseDetail_gridView.DeleteSelectedRows();
        }

        private void WWareHouseDetailCancel_simpleButton_Click(object sender, EventArgs e)
        {
            this.Load_WareHouse_GridView();
        }

        private void InvoiceWareHouseDetailCancel_simpleButton_Click(object sender, EventArgs e)
        {
            this.Load_InvoiceWareHouseDetail_GridView();
        }


        int WareHouseChoiceDepreciation = 0;

        private void WareHouseDepreciation_gridView_RowClick(object sender, RowClickEventArgs e)
        {
            // InvoiceDepreciationgroupControl.Enabled = true;
            //LoadInvoiceDepreciationGridviewFull()
            Depreciation depreciation = WareHouseDepreciation_gridView.GetRow(e.RowHandle).CastTo<Depreciation>();
            GlobalVarient.DepreciationsChoice = depreciation;
            if (WareHouseChoiceDepreciation == 0)
            {
                Load_DepreciationDetailGridviewFull();
                WareHouseChoiceDepreciation = 1;
            }
            else
            {
                Load_DepreciationDetail_GridView();
            }
        }

        private void WareHouseDepreciation_gridView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            bool isNewRow = WareHouseDepreciation_gridView.IsNewItemRow(e.RowHandle);
            if (isNewRow)
            {
                return;
            }

            Depreciation row = e.Row as Depreciation;
            if (row.StatusA == ModifyMode.Insert)
            {
                return;
            }
            row.StatusA = ModifyMode.Update;
        }



        private void WareHouseDepreciationSaveNew_simpleButton_Click(object sender, EventArgs e)
        {
            #region insert Khấu hao
            //1 hóa đơn có thể có nhiều phiếu kho
            if (!DepreciationAddNew_checkBox.Checked)
            {
                MessageBoxHelper.ShowErrorMessage("Vui lòng tick chọn thêm khấu hao trước khi lưu mới!");
                return;
            }
            #region set warehouseDetailID to Depreciation
            for (int i = 0; i < DepreciationData.Count; i++)
            {
                DepreciationData[i].CompanyID = GlobalVarient.CompanyIDChoice;
                DepreciationData[i].WareHouseDetailID = GlobalVarient.warehouseDetailChoice.WareHouseDetailID;
                DepreciationData[i].StatusA = ModifyMode.Insert;
            }
            #endregion set warehouseID to WareHouseDetail

            List<Depreciation> saveData = this.DepreciationData.Where(o => o.StatusA == ModifyMode.Insert).ToList();
            if (saveData?.Count > 0)
            {
                DepreciationController controller = new DepreciationController();
                if (controller.SaveDepreciation(saveData))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    DepreciationDelete = new List<Depreciation>();
                    this.Load_Depreciation_GridView();
                }
                else
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

            #endregion insert Khấu hao
        }

        private void WareHouseDepreciationSave_simpleButton_Click(object sender, EventArgs e)
        {
            #region set warehouseDetailID to Depreciation
            for (int i = 0; i < DepreciationData.Count; i++)
            {
                if (string.IsNullOrEmpty(DepreciationData[i].WareHouseDetailID))
                {
                    DepreciationData[i].CompanyID = GlobalVarient.CompanyIDChoice;
                    DepreciationData[i].WareHouseDetailID = GlobalVarient.warehouseDetailChoice.WareHouseDetailID;
                    DepreciationData[i].StatusA = ModifyMode.Insert;
                }
            }
            #endregion  set warehouseDetailID to Depreciation

            int checkAction = 0;

            List<Depreciation> saveData = this.DepreciationData.Where(o => o.StatusA == ModifyMode.Insert || o.StatusA == ModifyMode.Update || o.StatusA == ModifyMode.Delete).ToList();
            if (saveData?.Count > 0)
            {
                //  InvoiceController controller = new InvoiceController();
                DepreciationController controller = new DepreciationController();
                if (controller.SaveDepreciation(saveData))
                {
                    checkAction++;
                }
                else
                {
                    checkAction = 0;
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

            #region delete Depriciation
            if (InvoiceDepreciationDelete?.Count > 0)
            {
                DepreciationController controller = new DepreciationController();
                if (controller.SaveDepreciation(DepreciationDelete))
                {
                    checkAction++;
                }
                else
                {
                    checkAction = 0;
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

            if (checkAction > 0)
            {
                MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
            }
            #endregion delete Depriciation
            this.Load_Depreciation_GridView();
        }

        private void WareHouseDepreciationCancel_simpleButton_Click(object sender, EventArgs e)
        {
            this.Load_Depreciation_GridView();
        }

        private void WareHouseDepreciationDetailSaveNew_simpleButton_Click(object sender, EventArgs e)
        {
            #region insert Khấu hao
            //1 hóa đơn có thể có nhiều phiếu kho
            if (!DepreciationDetailAddNew_checkBox.Checked)
            {
                MessageBoxHelper.ShowErrorMessage("Vui lòng tick chọn thêm chi tiết khấu hao trước khi lưu mới!");
                return;
            }

            #region check so luong ky khau hao
            //select gaa.Sum(aa => aa.Quantity)).FirstOrDefault();
            var result = DepreciationDetailData.Select(o => o.QuantityPeriod).Sum();
            if (result > GlobalVarient.DepreciationsChoice.DepreciationMonth)
            {
                MessageBoxHelper.ShowErrorMessage("Số kỳ khấu hao chi tiết phải nhỏ hơn số kỳ khấu hao của hàng hóa!\n" + "Tổng số kỳ khấu hao của chi tiết: " + result.ToString() + "\nSố kỳ khấu hao của hàng hóa: " + GlobalVarient.InvoiceDepreciationsChoice.DepreciationMonth.ToString());
            }
            #endregion check so luong ky khau hao
            #region set DepreciationID to DepreciationDetail
            for (int i = 0; i < DepreciationDetailData.Count; i++)
            {
                DepreciationDetailData[i].CompanyID = GlobalVarient.CompanyIDChoice;
                DepreciationDetailData[i].DepreciationID = GlobalVarient.DepreciationsChoice.DepreciationID;
                DepreciationDetailData[i].StatusA = ModifyMode.Insert;
            }
            #endregion set warehouseID to WareHouseDetail

            List<DepreciationDetail> saveData = this.DepreciationDetailData.Where(o => o.StatusA == ModifyMode.Insert).ToList();
            if (saveData?.Count > 0)
            {
                DepreciationDetailController controller = new DepreciationDetailController();
                if (controller.SaveDepreciationDetail(saveData))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    DepreciationDetailDelete = new List<DepreciationDetail>();
                    this.Load_DepreciationDetail_GridView();
                }
                else
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }
            #endregion insert khấu hao detail
        }

        private void WareHouseDepreciationDetailSave_simpleButton_Click(object sender, EventArgs e)
        {
            #region set DepreciationID to DepreciationDetail

            var result = DepreciationDetailData.Select(o => o.QuantityPeriod).Sum();
            if (result > GlobalVarient.DepreciationsChoice.DepreciationMonth)
            {
                MessageBoxHelper.ShowErrorMessage("Số kỳ khấu hao chi tiết phải nhỏ hơn số kỳ khấu hao của hàng hóa!\n" + "Tổng số kỳ khấu hao của chi tiết: " + result.ToString() + "\nSố kỳ khấu hao của hàng hóa: " + GlobalVarient.InvoiceDepreciationsChoice.DepreciationMonth.ToString());
                return;
            }


            for (int i = 0; i < DepreciationDetailData.Count; i++)
            {
                if (string.IsNullOrEmpty(DepreciationDetailData[i].DepreciationDetailID))
                {
                    DepreciationDetailData[i].CompanyID = GlobalVarient.CompanyIDChoice;
                    DepreciationDetailData[i].DepreciationID = GlobalVarient.DepreciationsChoice.DepreciationID;
                    DepreciationDetailData[i].StatusA = ModifyMode.Insert;
                }
            }
            #endregion  set DepreciationID to DepreciationDetail

            int checkAction = 0;

            List<DepreciationDetail> saveData = this.DepreciationDetailData.Where(o => o.StatusA == ModifyMode.Insert || o.StatusA == ModifyMode.Update || o.StatusA == ModifyMode.Delete).ToList();
            if (saveData?.Count > 0)
            {
                //  InvoiceController controller = new InvoiceController();
                DepreciationDetailController controller = new DepreciationDetailController();
                if (controller.SaveDepreciationDetail(saveData))
                {
                    checkAction++;
                }
                else
                {
                    checkAction = 0;
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

            #region delete Depriciation detail
            if (DepreciationDetailDelete?.Count > 0)
            {
                DepreciationDetailController controller = new DepreciationDetailController();
                if (controller.SaveDepreciationDetail(DepreciationDetailDelete))
                {
                    checkAction++;
                }
                else
                {
                    checkAction = 0;
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

            if (checkAction > 0)
            {
                MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
            }
            #endregion delete Depriciation
            this.Load_DepreciationDetail_GridView();
        }

        private void WareHouseDepreciationDetailDelete_simpleButton_Click(object sender, EventArgs e)
        {
            int[] selectIndex = DepreciationDetail_gridView.GetSelectedRows();
            foreach (int index in selectIndex)
            {
                DepreciationDetail delete = DepreciationDetail_gridView.GetRow(index) as DepreciationDetail;
                if (!string.IsNullOrEmpty(delete.DepreciationDetailID))
                {
                    DepreciationDetailData[index].StatusA = ModifyMode.Delete;
                    DepreciationDetailDelete.Add(delete);
                }
            }

            DepreciationDetail_gridView.DeleteSelectedRows();
        }

        private void WareHouseDepreciationDetailCancel_simpleButton_Click(object sender, EventArgs e)
        {
            this.Load_DepreciationDetail_GridView();
        }

        private void InvoiceDepreciationDetailCancel_simpleButton_Click(object sender, EventArgs e)
        {
            this.Load_InvoiceDepreciationDetail_GridView();
        }



        private void InvoiceWareHouseDetail_gridView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.Column.FieldName == "Amount")
            {
                decimal QuantityFilter = (Decimal)InvoiceWareHouseDetail_gridView.GetFocusedRowCellValue("Quantity");

                if (QuantityFilter > 0)
                {

                    Decimal Cellprice = (Decimal)InvoiceWareHouseDetail_gridView.GetFocusedRowCellValue("Amount") / QuantityFilter;

                    if (Cellprice != (Decimal)InvoiceWareHouseDetail_gridView.GetFocusedRowCellValue("Price"))
                    {
                        InvoiceWareHouseDetail_gridView.SetFocusedRowCellValue("Price", Cellprice);
                    }
                }
                else
                {
                    MessageBoxHelper.ShowInfoMessage("Số lượng phải lớn hơn 0!");
                    return;
                }

            }
            else if (e.Column.FieldName == "Price")
            {
                Decimal Cellprice = (Decimal)InvoiceWareHouseDetail_gridView.GetFocusedRowCellValue("Price") * (Decimal)InvoiceWareHouseDetail_gridView.GetFocusedRowCellValue("Quantity");
                if (Cellprice != (Decimal)InvoiceWareHouseDetail_gridView.GetFocusedRowCellValue("Amount"))
                {
                    InvoiceWareHouseDetail_gridView.SetFocusedRowCellValue("Amount", Cellprice);
                }
            }
            // Decimal cellValueAmount = (Decimal)e.Value;

        }

        private void InvoiceDepreciation_gridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            InvoiceDepreciation_gridView.SetFocusedRowCellValue("DepreciationAmount", GlobalVarient.warehouseDetailInvoiceChoice.Amount);
        }

        private void InvoiceDepreciationDetail_gridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            int SoLuongKy = (int)InvoiceDepreciationDetail_gridView.GetFocusedRowCellValue("QuantityPeriod");
            Decimal totalamount = SoLuongKy * GlobalVarient.InvoiceDepreciationsChoice.DepreciationAmountPerMonth;

            InvoiceDepreciationDetail_gridView.SetFocusedRowCellValue("Amount", totalamount);
        }

        private void InvoiceDepreciationDetail_gridView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.Column.FieldName != "QuantityPeriod") return;
            if (e.Column.FieldName == "QuantityPeriod")
            {
                int SoLuongKy = (int)InvoiceDepreciationDetail_gridView.GetFocusedRowCellValue("QuantityPeriod");
                Decimal totalamount = SoLuongKy * GlobalVarient.InvoiceDepreciationsChoice.DepreciationAmountPerMonth;

                InvoiceDepreciationDetail_gridView.SetFocusedRowCellValue("Amount", totalamount);
            }
        }

        void ResetDatagridviewinvoice()
        {
            ////warehouse
            ///
            //GlobalVarient.warehouse = null;
            //WarehouseData = new BindingList<WareHouse>(GlobalVarient.warehouse);
            //WareHouse_gridControl.DataSource = WarehouseData;
            ///warehouseDetail
            ///depreciation
            ///depreciationDetail
        }

        private void Voucher_gridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            VoucherDetail_groupControl.Enabled = true;
            Voucher voucher = Voucher_gridView.GetFocusedRow().CastTo<Voucher>();
            if (voucher == null)
            {
                return;
            }
            LoadVoucherDetailGridView(voucher.VouchersID);
            richTextBoxVoucherContent.Text = voucher.Description;
            dateEditNgayNhapChungTu.EditValue = voucher.Date;
            VoucherTypeDK_searchLookUpEdit.EditValue = voucher.VouchersTypeID;
            GlobalVarient.VoucherIDChoice = voucher.VouchersID;
            GlobalVarient.voucherChoice = voucher;
            Voucher_gridView.FocusRectStyle = DrawFocusRectStyle.RowFocus;


        }

        private void Invoice_gridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {

            InvoiceWareHouse_groupControl.Enabled = true;
            // Invoice invoice = Invoice_gridView.GetRow(e.RowHandle).CastTo<Invoice>();
            Invoice invoice = Invoice_gridView.GetFocusedRow().CastTo<Invoice>();
            if (invoice == null)
            {
                return;
            }
            GlobalVarient.invoiceChoice = invoice;
            if (ChoiceInvoice == 0)
            {
                LoadInvoiceWareHouseGridviewFull();
                ChoiceInvoice = 1;
            }
            else
            {
                Load_InvoiceWareHouse_GridView();
            }

        }

        private void InvoiceWareHouse_gridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {

            WareHouse wareHouse = InvoiceWareHouse_gridView.GetFocusedRow().CastTo<WareHouse>();
            //if (wareHouse == null)
            //{
            //    return;
            //}

            GlobalVarient.warehouseInvoiceChoice = wareHouse;
            if (ChoiceWareHouse == 0)
            {
                // LoadInvoiceWareHouseGridviewFull();
                LoadInvoiceWareHouseDetailGridviewFull();
                ChoiceWareHouse = 1;
            }
            else
            {
                // Load_InvoiceWareHouse_GridView();
                Load_InvoiceWareHouseDetail_GridView();
            }
        }

        private void WareHouseDetail_gridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            WareHouseDepreciation_groupControl.Enabled = true;
            //WareHouseDepreciation_gridControl
            //LoadInvoiceDepreciationGridviewFull()
            WareHouseDetail wareHouseDetail = WareHouseDetail_gridView.GetFocusedRow().CastTo<WareHouseDetail>();


            GlobalVarient.warehouseDetailChoice = wareHouseDetail;
            GlobalVarient.DepreciationsChoice = null;
            if (ChoiceWWareHouseDetail == 0)
            {
                Load_DepreciationGridviewFull();
                Load_DepreciationDetailGridviewFull();
                ChoiceWWareHouseDetail = 1;
            }
            else
            {
                Load_Depreciation_GridView();
                Load_DepreciationDetail_GridView();
            }
        }

        private void WareHouseDepreciation_gridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            Depreciation depreciation = WareHouseDepreciation_gridView.GetFocusedRow().CastTo<Depreciation>();


            GlobalVarient.DepreciationsChoice = depreciation;
            if (WareHouseChoiceDepreciation == 0)
            {
                Load_DepreciationDetailGridviewFull();
                WareHouseChoiceDepreciation = 1;
            }
            else
            {
                Load_DepreciationDetail_GridView();
            }
        }

        private void WareHouse_gridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            WareHouse wareHouse = WareHouse_gridView.GetFocusedRow().CastTo<WareHouse>();


            GlobalVarient.warehouseChoice = wareHouse;
            if (ChoiceWWareHouse == 0)
            {
                // LoadInvoiceWareHouseGridviewFull();
                LoadWareHouseDetailGridviewFull();
                ChoiceWWareHouse = 1;
            }
            else
            {
                // Load_InvoiceWareHouse_GridView();
                Load_WareHouseDetail_GridView();
            }
        }

        private void WWareHouseDetailCalculator_simpleButton_Click(object sender, EventArgs e)
        {

            decimal TienCK = (decimal)WareHouseDetailDiscount_textEdit.EditValue;

            decimal TienFullDetail = WarehouseDetailData.Select(o => o.Amount).Sum();
            decimal PercentDiscount = TienCK * 100 / TienFullDetail;
            for (int i = 0; i < WarehouseDetailData.Count; i++)
            {

                WarehouseDetailData[i].Price = (WarehouseDetailData[i].Amount - (WarehouseDetailData[i].Amount * PercentDiscount / 100)) / WarehouseDetailData[i].Quantity;
                WarehouseDetailData[i].Amount = WarehouseDetailData[i].Price * WarehouseDetailData[i].Quantity;
                WarehouseDetailData[i].Status = ModifyMode.Update;

            }
            WareHouseDetail_gridControl.RefreshDataSource();
        }

        private void InvoiceWareHouseDetail_gridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            InvoiceDepreciationgroupControl.Enabled = true;
            //LoadInvoiceDepreciationGridviewFull()
            WareHouseDetail wareHouseDetail = InvoiceWareHouseDetail_gridView.GetFocusedRow().CastTo<WareHouseDetail>();
            GlobalVarient.warehouseDetailInvoiceChoice = wareHouseDetail;
            GlobalVarient.InvoiceDepreciationsChoice = null;
            if (ChoiceWareHouseDetail == 0)
            {
                LoadInvoiceDepreciationGridviewFull();
                LoadInvoiceDepreciationDetailGridviewFull();
                ChoiceWareHouseDetail = 1;
            }
            else
            {
                Load_InvoiceDepreciation_GridView();
                Load_InvoiceDepreciationDetail_GridView();
            }
        }

        private void InvoiceDepreciation_gridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            Depreciation depreciation = InvoiceDepreciation_gridView.GetFocusedRow().CastTo<Depreciation>();
            GlobalVarient.InvoiceDepreciationsChoice = depreciation;
            if (ChoiceDepreciation == 0)
            {
                LoadInvoiceDepreciationDetailGridviewFull();
                ChoiceDepreciation = 1;
            }
            else
            {
                Load_InvoiceDepreciationDetail_GridView();
            }
        }

        private void VoucherDetail_gridView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
          
        }

        private void Invoice_gridView_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            //check trung số hóa đơn trên database
            GridView view = sender as GridView;
            GridColumn columnInvoiceNo = view.Columns["InvoiceNo"];
            Invoice row = (e.Row as Invoice);
            if (!string.IsNullOrEmpty(row.InvoiceNo) && !string.IsNullOrEmpty(row.InvoiceFormNo) && !string.IsNullOrEmpty(row.FormNo) && !string.IsNullOrEmpty(row.SerialNo))
            {
                //Kiểm tra trùng số hóa đơn
                MaterialNVController controller = new MaterialNVController();
                List<MaterialCheck> MaterialCheckData = controller.GetMaterialCheckInvoiceNo(row.InvoiceID,row.CustomerID.ToString(),row.InvoiceFormNo,row.FormNo,row.SerialNo,row.InvoiceNo) ;
                bool msgCode = MaterialCheckData.Exists(s => s.msgCode == "0");
                if (msgCode)
                {
                    e.Valid = false;
                    view.SetColumnError(columnInvoiceNo, MaterialCheckData[0].msgName.ToString());
                }
            }

            // check trên grid hiện tại
            // Group the children by their parentId
            var result = InvoiceData.GroupBy(x => new { x.CustomerID, x.InvoiceFormNo, x.FormNo,x.SerialNo,x.InvoiceNo })
                                 .Select(x => new { CustomerID = x.First(), InvoiceFormNo = x.First(), FormNo= x.First(), SerialNo = x.First(), InvoiceNo = x.First(), Count = x.Count() }).ToList();
            for(int i = 0; i < result.Count; i++)
            {
                if (result[i].Count > 1)
                {
                    e.Valid = false;
                    view.SetColumnError(columnInvoiceNo,"Trùng số hóa đơn!");
                }
            }
        }
    }
}

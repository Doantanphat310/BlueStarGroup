﻿using System;
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

        public BindingList<Depreciation> InvoiceDepreciationData { get; set; }
        public BindingList<DepreciationDetail> InvoiceDepreciationDetailData { get; set; }

        public List<Voucher> VoucherDelete { get; set; }
        public List<VoucherDetail> VoucherDetailDelete { get; set; }
        public List<Invoice> InvoiceDelete { get; set; }
       // public List<WareHouse> WareHouseDelete { get; set; }
        public List<WareHouse> InvoiceWareHouseDelete { get; set; }
        public List<WareHouseDetail> InvoiceWareHouseDetailDelete { get; set; }
        public List<Depreciation> InvoiceDepreciationDelete { get; set; }
        public List<DepreciationDetail> InvoiceDepreciationDetailDelete { get; set; }

        public static MaterialNVController MaterialGL = new MaterialNVController();
        List<MaterialGL> materialGL = MaterialGL.GetMaterialGL(GlobalVarient.CompanyIDChoice);
        public static  MaterialNVController MaterialNV = new MaterialNVController();
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
            initControltoGridview();
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

        void initControltoGridview()
        {


            riLookup.DataSource = materialNV;
            riLookup.NullText = "";
            riLookup.ValueMember = "NVSummary";
            riLookup.DisplayMember = "NVName";
            VoucherDetail_gridControl.RepositoryItems.Add(riLookup);
            VoucherDetail_gridView.Columns["NV"].ColumnEdit = riLookup;
            riLookup.Popup += new EventHandler(riLookup_Popup);
            ////////////////////////////////////
            /// //TaiKhoan

            rsItemlookup.DataSource = materialTK;
            rsItemlookup.NullText = "";
            rsItemlookup.ValueMember = "AccountID";
            rsItemlookup.DisplayMember = "AccountID";
            VoucherDetail_gridControl.RepositoryItems.Add(rsItemlookup);
            VoucherDetail_gridView.Columns["AccountID"].ColumnEdit = rsItemlookup;
            rsItemlookup.Popup += new EventHandler(rsItemlookup_Popup);
            this.rsItemlookup.KeyDown += new KeyEventHandler(this.rsItemlookup_KeyDown);
            VoucherDetail_gridView.BestFitColumns();
            ///Doi Tuong
            ///
            //MaterialNVController MaterialDT = new MaterialNVController();
            //List<MaterialDT> materialDT = MaterialDT.GetMaterialDT(GlobalVarient.CompanyIDChoice);
            //rDTLookup.DataSource = materialDT;
            //rDTLookup.NullText = "";
            //rDTLookup.ValueMember = "CustomerID";
            //rDTLookup.DisplayMember = "CustomerSName";
            //VoucherDetail_gridControl.RepositoryItems.Add(rDTLookup);
            //VoucherDetail_gridView.Columns["CustomerID"].ColumnEdit = rDTLookup;
            //VoucherDetail_gridView.BestFitColumns();
            //rDTLookup.Popup += new EventHandler(rDTLookup_Popup);
            ///So cai
            ///

            rGLLookup.DataSource = materialGL;
            rGLLookup.NullText = "";
            rGLLookup.ValueMember = "GeneralLedgerID";
            rGLLookup.DisplayMember = "GeneralLedgerName";
            VoucherDetail_gridControl.RepositoryItems.Add(rGLLookup);
            VoucherDetail_gridView.Columns["GeneralLedgerID"].ColumnEdit = rGLLookup;
            VoucherDetail_gridView.BestFitColumns();
            rGLLookup.Popup += new EventHandler(rGLLookup_Popup);
        }



        private void VoucherControl_Load(object sender, EventArgs e)
        {
        }
        #region init design
        private void InitGridView()
        {
            this.Voucher_gridView.Columns.Clear();
            this.Voucher_gridView.AddColumn("VouchersTypeID", "Loại CT", 50, false);
            this.Voucher_gridView.AddColumn("VouchersID", "CT ID", 100, false);
            this.Voucher_gridView.AddColumn("Date", "Ngày", 100, false);
            this.Voucher_gridView.AddSpinEditColumn("Amount", "Tiền", 100, false, "c2");
            this.Voucher_gridView.AddColumn("Description", "Nội dung", 100, false);
            this.Voucher_gridView.AddColumn("CreateUser", "Người tạo", 100, false);
        }

        private void SetupGridView()
        {
            this.Voucher_gridView.SetupGridView(multiSelect: true, checkBoxSelectorColumnWidth: 30);
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
            this.VoucherDetail_gridView.AddColumn("NV", "NV", 50, true);
            this.VoucherDetail_gridView.AddColumn("AccountID", "Tài khoản", 80, true);
            //this.VoucherDetail_gridView.AddColumn("CustomerID", "Đối tượng", 120, true);

            this.VoucherDetail_gridView.AddSearchLookupEditColumn(
                "CustomerID", "Mã KH", 120, materialDT, "CustomerID", "CustomerSName", true, editValueChanged: Customer_EditValueChanged);
            this.VoucherDetail_gridView.AddColumn("GeneralLedgerID", "Sổ cái", 180, true);
            this.VoucherDetail_gridView.AddSpinEditColumn("Amount", "Tiền", 100, true, "$#,##0.00");
            this.VoucherDetail_gridView.AddColumn("VouchersDetailID", "DKID", 80, false);

           
            //MaterialNVController MaterialDT = new MaterialNVController();
            //List<MaterialDT> materialDT = MaterialDT.GetMaterialDT(GlobalVarient.CompanyIDChoice);
            //rDTLookup.DataSource = materialDT;
            //rDTLookup.NullText = "";
            //rDTLookup.ValueMember = "CustomerID";
            //rDTLookup.DisplayMember = "CustomerSName";
            //VoucherDetail_gridControl.RepositoryItems.Add(rDTLookup);
            //VoucherDetail_gridView.Columns["CustomerID"].ColumnEdit = rDTLookup;
            //VoucherDetail_gridView.BestFitColumns();
            //rDTLookup.Popup += new EventHandler(rDTLookup_Popup);
        }

        public void Customer_EditValueChanged(object sender, EventArgs e)
        {
            var selectRow = ((SearchLookUpEdit)sender).Properties.View.GetFocusedRow().CastTo<MaterialDT>();
            // Muon lay gi ra thif dung selectRow.
        }


        private void SetupVoucherDetailGridView()
        {
            this.VoucherDetail_gridView.SetupGridView(multiSelect: true, checkBoxSelectorColumnWidth: 30);
            this.VoucherDetail_gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            this.VoucherDetail_gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
        }

        private void LoadVoucherDetailGridView(string voucherID)
        {
            tabNavigationPageLKKho.PageVisible = false;
            tabNavigationPageLKVAT.PageVisible = false;
            VoucherDetailController controller = new VoucherDetailController();
            GlobalVarient.voucherDetailChoice = controller.GetVouchersDetailSelectVoucherID(voucherID, GlobalVarient.CompanyIDChoice);
            //  VoucherDetailData = new BindingList<VoucherDetail>(controller.GetVouchersDetailSelectVoucherID(voucherID, GlobalVarient.CompanyIDChoice));
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
            if (Debit != credit)
            {
                MessageBoxHelper.ShowErrorMessage("Tổng tiền nợ có phải bằng nhau!\n" + "N: " + Debit.ToString() + "\nC: " + credit.ToString());
                return;
            }

            #region set value to Insert Voucher
            VoucherController voucherController = new VoucherController();
            GlobalVarient.VoucherID++;
            Voucher voucher = new Voucher();
            //  voucher.VouchersID = "VOU" + DateTime.Now.ToString("yyyyMMddhhmmssff") + GlobalVarient.VoucherID.ToString();
            voucher.Amount = Debit;
            voucher.Description = richTextBoxVoucherContent.Text.ToString().Trim();
            voucher.VouchersTypeID = VoucherTypeDK_searchLookUpEdit.EditValue.ToString();
            voucher.Date = (DateTime)dateEditNgayNhapChungTu.EditValue;
            voucher.CompanyID = GlobalVarient.CompanyIDChoice;
            voucher.Status = ModifyMode.Insert;
            //  voucherController.InsertVouchers(voucher);
            //  LoadGridView();
            #endregion set value to Insert Voucher

            #region set VoucherDetailID
            VoucherDetailController voucherDetailController = new VoucherDetailController();
            for (int i = 0; i < VoucherDetailData.Count; i++)
            {
                // VoucherDetailData[i].VouchersID = voucher.VouchersID;
                // GlobalVarient.VoucherDetailID++;
                // VoucherDetailData[i].VouchersDetailID = "VOD" + DateTime.Now.ToString("yyyyMMddhhmmssff") + GlobalVarient.VoucherDetailID.ToString();
                VoucherDetailData[i].CompanyID = GlobalVarient.CompanyIDChoice;
                VoucherDetailData[i].Status = ModifyMode.Insert;
                //voucherDetailController.InsertVouchersDetail(VoucherDetailData[i]);
            }
            #endregion set VoucherDetailID

            List<VoucherDetail> saveData = this.VoucherDetailData.Where(o => o.Status == ModifyMode.Insert).ToList();
            if (saveData?.Count > 0)
            {
                VoucherDetailController controller = new VoucherDetailController();
                if (controller.SaveVoucher_Detail(saveData, voucher))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    VoucherDetailDelete = new List<VoucherDetail>();
                    this.LoadVoucherDetailGridView(voucher.VouchersID);
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

            // Role_UserName_TextBox.Text = selectedRow.UserID;

            // filter grid
            // UserRole_GridView.ActiveFilterString = $"[UserID] = '{selectedRow.UserID}'";
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
                else
                {
                    e.Valid = true;
                    // view.Appearance.Row.BackColor = Color.White;
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

        private void VoucherDetail_gridView_RowStyle(object sender, RowStyleEventArgs e)
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

        private void VoucherDetail_gridView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
        }

        private void VoucherDetail_gridView_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {

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
            this.InvoiceWareHouse_gridView.AddSearchLookupEditColumn("GeneralLedgerID", "Sổ cái", 120, materialGL, "GeneralLedgerID", "GeneralLedgerName", true);
            this.InvoiceWareHouse_gridView.AddSearchLookupEditColumn("Type", "Loại", 80, materialWareHouseType, "WareHouseTypeSummary", "WareHouseTypeSummary", true);
            this.InvoiceWareHouse_gridView.AddSearchLookupEditColumn("DebitAccountID", "TK Nợ", 80, materialTK, "AccountID", "AccountID", true);
            this.InvoiceWareHouse_gridView.AddSearchLookupEditColumn("CreditAccountID", "TK Có", 80, materialTK, "AccountID", "AccountID", true);
            this.InvoiceWareHouse_gridView.AddSearchLookupEditColumn("CustomerID", "KH", 80, materialDT, "CustomerID", "CustomerSName", true);
            this.InvoiceWareHouse_gridView.AddColumn("DeliverReceiver", "Người giao nhận", 80, true);
            this.InvoiceWareHouse_gridView.AddColumn("Description", "Nội dung", 100, true);
            this.InvoiceWareHouse_gridView.AddColumn("Attachfile", "File đính kèm", 60, true);
            this.InvoiceWareHouse_gridView.AddColumn("CreateUser", "Người tạo", 60, false);
        }

        private void Setup_InvoiceWareHouse_GridView()
        {
            this.InvoiceWareHouse_gridView.SetupGridView(multiSelect: true, checkBoxSelectorColumnWidth: 30);
            this.InvoiceWareHouse_gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            this.InvoiceWareHouse_gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
        }

        private void Load_InvoiceWareHouse_GridView()
        {
            WareHouseController controller = new WareHouseController();
            GlobalVarient.warehouseInvoice = controller.GetWareHouseSelectInvoiceID(GlobalVarient.invoiceChoice.InvoiceID, GlobalVarient.CompanyIDChoice);
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
            this.InvoiceDepreciation_gridView.AddColumn("UseMonth", "Số tháng SD", 80, true);
            this.InvoiceDepreciation_gridView.AddColumn("DepreciationMonth", "Số tháng KH", 80, true);
            this.InvoiceDepreciation_gridView.AddColumn("CurrentMonth", "Tháng HT", 80, true);
            this.InvoiceDepreciation_gridView.AddColumn("DepreciationAmount", "Tiền KH", 80, true);
            this.InvoiceDepreciation_gridView.AddColumn("DepreciationPercent", "% KH", 80, true);
            this.InvoiceDepreciation_gridView.AddColumn("DepreciationAmountMonth", "Tiền/Tháng", 80, false);

        }

        private void Setup_InvoiceDepreciation_GridView()
        {
            this.InvoiceDepreciation_gridView.SetupGridView(multiSelect: true, checkBoxSelectorColumnWidth: 30);
            this.InvoiceDepreciation_gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            this.InvoiceDepreciation_gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
        }

        private void Load_InvoiceDepreciation_GridView()
        {

            DepreciationController controller = new DepreciationController();
            GlobalVarient.InvoiceDepreciations = controller.GetDepreciationSelect(GlobalVarient.warehouseDetailInvoiceChoice.WareHouseDetailID, GlobalVarient.CompanyIDChoice);
            InvoiceDepreciationData = new BindingList<Depreciation>(GlobalVarient.InvoiceDepreciations);
            InvoiceWareHouseDetail_gridControl.DataSource = InvoiceDepreciationData;
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
            this.InvoiceDepreciationDetail_gridView.AddColumn("PeriodCurrent", "kỳ HT", 80, true);
            this.InvoiceDepreciationDetail_gridView.AddColumn("DepreciationDate", "Ngày của kỳ", 80, true);
            this.InvoiceDepreciationDetail_gridView.AddColumn("QuantityPeriod", "Số lượng kỳ", 80, true);
            this.InvoiceDepreciationDetail_gridView.AddColumn("Amount", "Tiền", 80, true);
            this.InvoiceDepreciationDetail_gridView.AddColumn("Descriptions", "Nội dung", 80, true);

        }

        private void Setup_InvoiceDepreciationDetail_GridView()
        {
            this.InvoiceDepreciationDetail_gridView.SetupGridView(multiSelect: true, checkBoxSelectorColumnWidth: 30);
            this.InvoiceDepreciationDetail_gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            this.InvoiceDepreciationDetail_gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
        }

        private void Load_InvoiceDepreciationDetail_GridView()
        {

            DepreciationDetailController controller = new DepreciationDetailController();
            GlobalVarient.InvoiceDepreciationsDetail = controller.GetDepreciationDetailSelect(GlobalVarient.InvoiceDepreciationsChoice.DepreciationID, GlobalVarient.CompanyIDChoice);
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
            this.InvoiceWareHouseDetail_gridView.AddSearchLookupEditColumn("ItemID", "Sản phẩm", 80, items,"ItemID", "ItemSName", true, editValueChanged: invoiceWareHouseDetail_EditValueChanged);
       
            this.InvoiceWareHouseDetail_gridView.AddColumn("ItemUnit", "ĐVT", 80, false);
            
            this.InvoiceWareHouseDetail_gridView.AddColumn("Quantity", "Số lượng", 120, true);
           
            this.InvoiceWareHouseDetail_gridView.AddColumn("Price", "Đơn giá", 80, true);
            this.InvoiceWareHouseDetail_gridView.AddColumn("Amount", "Thành tiền", 80, true);

        }

        private void Setup_InvoiceWareHouseDetail_GridView()
        {
            this.InvoiceWareHouseDetail_gridView.SetupGridView(multiSelect: true, checkBoxSelectorColumnWidth: 30);
            this.InvoiceWareHouseDetail_gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            this.InvoiceWareHouseDetail_gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
        }

        private void Load_InvoiceWareHouseDetail_GridView()
        {
            WareHouseDetailController controller = new WareHouseDetailController();
            GlobalVarient.warehouseDetailInvoice = controller.GetWareHouseDetailSelect(GlobalVarient.warehouseInvoiceChoice.WarehouseID, GlobalVarient.CompanyIDChoice);
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
                "CustomerID", "Mã KH", 120, materialCustomerInvoice, "CustomerID", "CustomerSName", true, editValueChanged: invoice_EditValueChanged);
            this.Invoice_gridView.AddColumn("MaSo", "Mã số", 80, true);
            this.Invoice_gridView.AddColumn("MauSo", "Mẫu số", 80, true);
            this.Invoice_gridView.AddColumn("KyHieu", "Kí hiệu", 80, true);
            this.Invoice_gridView.AddColumn("InvoiceNo", "Số HĐ", 80, true);
            this.Invoice_gridView.AddSpinEditColumn("Amount", "Tiền", 100, true, "c2");
            this.Invoice_gridView.AddSpinEditColumn("VAT", "%GTGT", 60, true, "{0}%");
            this.Invoice_gridView.AddSpinEditColumn("VATAmount", "Tiền GTGT", 80, true, "c2");
            this.Invoice_gridView.AddSpinEditColumn("Discounts", "CK", 80, true, "c2");
            this.Invoice_gridView.AddSpinEditColumn("TotalAmount", "Thành Tiền", 100, true, "c2");
            //this.Invoice_gridView.AddColumn("InvoiceType", "Loại HĐ", 60, true);
            this.Invoice_gridView.AddSearchLookupEditColumn(
    "InvoiceType", "Loại HĐ", 60, materialInvoiceType, "InvoiceTypeSummary", "InvoiceTypeName", true);
            this.Invoice_gridView.AddColumn("Description", "Nội dung", 150, true);
            this.Invoice_gridView.AddColumn("CreateUser", "Người tạo", 60, false);
        }


        private void Setup_Invoice_GridView()
        {
            this.Invoice_gridView.SetupGridView(multiSelect: true, checkBoxSelectorColumnWidth: 30);
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
        
     
        //private void popupForminvoice_EditValueChanged(object sender, EventArgs e)
        //{
        //    PopupSearchLookUpEditForm popupControl = (PopupSearchLookUpEditForm)((IPopupControl)sender).PopupWindow;
        //    popupControl.OwnerEdit.EditValueChanged -= new EventHandler(popupForminvoice_EditValueChanged);
        //    MaterialCustomerInvoice matertialCustomerInvoice = new MaterialCustomerInvoice();
        //    matertialCustomerInvoice = (MaterialCustomerInvoice)popupControl.OwnerEdit.GetSelectedDataRow();
        //    //  MessageBox.Show(String.Format("MaSo: {0}, MauSo{1}", matertialCustomerInvoice.MaSo, matertialCustomerInvoice.MauSo));

        //}
        
        public void invoice_EditValueChanged(object sender, EventArgs e)
        {
            var selectRow = ((SearchLookUpEdit)sender).Properties.View.GetFocusedRow().CastTo<MaterialCustomerInvoice>();
            Invoice_gridView.SetFocusedRowCellValue("MaSo", selectRow.MaSo);
            Invoice_gridView.SetFocusedRowCellValue("MauSo", selectRow.MauSo);
            Invoice_gridView.SetFocusedRowCellValue("KyHieu", selectRow.KyHieu);
            // Muon lay gi ra thif dung selectRow.
        }


        public void invoiceWareHouseDetail_EditValueChanged(object sender, EventArgs e)
        {
            var selectRow = ((SearchLookUpEdit)sender).Properties.View.GetFocusedRow().CastTo<Items>();
            InvoiceWareHouseDetail_gridView.SetFocusedRowCellValue("ItemUnit", selectRow.ItemUnit);
        }



        #endregion init Invoice TabPane

        private void InvoiceSaveNew_simpleButton_Click(object sender, EventArgs e)
        {
            if (!InvoiceAddNew_checkBox.Checked)
            {
                MessageBoxHelper.ShowErrorMessage("Vui lòng tick chọn thêm hóa đơn trước khi lưu mới!");
                return;
            }



            #region set VoucherID to invoice
            InvoiceController invoiceController = new InvoiceController();
            for (int i = 0; i < InvoiceData.Count; i++)
            {
                // VoucherDetailData[i].VouchersID = voucher.VouchersID;
                // GlobalVarient.VoucherDetailID++;
                // VoucherDetailData[i].VouchersDetailID = "VOD" + DateTime.Now.ToString("yyyyMMddhhmmssff") + GlobalVarient.VoucherDetailID.ToString();
                InvoiceData[i].CompanyID = GlobalVarient.CompanyIDChoice;
                InvoiceData[i].VouchersID = GlobalVarient.voucherChoice.VouchersID;
                InvoiceData[i].Status = ModifyMode.Insert;
                //voucherDetailController.InsertVouchersDetail(VoucherDetailData[i]);
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

        private void Invoice_gridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (Invoice_gridView.FocusedRowHandle == e.RowHandle)
                {
                    e.Appearance.BackColor = ColorTranslator.FromHtml("#80bfff");
                    e.HighPriority = true;
                }
            }
        }

        private void Voucher_gridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (Voucher_gridView.FocusedRowHandle == e.RowHandle)
                {
                    e.Appearance.BackColor  = ColorTranslator.FromHtml("#80bfff");
                    e.HighPriority = true;
                }
            }
        }

        private void InvoiceWareHouse_gridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (InvoiceWareHouse_gridView.FocusedRowHandle == e.RowHandle)
                {
                    e.Appearance.BackColor = ColorTranslator.FromHtml("#80bfff");
                    e.HighPriority = true;
                }
            }
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
            if (ChoiceWareHouseDetail == 0)
            {
                LoadInvoiceDepreciationGridviewFull();
                ChoiceWareHouseDetail = 1;
            }
            else
            {
                Load_InvoiceDepreciation_GridView();
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

            InvoiceDepreciation_gridView.DeleteSelectedRows();
        }
    }
}

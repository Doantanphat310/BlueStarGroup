using BSClient.Utility;
using BSCommon.Constant;
using BSCommon.Models;
using BSCommon.Utility;
using BSServer.Controllers;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class S35 : Form
    {
        public static MaterialNVController MaterialTK = new MaterialNVController();
        List<MaterialTK> materialTK = MaterialTK.GetMaterialTK(CommonInfo.CompanyInfo.CompanyID);

        public static MaterialNVController MaterialPayment = new MaterialNVController();
        List<MaterialPayment> materialPayment = MaterialPayment.GetMaterialPayment();

        public static MaterialNVController MaterialDT = new MaterialNVController();
        List<MaterialDT> materialDT = MaterialDT.GetMaterialDT(CommonInfo.CompanyInfo.CompanyID);

        public BindingList<Invoice> S35InvoiceData;
        public List<Invoice> S35InvoiceDelete;

        private BindingSource S35InvoiceDataBindingSource { get; set; } = new BindingSource();

        public static MaterialNVController MaterialInvoiceType = new MaterialNVController();
        List<MaterialInvoiceType> materialInvoiceType = MaterialInvoiceType.GetMaterialInvoiceType().Where(item => item.InvoiceTypeSummary == "R").ToList();


        public static ItemsController Items = new ItemsController();
        List<Items> items = Items.GetItems();

        public BindingList<WareHouseDetail> WarehouseDetailData { get; set; }

        public List<WareHouseDetail> WareHouseDetailDelete { get; set; }

        private bool IsFocusRowChanging = false;

        private string GlobalwarehouseID = "";

        public S35()
        {
            InitializeComponent();
            LoadGridviewS35_Invoice();
            InitDefaultControl();
            SetBindingDataInvoiceForm();
            S35InvoiceDataBindingSource.CurrentChanged += S35InvoiceDataBindingSource_CurrentChanged;
         
            S35InvoiceDataBindingSource.ListChanged += S35InvoiceDataBindingSource_ListChanged;

            LoadWareHouseDetailGridviewFull();
        }

        private void S35InvoiceDataBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Console.WriteLine("S35InvoiceDataBindingSource_CurrentChanged");
        }

        private void S35InvoiceDataBindingSource_ListChanged(object sender, EventArgs e)
        {
            Invoice invoice = this.S35_Invoice_GridView.GetFocusedRow().CastTo<Invoice>();
            if(invoice.Status != ModifyMode.Insert)
            {
                invoice.Status = ModifyMode.Update;
            }
        }
        

        public void InitDefaultControl()
        {
            //set default date search
            this.S35_StartDate_dateEdit.DateTime = DateTime.Now;
            this.S35_EndDate_dateEdit.DateTime = DateTime.Now;
            //Loại Doanh Thu
            List<ColumnInfo> columns = new List<ColumnInfo>
            {
                new ColumnInfo("AccountIDFULL", "Tài khoản | Thống kê",140),
                new ColumnInfo("AccountID", "Tài khoản",140),
                new ColumnInfo("AccountDetailID", "Mã TK",80),
                new ColumnInfo("Name", "Tên",180 ),
            };
            materialTK = materialTK.Where(item => item.AccountGroupID == "LTK000004").ToList();
            this.S35_TKTkeDoanhThu_searchLookUpEdit.SetupLookUpEdit("AccountIDFULL", "AccountIDFULL", materialTK, columns, nullText: "", enterChoiceFirstRow: true);

            //Company infor
            List<ColumnInfo> columnsPayment = new List<ColumnInfo>
            {
                new ColumnInfo("PaymentTypeSummary", "Mã",140),
                new ColumnInfo("PaymentTypeName", "Tên",140),
            };
            this.S35_PaymentTye_searchLookUpEdit.SetupLookUpEdit("PaymentTypeSummary", "PaymentTypeName", materialPayment, columnsPayment, nullText: "", enterChoiceFirstRow: true);
            //Customer
            List<ColumnInfo> columnsCustomer = new List<ColumnInfo>
            {
                new ColumnInfo("CustomerID", "KHID",100),
                new ColumnInfo("CustomerSName", "Mã KH",80),
                new ColumnInfo("CustomerName", "Tên",140),
                new ColumnInfo("CustomerTIN", "MST",140),
            };
            this.S35_Customer_searchLookUpEdit.SetupLookUpEdit("CustomerID", "CustomerSName", materialDT, columnsCustomer, nullText: "", enterChoiceFirstRow: true);
        }

        void LoadGridviewS35_Invoice()
        {
            Init_S35_Invoice_GridView();
            Setup_S35_Invoice_GridView();
            Load_S35_Invoice_GridView(DateTime.Now.Date, DateTime.Now.Date, CommonInfo.CompanyInfo.CompanyID);
        }
        #region Init invoice S35
        private void Init_S35_Invoice_GridView()
        {
            this.S35_Invoice_GridView.Columns.Clear();
            this.S35_Invoice_GridView.AddColumn("InvoiceDate", "Ngày HĐ", 80, true);
            this.S35_Invoice_GridView.AddColumn("InvoiceNo", "Số HĐ", 80, true);
            this.S35_Invoice_GridView.AddSpinEditColumn("Amount", "Doanh thu", 120, true, "c2");
            this.S35_Invoice_GridView.AddSpinEditColumn("VAT", "%GTGT", 60, true, "###.##");
            this.S35_Invoice_GridView.AddSpinEditColumn("VATAmount", "VAT", 120, true, "c2");
            this.S35_Invoice_GridView.AddSpinEditColumn("TotalAmount", "Tổng tiền", 120, true, "c2");
            this.S35_Invoice_GridView.AddSearchLookupEditColumn(
    "InvoiceType", "Loại HĐ", 60, materialInvoiceType, "InvoiceTypeSummary", "InvoiceTypeName", isAllowEdit: false);
        }

        private void Setup_S35_Invoice_GridView()
        {
            this.S35_Invoice_GridView.SetupGridView(multiSelect: true, checkBoxSelectorColumnWidth: 30, hasShowRowHeader: true,columnAutoWidth:true);
            // this.S35_Invoice_gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
        }

        private void Load_S35_Invoice_GridView(DateTime startDate, DateTime endDate, string companyID)
        {
            InvoiceController controller = new InvoiceController();
            S35InvoiceData = new BindingList<Invoice>(controller.GetInvoiceSelectS35(startDate, endDate, companyID));
            S35InvoiceDataBindingSource.DataSource = S35InvoiceData;
            this.S35_Invoice_gridControl.DataSource = S35InvoiceDataBindingSource;
            S35InvoiceDelete = new List<Invoice>();
        }

        private void SetBindingDataInvoiceForm()
        {
            DataBindingHelper.BindingLabelControl(this.S35_InvoiceCreateUser_labelControl, S35InvoiceDataBindingSource);
            DataBindingHelper.BindingTextEdit(this.S35_AccountVAT_textEdit, S35InvoiceDataBindingSource);
            DataBindingHelper.BindingTextEdit(this.S35_MST_textEdit, S35InvoiceDataBindingSource);

            DataBindingHelper.BindingTextEdit(this.S35_InvoiceFormNo_textEdit, S35InvoiceDataBindingSource);
            DataBindingHelper.BindingTextEdit(this.S35_FormNo_textEdit, S35InvoiceDataBindingSource);
            DataBindingHelper.BindingTextEdit(this.S35_SerialNo_textEdit, S35InvoiceDataBindingSource);
            DataBindingHelper.BindingTextEdit(this.S35_InvoiceNo_textEdit, S35InvoiceDataBindingSource);
            DataBindingHelper.BindingDateEdit(this.S35_NgayHD_dateEdit, S35InvoiceDataBindingSource);

            DataBindingHelper.BindingMemoEdit(this.S35_CustomerName_MemoEdit, S35InvoiceDataBindingSource);
            DataBindingHelper.BindingMemoEdit(this.S35_Description_MemoEdit, S35InvoiceDataBindingSource);

            DataBindingHelper.BindingSearchLookUpEdit(this.S35_Customer_searchLookUpEdit, S35InvoiceDataBindingSource);
            DataBindingHelper.BindingSearchLookUpEdit(this.S35_TKTkeDoanhThu_searchLookUpEdit, S35InvoiceDataBindingSource);
            DataBindingHelper.BindingSearchLookUpEdit(this.S35_PaymentTye_searchLookUpEdit, S35InvoiceDataBindingSource);
        }
        #endregion Init invoice S35


        #region Init Invoice WarehouseDetail
        void LoadWareHouseDetailGridviewFull()
        {
            Init_WareHouseDetail_GridView();
            Setup_WareHouseDetail_GridView();
            Load_WareHouseDetail_GridView();
        }

        private void Init_WareHouseDetail_GridView()
        {
            this.S35_WarehouseDetail_gridView.Columns.Clear();
            List<ColumnInfo> columns = new List<ColumnInfo>
            {
                new ColumnInfo("ItemID", "ItemID",140),
                new ColumnInfo("ItemSName", "Tên Hàng Hóa",140),
                new ColumnInfo("ItemUnitID", "Đơn vị tính",180 ),
            };
            this.S35_WarehouseDetail_gridView.AddSearchLookupEditColumn("ItemID", "Sản phẩm", 80, items, "ItemID", "ItemSName", columns: columns, isAllowEdit: true, editValueChanged: WareHouseDetail_EditValueChanged);
            this.S35_WarehouseDetail_gridView.AddColumn("ItemUnitID", "ĐVT", 35, true);
            this.S35_WarehouseDetail_gridView.AddSpinEditColumn("Quantity", "Số lượng", 60, true, "###,###,###.##", DevExpress.Data.SummaryItemType.Sum, "###,###,###.##");
            this.S35_WarehouseDetail_gridView.AddSpinEditColumn("Price", "Đơn giá", 120, true, "c2");
            this.S35_WarehouseDetail_gridView.AddSpinEditColumn("Amount", "Doanh Thu", 110, true, "c2", DevExpress.Data.SummaryItemType.Sum, "{0:C}");
            this.S35_WarehouseDetail_gridView.AddSpinEditColumn("VAT", "%GTGT", 60, true, "###.##");
            this.S35_WarehouseDetail_gridView.AddSpinEditColumn("VATAmount", "VAT", 120, true, "c2");
        }

        private void Setup_WareHouseDetail_GridView()
        {
            this.S35_WarehouseDetail_gridView.SetupGridView(multiSelect: true, showFooter: true, newItemRow: NewItemRowPosition.Top);
        }

        private void Load_WareHouseDetail_GridView()
        {
            WareHouseDetailController controller = new WareHouseDetailController();
            Invoice invoice = this.S35_Invoice_GridView.GetFocusedRow().CastTo<Invoice>();
            if (invoice == null)
            {
                WarehouseDetailData = new BindingList<WareHouseDetail>(controller.WareHouseDetailSelectInvoiceID("00000", CommonInfo.CompanyInfo.CompanyID));
            }
            else
            {
                if (invoice.InvoiceID != null)
                {
                    WarehouseDetailData = new BindingList<WareHouseDetail>(controller.WareHouseDetailSelectInvoiceID(invoice.InvoiceID, CommonInfo.CompanyInfo.CompanyID));
                }
                else if(invoice.InvoiceNo != null)
                {
                    // WarehouseDetailData.Where(item => item.InvoiceNo == invoice.InvoiceNo).ToList();
                    //filter dữ liệu theo số hóa đơn S35
                    string filter = string.Empty;
                    filter += $"[InvoiceNo] = '{invoice.InvoiceNo}'";
                    this.S35_WarehouseDetail_gridView.ActiveFilterString = filter;
                }
                else return;
               
            }
            S35_WarehouseDetail_gridControl.DataSource = WarehouseDetailData;
            WareHouseDetailDelete = new List<WareHouseDetail>();
        }


        public void WareHouseDetail_EditValueChanged(object sender, EventArgs e)
        {
            var selectRow = ((SearchLookUpEdit)sender).Properties.View.GetFocusedRow().CastTo<Items>();
            S35_WarehouseDetail_gridView.SetFocusedRowCellValue("ItemUnitID", selectRow.ItemUnitID);
        }

        #endregion Init Invoice WarehouseDetail


        private void S35_Customer_SearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            Console.WriteLine("S35_Customer_searchLookUpEdit_EditValueChanged");
            if (IsFocusRowChanging)
            {
                IsFocusRowChanging = false;
                return;
            }

            MaterialDT customer = S35_Customer_searchLookUpEdit.GetSelectedDataRow().CastTo<MaterialDT>();
            Invoice invoice = this.S35_Invoice_GridView.GetFocusedRow().CastTo<Invoice>();
            string customerName, customerTIN;

            customerName = string.Empty;
            customerTIN = string.Empty;
            if (customer != null && invoice != null)
            {
                customerName = customer.CustomerName;
                customerTIN = customer.CustomerTIN;
            }

            invoice.MST = customerTIN;
            invoice.CustomerName = customerName;
            this.S35_MST_textEdit.EditValue = customerTIN;
            this.S35_CustomerName_MemoEdit.EditValue = customerName;
        }

        private void S35_FilterData_simpleButton_Click(object sender, EventArgs e)
        {
            Load_S35_Invoice_GridView(this.S35_StartDate_dateEdit.DateTime, this.S35_EndDate_dateEdit.DateTime, CommonInfo.CompanyInfo.CompanyID);
        }

        private void S35_Invoice_GridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            //InvoiceType
            S35_Invoice_GridView.SetFocusedRowCellValue("InvoiceType", "R");
            S35_Invoice_GridView.SetFocusedRowCellValue("S35Type", true);
            //left form
            this.S35_InvoiceFormNo_textEdit.EditValue = CommonInfo.CompanyInfo.InvoiceFormNo;
            this.S35_FormNo_textEdit.EditValue = CommonInfo.CompanyInfo.FormNo;
            this.S35_SerialNo_textEdit.EditValue = CommonInfo.CompanyInfo.SerialNo;
            this.S35_NgayHD_dateEdit.DateTime = DateTime.Now.Date;
            this.S35_AccountVAT_textEdit.EditValue = "3331";
            //Invoice default Value
            S35_Invoice_GridView.SetFocusedRowCellValue("VAT", 10);

        }

        private void S35_Add_Invoice_simpleButton_Click(object sender, EventArgs e)
        {
            #region kiểm tra dữ liệu có đang bị khóa sổ
            if (VoucherControl.CheckLockDBCompany(S35_NgayHD_dateEdit.DateTime, CommonInfo.CompanyInfo.CompanyID))
            {
                //Dữ liệu đang nằm trong vùng khóa sổ
                MessageBoxHelper.ShowErrorMessage("Dữ liệu đang bị khóa sổ!");
                return;
            }
            #endregion kiểm tra dữ liệu có đang bị khóa sổ
            InvoiceController invoiceController = new InvoiceController();
            foreach (Invoice invoice in S35InvoiceData)
            {
                if (string.IsNullOrEmpty(invoice.InvoiceID))
                {
                    invoice.CompanyID = CommonInfo.CompanyInfo.CompanyID;
                    invoice.S35Type = true;
                    invoice.Status = ModifyMode.Insert;
                }
            }
            int checkAction = 0;
            List<Invoice> saveData = this.S35InvoiceData.Where(o => o.Status == ModifyMode.Insert || o.Status == ModifyMode.Update || o.Status == ModifyMode.Delete).ToList();
            if (saveData?.Count > 0)
            {
                InvoiceController controller = new InvoiceController();
                if (controller.SaveInvoice(saveData))
                {
                    checkAction++;
                   // S35InvoiceDelete = new List<Invoice>();
                  //  Load_S35_Invoice_GridView(this.S35_StartDate_dateEdit.DateTime.Date, this.S35_EndDate_dateEdit.DateTime.Date, CommonInfo.CompanyInfo.CompanyID);
                }
                else
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

            #region delete InvoiceDelete
            if (S35InvoiceDelete?.Count > 0)
            {
                InvoiceController controller = new InvoiceController();
                if (controller.SaveInvoice(S35InvoiceDelete))
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
            S35InvoiceDelete = new List<Invoice>();
            #endregion delete warehouseDetail
            Load_S35_Invoice_GridView(this.S35_StartDate_dateEdit.DateTime.Date, this.S35_EndDate_dateEdit.DateTime.Date, CommonInfo.CompanyInfo.CompanyID);
        }

        private void S35_Invoice_GridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            bool isNewRow = S35_Invoice_GridView.IsNewItemRow(e.RowHandle);
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

        private void S35_Delete_Invoice_simpleButton_Click(object sender, EventArgs e)
        {
            int[] selectIndex = this.S35_Invoice_GridView.GetSelectedRows();
            foreach (int index in selectIndex)
            {
                Invoice delete = this.S35_Invoice_GridView.GetRow(index) as Invoice;
                if (!string.IsNullOrEmpty(delete.InvoiceID))
                {
                    this.S35InvoiceData[index].Status = ModifyMode.Delete;
                    this.S35InvoiceDelete.Add(delete);
                }
            }
            this.S35_Invoice_GridView.DeleteSelectedRows();
        }

        private void S35_Update_Invoice_simpleButton_Click(object sender, EventArgs e)
        {
            this.S35InvoiceDelete = new List<Invoice>();
            this.Load_S35_Invoice_GridView(this.S35_StartDate_dateEdit.DateTime.Date, this.S35_EndDate_dateEdit.DateTime.Date, CommonInfo.CompanyInfo.CompanyID);
        }

        private void S35_Invoice_GridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            /*
        [Required(ErrorMessage = "Khách hàng không được để trống!")]
        [DisplayName("Mã KH")]
        public string CustomerID { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Mã số HĐ không được để trống!")]
        [DisplayName("Mã số")]
        public string InvoiceFormNo { get; set; }
        [Required(ErrorMessage = "Mẫu số HĐ không được để trống!")]
        [DisplayName("Mẫu số")]
        public string FormNo { get; set; }
        [Required(ErrorMessage = "Ký hiệu HĐ không được để trống!")]
        [DisplayName("Ký hiệu")]
        public string SerialNo { get; set; }
        [Required(ErrorMessage = "Số HĐ không được để trống!")]
        [DisplayName("Số HĐ")]
        public string InvoiceNo { get; set; }
        [Required(ErrorMessage = "Loại HĐ không được để trống!")]
        [DisplayName("Loại HĐ")]
        public string InvoiceType { get; set; }
        [Required(ErrorMessage = "Ngày HĐ không được để trống!")]
        [DisplayName("Ngày HĐ")]
        public DateTime InvoiceDate
        {
            get
            {
                return this.dateCreated.HasValue
                   ? this.dateCreated.Value
                   : DateTime.Now.Date;
            }
            set { this.dateCreated = value; }
        }

        [DisplayName("Tiền")]
        [Required(ErrorMessage = "Tiền hóa đơn không được để trống!")]
        [DisplayFormat(DataFormatString = "C2")]
        public decimal Amount { get; set; }
        [Required]
        [DisplayName("Thuế GTGT")]
        [Range(0, 999.99, ErrorMessage = "Thuế GTGT phải >= 0 và <= 999.99")]
        */
        }

        private void S35_Invoice_GridView_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            Console.WriteLine("S35_Invoice_gridView_BeforeLeaveRow");
            IsFocusRowChanging = true;
        }

        private void S35_WarehouseDetail_gridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            Invoice invoice = this.S35_Invoice_GridView.GetFocusedRow().CastTo<Invoice>();

            WareHouseDetail wareHouseDetail = this.S35_WarehouseDetail_gridView.GetFocusedRow().CastTo<WareHouseDetail>();
            wareHouseDetail.VAT = invoice.VAT;

            foreach (WareHouseDetail wareHouseDetailItem in WarehouseDetailData)
            {
                wareHouseDetailItem.VAT = invoice.VAT;
            }
        }

        private void S35_Add_WareHouseDetail_simpleButton_Click(object sender, EventArgs e)
        {
            //Lưu mới nếu WarehouseID trống
            //WarehouseDetailData
            string warehouseID = "";
            Invoice invoice = this.S35_Invoice_GridView.GetFocusedRow().CastTo<Invoice>();
            foreach (WareHouseDetail wareHouseDetail in WarehouseDetailData)
            {
                if (!string.IsNullOrEmpty(wareHouseDetail.WarehouseID))
                {
                    warehouseID = wareHouseDetail.WarehouseID;
                    break;
                }
            }
            GlobalwarehouseID = warehouseID;
            if (string.IsNullOrEmpty(warehouseID))
            {
                //Thêm mới warehouseID
                #region insert Phiếu kho cho hóa đơn.
                #region set InvoiceID to WareHouse
                List<WareHouse> wareHousesData = new List<WareHouse>();
                WareHouse wareHouseItem = new WareHouse();
                wareHouseItem.CompanyID = CommonInfo.CompanyInfo.CompanyID;
                wareHouseItem.InvoiceID = invoice.InvoiceID;
                wareHouseItem.CustomerID = invoice.CustomerID;
                wareHouseItem.Type = "X";
                wareHouseItem.Status = ModifyMode.Insert;

                wareHousesData.Add(wareHouseItem);
                #endregion set InvoiceID to WareHouse
                if (wareHousesData?.Count > 0)
                {
                    WareHouseController controller = new WareHouseController();
                    if (controller.SaveWareHouse(wareHousesData))
                    {
                        Console.WriteLine("set InvoiceID to WareHouse Success!");
                        //get warehousedetail with sql
                        List<WareHouse>  wareHouseGetID =  controller.InvoiceSelectWareHouseID(invoice.InvoiceID, CommonInfo.CompanyInfo.CompanyID);
                        if (wareHouseGetID.Count > 0)
                        {
                            foreach(WareHouse wareHouseItemGetID in wareHouseGetID)
                            {
                                warehouseID = wareHouseItemGetID.WarehouseID;
                            }  
                        }
                    }
                    else
                    {
                        MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                        return;
                    }
                }
                #endregion insert Phiếu kho cho hóa đơn.
            }
            //
            #region save warehousedetail

            #region set warehouseID to WareHouseDetail
            foreach(WareHouseDetail wareHouseDetailItem in WarehouseDetailData)
            {
                if (string.IsNullOrEmpty(wareHouseDetailItem.WareHouseDetailID))
                {
                    wareHouseDetailItem.CompanyID = CommonInfo.CompanyInfo.CompanyID;
                    wareHouseDetailItem.WarehouseID = warehouseID;
                    wareHouseDetailItem.Status = ModifyMode.Insert;
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
            #endregion save warehousedetail

            //Update nếu warehouseID không trống.
        }

        private void S35_Delete_WareHouseDetail_simpleButton_Click(object sender, EventArgs e)
        {
            int[] selectIndex = this.S35_WarehouseDetail_gridView.GetSelectedRows();
            foreach (int index in selectIndex)
            {
                WareHouseDetail delete = S35_WarehouseDetail_gridView.GetRow(index) as WareHouseDetail;
                if (!string.IsNullOrEmpty(delete.WarehouseID))
                {
                    WarehouseDetailData[index].Status = ModifyMode.Delete;
                    WareHouseDetailDelete.Add(delete);
                }
            }
            S35_WarehouseDetail_gridView.DeleteSelectedRows();
        }

        private void S35_CancelWareHouseDetail_simpleButton_Click(object sender, EventArgs e)
        {
            this.Load_WareHouseDetail_GridView();
        }

        private void S35_WarehouseDetail_gridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.Column.FieldName == "Amount")
            {
                decimal QuantityFilter = (Decimal)this.S35_WarehouseDetail_gridView.GetFocusedRowCellValue("Quantity");

                if (QuantityFilter > 0)
                {

                    Decimal Cellprice = (Decimal)this.S35_WarehouseDetail_gridView.GetFocusedRowCellValue("Amount") / QuantityFilter;

                    if (Cellprice != (Decimal)this.S35_WarehouseDetail_gridView.GetFocusedRowCellValue("Price"))
                    {
                        this.S35_WarehouseDetail_gridView.SetFocusedRowCellValue("Price", Cellprice);
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
                Decimal Cellprice = (Decimal)this.S35_WarehouseDetail_gridView.GetFocusedRowCellValue("Price") * (Decimal)this.S35_WarehouseDetail_gridView.GetFocusedRowCellValue("Quantity");
                if (Cellprice != (Decimal)this.S35_WarehouseDetail_gridView.GetFocusedRowCellValue("Amount"))
                {
                    this.S35_WarehouseDetail_gridView.SetFocusedRowCellValue("Amount", Cellprice);
                }
            }
        }

        private void S35_Invoice_GridView_RowClick(object sender, RowClickEventArgs e)
        {
            Load_WareHouseDetail_GridView();
        }

        private void S35_WarehouseDetail_gridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            bool isNewRow = S35_WarehouseDetail_gridView.IsNewItemRow(e.RowHandle);
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

        private void S35_SelectData_simpleButton_Click(object sender, EventArgs e)
        {
            int[] selectIndex = this.S35_Invoice_GridView.GetSelectedRows();
            GlobalVarient.S35DataSelected = new List<Invoice>();
            foreach (int index in selectIndex)
            {
                Invoice selectinvoice = this.S35_Invoice_GridView.GetRow(index) as Invoice;
                if (!string.IsNullOrEmpty(selectinvoice.InvoiceID))
                {
                    GlobalVarient.S35DataSelected.Add(selectinvoice);
                }
            }
            MessageBoxHelper.ShowInfoMessage("Lấy dữ liệu S35 thành công!");
        }

        private void S35_ImportExcel_simpleButton_Click(object sender, EventArgs e)
        {
            ImportData();
        }

        private void ImportData()
        {
            List<Invoice> invoices = ExcelHelper.LoadInvoice(out StringBuilder error);
          //  BindingList<Invoice> invoicesBidingList = new BindingList<Invoice>();
           List<Invoice> result  = invoices.GroupBy(x => new { x.CustomerID, x.InvoiceFormNo, x.FormNo, x.SerialNo, x.InvoiceNo, x.VAT })
                .Select(x => new Invoice() { CustomerID = x.First().CustomerID, InvoiceFormNo = x.First().InvoiceFormNo
                , FormNo = x.First().FormNo, SerialNo = x.First().SerialNo, InvoiceNo = x.First().InvoiceNo, VAT = x.First().VAT,
                    InvoiceDate = x.First().InvoiceDate, PaymentType = x.First().PaymentType , InvoiceType = "X", S35Type = true,
                    InvoiceVATAccountID = x.First().InvoiceVATAccountID, AccountIDFULL = x.First().AccountIDFULL,
                    Amount = x.Sum(i => i.Amount) }).ToList();

            //Lưu warehouse Detail Chưa có warehouseID và invoiceID
            // S35_WarehouseDetail_gridView
            // WarehouseDetailData
           // InvoiceNo
           foreach(Invoice invoiceDetail in invoices)
            {
                WareHouseDetail wareHouseDetailInvoice = new WareHouseDetail();
                wareHouseDetailInvoice.Amount = invoiceDetail.Amount;
                wareHouseDetailInvoice.ItemID = invoiceDetail.ItemID;
                wareHouseDetailInvoice.Quantity = invoiceDetail.Quantity;
                wareHouseDetailInvoice.Price = invoiceDetail.Price;
                wareHouseDetailInvoice.VAT = invoiceDetail.VAT;
                wareHouseDetailInvoice.InvoiceNo = invoiceDetail.InvoiceNo;
                WarehouseDetailData.Add(wareHouseDetailInvoice);
            }
            //Lưu invoice chưa có InvoiceID
            foreach (var item in result)
            {
                item.Status = ModifyMode.Insert;
                item.S35Type = true;
                item.InvoiceType = "R";
                item.InvoiceVATAccountID = "3331";
                this.S35InvoiceData.Add(item);
            }
         //   this.S35InvoiceData = new BindingList<Invoice>(result);
            if (error != null && error.Length > 0)
            {
                ClientCommon.ShowErrorBox(error.ToString());
            }
        }

        private void ExportData()
        {
          //  Customer_GridControl.ExportExcel(ExcelTemplate.EXL000001);
        }

        private void S35_SaveExcel_simpleButton_Click(object sender, EventArgs e)
        {
            int checkAction = 0;
            ///Lấy data hóa đơn
            foreach (Invoice invoiceExcel in this.S35InvoiceData)
            {
                if (string.IsNullOrEmpty(invoiceExcel.InvoiceID))
                {
                    invoiceExcel.CompanyID = CommonInfo.CompanyInfo.CompanyID;
                    invoiceExcel.S35Type = true;
                    invoiceExcel.Status = ModifyMode.Insert;
                    //lưu hóa đơn
                    InvoiceController controller = new InvoiceController();
                    ///lấy data chi tiết hóa đơn
                    List<WareHouseDetail> detailData = new List<WareHouseDetail>();
                    detailData = this.WarehouseDetailData.Where(item => item.InvoiceNo == invoiceExcel.InvoiceNo).ToList();
                    #region kiểm tra dữ liệu có đang bị khóa sổ
                    if (VoucherControl.CheckLockDBCompany(invoiceExcel.InvoiceDate, CommonInfo.CompanyInfo.CompanyID))
                    {
                        //Dữ liệu đang nằm trong vùng khóa sổ
                        MessageBoxHelper.ShowErrorMessage("Dữ liệu đang bị khóa sổ!\n" + "Số HĐ: " + invoiceExcel.InvoiceNo);
                        continue;
                    }
                    #endregion kiểm tra dữ liệu có đang bị khóa sổ
                    //Lưu chi tiết hóa đơn
                    //Lưu hóa đơn
                    if (controller.SaveInvoiceExcel(invoiceExcel, detailData))
                    {
                        checkAction++;
                    }
                    else
                    {
                        MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002 + " \n HĐ: " + invoiceExcel.InvoiceNo);
                    }
                }
            }

            if(checkAction != 0)
            {
                MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
            }

            Load_S35_Invoice_GridView(this.S35_StartDate_dateEdit.DateTime, this.S35_EndDate_dateEdit.DateTime, CommonInfo.CompanyInfo.CompanyID);

        }
    }
}

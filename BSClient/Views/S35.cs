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
        
        public static WareHouseListController WareHouseListS35 = new WareHouseListController();
        List<WarehouseList> wareHouseListS35 = WareHouseListS35.GetWareHouseListSelect(CommonInfo.CompanyInfo.CompanyID);

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
            //  S35InvoiceDataBindingSource.CurrentChanged += S35InvoiceDataBindingSource_CurrentChanged;

            S35InvoiceDataBindingSource.DataSourceChanged += S35InvoiceDataBindingSource_DataSourceChanged;

            S35InvoiceDataBindingSource.ListChanged += S35InvoiceDataBindingSource_ListChanged;



            LoadWareHouseDetailGridviewFull();
        }

        private void S35InvoiceDataBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (S35SourceFlat)
            {
                Invoice invoice = this.S35_Invoice_GridView.GetFocusedRow().CastTo<Invoice>();
                if (invoice != null)
                {
                    if (invoice.Status != ModifyMode.Insert)
                    {
                        invoice.Status = ModifyMode.Update;
                    }
                }
            }
        }

        //private void S35InvoiceDataBindingSource_CurrentChanged(object sender, EventArgs e)
        //{
        //    Console.WriteLine("S35InvoiceDataBindingSource_CurrentChanged");
        //}

        private void S35InvoiceDataBindingSource_DataSourceChanged(object sender, EventArgs e)
        {
            S35SourceFlat = true;
        }

        bool S35SourceFlat = false;
        private void S35InvoiceDataBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            if (S35SourceFlat)
            {
                Invoice invoice = this.S35_Invoice_GridView.GetFocusedRow().CastTo<Invoice>();
                if (invoice != null)
                {
                    if (invoice.Status != ModifyMode.Insert)
                    {
                        invoice.Status = ModifyMode.Update;
                    }
                }
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
            Load_S35_Invoice_GridView(DateTime.Now.Date, DateTime.Now.Date, CommonInfo.CompanyInfo.CompanyID,2);
        }
        #region Init invoice S35
        private void Init_S35_Invoice_GridView()
        {
            this.S35_Invoice_GridView.Columns.Clear();
            //  this.S35_Invoice_GridView.AddColumn("InvoiceDate", "Ngày HĐ", 80, true);
            this.S35_Invoice_GridView.AddDateEditColumn("InvoiceDate", "Ngày HĐ", 80, true);
            this.S35_Invoice_GridView.AddColumn("InvoiceNo", "Số HĐ", 80, true);
            this.S35_Invoice_GridView.AddSpinEditColumn("Amount", "Doanh thu", 120, true, "###,###,###,###,###");
            this.S35_Invoice_GridView.AddSpinEditColumn("VAT", "%GTGT", 60, true, "##0.00");
            this.S35_Invoice_GridView.AddSpinEditColumn("VATAmount", "VAT", 120, true, "###,###,###,###,###");
            this.S35_Invoice_GridView.AddSpinEditColumn("TotalAmount", "Tổng tiền", 120, true, "###,###,###,###,###");
            this.S35_Invoice_GridView.AddSearchLookupEditColumn(
    "InvoiceType", "Loại HĐ", 60, materialInvoiceType, "InvoiceTypeSummary", "InvoiceTypeName", isAllowEdit: false);
        }

        private void Setup_S35_Invoice_GridView()
        {
            this.S35_Invoice_GridView.SetupGridView(multiSelect: true, checkBoxSelectorColumnWidth: 30, hasShowRowHeader: true, columnAutoWidth: true);
            // this.S35_Invoice_gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
        }

        private void Load_S35_Invoice_GridView(DateTime startDate, DateTime endDate, string companyID, int StatusLink)
        {
            InvoiceController controller = new InvoiceController();
            S35InvoiceData = new BindingList<Invoice>(controller.GetInvoiceSelectS35(startDate, endDate, companyID, StatusLink));
            S35SourceFlat = false;
            S35InvoiceDataBindingSource.DataSource = S35InvoiceData;
            this.S35_Invoice_gridControl.DataSource = S35InvoiceDataBindingSource;
            S35InvoiceDelete = new List<Invoice>();
            S35SourceFlat = true;
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
            this.S35_WarehouseDetail_gridView.AddSpinEditColumn("Quantity", "Số lượng", 60, true, "###,###,###,###,##0.00", DevExpress.Data.SummaryItemType.Sum, "{0:###,###,###,###,###.##}");
            this.S35_WarehouseDetail_gridView.AddSpinEditColumn("S35Price", "Đơn giá", 120, true, "###,###,###,###,###");
            this.S35_WarehouseDetail_gridView.AddSpinEditColumn("S35Amount", "Doanh Thu", 110, true, "###,###,###,###,###", DevExpress.Data.SummaryItemType.Sum, "{0:###,###,###,###,###.##}");
            this.S35_WarehouseDetail_gridView.AddSpinEditColumn("S35VAT", "%GTGT", 60, true, "##0.00");
            this.S35_WarehouseDetail_gridView.AddSpinEditColumn("S35VATAmount", "VAT", 120, true, "###,###,###,###,###", DevExpress.Data.SummaryItemType.Sum, "{0:###,###,###,###,###.##}");
            this.S35_WarehouseDetail_gridView.AddSpinEditColumn("S35TotalAmount", "Doanh thu + Tiền thuế", 120, false, "###,###,###,###,###", DevExpress.Data.SummaryItemType.Sum, "{0:###,###,###,###,###.##}");
            
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
                else if (invoice.InvoiceNo != null)
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
            try
            {
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

        }

        private void S35_FilterData_simpleButton_Click(object sender, EventArgs e)
        {
            Load_S35_Invoice_GridView(this.S35_StartDate_dateEdit.DateTime, this.S35_EndDate_dateEdit.DateTime, CommonInfo.CompanyInfo.CompanyID,2);
            //S35SourceFlat = false;
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
            // this.S35_NgayHD_dateEdit.DateTime = DateTime.Now.Date;
            this.S35_AccountVAT_textEdit.EditValue = "3331";
            //Invoice default Value
            S35_Invoice_GridView.SetFocusedRowCellValue("VAT", 10);

        }

        private void S35_Add_Invoice_simpleButton_Click(object sender, EventArgs e)
        {
            #region kiểm tra dữ liệu có đang bị khóa sổ
            if (VoucherControl.CheckLockDBCompany(S35_EndDate_dateEdit.DateTime, CommonInfo.CompanyInfo.CompanyID))
            {
                //Dữ liệu đang nằm trong vùng khóa sổ
                MessageBoxHelper.ShowErrorMessage("Dữ liệu đang bị khóa sổ!");
                return;
            }

            #endregion kiểm tra dữ liệu có đang bị khóa sổ
            InvoiceController invoiceController = new InvoiceController();
            foreach (Invoice invoice in S35InvoiceData)
            {
                if (VoucherControl.CheckLockDBCompany(invoice.InvoiceDate, CommonInfo.CompanyInfo.CompanyID))
                {
                    //Dữ liệu đang nằm trong vùng khóa sổ
                    MessageBoxHelper.ShowErrorMessage("Dữ liệu đang bị khóa sổ! Những hóa đơn nằm trong vùng khóa sổ sẽ không được xử lý");
                    continue;
                }
                if (string.IsNullOrEmpty(invoice.InvoiceID))
                {
                    invoice.CompanyID = CommonInfo.CompanyInfo.CompanyID;
                    invoice.S35Type = true;
                    invoice.Status = ModifyMode.Insert;
                }
            }
            int checkAction = 0;
            List<Invoice> saveData = this.S35InvoiceData.Where(o => o.Status == ModifyMode.Insert || o.Status == ModifyMode.Update).ToList();
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
            Load_S35_Invoice_GridView(this.S35_StartDate_dateEdit.DateTime.Date, this.S35_EndDate_dateEdit.DateTime.Date, CommonInfo.CompanyInfo.CompanyID,2);
            for (int Vi = 0; Vi < S35InvoiceData.Count; Vi++)
            {
                if (S35InvoiceData[Vi].InvoiceFormNo == GlobalVarient.S35invoiceChoice.InvoiceFormNo &&
                    S35InvoiceData[Vi].FormNo == GlobalVarient.S35invoiceChoice.FormNo &&
                    S35InvoiceData[Vi].SerialNo == GlobalVarient.S35invoiceChoice.SerialNo &&
                    S35InvoiceData[Vi].InvoiceNo == GlobalVarient.S35invoiceChoice.InvoiceNo &&
                    S35InvoiceData[Vi].CustomerID == GlobalVarient.S35invoiceChoice.CustomerID
                    )
                {
                    S35_Invoice_GridView.MoveBy(Vi);
                    GlobalVarient.S35invoiceChoice = S35InvoiceData[Vi];
                    break;
                }
            }

        }

        private void S35_Invoice_GridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            bool isNewRow = S35_Invoice_GridView.IsNewItemRow(e.RowHandle);
            if (isNewRow)
            {
                return;
            }

            Invoice row = e.Row as Invoice;
            if (VoucherControl.CheckLockDBCompany(row.InvoiceDate, CommonInfo.CompanyInfo.CompanyID))
            {
                //Dữ liệu đang nằm trong vùng khóa sổ
                MessageBoxHelper.ShowErrorMessage("Dữ liệu đang bị khóa sổ! Những hóa đơn nằm trong vùng khóa sổ sẽ không được xử lý");
                return;
            }
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
                    if (VoucherControl.CheckLockDBCompany(delete.InvoiceDate, CommonInfo.CompanyInfo.CompanyID))
                    {
                        //Dữ liệu đang nằm trong vùng khóa sổ
                        MessageBoxHelper.ShowErrorMessage("Dữ liệu đang bị khóa sổ! Những hóa đơn nằm trong vùng khóa sổ sẽ không được xử lý");
                        continue;
                    }
                    this.S35InvoiceData[index].Status = ModifyMode.Delete;
                    this.S35InvoiceDelete.Add(delete);
                }
            }
            S35SourceFlat = false;
            this.S35_Invoice_GridView.DeleteSelectedRows();
            S35SourceFlat = true;
        }

        private void S35_Update_Invoice_simpleButton_Click(object sender, EventArgs e)
        {
            this.S35InvoiceDelete = new List<Invoice>();
            this.Load_S35_Invoice_GridView(this.S35_StartDate_dateEdit.DateTime.Date, this.S35_EndDate_dateEdit.DateTime.Date, CommonInfo.CompanyInfo.CompanyID,2);
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

                List<WarehouseList> Khohanghoa = wareHouseListS35.Where(o => o.WarehouseListDebitAccountID == "1561" && o.WarehouseListDebitAccountDetailID == "01").ToList();
                if(Khohanghoa != null)
                {
                    if(Khohanghoa.Count > 0)
                    {
                        wareHouseItem.WarehouseListID = Khohanghoa[0].WarehouseListID;
                    }
                }

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
                        List<WareHouse> wareHouseGetID = controller.InvoiceSelectWareHouseID(invoice.InvoiceID, CommonInfo.CompanyInfo.CompanyID);
                        if (wareHouseGetID.Count > 0)
                        {
                            foreach (WareHouse wareHouseItemGetID in wareHouseGetID)
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
            foreach (WareHouseDetail wareHouseDetailItem in WarehouseDetailData)
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
            #region save invoice
            List<Invoice> saveDatainvoice = this.S35InvoiceData.Where(o => o.Status == ModifyMode.Update).ToList();
            if (saveData?.Count > 0)
            {
                InvoiceController controller = new InvoiceController();
                if (controller.SaveInvoice(saveDatainvoice))
                {
                    checkAction++;
                }
                else
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }
            #endregion save invoice
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
            decimal VATAmounttotal = (decimal)WarehouseDetailData.Sum(x => x.S35VATAmount);
            S35_Invoice_GridView.SetFocusedRowCellValue("VATAmount", VATAmounttotal);
            
            decimal Amounttotal = (decimal)WarehouseDetailData.Sum(x => x.S35Amount);
            S35_Invoice_GridView.SetFocusedRowCellValue("Amount", VATAmounttotal);

            UpdateInvoiceTemp();
        }

        private void S35_CancelWareHouseDetail_simpleButton_Click(object sender, EventArgs e)
        {
            this.Load_WareHouseDetail_GridView();
        }

        private void S35_WarehouseDetail_gridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            /*
                public decimal ?S35Price { get; set; }
                public decimal ?S35Amount { get; set; }
                public decimal ?S35VATAmount { get; set; }
                public decimal ?S35VAT { get; set; }
             */
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.Column.FieldName == "S35Amount")
            {
                if (this.S35_WarehouseDetail_gridView.GetFocusedRowCellValue("Quantity") == null) return;
                decimal QuantityFilter = (Decimal)this.S35_WarehouseDetail_gridView.GetFocusedRowCellValue("Quantity");

                if (QuantityFilter > 0)
                {
                    if (this.S35_WarehouseDetail_gridView.GetFocusedRowCellValue("S35Amount") == null) return;
                    Decimal Cellprice = (Decimal)this.S35_WarehouseDetail_gridView.GetFocusedRowCellValue("S35Amount") / QuantityFilter;
                    if (this.S35_WarehouseDetail_gridView.GetFocusedRowCellValue("S35Price") == null) return;
                    if (Cellprice != (Decimal)this.S35_WarehouseDetail_gridView.GetFocusedRowCellValue("S35Price"))
                    {
                        this.S35_WarehouseDetail_gridView.SetFocusedRowCellValue("S35Price", Cellprice);
                    }
                }
                else
                {
                    MessageBoxHelper.ShowInfoMessage("Số lượng phải lớn hơn 0!");
                    return;
                }

                // decimal VATAmounttotal = (decimal)WarehouseDetailData.Sum(x => x.VATAmount);
                // S35_Invoice_GridView.SetFocusedRowCellValue("VATAmount", VATAmounttotal);
                if (this.S35_WarehouseDetail_gridView.GetFocusedRowCellValue("S35VAT") == null) return;
                Decimal VATAmountEnter = (Decimal)this.S35_WarehouseDetail_gridView.GetFocusedRowCellValue("S35Amount") * (Decimal)this.S35_WarehouseDetail_gridView.GetFocusedRowCellValue("S35VAT") / 100;
                S35_WarehouseDetail_gridView.SetFocusedRowCellValue("S35VATAmount", VATAmountEnter);

                decimal Amounttotal = (decimal)WarehouseDetailData.Sum(x => x.S35Amount);
                S35_Invoice_GridView.SetFocusedRowCellValue("Amount", Amounttotal);
                UpdateInvoiceTemp();

            }
            else if (e.Column.FieldName == "S35Price")
            {
                if (this.S35_WarehouseDetail_gridView.GetFocusedRowCellValue("S35Price") != null && this.S35_WarehouseDetail_gridView.GetFocusedRowCellValue("Quantity") != null)
                {
                    Decimal Cellprice = (Decimal)this.S35_WarehouseDetail_gridView.GetFocusedRowCellValue("S35Price") * (Decimal)this.S35_WarehouseDetail_gridView.GetFocusedRowCellValue("Quantity");
                    if (this.S35_WarehouseDetail_gridView.GetFocusedRowCellValue("S35Amount") != null)
                    {
                        if (Cellprice != (Decimal)this.S35_WarehouseDetail_gridView.GetFocusedRowCellValue("S35Amount"))
                        {
                            this.S35_WarehouseDetail_gridView.SetFocusedRowCellValue("S35Amount", Cellprice);
                        }
                    }
                }
            }
            else if (e.Column.FieldName == "Quantity")
            {
                if (this.S35_WarehouseDetail_gridView.GetFocusedRowCellValue("S35Price")!=null && this.S35_WarehouseDetail_gridView.GetFocusedRowCellValue("Quantity")!= null)
                {
                    Decimal Cellprice = (Decimal)this.S35_WarehouseDetail_gridView.GetFocusedRowCellValue("S35Price") * (Decimal)this.S35_WarehouseDetail_gridView.GetFocusedRowCellValue("Quantity");
                    if (this.S35_WarehouseDetail_gridView.GetFocusedRowCellValue("S35Amount") != null)
                    {
                        if (Cellprice != (Decimal)this.S35_WarehouseDetail_gridView.GetFocusedRowCellValue("S35Amount"))
                        {
                            this.S35_WarehouseDetail_gridView.SetFocusedRowCellValue("S35Amount", Cellprice);
                        }
                    }
                }                
            }
            else if (e.Column.FieldName == "S35VAT")
            {
                if (this.S35_WarehouseDetail_gridView.GetFocusedRowCellValue("S35Amount") == null) return;
                if (this.S35_WarehouseDetail_gridView.GetFocusedRowCellValue("S35VAT") == null) return;
                decimal Amount = (Decimal)S35_WarehouseDetail_gridView.GetFocusedRowCellValue("S35Amount");
                decimal VAT = (Decimal)S35_WarehouseDetail_gridView.GetFocusedRowCellValue("S35VAT");
                decimal VATAmount = VAT * Amount / 100;
                S35_WarehouseDetail_gridView.SetFocusedRowCellValue("S35VATAmount", VATAmount);

                decimal VATAmounttotal = (decimal)WarehouseDetailData.Sum(x => x.S35VATAmount);
                S35_Invoice_GridView.SetFocusedRowCellValue("VATAmount", VATAmounttotal);
                UpdateInvoiceTemp();

            }
            else if (e.Column.FieldName == "S35VATAmount")
            {
                decimal VATAmounttotal = (decimal)WarehouseDetailData.Sum(x => x.S35VATAmount);
                S35_Invoice_GridView.SetFocusedRowCellValue("VATAmount", VATAmounttotal);
                UpdateInvoiceTemp();
            }
        }

        public void UpdateInvoiceTemp()
        {
            Invoice invoice = this.S35_Invoice_GridView.GetFocusedRow().CastTo<Invoice>();
            try
            {
                if (invoice.Status != ModifyMode.Insert)
                {
                    invoice.Status = ModifyMode.Update;
                }
            }
            catch { }
        }

        private void S35_Invoice_GridView_RowClick(object sender, RowClickEventArgs e)
        {
            GlobalVarient.S35invoiceChoice = S35_Invoice_GridView.GetRow(e.RowHandle).CastTo<Invoice>();
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
            List<Invoice> result = invoices.GroupBy(x => new { x.CustomerID, x.InvoiceFormNo, x.FormNo, x.SerialNo, x.InvoiceNo })
                 .Select(x => new Invoice()
                 {
                     CustomerID = x.First().CustomerID,
                     InvoiceFormNo = x.First().InvoiceFormNo,
                     FormNo = x.First().FormNo,
                     SerialNo = x.First().SerialNo,
                     InvoiceNo = x.First().InvoiceNo,
                     VAT = 0,
                     InvoiceDate = x.First().InvoiceDate,
                     PaymentType = x.First().PaymentType,
                     InvoiceType = "X",
                     S35Type = true,
                     InvoiceVATAccountID = x.First().InvoiceVATAccountID,
                     AccountIDFULL = x.First().AccountIDFULL,
                     Amount = x.Sum(i => i.Amount),
                     VATAmount = x.Sum(i => i.VATAmount)
                 }).ToList();

            //Lưu warehouse Detail Chưa có warehouseID và invoiceID
            // S35_WarehouseDetail_gridView
            // WarehouseDetailData
            // InvoiceNo
            foreach (Invoice invoiceDetail in invoices)
            {
                WareHouseDetail wareHouseDetailInvoice = new WareHouseDetail();
                wareHouseDetailInvoice.S35Amount = invoiceDetail.Amount;
                wareHouseDetailInvoice.ItemID = invoiceDetail.ItemID;
                wareHouseDetailInvoice.Quantity = invoiceDetail.Quantity;
                wareHouseDetailInvoice.S35Price = invoiceDetail.Price;
                wareHouseDetailInvoice.S35VAT = invoiceDetail.VAT;
                wareHouseDetailInvoice.S35VATAmount = invoiceDetail.VATAmount;
                wareHouseDetailInvoice.InvoiceNo = invoiceDetail.InvoiceNo;
                //dvt
                List<String> materialDVTInvoice = items.Where(tk => tk.ItemID == invoiceDetail.ItemID).Select(x => x.ItemUnitID).ToList();
                if (materialDVTInvoice != null)
                {
                    if (materialDVTInvoice.Count > 0)
                    {
                        wareHouseDetailInvoice.ItemUnitID = materialDVTInvoice[0].ToString();
                    }
                }
                WarehouseDetailData.Add(wareHouseDetailInvoice);
            }
            //Lưu invoice chưa có InvoiceID
            S35InvoiceData = new BindingList<Invoice>();

            foreach (var item in result)
            {
                item.Status = ModifyMode.Insert;
                item.S35Type = true;
                item.InvoiceType = "R";
                item.InvoiceVATAccountID = "3331";
                item.InvoiceFormNo = CommonInfo.CompanyInfo.InvoiceFormNo;
                item.FormNo = CommonInfo.CompanyInfo.FormNo;
                item.SerialNo = CommonInfo.CompanyInfo.SerialNo;
                List<String> materialTKInvoice = materialTK.Where(tk => tk.AccountIDFULL == item.AccountIDFULL).Select(x => x.Name).ToList();
                //tên khách hàng
                List<String> materialDTInvoice = materialDT.Where(tk => tk.CustomerID == item.CustomerID).Select(x => x.CustomerName).ToList();
                List<String> materialTINInvoice = materialDT.Where(tk => tk.CustomerID == item.CustomerID).Select(x => x.CustomerTIN).ToList();
                if (materialDTInvoice != null)
                {
                    if (materialDTInvoice.Count > 0)
                    {
                        item.CustomerName = materialDTInvoice[0].ToString();
                    }
                }

                if (materialTINInvoice != null)
                {
                    if (materialTINInvoice.Count > 0)
                    {
                        item.MST = materialTINInvoice[0]?.ToString();
                    }
                }

                if (materialTKInvoice != null)
                {
                    if (materialTKInvoice.Count > 0)
                    {
                        item.Description = materialTKInvoice[0].ToString();
                    }
                }
                this.S35InvoiceData.Add(item);
            }
            S35SourceFlat = false;
            S35InvoiceDataBindingSource.DataSource = S35InvoiceData;
            this.S35_Invoice_gridControl.DataSource = S35InvoiceDataBindingSource;
            S35SourceFlat = true;

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

            if (checkAction != 0)
            {
                MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
            }

            Load_S35_Invoice_GridView(this.S35_StartDate_dateEdit.DateTime, this.S35_EndDate_dateEdit.DateTime, CommonInfo.CompanyInfo.CompanyID,2);

        }

        private void S35_TKTkeDoanhThu_searchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (IsFocusRowChanging)
            {
                IsFocusRowChanging = false;
                return;
            }
            try
            {
                MaterialTK TK = S35_TKTkeDoanhThu_searchLookUpEdit.GetSelectedDataRow().CastTo<MaterialTK>();
                Invoice invoice = this.S35_Invoice_GridView.GetFocusedRow().CastTo<Invoice>();
                string name = string.Empty;

                if (TK != null)
                {
                    name = TK.Name;
                }

                invoice.Description = name;
                S35_Description_MemoEdit.Text = name;
                lblNameDoanhThu.Text = name;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private void S35_Invoice_GridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.Column.FieldName == "Amount")
            {
                //set total Amount
                decimal VATAmount = (decimal)S35_Invoice_GridView.GetFocusedRowCellValue("VATAmount");
                decimal Amount = (decimal)S35_Invoice_GridView.GetFocusedRowCellValue("Amount");
                decimal TotalAmount = Amount + VATAmount;
                S35_Invoice_GridView.SetFocusedRowCellValue("TotalAmount", TotalAmount);
            }
            else if (e.Column.FieldName == "VATAmount")
            {
                //set total Amount
                decimal VATAmount = (decimal)S35_Invoice_GridView.GetFocusedRowCellValue("VATAmount");
                decimal Amount = (decimal)S35_Invoice_GridView.GetFocusedRowCellValue("Amount");
                decimal TotalAmount = Amount + VATAmount;
                S35_Invoice_GridView.SetFocusedRowCellValue("TotalAmount", TotalAmount);
            }
        }

        private void S35_Load(object sender, EventArgs e)
        {
            S35_NgayHD_dateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            S35_NgayHD_dateEdit.Properties.NullDate = DateTime.Now.Date;
            //S35_NgayHD_dateEdit.Properties.NullText = DateTime.Now.Date.ToString();

        }

        private void S35_FilterDataNoLink_simpleButton_Click(object sender, EventArgs e)
        {
            Load_S35_Invoice_GridView(this.S35_StartDate_dateEdit.DateTime, this.S35_EndDate_dateEdit.DateTime, CommonInfo.CompanyInfo.CompanyID, 0);
            //S35SourceFlat = false;
        }

        private void S35_FilterDataLink_simpleButton_Click(object sender, EventArgs e)
        {
            Load_S35_Invoice_GridView(this.S35_StartDate_dateEdit.DateTime, this.S35_EndDate_dateEdit.DateTime, CommonInfo.CompanyInfo.CompanyID, 1);
        }

        private void S35_FilterDataNoLinkWarehouse_simpleButton_Click(object sender, EventArgs e)
        {
            Load_S35_Invoice_GridView(this.S35_StartDate_dateEdit.DateTime, this.S35_EndDate_dateEdit.DateTime, CommonInfo.CompanyInfo.CompanyID, 10);
        }

        private void S35_FilterDataLinkWarehouse_simpleButton_Click(object sender, EventArgs e)
        {
            Load_S35_Invoice_GridView(this.S35_StartDate_dateEdit.DateTime, this.S35_EndDate_dateEdit.DateTime, CommonInfo.CompanyInfo.CompanyID, 11);
        }
    }
}

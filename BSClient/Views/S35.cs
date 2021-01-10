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

        private bool IsFocusRowChanged = false;

        public S35()
        {
            InitializeComponent();
            LoadGridviewS35_Invoice();
            InitDefaultControl();
            SetBindingDataInvoiceForm();
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
            this.S35_Invoice_gridView.Columns.Clear();
            this.S35_Invoice_gridView.AddColumn("InvoiceDate", "Ngày HĐ", 80, true);
            this.S35_Invoice_gridView.AddColumn("InvoiceNo", "Số HĐ", 80, true);
            this.S35_Invoice_gridView.AddSpinEditColumn("Amount", "Doanh thu", 120, true, "c2");
            this.S35_Invoice_gridView.AddSpinEditColumn("VAT", "%GTGT", 60, true, "###.##");
            this.S35_Invoice_gridView.AddSpinEditColumn("VATAmount", "VAT", 120, true, "c2");
            this.S35_Invoice_gridView.AddSpinEditColumn("TotalAmount", "Tổng tiền", 120, true, "c2");
            this.S35_Invoice_gridView.AddSearchLookupEditColumn(
    "InvoiceType", "Loại HĐ", 60, materialInvoiceType, "InvoiceTypeSummary", "InvoiceTypeName", isAllowEdit: false);
        }

        private void Setup_S35_Invoice_GridView()
        {
            this.S35_Invoice_gridView.SetupGridView(multiSelect: true, checkBoxSelectorColumnWidth: 30, hasShowRowHeader: true);
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
            DataBindingHelper.BindingTextEdit(this.S35_AccountVAT_textEdit, S35InvoiceDataBindingSource);
            DataBindingHelper.BindingTextEdit(this.S35_MST_textEdit, S35InvoiceDataBindingSource);

            DataBindingHelper.BindingTextEdit(this.S35_InvoiceFormNo_textEdit, S35InvoiceDataBindingSource);
            DataBindingHelper.BindingTextEdit(this.S35_InvoiceNo_textEdit, S35InvoiceDataBindingSource);
            DataBindingHelper.BindingTextEdit(this.S35_SerialNo_textEdit, S35InvoiceDataBindingSource);
            DataBindingHelper.BindingTextEdit(this.S35_InvoiceNo_textEdit, S35InvoiceDataBindingSource);
            DataBindingHelper.BindingDateEdit(this.S35_NgayHD_dateEdit, S35InvoiceDataBindingSource);

            DataBindingHelper.BindingTextEdit(this.S35_CustomerName_TextBox, S35InvoiceDataBindingSource);
            DataBindingHelper.BindingrichTextBox(this.S35_Description_richTextBox, S35InvoiceDataBindingSource);

            DataBindingHelper.BindingSearchLookUpEdit(this.S35_Customer_searchLookUpEdit, S35InvoiceDataBindingSource);
            DataBindingHelper.BindingSearchLookUpEdit(this.S35_TKTkeDoanhThu_searchLookUpEdit, S35InvoiceDataBindingSource);
            DataBindingHelper.BindingSearchLookUpEdit(this.S35_PaymentTye_searchLookUpEdit, S35InvoiceDataBindingSource);
        }
        #endregion Init invoice S35

        private void S35_Customer_searchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (IsFocusRowChanged)
            {
                IsFocusRowChanged = false;
                return;
            }

            var selectRow = S35_Customer_searchLookUpEdit.GetSelectedDataRow().CastTo<MaterialDT>();
            Invoice invoice = this.S35_Invoice_gridView.GetFocusedRow().CastTo<Invoice>();
            string customerName, customerTIN;
            customerName = string.Empty;
            customerTIN = string.Empty;
            if (selectRow != null && invoice != null)
            {
                customerName = selectRow.CustomerName;
                customerTIN = selectRow.CustomerTIN;

                invoice.MST = customerTIN;
                invoice.CustomerName = customerName;
                this.S35_MST_textEdit.EditValue = customerTIN;
                this.S35_CustomerName_TextBox.EditValue = customerName;
            }
            else
            {
                this.S35_MST_textEdit.EditValue = customerTIN;
                this.S35_CustomerName_TextBox.EditValue = customerName;
            }           
        }

        private void S35_FilterData_simpleButton_Click(object sender, EventArgs e)
        {
            Load_S35_Invoice_GridView(this.S35_StartDate_dateEdit.DateTime, this.S35_EndDate_dateEdit.DateTime, CommonInfo.CompanyInfo.CompanyID);
        }

        private void S35_Invoice_gridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            //InvoiceType
            S35_Invoice_gridView.SetFocusedRowCellValue("InvoiceType", "R");
            S35_Invoice_gridView.SetFocusedRowCellValue("S35Type", true);
            //left form
            this.S35_InvoiceFormNo_textEdit.EditValue = CommonInfo.CompanyInfo.InvoiceFormNo;
            this.S35_FormNo_textEdit.EditValue = CommonInfo.CompanyInfo.FormNo;
            this.S35_SerialNo_textEdit.EditValue = CommonInfo.CompanyInfo.SerialNo;
            this.S35_NgayHD_dateEdit.DateTime = DateTime.Now.Date;
            //this.S35_PaymentTye_searchLookUpEdit.EditValue = "TM";
            //this.S35_Customer_searchLookUpEdit.EditValue = "";
            //this.S35_MST_textEdit.EditValue = "";
            //this.S35_CustomerName_richTextBox.Text = "";
        }

        private void S35_Add_Invoice_simpleButton_Click(object sender, EventArgs e)
        {
            InvoiceController invoiceController = new InvoiceController();
            foreach (Invoice invoice in S35InvoiceData)
            {
                if (string.IsNullOrEmpty(invoice.InvoiceID))
                {
                    invoice.CompanyID = CommonInfo.CompanyInfo.CompanyID;
                    invoice.Status = ModifyMode.Insert;
                }
            }

            List<Invoice> saveData = this.S35InvoiceData.Where(o => o.Status == ModifyMode.Insert || o.Status == ModifyMode.Update || o.Status == ModifyMode.Delete).ToList();
            if (saveData?.Count > 0)
            {
                InvoiceController controller = new InvoiceController();
                if (controller.SaveInvoice(saveData))
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    S35InvoiceDelete = new List<Invoice>();
                    Load_S35_Invoice_GridView(this.S35_StartDate_dateEdit.DateTime.Date, this.S35_EndDate_dateEdit.DateTime.Date, CommonInfo.CompanyInfo.CompanyID);
                }
                else
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }
        }

        private void S35_Invoice_gridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            bool isNewRow = S35_Invoice_gridView.IsNewItemRow(e.RowHandle);
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
            int[] selectIndex = this.S35_Invoice_gridView.GetSelectedRows();
            foreach (int index in selectIndex)
            {
                Invoice delete = this.S35_Invoice_gridView.GetRow(index) as Invoice;
                if (!string.IsNullOrEmpty(delete.InvoiceID))
                {
                    this.S35InvoiceData[index].Status = ModifyMode.Delete;
                    this.S35InvoiceDelete.Add(delete);
                }
            }
            this.S35_Invoice_gridView.DeleteSelectedRows();
        }

        private void S35_Update_Invoice_simpleButton_Click(object sender, EventArgs e)
        {
            this.S35InvoiceDelete = new List<Invoice>();
            this.Load_S35_Invoice_GridView(this.S35_StartDate_dateEdit.DateTime.Date, this.S35_EndDate_dateEdit.DateTime.Date, CommonInfo.CompanyInfo.CompanyID);
        }

        private void S35_Invoice_gridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
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

        private void S35_Invoice_gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            IsFocusRowChanged = true;
        }
    }
}

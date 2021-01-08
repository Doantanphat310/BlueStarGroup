using BSClient.Utility;
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
        List<MaterialInvoiceType> materialInvoiceType = MaterialInvoiceType.GetMaterialInvoiceType().Where(item=> item.InvoiceTypeSummary == "R").ToList();

        public S35()
        {
            InitializeComponent();
            InitDefaultControl();
            LoadGridviewS35_Invoice();
        }
         public void InitDefaultControl()
        {
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
            S35_InvoiceFormNo_textEdit.EditValue = "MaSo";//CommonInfo.CompanyInfo.InvoiceFormNo;
            S35_FormNo_textEdit.EditValue = "MauSo";//CommonInfo.CompanyInfo.FormNo;
            S35_SerialNo_textEdit.EditValue = "KyHieu"; //CommonInfo.CompanyInfo.SerialNo;
                                                        //Payment type

            List<ColumnInfo> columnsPayment = new List<ColumnInfo>
            {
                new ColumnInfo("PaymentTypeSummary", "Mã",140),
                new ColumnInfo("PaymentTypeName", "Tên",140),
            };
            this.S35_PaymentTye_searchLookUpEdit.SetupLookUpEdit("PaymentTypeSummary", "PaymentTypeName", materialPayment, columnsPayment, nullText: "", enterChoiceFirstRow: true);
            //Customer
            List<ColumnInfo> columnsCustomer = new List<ColumnInfo>
            {
                new ColumnInfo("CustomerID", "Mã",100),
                new ColumnInfo("CustomerSName", "Tên",80),
                new ColumnInfo("CustomerName", "Tên",140),
                new ColumnInfo("CustomerTIN", "Tên",140),
            };
            this.S35_Customer_searchLookUpEdit.SetupLookUpEdit("CustomerID", "CustomerSName", materialDT, columnsCustomer, nullText: "", enterChoiceFirstRow: true);
        }

        void LoadGridviewS35_Invoice()
        {
            Init_S35_Invoice_GridView();
            Setup_S35_Invoice_GridView();
            Load_S35_Invoice_GridView(DateTime.Now.Date,DateTime.Now.Date, CommonInfo.CompanyInfo.CompanyID);
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
            this.S35_Invoice_gridView.SetupGridView(multiSelect: true, checkBoxSelectorColumnWidth: 30);
            this.S35_Invoice_gridView.SetupGridView(columnAutoWidth: false);
            this.S35_Invoice_gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            this.S35_Invoice_gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
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
            DataBindingHelper.BindingrichTextBox(this.S35_CustomerName_richTextBox, S35InvoiceDataBindingSource);
            DataBindingHelper.BindingSearchLookUpEdit(this.S35_Customer_searchLookUpEdit, S35InvoiceDataBindingSource);
            DataBindingHelper.BindingSearchLookUpEdit(this.S35_TKTkeDoanhThu_searchLookUpEdit, S35InvoiceDataBindingSource);
            DataBindingHelper.BindingSearchLookUpEdit(this.S35_PaymentTye_searchLookUpEdit, S35InvoiceDataBindingSource);
        }
        #endregion Init invoice S35

        private void S35_Customer_searchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            var selectRow = ((SearchLookUpEdit)sender).Properties.View.GetFocusedRow().CastTo<MaterialDT>();
            this.S35_CustomerName_richTextBox.Text = selectRow.CustomerName.ToString();
           this.S35_MST_textEdit.EditValue =  selectRow.CustomerTIN.ToString();
        }

        private void S35_FilterData_simpleButton_Click(object sender, EventArgs e)
        {
            Load_S35_Invoice_GridView(this.S35_StartDate_dateEdit.DateTime, this.S35_EndDate_dateEdit.DateTime, CommonInfo.CompanyInfo.CompanyID);
        }

        private void S35_Invoice_gridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            //InvoiceType
            S35_Invoice_gridView.SetFocusedRowCellValue("InvoiceType", "R");
            S35_Invoice_gridView.SetFocusedRowCellValue("S35Type", true);       }

        private void S35_Add_Invoice_simpleButton_Click(object sender, EventArgs e)
        {

        }
    }
}

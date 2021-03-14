using BSClient.Utility;
using BSCommon.Models;
using BSCommon.Utility;
using BSServer.Controllers;
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
    public partial class ToKhaiThueGTGT : Form
    {
        public static MaterialNVController MaterialInvoiceType = new MaterialNVController();
        List<MaterialInvoiceType> materialInvoiceType = MaterialInvoiceType.GetMaterialInvoiceType();
        public static MaterialNVController MaterialCustomerInvoice = new MaterialNVController();
        List<MaterialCustomerInvoice> materialCustomerInvoice = MaterialCustomerInvoice.GetMaterialCustomerInvoice(CommonInfo.CompanyInfo.CompanyID);
        public static MaterialNVController MaterialInvoiceTypeToKhai = new MaterialNVController();
        List<MaterialInvoiceType> materialInvoiceTypeToKhai = MaterialInvoiceTypeToKhai.GetMaterialInvoiceTypeToKhai();
        public BindingList<BSCommon.Models.ToKhai> ToKhaiData = new BindingList<BSCommon.Models.ToKhai>();

        public ToKhaiThueGTGT()
        {
            InitializeComponent();
            //set From-ToDate
            ToKhai_FromDate.DateTime = DateTime.Now.Date;
            ToKhai_ToDate.DateTime = DateTime.Now.Date;
            // Init control
            Init_Control();
            LoadGridToKhai();

        }

        #region init invoice gridview

        private void LoadGridToKhai()
        {
            Init_ToKhai_GridView();

            Setup_ToKhai_GridView();

            Load_ToKhai_GridView(ToKhai_FromDate.DateTime, ToKhai_ToDate.DateTime, ToKhai_Loai_searchLookUpEdit.EditValue.ToString(), CommonInfo.CompanyInfo.CompanyID);
        }

        private void Init_ToKhai_GridView()
        {
            this.ToKhai_gridView.Columns.Clear();
            this.ToKhai_gridView.AddSearchLookupEditColumn(
    "InvoiceType", "Loại HĐ", 60, materialInvoiceType, "InvoiceTypeSummary", "InvoiceTypeName", isAllowEdit: false);
            this.ToKhai_gridView.AddColumn("CTNo", "Số CT", 80, false);
            this.ToKhai_gridView.AddColumn("InvoiceDate", "Ngày HĐ", 80, false);
            this.ToKhai_gridView.AddColumn("InvoiceNo", "Số HĐ", 80, false);
            this.ToKhai_gridView.AddSpinEditColumn("Amount", "Trước VAT", 120, false, "###,###,###,###,###.##", DevExpress.Data.SummaryItemType.Sum, "{0:###,###,###,###,###}");
            this.ToKhai_gridView.AddSpinEditColumn("VAT", "%", 60, false, "###.##");
            this.ToKhai_gridView.AddSpinEditColumn("VATAmount", "Tiền VAT", 120, false, "###,###,###,###,##0", DevExpress.Data.SummaryItemType.Sum, "{0:###,###,###,###,###}");
            this.ToKhai_gridView.AddColumn("Description", "Mặt hàng", 150, false);
            this.ToKhai_gridView.AddColumn("CustomerTIN", "Mã Thuế", 150, false);
            this.ToKhai_gridView.AddColumn("CustomerName", "Tên KH", 150, false);
        }

        //setup ToKhai gridview
        private void Setup_ToKhai_GridView()
        {
            this.ToKhai_gridView.SetupGridView(multiSelect: true, checkBoxSelectorColumnWidth: 30, hasShowRowHeader: true, columnAutoWidth: true);
        }
        //Load ToKhai
        private void Load_ToKhai_GridView(DateTime FromDate, DateTime ToDate, string invoiceType, string companyID)
        {
            ToKhaiController controller = new ToKhaiController();
            ToKhaiData = new BindingList<BSCommon.Models.ToKhai>(controller.ToKhaiSelect(FromDate, ToDate, invoiceType, companyID));
            this.ToKhai_gridControl.DataSource = ToKhaiData;
        }
        #endregion init invoice gridview

        #region init control
        private void Init_Control()
        {
            //Company infor
            List<ColumnInfo> columnsInvoiceTypeToKhai = new List<ColumnInfo>
            {
                new ColumnInfo("InvoiceTypeSummary", "Mã",140),
                new ColumnInfo("InvoiceTypeName", "Tên",140),
            };
            this.ToKhai_Loai_searchLookUpEdit.SetupLookUpEdit("InvoiceTypeSummary", "InvoiceTypeName", materialInvoiceTypeToKhai, columnsInvoiceTypeToKhai, nullText: "", enterChoiceFirstRow: true);
            this.ToKhai_Loai_searchLookUpEdit.EditValue = "A";
        }
        #endregion init control

        private void ToKhai_LaySoLieu_simpleButton_Click(object sender, EventArgs e)
        {
            Load_ToKhai_GridView(ToKhai_FromDate.DateTime, ToKhai_ToDate.DateTime, ToKhai_Loai_searchLookUpEdit.EditValue.ToString(), CommonInfo.CompanyInfo.CompanyID);
        }
    }
}

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
    public partial class KetChuyen : Form
    {
        public KetChuyen()
        {
            InitializeComponent();
            LoadKichBanKetChuyen();
            LoadKetChuyen();
        }
        #region Kich ban ket chuyen
        public BindingList<KichBanKetChuyentable> KichBanKetChuyentableData { get; set; }
        private void LoadKichBanKetChuyen()
        {
            Init_KichBanKetChuyen_GridView();

            Setup_KichBanKetChuyen_GridView();

            Load_KichBanKetChuyen_GridView();
        }
        private void Init_KichBanKetChuyen_GridView()
        {
            this.KetChuyenKichBan_gridView.Columns.Clear();
            this.KetChuyenKichBan_gridView.AddColumn("GroupCode", "Nhóm", 64, false);
            this.KetChuyenKichBan_gridView.AddColumn("KetChuyenDebitAccountID", "TK Nợ", 110, false);
            this.KetChuyenKichBan_gridView.AddColumn("KetChuyenCreditAccountID", "TK Có",110,false);
        }
        private void Setup_KichBanKetChuyen_GridView()
        {
            this.KetChuyenKichBan_gridView.SetupGridView(columnAutoWidth: false, multiSelect: false, checkBoxSelectorColumnWidth: 30, showAutoFilterRow: true, newItemRow: DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None);
        }
        private void Load_KichBanKetChuyen_GridView()
        {
            KichBanKetChuyentableController controller = new KichBanKetChuyentableController();
            KichBanKetChuyentableData = new BindingList<KichBanKetChuyentable>(controller.KichBanKetChuyentableSelect(CommonInfo.CompanyInfo.CompanyID));
            KetChuyenKichBan_gridControl.DataSource = KichBanKetChuyentableData;
        }
        #endregion kich ban ket chuyen

        #region ket chuyen
        public BindingList<KetChuyenValue> KetChuyenData { get; set; }
        private void LoadKetChuyen()
        {
            Init_KetChuyen_GridView();

            Setup_KetChuyen_GridView();
        }
        private void Init_KetChuyen_GridView()
        {
            this.KetChuyenListData_gridView.Columns.Clear();
            this.KetChuyenListData_gridView.AddColumn("KetChuyenDebitAccountID", "TK Nợ", 110, false);
            this.KetChuyenListData_gridView.AddColumn("KetChuyenDebitAccountDetailID", "T.Kê Nợ", 60, false);
            this.KetChuyenListData_gridView.AddColumn("KetChuyenCreditAccountID", "TK Có", 110, false);
            this.KetChuyenListData_gridView.AddColumn("KetChuyenCreditAccountDetailID", "T.Kê Có", 60, false);
            this.KetChuyenListData_gridView.AddColumn("Amount", "Tiền", 150, false);
            this.KetChuyenListData_gridView.AddColumn("AccountDetailID", "Mã KH", 110, false);
            this.KetChuyenListData_gridView.AddColumn("KetChuyernCreditAccountID", "Hợp Đồng", 110, false);
        }

        private void Setup_KetChuyen_GridView()
        {
            this.KetChuyenListData_gridView.SetupGridView(columnAutoWidth: false, multiSelect: false, checkBoxSelectorColumnWidth: 30, showAutoFilterRow: true, newItemRow: DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None, editable: false);
        }


        private void Load_KetChuyen_GridView(DateTime StartDate, DateTime EndDate, string CompanyID)
        {
            KetChuyenController controller = new KetChuyenController();
            KetChuyenData = new BindingList<KetChuyenValue>(controller.KetChuyentableSelect(StartDate, EndDate, CommonInfo.CompanyInfo.CompanyID));
            KetChuyenListData_gridControl.DataSource = KetChuyenData;
        }
        #endregion ket chuyen

        private void KetChuyenGetdata_simpleButton_Click(object sender, EventArgs e)
        {
            Load_KetChuyen_GridView(ketChuyenStart_dateEdit.DateTime, this.KetChuyenEnd_dateEdit.DateTime, CommonInfo.CompanyInfo.CompanyID);
        }
    }
}

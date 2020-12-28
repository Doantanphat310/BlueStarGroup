using BSClient.Utility;
using BSCommon.Models;
using BSCommon.Utility;
using BSServer.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace BSClient.Views
{
    public partial class KetChuyen : Form
    {
        #region Kich ban ket chuyen
        public BindingList<KichBanKetChuyentable> KichBanKetChuyentableData { get; set; }

        public BindingList<KetChuyenValue> KetChuyenData { get; set; }

        public KetChuyen()
        {
            InitializeComponent();
            LoadKichBanKetChuyen();
            //LoadKetChuyen();
        }

        private void LoadKichBanKetChuyen()
        {
            Init_KichBanKetChuyen_GridView();

            Setup_KichBanKetChuyen_GridView();

            Load_KichBanKetChuyen_GridView();
        }

        private void Init_KichBanKetChuyen_GridView()
        {            
            this.KetChuyenKichBan_GridView.Columns.Clear();
            this.KetChuyenKichBan_GridView.AddColumn("GroupCode", "Nhóm", 64, false);
            this.KetChuyenKichBan_GridView.AddColumn("KetChuyenDebitAccountID", "TK Nợ", 110, false);
            this.KetChuyenKichBan_GridView.AddColumn("KetChuyenCreditAccountID", "TK Có", 110, false);
        }

        private void Setup_KichBanKetChuyen_GridView()
        {
            this.KetChuyenKichBan_GridView.SetupGridView(
                columnAutoWidth: false,
                multiSelect: false,
                newItemRow: DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None);
        }

        private void Load_KichBanKetChuyen_GridView()
        {
            KichBanKetChuyentableController controller = new KichBanKetChuyentableController();
            
            KichBanKetChuyentableData = new BindingList<KichBanKetChuyentable>(controller.KichBanKetChuyentableSelect(CommonInfo.CompanyInfo.CompanyID));
            KetChuyenKichBan_GridControl.DataSource = KichBanKetChuyentableData;
        }
        #endregion kich ban ket chuyen

        #region ket chuyen
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

        private void KetChuyen_Load(object sender, EventArgs e)
        {

        }
    }
}

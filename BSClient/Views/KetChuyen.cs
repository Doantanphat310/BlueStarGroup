using BSClient.Utility;
using BSCommon.Constant;
using BSCommon.Models;
using BSCommon.Utility;
using BSServer.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
            LoadKetChuyen();
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
            this.KetChuyenListData_gridView.AddSpinEditColumn("Amount", "Tiền", 150, false,"C2");
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
            // KetChuyenData
            // List<KetChuyenValue> list = KetChuyenData.w.ToList();
            Decimal No911 = KetChuyenData.Where(item => item.KetChuyenDebitAccountID == "911").Sum(item => item.Amount);
            Decimal Co911 = KetChuyenData.Where(item => item.KetChuyenCreditAccountID == "911").Sum(item => item.Amount);

            //Lợi nhuận = Tổng nợ - tổng có 911
            Decimal LoiNhuan = No911 - Co911;
            if(LoiNhuan > 0)
            {
                //Lợi nhuận > 0 then lợi nhuận * % thuế. Ghi Có 3334, ghi nợ 8211
                KetChuyenValue ketChuyenValue = new KetChuyenValue();
                decimal ThueDN = LoiNhuan * decimal.Parse(KetChuyenVat_textEdit.EditValue.ToString()) / 100;
                ketChuyenValue.KetChuyenCreditAccountID = "3334";
                ketChuyenValue.KetChuyenDebitAccountID = "8211";
                ketChuyenValue.Amount = ThueDN;
                KetChuyenData.Add(ketChuyenValue);
                //Ghi có 8211 vào Nợ 911 (Lợi nhuận * %Thuế)
                ketChuyenValue = new KetChuyenValue();
                ketChuyenValue.KetChuyenCreditAccountID = "8211";
                ketChuyenValue.KetChuyenDebitAccountID = "911";
                ketChuyenValue.Amount = ThueDN;
                KetChuyenData.Add(ketChuyenValue);
                //Lợi nhuận – (Lợi nhuận * %Thuế) | Nợ 911, có 4212
                ketChuyenValue = new KetChuyenValue();
                ketChuyenValue.KetChuyenCreditAccountID = "4212";
                ketChuyenValue.KetChuyenDebitAccountID = "911";
                ketChuyenValue.Amount = LoiNhuan - ThueDN;
                KetChuyenData.Add(ketChuyenValue);
            }
            else
            {
                //Nếu lợi nhuận <=0 
                //Kết chuyển thẳng về Nợ 4212 và có 911
                KetChuyenValue ketChuyenValue = new KetChuyenValue();
              //  decimal ThueDN = LoiNhuan * decimal.Parse(KetChuyenVat_textEdit.EditValue.ToString());
                ketChuyenValue.KetChuyenCreditAccountID = "911";
                ketChuyenValue.KetChuyenDebitAccountID = "4212";
                ketChuyenValue.Amount = Math.Abs(LoiNhuan);
                KetChuyenData.Add(ketChuyenValue);
            }
        }

        private void KetChuyen_Load(object sender, EventArgs e)
        {

        }

        private void KetChuyenSumit_simpleButton_Click(object sender, EventArgs e)
        {
            //insert vouchers và voucherDetail
            foreach(KetChuyenValue item in KetChuyenData)
            {
                #region set value to Insert Voucher
                Voucher voucher = new Voucher();
                voucher.VoucherAmount = item.Amount;
                voucher.VoucherDescription = this.KetChuyenContent_textEdit.EditValue.ToString();
                voucher.VouchersTypeID = "KC";
                voucher.VoucherDate = this.KetChuyenEnd_dateEdit.DateTime.Date;
                voucher.CompanyID = CommonInfo.CompanyInfo.CompanyID;
                voucher.Status = ModifyMode.Insert;
                #endregion set value to Insert Voucher
                List<VoucherDetail> VoucherDetailData = new List<VoucherDetail>();
                VoucherDetail voucherDetail = new VoucherDetail();
                voucherDetail.CompanyID = CommonInfo.CompanyInfo.CompanyID;
                voucherDetail.AccountID = item.KetChuyenCreditAccountID;
                voucherDetail.AccountDetailID = item.KetChuyenCreditAccountDetailID;
                voucherDetail.Amount = item.Amount;
                voucherDetail.NV = "C";
                voucherDetail.Status = ModifyMode.Insert;
                VoucherDetailData.Add(voucherDetail);

                voucherDetail = new VoucherDetail();
                voucherDetail.CompanyID = CommonInfo.CompanyInfo.CompanyID;
                voucherDetail.AccountID = item.KetChuyenDebitAccountID;
                voucherDetail.AccountDetailID = item.KetChuyenDebitAccountDetailID;
                voucherDetail.Amount = item.Amount;
                voucherDetail.NV = "N";
                voucherDetail.Status = ModifyMode.Insert;
                VoucherDetailData.Add(voucherDetail);

                List<VoucherDetail> saveData = VoucherDetailData;
                if (saveData?.Count > 0)
                {
                    VoucherDetailController controller = new VoucherDetailController();
                    if (controller.SaveVoucher_Detail(saveData, voucher))
                    {
                        MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    }
                    else
                    {
                        MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                    }
                }
            }
            Load_KetChuyen_GridView(ketChuyenStart_dateEdit.DateTime, this.KetChuyenEnd_dateEdit.DateTime, CommonInfo.CompanyInfo.CompanyID);
        }
    }
}

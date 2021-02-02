using BSClient.Utility;
using BSCommon.Constant;
using BSCommon.Models;
using BSCommon.Utility;
using BSServer.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BSClient.Views
{
    public partial class KetChuyen : Form
    {
        #region Kich ban ket chuyen
        public BindingList<KichBanKetChuyentable> KichBanKetChuyentableData { get; set; }
        public List<KichBanKetChuyentable> KichBanKetChuyentableDelete;

        public BindingList<KetChuyenValue> KetChuyenData { get; set; }

        public static MaterialNVController MaterialTK = new MaterialNVController();
        List<MaterialTK> materialTK = MaterialTK.GetMaterialTK(CommonInfo.CompanyInfo.CompanyID);

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
                multiSelect: true,
                newItemRow: DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None);
        }

        private void Load_KichBanKetChuyen_GridView()
        {
            KichBanKetChuyentableController controller = new KichBanKetChuyentableController();
            
            KichBanKetChuyentableData = new BindingList<KichBanKetChuyentable>(controller.KichBanKetChuyentableSelect(CommonInfo.CompanyInfo.CompanyID));
            KetChuyenKichBan_GridControl.DataSource = KichBanKetChuyentableData;
            this.KichBanKetChuyentableDelete = new List<KichBanKetChuyentable>();
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
            this.KetChuyenListData_gridView.AddColumn("CustomerID", "Mã KH", 110, false);
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
            Decimal LoiNhuan = Co911 - No911;
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

            #region kiểm tra dữ liệu có đang bị khóa sổ
            if (VoucherControl.CheckLockDBCompany(KetChuyenEnd_dateEdit.DateTime, CommonInfo.CompanyInfo.CompanyID))
            {
                //Dữ liệu đang nằm trong vùng khóa sổ
                MessageBoxHelper.ShowErrorMessage("Dữ liệu đang bị khóa sổ!\n");
                return;
            }
            #endregion kiểm tra dữ liệu có đang bị khóa sổ
            int checkSuccess = 0;
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
                string result = "";
                if (item.KetChuyenCreditAccountID != "911")
                {
                    voucherDetail.CustomerID = item.CustomerID;
                    result = CheckDKInsertKC(false, true, item.KetChuyenCreditAccountID,
                            item.KetChuyenCreditAccountDetailID, "",
                            this.KetChuyenEnd_dateEdit.DateTime.Date, item.Amount);
                }
                else
                {
                     result = CheckDKInsertKC(false, true, item.KetChuyenCreditAccountID,
                            item.KetChuyenCreditAccountDetailID, item.CustomerID,
                            this.KetChuyenEnd_dateEdit.DateTime.Date, item.Amount);
                }
                voucherDetail.NV = "C";
                voucherDetail.Status = ModifyMode.Insert;
                VoucherDetailData.Add(voucherDetail);
                int checkbreak = 0; ;
                if(result != "1")
                {
                    MessageBoxHelper.ShowInfoMessage(result);
                    checkbreak = 1;
                }

                voucherDetail = new VoucherDetail();
                voucherDetail.CompanyID = CommonInfo.CompanyInfo.CompanyID;
                voucherDetail.AccountID = item.KetChuyenDebitAccountID;
                voucherDetail.AccountDetailID = item.KetChuyenDebitAccountDetailID;
                voucherDetail.Amount = item.Amount;
                if (item.KetChuyenDebitAccountID != "911")
                {
                    voucherDetail.CustomerID = item.CustomerID;
                    result = CheckDKInsertKC(false, true, item.KetChuyenDebitAccountID,
                            item.KetChuyenCreditAccountDetailID, "",
                            this.KetChuyenEnd_dateEdit.DateTime.Date, item.Amount);
                }
                else
                {
                    result = CheckDKInsertKC(true, false, item.KetChuyenDebitAccountID,
                           item.KetChuyenCreditAccountDetailID, item.CustomerID,
                           this.KetChuyenEnd_dateEdit.DateTime.Date, item.Amount);
                }
                voucherDetail.NV = "N";
                voucherDetail.Status = ModifyMode.Insert;
                VoucherDetailData.Add(voucherDetail);

                if (result != "1")
                {
                    MessageBoxHelper.ShowInfoMessage(result);
                    checkbreak = 1;
                }

                if (checkbreak == 1) continue;

                List<VoucherDetail> saveData = VoucherDetailData;
                if (saveData?.Count > 0)
                {
                    VoucherDetailController controller = new VoucherDetailController();
                    if (controller.SaveVoucher_Detail(saveData, voucher))
                    {
                      //  MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                    }
                    else
                    {
                        checkSuccess = 1;
                        MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                    }
                }
            }
            Load_KetChuyen_GridView(ketChuyenStart_dateEdit.DateTime, this.KetChuyenEnd_dateEdit.DateTime, CommonInfo.CompanyInfo.CompanyID);
            if(checkSuccess == 0)
            {
                MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
            }
        }

      public  String  CheckDKInsertKC(Boolean DuNo, Boolean DuCo, string AccountID, string AccountDetailID, string CustomerID, DateTime voucherDate, decimal Amount)
        {
            List<MaterialTK> TKCheck =  materialTK.Where(tk => tk.AccountID.ToString() == AccountID).ToList();
            MaterialNVController materialSoDuCuoiKyTK = new MaterialNVController();
            List<MaterialSoDuCuoiKyTK> SoDuCuoiKy = materialSoDuCuoiKyTK.GetMaterialGetSoDuCuoiKyTK(AccountID, AccountDetailID, CustomerID, CommonInfo.CompanyInfo.CompanyID, voucherDate, "0000");

            if (TKCheck.Count > 0)
            {
                if ((TKCheck[0].DuNo == true && DuNo == true) || (TKCheck[0].DuCo == true && DuCo == true))
                {
                    //Cho phép nhập Nợ, Có không cần kiểm tra
                }
                else if (TKCheck[0].DuNo == false && DuNo) // Kiểm tra nợ <= có
                {
                    //Kiểm tra Nợ nhập tk Nợ nhỏ hơn DuCo
                   
                       decimal number2 = Decimal.Round(SoDuCuoiKy[0].CreditAmount - SoDuCuoiKy[0].DebitAmount, 2);
                        Boolean CompareAmountSoDu = Amount > number2;
                        if (CompareAmountSoDu)
                        {
                            //Tiền nhập đang lớn hơn số dư
                            return "Dư có" + AccountID  + " hiện tại là: " + number2.ToString("C2");
                        }
                }
                else if (TKCheck[0].DuCo == false && DuCo) //Kiểm tra có <=N
                {
                    //Kiểm tra Có nhập tk có nhỏ hơn DuNo'
                    decimal number2 = Decimal.Round(SoDuCuoiKy[0].DebitAmount - SoDuCuoiKy[0].CreditAmount, 2);
                        Boolean CompareAmountSoDu = Amount > number2;
                        if (CompareAmountSoDu)
                        {
                        //Tiền nhập đang lớn hơn số dư
                            return "Dư nợ" + AccountID + " hiện tại là: " + number2.ToString("C2");
                        }
                }
            }
            return "1";
        }

        private void KichBanKC_ImportExcel_simpleButton_Click(object sender, EventArgs e)
        {
            ImportData();
        }

        private void ImportData()
        {
            List<KichBanKetChuyentable> kichBanKetChuyentables = ExcelHelper.LoadKichBanKC(out StringBuilder error);
            //Lưu invoice chưa có InvoiceID
            foreach (var item in kichBanKetChuyentables)
            {
                this.KichBanKetChuyentableData.Add(item);
            }
            //   this.S35InvoiceData = new BindingList<Invoice>(result);
            if (error != null && error.Length > 0)
            {
                ClientCommon.ShowErrorBox(error.ToString());
            }
        }

        private void KichBanKC_Delete_simpleButton_Click(object sender, EventArgs e)
        {
            int[] selectIndex = this.KetChuyenKichBan_GridView.GetSelectedRows();
            foreach (int index in selectIndex)
            {
                KichBanKetChuyentable delete = this.KetChuyenKichBan_GridView.GetRow(index) as KichBanKetChuyentable;
                delete.Status = ModifyMode.Delete;
                this.KichBanKetChuyentableDelete.Add(delete);
            }
            this.KetChuyenKichBan_GridView.DeleteSelectedRows();
        }

        private void KichBanKC_SaveData_simpleButton_Click(object sender, EventArgs e)
        {
                int checkAction = 0;
                KichBanKetChuyentableController controller = new KichBanKetChuyentableController();
                List<KichBanKetChuyentable> detailData = new List<KichBanKetChuyentable>();
                detailData = this.KichBanKetChuyentableData.Where(item => item.Status == ModifyMode.Insert || item.Status == ModifyMode.Delete).ToList();
                if (controller.SaveKichBanKetChuyentable(detailData))
                {
                    checkAction++;
                }
                else
                {
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }

            #region delete KichBanKC
            if (this.KichBanKetChuyentableDelete?.Count > 0)
            {
                if (controller.SaveKichBanKetChuyentable(KichBanKetChuyentableDelete))
                {
                    checkAction++;
                }
                else
                {
                    checkAction = 0;
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }
            #endregion delete KichBanKC

            if (checkAction != 0)
                {
                MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
                }
                Load_KichBanKetChuyen_GridView();
        }
    }
}

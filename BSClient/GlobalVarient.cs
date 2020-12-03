using BSCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSClient
{
    public class GlobalVarient
    {
        public static string CompanyIDChoice = "COM0001";
        public static string VoucherIDChoice = "";
        public static int VoucherID = 0;
        public static int VoucherDetailID = 0;
        public static Voucher voucherChoice = new Voucher();
        public static List<VoucherDetail> voucherDetailChoice = new List<VoucherDetail>();
        public static List<Invoice> invoices = new List<Invoice>();
        public static Invoice invoiceChoice = new Invoice();

        public static List<WareHouse> warehouse = new List<WareHouse>();
        public static WareHouse warehouseChoice = new WareHouse();

        public static List<WareHouse>  warehouseInvoice = new List<WareHouse>();
        public static WareHouse warehouseInvoiceChoice = new WareHouse();

        public static List<WareHouseDetail> warehouseDetail = new List<WareHouseDetail>();
        public static WareHouseDetail warehouseDetailChoice = new WareHouseDetail();

        public static List<WareHouseDetail> warehouseDetailInvoice = new List<WareHouseDetail>();
        public static WareHouseDetail warehouseDetailInvoiceChoice = new WareHouseDetail();


        public static List<Depreciation> InvoiceDepreciations = new List<Depreciation>();
        public static Depreciation InvoiceDepreciationsChoice = new Depreciation();


        public static List<Depreciation> Depreciations = new List<Depreciation>();
        public static Depreciation DepreciationsChoice = new Depreciation();

        public static List<DepreciationDetail> InvoiceDepreciationsDetail = new List<DepreciationDetail>();
        public static DepreciationDetail InvoiceDepreciationsDetailChoice = new DepreciationDetail();

        public static List<DepreciationDetail> DepreciationsDetail = new List<DepreciationDetail>();
        public static DepreciationDetail DepreciationsDetailChoice = new DepreciationDetail();


    }
}

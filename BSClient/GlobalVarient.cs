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
        public static List<WareHouse>  warehouseInvoice = new List<WareHouse>();
        public static WareHouse warehouseInvoiceChoice = new WareHouse();

    }
}

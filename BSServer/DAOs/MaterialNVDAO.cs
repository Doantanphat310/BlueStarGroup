using BSCommon.Models;
using BSServer._Core.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSServer.DAOs
{
   public class MaterialNVDAO
    {
        public MaterialNVDAO(BSContext context)
        {
            this.Context = context;
        }
        private BSContext Context { get; set; }

        public List<MaterialNV> GetMaterialNV()
        {
            return this.Context.Database
                .SqlQuery<MaterialNV>("SPSelectMaterialNV")
                .ToList();
        }

        public List<MaterialInvoiceType> GetMaterialInvoiceType()
        {
            return this.Context.Database
                .SqlQuery<MaterialInvoiceType>("SPSelectMaterialInvoiceType")
                .ToList();
        }

        public List<MaterialWareHouseType> GetMaterialWareHouseType()
        {
            return this.Context.Database
                .SqlQuery<MaterialWareHouseType>("SPSelectMaterialWareHouseType")
                .ToList();
        }

        public List<MaterialTK> GetMaterialTK(string companyID)
        {
            SqlParameter param = new SqlParameter("@CompanyID", companyID);
            return this.Context.Database
                .SqlQuery<MaterialTK>("SPSelectMaterialTK @CompanyID", param)
                .ToList();
        }

        public List<MaterialDT> GetMaterialDT(string companyID)
        {
            SqlParameter param = new SqlParameter("@CompanyID", companyID);
            return this.Context.Database
                .SqlQuery<MaterialDT>("SPSelectMaterialDoiTuong @CompanyID", param)
                .ToList();
        }


        public List<MaterialCustomerInvoice> GetMaterialCustomerInvoice(string customerID)
        {
            SqlParameter param = new SqlParameter("@CustomerID", customerID);
            return this.Context.Database
                .SqlQuery<MaterialCustomerInvoice>("SPSelectMaterialMaSoCustomer @CustomerID", param)
                .ToList();
        }

        ///SPCheckMaterialTK_GL '111','GL6'    
        public List<MaterialCheck> GetMaterialCheck(string accountID, string GLID)
        {
            return this.Context.Database.SqlQuery<MaterialCheck>(
            "SPCheckMaterialTK_GL @AccountID, @GeneralLedgerID",
            new SqlParameter("@AccountID", accountID),
            new SqlParameter("@GeneralLedgerID", GLID)
            ).ToList();
        }

        //create proc SPCheckInvoiceNo
        // @CustomerID varchar(50),@InvoiceFormNo varchar(50),@FormNo varchar(50),@SerialNo varchar(50),@InvoiceNo varchar(50)
        public List<MaterialCheck> GetMaterialCheckInvoiceNo(string InvoiceID,string CustomerID, string InvoiceFormNo, string FormNo, string SerialNo, string InvoiceNo)
        {
            return this.Context.Database.SqlQuery<MaterialCheck>(
            "SPCheckInvoiceNo @InvoiceID, @CustomerID,@InvoiceFormNo,@FormNo,@SerialNo,@InvoiceNo",
            new SqlParameter("@InvoiceID", InvoiceID ?? (object)DBNull.Value),
            new SqlParameter("@CustomerID", CustomerID),
            new SqlParameter("@InvoiceFormNo", InvoiceFormNo),
            new SqlParameter("@FormNo", FormNo),
            new SqlParameter("@SerialNo", SerialNo),
            new SqlParameter("@InvoiceNo", InvoiceNo)
            ).ToList();
        }
        /*
         @AccountID varchar(50),@AccountDetailID varchar(50),@CustomerID varchar(50),@CompanyID varchar(50),
@VoucherDate datetime,@VoucherDetailID varchar(50)
             */

        public List<MaterialSoDuCuoiKyTK> GetMaterialGetSoDuCuoiKyTK(string accountID, string AccountDetailID,string CustomerID, string CompanyID, DateTime VoucherDate, string VoucherDetailID)
        {
            return this.Context.GetDataFromProcedure<MaterialSoDuCuoiKyTK>(
                "SP_SoDuCuoiKyHienTaiTK",
                new SqlParameter("@AccountID", accountID),
                new SqlParameter("@AccountDetailID", AccountDetailID ?? (object)DBNull.Value),
                new SqlParameter("@CustomerID", CustomerID ?? (object)DBNull.Value),
                new SqlParameter("@CompanyID", CompanyID),
                new SqlParameter("@VoucherDate", VoucherDate),
                new SqlParameter("@VoucherDetailID", VoucherDetailID ?? (object)DBNull.Value));

            //    .Database.SqlQuery<MaterialSoDuCuoiKyTK>(
            //"SP_SoDuCuoiKyHienTaiTK @AccountID, @AccountDetailID, @CustomerID, @CompanyID, @VoucherDate, @VoucherDetailID",
            //new SqlParameter("@AccountID", accountID),
            //new SqlParameter("@AccountDetailID", AccountDetailID ?? (object)DBNull.Value),
            //new SqlParameter("@CustomerID", CustomerID ?? (object)DBNull.Value),
            //new SqlParameter("@CompanyID", CompanyID),
            //new SqlParameter("@VoucherDate", VoucherDate),
            //new SqlParameter("@VoucherDetailID", VoucherDetailID ?? (object)DBNull.Value)
            //).ToList();
        }

        public List<MaterialTonKho> GetMaterialTonKho(DateTime VoucherDate,  string ItemID, string CompanyID)
        {
            return this.Context.Database.SqlQuery<MaterialTonKho>(
            "SP_TonKhoItem @VoucherDate, @ItemID, @CompanyID",
            new SqlParameter("@VoucherDate", VoucherDate),
            new SqlParameter("@ItemID", ItemID),
            new SqlParameter("@CompanyID", CompanyID)
            ).ToList();
        }
    }
}

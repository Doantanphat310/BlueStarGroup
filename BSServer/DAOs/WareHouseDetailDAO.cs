using BSCommon.Models;
using BSCommon.Utility;
using BSServer._Core.Base;
using BSServer._Core.Const;
using BSServer._Core.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSServer.DAOs
{
   public class WareHouseDetailDAO : BaseDAO
    {
        public WareHouseDetailDAO(BSContext context) : base(context)
        {
        }

        public List<WareHouseDetail> GetWareHouseDetailSelect(string warehouseDetailID, string CompanyID)
        {
            return this.Context.Database.SqlQuery<WareHouseDetail>(
          "WareHouseDetailSelect @warehouseDetailID, @CompanyID, @CreateUser",
          new SqlParameter("@WareHouseID", warehouseDetailID),
          new SqlParameter("@CompanyID", CompanyID),
          new SqlParameter("@CreateUser", UserInfo.UserID)
          ).ToList();
        }


        public List<WareHouseDetail> GetWareHouseDetailSelectWahouseID(string warehouseID, string CompanyID)
        {
            return this.Context.Database.SqlQuery<WareHouseDetail>(
          "WareHouseDetailSelectWahouseID @WareHouseID, @CompanyID, @CreateUser",
          new SqlParameter("@WareHouseID", warehouseID),
          new SqlParameter("@CompanyID", CompanyID),
          new SqlParameter("@CreateUser", UserInfo.UserID)
          ).ToList();
        }
        public List<WareHouseDetail> WareHouseDetailSelectInvoiceID(string invoiceID, string CompanyID)
        {
            return this.Context.Database.SqlQuery<WareHouseDetail>(
          "WareHouseDetailSelectInvoiceID @InvoiceID, @CompanyID, @CreateUser",
          new SqlParameter("@InvoiceID", invoiceID),
          new SqlParameter("@CompanyID", CompanyID),
          new SqlParameter("@CreateUser", UserInfo.UserID)
          ).ToList();
        }


        public long GetWareHouseDetailSEQ()
        {
            return this.GetMaxSEQ(BSServerConst.WareHouseDetailSymbol);
        }

        public bool InsertWareHouseDetail(WareHouseDetail wareHouseDetail)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@WareHouseDetailID", wareHouseDetail.WareHouseDetailID),
                    new SqlParameter("@WarehouseID", wareHouseDetail.WarehouseID),
                    new SqlParameter("@ItemID", wareHouseDetail.ItemID),
                    new SqlParameter("@Quantity", wareHouseDetail.Quantity),
                    new SqlParameter("@Price",wareHouseDetail.Price),
                    new SqlParameter("@Amount", wareHouseDetail.Amount),
                    new SqlParameter("@VAT", wareHouseDetail.VAT),
                    new SqlParameter("@VATAmount", wareHouseDetail.VATAmount),
                    new SqlParameter("@CreateUser", UserInfo.UserID),
                    new SqlParameter("@CompanyID", wareHouseDetail.CompanyID),
                    new SqlParameter("@S35Price", wareHouseDetail.S35Price),
                    new SqlParameter("@S35Amount", wareHouseDetail.S35Amount),
                    new SqlParameter("@S35VATAmount", wareHouseDetail.S35VATAmount),
                    new SqlParameter("@S35VAT", wareHouseDetail.S35VAT),
                    new SqlParameter("@DonGiaBinhQuan", wareHouseDetail.DonGiaBinhQuan),
                    new SqlParameter("@SoLuongTon", wareHouseDetail.SoLuongTon)
    };
                this.Context.ExecuteDataFromProcedure("WareHouseDetailInsert", sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert WareHouse Detail Fail! " + ex.Message);
                return false;
            }
        }

        public bool DeleteWareHouseDetail(string warehousedetailID, string CompanyID)
        {

            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
               {
                    new SqlParameter("@WareHouseDetailID", warehousedetailID),
                    new SqlParameter("@CreateUser", UserInfo.UserID),
                    new SqlParameter("@CompanyID", CompanyID)

               };

                this.Context.ExecuteDataFromProcedure("WareHouseDetailDelete", sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete WareHouse Detail Fail! " + ex.Message);
                return false;
            }
        }


        public bool UpdateWareHouseDetail(WareHouseDetail wareHouseDetail)
        {

            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@WareHouseDetailID", wareHouseDetail.WareHouseDetailID),
                    new SqlParameter("@ItemID", wareHouseDetail.ItemID),
                    new SqlParameter("@Quantity", wareHouseDetail.Quantity),
                    new SqlParameter("@Price", wareHouseDetail.Price),
                    new SqlParameter("@Amount", wareHouseDetail.Amount),
                    new SqlParameter("@VAT", wareHouseDetail.VAT),
                    new SqlParameter("@VATAmount", wareHouseDetail.VATAmount),
                    new SqlParameter("@CreateUser", UserInfo.UserID),
                    new SqlParameter("@CompanyID", wareHouseDetail.CompanyID),
                    new SqlParameter("@S35Price", wareHouseDetail.S35Price),
                    new SqlParameter("@S35Amount", wareHouseDetail.S35Amount),
                    new SqlParameter("@S35VATAmount", wareHouseDetail.S35VATAmount),
                    new SqlParameter("@S35VAT", wareHouseDetail.S35VAT),
                    new SqlParameter("@DonGiaBinhQuan", wareHouseDetail.DonGiaBinhQuan),
                    new SqlParameter("@SoLuongTon", wareHouseDetail.SoLuongTon)
                };

                this.Context.ExecuteDataFromProcedure("WareHouseDetailUpdate", sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update WareHouse Detail Fail! " + ex.Message);
                return false;
            }
        }
    }
}

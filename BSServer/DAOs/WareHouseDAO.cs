﻿using BSCommon.Models;
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
   public  class WareHouseDAO : BaseDAO
    {

        public WareHouseDAO(BSContext context) : base(context)
        {
        }

        public List<WareHouse> GetWareHouseSelectVoucherID(string voucherID, string CompanyID)
        {
            return this.Context.Database.SqlQuery<WareHouse>(
          "WareHouseSelectVoucherID @VouchersID, @CompanyID, @CreateUser",
          new SqlParameter("@VouchersID", voucherID),
          new SqlParameter("@CompanyID", CompanyID),
          new SqlParameter("@CreateUser", CommonInfo.UserInfo.UserName)
          ).ToList();
        }

        public List<WareHouse> GetWareWareHouseSelectInvoiceID(string invoiceID, string CompanyID)
        {
            return this.Context.Database.SqlQuery<WareHouse>(
          "WareHouseSelectInvoiceID @InvoiceID, @CompanyID, @CreateUser",
          new SqlParameter("@InvoiceID", invoiceID),
          new SqlParameter("@CompanyID", CompanyID),
          new SqlParameter("@CreateUser", CommonInfo.UserInfo.UserName)
          ).ToList();
        }

        public long GetWareHouseSEQ()
        {
            return this.GetMaxSEQ(BSServerConst.WareHouseSymbol);
        }

        public bool InsertWareHouse(WareHouse wareHouse)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@WarehouseID", wareHouse.WarehouseID),
                    new SqlParameter("@VouchersID", wareHouse.VouchersID),
                    new SqlParameter("@InvoiceID", wareHouse.InvoiceID),
                    new SqlParameter("@CustomerID", wareHouse.CustomerID),
                    new SqlParameter("@GeneralLedgerID",wareHouse.WarehouseListID?? (object)DBNull.Value),
                    new SqlParameter("@Date", wareHouse.Date),
                    new SqlParameter("@DebitAccountID", wareHouse.DebitAccountID),
                    new SqlParameter("@CreditAccountID", wareHouse.CreditAccountID),
                    new SqlParameter("@Type", wareHouse.Type),
                    new SqlParameter("@DeliverReceiver", wareHouse.DeliverReceiver),
                    new SqlParameter("@Description", wareHouse.Description),
                    new SqlParameter("@Attachfile",  wareHouse.Attachfile),
                    new SqlParameter("@Discount", wareHouse.Discount),
                    new SqlParameter("@CreateUser", CommonInfo.UserInfo.UserID),
                    new SqlParameter("@CompanyID", wareHouse.CompanyID),
                };
                this.Context.ExecuteDataFromProcedure("WareHouseInsert", sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert WareHouse Fail! " + ex.Message);
                return false;
            }
        }

        public bool DeleteWareHouse(string WareHouseID, string CompanyID)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
               {
                    new SqlParameter("@WarehouseID", WareHouseID),
                    new SqlParameter("@CreateUser", CommonInfo.UserInfo.UserID),
                    new SqlParameter("@CompanyID", CompanyID)
                    
               };

                this.Context.ExecuteDataFromProcedure("WareHouseDelete", sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete WareHouse Fail! " + ex.Message);
                return false;
            }
        }


        public bool UpdateWareHouse(WareHouse wareHouse)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@WarehouseID", wareHouse.WarehouseID),
                    new SqlParameter("@DebitAccountID", wareHouse.DebitAccountID),
                    new SqlParameter("@CreditAccountID", wareHouse.CreditAccountID),
                    new SqlParameter("@Type", wareHouse.Type),
                    new SqlParameter("@DeliverReceiver", wareHouse.DeliverReceiver),
                    new SqlParameter("@Description", wareHouse.Description),
                    new SqlParameter("@Attachfile",  wareHouse.Attachfile??(object)DBNull.Value),
                    new SqlParameter("@CreateUser", CommonInfo.UserInfo.UserID),
                    new SqlParameter("@CompanyID", wareHouse.CompanyID),
                };

                this.Context.ExecuteDataFromProcedure("WareHouseUpdate", sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update WareHouse Fail! " + ex.Message);
                return false;
            }
        }
    }
}

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
          "WareHouseDetailSelect @WareHouseID, @CompanyID, @CreateUser",
          new SqlParameter("@WareHouseDetailID", warehouseDetailID),
          new SqlParameter("@CompanyID", CompanyID),
          new SqlParameter("@CreateUser", CommonInfo.UserInfo.UserName)
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
                    new SqlParameter("@CreateUser", CommonInfo.UserInfo.UserID),
                    new SqlParameter("@CompanyID", wareHouseDetail.CompanyID)
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
                    new SqlParameter("@CreateUser", CommonInfo.UserInfo.UserID),
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
                    new SqlParameter("@CreateUser", CommonInfo.UserInfo.UserID),
                    new SqlParameter("@CompanyID", wareHouseDetail.CompanyID),
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

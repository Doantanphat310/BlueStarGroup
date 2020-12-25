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
   public  class WareHouseListDAO : BaseDAO
    {

        public WareHouseListDAO(BSContext context) : base(context)
        {
        }

        public List<WarehouseList> GetWareHouseListSelect(string CompanyID)
        {
            return this.Context.Database.SqlQuery<WarehouseList>(
            "WarehouseListSelect @CompanyID",
            new SqlParameter("@CompanyID", CompanyID)
            ).ToList();
        }

        public long GetWareHouseListSEQ()
        {
            return this.GetMaxSEQ(BSServerConst.WareHouseListSymbol);
        }

        public bool InsertWareHouseList(WarehouseList wareHouseList)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@WarehouseListID", wareHouseList.WarehouseListID),
                    new SqlParameter("@WarehouseListName", wareHouseList.WarehouseListName),
                    new SqlParameter("@WarehouseListDebitAccountID", wareHouseList.WarehouseListDebitAccountID),
                    new SqlParameter("@WarehouseListDebitAccountDetailID", wareHouseList.WarehouseListDebitAccountDetailID),
                    new SqlParameter("@WarehouseListCreditAccountID",wareHouseList.WarehouseListCreditAccountID),
                    new SqlParameter("@WarehouseListCreditAccountDetailID", wareHouseList.WarehouseListCreditAccountDetailID),
                    new SqlParameter("@WarehouseListManageCode", wareHouseList.WarehouseListManageCode),
                    new SqlParameter("@WarehouseListTitle", wareHouseList.WarehouseListTitle?? (object)DBNull.Value),
                    new SqlParameter("@WarehouseListAddress", wareHouseList.WarehouseListAddress?? (object)DBNull.Value),
                    new SqlParameter("@WarehouseListNote", wareHouseList.WarehouseListNote?? (object)DBNull.Value),
                    new SqlParameter("@CreateUser", UserInfo.UserID),
                    new SqlParameter("@CompanyID", CommonInfo.CompanyInfo.CompanyID),
                };
                this.Context.ExecuteDataFromProcedure("WarehouseListInsert", sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert WareHouseList Fail! " + ex.Message);
                return false;
            }
        }

        public bool DeleteWareHouseList(string WareHouseListID, string CompanyID)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
               {
                    new SqlParameter("@WarehouseListID", WareHouseListID),
                    new SqlParameter("@CreateUser", UserInfo.UserID),
                    new SqlParameter("@CompanyID", CompanyID)
                    
               };

                this.Context.ExecuteDataFromProcedure("WarehouseListDelete", sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete WareHouseList Fail! " + ex.Message);
                return false;
            }
        }


        public bool UpdateWareHouseList(WarehouseList wareHouseList)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@WarehouseListID", wareHouseList.WarehouseListID),
                    new SqlParameter("@WarehouseListName", wareHouseList.WarehouseListName),
                    new SqlParameter("@WarehouseListDebitAccountID", wareHouseList.WarehouseListDebitAccountID),
                    new SqlParameter("@WarehouseListDebitAccountDetailID", wareHouseList.WarehouseListDebitAccountDetailID),
                    new SqlParameter("@WarehouseListCreditAccountID",wareHouseList.WarehouseListCreditAccountID),
                    new SqlParameter("@WarehouseListCreditAccountDetailID", wareHouseList.WarehouseListCreditAccountDetailID),
                    new SqlParameter("@WarehouseListManageCode", wareHouseList.WarehouseListManageCode),
                    new SqlParameter("@WarehouseListTitle", wareHouseList.WarehouseListTitle?? (object)DBNull.Value),
                    new SqlParameter("@WarehouseListAddress", wareHouseList.WarehouseListAddress?? (object)DBNull.Value),
                    new SqlParameter("@WarehouseListNote", wareHouseList.WarehouseListNote?? (object)DBNull.Value),
                    new SqlParameter("@CreateUser", UserInfo.UserID),
                    new SqlParameter("@CompanyID", CommonInfo.CompanyInfo.CompanyID),
                };
                this.Context.ExecuteDataFromProcedure("WarehouseListUpdate", sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update WareHouseList Fail! " + ex.Message);
                return false;
            }
        }
    }
}

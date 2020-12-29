﻿using BSCommon.Models;
using BSCommon.Utility;
using BSServer._Core.Base;
using BSServer._Core.Const;
using BSServer._Core.Context;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BSServer.DAOs
{
    public class ItemsDAO : BaseDAO
    {
        public ItemsDAO(BSContext context) : base(context)
        {
        }

        public long GetItemSEQ()
        {
            return this.GetMaxSEQ(BSServerConst.ItemSymbol);
        }

        public long GetItemTypeSEQ()
        {
            return this.GetMaxSEQ(BSServerConst.ItemTypeSymbol);
        }

        public List<ItemType> GetItemType()
        {
            return this.Context.ItemType
                .Where(o => o.CompanyID == CommonInfo.CompanyInfo.CompanyID)
                .OrderBy(o => o.ItemTypeName)
                .ToList();
        }

        public List<Items> GetItems()
        {
            return this.Context
                .GetDataFromProcedure<Items>(
                    "SP_GetItems",
                    new SqlParameter("@CompanyID", CommonInfo.CompanyInfo.CompanyID));
        }

        public List<ItemUnit> GetItemUnit()
        {
            return this.Context.ItemUnit
                .OrderBy(o => o.ItemUnitName)
                .ToList();
        }

        public bool InsertItemType(ItemType data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@ItemTypeID", data.ItemTypeID),
                new SqlParameter("@ItemTypeName", data.ItemTypeName),
                new SqlParameter("@ItemTypeSName", data.ItemTypeSName),
                new SqlParameter("@CompanyID", data.CompanyID),
                new SqlParameter("@UpdateUser", UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("ItemTypeInsert", sqlParameters);

            return true;
        }

        public bool UpdateItemType(ItemType data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@ItemTypeID", data.ItemTypeID),
                new SqlParameter("@ItemTypeName", data.ItemTypeName),
                new SqlParameter("@ItemTypeSName", data.ItemTypeSName),
                new SqlParameter("@CompanyID", data.CompanyID),
                new SqlParameter("@UpdateUser", UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("ItemTypeUpdate", sqlParameters);

            return true;
        }

        public bool DeleteItemType(ItemType data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@ItemTypeID", data.ItemTypeID)
            };

            this.Context.ExecuteDataFromProcedure("ItemTypeDelete", sqlParameters);

            return true;
        }

        public bool InsertItems(Items data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@ItemID", data.ItemID),
                new SqlParameter("@ItemName", data.ItemName),
                new SqlParameter("@ItemSName", data.ItemSName),
                new SqlParameter("@ItemTypeID", data.ItemTypeID),
                new SqlParameter("@ItemUnitID", data.ItemUnitID),
                new SqlParameter("@ItemSpecification", data.ItemSpecification),
                new SqlParameter("@UpdateUser", UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("ItemsInsert", sqlParameters);

            return true;
        }

        public bool UpdateItems(Items data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@ItemID", data.ItemID),
                new SqlParameter("@ItemName", data.ItemName),
                new SqlParameter("@ItemSName", data.ItemSName),
                new SqlParameter("@ItemTypeID", data.ItemTypeID),
                new SqlParameter("@ItemUnitID", data.ItemUnitID),
                new SqlParameter("@ItemSpecification", data.ItemSpecification),
                new SqlParameter("@UpdateUser", UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("ItemsUpdate", sqlParameters);

            return true;
        }

        public bool DeleteItems(Items data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@ItemID", data.ItemID)
            };

            this.Context.ExecuteDataFromProcedure("ItemsDelete", sqlParameters);

            return true;
        }

        public bool InsertItemPriceCompany(ItemPriceCompany data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@ItemID", data.ItemID),
                new SqlParameter("@CompanyID", data.CompanyID),
                new SqlParameter("@ItemPrice", data.ItemPrice),
                new SqlParameter("@UpdateUser", UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("ItemPriceCompanyInsert", sqlParameters);

            return true;
        }

        public bool UpdateItemPriceCompany(ItemPriceCompany data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@ItemID", data.ItemID),
                new SqlParameter("@CompanyID", data.CompanyID),
                new SqlParameter("@ItemPrice", data.ItemPrice),
                new SqlParameter("@UpdateUser", UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("ItemPriceCompanyUpdate", sqlParameters);

            return true;
        }

        public bool DeleteItemPriceCompany(ItemPriceCompany data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@ItemID", data.ItemID),
                new SqlParameter("@CompanyID", data.CompanyID)
            };

            this.Context.ExecuteDataFromProcedure("ItemPriceCompanyDelete", sqlParameters);

            return true;
        }

        public bool InsertItemUnit(ItemUnit data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@ItemUnitID", data.ItemUnitID),
                new SqlParameter("@ItemUnitName", data.ItemUnitName),
                new SqlParameter("@UpdateUser", UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("ItemUnitInsert", sqlParameters);

            return true;
        }

        public bool UpdateItemUnit(ItemUnit data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@ItemUnitID", data.ItemUnitID),
                new SqlParameter("@ItemUnitName", data.ItemUnitName),
                new SqlParameter("@UpdateUser", UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("ItemUnitUpdate", sqlParameters);

            return true;
        }

        public bool DeleteItemUnit(ItemUnit data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@ItemUnitID", data.ItemUnitID)
            };

            this.Context.ExecuteDataFromProcedure("ItemUnitDelete", sqlParameters);

            return true;
        }
    }
}

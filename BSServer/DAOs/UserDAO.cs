﻿using BSCommon.Constant;
using BSCommon.Models;
using BSCommon.Utility;
using BSServer._Core.Base;
using BSServer._Core.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BSServer.DAOs
{
    public class UserDAO : BaseDAO
    {
        public UserDAO(BSContext context) : base(context)
        {
        }

        public UserInfo GetUserInfo(string userId)
        {
            return this.GetUsers().Where(o => o.UserID == userId).FirstOrDefault();
        }

        public List<UserInfo> GetUsers()
        {
            return this.Context.Users.Where(o => o.IsDelete == null).ToList();
        }

        public List<UserRoleInfo> GetUserRoleCompany()
        {
            return this.Context.GetDataFromProcedure<UserRoleInfo>("UserRoleCompanySelect");
        }

        public bool InsertUser(UserInfo userInfo)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", userInfo.UserID),
                new SqlParameter("@Password", SHA1Helper.GetHash(userInfo.Password)),
                new SqlParameter("@UserName", userInfo.UserName),
                new SqlParameter("@Phone", userInfo.Phone),
                new SqlParameter("@Address", userInfo.Address),
                new SqlParameter("@UpdateUserID", CommonInfo.UserInfo.UserID),
            };

            this.Context.ExecuteDataFromProcedure("UserInsert", sqlParameters);

            return true;
        }

        public bool DeleteUser(string userID)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
               {
                    new SqlParameter("@UserID", userID),
                    new SqlParameter("@UpdateUserID", CommonInfo.UserInfo.UserID)
               };

            this.Context.ExecuteDataFromProcedure("UserDelete", sqlParameters);
            return true;
        }

        public bool UpdateUser(UserInfo userInfo)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", userInfo.UserID),
                new SqlParameter("@Password", userInfo.Password),
                new SqlParameter("@UserName", userInfo.UserName),
                new SqlParameter("@Phone", userInfo.Phone),
                new SqlParameter("@Address", userInfo.Address),
                new SqlParameter("@UpdateUserID", CommonInfo.UserInfo.UserID),
            };

            this.Context.ExecuteDataFromProcedure("UserUpdate", sqlParameters);
            return true;
        }

        public bool InsertUserRoleCompany(UserRoleInfo userRoleInfo)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", userRoleInfo.UserID),
                new SqlParameter("@CompanyID", userRoleInfo.CompanyID),
                new SqlParameter("@RoleID", userRoleInfo.UserRoleID),
                new SqlParameter("@UpdateUserID", CommonInfo.UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("UserRoleCompanyInsert", sqlParameters);

            return true;
        }

        public bool DeleteUserRoleCompany(UserRoleInfo userRoleInfo)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                    new SqlParameter("@UserID", userRoleInfo.UserID),
                    new SqlParameter("@CompanyID", userRoleInfo.CompanyID),
                    new SqlParameter("@RoleID", userRoleInfo.UserRoleID)
            };

            this.Context.ExecuteDataFromProcedure("UserRoleCompanyDelete", sqlParameters);

            return true;
        }
    }
}

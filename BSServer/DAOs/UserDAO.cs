using BSCommon.Models;
using BSCommon.Utility;
using BSServer._Core.Base;
using BSServer._Core.Context;
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

        public Users GetUserInfo(string userId)
        {
            return this.Context.Users
                .FirstOrDefault(o => o.UserID == userId);
        }

        public List<Users> GetUsers()
        {
            return this.Context.Users.ToList();
        }

        public List<UserRoleCompany> GetUserRoleCompany(string userID = "")
        {
            return this.Context
                .GetDataFromProcedure<UserRoleCompany>("UserRoleCompanySelect")
                .Where(o => o.UserID == userID || string.IsNullOrEmpty(userID))
                .ToList();
        }

        public bool InsertUserList(Users data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", data.UserID),
                new SqlParameter("@Password", data.Password),
                new SqlParameter("@UserName", data.UserName),
                new SqlParameter("@Phone", data.Phone),
                new SqlParameter("@Address", data.Address),
                new SqlParameter("@UpdateUser", UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("UserListInsert", sqlParameters);

            return true;
        }

        public bool UpdateUserList(Users data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", data.UserID),
                new SqlParameter("@Password", data.Password),
                new SqlParameter("@UserName", data.UserName),
                new SqlParameter("@Phone", data.Phone),
                new SqlParameter("@Address", data.Address),
                new SqlParameter("@UpdateUser", UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("UserListUpdate", sqlParameters);

            return true;
        }

        public bool DeleteUserList(Users data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", data.UserID)
            };

            this.Context.ExecuteDataFromProcedure("UserListDelete", sqlParameters);

            return true;
        }

        public bool InsertUserRoleCompany(UserRoleCompany data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", data.UserID),
                new SqlParameter("@CompanyID", data.CompanyID),
                new SqlParameter("@RoleID", data.UserRoleID),
                new SqlParameter("@UpdateUser", UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("UserRoleCompanyInsert", sqlParameters);

            return true;
        }

        public bool DeleteUserRoleCompany(UserRoleCompany data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", data.UserID),
                new SqlParameter("@CompanyID", data.CompanyID),
                new SqlParameter("@RoleID", data.UserRoleID)
            };

            this.Context.ExecuteDataFromProcedure("UserRoleCompanyDelete", sqlParameters);

            return true;
        }
    }
}

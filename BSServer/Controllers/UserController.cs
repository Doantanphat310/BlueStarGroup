using BSCommon.Models;
using BSServer._Core.Base;
using BSServer._Core.Context;
using BSServer.DAOs;
using BSServer.Logics;
using System.Collections.Generic;

namespace BSServer.Controllers
{
    public class UserController : BaseController
    {
        private BSContext Context { get; set; }

        private UserLogic UserLogic { get; set; }

        private UserDAO UserDAO { get; set; }

        public UserController()
        {
            this.Context = new BSContext();
            this.UserDAO = new UserDAO(this.Context);
            this.UserLogic = new UserLogic(this.Context);
        }

        public UserInfo GetUserInfo(string userId)
        {
            return this.UserDAO.GetUserInfo(userId);
        }

        public List<UserInfo> GetUsers()
        {
            return this.UserDAO.GetUsers();
        }

        public List<UserRoleInfo> GetUserRoleCompany()
        {
            return this.UserDAO.GetUserRoleCompany();
        }

        public bool InsertUser(UserInfo userInfo)
        {
            return this.UserDAO.InsertUser(userInfo);
        }

        public bool UpdateUser(UserInfo userInfo)
        {
            return this.UserDAO.UpdateUser(userInfo);
        }

        public bool DeleteUser(string userID)
        {
            return this.UserDAO.DeleteUser(userID);
        }

        public bool SaveUser(List<UserInfo> dataList)
        {
            return this.UserLogic.SaveUser(dataList);
        }

        public bool SaveUserRoleCompany(List<UserRoleInfo> dataList)
        {
            return this.UserLogic.SaveUserRoleCompany(dataList);
        }
    }
}

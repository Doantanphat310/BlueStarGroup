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
        private UserLogic UserLogic { get; set; }

        private UserDAO UserDAO { get; set; }

        public UserController()
        {
            this.UserDAO = new UserDAO(this.Context);
            this.UserLogic = new UserLogic(this.Context);
        }

        public Users GetUserInfo(string userId)
        {
            return this.UserDAO.GetUserInfo(userId);
        }

        public List<Users> GetUsers()
        {
            return this.UserDAO.GetUsers();
        }

        public List<UserRoleCompany> GetUserRoleCompany(string userID = null)
        {
            return this.UserDAO.GetUserRoleCompany(userID);
        }

        public bool SaveUser(List<Users> dataList)
        {
            return this.UserLogic.SaveUser(dataList);
        }

        public bool SaveUserRoleCompany(List<UserRoleCompany> dataList)
        {
            return this.UserLogic.SaveUserRoleCompany(dataList);
        }
    }
}

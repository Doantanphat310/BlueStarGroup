using BSCommon.Models;
using BSServer._Core.Context;
using BSServer.DAOs;

namespace BSServer.Controllers
{
    public class UserController
    {
        private BSContext Context { get; set; }

        private UserDAO UserDAO { get; set; }

        public UserController()
        {
            this.Context = new BSContext();
            this.UserDAO = new UserDAO(this.Context);
        }

        public User GetUserInfo(string userId)
        {
            return this.UserDAO.GetUserInfo(userId);
        }
    }
}

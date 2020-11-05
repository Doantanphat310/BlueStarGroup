using BSCommon.Models;
using BSServer._Core.Context;
using BSServer.DAOs;

namespace BSServer.Controllers
{
    public class LoginController
    {
        private BSContext Context { get; set; }

        private UserDAO UserDAO { get; set; }

        public LoginController()
        {
            this.Context = new BSContext();
            this.UserDAO = new UserDAO(this.Context);
        }

        public UserInfo GetUserInfo(string userId)
        {
            return this.UserDAO.GetUserInfo(userId);
        }
    }
}

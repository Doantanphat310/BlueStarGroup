using BSCommon.Constant;
using BSCommon.Models;
using BSServer._Core.Context;
using System.Linq;

namespace BSServer.DAOs
{
    public class UserDAO
    {
        public UserDAO(BSContext context)
        {
            this.Context = context;
        }

        private BSContext Context { get; set; }

        public User GetUserInfo(string userId)
        {
            return this.Context.Users.Where(o => o.UserID == userId && o.IsDelete == null).FirstOrDefault<User>();
        }
    }
}

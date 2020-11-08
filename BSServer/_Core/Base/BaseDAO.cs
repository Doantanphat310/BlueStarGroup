using BSCommon.Models;
using System;

namespace BSServer._Core.Base
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseDAO : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public BaseDAO(User userInfo)
        {
            //this.Logger = logger;
            this.UserInfo = userInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        //protected ILogger Logger { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected User UserInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
        }
    }
}
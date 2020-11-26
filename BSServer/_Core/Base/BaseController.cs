using BSServer._Core.Context;
using System;

namespace BSServer._Core.Base
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseController : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public BaseController()
        {
            this.Context = new BSContext();
            //this.Logger = logger;
            //this.UserInfo = userInfo;
        }

        protected BSContext Context { get; set; }

        /// <summary>
        /// 
        /// </summary>
        //protected ILogger Logger { get; set; }

        /// <summary>
        /// 
        /// </summary>
        //protected UserInfo UserInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// 

        public void Dispose()
        {
        }
    }
}
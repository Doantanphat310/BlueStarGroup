using BSCommon.Models;
using BSServer._Core.Context;
using System;
using System.Data.Entity;

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
            //this.Logger = logger;
            //this.UserInfo = userInfo;
        }

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
using BSCommon.Models;
using BSServer._Core.Context;
using System;
using System.Data.Entity;
using System.Data.SqlClient;

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
        public BaseDAO(BSContext context)
        {
            //this.Logger = logger;
            //this.UserInfo = userInfo;
            this.Context = context;
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

        /// <summary>
        /// 
        /// </summary>
        public BSContext Context { get; set; }

        protected long GetMaxSEQ(string type)
        {
            return this.Context.ExecuteScalar(
                "GetSEQ",
                new SqlParameter("@Type", type));
        }

        public void Dispose()
        {
        }
    }
}
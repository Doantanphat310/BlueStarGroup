using BSServer._Core.Context;
using System;

namespace BSServer._Core.Base
{
    public class BaseLogic : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public BaseLogic(BSContext context)
        {
            //this.Logger = logger;
            this.Context = context;
        }

        public BSContext Context { get; set; }

        /// <summary>
        /// 
        /// </summary>
        //protected ILogger Logger { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
        }
    }
}

using BSCommon.Models;
using BSServer._Core.Context;
using BSServer.DAOs;
using System.Collections.Generic;

namespace BSServer.Controllers
{
   public class VouchersTypeController
    {
        private BSContext Context { get; set; }

        private VouchersTypeDAO VouchersTypeDAO { get; set; }

        public VouchersTypeController()
        {
            this.Context = new BSContext();
            this.VouchersTypeDAO = new VouchersTypeDAO(this.Context);
        }

        public List<VouchersType> GetVouchersTypeInfo(string status)
        {
            return this.VouchersTypeDAO.GetVouchersTypeInfo(status);
        }
    }
}

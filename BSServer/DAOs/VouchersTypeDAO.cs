using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSCommon.Constant;
using BSCommon.Models;
using BSServer._Core.Context;

namespace BSServer.DAOs
{
    public class VouchersTypeDAO
    {
        public VouchersTypeDAO(BSContext context)
        {
            this.Context = context;
        }

        private BSContext Context { get; set; }

        public List<VouchersType> GetVouchersTypeInfo(string status)
        {
            return this.Context.VoucherTypes.Where(o => o.Status == status).ToList();

            //.Select(x => new { x.ServerName, x.ProcessID, x.Username }).ToList();
        }
    }
}

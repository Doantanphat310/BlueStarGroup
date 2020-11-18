using BSCommon.Constant;
using BSCommon.Models;
using BSServer._Core.Base;
using BSServer._Core.Context;
using System.Collections.Generic;
using System.Linq;

namespace BSServer.DAOs
{
    public class MasterInfoDAO : BaseDAO
    {
        public MasterInfoDAO(BSContext context) : base(context)
        {
        }

        public List<MasterInfo> GetMasterInfos(string masterCd)
        {
            return this.Context.Database
              .SqlQuery<MasterInfo>("MasterInfoSelect")
              .Where(o => o.MasterCd == masterCd)
              .ToList();
        }
    }
}

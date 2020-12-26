using BSCommon.Models;
using BSServer._Core.Base;
using BSServer._Core.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSServer.DAOs
{
   public class KetChuyenDAO : BaseDAO
    {
        public KetChuyenDAO(BSContext context) : base(context) { }

        public List<KetChuyenValue> KetChuyenData(DateTime StartDate, DateTime EndDate, string CompanyID)
        {
            //@StartDate datetime, @EndDate datetime, @CompanyID varchar(50)
            return this.Context.Database.SqlQuery<KetChuyenValue>("VoucherDetailKetChuyenData @StartDate, @EndDate, @CompanyID",
                new SqlParameter("@StartDate", StartDate),
                new SqlParameter("@EndDate", EndDate),
                new SqlParameter("@CompanyID", CompanyID)
                ).ToList();
        }
    }
}

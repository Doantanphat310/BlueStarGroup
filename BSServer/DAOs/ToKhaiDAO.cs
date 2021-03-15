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
   public  class ToKhaiDAO : BaseDAO
    {
        public ToKhaiDAO(BSContext context) : base(context) { }

        public List<ToKhai> ToKhaiData(DateTime FromDate, DateTime Todate, string invoiceType, string CompanyID)
        {
            return this.Context.Database.SqlQuery<ToKhai>("ToKhaiSelect @FromDate, @Todate, @InvoiceType, @CompanyID",
                new SqlParameter("@FromDate", FromDate),
                new SqlParameter("@Todate", Todate),
                new SqlParameter("@InvoiceType", invoiceType),
                new SqlParameter("@CompanyID", CompanyID)
                ).ToList();
        }
    }
}

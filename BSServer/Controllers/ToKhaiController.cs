using BSCommon.Models;
using BSServer._Core.Context;
using BSServer.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSServer.Controllers
{
   public class ToKhaiController
    {
        /* public List<ToKhai> ToKhaiData(DateTime FromDate, DateTime Todate, string invoiceType, string CompanyID) */
        private BSContext Context { get; set; }

        // private BalanceLogic BalanceLogic { get; set; }

        private ToKhaiDAO ToKhaiDAO { get; set; }

        public ToKhaiController()
        {
            this.Context = new BSContext();
            this.ToKhaiDAO = new ToKhaiDAO(this.Context);
            //  this.BalanceLogic = new BalanceLogic(this.Context);
        }

        public List<ToKhai> ToKhaiSelect(DateTime FromDate,DateTime Todate, string invoiceType, string CompanyID)
        {
            return this.ToKhaiDAO.ToKhaiData(FromDate, Todate, invoiceType, CompanyID);
        }
    }
}

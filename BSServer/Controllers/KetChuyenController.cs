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
   public class KetChuyenController
    {
        private BSContext Context { get; set; }

        // private BalanceLogic BalanceLogic { get; set; }

        private KetChuyenDAO KetChuyenDAO { get; set; }

        public KetChuyenController()
        {
            this.Context = new BSContext();
            this.KetChuyenDAO = new KetChuyenDAO(this.Context);
            //  this.BalanceLogic = new BalanceLogic(this.Context);
        }

        public List<KetChuyenValue> KetChuyentableSelect(DateTime StartDate, DateTime EndDate, string CompanyID)
        {
            return this.KetChuyenDAO.KetChuyenData(StartDate, EndDate, CompanyID);
        }
    }
}

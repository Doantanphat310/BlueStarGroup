using BSCommon.Models;
using BSServer._Core.Context;
using BSServer.DAOs;
using BSServer.Logics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSServer.Controllers
{
    public class KichBanKetChuyentableController
    {
        private BSContext Context { get; set; }

        private KichBanKetChuyentableLogic KichBanKetChuyentableLogic { get; set; }

        private KichBanKetChuyentableDAO KichBanKetChuyentableDAO { get; set; }

        public KichBanKetChuyentableController()
        {
            this.Context = new BSContext();
            this.KichBanKetChuyentableDAO = new KichBanKetChuyentableDAO(this.Context);
           this.KichBanKetChuyentableLogic = new KichBanKetChuyentableLogic(this.Context);
        }

        public List<KichBanKetChuyentable> KichBanKetChuyentableSelect(string companyID)
        {
            return this.KichBanKetChuyentableDAO.KichBanKetChuyentableSelect(companyID);
        }

        public bool SaveKichBanKetChuyentable(List<KichBanKetChuyentable> dataList)
        {
            return this.KichBanKetChuyentableLogic.SaveKichBanKetChuyentable(dataList);
        }
    }
}

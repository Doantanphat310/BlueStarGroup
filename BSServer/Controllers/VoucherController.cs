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
    public class VoucherController
    {
        private BSContext Context { get; set; }

        private VoucherDAO VoucherDAO { get; set; }


        private VoucherLogic VoucherLogic { get; set; }

        public VoucherController()
        {
            this.Context = new BSContext();
            this.Context.Database.Log = Console.Write;

            this.VoucherDAO = new VoucherDAO(this.Context);
            this.VoucherLogic = new VoucherLogic(this.Context);
        }

        public List<Voucher> GetVouchers()
        {
            return this.VoucherDAO.GetVouchers();
        }
        public List<Voucher> GetVouchersCompany(string companyID)
        {
            return this.VoucherDAO.GetVouchersCompany(companyID);
        }

        public List<Voucher> GetVouchersConditionCompany(string companyID, DateTime NgayBD, DateTime NgayKT, string voucherType)
        {
            return this.VoucherDAO.GetVouchersCondition(companyID,NgayBD,NgayKT,voucherType);
        }


        public bool SaveCustommers(List<VouchersInsert> voucherCompanies)
        {
            return this.VoucherLogic.SaveVouchersCompany(voucherCompanies);
        }

        public void Dispose()
        {
        }
    }
}

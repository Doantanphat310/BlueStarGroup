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

        private VoucherLogic VoucherLogic { get; set; }

        private VoucherDAO VoucherDAO { get; set; }

        public VoucherController()
        {
            this.Context = new BSContext();
            this.VoucherDAO = new VoucherDAO(this.Context);
            this.VoucherLogic = new VoucherLogic(this.Context);
        }

        public List<Voucher> GetVouchersCompany(DateTime VoucherDate, string companyID)
        {
            return this.VoucherDAO.GetVouchersCompany(VoucherDate,companyID);
        }
        //GetVouchersCondition
        public List<Voucher> GetVouchersCondition(string companyID, DateTime NgayBD, DateTime NgayKT, string voucherType)
        {
            return this.VoucherDAO.GetVouchersCondition(companyID, NgayBD, NgayKT, voucherType);
        }

        public bool InsertVouchers(Voucher voucherInfo)
        {
            return this.VoucherDAO.InsertVouchers(voucherInfo);
        }

        public bool UpdateVoucher(Voucher voucherInfo)
        {
            return this.VoucherDAO.UpdateVoucher(voucherInfo);
        }

        public bool DeleteVoucher(string voucherID, string companyID)
        {
            return this.VoucherDAO.DeleteVoucher(voucherID,companyID);
        }

        public bool SaveVoucher(List<Voucher> dataList)
        {
            return this.VoucherLogic.SaveVoucher(dataList);
        }
    }
}

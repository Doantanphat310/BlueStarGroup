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
   public  class VoucherDetailController
    {

        private BSContext Context { get; set; }

        private VoucherDetailLogic VoucherDetailLogic { get; set; }

        private VoucherDetailDAO VoucherDetailDAO { get; set; }

        public VoucherDetailController()
        {
            this.Context = new BSContext();
            this.VoucherDetailDAO = new VoucherDetailDAO(this.Context);
            this.VoucherDetailLogic = new VoucherDetailLogic(this.Context);
        }

        public List<VoucherDetail> GetVouchersDetailSelectVoucherID(string voucherID,string companyID)
        {
            return this.VoucherDetailDAO.GetVouchersDetailSelectVoucherID(voucherID, companyID);
        }
        

        public bool InsertVouchersDetail(VoucherDetail voucherDetailInfo)
        {
            return this.VoucherDetailDAO.InsertVouchersDetail(voucherDetailInfo);
        }

        public bool UpdateVoucherDetail(VoucherDetail voucherDetailInfo)
        {
            return this.VoucherDetailDAO.UpdateVoucherDetail(voucherDetailInfo);
        }

        public bool DeleteVoucherDetail(string voucherDetailID, string companyID)
        {
            return this.VoucherDetailDAO.DeleteVoucherDetail(voucherDetailID,companyID);
        }

        public bool SaveVoucherDetail(List<VoucherDetail> dataList)
        {
            return this.VoucherDetailLogic.SaveVoucherDetail(dataList);
        }
        
    }
}

using BSCommon.Models;
using BSServer._Core.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSServer.DAOs
{
   public  class VoucherDetailDinhKhoanDAO
    {
        public VoucherDetailDinhKhoanDAO(BSContext context)
        {
            this.Context = context;
        }
        private BSContext Context { get; set; }

        public List<VoucherDetailDinhKhoan> GetVoucherDetailDinhKhoan(string voucherID)
        {
            SqlParameter param = new SqlParameter("@VoucherID", voucherID);
            return this.Context.Database
                .SqlQuery<VoucherDetailDinhKhoan>("SPSelectVoucherDinhKhoanWithVoucher @VoucherID", param)
                .ToList();
        }

    }
}

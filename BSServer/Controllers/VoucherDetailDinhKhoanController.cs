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
    public class VoucherDetailDinhKhoanController
    {
        private BSContext Context { get; set; }
        private VoucherDetailDinhKhoanDAO VoucherDetailDinhKhoanDAO { get; set; }
        public VoucherDetailDinhKhoanController()
        {
            this.Context = new BSContext();
            this.Context.Database.Log = Console.Write;
            this.VoucherDetailDinhKhoanDAO = new VoucherDetailDinhKhoanDAO(this.Context);
        }
        public List<VoucherDetailDinhKhoan> GetVoucherDetailDinhKhoan(string voucherID)
        {
            return this.VoucherDetailDinhKhoanDAO.GetVoucherDetailDinhKhoan(voucherID);
        }
        public void Dispose()
        {
        }
    }
}

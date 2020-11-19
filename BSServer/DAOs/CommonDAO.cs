using BSServer._Core.Base;
using BSServer._Core.Const;
using BSServer._Core.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSServer.DAOs
{
    public class CommonDAO : BaseDAO
    {
        public CommonDAO(BSContext context) : base(context)
        {
        }

        public long GetMaxSEQ(string type)
        {
            return this.Context.ExecuteScalar(
                "GetSEQ",
                new SqlParameter("@Type", type));
        }

        public string GetCustomerID()
        {
            long seq = GetMaxSEQ(SSServerConst.CustomerSymbol) + 1;
            return $"{SSServerConst.CustomerSymbol}{seq.ToString("0000000000")}";
        }

        public string GetItemID()
        {
            long seq = GetMaxSEQ(SSServerConst.ItemSymbol) + 1;
            return $"{SSServerConst.ItemSymbol}{seq.ToString("0000000000")}";
        }

        public string GetCompanyID()
        {
            long seq = GetMaxSEQ(SSServerConst.CompanySymbol) + 1;
            return $"{SSServerConst.CompanySymbol}{seq.ToString("0000000000")}";
        }

        public string GetVoucherID()
        {
            long seq = GetMaxSEQ(SSServerConst.VoucherSymbol) + 1;
            return $"{SSServerConst.VoucherSymbol}{DateTime.Now.ToString("yyyyMMdd")}{seq.ToString("000000")}";
        }
        
        public string GetVoucherDetailID()
        {
            long seq = GetMaxSEQ(SSServerConst.VoucherDetailSymbol) + 1;
            return $"{SSServerConst.VoucherDetailSymbol}{DateTime.Now.ToString("yyyyMMdd")}{seq.ToString("000000")}";
        }

        public string GetInvoiceID()
        {
            long seq = GetMaxSEQ(SSServerConst.InvoiceSymbol) + 1;
            return $"{SSServerConst.InvoiceSymbol}{DateTime.Now.ToString("yyyyMMdd")}{seq.ToString("000000")}";
        }
    }
}

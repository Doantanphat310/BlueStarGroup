using BSCommon.Models;
using BSCommon.Utility;
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
   public class KichBanKetChuyentableDAO : BaseDAO
    {
        public KichBanKetChuyentableDAO(BSContext context): base(context) { }

        public List<KichBanKetChuyentable> KichBanKetChuyentableSelect(string CompanyID)
        {
            return this.Context.Database.SqlQuery<KichBanKetChuyentable>("KichBanKetChuyentableSelect @CompanyID",
                new SqlParameter("@CompanyID", CompanyID)
                ).ToList();
        }


        public bool InsertKichBanKetChuyentable(KichBanKetChuyentable data)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                new SqlParameter("@GroupCode", data.GroupCode),
                new SqlParameter("@KetChuyenDebitAccountID", data.KetChuyenDebitAccountID),
                new SqlParameter("@KetChuyenCreditAccountID", data.KetChuyenCreditAccountID),
                new SqlParameter("@CreateUser", UserInfo.UserID),
                new SqlParameter("@CompanyID", CommonInfo.CompanyInfo.CompanyID)
                };
                this.Context.ExecuteDataFromProcedure("KichBanKetChuyentableInsert", sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return false;
            }
        }

        public bool DeleteKichBanKetChuyentable(KichBanKetChuyentable data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@GroupCode", data.GroupCode),
                new SqlParameter("@KetChuyenDebitAccountID", data.KetChuyenDebitAccountID),
                new SqlParameter("@KetChuyenCreditAccountID", data.KetChuyenCreditAccountID),
                new SqlParameter("@CreateUser", UserInfo.UserID),
                new SqlParameter("@CompanyID", CommonInfo.CompanyInfo.CompanyID)
            };
            this.Context.ExecuteDataFromProcedure("KichBanKetChuyentableDelete", sqlParameters);
            return true;
        }
    }
}

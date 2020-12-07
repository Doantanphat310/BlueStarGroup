using BSCommon.Models;
using BSCommon.Utility;
using BSServer._Core.Base;
using BSServer._Core.Context;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BSServer.DAOs
{
    public class MasterInfoDAO : BaseDAO
    {
        public MasterInfoDAO(BSContext context) : base(context)
        {
        }

        public List<MasterInfo> GetMasterInfos(string key)
        {
            return this.Context.Database
              .SqlQuery<MasterInfo>("MasterInfoSelect")
              .Where(o => o.Key == key)
              .ToList();
        }

        public bool InsertMasterInfo(MasterInfo data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MasterCd", data.Key),
                new SqlParameter("@DetailCd", data.Id),
                new SqlParameter("@Value", data.Value),
                new SqlParameter("@Value2", data.Value2),
                new SqlParameter("@Value3", data.Value3),
                new SqlParameter("@Value4", data.Value4),
                new SqlParameter("@Value5", data.Value5),
                new SqlParameter("@UpdateUser", CommonInfo.UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("MasterInfoInsert", sqlParameters);

            return true;
        }

        public bool UpdateMasterInfo(MasterInfo data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MasterCd", data.Key),
                new SqlParameter("@DetailCd", data.Id),
                new SqlParameter("@Value", data.Value),
                new SqlParameter("@Value2", data.Value2),
                new SqlParameter("@Value3", data.Value3),
                new SqlParameter("@Value4", data.Value4),
                new SqlParameter("@Value5", data.Value5),
                new SqlParameter("@UpdateUser", CommonInfo.UserInfo.UserID)
            };

            this.Context.ExecuteDataFromProcedure("MasterInfoUpdate", sqlParameters);

            return true;
        }

        public bool DeleteMasterInfo(MasterInfo data)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MasterCd", data.Key),
                new SqlParameter("@DetailCd", data.Id)
            };

            this.Context.ExecuteDataFromProcedure("MasterInfoDelete", sqlParameters);

            return true;
        }
    }
}

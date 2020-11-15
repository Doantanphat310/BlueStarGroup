using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace BSServer._Core.Base
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseDbContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public BaseDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public List<T> GetDataFromProcedure<T>(string procedureName, params SqlParameter[] sqlParameter)
        {
            string paramString = GetSqlParamString(sqlParameter);
            string sql = $@"
{procedureName}
{paramString}
";

            return this.Database.SqlQuery<T>(sql, sqlParameter).ToList();
        }

        public int ExecuteDataFromProcedure(string procedureName, params SqlParameter[] sqlParameter)
        {
            string paramString = GetSqlParamString(sqlParameter);
            string sql = $@"
{procedureName}
{paramString}
";

            return this.Database.ExecuteSqlCommand(sql, sqlParameter);
        }

        private string GetSqlParamString(SqlParameter[] sqlParameter)
        {
            return string.Join(", ", sqlParameter.Select(o => o.ParameterName));
        }
    }
}

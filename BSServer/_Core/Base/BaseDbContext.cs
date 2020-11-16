using System;
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

            try
            {
                return this.Database.SqlQuery<T>(sql, sqlParameter).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Xử lý thất bại. " + ex.Message);
                return null;
            }
        }

        public int ExecuteDataFromProcedure(string procedureName, params SqlParameter[] sqlParameter)
        {
            string paramString = GetSqlParamString(sqlParameter);
            string sql = $@"
{procedureName}
{paramString}
";
            try
            {
return this.Database.ExecuteSqlCommand(sql, sqlParameter);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Xử lý thất bại. " + ex.Message);
                return -1;
            }
            
        }

        private string GetSqlParamString(SqlParameter[] sqlParameter)
        {
            return string.Join(", ", sqlParameter.Select(o => o.ParameterName));
        }
    }
}

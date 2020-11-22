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

        public long ExecuteScalar(string procedureName, params SqlParameter[] sqlParameter)
        {
            string paramString = GetSqlParamString(sqlParameter);
            string sql = $@"
{procedureName}
{paramString}
";

            try
            {
                return this.Database.SqlQuery<long>(sql, sqlParameter).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Xử lý thất bại. " + ex.Message);
                throw ex;
            }
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
                Console.WriteLine(@"Xử lý thất bại. " + ex.Message);
                throw ex;
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
                foreach (var param in sqlParameter)
                {
                    param.Value = param.Value ?? DBNull.Value;
                }

                return this.Database.ExecuteSqlCommand(sql, sqlParameter);
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Xử lý thất bại. " + ex.Message);
                throw ex;
            }

        }

        private string GetSqlParamString(SqlParameter[] sqlParameter)
        {
            return string.Join(", ", sqlParameter.Select(o => o.ParameterName));
        }
    }
}

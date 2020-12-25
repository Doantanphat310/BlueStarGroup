using BSCommon.Utility;
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
            this.Database.Log = message => BSLog.Logger.Debug(message);
        }

        public long ExecuteScalar(string procedureName, params SqlParameter[] sqlParameter)
        {
            string paramString = GetSqlParamString(sqlParameter);
            string sql = $"{procedureName} {paramString}";

            try
            {
                WriteQueryLog(sql, sqlParameter);
                return this.Database.SqlQuery<long>(sql, sqlParameter).FirstOrDefault();
            }
            catch (Exception ex)
            {
                BSLog.Logger.Error(ex, procedureName);
                throw;
            }
        }

        public List<T> GetDataFromProcedure<T>(string procedureName, params SqlParameter[] sqlParameter)
        {
            string paramString = GetSqlParamString(sqlParameter);
            string sql = $@"{procedureName} {paramString}";

            try
            {
                foreach (var param in sqlParameter)
                {
                    param.Value = param.Value ?? DBNull.Value;
                }

                WriteQueryLog(procedureName, sqlParameter);
                return this.Database.SqlQuery<T>(sql, sqlParameter).ToList();
            }
            catch (Exception ex)
            {
                BSLog.Logger.Error(ex, procedureName);
                throw ex;
            }
        }

        public int ExecuteDataFromProcedure(string procedureName, params SqlParameter[] sqlParameter)
        {
            string paramString = GetSqlParamString(sqlParameter);
            string sql = $@"{procedureName} {paramString}";
            try
            {
                foreach (var param in sqlParameter)
                {
                    param.Value = param.Value ?? DBNull.Value;
                }

                WriteQueryLog(sql, sqlParameter);
                return this.Database.ExecuteSqlCommand(sql, sqlParameter);
            }
            catch (Exception ex)
            {
                BSLog.Logger.Error(ex, procedureName);
                throw ex;
            }
        }

        private string GetSqlParamString(SqlParameter[] sqlParameter)
        {
            return string.Join(", ", sqlParameter.Select(o => o.ParameterName));
        }

        private void WriteQueryLog(string sql, params SqlParameter[] sqlParameter)
        {
            string parram = string.Join(", ", sqlParameter.Select(o => $"{o.ParameterName}: {o.Value}"));
            BSLog.Logger.Trace($"{sql}|{parram}");
        }
    }
}

using SQLAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLAuto
{
    public static class CommonUtility
    {
        private static Dictionary<string, string> ConvertColumn = new Dictionary<string, string>
        {
            { "CreateDate", "GETDATE()" },
            { "UpdateDate", "GETDATE()" },
            { "CreateUser", "@UserId" },
            { "UpdateUser", "@UserId" }
        };

        private static readonly HashSet<string> IgnoreColumn = new HashSet<string>
        {
            "CreateDate",
            "UpdateDate",
            "CreateUser",
            "UpdateUser",
            "IsDelete"
        };

        private static Dictionary<string, string> TypeMap = new Dictionary<string, string>()
        {
            {"varchar", "string" },
            {"nvarchar", "string" },
            {"money", "decimal" },
            {"datetime", "datetime" },
            {"decimal", "decimal" },
            {"bit", "bool" },
            {"float", "float" },
            {"tinyint", "byte" },
            {"numeric", "decimal" },
            {"int", "int" },
        };
        //        typeMap[typeof(byte)] = DbType.Byte;
        //typeMap[typeof(sbyte)] = DbType.SByte;
        //typeMap[typeof(short)] = DbType.Int16;
        //typeMap[typeof(ushort)] = DbType.UInt16;
        //typeMap[typeof(int)] = DbType.Int32;
        //typeMap[typeof(uint)] = DbType.UInt32;
        //typeMap[typeof(long)] = DbType.Int64;
        //typeMap[typeof(ulong)] = DbType.UInt64;
        //typeMap[typeof(float)] = DbType.Single;
        //typeMap[typeof(double)] = DbType.Double;
        //typeMap[typeof(decimal)] = DbType.Decimal;
        //typeMap[typeof(bool)] = DbType.Boolean;
        //typeMap[typeof(string)] = DbType.String;
        //typeMap[typeof(char)] = DbType.StringFixedLength;
        //typeMap[typeof(Guid)] = DbType.Guid;
        //typeMap[typeof(DateTime)] = DbType.DateTime;
        //typeMap[typeof(DateTimeOffset)] = DbType.DateTimeOffset;
        //typeMap[typeof(byte[])] = DbType.Binary;
        //typeMap[typeof(byte?)] = DbType.Byte;
        //typeMap[typeof(sbyte?)] = DbType.SByte;
        //typeMap[typeof(short?)] = DbType.Int16;
        //typeMap[typeof(ushort?)] = DbType.UInt16;
        //typeMap[typeof(int?)] = DbType.Int32;
        //typeMap[typeof(uint?)] = DbType.UInt32;
        //typeMap[typeof(long?)] = DbType.Int64;
        //typeMap[typeof(ulong?)] = DbType.UInt64;
        //typeMap[typeof(float?)] = DbType.Single;
        //typeMap[typeof(double?)] = DbType.Double;
        //typeMap[typeof(decimal?)] = DbType.Decimal;
        //typeMap[typeof(bool?)] = DbType.Boolean;
        //typeMap[typeof(char?)] = DbType.StringFixedLength;
        //typeMap[typeof(Guid?)] = DbType.Guid;
        //typeMap[typeof(DateTime?)] = DbType.DateTime;
        //typeMap[typeof(DateTimeOffset?)] = DbType.DateTimeOffset;
        //typeMap[typeof(System.Data.Linq.Binary)] = DbType.Binary;
        public static string GeneralUpdateSP(string tableName, List<ColumnInfo> columnInfos)
        {
            string result;
            string format = SPFormat.UPDATE;
            string parramStr = "";
            string columnsStr = "";
            string whereStr = "";

            foreach (var col in columnInfos)
            {
                if (IgnoreColumn.Contains(col.ColumnName))
                {
                    continue;
                }

                parramStr = parramStr.AddStr(GetSQLParam(col.ColumnName, col.TypeName, col.TypeSize));

                if (col.IsKey == true)
                {
                    whereStr = whereStr.AddExpression($"{col.ColumnName} = @{col.ColumnName}", "AND");
                }
                else
                {
                    columnsStr = columnsStr.AddStr($"{col.ColumnName} = @{col.ColumnName}");
                }
            }

            parramStr = parramStr.TrimStr();
            columnsStr = columnsStr.TrimStr();
            whereStr = whereStr.TrimStr();
            result = string.Format(format, tableName, parramStr, columnsStr, whereStr);

            return result;
        }

        public static string GeneralInsertSP(string tableName, List<ColumnInfo> columnInfos)
        {
            string result;
            string format = SPFormat.INSERT_PLUS;

            string parramStr = "";
            string columnsStr = "";
            string valuesStr = "";

            foreach (var col in columnInfos)
            {
                if (IgnoreColumn.Contains(col.ColumnName))
                {
                    continue;
                }

                parramStr = parramStr.AddStr(GetSQLParam(col.ColumnName, col.TypeName, col.TypeSize));
                columnsStr = columnsStr.AddStr(col.ColumnName);
                valuesStr = valuesStr.AddStr($"@{col.ColumnName}");
            }

            parramStr = parramStr.TrimStr();
            columnsStr = columnsStr.TrimStr();
            valuesStr = valuesStr.TrimStr();
            result = string.Format(format, tableName, parramStr, columnsStr, valuesStr);

            return result;
        }

        public static string GeneralDeleteSP(string tableName, List<ColumnInfo> columnInfos)
        {
            string result;
            string format = SPFormat.DELETE;
            string parramStr = "";
            string whereStr = "";

            foreach (var col in columnInfos)
            {
                if (IgnoreColumn.Contains(col.ColumnName))
                {
                    continue;
                }

                if (col.IsKey == true)
                {
                    parramStr = parramStr.AddStr(GetSQLParam(col.ColumnName, col.TypeName, col.TypeSize));
                    whereStr = whereStr.AddExpression($"{col.ColumnName} = @{col.ColumnName}", "AND");
                }
            }

            parramStr = parramStr.TrimStr();
            whereStr = whereStr.TrimStr();
            result = string.Format(format, tableName, parramStr, whereStr);

            return result;
        }

        public static string GeneralDeleteLogicSP(string tableName, List<ColumnInfo> columnInfos)
        {
            string result;
            string parramStr = "";
            string whereStr = "";

            foreach (var col in columnInfos)
            {
                if (IgnoreColumn.Contains(col.ColumnName))
                {
                    continue;
                }

                if (col.IsKey == true)
                {
                    parramStr = parramStr.AddStr(GetSQLParam(col.ColumnName, col.TypeName, col.TypeSize));
                    whereStr = whereStr.AddExpression($"{col.ColumnName} = @{col.ColumnName}", "AND ");
                }
            }

            parramStr = parramStr.TrimStr();
            whereStr = whereStr.TrimStr();
            result = string.Format(SPFormat.DELETE_LOGIC, tableName, parramStr, whereStr);

            return result;
        }

        public static string GeneralModel(string tableName, List<ColumnInfo> columnInfos)
        {
            string result;
            string column;
            string columnsStr = "";
            string keyStr;
            string nullStr;
            string namespaceStr = "BSCommon.Models";
            string typeName;

            foreach (var col in columnInfos)
            {
                column = string.Empty;
                keyStr = string.Empty;
                if (IgnoreColumn.Contains(col.ColumnName))
                {
                    continue;
                }
                typeName = TypeMap[col.TypeName];
                nullStr = col.IsNullable && typeName != "string" ? "?" : string.Empty;

                if (col.IsKey == true && col.KeyOrder > 0)
                {
                    keyStr = GetColumnKey(col.KeyOrder ?? 0);
                }

                column = string.Format(ModelFormat.Column_Format, col.ColumnName, TypeMap[col.TypeName], nullStr, keyStr);
                columnsStr += Environment.NewLine + column;
            }

            columnsStr = columnsStr.TrimStr();
            result = string.Format(ModelFormat.Class_Format, namespaceStr, tableName, columnsStr);

            return result;
        }

        private static string GetColumnModel(string columnName, bool isNull, string typeName)
        {
            string type = TypeMap[typeName];
            string nullStr = (isNull && type != "string" ? "?" : string.Empty);
            return $@"
        /// <summary>
        /// {columnName}
        /// </summary>
        public {type}{nullStr} {columnName} {{ get; set; }} ";
        }

        private static string GetColumnKey(int keyOrder)
        {
            return $@"
        [Key]
        [Column(Order = {keyOrder})]";
        }

        public static string AddStr(this string str, string content)
        {
            if (string.IsNullOrEmpty(content)) return str;

            str = str.AddExpression(content, ",");

            return str;
        }

        public static string AddExpression(this string str, string content, string expression)
        {
            if (string.IsNullOrEmpty(content)) return str;
            if (string.IsNullOrEmpty(str))
            {
                str = content;
            }
            else
            {
                str += "\n" + $@"{expression}{content}";
            }

            return str;
        }

        public static string AddAndOparator(this string str, string content)
        {
            return str.AddExpression(content, "AND ");
        }

        public static string AddOrOparator(this string str, string content)
        {
            return str.AddExpression(content, "OR ");
        }

        public static string TrimStr(this string str)
        {
            return str.Trim('\r', '\n', ','); ;
        }

        private static string GetSQLParam(string column, string type, int? size)
        {
            string typeStr = GetSQLType(type, size);

            return string.Format(SPFormat.ParamFormat, column, typeStr);
        }

        private static string GetSQLType(string type, int? size)
        {
            string sizeStr;
            if (size == null)
            {
                sizeStr = string.Empty;
            }
            else if (size == -1)
            {
                sizeStr = @"(MAX)";
            }
            else
            {
                sizeStr = $@"({size})";
            }

            return $"{type}{sizeStr}";
        }
    }
}

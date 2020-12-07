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
        private static readonly HashSet<string> IgnoreColumn = new HashSet<string>
        {
            "CreateDate",
            "UpdateDate",
            "CreateUser",
            "UpdateUser",
            "IsDelete"
        };

        private static readonly HashSet<string> IgnoreModelColumn = new HashSet<string>
        {
            "CreateDate",
            "UpdateDate",
            "CreateUser",
            "UpdateUser"
        };

        private static readonly Dictionary<string, string> TypeMapping = new Dictionary<string, string>()
        {
            { "text", "string" },
            { "date", "DateTime" },
            { "time", "DateTime" },
            { "datetime2", "DateTime" },
            { "tinyint", "byte" },
            { "smallint", "short" },
            { "int", "int" },
            { "smalldatetime", "DateTime" },
            { "real", "decimal" },
            { "money", "decimal" },
            { "datetime", "DateTime" },
            { "float", "decimal" },
            { "ntext", "string" },
            { "bit", "bool" },
            { "decimal", "decimal" },
            { "numeric", "decimal" },
            { "smallmoney", "decimal" },
            { "bigint", "long" },
            { "varchar", "string" },
            { "char", "string" },
            { "nvarchar", "string" },
            { "nchar", "string" }
        };

        public static string GeneralInsertSP(string tableName, List<ColumnInfo> columnInfos)
        {
            string result;
            string format = SPFormat.INSERT;

            string parramStr = "";
            string columnsStr = "";
            string valuesStr = "";
            string parram;

            foreach (var col in columnInfos)
            {
                if (IgnoreColumn.Contains(col.ColumnName))
                {
                    continue;
                }

                parram = GetSQLParam(col.ColumnName, col.TypeName, col.TypeSize);
                parramStr = parramStr.AddStr(parram, "\t");
                columnsStr = columnsStr.AddStr(col.ColumnName, "\t\t");
                valuesStr = valuesStr.AddStr($"@{col.ColumnName}", "\t\t");
            }

            result = string.Format(format, tableName, parramStr, columnsStr, valuesStr);

            return result;
        }

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

                parramStr = parramStr.AddStr(GetSQLParam(col.ColumnName, col.TypeName, col.TypeSize), "\t");

                if (col.IsKey == true)
                {
                    whereStr = whereStr.AddAndOparator($"{col.ColumnName} = @{col.ColumnName}", "\t\t");
                }
                else
                {
                    columnsStr = columnsStr.AddStr($"{col.ColumnName} = @{col.ColumnName}", "\t\t");
                }
            }

            result = string.Format(format, tableName, parramStr, columnsStr, whereStr);

            return result;
        }

        public static string GeneralDeleteSP(string tableName, List<ColumnInfo> columnInfos)
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
                    parramStr = parramStr.AddStr(GetSQLParam(col.ColumnName, col.TypeName, col.TypeSize), "\t");
                    whereStr = whereStr.AddAndOparator($"{col.ColumnName} = @{col.ColumnName}", "\t\t");
                }
            }

            parramStr = parramStr.TrimStr();
            whereStr = whereStr.TrimStr();
            result = string.Format(SPFormat.DELETE, tableName, parramStr, whereStr);

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
                    parramStr = parramStr.AddStr(GetSQLParam(col.ColumnName, col.TypeName, col.TypeSize), "\t");
                    whereStr = whereStr.AddAndOparator($"{col.ColumnName} = @{col.ColumnName}", "\t\t");
                }
            }

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

                if (IgnoreModelColumn.Contains(col.ColumnName))
                {
                    continue;
                }

                if (!TypeMapping.ContainsKey(col.TypeName))
                {
                    typeName = col.TypeName;
                }
                else
                {
                    typeName = TypeMapping[col.TypeName];
                }

                nullStr = col.IsNullable && typeName != "string" ? "?" : string.Empty;

                if (col.IsKey == true && col.KeyOrder > 0)
                {
                    column = string.Format(ModelFormat.ColumnKey_Format, col.ColumnName, typeName, nullStr, col.KeyOrder);
                }
                else
                {
                    column = string.Format(ModelFormat.Column_Format, col.ColumnName, typeName, nullStr);
                }

                columnsStr += Environment.NewLine + column;
            }

            columnsStr = columnsStr.TrimStr();
            result = string.Format(ModelFormat.Class_Format, namespaceStr, tableName, columnsStr);

            return result;
        }

        public static string GeneralDAO(string tableName, List<ColumnInfo> columnInfos)
        {
            string result;
            string namespaceStr = "BSServer.DAOs";
            string insertStr;
            string updateStr;
            string deleteStr;

            insertStr = string.Format(DAOFormat.Class_Format, tableName, GetDAOParam(columnInfos), "Insert");
            updateStr = string.Format(DAOFormat.Class_Format, tableName, GetDAOParam(columnInfos), "Update");

            if (columnInfos.Find(o => o.ColumnName == "IsDelete") != null)
            {
                deleteStr = string.Format(DAOFormat.Class_Format, tableName, GetDAOParam(columnInfos, true, true), "Delete");
            }
            else
            {
                deleteStr = string.Format(DAOFormat.Class_Format, tableName, GetDAOParam(columnInfos, true, false), "Delete");
            }

            result = string.Format(DAOFormat.File_Format, namespaceStr, tableName, insertStr, updateStr, deleteStr);

            return result;
        }

        private static string GetDAOParam(List<ColumnInfo> columnInfos, bool isOnlyKey = false, bool addUser = true)
        {
            string param;
            string paramStr = "";
            foreach (var col in columnInfos)
            {
                param = string.Empty;

                if (IgnoreColumn.Contains(col.ColumnName))
                {
                    continue;
                }

                param = string.Format(DAOFormat.Param_Format, col.ColumnName);

                if (isOnlyKey)
                {
                    if (col.IsKey == true && col.KeyOrder > 0)
                    {
                        paramStr = paramStr.AddExpression(param, "", "\t\t\t\t");
                    }
                }
                else
                {
                    paramStr = paramStr.AddExpression(param, "", "\t\t\t\t");
                }
            }

            if (addUser)
            {
                paramStr = paramStr.AddExpression(DAOFormat.User_Format, string.Empty, "\t\t\t\t");
            }

            return paramStr.TrimStr();
        }

        private static string GetColumnModel(string columnName, bool isNull, string typeName)
        {
            string type = TypeMapping[typeName];
            string nullStr = (isNull && type != "string" ? "?" : string.Empty);
            return $@"
        /// <summary>
        /// {columnName}
        /// </summary>
        public {type}{nullStr} {columnName} {{ get; set; }} ";
        }

        public static string AddStr(this string str, string content, string tabStr = "")
        {
            if (string.IsNullOrEmpty(content)) return str;

            str = str.AddExpression(content, ",", tabStr);

            return str;
        }

        public static string AddAndOparator(this string str, string content, string tabStr = "")
        {
            return str.AddExpression(content, "AND ", tabStr);
        }

        public static string AddOrOparator(this string str, string content, string tabStr = "")
        {
            return str.AddExpression(content, " OR ", tabStr);
        }

        public static string AddExpression(this string str, string content, string expression, string tabStr = "")
        {
            if (string.IsNullOrEmpty(content)) return str;

            if (string.IsNullOrEmpty(str))
            {
                str = tabStr + content;
            }
            else
            {
                str += "\r\n" + $@"{tabStr}{expression}{content}";
            }

            return str;
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

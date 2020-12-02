using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLAuto.Models
{
    public class ColumnInfo
    {
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string TypeName { get; set; }
        public bool IsNullable { get; set; }
        public int? TypeSize { get; set; }
        public bool IsKey { get; set; }
        public int? KeyOrder { get; set; }
        public string DefaultValue { get; set; }
    }
}

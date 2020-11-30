using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSCommon.Models
{
    /// <summary>
    /// Column infomation
    /// </summary>
    public class ColumnInfo 
    {
        public string FieldName { get; set; }
        public string Caption { get; set; }
        public int Width { get; set; }

        public ColumnInfo(string fieldName, string caption, int width)
        {
            this.FieldName = fieldName;
            this.Caption = caption;
            this.Width = width;
        }
    }
}

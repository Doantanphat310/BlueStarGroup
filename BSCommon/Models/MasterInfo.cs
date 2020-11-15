using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSCommon.Models
{
    /// <summary>
    /// User role infomation
    /// </summary>
    public class MasterInfo
    {
        public string MasterCd { get; set; }

        public string DetailCd { get; set; }

        public string Value { get; set; }

        public string Value2 { get; set; }

        public string Value3 { get; set; }

        public string Value4 { get; set; }

        public string Value5 { get; set; }
    }
}

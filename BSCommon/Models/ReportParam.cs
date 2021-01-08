namespace BSCommon.Models
{
    public class ReportParam
    {
        public string ParamID { get; set; }

        public object ParamValue { get; set; }

        public ReportParam(string paramID, object paramValue)
        {
            ParamID = paramID;
            ParamValue = paramValue;
        }
    }
}

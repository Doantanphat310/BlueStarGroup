namespace BSClient.Constants
{
    public class ExcelOperator
    {
        public const string ImportSymbol = "Import";
        public const string ExportSymbol = "Export";
    }

    public enum BSRole
    {
        /// <summary>
        /// Read only
        /// </summary>
        Read = 1 << 0,

        /// <summary>
        /// Full
        /// </summary>
        Full = 1 << 1,

        ///// <summary>
        ///// Full
        ///// </summary>
        //Full = 1 << 1
    }
}

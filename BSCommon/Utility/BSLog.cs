using NLog;
using System.Net;

namespace BSCommon.Utility
{
    public static class BSLog
    {
        public static ILogger Logger
        {
            get
            {
                // ログ出力用_IPアドレス＆ユーザーID設定
                NLog.GlobalDiagnosticsContext.Set("clientIP", GetIPAddress());
                NLog.GlobalDiagnosticsContext.Set("userID", UserInfo.UserID);
                return NLog.LogManager.GetCurrentClassLogger();
            }
        }

        public static string GetIPAddress()
        {
            string ipaddress = string.Empty;
            IPHostEntry ipentry = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in ipentry.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ipaddress = ip.ToString();
                    break;
                }
            }

            return ipaddress;
        }
    }
}

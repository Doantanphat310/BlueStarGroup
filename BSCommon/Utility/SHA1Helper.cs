using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BSCommon.Utility
{
    public static class SHA1Helper
    {
        private static string Hash(string input)
        {
            using (var sha1 = new SHA1Managed())
            {
                input += CommonInfo.AppKey;
                var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(input));
                return Convert.ToBase64String(hash);
            }
        }

        public static bool IsCheck(string value, string hashCompare)
        {
            var hash = Hash(value);

            return hash == hashCompare;
        }

        public static string GetHash(string input)
        {
            return Hash(input);
        }
    }
}

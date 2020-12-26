using System;
using System.Drawing;
using System.IO;

namespace BSCommon.Utility
{
    public class CommonUtility
    {
        public static Image Base64ToImage(string base64String)
        {
            try
            {
                if (string.IsNullOrEmpty(base64String)) return null;

                byte[] imageBytes = Convert.FromBase64String(base64String);
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                ms.Write(imageBytes, 0, imageBytes.Length);
                System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);

                return image;
            }
            catch (Exception ex)
            {
                BSLog.Logger.Debug("Base64ToImage: " + ex.Message);
                return null;
            }
        }
    }
}

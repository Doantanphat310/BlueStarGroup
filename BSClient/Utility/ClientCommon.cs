using BSCommon.Utility;
using System;
using System.Drawing;
using System.IO;

namespace BSClient.Utility
{
    public static class ClientCommon
    {
        public static bool IsCheckPass(string password, string hashPassword)
        {
            return SHA1Helper.IsCheck(password, hashPassword);
        }

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
            catch(Exception ex)
            {
                BSLog.Logger.Debug("Base64ToImage: " + ex.Message);
                return null;
            }
        }

        public static string GetBase64StringFormImage(string imgPath)
        {
            try
            {
                if (string.IsNullOrEmpty(imgPath)) return string.Empty;

                byte[] imageBytes = System.IO.File.ReadAllBytes(imgPath);
                string base64String = Convert.ToBase64String(imageBytes);

                return base64String;
            }
            catch (Exception ex)
            {
                BSLog.Logger.Debug("GetBase64StringFormImage: " + ex.Message);
                return null;
            }
        }

        public static string ImageToBase64(Image image)
        {
            try
            {
                var imageStream = new MemoryStream();
                image.Save(imageStream, System.Drawing.Imaging.ImageFormat.Bmp);
                imageStream.Position = 0;
                var imageBytes = imageStream.ToArray();
                var ImageBase64 = Convert.ToBase64String(imageBytes);

                return ImageBase64;
            }
            catch (Exception ex)
            {
                BSLog.Logger.Debug("ImageToBase64: " + ex.Message);
                return null;
            }
        }
    }
}

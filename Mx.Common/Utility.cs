using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Utility
{
    public static class Hash
    {
        public static string md5(string s)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(s, "MD5").ToLower();
        }
        public static string sha1(string s)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(s, "SHA1").ToLower();
        }
    }

    public static class HTTP
    {
        public static HttpWorkerRequest GetWokerRequest()
        {
            return (HttpContext.Current as IServiceProvider).GetService(typeof(HttpWorkerRequest)) as HttpWorkerRequest;
        }

        public static bool IsUploadRequest(HttpRequest r)
        {
            return r.ContentType.ToLower().StartsWith("multipart/form-data");
        }
    }

    public static class RandCodeBuilder
    {
        public static byte[] BuildImage(string s)
        {
            Bitmap bm = new Bitmap(76, 24, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bm);
            Random r = new Random();

            g.Clear(Color.White);
            /*
            for (int i = 0; i < 50; i++) 
            { 
                int x1 = r.Next(bm.Width); 
                int x2 = r.Next(bm.Width); 
                int y1 = r.Next(bm.Height); 
                int y2 = r.Next(bm.Height); 
                g.DrawLine(new Pen(Color.FromArgb(r.Next())), x1, y1, x2, y2);
            } 
            */
            for (int i = 0; i < 200; i++)
            {
                int x = r.Next(bm.Width);
                int y = r.Next(bm.Height);
                bm.SetPixel(x, y, Color.Silver);
            }

            int j = r.Next(1, 4);
            Font f = new Font("Courier New", 14, FontStyle.Bold);
            LinearGradientBrush lgb = new LinearGradientBrush(new Rectangle(0, 0, 76, 24), Color.DarkGreen, Color.DarkSeaGreen, 1.2f, true);
            g.DrawString(s, f, lgb, 0, 0);
            //g.DrawRectangle(new Pen(Color.Silver), 0, 0, 70, 22); 

            MemoryStream ms = new MemoryStream();
            bm.Save(ms, ImageFormat.Gif);
            return ms.ToArray();
        }
    }

    public static class Text
    {
        private static char[] seeds = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        public static string RandString(int len)
        {
            StringBuilder sb = new StringBuilder(36);
            Random r = new Random();
            for (int i = 0; i < len; i++)
            {
                sb.Append(seeds[r.Next(36)]);
            }
            return sb.ToString();
        }
    }

}

using System;
using System.Collections.Generic;
using System.Text;

namespace Mx.Common
{

    /// <summary> 
    /// 随机函数 
    /// </summary> 
    public class RandomObject
    {
        private static long tick = DateTime.Now.Ticks;
        static Random g_rnd = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32)); 


        #region 数字随机数
        /// <summary> 
        /// 数字随机数 
        /// </summary> 
        /// <param name="n">生成长度</param> 
        /// <returns></returns> 
        public static string RandNum(int n)
        {
            char[] arrChar = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            StringBuilder num = new StringBuilder();
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < n; i++)
            {
                num.Append(arrChar[rnd.Next(0, 9)].ToString());
            }
            return num.ToString();
        }
        #endregion
        #region 数字和字母随机数
        /// <summary> 
        /// 数字和字母随机数 
        /// </summary> 
        /// <param name="n">生成长度</param> 
        /// <returns></returns> 
        public static string RandCode(int n)
        {
            char[] arrChar = new char[]{ 
            'a','b','d','c','e','f','g','h','i','j','k','l','m','n','p','r','q','s','t','u','v','w','z','y','x', 
            '0','1','2','3','4','5','6','7','8','9', 
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','Q','P','R','T','S','V','U','W','X','Y','Z' 
            };
            StringBuilder num = new StringBuilder();
            //Random rnd = new Random(DateTime.Now.Millisecond);
            long tick = DateTime.Now.Ticks;
            //Random g_rnd = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));            
            for (int i = 0; i < n; i++)
            {
                num.Append(arrChar[g_rnd.Next(0, arrChar.Length)].ToString());
            }
            return num.ToString();
        }
        #endregion
        #region 字母随机数
        /// <summary> 
        /// 字母随机数 
        /// </summary> 
        /// <param name="n">生成长度</param> 
        /// <returns></returns> 
        public static string RandLetter(int n)
        {
            char[] arrChar = new char[]{ 
            'a','b','d','c','e','f','g','h','i','j','k','l','m','n','p','r','q','s','t','u','v','w','z','y','x', 
            '_', 
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','Q','P','R','T','S','V','U','W','X','Y','Z' 
            };
            StringBuilder num = new StringBuilder();
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < n; i++)
            {
                num.Append(arrChar[rnd.Next(0, arrChar.Length)].ToString());
            }
            return num.ToString();
        }
        #endregion
        #region 日期随机函数
        /// <summary> 
        /// 日期随机函数 
        /// </summary> 
        /// <param name="ra">长度</param> 
        /// <returns></returns> 
        public static string DateRndName(Random ra)
        {
            DateTime d = DateTime.Now;
            string s = null, y, m, dd, h, mm, ss;
            y = d.Year.ToString();
            m = d.Month.ToString();
            if (m.Length < 2) m = "0" + m;
            dd = d.Day.ToString();
            if (dd.Length < 2) dd = "0" + dd;
            h = d.Hour.ToString();
            if (h.Length < 2) h = "0" + h;
            mm = d.Minute.ToString();
            if (mm.Length < 2) mm = "0" + mm;
            ss = d.Second.ToString();
            if (ss.Length < 2) ss = "0" + ss;
            s += y + m + dd + h + mm + ss;
            s += ra.Next(100, 999).ToString();
            return s;
        }
        #endregion
        #region 生成GUID
        /// <summary> 
        /// 生成GUID 
        /// </summary> 
        /// <returns></returns> 
        public static string GetGuid()
        {
            System.Guid g = System.Guid.NewGuid();
            return g.ToString();
        }
        #endregion




        //生成唯一值 8位
        public static string GenUniqueString()
        {
            string KeleyiStr = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] rtn = new char[8];
            Guid gid = Guid.NewGuid();
            var ba = gid.ToByteArray();
            for (var i = 0; i < 8; i++)
            {
                rtn[i] = KeleyiStr[((ba[i] + ba[8 + i]) % 35)];
            }
            return "" + rtn[0] + rtn[1] + rtn[2] + rtn[3] + rtn[4] + rtn[5] + rtn[6] + rtn[7];
        }
    }

}

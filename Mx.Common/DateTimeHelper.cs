using System;
using System.Collections.Generic;
using System.Text;

namespace Mx.Common
{
    public class DateTimeHelper
    {
        /// <summary>
        /// ��ȡ���ʱ��
        /// <remarks>
        /// ����Random �Ե�ǰϵͳʱ����Ϊ��ֵ,���Ե��������ж�θ÷������õ��Ľ��������ͬ,
        /// ��ʱ,��Ӧ�����ⲿ��ʼ�� Random ʵ�������� GetRandomTime(DateTime time1, DateTime time2, Random random)
        /// </remarks>
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public static DateTime GetRandomTime(DateTime time1, DateTime time2)
        {
            Random random = new Random();
            return GetRandomTime(time1, time2, random);
        }

        /// <summary>
        /// ��ȡ���ʱ��
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <param name="random"></param>
        /// <returns></returns>
        public static DateTime GetRandomTime(DateTime time1, DateTime time2, Random random)
        {
            DateTime minTime = new DateTime();
            DateTime maxTime = new DateTime();

            System.TimeSpan ts = new System.TimeSpan(time1.Ticks - time2.Ticks);

            // ��ȡ����ʱ�����������
            double dTotalSecontds = ts.TotalSeconds;
            int iTotalSecontds = 0;

            if (dTotalSecontds > System.Int32.MaxValue)
            {
                iTotalSecontds = System.Int32.MaxValue;
            }
            else if (dTotalSecontds < System.Int32.MinValue)
            {
                iTotalSecontds = System.Int32.MinValue;
            }
            else
            {
                iTotalSecontds = (int)dTotalSecontds;
            }


            if (iTotalSecontds > 0)
            {
                minTime = time2;
                maxTime = time1;
            }
            else if (iTotalSecontds < 0)
            {
                minTime = time1;
                maxTime = time2;
            }
            else
            {
                return time1;
            }

            int maxValue = iTotalSecontds;

            if (iTotalSecontds <= System.Int32.MinValue)
                maxValue = System.Int32.MinValue + 1;

            int i = random.Next(System.Math.Abs(maxValue));

            return minTime.AddSeconds(i);
        }






        /// <summary>
        /// DateTimeʱ���ʽת��Ϊ13λ�������Unixʱ���
        /// </summary>
        /// <param name="time"> DateTimeʱ���ʽ</param>
        /// <returns>Unixʱ�����ʽ</returns>
        public static long ConvertDateTimeLong(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (long)(time - startTime).TotalMilliseconds;
        }

        //=========================================
        /// <summary>
        /// DateTimeʱ���ʽת��Ϊ10λ���������Unixʱ���
        /// </summary>
        /// <param name="time"> DateTimeʱ���ʽ</param>
        /// <returns>Unixʱ�����ʽ</returns>
        public static int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }
        //========================================
        /// <summary>
        /// ʱ���תΪC#��ʽʱ��
        /// </summary>
        /// <param name="timeStamp">Unixʱ�����ʽ</param>
        /// <returns>C#��ʽʱ��</returns>
        public static DateTime GetTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }




    }
}

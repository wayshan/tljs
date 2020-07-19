using System;

namespace Mx.Common
{
	/// <summary>
	/// HtmlFilter 的摘要说明。
	/// </summary>
	public class HtmlFilter
	{
		public HtmlFilter()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 将特殊字符格式化为Html代码
		/// </summary>
		/// <param name="sHtml">要转换的字符串</param>
		/// <returns>string</returns>
		/// <date>2006-08-01</date>
		public static string InputFilter(string sHtml)
		{
			string returnHtml = string.Empty;
			returnHtml = sHtml;
			returnHtml = returnHtml.Replace("<","&lt;");
			returnHtml = returnHtml.Replace(">","&gt;");
			returnHtml = returnHtml.Replace("$","");
			returnHtml = returnHtml.Replace("\r\n","<br>");
            returnHtml = returnHtml.Replace(" ","&nbsp;");
			//returnHtml = returnHtml.Replace('{','｛');
			//returnHtml = returnHtml.Replace('}','｝');           
            returnHtml = returnHtml.Replace("'", "’");
            returnHtml = returnHtml.Replace("[", "［");
            returnHtml = returnHtml.Replace("]", "］");
//			returnHtml = returnHtml.Replace('!','！');
//			returnHtml = returnHtml.Replace('@','＠');
//			returnHtml = returnHtml.Replace('%','％');
//			returnHtml = returnHtml.Replace('^','＾');
//			returnHtml = returnHtml.Replace('&','＆');
//			returnHtml = returnHtml.Replace('*','×');
//			returnHtml = returnHtml.Replace('(','（');
//			returnHtml = returnHtml.Replace(')','）');
//			returnHtml = returnHtml.Replace(')','）');
//			returnHtml = returnHtml.Replace('_','＿');
//			returnHtml = returnHtml.Replace('+','＋');
//			returnHtml = returnHtml.Replace('|','‖');
			//returnHtml = returnHtml.Trim();
			return returnHtml;
		}

        /// <summary>
        /// 将特殊字符格式化为Html代码
        /// </summary>
        /// <param name="sHtml">要转换的字符串</param>
        /// <returns>string</returns>
        /// <date>2006-08-01</date>
        public static string InputFilterKeyWord(string sHtml)
        {
            string returnHtml = string.Empty;
            returnHtml = sHtml;
            returnHtml = returnHtml.Replace("<", "&lt;");
            returnHtml = returnHtml.Replace(">", "&gt;");
            returnHtml = returnHtml.Replace("$", "");
            returnHtml = returnHtml.Replace("\r\n", "<br>");
            returnHtml = returnHtml.Replace(" ", "&nbsp;");
            returnHtml = returnHtml.Replace("\"", "&quot;");
            //returnHtml = returnHtml.Replace('{','｛');
            //returnHtml = returnHtml.Replace('}','｝');           
            //			returnHtml = returnHtml.Replace('!','！');
            //			returnHtml = returnHtml.Replace('@','＠');
            //			returnHtml = returnHtml.Replace('%','％');
            //			returnHtml = returnHtml.Replace('^','＾');
            //			returnHtml = returnHtml.Replace('&','＆');
            //			returnHtml = returnHtml.Replace('*','×');
            //			returnHtml = returnHtml.Replace('(','（');
            //			returnHtml = returnHtml.Replace(')','）');
            //			returnHtml = returnHtml.Replace(')','）');
            //			returnHtml = returnHtml.Replace('_','＿');
            //			returnHtml = returnHtml.Replace('+','＋');
            //			returnHtml = returnHtml.Replace('|','‖');
            //returnHtml = returnHtml.Trim();
            return returnHtml;
        }

		/// <summary>
		/// 将Html代码格式化为特殊字符
		/// </summary>
		/// <param name="sHtml">要转换的字符串</param>
		/// <returns>string</returns>
		/// <date>2006-08-01</date>
		public static string OutputFilter(string sHtml)
		{
			string returnHtml = string.Empty;
			returnHtml = sHtml;
			returnHtml = returnHtml.Replace("&lt;","<");
			returnHtml = returnHtml.Replace("&gt;",">");
			returnHtml = returnHtml.Replace("<br>","\r\n");
			returnHtml = returnHtml.Replace("&nbsp;"," ");
			returnHtml = returnHtml.Replace('｛','{');
			returnHtml = returnHtml.Replace('｝','}');
            returnHtml = returnHtml.Replace("’", "'");
            returnHtml = returnHtml.Replace("［", "[");
            returnHtml = returnHtml.Replace("］", "]");
			//returnHtml = returnHtml.Trim();
			return returnHtml;
		}
	}
}

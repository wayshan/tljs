using System;

namespace Mx.Common
{
	/// <summary>
	/// HtmlFilter ��ժҪ˵����
	/// </summary>
	public class HtmlFilter
	{
		public HtmlFilter()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		/// <summary>
		/// �������ַ���ʽ��ΪHtml����
		/// </summary>
		/// <param name="sHtml">Ҫת�����ַ���</param>
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
			//returnHtml = returnHtml.Replace('{','��');
			//returnHtml = returnHtml.Replace('}','��');           
            returnHtml = returnHtml.Replace("'", "��");
            returnHtml = returnHtml.Replace("[", "��");
            returnHtml = returnHtml.Replace("]", "��");
//			returnHtml = returnHtml.Replace('!','��');
//			returnHtml = returnHtml.Replace('@','��');
//			returnHtml = returnHtml.Replace('%','��');
//			returnHtml = returnHtml.Replace('^','��');
//			returnHtml = returnHtml.Replace('&','��');
//			returnHtml = returnHtml.Replace('*','��');
//			returnHtml = returnHtml.Replace('(','��');
//			returnHtml = returnHtml.Replace(')','��');
//			returnHtml = returnHtml.Replace(')','��');
//			returnHtml = returnHtml.Replace('_','��');
//			returnHtml = returnHtml.Replace('+','��');
//			returnHtml = returnHtml.Replace('|','��');
			//returnHtml = returnHtml.Trim();
			return returnHtml;
		}

        /// <summary>
        /// �������ַ���ʽ��ΪHtml����
        /// </summary>
        /// <param name="sHtml">Ҫת�����ַ���</param>
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
            //returnHtml = returnHtml.Replace('{','��');
            //returnHtml = returnHtml.Replace('}','��');           
            //			returnHtml = returnHtml.Replace('!','��');
            //			returnHtml = returnHtml.Replace('@','��');
            //			returnHtml = returnHtml.Replace('%','��');
            //			returnHtml = returnHtml.Replace('^','��');
            //			returnHtml = returnHtml.Replace('&','��');
            //			returnHtml = returnHtml.Replace('*','��');
            //			returnHtml = returnHtml.Replace('(','��');
            //			returnHtml = returnHtml.Replace(')','��');
            //			returnHtml = returnHtml.Replace(')','��');
            //			returnHtml = returnHtml.Replace('_','��');
            //			returnHtml = returnHtml.Replace('+','��');
            //			returnHtml = returnHtml.Replace('|','��');
            //returnHtml = returnHtml.Trim();
            return returnHtml;
        }

		/// <summary>
		/// ��Html�����ʽ��Ϊ�����ַ�
		/// </summary>
		/// <param name="sHtml">Ҫת�����ַ���</param>
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
			returnHtml = returnHtml.Replace('��','{');
			returnHtml = returnHtml.Replace('��','}');
            returnHtml = returnHtml.Replace("��", "'");
            returnHtml = returnHtml.Replace("��", "[");
            returnHtml = returnHtml.Replace("��", "]");
			//returnHtml = returnHtml.Trim();
			return returnHtml;
		}
	}
}

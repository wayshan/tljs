using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Web.SessionState;
using System.Collections;
using System.Web.Security;
using System.Web;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Mx.Common
{
    /// <summary>
    /// PageFunc ��ժҪ˵����
    /// </summary>
    public class PageFunc : System.Web.UI.Page
    {
        public PageFunc()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }

        /// <summary>
        /// ������׼ȷ���Ի���
        /// </summary>
        /// <param name="Mypage"></param>
        /// <param name="msg"></param>
        public static void Alert(Page Mypage, string msg)
        {
            if (msg == null) return;
            string tempstr = msg.Replace("\"", "\\\"");
            tempstr = tempstr.Replace("\'", "\\\'");
            StringBuilder sb = new StringBuilder("<script Language=\"Javascript\">");
            sb.Append("alert(\"");
            sb.Append(tempstr).Append("\");");
            sb.Append("<").Append("/").Append("script>");

            if (!Mypage.IsStartupScriptRegistered("msgscript"))
                Mypage.RegisterStartupScript("msgscript", sb.ToString());
        }

        /// <summary>
        /// ������׼ȷ���Ի���
        /// </summary>
        /// <param name="Mypage"></param>
        /// <param name="msg"></param>
        public static void AjaxAlert(Page Mypage, string msg)
        {
            if (msg == null) return;
            string tempstr = msg.Replace("\"", "\\\"");
            tempstr = tempstr.Replace("\'", "\\\'");
            StringBuilder sb = new StringBuilder("<script Language=\"Javascript\">");
            sb.Append("alert(\"");
            sb.Append(tempstr).Append("\");");
            sb.Append("<").Append("/").Append("script>");

           ScriptManager.RegisterStartupScript(Mypage, typeof(string), "alertScript", sb.ToString(), false);
        }

        /// <summary>
        /// ������׼ȷ���Ի���
        /// </summary>
        /// <param name="Mypage"></param>
        /// <param name="msg"></param>
        public static void AjaxAlert(Page Mypage, string msg, string Appscript)
        {
            if (msg == null) return;
            string tempstr = msg.Replace("\"", "\\\"");
            tempstr = tempstr.Replace("\'", "\\\'");
            StringBuilder sb = new StringBuilder("<script Language=\"Javascript\">");
            sb.Append("alert(\"");
            sb.Append(tempstr).Append("\");");
            sb.AppendFormat("{0};", Appscript);
            sb.Append("<").Append("/").Append("script>");

           ScriptManager.RegisterStartupScript(Mypage, typeof(string), "alertScript", sb.ToString(), false);
        }



        /// <summary>
        /// ȷ����Ϣ������ת����������
        /// </summary>
        /// <param name="Mypage"></param>
        /// <param name="msg"></param>
        public static string ShowMsgJumpE(string msg, string jum)
        {
            string str;
            str = "<script language='Javascript'>alert('" + msg + "');window.location.href='" + jum + "';</script>";
            return str;
        }

        /// <summary>
        /// ���ڶԶ�����ʹ��FormsAuthenticationTicket������м���
        /// </summary>
        public static string Encrypt(string Password)
        {
            string str = "";
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(Password, true, 2);
            str = FormsAuthentication.Encrypt(ticket).ToString();
            return str;
        }

        /// <summary>
        /// ���������SHA1��Format��0����MD5��Format��1������
        /// </summary>
        public static string Encrypt(string Password, int Format)
        {
            string str = "";
            switch (Format)
            {
                case 0:
                    str = FormsAuthentication.HashPasswordForStoringInConfigFile(Password, "SHA1");
                    break;
                case 1:
                    str = FormsAuthentication.HashPasswordForStoringInConfigFile(Password, "MD5");
                    break;
            }
            return str;
        }

        /// <summary>
        /// ���ڽ����û�������
        /// </summary>
        public static string Decrypt(string Password)
        {
            string str = "";
            str = FormsAuthentication.Decrypt(Password).Name.ToString();
            return str;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="d">DropDownList����</param>
        /// <param name="nowlayer">��ǰ��</param>
        ///  <param name="so">��ʶ����</param>
        /// <param name="sel">ѡ������</param>
        /// <param name="ds">���ݼ�</param>
        /// <param name="valuename">ֵ�ֶ�</param>
        /// <param name="fidname">��ǰ�ڵ��ֶ���</param>
        public static void SIMPLEFillDDL(DropDownList d, string sel, DataSet ds, string valuename, string textname)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem(HtmlFilter.OutputFilter(ds.Tables[0].Rows[i][textname].ToString()), ds.Tables[0].Rows[i][valuename].ToString());
                if (ds.Tables[0].Rows[i][valuename].ToString() == sel)
                    li.Selected = true;
                d.Items.Add(li);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="d">DropDownList����</param>
        /// <param name="nowlayer">��ǰ��</param>
        ///  <param name="so">��ʶ����</param>
        /// <param name="sel">ѡ������</param>
        /// <param name="ds">���ݼ�</param>
        /// <param name="fup">�ϼ��ڵ�</param>
        /// <param name="valuename">ֵ�ֶ�</param>
        /// <param name="textname">��ʶ��Ϣ�ֶ���</param>
        /// <param name="fupname">�ϼ��ڵ��ֶ���</param>
        /// <param name="fidname">��ǰ�ڵ��ֶ���</param>
        public static void FillDDL(DropDownList d, int nowlayer, string sel, string so, DataSet ds, string fup, string valuename, string textname, string fupname, string fidname)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i][fupname].ToString() == fup)
                {
                    ListItem li;
                    //����ǰ��ı�ʶ
                    string so_layer = "";
                    for (int j = 0; j < nowlayer; j++) { so_layer = so_layer + so; }
                    li = new ListItem(so_layer + HtmlFilter.OutputFilter(ds.Tables[0].Rows[i][textname].ToString()), ds.Tables[0].Rows[i][valuename].ToString());
                    if (ds.Tables[0].Rows[i][valuename].ToString() == sel)
                        li.Selected = true;
                    d.Items.Add(li);
                    FillDDL(d, (nowlayer + 1), sel, so, ds, ds.Tables[0].Rows[i][fidname].ToString(), valuename, textname, fupname, fidname);
                }
            }
        }


        /// <summary>
        /// ��Ʒ���
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="nowlayer"></param>
        /// <param name="sel"></param>
        /// <param name="so"></param>
        /// <param name="ds"></param>
        /// <param name="fup"></param>
        /// <param name="valuename"></param>
        /// <param name="textname"></param>
        /// <param name="fupname"></param>
        /// <param name="fidname"></param>
        public static void FillProductsSortdt(DataTable dt, int nowlayer, string sel, string so, DataSet ds, string fup, string valuename, string textname, string fupname, string fidname)
        {
            DataRow dr;

            // DataTable dt = dschange.Tables[0];
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i][fupname].ToString() == fup)
                {
                    dr = dt.NewRow();
                    //����ǰ��ı�ʶ
                    string so_layer = "";
                    for (int j = 0; j < nowlayer; j++) { so_layer = so_layer + so; }
                    dr["id"] = ds.Tables[0].Rows[i]["id"].ToString();
                    dr["Fid"] = ds.Tables[0].Rows[i]["Fid"].ToString();
                    dr["OrderID"] = ds.Tables[0].Rows[i]["OrderID"].ToString();
                    dr["SortName"] = so_layer + ds.Tables[0].Rows[i]["SortName"].ToString();
                    dr["IsEnabled"] = ds.Tables[0].Rows[i]["IsEnabled"].ToString();
                    dr["Deeps"] = string.Format("{0}", nowlayer + 1);

                    dt.Rows.Add(dr);
                    FillProductsSortdt(dt, (nowlayer + 1), sel, so, ds, ds.Tables[0].Rows[i]["id"].ToString(), valuename, textname, fupname, fidname);
                }
            }
        }

        /// <param name="total">�ܼ�¼��</param>
        /// <param name="per">ÿҳ��¼��</param>
        /// <param name="page">��ǰҳ��</param>
        /// <param name="query_string">Url����</param>
        public  static string paginationSearch(int total, int per, int page, string query_string)
        {
            int allpage = 0;
            int next = 0;
            int pre = 0;
            int startcount = 0;
            int endcount = 0;
            string pagestr = "";

            if (page < 1) { page = 1; }
            //������ҳ��
            if (per != 0)
            {
                allpage = (total / per);
                allpage = ((total % per) != 0 ? allpage + 1 : allpage);
                allpage = (allpage == 0 ? 1 : allpage);
            }

            if (allpage == 1)
            {
                return pagestr;
            }


            next = page + 1;
            pre = page - 1;
            startcount = (page + 5) > allpage ? allpage - 9 : page - 4;//�м�ҳ��ʼ���
            //�м�ҳ��ֹ���
            endcount = page < 5 ? 10 : page + 5;
            if (startcount < 1) { startcount = 1; } //Ϊ�˱��������ʱ������������������С��1�ʹ����1��ʼ
            if (allpage < endcount) { endcount = allpage; }//ҳ��+5�Ŀ����Ծͻ�������������Ŵ�����ҳ�룬��ô��Ҫ���������ҳ����֮��
            pagestr = "";// "��" + allpage + "ҳ";

            pagestr += page > 1 ? "<span><a href=\"" + query_string + "\">��ҳ</a></span><span><a href=\"" + query_string + "&page=" + pre + "\">��һҳ</a></span>" : "";
            //�м�ҳ�����������ʱ�临�Ӷȣ���С�ռ临�Ӷ�
            for (int i = startcount; i <= endcount; i++)
            {
                pagestr += page == i ? "<strong>" + i + "</strong>" : "<span><a href=\"" + query_string +"&page="+i+ "\">" + i + "</a></span>";
            }
            pagestr += page != allpage ? "<span><a href=\"" + query_string + "&page="+ next +"\">��һҳ</a></strong><span><a href=\"" + query_string + "&page=" + allpage + "\">ĩҳ</a></strong>" : " ";

            return pagestr;
        }


        /// <param name="total">�ܼ�¼��</param>
        /// <param name="per">ÿҳ��¼��</param>
        /// <param name="page">��ǰҳ��</param>
        /// <param name="query_string">Url����</param>
        public static string pagination(int total, int per, int page, string query_string)
        {
            int allpage = 0;
            int next = 0;
            int pre = 0;
            int startcount = 0;
            int endcount = 0;
            string pagestr = "";

            if (page < 1) { page = 1; }
            //������ҳ��
            if (per != 0)
            {
                allpage = (total / per);
                allpage = ((total % per) != 0 ? allpage + 1 : allpage);
                allpage = (allpage == 0 ? 1 : allpage);
            }

            if (allpage == 1)
            {
                return pagestr;
            }


            next = page + 1;
            pre = page - 1;
            startcount = (page + 5) > allpage ? allpage - 9 : page - 4;//�м�ҳ��ʼ���
            //�м�ҳ��ֹ���
            endcount = page < 5 ? 10 : page + 5;
            if (startcount < 1) { startcount = 1; } //Ϊ�˱��������ʱ������������������С��1�ʹ����1��ʼ
            if (allpage < endcount) { endcount = allpage; }//ҳ��+5�Ŀ����Ծͻ�������������Ŵ�����ҳ�룬��ô��Ҫ���������ҳ����֮��
            pagestr = "";// "��" + allpage + "ҳ";

            pagestr += page > 1 ? "<span><a href=\"" + query_string + ".aspx\">��ҳ</a></span><span><a href=\"" + query_string + "_" + pre + ".aspx\">��һҳ</a></span>" : "";
            //�м�ҳ�����������ʱ�临�Ӷȣ���С�ռ临�Ӷ�
            for (int i = startcount; i <= endcount; i++)
            {
                pagestr += page == i ? "<strong>" + i + "</strong>" : "<span><a href=\"" + query_string + "_" + i + ".aspx\">" + i + "</a></span>";
            }
            pagestr += page != allpage ? "<span><a href=\"" + query_string + "_" + next + ".aspx\">��һҳ</a></strong><span><a href=\"" + query_string + "_" + allpage + ".aspx\">ĩҳ</a></strong>" : " ";

            return pagestr;
        }


        //��֤�Ƿ�Ϊ�������� 
        public static bool IsFloat(string str)
        {
            string regextext = @"^(-?\d+)(\.\d+)?$";
            Regex regex = new Regex(regextext, RegexOptions.None);
            return regex.IsMatch(str.Trim());
        }
        public static string getSiteDomain(Page page)
        {
            return page.Request.Url.Scheme + "://" + page.Request.Url.Authority;
        }

        /// <summary>
        /// ��ʾ������Ϣ
        /// </summary>
        public static string ShowErrMsg(string err)
        {
            string str;
            str = "<script type=\"text/javascript\">";
            str += "alert(\"" + err + "\")";
            str += "</script>";
            return str;
        }


        /// <summary>
        /// ִ��js
        /// </summary>
        /// <param name="Mypage"></param>
        /// <param name="msg"></param>
        public static void AjaxExecJs(Page Mypage, string msg)
        {
            string tempstr = msg.Replace("\"", "\\\"");
            tempstr = tempstr.Replace("\n", "").Replace("\r", "");
            StringBuilder sb = new StringBuilder("<script Language=\"Javascript\">");
            sb.Append(tempstr + "</script>");

            ScriptManager.RegisterStartupScript(Mypage, typeof(string), "Script", sb.ToString(), false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s">UploadFile����</param>
        /// <param name="oldname">ԭ�ļ���</param>
        /// <param name="UpFileDIR">UpFileDIR: Զ�̱���ĵ�ַ��Ĭ��Ϊ"./"</param>
        /// <returns></returns>
        public string UploadFile(System.Web.HttpPostedFile s, string oldname, string UpFileDIR, string canextension, int length, int sm, int sm_Width, int sm_hight)
        {
            if (s.FileName.Trim() != "")
            {
                string res = "";
                try
                {
                    //���ļ���С�����ж�
                    if (length != 0)
                    {
                        if (s.ContentLength > length)
                        {
                            HttpContext.Current.Response.Write(PageFunc.ShowErrMsg("�ϴ�ʧ�ܣ��ļ���С����" + length + "B"));
                            HttpContext.Current.Response.Write("<script language=javascript>history.go(-1);</script>");
                            HttpContext.Current.Response.End();
                        }
                    }


                    if (UpFileDIR.Trim() == "")
                    {
                        UpFileDIR = "/";		//��֤���Ϊ"/UploadFile/"
                    }
                    else
                    {
                        //�ϴ�Ŀ¼�����ڣ��򴴽�
                        if (!Directory.Exists(Server.MapPath(UpFileDIR)))
                        {
                            Directory.CreateDirectory(Server.MapPath(UpFileDIR));
                        }
                    }


                    //�ϴ��ļ�
                    string extension = Path.GetExtension(s.FileName).ToUpper();

                    //���ļ��������������ж�
                    if (canextension.IndexOf(extension.Substring(1, extension.Length - 1)) == -1)
                    {
                        HttpContext.Current.Response.Write(PageFunc.ShowErrMsg("�ϴ����ļ����Ͳ�����ϵͳҪ��,���ϴ�" + canextension + "���͵��ļ�") + "<script language=javascript>history.go(-1);</script>");
                        HttpContext.Current.Response.Write("<script language=javascript>history.go(-1);</script>");
                        HttpContext.Current.Response.End();
                    }

                    GC.Collect();
                    Random r = new Random();
                    string fileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + r.Next(1000).ToString();
                    //return fileName;
                    string path = Server.MapPath(UpFileDIR + fileName + extension);
                    string newSmPath = path.Replace(extension, "_sm" + extension);
                    s.SaveAs(path);
                    GC.Collect();
                    res = UpFileDIR + fileName + extension;
                    //ɾ��ԭ���ļ�
                    string oldFilePath = Server.MapPath(UpFileDIR + oldname);
                    if (oldname != "" && File.Exists(oldFilePath))
                    {
                        File.Delete(oldFilePath);
                    }
                    res = res.Substring(res.LastIndexOf("/") + 1, res.Length - res.LastIndexOf("/") - 1);

                    //��smΪ1��ʱ�򣬱���Ҫ��������ͼ
                    if (sm == 1)
                    {
                        ////////��������ͼ
                        //����СͼƬ
                        System.Drawing.Image image = new Bitmap(path);//�õ�ԭͼ


                        //����ָ����С��ͼ
                        //System.Drawing.Image newImage = image.GetThumbnailImage(sm_Width, sm_hight, null, new IntPtr());


                        System.Drawing.Bitmap newImage = new Bitmap(sm_Width, sm_hight);
                        Graphics g = Graphics.FromImage(newImage);
                        //��ԭͼ����ָ����ͼ��
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//�������
                        g.DrawImage(image,
                            new System.Drawing.Rectangle(0, 0, sm_Width, sm_hight), //����´�С
                            new System.Drawing.Rectangle(0, 0, image.Width, image.Height),//���ԭͼ��С
                            System.Drawing.GraphicsUnit.Pixel);

                        g.Dispose();
                        newImage.Save(newSmPath);
                    }


                    /////////


                    return res;

                }
                catch (Exception e)
                {
                    //Response.Write(Functions.ShowErrMsg("ͼƬ�ϴ�ʧ��"));
                    //HttpContext.Current.Response.Write(Functions.ShowErrMsg(e.ToString()));
                    HttpContext.Current.Response.Write(PageFunc.ShowErrMsg("�ϴ�ʱ���ִ���,����ʧ�ܡ�" + e.ToString()));
                    HttpContext.Current.Response.Write("<script language=javascript>history.go(-1);</script>");
                    HttpContext.Current.Response.End();
                    // res = oldname;
                    // return res;
                }

                return res;
            }
            return oldname;
        }


        /// <summary>
        /// �ϴ�����
        /// </summary>
        /// <param name="s">UploadFile����</param>
        /// <param name="oldname">ԭ�ļ���</param>
        /// <param name="UpFileDIR">UpFileDIR: Զ�̱���ĵ�ַ��Ĭ��Ϊ"./"</param>
        /// <returns></returns>
        public string UploadAttFile(System.Web.HttpPostedFile s, string UpFileDIR, string oldname, string canextension, int length)
        {
            if (s.FileName.Trim() != "")
            {
                string res = "";
                try
                {
                    //���ļ���С�����ж�
                    if (length != 0)
                    {
                        if (s.ContentLength > length)
                        {
                            HttpContext.Current.Response.Write(PageFunc.ShowErrMsg("�ϴ�ʧ�ܣ��ļ���С����" + length + "B"));
                            HttpContext.Current.Response.Write("<script language=javascript>history.go(-1);</script>");
                            HttpContext.Current.Response.End();
                        }
                    }


                    if (UpFileDIR.Trim() == "")
                    {
                        UpFileDIR = "/";		//��֤���Ϊ"/UploadFile/"
                    }

                    //�ϴ��ļ�
                    string extension = Path.GetExtension(s.FileName).ToUpper();

                    //���ļ��������������ж�
                    if (canextension.IndexOf(extension.Substring(1, extension.Length - 1)) == -1)
                    {
                        HttpContext.Current.Response.Write(PageFunc.ShowErrMsg("�ϴ����ļ����Ͳ�����ϵͳҪ��,���ϴ�" + canextension + "���͵��ļ�") + "<script language=javascript>history.go(-1);</script>");
                        //HttpContext.Current.Response.Write("<script language=javascript>history.go(-1);</script>");
                        HttpContext.Current.Response.End();
                        
                    }

                    GC.Collect();
                    Random r = new Random();
                    string fileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + r.Next(1000).ToString();
                    //return fileName;
                    string path = Server.MapPath(UpFileDIR + fileName + extension);
                    s.SaveAs(path);
                    GC.Collect();
                    res = UpFileDIR + fileName + extension;
                    //ɾ��ԭ���ļ�
                    string oldFilePath = Server.MapPath(UpFileDIR + oldname);
                    if (oldname != "" && File.Exists(oldFilePath))
                    {
                        File.Delete(oldFilePath);
                    }
                    res = res.Substring(res.LastIndexOf("/") + 1, res.Length - res.LastIndexOf("/") - 1);

                    /////////


                    return res;

                }
                catch (Exception e) 
                {
                    //Response.Write(Functions.ShowErrMsg("ͼƬ�ϴ�ʧ��"));
                    //HttpContext.Current.Response.Write(Functions.ShowErrMsg(e.ToString()));
                    HttpContext.Current.Response.Write(PageFunc.ShowErrMsg("�ϴ�ʱ���ִ���,����ʧ��"));
                    HttpContext.Current.Response.Write("<script language=javascript>history.go(-1);</script>");
                    HttpContext.Current.Response.End();
                    // res = oldname;
                    // return res;
                }

                return res;
            }
            return oldname;
        }


        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <returns></returns>
        public static string GetDomain()
        {
            return string.Format("{0}://{1}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Authority);
        }





        #region URL��ȥ��ָ������
        ///
        /// ��ȥ��ָ������
        ///
        /// ��ַ
        /// ����
        ///
        public static string buildurl(string url, string param)
        {
            string url1 = url;
            if (url.IndexOf(param) > 0)
            {
                if (url.IndexOf("&", url.IndexOf(param) + param.Length) > 0)
                {
                    url1 = url.Substring(0, url.IndexOf(param) - 1) + url.Substring(url.IndexOf("&", url.IndexOf(param) + param.Length) + 1);
                }
                else
                {
                    url1 = url.Substring(0, url.IndexOf(param) - 1);
                }
                return url1;
            }
            else
            {
                return url1;
            }
        }
        #endregion
        #region "��ȡҳ��url"
        ///
        /// ��ȡ��ǰ����ҳ���ַ����
        ///
        public static string GetScriptNameQueryString
        {
            get
            {
                return HttpContext.Current.Request.ServerVariables["QUERY_STRING"].ToString();
            }
        }
        ///
        /// ��ȡ��ǰ����ҳ���ַ
        ///
        public static string GetScriptName
        {
            get
            {
                return HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString();
            }
        }
        ///
        /// ��ȡ��ǰ����ҳ��Url
        ///
        public static string GetScriptUrl
        {
            get
            {
                return GetScriptNameQueryString == "" ? GetScriptName : string.Format("{0}?{1}", GetScriptName, GetScriptNameQueryString);
            }
        }
        ///
        /// ��ȡ��ǰ����ҳ�� ����
        ///
        public static string GetScriptNameQuery
        {
            get
            {
                return HttpContext.Current.Request.Url.Query;
            }
        }
        #endregion





        /// <summary>
        /// ��ȡ�ַ�����������Ӣ��
        /// </summary>
        /// <param name="inputString"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string CutString(object inputString, int len)
        {
            string strInput = inputString == null ? "" : inputString.ToString();

            ASCIIEncoding ascii = new ASCIIEncoding();
            int tempLen = 0;
            string tempString = "";
            byte[] s = ascii.GetBytes(strInput);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                {
                    tempLen += 2;
                }
                else
                {
                    tempLen += 1;
                }

                try
                {
                    tempString += strInput.Substring(i, 1);
                }
                catch
                {
                    break;
                }

                if (tempLen > len)
                    break;
            }
            //����ع�����ϰ��ʡ�Ժ� 
            byte[] mybyte = System.Text.Encoding.Default.GetBytes(strInput);
            if (mybyte.Length > len)
                tempString += "...";


            return tempString;
        }

        /// <summary>
        /// ��ȡ�ַ����У��ո�����ĵ�����
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int getIndex(string text)
        {
            int iResult = text.Length - 1;
            for (int i = 0; i < text.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(text[i].ToString()) || (int)text[i] > 127)
                {
                    iResult = i;
                    break;
                }
                else
                {
                    continue;
                }
            }
            return iResult;
        }

        /// <summary>
        /// ��ȡurl�ַ������������ز���ֵ�ַ���
        /// </summary>
        /// <param name="name">��������</param>
        /// <param name="url">url�ַ���</param>
        /// <returns></returns>
        public static string GetQueryString(string name, string url)
        {
            Regex re = new Regex(@"(^|&)?(\w+)=([^&]+)(&|$)?", RegexOptions.Compiled);
            MatchCollection mc = re.Matches(url);
            foreach (Match m in mc)
            {
                if (m.Result("$2").Equals(name))
                {
                    return m.Result("$3");
                }
            }
            return "";
        }


    }

}

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
    /// PageFunc 的摘要说明。
    /// </summary>
    public class PageFunc : System.Web.UI.Page
    {
        public PageFunc()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 弹出标准确定对话框
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
        /// 弹出标准确定对话框
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
        /// 弹出标准确定对话框
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
        /// 确认信息并且跳转（无条件）
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
        /// 用于对对密码使用FormsAuthenticationTicket对象进行加密
        /// </summary>
        public static string Encrypt(string Password)
        {
            string str = "";
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(Password, true, 2);
            str = FormsAuthentication.Encrypt(ticket).ToString();
            return str;
        }

        /// <summary>
        /// 对密码进行SHA1（Format＝0）或MD5（Format＝1）加密
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
        /// 用于解密用户的密码
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
        /// <param name="d">DropDownList对象</param>
        /// <param name="nowlayer">当前层</param>
        ///  <param name="so">标识符号</param>
        /// <param name="sel">选定内容</param>
        /// <param name="ds">数据集</param>
        /// <param name="valuename">值字段</param>
        /// <param name="fidname">当前节点字段名</param>
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
        /// <param name="d">DropDownList对象</param>
        /// <param name="nowlayer">当前层</param>
        ///  <param name="so">标识符号</param>
        /// <param name="sel">选定内容</param>
        /// <param name="ds">数据集</param>
        /// <param name="fup">上级节点</param>
        /// <param name="valuename">值字段</param>
        /// <param name="textname">标识信息字段名</param>
        /// <param name="fupname">上级节点字段名</param>
        /// <param name="fidname">当前节点字段名</param>
        public static void FillDDL(DropDownList d, int nowlayer, string sel, string so, DataSet ds, string fup, string valuename, string textname, string fupname, string fidname)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i][fupname].ToString() == fup)
                {
                    ListItem li;
                    //生成前面的标识
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
        /// 产品类别
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
                    //生成前面的标识
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

        /// <param name="total">总记录数</param>
        /// <param name="per">每页记录数</param>
        /// <param name="page">当前页数</param>
        /// <param name="query_string">Url参数</param>
        public  static string paginationSearch(int total, int per, int page, string query_string)
        {
            int allpage = 0;
            int next = 0;
            int pre = 0;
            int startcount = 0;
            int endcount = 0;
            string pagestr = "";

            if (page < 1) { page = 1; }
            //计算总页数
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
            startcount = (page + 5) > allpage ? allpage - 9 : page - 4;//中间页起始序号
            //中间页终止序号
            endcount = page < 5 ? 10 : page + 5;
            if (startcount < 1) { startcount = 1; } //为了避免输出的时候产生负数，设置如果小于1就从序号1开始
            if (allpage < endcount) { endcount = allpage; }//页码+5的可能性就会产生最终输出序号大于总页码，那么就要将其控制在页码数之内
            pagestr = "";// "共" + allpage + "页";

            pagestr += page > 1 ? "<span><a href=\"" + query_string + "\">首页</a></span><span><a href=\"" + query_string + "&page=" + pre + "\">上一页</a></span>" : "";
            //中间页处理，这个增加时间复杂度，减小空间复杂度
            for (int i = startcount; i <= endcount; i++)
            {
                pagestr += page == i ? "<strong>" + i + "</strong>" : "<span><a href=\"" + query_string +"&page="+i+ "\">" + i + "</a></span>";
            }
            pagestr += page != allpage ? "<span><a href=\"" + query_string + "&page="+ next +"\">下一页</a></strong><span><a href=\"" + query_string + "&page=" + allpage + "\">末页</a></strong>" : " ";

            return pagestr;
        }


        /// <param name="total">总记录数</param>
        /// <param name="per">每页记录数</param>
        /// <param name="page">当前页数</param>
        /// <param name="query_string">Url参数</param>
        public static string pagination(int total, int per, int page, string query_string)
        {
            int allpage = 0;
            int next = 0;
            int pre = 0;
            int startcount = 0;
            int endcount = 0;
            string pagestr = "";

            if (page < 1) { page = 1; }
            //计算总页数
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
            startcount = (page + 5) > allpage ? allpage - 9 : page - 4;//中间页起始序号
            //中间页终止序号
            endcount = page < 5 ? 10 : page + 5;
            if (startcount < 1) { startcount = 1; } //为了避免输出的时候产生负数，设置如果小于1就从序号1开始
            if (allpage < endcount) { endcount = allpage; }//页码+5的可能性就会产生最终输出序号大于总页码，那么就要将其控制在页码数之内
            pagestr = "";// "共" + allpage + "页";

            pagestr += page > 1 ? "<span><a href=\"" + query_string + ".aspx\">首页</a></span><span><a href=\"" + query_string + "_" + pre + ".aspx\">上一页</a></span>" : "";
            //中间页处理，这个增加时间复杂度，减小空间复杂度
            for (int i = startcount; i <= endcount; i++)
            {
                pagestr += page == i ? "<strong>" + i + "</strong>" : "<span><a href=\"" + query_string + "_" + i + ".aspx\">" + i + "</a></span>";
            }
            pagestr += page != allpage ? "<span><a href=\"" + query_string + "_" + next + ".aspx\">下一页</a></strong><span><a href=\"" + query_string + "_" + allpage + ".aspx\">末页</a></strong>" : " ";

            return pagestr;
        }


        //验证是否为浮点数字 
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
        /// 显示错误信息
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
        /// 执行js
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
        /// <param name="s">UploadFile对象</param>
        /// <param name="oldname">原文件名</param>
        /// <param name="UpFileDIR">UpFileDIR: 远程保存的地址，默认为"./"</param>
        /// <returns></returns>
        public string UploadFile(System.Web.HttpPostedFile s, string oldname, string UpFileDIR, string canextension, int length, int sm, int sm_Width, int sm_hight)
        {
            if (s.FileName.Trim() != "")
            {
                string res = "";
                try
                {
                    //对文件大小进行判断
                    if (length != 0)
                    {
                        if (s.ContentLength > length)
                        {
                            HttpContext.Current.Response.Write(PageFunc.ShowErrMsg("上传失败，文件大小超过" + length + "B"));
                            HttpContext.Current.Response.Write("<script language=javascript>history.go(-1);</script>");
                            HttpContext.Current.Response.End();
                        }
                    }


                    if (UpFileDIR.Trim() == "")
                    {
                        UpFileDIR = "/";		//保证规格为"/UploadFile/"
                    }
                    else
                    {
                        //上传目录不存在，则创建
                        if (!Directory.Exists(Server.MapPath(UpFileDIR)))
                        {
                            Directory.CreateDirectory(Server.MapPath(UpFileDIR));
                        }
                    }


                    //上传文件
                    string extension = Path.GetExtension(s.FileName).ToUpper();

                    //对文件的扩张名进行判断
                    if (canextension.IndexOf(extension.Substring(1, extension.Length - 1)) == -1)
                    {
                        HttpContext.Current.Response.Write(PageFunc.ShowErrMsg("上传的文件类型不符合系统要求,请上传" + canextension + "类型的文件") + "<script language=javascript>history.go(-1);</script>");
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
                    //删除原来文件
                    string oldFilePath = Server.MapPath(UpFileDIR + oldname);
                    if (oldname != "" && File.Exists(oldFilePath))
                    {
                        File.Delete(oldFilePath);
                    }
                    res = res.Substring(res.LastIndexOf("/") + 1, res.Length - res.LastIndexOf("/") - 1);

                    //当sm为1的时候，表明要生成缩略图
                    if (sm == 1)
                    {
                        ////////生成缩略图
                        //生成小图片
                        System.Drawing.Image image = new Bitmap(path);//得到原图


                        //创建指定大小的图
                        //System.Drawing.Image newImage = image.GetThumbnailImage(sm_Width, sm_hight, null, new IntPtr());


                        System.Drawing.Bitmap newImage = new Bitmap(sm_Width, sm_hight);
                        Graphics g = Graphics.FromImage(newImage);
                        //将原图画到指定的图上
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//消除锯齿
                        g.DrawImage(image,
                            new System.Drawing.Rectangle(0, 0, sm_Width, sm_hight), //你的新大小
                            new System.Drawing.Rectangle(0, 0, image.Width, image.Height),//你的原图大小
                            System.Drawing.GraphicsUnit.Pixel);

                        g.Dispose();
                        newImage.Save(newSmPath);
                    }


                    /////////


                    return res;

                }
                catch (Exception e)
                {
                    //Response.Write(Functions.ShowErrMsg("图片上传失败"));
                    //HttpContext.Current.Response.Write(Functions.ShowErrMsg(e.ToString()));
                    HttpContext.Current.Response.Write(PageFunc.ShowErrMsg("上传时出现错误,操作失败。" + e.ToString()));
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
        /// 上传附件
        /// </summary>
        /// <param name="s">UploadFile对象</param>
        /// <param name="oldname">原文件名</param>
        /// <param name="UpFileDIR">UpFileDIR: 远程保存的地址，默认为"./"</param>
        /// <returns></returns>
        public string UploadAttFile(System.Web.HttpPostedFile s, string UpFileDIR, string oldname, string canextension, int length)
        {
            if (s.FileName.Trim() != "")
            {
                string res = "";
                try
                {
                    //对文件大小进行判断
                    if (length != 0)
                    {
                        if (s.ContentLength > length)
                        {
                            HttpContext.Current.Response.Write(PageFunc.ShowErrMsg("上传失败，文件大小超过" + length + "B"));
                            HttpContext.Current.Response.Write("<script language=javascript>history.go(-1);</script>");
                            HttpContext.Current.Response.End();
                        }
                    }


                    if (UpFileDIR.Trim() == "")
                    {
                        UpFileDIR = "/";		//保证规格为"/UploadFile/"
                    }

                    //上传文件
                    string extension = Path.GetExtension(s.FileName).ToUpper();

                    //对文件的扩张名进行判断
                    if (canextension.IndexOf(extension.Substring(1, extension.Length - 1)) == -1)
                    {
                        HttpContext.Current.Response.Write(PageFunc.ShowErrMsg("上传的文件类型不符合系统要求,请上传" + canextension + "类型的文件") + "<script language=javascript>history.go(-1);</script>");
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
                    //删除原来文件
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
                    //Response.Write(Functions.ShowErrMsg("图片上传失败"));
                    //HttpContext.Current.Response.Write(Functions.ShowErrMsg(e.ToString()));
                    HttpContext.Current.Response.Write(PageFunc.ShowErrMsg("上传时出现错误,操作失败"));
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
        /// 获取域名
        /// </summary>
        /// <returns></returns>
        public static string GetDomain()
        {
            return string.Format("{0}://{1}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Authority);
        }





        #region URL中去除指定参数
        ///
        /// 中去除指定参数
        ///
        /// 地址
        /// 参数
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
        #region "获取页面url"
        ///
        /// 获取当前访问页面地址参数
        ///
        public static string GetScriptNameQueryString
        {
            get
            {
                return HttpContext.Current.Request.ServerVariables["QUERY_STRING"].ToString();
            }
        }
        ///
        /// 获取当前访问页面地址
        ///
        public static string GetScriptName
        {
            get
            {
                return HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString();
            }
        }
        ///
        /// 获取当前访问页面Url
        ///
        public static string GetScriptUrl
        {
            get
            {
                return GetScriptNameQueryString == "" ? GetScriptName : string.Format("{0}?{1}", GetScriptName, GetScriptNameQueryString);
            }
        }
        ///
        /// 获取当前访问页面 参数
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
        /// 截取字符串，区别中英文
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
            //如果截过则加上半个省略号 
            byte[] mybyte = System.Text.Encoding.Default.GetBytes(strInput);
            if (mybyte.Length > len)
                tempString += "...";


            return tempString;
        }

        /// <summary>
        /// 获取字符串中，空格或中文的索引
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
        /// 获取url字符串参数，返回参数值字符串
        /// </summary>
        /// <param name="name">参数名称</param>
        /// <param name="url">url字符串</param>
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

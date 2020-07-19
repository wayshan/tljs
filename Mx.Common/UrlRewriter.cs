using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Xml;
using System.IO;

namespace UrlRewriter
{

    public class HttpModule : IHttpModule
    {
        #region IHttpModule 成员

        public void Dispose()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Init(HttpApplication context)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IHttpModule 成员

        void IHttpModule.Dispose()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        void IHttpModule.Init(HttpApplication context)
        {
            context.AcquireRequestState += new EventHandler(context_AcquireRequestState);
            context.BeginRequest += new EventHandler(Module_BeginRequest);
            context.EndRequest += new EventHandler(Module_EndRequest);
        }

        void context_AcquireRequestState(object sender, EventArgs e)
        {

            HttpApplication application = (HttpApplication)sender;
            string ip = application.Request.ServerVariables["LOCAL_ADDR"];
            string requestUrl = application.Request.Url.ToString().ToLower();
        }

        protected void Module_BeginRequest(Object sender, EventArgs e)
        {

            HttpContext hc = (sender as HttpApplication).Context;

            string url = hc.Request.Url.AbsoluteUri.ToString();
            
            url = url.ToLower();
            if (url.IndexOf("/tkl/") < 0 && url.IndexOf("/comm/") < 0  && url.IndexOf("/user/") < 0 && url.IndexOf("/img/") < 0 && url.IndexOf("/js/") < 0 && url.IndexOf("/images/") < 0 && url.IndexOf("/upload/") < 0)
            {
                url = RuleParser.Parse(url);
                //hc.Response.Write("url2:" + url + "<br>");
                //hc.Response.End();
                if (!String.IsNullOrEmpty(url))
                {
                    //hc.Response.Write(url);
                    //hc.Response.End();
                    hc.RewritePath(url);
                }
            }
           
        }

        protected void Module_EndRequest(Object sender, EventArgs e)
        {
            //
        }


       public void writeMsg(string msg, string filename)
    {
        string str_Directory = HttpContext.Current.Server.MapPath("~/");
        string str_file = str_Directory + "\\" + filename + ".txt";
        if (System.IO.File.Exists(str_file))
            System.IO.File.AppendAllText(str_file, msg, Encoding.UTF8);
        else
        {
            FileStream myFs = new FileStream(str_file, FileMode.Create);
            StreamWriter mySw = new StreamWriter(myFs);
            mySw.Write(msg); mySw.Close(); myFs.Close();
        }

    }

        #endregion
    }

    public static class RuleParser
    {
        //		private static int MAX_CACHE = 1024;
        private static Settings settings = ConfigurationManager.GetSection("rewriter") as Settings;
        private static NameValueCollection cache = new NameValueCollection(settings.maxcache);

        public static string Parse(string url)
        {
            string k = Utility.Hash.md5(url);
            string s = CheckCache(k);
            if (!String.IsNullOrEmpty(s))
            {
                //				EventLog.WriteEntry("Test", "Url Rewriter hit cache = " + s);
                return s;
            }

            Match match = null;
            Regex regex = null;
            foreach (Rule r in settings.rules)
            {
                if (!string.IsNullOrEmpty(r.urlfor) && !string.IsNullOrEmpty(r.urlnew))
                {
                    regex = new Regex(r.urlfor, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
                    match = regex.Match(url);
                    if (match.Success)
                    {
                        GroupCollection gc = match.Groups;
                        string[] ss = new string[gc.Count];
                        int i = 0;
                        foreach (Group g in gc)
                        {
                            ss[i++] = g.Value;
                        }
                        s = String.Format(r.urlnew, ss);
                        UpdateCache(k, s);
                        return s;
                    }
                }
            }
            return null;
        }

        private static string CheckCache(string key)
        {
            if (cache[key] != null)
                return cache[key];
            else
                return null;
        }

        private static void UpdateCache(string key, string val)
        {
            if (cache.Count >= settings.maxcache)
            {
                cache.Remove(cache.GetKey(0));
            }
            cache.Add(key, val);
        }
    }

    public sealed class Configuration : IConfigurationSectionHandler
    {
        public object Create(object parent, object input, XmlNode section)
        {
            Rule r = new Rule();
            Settings settings = new Settings();

            settings.maxcache = Int32.Parse(section.Attributes["maxcache"].Value);

            foreach (XmlNode xn in section.ChildNodes)
            {
                if (xn.HasChildNodes)
                {
                    // get <for> value
                    if (xn.FirstChild.HasChildNodes)
                        r.urlfor = xn.FirstChild.FirstChild.Value;
                    else
                        r.urlfor = xn.FirstChild.Value;
                    // get <new> value
                    if (xn.LastChild.HasChildNodes)
                        r.urlnew = xn.LastChild.FirstChild.Value;
                    else
                        r.urlnew = xn.LastChild.Value;
                }
                settings.rules.Add(r);
            }
            return settings;
        }
    }

    public class Settings
    {
        public int maxcache = 1024;
        public List<Rule> rules = new List<Rule>();
    }

    public struct Rule
    {
        public string urlfor;
        public string urlnew;
    }

   

}

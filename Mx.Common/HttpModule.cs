using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// HttpModule 的摘要说明
/// </summary>
public class HttpModule:IHttpModule 
{
    public void Dispose()
    {
    }

    public void Init(HttpApplication application)
    {
        application.BeginRequest += new EventHandler(Application_BeginRequest);
        application.EndRequest += new EventHandler(Application_EndRequest);
    }

    void Application_BeginRequest(Object source, EventArgs e)
    {
        string url = HttpContext.Current.Request.Url.ToString();
    }

    void Application_EndRequest(Object source, EventArgs e)
    {
        string url = HttpContext.Current.Request.Url.ToString();
        if (url.IndexOf("root.txt") > 0)
        {
            string[] UserHost = HttpContext.Current.Request.Url.Host.Split(new Char[] { '.' });
            string domain2 = UserHost[0];
            if (domain2 != "www") {
                String newUrl = "http://www." + HttpContext.Current.Request.Url.Host.ToString() + ":7001/yanzheng/" + domain2+".txt";
                HttpApplication application = (HttpApplication)source;
                HttpContext context = application.Context;
                context.RewritePath(url);
          
            }
        }
    } 
}

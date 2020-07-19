using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mx.Common;
using System.Web.SessionState;

namespace Mx.Web.Ajax
{
    /// <summary>
    /// AjaxValid 的摘要说明
    /// </summary>
    public class AjaxValid : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml";
            AjaxValidate ajax = new AjaxValidate();
            string act = context.Request["a"];
            //switch (act)
            //{                  
            //    case "cpwd":
            //        ajax = ChangePwd(context);
            //        break;                
                    
            //}
            string xml = XmlUtil.Serializer(typeof(AjaxValidate), ajax);
            context.Response.Write(xml);
        }
       

        //public AjaxValidate ChangePwd(HttpContext context)
        //{
        //    AdminPage bPage = new AdminPage();
        //    var LoginModel = context.Session[bPage.sessionAdminModel] as Model.AdminInfo;
        //    string oldPwd = HttpContext.Current.Request["opw"];
        //    BLL.Admin bllAdmin = new BLL.Admin();
        //    AjaxValidate ajaxClass = new AjaxValidate();

        //    Model.Admin model = new Model.Admin();

        //    model = bllAdmin.GetModel(LoginModel.ID);
        //    if (PageFunc.Encrypt(oldPwd, 1) != model.UserPwd)
        //    {
        //        ajaxClass.Msg = "旧密码不正确!";
        //        ajaxClass.Result = 0;
        //    }
        //    else
        //    {
        //        ajaxClass.Msg = "旧密码正确!";
        //        ajaxClass.Result = 1;
        //    }

        //    return ajaxClass;
        //}

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mx.Common;

namespace Mx.Web
{
    public class AdminPage : System.Web.UI.Page
    {        
        public string sessionAdminModel = "A_model";

        protected override void OnInit(EventArgs e)
        {
            //BLL.Admin bllAdmin = new BLL.Admin();
            //var u = bllAdmin.GetModel(1);
            //Model.AdminInfo uModel = new Model.AdminInfo
            //{
            //    ID = u.ID,
            //    UserName = u.UserName,
            //    UserType = Codes.AdminRole.管理员,
            //    TbAccount = "S1"
            //};
            //Session[sessionAdminModel] = uModel;

            if (Session[sessionAdminModel]==null && (Request.Url.ToString().ToLower().IndexOf("tljlist.aspx")!=-1 ||
                Request.Url.ToString().ToLower().IndexOf("tljdo.aspx") != -1 ||Request.Url.ToString().ToLower().IndexOf("change.aspx") != -1))
            {
                if(Request.QueryString["zhanghao"]!=null&&Request.QueryString["mima"]!=null)
                {
                    string username = Request.QueryString["zhanghao"];
                    string userpwd = Request.QueryString["mima"];
                    BLL.Admin bllAdmin = new BLL.Admin();
                    var uModel = bllAdmin.AdminLogin(username, PageFunc.Encrypt(userpwd, 1));
                    if (uModel != null)
                    {
                        Session[sessionAdminModel] = uModel;
                        Response.Redirect(Request.Url.ToString());
                    }
                    else
                    {
                        Response.Write("<script language='Javascript'>alert('帐号无效！');window.parent.location='login.aspx';</script>");
                        Response.End();
                    }
                }
            }

            if (Session[sessionAdminModel] == null)
            {
                Response.Write("<script language='Javascript'>alert('登录超时！');window.parent.location='login.aspx';</script>");
                Response.End();
            }
        }


        protected Model.AdminInfo CurrentLoginAdmin
        {
            get
            {
                return Session[sessionAdminModel] as Model.AdminInfo;
            }
        }

        /// <summary>
        /// 检验权限
        /// </summary>
        /// <param name="arr"></param>
        protected bool CheckAuth(string[] arr, bool bAlert = true)
        {
            bool bResult = arr.Contains(CurrentLoginAdmin.UserType);
            if (!arr.Contains(CurrentLoginAdmin.UserType) && bAlert)
            {
                Response.Write("<script language='Javascript'>alert('你无权限操作！');window.history.go(-1);</script>");
                Response.End();
            }
            return bResult;
        }
        
        
        ///// <summary>
        ///// 用户是否有关联数据
        ///// </summary>
        ///// <param name="qq">qq号码</param>
        ///// <param name="type">0：全部，1：评论，2：QQ返利，3：财务单</param>
        ///// <returns></returns>
        //protected bool GetUserDataByQQ(string qq,int type=0) {
        //    bool bResult = false;    
        //        BLL.InfoDetail bllInfoDetail =new BLL.InfoDetail();
        //        BLL.QQRebate bllQQRebate = new BLL.QQRebate();
        //        BLL.FinanceOrders bllFinanceOrders = new BLL.FinanceOrders();
        //        int total = 0;
        //        var listInfoDetail = bllInfoDetail.GetList(1, int.MaxValue, ref total, p => p.QQ.Contains(qq), p => p.ID, false);
        //        var listQQRebate = bllQQRebate.GetList(1, int.MaxValue, ref total, p => p.QQ.Contains(qq), p => p.ID, false);
        //        var listFinanceOrders = bllFinanceOrders.GetList(1, int.MaxValue, ref total, p => p.QQ.Contains(qq), p => p.ID, false);
        //        switch (type)
        //        {                   
        //            case 1:
        //                bResult = listInfoDetail.Count > 0;
        //                break;
        //            case 2:
        //                bResult = listQQRebate.Count > 0;
        //                break;
        //            case 3:
        //                bResult = listFinanceOrders.Count > 0;
        //                break;
        //            default:
        //                bResult = listInfoDetail.Count > 0 || listQQRebate.Count > 0 || listFinanceOrders.Count > 0;
        //                break;
        //        }
        //        return bResult;
        //}




    }
}
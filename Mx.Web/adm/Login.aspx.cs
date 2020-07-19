using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mx.Common;

namespace Mx.Web.adm
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            BLL.Admin bllAdmin = new BLL.Admin();
            if (Session["SSVC"] != null)
            {

                if (this.txtCode.Text.Trim().ToLower() != Session["SSVC"].ToString().ToLower())
                {
                    PageFunc.AjaxAlert(this.Page, "错误的验证码，请重新输入！");
                    this.txtCode.Text = "";
                }
                else
                {

                    var uModel = bllAdmin.AdminLogin(this.txtUserName.Text.Trim(), PageFunc.Encrypt(this.txtPassWd.Text, 1));
                    if (uModel != null)
                    {
                        if (!uModel.Enabled)
                        {
                            PageFunc.AjaxAlert(this.Page, "该帐号已被停用！");
                            this.txtCode.Text = "";
                        }
                        else
                        {
                            AdminPage basePage = new AdminPage();
                            Session[basePage.sessionAdminModel] = uModel;

                            Response.Redirect("TljList.aspx");
                        }
                    }
                    else
                    {
                        PageFunc.AjaxAlert(this.Page, "用户名或密码有误！");
                        this.txtCode.Text = "";
                    }
                    
                }
            }
            else
            {
                PageFunc.AjaxAlert(this.Page, "验证码无效，请重新刷新！");
                this.txtCode.Text = "";
            }
        }
    }
}
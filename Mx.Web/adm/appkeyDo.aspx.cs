using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mx.Common;

namespace Mx.Web.adm
{
    public partial class appkeyDo : AdminPage
    {
        Model.appkey modelappkey = new Model.appkey();
        BLL.appkey bllappkey = new BLL.appkey();

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckAuth(new string[] { Codes.AdminRole.管理员 });
            if (!IsPostBack)
            {
                ShowInfo();
            }
        }


        protected void ShowInfo()
        {
            if (Request.QueryString["id"] != null)
            {

                modelappkey = bllappkey.GetModel(int.Parse(Request.QueryString["id"]));

                txtAppKey.Text = modelappkey.AppKey;
                txtAppSecret.Text = modelappkey.AppSecret;
                txtAppName.Text = modelappkey.AppName;
                txtTbAccount.Text = modelappkey.TbAccount;
                chbIsDefault.Checked = modelappkey.IsDefault.Value;

                this.BtnSubmit.Visible = false;
                this.BtnUpdate.Visible = true;
            }

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            modelappkey.AppKey=txtAppKey.Text.Trim();
            modelappkey.AppSecret=txtAppSecret.Text.Trim();
            modelappkey.AppName=txtAppName.Text.Trim();
            modelappkey.TbAccount=txtTbAccount.Text.Trim();
            modelappkey.IsDefault=chbIsDefault.Checked;

            bllappkey.Add(modelappkey);
            Response.Write(PageFunc.ShowMsgJumpE("添加成功！", "appkeyList.aspx"));
        }



        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"]);

                modelappkey = bllappkey.GetModel(id);

                modelappkey.AppKey = txtAppKey.Text.Trim();
                modelappkey.AppSecret = txtAppSecret.Text.Trim();
                modelappkey.AppName = txtAppName.Text.Trim();
                modelappkey.TbAccount = txtTbAccount.Text.Trim();
                modelappkey.IsDefault = chbIsDefault.Checked;

                bllappkey.Update(modelappkey);
                Response.Write(PageFunc.ShowMsgJumpE("更新成功！", "appkeyList.aspx"));
            }
        }
    }
}
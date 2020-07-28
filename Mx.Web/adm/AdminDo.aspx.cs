using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mx.Common;

namespace Mx.Web.adm
{
    public partial class AdminDo : AdminPage
    {
        Model.Admin modelAdmin = new Model.Admin();
        BLL.Admin bllAdmin = new BLL.Admin();
        BLL.appkey bllappkey = new BLL.appkey();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckAuth(new string[] { Codes.AdminRole.管理员});
            if (!IsPostBack)
            {
                ddlDataBind();

                ShowInfo();
            }
        }
        /// <summary>
        /// 下拉框数据绑定
        /// </summary>
        protected void ddlDataBind()
        {
            int total = 0;
            var appkeyList = bllappkey.GetList(1, int.MaxValue, ref total,
                new Model.appkeyCondition { }, w => w.ID, false);
            var listAccount = appkeyList.GroupBy(m => new { m.TbAccount }).Select(m => m.Key).ToList();
            foreach (var item in listAccount)
            {
                ListItem li = new ListItem(item.TbAccount, item.TbAccount);
                ddlAccount.Items.Add(li);
            }
        }

        protected void ShowInfo()
        {
            if (Request.QueryString["id"] != null)
            {
                modelAdmin = bllAdmin.GetModel(int.Parse(Request.QueryString["id"]));

                txtUserName.Text = modelAdmin.UserName;
                txtPwd.Attributes.Add("value", "重新设置密码");
                txtRePwd.Attributes.Add("value", "重新设置密码");
                chbIsEnabled.Checked = modelAdmin.Enabled.Value;
                ddlUserType.SelectedValue = modelAdmin.UserType;
                txtRemark.Text = modelAdmin.Remark;
                ddlAccount.SelectedValue = modelAdmin.TbAccount;

                this.BtnSubmit.Visible = false;
                this.BtnUpdate.Visible = true;
            }

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            var model = bllAdmin.GetModel(p => p.UserName.Equals(username));
            if (model != null)
            {
                PageFunc.AjaxAlert(this.Page, "用户名已存在！");
                return;
            }


            modelAdmin.UserName = username;
            modelAdmin.UserPwd = PageFunc.Encrypt(txtPwd.Text, 1);
            modelAdmin.AddTime = DateTime.Now;
            modelAdmin.Enabled = chbIsEnabled.Checked;
            modelAdmin.UserType = ddlUserType.SelectedValue;
            modelAdmin.Remark = txtRemark.Text.Trim();
            modelAdmin.TbAccount = ddlAccount.SelectedValue;

            bllAdmin.Add(modelAdmin);
            Response.Write(PageFunc.ShowMsgJumpE("添加成功！", "AdminList.aspx"));
        }



        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"]);
                string username = txtUserName.Text.Trim();
                var model = bllAdmin.GetModel(p => p.ID != id && p.UserName.Equals(username));
                if (model != null)
                {
                    PageFunc.AjaxAlert(this.Page, "用户名已存在！");
                    return;
                }



                modelAdmin = bllAdmin.GetModel(int.Parse(Request.QueryString["id"]));
               
                modelAdmin.UserName = username;
                if (txtPwd.Text != "重新设置密码")
                {
                    modelAdmin.UserPwd = PageFunc.Encrypt(txtPwd.Text, 1);
                }
                modelAdmin.Enabled = chbIsEnabled.Checked;
                modelAdmin.UserType = ddlUserType.SelectedValue;
                
                modelAdmin.Remark = txtRemark.Text.Trim();
                modelAdmin.TbAccount = ddlAccount.SelectedValue;

                bllAdmin.Update(modelAdmin);
                Response.Write(PageFunc.ShowMsgJumpE("更新成功！", "AdminList.aspx"));
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mx.Common;

namespace Mx.Web.uadm
{
    public partial class ChangePwd : AdminPage
    {
        Model.Admin modelAdmin = new Model.Admin();
        BLL.Admin bllAdmin = new BLL.Admin();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            var loginModel = Session[sessionAdminModel] as Model.AdminInfo;            
            modelAdmin = bllAdmin.GetModel(loginModel.ID);
            modelAdmin.UserPwd = PageFunc.Encrypt(txtPwd.Text, 1);

            bllAdmin.Update(modelAdmin);
            Response.Write(PageFunc.ShowMsgJumpE("更新成功！", "ChangePwd.aspx"));

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mx.Web;
using Mx.Web.Codes;

namespace Mx.Web.adm
{
    public partial class AdminBaseMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminPage basePage = new AdminPage();
            if (Session[basePage.sessionAdminModel] != null)
            {
                var modelAccount = Session[basePage.sessionAdminModel] as Model.AdminInfo;
                LbUserName.Text = string.Format("{0}", modelAccount.UserName);


                switch (modelAccount.UserType)
                {
                    case AdminRole.管理员:
                        phAdmin.Visible = true;                        
                        break;                   
                }

            }
        }
    }
}
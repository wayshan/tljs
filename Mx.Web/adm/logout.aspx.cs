using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mx.Web.adm
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminPage basePage = new AdminPage();
            Session.Remove(basePage.sessionAdminModel);
            Response.Redirect("Login.aspx");
        }
    }
}
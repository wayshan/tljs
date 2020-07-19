using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Mx.Common;

public partial class comm_CheckCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        clsCheckCode cc = new clsCheckCode();
        cc.Chaos = true;
        string chkcode = cc.CreateVerifyCode(4);
        Session["SSVC"] = cc.CreateVerifyCode(4);
        cc.CreateImageOnPage(Session["SSVC"].ToString(), this.Context);
    }
}

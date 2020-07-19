using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mx.Web.adm
{
    public partial class AdminList : AdminPage
	{
        BLL.Admin bllAdmin = new BLL.Admin();

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckAuth(new string[] { Codes.AdminRole.管理员});
            DataInfoBind();
        }


        protected void DataInfoBind()
        {
            int total = 0;
            var list = bllAdmin.GetList(ShowPager.CurrentPageIndex, ShowPager.PageSize, ref total, p => true, p => p.ID, false);

            ShowPager.RecordCount = total;
            this.rpData.DataSource = list;
            this.rpData.DataBind();
        }


        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            DataInfoBind();
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDo.aspx");
        }


        protected void LbEdit_Click(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument.ToString();
            Response.Redirect("AdminDo.aspx?id=" + id);
        }


        protected void LbDel_Click(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument.ToString();
            bllAdmin.Delete(int.Parse(id));
            //DataInfoBind();
            Response.Redirect("AdminList.aspx");
        }
	}
}
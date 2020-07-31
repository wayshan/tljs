using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mx.Common;
using System.Collections;
using Mx.Model;

namespace Mx.Web.adm
{
    public partial class plansList : AdminPage
    {
        private BLL.plans bllplans = new BLL.plans();
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckAuth(new string[] { Codes.AdminRole.管理员 });
            if (!IsPostBack)
            {
                if (Request.QueryString["sort"] != null)
                {
                    ddlsort.SelectedValue = Request.QueryString["sort"];
                }
                DataInfoBind();
            }
        }


        protected void DataInfoBind()
        {
            ShowPager.PageSize = PageSize;
            int total = 0;
            Model.plansCondition con = condition();
            var list = new List<Model.plans>();
            if (ddlsort.SelectedValue == "2")
            {
                list = bllplans.GetList(ShowPager.CurrentPageIndex, ShowPager.PageSize, ref total, con, p => p.lastOkTime, false);
            }
            else if (ddlsort.SelectedValue == "3")
            {
                list = bllplans.GetList(ShowPager.CurrentPageIndex, ShowPager.PageSize, ref total, con, p => p.lastOkTime, false);
            }
            else
            {
                list = bllplans.GetList(ShowPager.CurrentPageIndex, ShowPager.PageSize, ref total, con, p => p.id, false);
            }
            ShowPager.RecordCount = total;
            this.rpData.DataSource = list;
            this.rpData.DataBind();
        }


        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            DataInfoBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataInfoBind();
        }

        protected Model.plansCondition condition()
        {
            Model.plansCondition con = new Model.plansCondition
            {
                goodsname = this.txtgoodsname.Text.Trim(),
                shopname = this.txtshopname.Text.Trim()
            };
            if (!string.IsNullOrEmpty(ddlifok.SelectedValue))
            {
                con.ifok = ddlifok.SelectedValue;
            }                                 
            return con;
        }


        protected void txtPageSize_TextChanged(object sender, EventArgs e)
        {
            DataInfoBind();
        }
        public int PageSize
        {
            get
            {
                int ps = 10;
                bool d = int.TryParse(this.txtPageSize.Text.Trim(), out ps);
                if (!d)
                {
                    this.txtPageSize.Text = "10";
                }
                return ps;
            }
        }

    }
}
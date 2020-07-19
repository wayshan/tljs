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
                DataInfoBind();

                //Model.collectgoods model = new collectgoods
                //{
                //    qudao = "渠道",
                //    item_id = "产品ID",
                //    goodsname = "产品名",
                //    paymoney = 20.30m,
                //    lijing = 4.50m,
                //    shopname = "店铺名称",
                //    msg = "msg",
                //    campaigntype = "计划类型",
                //    ifok = "有效",
                //    zctime = DateTime.Now
                //};
                //string json = Newtonsoft.Json.JsonConvert.SerializeObject(model);

            }
        }


        protected void DataInfoBind()
        {
            ShowPager.PageSize = PageSize;
            int total = 0;
            Model.plansCondition con = condition();
            var list = bllplans.GetList(ShowPager.CurrentPageIndex, ShowPager.PageSize, ref total, con, p => ddlsort.SelectedValue == "2" ? p.tdRatio : p.id, false);
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
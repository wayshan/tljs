using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mx.Common;

namespace Mx.Web.adm
{
    public partial class plansDo : AdminPage
    {
        Model.plans modelplans = new Model.plans();
        BLL.plans bllplans = new BLL.plans();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ShowInfo();
            }
        }


        protected void ShowInfo()
        {


        }



        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
        }


        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            add();
        }



        private void add()
        {           
            modelplans = new Model.plans();
            modelplans.item_id = txtitem_id.Text.Trim();
            modelplans.goodsname = txtgoodsname.Text.Trim();
            modelplans.pic = txtitem_pic.Value.Trim();
            modelplans.planname = txtplan_name.Text.Trim();
            modelplans.campaignId = txtcampaignId.Text.Trim();
            modelplans.planlink = txtplan_link.Text.Trim();
            modelplans.coupon_url = txtquan_link.Text.Trim();
            modelplans.commission_dx = txtcommission_dx.Text.Trim();
            modelplans.commission_MKT = txtcommission_MKT.Text.Trim();

            bllplans.Add(modelplans);
            Response.Write(PageFunc.ShowMsgJumpE("添加成功！", "plansList.aspx"));

        }
    }
}
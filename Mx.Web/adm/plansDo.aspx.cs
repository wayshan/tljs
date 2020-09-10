using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mx.Common;
using System.Text.RegularExpressions;

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
            string planLink = txtplan_link.Text.Trim();
            string camId = "";            
            Regex reg = new Regex("campaignId=(.+)&?");
            Match match = reg.Match(planLink);
            camId = match.Groups[1].Value;
            var model = bllplans.GetModel(p => p.planlink.ToLower()==planLink || p.campaignId == camId);
            if (model != null)
            {
                PageFunc.AjaxAlert(this.Page, "计划链接已存在！");
                return;
            }
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
            modelplans.ifok = "正常";
            modelplans.zctime = DateTime.Now;
            decimal paymoney = 0m;
            decimal.TryParse(txtPayMoney.Text.Trim(), out paymoney);
            modelplans.PayMoney = paymoney;

            bllplans.Add(modelplans);
            Response.Write(PageFunc.ShowMsgJumpE("添加成功！", "plansList.aspx"));

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mx.Common;

namespace Mx.Web.adm
{
    public partial class TljDo : AdminPage
    {
        Model.TljInfo modelTljInfo = new Model.TljInfo();
        BLL.TljInfo bllTljInfo = new BLL.TljInfo();
        BLL.appkey bllappkey = new BLL.appkey();
        public static string xianshi= "";
        public string initJs = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                if (Request.QueryString["gid"] != null && Request.QueryString["lj"] != null
                    && Request.QueryString["ql"] != null && Request.QueryString["ct"] != null)
                {
                    goods_link.Text = Request.QueryString["gid"];
                    txtquan_link.Text = Request.QueryString["ql"];
                    txtper_face.Text = Request.QueryString["lj"];
                    if (Request.QueryString["ct"].ToString() == "DX")
                    {
                        ddlCampaignType.SelectedValue = "DX";
                        initJs += "isDx = true;";
                    }
                    initJs += "$('.getGoodsInfo').click();";

                    

                }


                if (Request.QueryString["zhuangtai"] != null)
                {
                    if (Request.QueryString["zhuangtai"] == "false") xianshi = "style='display:none;'";
                    else xianshi = "";
                }
                else {
                    xianshi = "";
                }

                //txtpagePrice.Attributes.Add("readonly", "true");
                ddlDataBind();
                ShowInfo();
            }
        }


        protected void ShowInfo()
        {
            txtcreatetime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            txtsend_start_time.Text = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
            txtsend_end_time.Text = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");

            if (Request.QueryString["id"] != null)
            {

                modelTljInfo = bllTljInfo.GetModel(int.Parse(Request.QueryString["id"]));

                txtpagePrice.Text = modelTljInfo.PayMoney.ToString();
                ddlAppKeyID.SelectedValue = modelTljInfo.AppKeyID.ToString();
                txtActiveCode.Text = modelTljInfo.ActiveCode;
                txtitem_id.Text = modelTljInfo.item_id;
                txtgoodsname.Text = modelTljInfo.goodsname;
                txtquan_link.Text = modelTljInfo.quan_link;
                ddlname.SelectedValue = modelTljInfo.name.ToString();
                ddlCampaignType.SelectedValue = modelTljInfo.campaigntype;
                txtbatch.Text = modelTljInfo.batch.ToString();
                txttotal_num.Text = modelTljInfo.total_num.ToString();
                txtper_face.Text = modelTljInfo.per_face.ToString();
                txtuser_total_win_num_limit.Text = modelTljInfo.user_total_win_num_limit.ToString();
                txtsend_start_time.Text = modelTljInfo.send_start_time.Value.ToString("yyyy-MM-dd HH:mm:ss");
                txtsend_end_time.Text = modelTljInfo.send_end_time.Value.ToString("yyyy-MM-dd HH:mm:ss");
                txtuse_end_time.Text = modelTljInfo.use_end_time.ToString();
                

                this.BtnSubmit.Visible = false;
                this.BtnUpdate.Visible = true;
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
            foreach (var item in appkeyList)
            {
                ListItem li = new ListItem(item.AppName, item.ID.ToString());   //item.TbAccount
                ddlAppKeyID.Items.Add(li);
            }

            var modelDefault = appkeyList.FirstOrDefault(m => m.IsDefault == true);
            if (modelDefault != null)
            {
                ddlAppKeyID.SelectedValue = modelDefault.ID.ToString();
            }
            if (Request.Cookies["zhanghaoid"] != null)
            {

                ddlAppKeyID.SelectedValue = Request.Cookies["zhanghaoid"].Value;
            }
        }



        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            add();
        }



        private void add()
        {
            DateTime dtCreate = DateTime.Parse(txtcreatetime.Text.Trim());
            int batch = int.Parse(txtbatch.Text.Trim());
            for (int i = 0; i < batch; i++)
            {
                modelTljInfo = new Model.TljInfo();
                modelTljInfo.AppKeyID = int.Parse(ddlAppKeyID.SelectedValue);
                modelTljInfo.ActiveCode = txtActiveCode.Text.Trim();
                modelTljInfo.item_id = txtitem_id.Text.Trim();
                modelTljInfo.goodsname = txtgoodsname.Text.Trim();
                modelTljInfo.quan_link = txtquan_link.Text.Trim();
                modelTljInfo.name = ddlname.SelectedValue;
                modelTljInfo.batch = int.Parse(txtbatch.Text.Trim());
                modelTljInfo.total_num = int.Parse(txttotal_num.Text.Trim());
                modelTljInfo.per_face = decimal.Parse(txtper_face.Text.Trim());
                modelTljInfo.user_total_win_num_limit = int.Parse(txtuser_total_win_num_limit.Text.Trim());
                modelTljInfo.send_start_time = DateTime.Parse(txtsend_start_time.Text.Trim());
                modelTljInfo.send_end_time = DateTime.Parse(txtsend_end_time.Text.Trim());
                modelTljInfo.use_end_time = int.Parse(txtuse_end_time.Text.Trim());
                modelTljInfo.createtime = dtCreate;
                modelTljInfo.ifok = "未创建";
                modelTljInfo.ifget = false;
                modelTljInfo.item_pic = txtitem_pic.Value;
                modelTljInfo.commission_bili = decimal.Parse(txtcommission_bili.Text.Trim());
                modelTljInfo.quanPrice = decimal.Parse(txtquanPrice.Text.Trim());

                modelTljInfo.zctime = DateTime.Now;
                modelTljInfo.remark = txtRemark.Text.Trim();
                modelTljInfo.iftop = int.Parse(ddliftop.SelectedValue);
                modelTljInfo.campaigntype = ddlCampaignType.SelectedValue;
                modelTljInfo.PayMoney= decimal.Parse(txtpagePrice.Text.Trim());
                decimal pagePrice = decimal.Parse(txtpagePrice.Text.Trim());
                if ((pagePrice - modelTljInfo.per_face) == 0)
                {
                    modelTljInfo.goodstype = "免单";
                }

                if (pagePrice - modelTljInfo.per_face <0)
                {
                    modelTljInfo.goodstype = "负";
                }


                modelTljInfo.AID = CurrentLoginAdmin.ID;

                bllTljInfo.Add(modelTljInfo);
            }
            Response.Cookies["zhanghaoid"].Value = modelTljInfo.AppKeyID.ToString();    //增加对账号的选择后  cookies的记录
            Response.Cookies["zhanghaoid"].Expires = DateTime.Now.AddDays(100);
            Response.Write(PageFunc.ShowMsgJumpE("添加成功！", "TljList.aspx"));
            
        }



        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"]);

                modelTljInfo = bllTljInfo.GetModel(id);

                DateTime dtCreate = DateTime.Parse(txtcreatetime.Text.Trim());
                modelTljInfo.AppKeyID = int.Parse(ddlAppKeyID.SelectedValue);
                modelTljInfo.item_id = txtitem_id.Text.Trim();
                modelTljInfo.goodsname = txtgoodsname.Text.Trim();
                modelTljInfo.quan_link = txtquan_link.Text.Trim();
                modelTljInfo.name = ddlname.SelectedValue;
                modelTljInfo.batch = int.Parse(txtbatch.Text.Trim());
                modelTljInfo.total_num = int.Parse(txttotal_num.Text.Trim());
                modelTljInfo.per_face = decimal.Parse(txtper_face.Text.Trim());
                modelTljInfo.user_total_win_num_limit = int.Parse(txtuser_total_win_num_limit.Text.Trim());
                modelTljInfo.send_start_time = DateTime.Parse(txtsend_start_time.Text.Trim());
                modelTljInfo.send_end_time = DateTime.Parse(txtsend_end_time.Text.Trim());
                modelTljInfo.use_end_time = int.Parse(txtuse_end_time.Text.Trim());
                modelTljInfo.createtime = dtCreate;
                modelTljInfo.iftop = int.Parse(ddliftop.SelectedValue);
                modelTljInfo.campaigntype = ddlCampaignType.SelectedValue;
                modelTljInfo.PayMoney = decimal.Parse(txtpagePrice.Text.Trim());
                bllTljInfo.Update(modelTljInfo);
                Response.Write(PageFunc.ShowMsgJumpE("更新成功！", "TljList.aspx"));
            }
        }
    }
}
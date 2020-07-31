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
    public partial class TljList : AdminPage
    {
        private BLL.TljInfo bllTljInfo = new BLL.TljInfo();
        BLL.appkey bllappkey = new BLL.appkey();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["status"] != null)
                {
                    string status = Request.QueryString["status"].ToString();
                    if (status == "正常")
                    {
                        ddlgoodstype.SelectedValue = "";
                    }
                    else
                    {
                        ddlgoodstype.SelectedValue = status;
                    }                    
                }

                txtDateStart.Text = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
                txtDateEnd.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd 23:59:59");
                ddlDataBind();
                DataInfoBind();
            }
        }


        protected void DataInfoBind()
        {
            ShowPager.PageSize = PageSize;
            int total = 0;
            Model.TljInfoCondition con = condition();
            var list = bllTljInfo.GetList(ShowPager.CurrentPageIndex, ShowPager.PageSize, ref total, con, p => p.ID, false)
                .Select(i => new {
                    ID = i.ID,
                    goodsname = i.goodsname,
                    item_id = i.item_id,
                    item_pic = i.item_pic,
                    name = i.name,
                    total_num = i.total_num,
                    per_face = i.per_face,
                    user_total_win_num_limit = i.user_total_win_num_limit,
                    commission_bili = i.commission_bili,
                    goodstype = i.goodstype,
                    quanPrice = i.quanPrice,
                    send_start_time = i.send_start_time,
                    send_end_time = i.send_end_time,
                    use_end_time = i.use_end_time,
                    ifok = i.ifok,
                    kouling = i.kouling,
                    ifget = i.ifget,
                    gettime = i.gettime,
                    win_amount = i.win_amount,
                    win_num = i.win_num,
                    alipay_amount = i.alipay_amount,
                    pre_commission_amount = i.pre_commission_amount,
                    use_amount = i.use_amount,
                    use_num = i.use_num,
                    refund_amount = i.refund_amount,
                    refund_num = i.refund_num,
                    unfreeze_num = i.unfreeze_num,
                    unfreeze_amount = i.unfreeze_amount,
                    remark = i.remark,
                    zctime = i.zctime,
                    campaigntype = i.campaigntype,
                    PayMoney = i.PayMoney,
                    createtime = i.createtime,
                    dotime = i.dotime,
                    appkeyid = i.AppKeyID,
                    quan_link = i.quan_link,
                    yjyl = Math.Round((((i.PayMoney.HasValue ? i.PayMoney.Value : 0.00m)
                    * (i.commission_bili.HasValue ? i.commission_bili.Value : 0.00m) / 100)
                    * 0.88m - (i.per_face.HasValue ? i.per_face.Value : 0.00m)), 2, MidpointRounding.AwayFromZero),
                    AppName = new TljEntities().appkeys.FirstOrDefault(a => a.ID == i.AppKeyID) != null ?
                    new TljEntities().appkeys.FirstOrDefault(a => a.ID == i.AppKeyID).AppName : "",
                    TbAccount = new TljEntities().appkeys.FirstOrDefault(a => a.ID == i.AppKeyID) != null ?
                    new TljEntities().appkeys.FirstOrDefault(a => a.ID == i.AppKeyID).TbAccount : "",
                });

            

            ShowPager.RecordCount = total;
            this.rpData.DataSource = list;
            this.rpData.DataBind();
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
                ListItem li = new ListItem(item.AppName, item.AppName);
                ddlAppKeyID.Items.Add(li);
            }

            var listAccount = appkeyList.GroupBy(m => new { m.TbAccount }).Select(m => m.Key).ToList();
            foreach (var item in listAccount)
            {
                ListItem li = new ListItem(item.TbAccount, item.TbAccount);
                if (item.TbAccount == CurrentLoginAdmin.TbAccount)
                {
                    li.Selected = true;
                }
                ddlAccount.Items.Add(li);
            }
        }

        protected void LbDel_Click(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument.ToString();
            bllTljInfo.Delete(int.Parse(id));
            
            Response.Redirect("TljList.aspx");
        }


        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            DataInfoBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataInfoBind();
        }

        protected Model.TljInfoCondition condition()
        {
            Model.TljInfoCondition con = new Model.TljInfoCondition
            {
                KeyWords = this.txtKeyWords.Text.Trim()
            };
            if(!string.IsNullOrEmpty(txtDateStart.Text))
            {
                con.startTime = DateTime.Parse(txtDateStart.Text);
            }
            if (!string.IsNullOrEmpty(txtDateEnd.Text))
            {
                con.endTime = DateTime.Parse(txtDateEnd.Text);
            }
            if (!string.IsNullOrEmpty(ddlifget.SelectedValue))
            {
                con.ifget = Convert.ToBoolean(ddlifget.SelectedValue);
            }
            if (!string.IsNullOrEmpty(ddlIfok.SelectedValue))
            {
                con.Ifok = ddlIfok.SelectedValue;
            }
            if (!string.IsNullOrEmpty(ddlIfsingle.SelectedValue))
            {
                con.Ifsingle = ddlIfsingle.SelectedValue;
            }

            if (!string.IsNullOrEmpty(ddlAppKeyID.SelectedValue))
            {
                con.AppName = ddlAppKeyID.SelectedValue;
            }
            if (!string.IsNullOrEmpty(ddlAccount.SelectedValue))
            {
                con.setName = ddlAccount.SelectedValue;
            }
           
            con.goodstype = ddlgoodstype.SelectedValue;
           
            
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

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            int total = 0;
            Model.TljInfoCondition con = condition();
            var list = bllTljInfo.GetList(1, int.MaxValue, ref total, con, p => p.ID, false);

            var excelList = new List<Model.TljXls>();

            foreach (var i in list)
            {
                excelList.Add(new Model.TljXls
                {
                    goodsname = i.goodsname,
                    item_id = i.item_id,
                    name = i.name,
                    total_num = i.total_num,
                    per_face = i.per_face,
                    user_total_win_num_limit = i.user_total_win_num_limit,
                    commission_bili = i.commission_bili,
                    goodstype = i.goodstype,
                    quanPrice = i.quanPrice,
                    send_start_time = i.send_start_time,
                    send_end_time = i.send_end_time,
                    use_end_time = i.use_end_time,
                    ifok = i.ifok,
                    kouling = i.kouling,
                    ifget = (i.ifget!=null&&i.ifget.Value==true)?"是":"否",
                    gettime = i.gettime,                    
                    
                    win_amount = i.win_amount,

                    win_num = i.win_num,
                    alipay_amount = i.alipay_amount,
                    pre_commission_amount = i.pre_commission_amount,
                    use_amount = i.use_amount,
                    use_num = i.use_num,
                    refund_amount = i.refund_amount,
                    refund_num = i.refund_num,
                    unfreeze_num = i.unfreeze_num,
                    unfreeze_amount = i.unfreeze_amount,
                    remark = i.remark,
                    zctime = i.zctime,
                    
                    yjyl = Math.Round((((i.PayMoney.HasValue ? i.PayMoney.Value : 0.00m)
                    * (i.commission_bili.HasValue ? i.commission_bili.Value : 0.00m) / 100)
                    * 0.88m - (i.per_face.HasValue ? i.per_face.Value : 0.00m)), 2, MidpointRounding.AwayFromZero)

                });
            }

            string fileName = string.Format("转换记录_{0}.xls", DateTime.Now.ToString("yyyy-MM-dd"));
            ExcelHelp<Model.TljXls> excelH = new ExcelHelp<Model.TljXls>();
            Hashtable ht = new Hashtable();
            
            ht.Add("goodsname", "商品名称");
            ht.Add("item_id", "商品ID");
            ht.Add("name", "淘礼金名称");
            ht.Add("total_num", "发放个数");
            ht.Add("per_face", "单个金额");
            ht.Add("user_total_win_num_limit", "限领个数");
            ht.Add("commission_bili", "佣金比例");
            ht.Add("goodstype", "产品类型");
            ht.Add("quanPrice", "优惠券金额");
            ht.Add("send_start_time", "开始时间");
            ht.Add("send_end_time", "结束时间");
            ht.Add("ifok", "状态");
            ht.Add("kouling", "口令");
            ht.Add("ifget", "是否已领取");
            ht.Add("gettime", "领取时间");
            ht.Add("win_amount", "红包领取金额");
            ht.Add("win_num", "红包领取个数");
            ht.Add("alipay_amount", "引导成交金额");
            ht.Add("pre_commission_amount", "预估佣金金额");
            ht.Add("use_amount", "红包核销金额");
            ht.Add("use_num", "红包核销个数");
            ht.Add("refund_amount", "失效回退金额");
            ht.Add("refund_num", "失效回退个数");
            ht.Add("unfreeze_num", "解冻红包个数");
            ht.Add("unfreeze_amount", "解冻金额");
            ht.Add("remark", "备注");
            ht.Add("zctime", "添加时间");
            ht.Add("yjyl", "盈利");
            
           

            excelH.getExcel(excelList, ht, fileName);
        }
        
        
    }
}
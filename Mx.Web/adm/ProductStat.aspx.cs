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
    public partial class ProductStat : AdminPage
    {
        private BLL.Orders bllOrders = new BLL.Orders();
        private BLL.appkey bllappkey = new BLL.appkey();
        static List<Orders> listAll;
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckAuth(new string[] { Codes.AdminRole.管理员 });
            if (!IsPostBack)
            {
                ddlDataBind();
                txtDateStart.Text = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
                txtDateEnd.Text = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
                DataInfoBind();
            }
        }


        protected void DataInfoBind()
        {
            ShowPager.PageSize = PageSize;
            int total = 0;
            Model.OrdersCondition con = condition();
            var iEnumerale = bllOrders.GetList(1, int.MaxValue, ref total, con, p => p.ID, false)
                .GroupBy(m => new
                {
                    m.ProductID,
                    m.ProductName,
                    m.OwnedShop,
                    m.pic
                }).Select(m => new
                {
                    ProductID = m.Key.ProductID,
                    ProductName = m.Key.ProductName,
                    OwnedShop = m.Key.OwnedShop,
                    pic = m.Key.pic,
                    totalLijin = m.Sum(p => p.lijin.HasValue ? p.lijin.Value : 0.00m),
                    totalRealshouru = m.Sum(p => p.realshouru.HasValue ? p.realshouru.Value : 0.00m),
                    totalEffect = m.Sum(p => p.Effect.HasValue ? p.Effect.Value : 0.00m),
                    totalValidEffect = m.Where(p => p.OrderStatus == "订单付款" || p.OrderStatus == "订单结算").Sum(p => p.Effect.HasValue ? p.Effect.Value : 0.00m),
                    totalOrderNums = m.Count(),
                    totalValidOrderNums = m.Where(p => p.OrderStatus == "订单付款" || p.OrderStatus == "订单结算").Count(),
                    totalReturnOrderNums = m.Where(p => p.OrderStatus == "订单失效").Count(),
                    adverLijin = m.Where(p => p.OrderStatus == "订单付款" || p.OrderStatus == "订单结算").Count() > 0 ?
                    Convert.ToDecimal(Math.Round(m.Sum(p => p.lijin.HasValue ? p.lijin.Value : 0.00m) / (m.Where(p => p.OrderStatus == "订单付款" || p.OrderStatus == "订单结算").Count()),    2,MidpointRounding.AwayFromZero)) : 0.00m                    
                }).OrderByDescending(m => m.totalEffect);

            var list = iEnumerale.Skip((ShowPager.CurrentPageIndex - 1) * ShowPager.PageSize).Take(ShowPager.PageSize).ToList();
            total = iEnumerale.Count();
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
                ListItem li = new ListItem(item.AppName, item.AdzoneId);
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



        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            DataInfoBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataInfoBind();
        }

        protected Model.OrdersCondition condition()
        {
            Model.OrdersCondition con = new Model.OrdersCondition
            {
                KeyWords = this.txtKeyWords.Text.Trim()
            };

            con.dateTime = ddlDateTime.SelectedValue;
            if (!string.IsNullOrEmpty(txtDateStart.Text))
            {
                con.startTime = DateTime.Parse(txtDateStart.Text);
            }
            if (!string.IsNullOrEmpty(txtDateEnd.Text))
            {
                con.endTime = DateTime.Parse(txtDateEnd.Text);
            }
            
            if (!string.IsNullOrEmpty(ddlAppKeyID.SelectedValue))
            {
                con.AdId = ddlAppKeyID.SelectedValue;
            }
            if (!string.IsNullOrEmpty(ddlAccount.SelectedValue))
            {
                con.setName = ddlAccount.SelectedValue;
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



        protected void btnExcel_Click(object sender, EventArgs e)
        {
            int total = 0;
            Model.OrdersCondition con = condition();
            var listAll = bllOrders.GetList(1, int.MaxValue, ref total, con, p => p.ID, false)
               .GroupBy(m => new
               {
                   m.ProductID,
                   m.ProductName,
                   m.OwnedShop,
                   m.pic
               }).Select(m => new
               {
                   ProductID = m.Key.ProductID,
                   ProductName = m.Key.ProductName,
                   OwnedShop = m.Key.OwnedShop,
                   pic = m.Key.pic,
                   totalLijin = m.Sum(p => p.lijin.HasValue ? p.lijin.Value : 0.00m),
                   totalRealshouru = m.Sum(p => p.realshouru.HasValue ? p.realshouru.Value : 0.00m),
                   totalEffect = m.Sum(p => p.Effect.HasValue ? p.Effect.Value : 0.00m),
                   totalValidEffect = m.Where(p => p.OrderStatus == "订单付款" || p.OrderStatus == "订单结算").Sum(p => p.Effect.HasValue ? p.Effect.Value : 0.00m),
                   totalOrderNums = m.Count(),
                   totalValidOrderNums = m.Where(p => p.OrderStatus == "订单付款" || p.OrderStatus == "订单结算").Count(),
                   totalReturnOrderNums = m.Where(p => p.OrderStatus == "订单失效").Count(),
                   adverLijin = m.Where(p => p.OrderStatus == "订单付款" || p.OrderStatus == "订单结算").Count() > 0 ?
                    Convert.ToDecimal(Math.Round(m.Sum(p => p.lijin.HasValue ? p.lijin.Value : 0.00m) / (m.Where(p => p.OrderStatus == "订单付款" || p.OrderStatus == "订单结算").Count()), 2, MidpointRounding.AwayFromZero)) : 0.00m
               }).OrderByDescending(m => m.totalEffect);


            var excelList = new List<Model.ProductStatXls>();

            foreach (var i in listAll)
            {
                excelList.Add(new Model.ProductStatXls
                {
                    ProductName = i.ProductName,
                    ProductID = i.ProductID,
                    OwnedShop = i.OwnedShop,                    
                    totalEffect = i.totalEffect,
                    totalValidEffect = i.totalValidEffect,
                    totalLijin = i.totalLijin,
                    adverLijin = i.adverLijin,
                    totalRealshouru = i.totalRealshouru,
                    totalOrderNums = i.totalOrderNums,
                    totalValidOrderNums = i.totalValidOrderNums,
                    totalReturnOrderNums = i.totalReturnOrderNums
                });
            }

            string fileName = string.Format("产品排行_{0}.xls", DateTime.Now.ToString("yyyy-MM-dd"));
            ExcelHelp<Model.ProductStatXls> excelH = new ExcelHelp<Model.ProductStatXls>();
            Hashtable ht = new Hashtable();

            ht.Add("ProductName", "商品名称");
            ht.Add("ProductID", "商品ID");
            ht.Add("OwnedShop", "店铺名");
            ht.Add("totalEffect", "全部佣金");
            ht.Add("totalValidEffect", "有效佣金");
            ht.Add("totalLijin", "合计礼金");
            ht.Add("adverLijin", "平均礼金"); 
            ht.Add("totalRealshouru", "实际收益");
            ht.Add("totalOrderNums", "全部订单");
            ht.Add("totalValidOrderNums", "有效订单");
            ht.Add("totalReturnOrderNums", "退款订单");           

            excelH.getExcel(excelList, ht, fileName);
        }


    }
}
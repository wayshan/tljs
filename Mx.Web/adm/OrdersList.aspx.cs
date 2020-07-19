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
    public partial class OrdersList : AdminPage
    {
        protected decimal totalyj = 0.00m;
        protected decimal totalyjds = 0.00m;
        protected decimal totallijin = 0.00m;
        protected decimal totalrealshouru = 0.00m;
        protected decimal totalmd_amount = 0.00m;
        protected int totalmd_count = 0;

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
            var list = bllOrders.GetList(ShowPager.CurrentPageIndex, ShowPager.PageSize, ref total, con, p => p.ID, false);

            ShowPager.RecordCount = total;
            this.rpData.DataSource = list;
            this.rpData.DataBind();


            listAll = bllOrders.GetList(1, int.MaxValue, ref total, con, p => p.ID, false);
            totalyj = listAll.Sum(m => m.Effect.HasValue ? m.Effect.Value : 0.00m);
            totalyjds = listAll.Sum(m => m.Effect.HasValue ? Math.Round(m.Effect.Value * 0.84m, 2) : 0.00m);
            totallijin = listAll.Sum(m => m.lijin.HasValue ? m.lijin.Value : 0.00m);
            totalrealshouru = listAll.Sum(m => m.realshouru.HasValue ? m.realshouru.Value : 0.00m);
            totalmd_amount = listAll.Where(p => p.realshouru < 0).Sum(m => m.realshouru.HasValue ? m.realshouru.Value : 0.00m);
            totalmd_count = listAll.Where(p => p.realshouru < 0).Count();
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
                ListItem li = new ListItem(item.AppName, item.AdzoneId.ToString());
                ddlAppKeyID.Items.Add(li);
                
            }

            var listAccount = appkeyList.GroupBy(m => new { m.TbAccount }).Select(m => m.Key).ToList();
            foreach (var item in listAccount)
            {
                ListItem li = new ListItem(item.TbAccount, item.TbAccount);
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

            if (!string.IsNullOrEmpty(ddlOrderStatus.SelectedValue))
            {
                con.orderStatus = ddlOrderStatus.SelectedValue;
            }
            if (!string.IsNullOrEmpty(ddlAppKeyID.SelectedValue))
            {
                con.AdId = ddlAppKeyID.SelectedValue;
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

            var excelList = new List<Model.OrderXls>();

            foreach (var i in listAll)
            {
                excelList.Add(new Model.OrderXls
                {
                    ProductName = i.ProductName,
                    ProductID = i.ProductID,
                    CreateTime = i.CreateTime,
                    SettlementTime = i.SettlementTime,
                    PayMoney = i.PayMoney,
                    OrderStatus = i.OrderStatus,
                    CommissionRate = i.CommissionRate,
                    Effect = i.Effect,
                    lijin = i.lijin,
                    realshouru =i.realshouru,
                    AdName = i.AdName                   
                });
            }

            string fileName = string.Format("订单明细_{0}.xls", DateTime.Now.ToString("yyyy-MM-dd"));
            ExcelHelp<Model.OrderXls> excelH = new ExcelHelp<Model.OrderXls>();
            Hashtable ht = new Hashtable();

            ht.Add("ProductName", "商品名称");
            ht.Add("ProductID", "商品ID");
            ht.Add("CreateTime", "创建时间");
            ht.Add("SettlementTime", "结算时间");
            ht.Add("PayMoney", "付款金额");
            ht.Add("OrderStatus", "订单状态");
            ht.Add("CommissionRate", "提成比例");
            ht.Add("Effect", "预估佣金");
            ht.Add("lijin", "礼金");
            ht.Add("realshouru", "实际收益");
            ht.Add("AdName", "推广位");

            excelH.getExcel(excelList, ht, fileName);
        }
        
        
    }
}
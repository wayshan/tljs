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
    public partial class TljStat : AdminPage
    {
        private BLL.Orders bllOrder = new BLL.Orders();
        protected string statData = "";
        protected string xAxis_arr;
        protected string yj_arr;
        protected string yjds_arr;
        protected string use_amount_arr;
        protected string md_amount_arr;
        protected string ykresult_arr;
        protected decimal totalyj = 0.00m;
        protected decimal totalyjds = 0.00m;
        protected decimal totaluse_amount = 0.00m;
        protected decimal totalykresult = 0.00m;
        protected decimal totalmd_amount = 0.00m;
        protected int totalmd_count = 0;

        static List<TljStatXls>  listRes = new List<TljStatXls>();

        BLL.appkey bllappkey = new BLL.appkey();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlDataBind();
                txtDateTimeNow.Value = DateTime.Now.ToString("yyyy-MM-dd");
                txtDateStart.Text = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
                txtDateEnd.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                getData();
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
                ListItem li = new ListItem(item.AppName, item.AdzoneId); 
                ddlAppKeyID.Items.Add(li);
            }

            var listAccount = appkeyList.GroupBy(m => new { m.TbAccount }).Select(m => m.Key).ToList();
            foreach (var item in listAccount)
            {
                ListItem li = new ListItem(item.TbAccount, item.TbAccount);
                ddlAccount.Items.Add(li);
            }
        }


        protected void getData()
        {
            listRes.Clear();
            DateTime dtNow = new DateTime();
            if (!string.IsNullOrEmpty(txtDateStart.Text) && !string.IsNullOrEmpty(txtDateEnd.Text))
            {
                DateTime dtStart = DateTime.Parse(txtDateStart.Text);
                DateTime dtEnd = DateTime.Parse(txtDateEnd.Text);
                for (DateTime dt = dtStart; dt <= dtEnd; dt = dt.AddDays(1))
                {
                    listRes.Add(new TljStatXls { 
                        dotime = dt.ToString("yyyy-MM-dd"),
                        yj = 0.00m,
                        yjds = 0.00m,
                        use_amount = 0.00m,
                        ykresult = 0.00m,
                        md_amount = 0.00m,
                        md_count = 0
                    });
                }

                int total = 0;
                Model.OrdersCondition con = condition();
                var list = bllOrder.GetList(1, int.MaxValue, ref total, con, m => m.CreateTime)
                    .GroupBy(m => new
                    {
                        dotime = m.CreateTime.Value.ToString("yyyy-MM-dd")
                    })
                    .Select(m => new
                    {
                        yj = m.Sum(p => p.Effect.HasValue ? p.Effect.Value : 0.00m),
                        yjds = m.Sum(p => p.Effect.HasValue ? Math.Round(p.Effect.Value * 0.84m, 2) : 0.00m),
                        use_amount = m.Sum(p => p.lijin.HasValue ? p.lijin.Value : 0.00m),
                        ykresult = m.Sum(p => p.realshouru.HasValue ? p.realshouru.Value : 0.00m),
                        md_amount = m.Where(p=>p.realshouru<0).Sum(p=>p.realshouru.HasValue ? p.realshouru.Value : 0.00m),
                        md_count = m.Where(p=>p.realshouru<0).Count(),
                        dotime = m.Key.dotime
                    });

                listRes.ForEach(m =>
                {
                    foreach (var item in list)
                    {
                        if (item.dotime == m.dotime)
                        {
                            m.yj = item.yj;
                            m.yjds = item.yjds;
                            m.use_amount = item.use_amount;
                            m.ykresult = item.ykresult;
                            m.md_amount = item.md_amount;
                            m.md_count = item.md_count;
                        }
                    }
                });


                xAxis_arr = Newtonsoft.Json.JsonConvert.SerializeObject(listRes.Select(m => m.dotime).ToArray());
                yj_arr = Newtonsoft.Json.JsonConvert.SerializeObject(listRes.Select(m => m.yj).ToArray());
                yjds_arr = Newtonsoft.Json.JsonConvert.SerializeObject(listRes.Select(m => m.yjds).ToArray());
                use_amount_arr = Newtonsoft.Json.JsonConvert.SerializeObject(listRes.Select(m => m.use_amount).ToArray());
                md_amount_arr = Newtonsoft.Json.JsonConvert.SerializeObject(listRes.Select(m => m.md_amount).ToArray());                
                ykresult_arr = Newtonsoft.Json.JsonConvert.SerializeObject(listRes.Select(m => m.ykresult).ToArray());

                totalyj = list.Sum(m=>m.yj);
                totalyjds = list.Sum(m => m.yjds);
                totaluse_amount = list.Sum(m => m.use_amount);
                totalykresult = list.Sum(m => m.ykresult);
                totalmd_amount = list.Sum(m=>m.md_amount);
                totalmd_count = list.Sum(m => m.md_count);
            }
            

        }
        protected Model.OrdersCondition condition()
        {
            Model.OrdersCondition con = new Model.OrdersCondition();
            con.isstat = true;
            if (!string.IsNullOrEmpty(txtDateStart.Text))
            {
                con.statStartTime = DateTime.Parse(txtDateStart.Text);
            }
            if (!string.IsNullOrEmpty(txtDateEnd.Text))
            {
                con.statEndTime = DateTime.Parse(txtDateEnd.Text).AddDays(1);
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


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            getData();
        }


        protected void btnExcel_Click(object sender, EventArgs e)
        {
            if (listRes.Count == 0)
            {               
                PageFunc.AjaxAlert(this.Page, "数据为空，请先统计查询！");
            }
            else
            {               
                DateTime dtStart = DateTime.Parse(txtDateStart.Text);
                DateTime dtEnd = DateTime.Parse(txtDateEnd.Text);
                string fileName = string.Format("{0}-{1}_{2}_{3}_{4}.xls",
                    dtStart.ToString("yyyy-MM-dd"),
                    dtEnd.ToString("yyyy-MM-dd"),
                    string.IsNullOrEmpty( ddlAccount.SelectedValue)?"全部帐号":ddlAccount.SelectedValue,
                    string.IsNullOrEmpty(ddlAccount.SelectedValue) ? "全部推广位" : ddlAppKeyID.SelectedItem.Text,
                    DateTime.Now.ToString("yyyy-MM-dd"));
                ExcelHelp<Model.TljStatXls> excelH = new ExcelHelp<Model.TljStatXls>();
                Hashtable ht = new Hashtable();

                ht.Add("dotime", "日期");
                ht.Add("yj", "预估佣金");
                ht.Add("yjds", "预估到手佣金");
                ht.Add("use_amount", "淘礼金支出");
                ht.Add("md_amount","免单金额");
                ht.Add("ykresult", "盈亏情况");
                ht.Add("md_count", "免单数量");

                excelH.getExcel(listRes, ht, fileName);
            }
        }


    }



}
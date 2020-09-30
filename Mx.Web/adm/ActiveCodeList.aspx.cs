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
    public partial class ActiveCodeList : AdminPage
    {
        private string strQunmanageUrl = ConfigHelper.GetConfigString("qunmanageUrl");
        private BLL.TljInfo bllTljInfo = new BLL.TljInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckAuth(new string[] { Codes.AdminRole.管理员 });
            if (!IsPostBack)
            {              
                DataInfoBind();
            }
        }


        protected void DataInfoBind()
        {            
            int total = 0;
            TljInfoCondition cond = condition();
            var list = bllTljInfo.GetList(1, int.MaxValue, ref total, cond, t => t.ID)
                .GroupBy(m => new
                {
                    m.ActiveCode,
                    m.item_id,
                    m.goodsname,
                    m.item_pic
                }).Select(m =>  
                new ModelActCode
                {
                    ActiveCode = m.Key.ActiveCode,
                    goodsname = m.Key.goodsname,
                    item_id = m.Key.item_id,
                    item_pic = m.Key.item_pic,
                    count = m.Count()                  
                }).ToList();

            foreach (var item in list)
            { 
                item.Link = string.Format("{0}/mdtishi.aspx?qid=｛待补充群号｝&hdcode={1}", strQunmanageUrl,item.ActiveCode);
                item.qunLink = string.Format("{0}/adm/GroupActList.aspx?json={1}", strQunmanageUrl, Server.UrlEncode(Newtonsoft.Json.JsonConvert.SerializeObject(item)));
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

        protected TljInfoCondition condition()
        {
            DateTime dtNow = DateTime.Now;
            DateTime dtToday = DateTime.Parse(dtNow.ToShortDateString());
            TljInfoCondition con = new TljInfoCondition
            {
                ifget = false,
                Ifok = "已生成",
                statStartTime = dtToday
            };                                      
            return con;
        }
    }
}
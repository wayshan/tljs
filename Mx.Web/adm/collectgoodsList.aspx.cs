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
    public partial class collectgoodsList : AdminPage
    {
        private BLL.collectgoods bllcollectgoods = new BLL.collectgoods(); 
        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!IsPostBack)
            {
                CheckAuth(new string[] { Codes.AdminRole.管理员 });
                DataInfoBind();
            }
        }


        protected void DataInfoBind()
        {
            ShowPager.PageSize = PageSize;
            int total = 0;
            Model.collectgoodsCondition con = condition();
            var list = bllcollectgoods.GetList(ShowPager.CurrentPageIndex, ShowPager.PageSize, ref total, con, p => p.id, false);
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

        protected Model.collectgoodsCondition condition()
        {
            Model.collectgoodsCondition con = new Model.collectgoodsCondition
            {
                goodsname = this.txtgoodsname.Text.Trim(),
                shopname = this.txtshopname.Text.Trim(),
                qudao = this.txtqudao.Text.Trim()
            };
            if (!string.IsNullOrEmpty(ddlifok.SelectedValue))
            {
                con.ifok = ddlifok.SelectedValue;
            }
            if (!string.IsNullOrEmpty(ddltotalNum.SelectedValue))
            {
                con.totalNum = ddltotalNum.SelectedValue;
            }
            if (!string.IsNullOrEmpty(ddlType.SelectedValue))
            {
                con.type = ddlType.SelectedValue;
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
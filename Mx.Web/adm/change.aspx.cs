using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mx.Common;


namespace Mx.Web.adm
{
    public partial class change : AdminPage
    {
        Model.TljInfo modelTljInfo = new Model.TljInfo();
        BLL.TljInfo bllTljInfo = new BLL.TljInfo();
        BLL.appkey bllappkey = new BLL.appkey();
        public static string xianshi = "";
        public string initJs = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["gid"] != null && Request.QueryString["lj"] != null)
                {
                    goods_link.Text = Request.QueryString["gid"];
                    txtquan_link.Text = Request.QueryString["ql"];


                    initJs += "$('.getGoodsInfo').click();";



                }





                if (Request.QueryString["zhuangtai"] != null)
                {
                    if (Request.QueryString["zhuangtai"] == "false") xianshi = "style='display:none;'";
                    else xianshi = "";
                }
                else
                {
                    xianshi = "";
                }

              
                ddlDataBind();
             
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







    }

}
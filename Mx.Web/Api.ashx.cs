using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Mx.Web.BaseClass;
using System.Data;
using System.Configuration;
using Mx.Common;

namespace Mx.Web
{
    /// <summary>
    /// Api 的摘要说明
    /// </summary>
    public class Api : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            ApiResult result = new ApiResult();
            try
            {
                string action = GetRequest(context, "act").ToLower();
                switch (action)
                {
                    case "getplans":
                        result = GetPlans(context);
                        break;
                    //添加高佣金计划
                    case "upplans":
                        result = UpPlans(context);
                        break;
                    //更新帐号
                    case "updatezh":
                        result = UpdateZh(context);
                        break;

                }
            }
            catch
            {
                result.message = "缺少参数或参数有误";
                result.success = false;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
            context.Response.End();
        }

        /// <summary>
        /// 获取高佣计划
        /// Api.ashx?act=getplans&dt=1590940800
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        private ApiResult GetPlans(HttpContext con)
        {
            BLL.plans bllplans = new BLL.plans();
            ApiResult res = new ApiResult();
            try
            {
                string strDt = GetRequest(con, "dt");
                DateTime dt = DateTimeHelper.GetTime(strDt);

                int total = 0;
                List<Model.plansInfo> listRes = new List<Model.plansInfo>();
                var list = bllplans.GetList(1, int.MaxValue, ref total, m => m.zctime >= dt, m => m.id, false);

                foreach (var item in list)
                {
                    listRes.Add(new Model.plansInfo
                    {
                        id = item.id,
                        item_id = item.item_id,
                        goodsname = item.item_id,
                        shopname = item.shopname,
                        PayMoney = item.PayMoney,
                        planname = item.planname,
                        planlink = item.planlink,
                        campaignId = item.campaignId,
                        userNumberId = item.userNumberId,
                        shopkeeperId = item.shopkeeperId,
                        zctime = item.zctime,
                        zhanghaos_ok = item.zhanghaos_ok,
                        ifok = item.ifok,
                        coupon_url = item.coupon_url,
                        coupon_price = item.coupon_price,
                        commission_dx = item.commission_dx,
                        commission_MKT = item.commission_MKT,
                        pic = item.pic,
                        intro = item.intro,
                        tdRatio = item.tdRatio,
                        tdCoupon = item.tdCoupon,
                        tdCouponPrice = item.tdCouponPrice,
                        detectionTime = item.detectionTime

                    });
                }

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(listRes);
                res.message = json;
                res.success = true;
            }
            catch (Exception e)
            {
                res.success = false;
                res.message = "添加失败" + e.Message;
            }

            return res;
        }


        /// <summary>
        /// 添加高佣金计划
        /// Api.ashx?act=upplans&json={"item_id":"12345","goodsname":"产品名","shopname":"店铺名","PayMoney":50.2,"planname":"playName","planlink":"playLink","campaignId":"23","userNumberId":"232","shopkeeperId":"12321","zctime":"2020-07-07T17:28:21.1393121+08:00","zhanghaos":"a","ifok":"有效"}
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        private ApiResult UpPlans(HttpContext con)
        {
            BLL.plans bllplans = new BLL.plans();
            ApiResult res = new ApiResult();
            try
            {
                string strJsonInfo = GetRequest(con, "json");
                //strJsonInfo = "{\"item_id\":\"12345\",\"goodsname\":\"产品名\",\"shopname\":\"店铺名\",\"PayMoney\":50.2,\"planname\":\"playName\",\"planlink\":\"playLink\",\"campaignId\":\"23\",\"userNumberId\":\"232\",\"shopkeeperId\":\"12321\",\"zctime\":\"2020-07-07T17:28:21.1393121+08:00\",\"zhanghaos\":\"a\",\"ifok\":\"有效\"}";
                Model.plans model = new Model.plans();
                model = Newtonsoft.Json.JsonConvert.DeserializeObject<Model.plans>(strJsonInfo);
                bllplans.Add(model);

                res.message = "";
                res.success = true;
            }
            catch (Exception e)
            {
                res.success = false;
                res.message = "添加失败" + e.Message;
            }

            return res;

        }


        /// <summary>
        /// 修改帐号
        /// Api.ashx?act=updatezh&zh=b帐号&status=已申请&ids=114964887,115371546,115365386
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        private ApiResult UpdateZh(HttpContext con)
        {
            BLL.plans bllplans = new BLL.plans();
            DataSet ds = new DataSet();
            ApiResult res = new ApiResult();
            try
            {
                string ids = GetRequest(con, "ids");
                string zh = GetRequest(con, "zh");
                string status = GetRequest(con, "status");
                ids = "," + ids + ",";
                int total = 0;
                var list = bllplans.GetList(1, int.MaxValue, ref total, m => ids.Contains("," + m.campaignId + ","), m => m.id, false);

                foreach (var model in list)
                {
                    if (status == "已通过")
                    {
                       model.zhanghaos_ok += "#" + zh;
                       model.zhanghaos_ok = model.zhanghaos_ok.Trim('#') ;
                       List<string> tmplist = new List<string>();
                        if (!string.IsNullOrEmpty(model.zhanghaos_doing))
                       {
                           tmplist = new List<string>(model.zhanghaos_doing.Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries));
                       }
                       model.zhanghaos_doing = string.Join("#", tmplist.Where(i => i != zh));
                    }
                    else if (status == "已申请")
                    {
                        model.zhanghaos_doing += "#" + zh;
                        model.zhanghaos_doing = model.zhanghaos_doing.Trim('#');
                        List<string> tmplist = new List<string>();
                        if (!string.IsNullOrEmpty(model.zhanghaos_ok))
                        {
                            tmplist = new List<string>(model.zhanghaos_ok.Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries));
                        }
                        model.zhanghaos_ok = string.Join("#", tmplist.Where(i => i != zh));
                    }
                    else if (status == "作废")
                    {
                        model.ifok = "作废";
                    }
                    bllplans.Update(model);
                }

                res.message = "";
                res.success = true;
            }
            catch (Exception e)
            {
                res.success = false;
                res.message = "更新失败，" + e.Message;
            }

            return res;

        }



        /// <summary>
        /// 获取指定键值的参数值
        /// </summary>
        /// <param name="content"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetRequest(HttpContext content, string key, string defaultValue = "")
        {
            if (content.Request[key] != null)
            {
                return content.Request[key].ToString();
            }
            return defaultValue;
        }

        /// <summary>
        /// 获取指定键值的参数值
        /// </summary>
        /// <param name="content"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public int GetRequestInt(HttpContext content, string key, int defaultValue = 0)
        {
            if (content.Request[key] != null)
            {
                int.TryParse(content.Request[key].ToString(), out defaultValue);
            }
            return defaultValue;
        }

        /// <summary>
        /// 获取指定键值的参数值
        /// </summary>
        /// <param name="content"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public float GetRequestFloat(HttpContext content, string key, float defaultValue = 0)
        {
            if (content.Request[key] != null)
            {
                float.TryParse(content.Request[key].ToString(), out defaultValue);
            }
            return defaultValue;
        }

        /// <summary>
        /// 获取指定键值的参数值
        /// </summary>
        /// <param name="content"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public decimal GetRequestDecimal(HttpContext content, string key, decimal defaultValue = 0)
        {
            if (content.Request[key] != null)
            {
                decimal.TryParse(content.Request[key].ToString(), out defaultValue);
            }
            return defaultValue;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
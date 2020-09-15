using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Mx.Web.BaseClass;
using System.Data;
using System.Configuration;
using Mx.Common;
using System.Text;
using System.IO;
using Newtonsoft.Json.Linq;
using Mx.Model.Api;
using System.Data.Objects;

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
                string action = "";
                dynamic oJson = "";
                if (context.Request.HttpMethod == "POST")
                {
                    Stream s = context.Request.InputStream;
                    byte[] b = new byte[s.Length];
                    s.Read(b, 0, (int)s.Length);
                    string strJsonInfo = Encoding.UTF8.GetString(b);
                    //LogHelper.Debug(strJsonInfo, typeof(Api));
                    oJson = JObject.Parse(strJsonInfo);
                    action = oJson.Event.ToString().ToLower();
                }
                else if (context.Request.HttpMethod == "GET")
                {
                    action = GetRequest(context, "act").ToLower();
                }            
                switch (action)
                {
                    case "getplans":
                        result = GetPlans(context);
                        break;
                    //添加高佣金计划
                    case "upplans":
                        result = UpPlans(context);
                        break;
                    //处理链接内容
                    case "deallink":
                        result = DealLink(oJson);
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
                string strGetOk = GetRequest(con, "getok");
                string strDt = GetRequest(con, "dt");
                DateTime dt = DateTimeHelper.GetTime(strDt);

                int total = 0;
                List<Model.plansInfo> listRes = new List<Model.plansInfo>();

                List<Model.plans> list = new List<Model.plans>();
                if (string.IsNullOrEmpty(strGetOk))
                {
                    list = bllplans.GetList(1, int.MaxValue, ref total, m => m.zctime >= dt && m.ifok=="正常", m => m.id, false);
                }
                else
                {
                    list = bllplans.GetList(1, int.MaxValue, ref total, m => m.zctime >= dt && m.zhanghaos_ok!="" && m.ifok == "正常", m => m.lastOkTime, false);
                }                

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
                res.message = "操作失败" + e.Message;
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

        private ApiResult DealLink(dynamic json)
        {
            ApiResult res = new ApiResult();
            try
            {
                BLL.plans bllPlans = new BLL.plans();
                rootDto<Model.Api.message> dto = JsonConvert.DeserializeObject<rootDto<Model.Api.message>>(json.ToString());
                DateTime dtNow = DateTime.Now;
                DateTime dtToDay = DateTime.Parse(dtNow.ToString("yyyy-MM-dd"));
                string strMsg = dto.Data.msg;
                string[] strArr = strMsg.Split(new string[] { "http" }, StringSplitOptions.None);
                List<string> aLink = new List<string>();
                for (int i = 0; i < strArr.Length; i++)
                {
                    if (i == 0 && string.IsNullOrEmpty(strArr[0]))
                    {
                        continue;
                    }
                    string strItem = strArr[i];
                    int index =PageFunc.getIndex(strItem);
                    string strLink = string.Format("http{0}", strItem.Substring(0, index));
                    if (strLink.IndexOf("uland.taobao.com") != -1)
                    {

                    }
                    else if (strLink.IndexOf("detail.tmall.com") != -1)
                    {
                        string itemId = PageFunc.GetQueryString("id", strLink);
                        string strContent = HttpHelper.HttpGet("http://g5.vipdamai.net/hcapi.ashx?gid="+itemId);
                        hcRoot hc = JsonConvert.DeserializeObject<hcRoot>(strContent);
                        if (hc.error == "0")
                        {
                            if (hc.data != null)
                            {
                                
                                int total = 0;
                                var list = bllPlans.GetList(1, int.MaxValue, ref total, p => p.userNumberId == hc.data.seller_id && EntityFunctions.CreateDateTime(p.zctime.Value.Year, p.zctime.Value.Month, p.zctime.Value.Day, 0, 0, 0) == dtToDay, p => p.id);

                                if (total > 0)
                                {
                                    foreach (var item in list)
                                    {
                                        item.item_id = hc.data.num_iid;
                                        item.goodsname = hc.data.title;
                                        item.shopname = hc.data.shop_title;
                                        if (!string.IsNullOrEmpty(hc.data.coupon_info))
                                        {
                                            int tempIndex1 = hc.data.coupon_info.IndexOf("减");
                                            int tempIndex2 = hc.data.coupon_info.IndexOf("元");
                                            string couponPrice = hc.data.coupon_info.Substring(tempIndex1, tempIndex2 - tempIndex1);
                                            item.coupon_price = couponPrice;
                                            item.PayMoney = decimal.Parse(hc.data.zk_final_price) - decimal.Parse(couponPrice);
                                        }
                                        else
                                        {
                                            item.PayMoney = decimal.Parse(hc.data.zk_final_price);
                                        }
                                        bllPlans.Update(item);
                                    }
                                }
                                else
                                {
                                    var item = new Model.plans();
                                    item.item_id = itemId;
                                    item.goodsname = hc.data.title;
                                    item.shopname = hc.data.shop_title;
                                    item.pic = hc.data.pict_url;
                                    item.zctime = dtNow;
                                    item.coupon_url = hc.data.coupon_click_url;
                                    item.userNumberId = hc.data.seller_id;
                                    item.ifok = "待补充";
                                    bllPlans.Add(item);
                                }
                            }
                        }
                    }
                    else if (strLink.IndexOf("pub.alimama.com") != -1)
                    {
                        string userNumberId = PageFunc.GetQueryString("userNumberId", strLink);
                        
                        var model = bllPlans.GetModel(p=>p.userNumberId==userNumberId && EntityFunctions.CreateDateTime(p.zctime.Value.Year, p.zctime.Value.Month, p.zctime.Value.Day, 0, 0, 0) == dtToDay);
                        if (model != null)
                        {                           
                            model.planname = "默认计划名";                            
                            model.planlink = strLink;
                            model.ifok = "正常";
                            bllPlans.Add(model);
                        }
                        else
                        {
                            model = new Model.plans();
                            model.planname = "默认计划名";
                            model.userNumberId = userNumberId;
                            model.planlink = strLink;
                            model.zctime = dtNow;
                            model.ifok = "正常";
                            bllPlans.Add(model);
                        }
                    }
                }                

                res.message = "";
                res.success = true;
            }
            catch (Exception e)
            {
                res.success = false;
                res.message = "请求失败" + e.Message;
                LogHelper.Error(res.message, e);
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
                        model.zhanghaos_ok = model.zhanghaos_ok.Trim('#');
                        List<string> tmplist = new List<string>();
                        if (!string.IsNullOrEmpty(model.zhanghaos_doing))
                        {
                            tmplist = new List<string>(model.zhanghaos_doing.Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries));
                        }
                        model.zhanghaos_doing = string.Join("#", tmplist.Where(i => i != zh));
                        model.lastOkTime = DateTime.Now;
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
                res.message = "操作失败，" + e.Message;
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
            if (content.Request.HttpMethod == "POST")
            {
                return content.Request.Form[key].ToString();
            }
            else if (content.Request[key] != null)
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
            if (content.Request.HttpMethod == "POST")
            {
                int.TryParse(content.Request.Form[key].ToString(), out defaultValue);               
            }
            else if(content.Request[key] != null)
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
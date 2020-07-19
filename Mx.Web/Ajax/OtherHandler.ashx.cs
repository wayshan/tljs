using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mx.Common;
using System.Web.SessionState;
using System.IO;
using System.Text.RegularExpressions;

namespace Mx.Web.Ajax
{
    /// <summary>
    /// OtherHandler 的摘要说明
    /// </summary>
    public class OtherHandler : IHttpHandler, IRequiresSessionState
    {

        Model.appkey modelappkey = new Model.appkey();
        BLL.appkey bllappkey = new BLL.appkey();
        BLL.plans bllPlans = new BLL.plans();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string json = "";
            string act = context.Request["act"];
            OtherResult r;
            switch (act.ToLower())
            {
                case "getgoodsinfo":
                    r = GetGoodsInfo(context);
                    json = JsonHelper.JsonSerializer<OtherResult>(r);
                    break;

                case "upgettime":
                    r = UpGetTime(context);
                    json = JsonHelper.JsonSerializer<OtherResult>(r);
                    break;

                case "gettomdate":
                    object j = new
                    {
                        stime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd 00:00:00"),
                        etime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd 23:59:59")
                    };

                    json = JsonHelper.JsonSerializer(j);
                    break;
            }
            context.Response.Write(json);
            context.Response.End();
        }

        private OtherResult UpGetTime(HttpContext con)
        {
            OtherResult res = new OtherResult();
            if (con.Request["id"] == null)
            {
                res.IsSuccess = false;
                res.Message = "商品ID为必须参数";
            }
            DateTime dtNow = DateTime.Now;
            string id = con.Request["id"].ToString();
            BLL.TljInfo bllTljInfo = new BLL.TljInfo();
            Model.TljInfo ModelTljInfo = new Model.TljInfo();
            ModelTljInfo = bllTljInfo.GetModel(int.Parse(id));
            if (ModelTljInfo != null)
            {                
                ModelTljInfo.ifget = true;
                ModelTljInfo.gettime = dtNow;
            }
            bllTljInfo.Update(ModelTljInfo);

            object obj = new
            {
                ifget = "是",
                gettime = dtNow.ToString("yyyy-MM-dd HH:mm:ss")
            };

            res.IsSuccess = true;
            res.Message = JsonHelper.JsonSerializer<object>(obj);
            return res;
        }


        private OtherResult GetGoodsInfo(HttpContext con)
        {
            OtherResult res = new OtherResult();

            string siteid = "";
            string adzoneid = "";
            string setname = "";


            if (con.Request["id"] == null)
            {
                res.IsSuccess = false;
                res.Message = "商品ID为必须参数";
            }
            string activityid = "";


            if (con.Request["activityid"] != null)
            {
                activityid = con.Request["activityid"].ToString();
                if (activityid.IndexOf("activityId") > 0)
                {
                    activityid = activityid.Substring(activityid.IndexOf("activityId"));
                    if (activityid.IndexOf("&") > 0) activityid = activityid.Substring(0, activityid.IndexOf("&"));
                    activityid = "&" + activityid;
                }
                else
                {
                    activityid = "";
                }
            }

            if (con.Request["appkeyid"] != null)
            {
                string appkeyid = con.Request["appkeyid"].ToString();
                modelappkey = bllappkey.GetModel(int.Parse(appkeyid));




                //根据appkeyid 读取   三个基础参数
                siteid = modelappkey.SiteId;
                adzoneid = modelappkey.AdzoneId;
                setname = modelappkey.TbAccount;

            }
            string id = con.Request["id"].ToString();
            if (id.IndexOf("http") != -1)
            {
                string link = id;
                Regex reg = new Regex("id=(.+)&?");
                Match match = reg.Match(link);
                id = match.Groups[1].Value;
            }

            string strContent = HttpHelper.HttpGet("http://g5.vipdamai.net/ZhuanKouLin.aspx?moshi=jiance&keyword=https://detail.tmall.com/item.htm?id=" + id + "&siteid=" + siteid + "&adzoneid=" + adzoneid + "&setname=" + setname + activityid);
            strContent = strContent.TrimStart("\"".ToArray()).TrimEnd("\"".ToArray());
            string temp = "";
            temp += "<?xml version=\"1.0\" encoding=\"utf-16\"?>";
            temp += "<goodsinfo xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">";
            strContent = temp + strContent + "</goodsinfo>";

            var obj = XmlUtil.DeserializeXml<Model.goodsinfo>(strContent);

            int total = 0;
            DateTime zcTime = DateTime.Now.AddMonths(-1);
            var plansList = bllPlans.GetList(1, int.MaxValue, ref total, m => m.item_id == id && m.zctime >= zcTime, m => m.id);
            if (total > 0)
            {
                obj.campaignType = "DX";
            }
            else
            {
                obj.campaignType = "MKT";
            }
            res.IsSuccess = true;
            res.Message = JsonHelper.JsonSerializer<object>(obj);

            return res;
        }




        //private string AdIndex(HttpContext context)
        //{
        //    BLL.SpecialLog bllSpecialLog = new BLL.SpecialLog();
        //    BLL.MobileStatus bllMobileStatus = new BLL.MobileStatus();
        //    BLL.MobileStatusHis bllMobileStatusHis = new BLL.MobileStatusHis();
        //    Model.AdIndexInfo modelAdInfo = new Model.AdIndexInfo();

        //    //int iworkCount = 0;
        //    //int inotWorkCount = 0;
        //    //int iTotalCount = 0;

        //    int total = 0;
        //    var list = bllMobileStatus.GetList(1, int.MaxValue, ref total, new Model.MobileStatusCondition
        //    {
        //        Status = Model.MStatus.正常
        //    }, s => s.ID);

        //    modelAdInfo.workCount = list.Count;


        //    list = bllMobileStatus.GetList(1, int.MaxValue, ref total, new Model.MobileStatusCondition
        //    {
        //        Status = Model.MStatus.异常
        //    }, s => s.ID);
        //    modelAdInfo.notWorkCount = list.Count;


        //    list = bllMobileStatus.GetList(1, int.MaxValue, ref total, new Model.MobileStatusCondition
        //    {
        //    }, s => s.ID);
        //    modelAdInfo.totalMobileCount = list.Count;


        //    string path = HttpContext.Current.Server.MapPath("/zh");
        //    DirectoryInfo dirInfo = new DirectoryInfo(path);
        //    var file = dirInfo.GetFiles();
        //    modelAdInfo.totalSourceCount = file.Count();
        //    //FileSystemManager.SetRootPath(path);            
        //    //List<FileSystemItem> fileList = FileSystemManager.GetItems(path);            
        //    //modelAdInfo.totalSourceCount = fileList.Where(f=>f.IsFolder==false).Count();



        //    var logList = bllSpecialLog.GetList(1, 20, ref total, new Model.SpecialLogCondition { }
        //        , l => l.ID, false).Select(l => new Model.SpecialLogInfo
        //        {                    
        //            ID = l.ID,
        //            MType = l.MType,
        //            MNo = l.MNo,
        //            IMEI = l.IMEI,
        //            AddTime = l.AddTime.Value.ToString("yyyy-MM-dd HH:mm:ss"),
        //            Remarks = l.Remarks,
        //        }).ToList();

        //    modelAdInfo.loglist = logList;

        //    return JsonHelper.JsonSerializer<Model.AdIndexInfo>(modelAdInfo);
        //}



        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
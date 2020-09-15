using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mx.Model.Api
{
    public class hcRoot
    {
        /// <summary>
        /// 
        /// </summary>
        public string error { get; set; }
        /// <summary>
        /// 高佣转链成功！
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public hcData data { get; set; }
    }
    public class hcData
    {
        /// <summary>
        /// 
        /// </summary>
        public string category_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string coupon_click_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string coupon_end_time { get; set; }
        /// <summary>
        /// 满39元减5元
        /// </summary>
        public string coupon_info { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string coupon_remain_count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string coupon_start_time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string coupon_total_count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string max_commission_rate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string commission_rate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string num_iid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string zk_final_price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string white_image { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string volume { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string user_type { get; set; }
        /// <summary>
        /// 李子柒桂花坚果藕粉藕粉坚果羹营养早餐杭州特产代餐食品方便速食
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> small_images { get; set; }
        /// <summary>
        /// 李子柒旗舰店
        /// </summary>
        public string shop_title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string shop_dsr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string seller_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string reserve_price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string real_post_fee { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pict_url { get; set; }
        /// <summary>
        /// 李子柒旗舰店
        /// </summary>
        public string nick { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string item_url { get; set; }
        /// <summary>
        /// 咖啡/麦片/冲饮
        /// </summary>
        public string cat_name { get; set; }
        /// <summary>
        /// 藕粉
        /// </summary>
        public string cat_leaf_name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string tbk_pwd { get; set; }
        /// <summary>
        /// 0.0fu致内容￥shYCc4bZjqF￥转移至τao寶或點击链街 https://m.tb.cn/h.VC5a0tf 至浏.览览.器【李子柒桂花坚果藕粉藕粉坚果羹营养早餐杭州特产代餐食品方便速食】
        /// </summary>
        public string ios_tbk_pwd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string coupon_short_url { get; set; }
    }

   
}

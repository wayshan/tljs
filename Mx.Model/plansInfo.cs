using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mx.Model
{
    public class plansInfo
    {
        /// <summary>
        /// id
        /// </summary>	
        public int id { get; set; }
        /// <summary>
        /// 产品id
        /// </summary>	
        public string item_id { get; set; }
        /// <summary>
        /// 产品名
        /// </summary>	
        public string goodsname { get; set; }
        /// <summary>
        /// 店铺名
        /// </summary>	
        public string shopname { get; set; }
        /// <summary>
        /// 付款金额
        /// </summary>	
        public decimal? PayMoney { get; set; }
        /// <summary>
        /// planname
        /// </summary>	
        public string planname { get; set; }
        /// <summary>
        /// planlink
        /// </summary>	
        public string planlink { get; set; }
        /// <summary>
        /// campaignId
        /// </summary>	
        public string campaignId { get; set; }
        /// <summary>
        /// userNumberId
        /// </summary>	
        public string userNumberId { get; set; }
        /// <summary>
        /// shopkeeperId
        /// </summary>	
        public string shopkeeperId { get; set; }
        /// <summary>
        /// zctime
        /// </summary>	
        public DateTime? zctime { get; set; }
        /// <summary>
        /// 已通过申请
        /// </summary>	
        public string zhanghaos_ok { get; set; }
        /// <summary>
        /// 正在申请
        /// </summary>	
        public string zhanghaos_doing { get; set; }
        /// <summary>
        /// 申请拒绝
        /// </summary>	
        public string zhanghaos_refuse { get; set; }
        /// <summary>
        /// 正常/失效/
        /// </summary>	
        public string ifok { get; set; }
        /// <summary>
        /// 券地址
        /// </summary>	
        public string coupon_url { get; set; }
        /// <summary>
        /// 优惠券金额
        /// </summary>	
        public string coupon_price { get; set; }
        /// <summary>
        /// 定向佣金比例
        /// </summary>	
        public string commission_dx { get; set; }
        /// <summary>
        /// 营销佣金比例
        /// </summary>	
        public string commission_MKT { get; set; }
        /// <summary>
        /// pic
        /// </summary>	
        public string pic { get; set; }
        /// <summary>
        /// intro
        /// </summary>	
        public string intro { get; set; }
        /// <summary>
        /// tdRatio
        /// </summary>	
        public decimal? tdRatio { get; set; }
        /// <summary>
        /// tdCoupon
        /// </summary>	
        public string tdCoupon { get; set; }
        /// <summary>
        /// tdCouponPrice
        /// </summary>	
        public decimal? tdCouponPrice { get; set; }
        /// <summary>
        /// detectionTime
        /// </summary>	
        public string detectionTime { get; set; }   
    }
}

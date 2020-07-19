using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mx.Model
{
    public class TljXls
    {
        public string goodsname { get; set; }
        public string item_id { get; set; }
        public string name { get; set; }
        public int? total_num { get; set; }
        public decimal? per_face { get; set; }
        public int? user_total_win_num_limit { get; set; }
        public decimal? commission_bili { get; set; }
        public string goodstype { get; set; }
        public decimal? quanPrice { get; set; }
        public DateTime? send_start_time { get; set; }
        public DateTime? send_end_time { get; set; }
        public int? use_end_time { get; set; }
        public string ifok { get; set; }
        public string kouling { get; set; }
        public string ifget { get; set; }
        public DateTime? gettime { get; set; }

        //红包领取金额
        public decimal? win_amount { get; set; }
        //红包领取个数
        public int? win_num { get; set; }
        //引导成交金额
        public decimal? alipay_amount { get; set; }
        //预估佣金金额
        public decimal? pre_commission_amount { get; set; }
        //红包核销金额
        public decimal? use_amount { get; set; }
        //红包核销个数
        public int? use_num { get; set; }
        //失效回退金额
        public decimal? refund_amount { get; set; }
        //失效回退个数
        public int? refund_num { get; set; }
        //解冻红包个数
        public int? unfreeze_num { get; set; }
        //解冻金额
        public decimal? unfreeze_amount { get; set; }
        public string remark { get; set; }

        public DateTime? zctime { get; set; }

        public decimal? yjyl { get; set; }

        
        
    }
}

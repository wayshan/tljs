using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mx.Model
{
    public class OrderXls
    {
        public string ProductName { get; set; }
        public string ProductID { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? SettlementTime { get; set; }
        public decimal? PayMoney { get; set; }
        public string OrderStatus { get; set; }
        public decimal? CommissionRate { get; set; }
        public decimal? Effect { get; set; }
        public decimal? lijin { get; set; }
        public decimal? realshouru { get; set; }
        public string AdName { get; set; }
        public decimal md_amount { get; set; }
        public int md_count { get; set; }
            
    }
}

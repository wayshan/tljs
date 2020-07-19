using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mx.Model
{
    public class OrdersCondition
    {
        public string KeyWords { get; set; }
        public bool isstat { get; set; }
        public DateTime? statStartTime { get; set; }
        public DateTime? statEndTime { get; set; }
        public string adName { get; set; }
        public string AdId { get; set; }

        public string dateTime { get; set; }
        public DateTime? startTime { get; set; }
        public DateTime? endTime { get; set; }

        public string orderStatus { get; set; }
        
    }
}
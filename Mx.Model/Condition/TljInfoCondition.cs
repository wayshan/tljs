using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mx.Model
{
    public class TljInfoCondition
    {
        public string KeyWords { get; set; }

        public DateTime? startTime { get; set; }
        public DateTime? endTime { get; set; }

        public bool isstat { get; set; }
        public DateTime? statStartTime { get; set; }
        public DateTime? statEndTime { get; set; }


        public bool? ifget { get; set; }
        public string Ifok { get; set; }

        public string Ifsingle { get; set; }

        public string AppName { get; set; }
        public string setName { get; set; }

        public string goodstype { get; set; }
        
        
    }
}

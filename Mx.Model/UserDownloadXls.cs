using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mx.Model
{
    public class UserDownloadXls
    {
        public string MType { get; set; }
        public string MNo { get; set; }
        public string IMEI { get; set; }
        public string Remarks { get; set; }        
        public string FileName { get; set; }
        public DateTime? LastUpdateTime { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mx.Web.Ajax
{
    [Serializable]
    public class AjaxValidate
    {
        public AjaxValidate()
        {
            Msg = "程序出现异常,请联系管理员!";
            Result = 0;
        }
        public string Msg { get; set; }
        public int Result { get; set; }
    }
}
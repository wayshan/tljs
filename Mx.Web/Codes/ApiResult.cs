using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mx.Web.Codes
{
    public class ApiResult
    {
        public ApiResult()
        {
            success = false;
            message = "参数有误";
        }
         public ApiResult(bool _success, string _message = "")
        {
            success = _success;
            message = _message;
        }
        public bool success
        {
            get;
            set;
        }
        public string message
        {
            get;
            set;
        }
    }
}
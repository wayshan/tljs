using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mx.Web.Ajax
{
    public class OtherResult
    {
        public OtherResult()
        { 
        
        }
        public OtherResult(bool isSuccess, long statusID, string message)
        {
            IsSuccess = isSuccess;
            StatusID = statusID;
            Message = message;
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public long StatusID { get; set; }
    }
}
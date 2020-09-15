using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mx.Common
{
    public class LogHelper
    {
        public static string name = "DefaultLogger";
        static LogHelper()
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(
                new System.IO.FileInfo("log4net.config"));

            log = LogManager.GetLogger(name);
        }
        

        public static log4net.ILog log = null;

        public static void Info(string msg, Type type)
        {
            Info(string.Format("{0} - {1}", type.Name, msg));
        }

        public static void Info(string msg)
        {
            log.Info(msg);
        }

        public static void Error(string msg, Exception ex, Type type)
        {
            Error(string.Format("{0} - {1}", type.Name, msg), ex);
        }

        public static void Error(string msg, Exception ex)
        {
            log.Error(msg, ex);
        }

        public static void Debug(string msg, Type type)
        {
            Debug(string.Format("{0} - {1}", type.Name, msg));
        }

        public static void Debug(string msg)
        {
            log.Debug(msg);
        }
    }
}

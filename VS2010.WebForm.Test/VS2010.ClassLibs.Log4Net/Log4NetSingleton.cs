using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
namespace VS2010.ClassLibs.Log4Net
{
    public static class Log4NetSingleton
    {
        private static readonly ILog log = LogManager.GetLogger(typeof (Log4NetSingleton));

        public static void Debug(object message)
        {
            log.Debug(message);
        }
    }
}

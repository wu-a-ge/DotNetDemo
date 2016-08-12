using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace VS2010.Lib.Log4Net
{
    public static class Log4NetSingleton
    {
        public static ILog Log = LogManager.GetLogger(typeof(Log4NetSingleton));

        public static void Debug(object message)
        {
            //if(Log.IsDebugEnabled)
            Log.Debug(message);
        }
        public static void DebugFormat(string format, params object[] args)
        {
            //if (Log.IsDebugEnabled)
            Log.DebugFormat(format, args);
        }

        public static void Error(object message)
        {
            Log.Error(message);
        }
    }
}

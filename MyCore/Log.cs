using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCore
{
    public static class Log
    {
        private static Logger InfoLogManager = NLog.LogManager.GetLogger("InfoLoggerRule");
        private static Logger WarningLogManager = NLog.LogManager.GetLogger("WarningLoggerRule");
        private static Logger FatalLogManager = NLog.LogManager.GetLogger("FatalLoggerRule");

        public static void init()
        {
            InfoLogManager.Factory.Configuration = new NLog.Config.XmlLoggingConfiguration(ConfigurationManager.AppSettings["LogConfigFile"].ToString(), true);
        }
        public static void LogInfoLevel(string message)
        {
            init();
            InfoLogManager.Log(LogLevel.Info, message);
        }

        public static void LogWarningLevel(string message)
        {
            init();
            WarningLogManager.Log(LogLevel.Warn, message);
        }
        public static void LogFataloLevel(string message)
        {
            init();
            FatalLogManager.Log(LogLevel.Fatal, message);
        }

        public static string GetExException(Exception ex)
        {
            string strOut = string.Empty;

            try
            {
                //If the Message is not null or string empty the metod returns that one as a string
                if (!string.IsNullOrEmpty(ex.Message))
                    strOut = ex.Message.ToString();
                else
                    //If the Message is empty and the InnerException is not null or string empty the metod returns that one as a string
                if (!string.IsNullOrEmpty(ex.InnerException.Message))
                    strOut = ex.InnerException.Message;
            }
            catch { }

            return strOut;
        }



    }
}

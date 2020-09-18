using AngularLayout.Logger;
using log4net;
using System;

namespace AngularLayout.Model.Common.Loggers
{
    public static class AppLogger
    {
        private static readonly ILog _log;

        static AppLogger()
        {
            _log = LogMaster.GetLogger("AngularLayout_Log", Constants.AppSettings["Log_Default"]);
        }

        public static void Error(string message)
        {
            _log.Error(message);
        }

        public static void Error(string message, Exception e)
        {
            _log.Error(message, e);
        }

        public static void Info(string message)
        {
            _log.Info(message);
        }

        public static void Warn(string message)
        {
            _log.Warn(message);
        }
    }
}

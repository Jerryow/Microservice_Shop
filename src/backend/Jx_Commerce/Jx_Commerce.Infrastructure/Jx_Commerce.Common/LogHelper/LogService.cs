using log4net;
using log4net.Config;
using log4net.Core;
using log4net.Repository;
using System;
using System.IO;

namespace Jx_Commerce.Common.LogHelper
{
    public class LogService : ILogService
    {
        private static readonly ILoggerRepository loggerRepository = null;
        private static readonly ILog logInfo = null;
        private static readonly ILog logError = null;
        private static readonly ILog logDebug = null;
        private static readonly ILog logWarning = null;

        static LogService()
        {
            loggerRepository = LoggerManager.CreateRepository("CoreRepository");
            XmlConfigurator.Configure(loggerRepository, new FileInfo("log4net.config"));//此文件需要选择始终复制
            logInfo = LogManager.GetLogger("CoreRepository", "InfoLog");
            logError = LogManager.GetLogger("CoreRepository", "ErrorLog");
            logDebug = LogManager.GetLogger("CoreRepository", "DebugLog");
            logWarning = LogManager.GetLogger("CoreRepository", "WarningLog");
        }

        #region Info
        public void LogInfo(string msg)
        {
            string errorMsg = string.Format("【记录信息】：{0} \r\n", msg);
            logInfo.Info(errorMsg);
        }
        #endregion


        #region Error
        public void ErrorInfo(string msg, Exception ex)
        {
            string errorMsg = string.Format("【抛出信息】：{0} \r\n【异常类型】：{1} \r\n【异常信息】：{2} \r\n【堆栈调用】：{3}", new object[] { msg,
                ex.GetType().Name, ex.Message, ex.StackTrace });
            logError.Error(errorMsg);
        }

        #endregion


        #region Debug
        public void DebugInfo(string msg)
        {
            string errorMsg = string.Format("【记录信息】：{0} \r\n", msg);
            logDebug.Debug(errorMsg);
        }
        #endregion


        #region Warning
        public void WarningInfo(string msg)
        {
            string errorMsg = string.Format("【记录信息】：{0} \r\n", msg);
            logWarning.Warn(errorMsg);
        }
        #endregion
    }
}

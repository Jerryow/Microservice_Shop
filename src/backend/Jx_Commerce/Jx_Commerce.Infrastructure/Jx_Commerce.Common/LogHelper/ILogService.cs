using System;
using System.Collections.Generic;
using System.Text;

namespace Jx_Commerce.Common.LogHelper
{
    public interface ILogService
    {
        #region Info
        void LogInfo(string msg);
        #endregion

        #region Error
        void ErrorInfo(string msg, Exception ex);
        #endregion

        #region Debug
        void DebugInfo(string msg);
        #endregion

        #region Warning
        void WarningInfo(string msg);
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Service
{
    public class LoggingService
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();


        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogError(Exception ex)
        {
            logger.Error(ex, "An error occurred: {0}", ex.Message);
        }

        public void LogWarning(string message)
        {
            logger.Warn(message);
        }

        public void LogDebug(string message)
        {
            logger.Debug(message);
        }
    }
}

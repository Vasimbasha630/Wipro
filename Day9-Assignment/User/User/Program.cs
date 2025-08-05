using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new LoggingService();

            logger.LogInfo("Application started.");

            try
            {
                // Example to generate an error
                throw new InvalidOperationException("Demo exception");
            }
            catch (Exception ex)
            {
                logger.LogError(ex);
            }

            logger.LogInfo("Application ended.");
        }
    }
}

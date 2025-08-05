using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    
    public class LoggingServiceTests
    {
        [Test]
        public void Logging_Does_Not_Throw_Exception()
        {
            var logger = new LoggingService();
            Assert.DoesNotThrow(() => logger.LogInfo("Test info"));
        }
    }
}

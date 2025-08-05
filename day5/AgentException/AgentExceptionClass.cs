using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentException
{
    public class AgentExceptionClass : ApplicationException
    {
        public AgentExceptionClass() { }
        public AgentExceptionClass(string message) : base(message) { }

    }
}

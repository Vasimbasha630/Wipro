using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgentModel;
namespace AgentDao
{
    internal interface AgentDaoInterface
    {
        string AddAgent(Agent agent);
        List<Agent>ShowAgents();

        Agent SearchAgentDao(int id);

        string UpdateAgent(Agent agent);

        string DeleteAgent(int id);
        string WriteToFileDao();

        string ReadFormFileDao();

        
    }
}

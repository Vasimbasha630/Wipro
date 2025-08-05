using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgentException;
using AgentModel;
using AgentDao;

namespace AgentBal
{
    public class AgentBal
    {

        public StringBuilder sb = new StringBuilder();
        public static AgentImp agentImp;


        static AgentBal()
        {
            agentImp = new AgentImp();  
        }

        public List<Agent> ShowAgentBal()
        {
            return agentImp.ShowAgents();
        }

        public string WriteFileBal()
        {
            return agentImp.WriteToFileDao();
        }
        public string ReadFileBal()
        {
            return agentImp.ReadFormFileDao();
        }

        public string DeleteAgentBal(int id)
        {
            return agentImp.DeleteAgent(id);
        }
        public string UpdateAgentBal(Agent agent) 
        {
            if(ValidateAgent(agent) == true)
            {
               return agentImp.UpdateAgent(agent);

            }
            throw new AgentExceptionClass(sb.ToString()); 
            
        }

        public Agent SearchAgentBal(int id)
        {
           return agentImp.SearchAgentDao(id);
        }


        public string AddAgentBal(Agent a)
        {
            if(ValidateAgent(a) == true)
            {
                return agentImp.AddAgent(a);
            }
            throw new Exception(sb.ToString());
        }

        public bool ValidateAgent(Agent agent)
        {
            bool flag = true;
            if (agent.Id<=0)
            {
                sb.Append("Agent No Cannot be zero or Negative...");
                flag = false;
            }
            if(agent.FirstName.Length<5)
            {
                sb.Append("Basic Must be betwwen 10000 and 80000");
                flag = false;
            }
            if(agent.PremiumAmount<10000 || agent.PremiumAmount>80000)
            {
                flag = false;
            }
            return flag;
        }

        
    }
}
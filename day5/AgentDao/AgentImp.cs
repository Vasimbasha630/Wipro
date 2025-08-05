using AgentModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AgentDao
{
    public class AgentImp : AgentDaoInterface
    {
        static List<Agent> agentList;

        static AgentImp()
        {
            agentList = new List<Agent>();
        }

        public string AddAgent(Agent agent)
        {
            agentList.Add(agent);
            return "Agent Record Inserted";
        }

        public string DeleteAgent(int id)
        {
            Agent agentFound = SearchAgentDao(id);
            if (agentFound != null)
            {
                agentList.Remove(agentFound);
                return "Agent Record Delete Successfully";
            }
            return "Agent Record Not Found";
        }
        public string ReadFormFileDao()
        {
            FileStream fs = new FileStream(@"E:\FileHandling\def.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            agentList = (List<Agent>)binaryFormatter.Deserialize(fs);
            return "Data Retrived from the File Successfully";
        }

        public Agent SearchAgentDao(int id)
        {
            Agent a = null;
            foreach (Agent agent in agentList) 
            {
                if (agent.Id == id)
                {
                    {
                        a = agent;
                        break;
                    }
                }

            }
            return a;
        }
                

        public List<Agent>ShowAgents()
        {
            return agentList;
        }

        public string UpdateAgent(Agent a)
        {
            Agent agent = SearchAgentDao(a.Id);
            if (agent != null)
            {
                agent.FirstName = a.FirstName;
                agent.LastName = a.LastName;
                agent.City = a.City;
                agent.Gender = a.Gender;
                agent.PremiumAmount = a.PremiumAmount;
                return "Agenet Record updated";

            }
            return "Agent Record Not Found";
        }
        
        public string WriteToFileDao()
        {
            FileStream fs = new FileStream(@"E:\FileHandling\def.txt",FileMode.Create,FileAccess.Write);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fs, agentList);
            fs.Close();
            return "Data Stored in File Successfully..";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgentModel;
using AgentException;
using AgentDao;
using AgentBal;

namespace AgentMain1
{
    internal class Program
    {
        static AgentBal agentBal;
        static Program()
        {
            agentBal = new AgentBal();
        }

        public static void WriteFileBal()
        {
            Consloe.WriteLine(agentBal.WriteFileBal());
        }
        public static void ReadFileMain()
        {
            Console.WriteLine(agentBal.ReadFileBal());
        }
        public static void DeleteAgentMain()
        {
            int empno;
            Console.WriteLine("Enter Agent Number   ");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(agentBal.DeleteAgentBal(id));
        }


        static void Main(string[] args)
        {
        }
    }
}
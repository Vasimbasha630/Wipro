using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeligateExample1
{
    internal class MultiCastDelegate
    {
        public delegate void DotnetFsd();
        public static void Project()
        {
            Console.WriteLine("Capstone Project to be done Last Phase..");
        }

        public static void MileStone1()
        {
            Console.WriteLine("Milestone 1 to be Conducted on Core Topics...");
        }

        public static void MileStone2()
        {
            Console.WriteLine("Milestone 2 to be on dotnet Core....");
        }

        public static void MileStone3()
        {
            Console.WriteLine("Milestone 3 to be on Asp.net Core Web API");
        }

        public static void MileStone4()
        {
            Console.WriteLine("Milestone 4 to be on React FrameWork...");
        }

        static void Main()
        {
            DotnetFsd obj = new DotnetFsd(MileStone1);
            obj += MileStone2;
            obj += MileStone3;
            obj += MileStone4;
            obj += Project;

            obj();

        }
    }

}

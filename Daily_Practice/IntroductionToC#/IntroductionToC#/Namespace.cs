using IntroductionToC_.ProjectA.TeamA;
using IntroductionToC_.ProjectA.TeamB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToC_
{
    namespace ProjectA
    {
        namespace TeamA
        {
            class ClassA
            {
                public static void Print()
                {
                    Console.WriteLine("Team A Print Method");
                }
            }
        }
    }

    namespace ProjectA
    {
        namespace TeamB
        {
            class ClassA
            {
                public static void Print()
                {
                    Console.WriteLine("Team B Print Method");
                }
            }
        }
    }
    
    internal class Namespace
    {
        static void Main()
        {
            //full colified name 
            //otherwise you can use in the namespace part 
            ProjectA.TeamA.ClassA.Print();
            ProjectA.TeamB.ClassA.Print();
        }
    }
}

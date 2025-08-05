using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionEx
{
    internal class ReflectionExample1
    {
        static void Main()
        {
            Type typeObj = typeof(Test);
            Console.WriteLine("Methods Available in Test Class Are..");
            foreach (MethodInfo mi in typeObj.GetMethods())
            {
                Console.WriteLine(mi.Name);
            }
            Console.WriteLine("Varibales avaiable in the  class are");
            foreach(FieldInfo fi in typeObj.GetFields())
            {
                Console.WriteLine(fi.Name);
            }
        }
    }
}

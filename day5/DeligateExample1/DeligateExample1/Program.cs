using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeligateExample1
{
    internal class Program
    {
        public delegate void MyDelegate();

        public static void Show()
        {
            Console.WriteLine("Welcome to MyDelicate");
        }
        static void Main(string[] args)
        {
            //delegate_name obj = new delegate_name(methodName);
            MyDelegate obj = new MyDelegate(Show);
            obj();
            
        }
    }
}

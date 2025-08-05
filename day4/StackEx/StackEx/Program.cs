using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack s = new Stack();
            s.Push("Vasim");
            s.Push("Basha");
            s.Push("Owk");
            foreach (object o in s)
            {
                Console.WriteLine(o);
            }
            s.Pop();
            Console.WriteLine("Poping one element");
            foreach(object o in s)
            {
                Console.WriteLine(o);
            }
            s.Pop();
            s.Pop();
            Console.WriteLine("Poping two element");
            foreach (object o in s)
            {
                Console.WriteLine(o);
            }



        }
    }
}

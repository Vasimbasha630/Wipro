using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentDemo;

namespace StudentClinet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student();
            s.id =10;
            s.name = "Basha";
            s.salary = 100;
            Console.WriteLine(s.id);
            Console.Write(s.name);
            Console.WriteLine(s.salary);



        }
    }
}

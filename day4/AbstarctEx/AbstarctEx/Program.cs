using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstarctEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s = new Vasim();
            s.Name();
            s.Email();
            s.Course();
            //foreach(Student std in arryStudent)
            //{
            //    std.Name();
            //    std.Email();
            //    Console.WriteLine(std);
            //}
        }
    }
}

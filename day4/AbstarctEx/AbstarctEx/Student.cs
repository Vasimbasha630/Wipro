using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstarctEx
{
    internal abstract class Student
    {
        public void Course()
        {
            Console.WriteLine("The course is C# Do.net");
        }
        public abstract void Name();
        public abstract void Email();
    }
}

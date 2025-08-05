using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstarctEx
{
    internal class Vasim : Student
    {
        public override void Email()
        {
            Console.WriteLine("The email is owkbasha@gmail.com");
        }

        public override void Name()
        {
            Console.WriteLine("The Name is Basha");
        }
    }
}

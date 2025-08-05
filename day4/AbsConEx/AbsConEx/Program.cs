using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsConEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employ[] arrEmploy = new Employ[]
            {
                new Vasim(1,"vasim",5253),
                new Basha(2,"Basha",5254)

            };
            foreach(Employ employ in arrEmploy)
            {
                Console.WriteLine(employ);
            }

        }
    }
}

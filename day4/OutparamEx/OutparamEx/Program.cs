using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutparamEx
{
    internal class Program
    {

        public void Show(int emno, out string name, out double basic)
        {
            name = string.Empty;
            basic = 0;
            if(emno ==1)
            {
                name = "vasim";
                basic = 888;
            }
            if (emno == 2)
            {
                name = "Basha";
                basic = 999;
            }

        }
        static void Main(string[] args)
        {
            int emno;
            Console.WriteLine("Enter Employ number");
            emno = Convert.ToInt32(Console.ReadLine());
            Program p = new Program();
            string name;
            double basic;
            p.Show(emno, out name, out basic);
            Console.WriteLine("Name is "+name);
            Console.WriteLine("Basic is" + basic);

        }
    }
}

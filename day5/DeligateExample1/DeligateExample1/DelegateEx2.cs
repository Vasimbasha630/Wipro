using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeligateExample1
{
    internal class DelegateEx2
    {
        public delegate void MyDelegate(string s);

        public static void Show(string s)
        {
            System.Console.WriteLine("Welcome to deligate"+s);
        }

        static void Main()
        {
            MyDelegate obj = new MyDelegate(Show);
            obj("Vasim");

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeligateExample1
{
    internal class DelegateArrays
    {
        public delegate void MyDelegate(int n);
        public static void Fact(int n)
        {
            int f = 1;
            for (int i = 1; i <= n; i++)
            {
                f = f * i;
            }
            Console.WriteLine("Factorial value"+f);
        }

        public static void EvenOdd(int n)
        {
            if(n%2==0)
            {
                Console.WriteLine("Even Number");
            }
            else
            {
                Console.WriteLine("Odd Number");
            }
        }
        public static void PosNeg(int n)
        {
            if (n >= 0)
            {
                Console.WriteLine("Positive Number...");
            }
            else
            {
                Console.WriteLine("Negative Number...");
            }
        }

        static void Main()
        {
            Console.WriteLine("Enter N value");
            int n = Convert.ToInt32(Console.ReadLine());
            MyDelegate[] arr =
            {
                new MyDelegate(PosNeg),
                new MyDelegate(EvenOdd),
                new MyDelegate(Fact)
            };
            foreach (MyDelegate a in arr)
            {
                a(n);
            }
        }
    }
}

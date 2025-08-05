using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///<summar>
///Example about Multi- cast Deligate
/// </summary>
namespace DeligateExample1
{
    internal class DelegateExample3
    {
        public delegate void MyDeligate(int n);

        public static void Fact(int n)
        {
            int f=1;
            for(int i=1;i<=n;i++)
            {
                f = f * i;
            }
            Console.WriteLine("Factorial value"+f);
        }
        public static void PosNeg(int n)
        {
            if(n>=0)
            {
                Console.WriteLine("Positive Number");
            }
            else
            {
                Console.WriteLine("Negative Number");
            }
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
        static void Main()
        {
            int n;
            Console.WriteLine("Enter N value");
            n = Convert.ToInt32(Console.ReadLine());
            MyDeligate obj = new MyDeligate(PosNeg);
            obj += new MyDeligate(Fact);
            obj += new MyDeligate(EvenOdd);
            obj(n);

        }
    }
}

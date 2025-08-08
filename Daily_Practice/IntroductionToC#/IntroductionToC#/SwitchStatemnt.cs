using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToC_
{
    internal class SwitchStatemnt
    {
        static void Main()
        {
            Console.WriteLine("Enter a number");
            int userNumber = Convert.ToInt32(Console.ReadLine());
            //if(userNumber==10)
            //{
            //    Console.WriteLine("Your number is 10");
            //}
            //else if (userNumber == 20)
            //{
            //    Console.WriteLine("Your number is 20");
            //}
            //else if (userNumber == 30)
            //{
            //    Console.WriteLine("Your number is 30");
            //}
            //else
            //{
            //    Console.WriteLine("Invalid option you choose");
            //}
            //By using multiple if conditions go for switch case
            switch (userNumber)
            {
                case 10:
                    Console.WriteLine("Your number is 10");
                    break;
                case 20:
                    Console.WriteLine("Your number is 20");
                    break;
                case 30:
                    Console.WriteLine("Your number is 30");
                    break;
                default:
                    Console.WriteLine("You can choose anothern");
                    break;
            
            }

        }
    }
}

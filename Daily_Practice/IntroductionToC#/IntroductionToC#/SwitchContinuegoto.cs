using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToC_
{
    internal class SwitchContinuegoto
    {
        static void Main()
        {
            int totalcost = 0;
        Start:
            Console.WriteLine("1-Small,2-Medium,3-Large");
            int userChoice = int.Parse(Console.ReadLine());
            switch(userChoice)
            {
                case 1:
                    totalcost += 1;
                    break;
                case 2:
                    totalcost += 2;
                    break;
                case 3:
                    totalcost += 3;
                    break;
                default:
                    Console.WriteLine("Your choice is invalid"+userChoice);
                    break;

            }
        Decide:
            Console.WriteLine("You want to buy another coffe yes or no");
            string userDesicion = Console.ReadLine();
            switch(userDesicion.ToUpper())
            {
                case "YES":
                    goto Start;
                case "NO":
                    break;
                default:
                    Console.WriteLine("Your choice invalid and please try again");
                    goto Decide;
            }
            Console.WriteLine("Thank for shoping");
            Console.WriteLine("Bill Amount is"+totalcost);
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voting1
{
    internal class Program
    {
        public void Check(int age)
        {
            if (age < 18)
            {
                throw new Voting1Exception("You are Not Elligible For voting...");
            }
            Console.WriteLine("You Can Vote...");
        }
        static void Main(string[] args)
        {
            int age;
            Console.WriteLine("Enter Age  ");
            age = Convert.ToInt32(Console.ReadLine());
            Voting1 voting = new Voting1();
            try
            {
                voting.Check(age);
            }
            catch (VotingException v)
            {
                Console.WriteLine(v.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToC_
{
    internal class ClassDemo
    {
        /// <summary>
        /// Declaration of class
        /// class classname
        /// {
        /// }
        /// </summary>
        class Customer
        {
            string _firstName;
            string _lastName;
            public Customer(string firstName, string lastName)
            {
                this._firstName = firstName;
                this._lastName = lastName;
            }

            public void PrintFullName()
            {
                Console.WriteLine("Full name= {0}",this._firstName+""+this._lastName);
            }
            Customer()
            {

            }
        }
        static void Main()
        {
            Customer c = new Customer("Basha","Vasim");
            c.PrintFullName();


        }
    }
}

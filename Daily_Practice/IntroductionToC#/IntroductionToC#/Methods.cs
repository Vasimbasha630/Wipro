using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToC_
{
    //Methods are also called as functions.
    //These terms are used interchangeably.
    //Methods are extermely useful because they allow you to define 
    //your logic once, and use itm at many places.
    //Methods make the maintenance of your application easier.
    //[attributes]
    //access-modifiers return-type method name(Parameters)
    //{
    // Method Body
    // }
    /// We will talk about attributes and access modifiers in a later session
    /// Return type can be any valid data type or void
    /// Method name can be any meaningfull name
    /// Parameters are optional.
    /*
     * When a method declaration include a static modifier
     * that method is said to be a static method.
     * When no static modifier is present, the method is said
     * to be an instance method.
     * static method is involed using the class name, where as an
     * instance method is involved using an instance of the class.
     * The difference between instance methods and static methods is that multiple
     * instance of a class can be created(or instantiated) and each instance has
     * its own separate method. However, when a method is staticm there are no instance
     * of that method, and you can invoke only that one defination of the static method.
     * 
     */
    internal class Methods
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public void Sum(int a, int b)
        {
            int result = a+ b;
            Console.WriteLine("The sum of two numbers is"+result);
        }

        public static void EvenNumber()
        {
            int start = 0;
            while (start < 10)
            {
                start = start + 1;
                Console.WriteLine(start);
                
            }

        }
        static void Main()
        {
            Methods m = new Methods();
            Console.WriteLine(m.Add(1, 2));
            m.Sum(1, 2);  
            Methods.EvenNumber();
        }


    }
}

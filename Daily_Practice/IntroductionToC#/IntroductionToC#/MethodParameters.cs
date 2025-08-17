using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToC_
{
    /*
     * The 4 types of method parameters
     * value parameters : Creates a copy of the parameter passed, so modificationse does not affect each other.
     * Reference Parameters : The ref method paramter keyword on a method parameter causes
     *  a method to refer to the same variable that was passed into the method. Any changes made to the paramete in the method
     *  will be reflected in that varibale when contorl passes back to the calling method.
     * Out Parameters: Use when you want a method to return more than one value
     * Parameter Arrays: The params keyword lets you specify a method paramter that takes a 
     * variable number of arguments. You can send a comma-separated list of argumnets, or an array, or no arguments.
     * Params keyword shoud be the last one in a method declarations and only one params keyword
     * is permitted in a method declaration.
     * Method Parameters Vs Method Arguments
     */
    internal class MethodParameters
    {
        public static void SimpleMethod(int j)
        {
            j = 101;
           
        }
        
        static void Main()
        {
            int i = 0;
            
            SimpleMethod(i);
            Console.WriteLine(i);

         
               
        }
    }
}

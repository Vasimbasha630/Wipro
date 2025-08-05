using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionEx1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add("Vasim");
            arrayList.Add(15.20);
            foreach(object obj in arrayList)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine("Inserting the value........");
            arrayList.Insert(1, "Basha");
            Console.WriteLine("After Inserting the output is...");
            foreach(Object o in arrayList)
            {
                Console.WriteLine(o);
            }    

        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionEx1
{
    internal class AddingIndexingandRemoving
    {
        static void Main()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add("Vasim");
            arrayList.Add("Basha");
            arrayList.Add("Yamini");
            Console.WriteLine("Default ArrayList Elements are");
            foreach(object o in arrayList)
            {
                Console.WriteLine(o);
            }

            Console.WriteLine("Removing the elements in the list....");
            arrayList.RemoveAt(0);
            arrayList.Remove("Basha");
            Console.WriteLine("After removing the elemnets");
            foreach(object o in arrayList)
            {
                Console.WriteLine(o);
            }

        }
        
    }
}

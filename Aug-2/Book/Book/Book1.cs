using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    public class Book1
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsBorrowed { get; private set; }

        public void Borrow()
        {
            if (!IsBorrowed)
                IsBorrowed = true;
        }

        public void Return()
        {
            if (IsBorrowed)
                IsBorrowed = false;
        }
    }

}

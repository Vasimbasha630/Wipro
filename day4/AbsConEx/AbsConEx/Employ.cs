using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsConEx
{
    internal class Employ
    {
        private int id;
        private string name;
        private double basic;

        public Employ(int id,string name, double basic)
        {
            this.id = id;
            this.name = name;
            this.basic = basic;
        }

        public override string ToString()
        {
            return "The id is" + id + "The name is " + name + "The basic is" + basic;
        }
    }
}

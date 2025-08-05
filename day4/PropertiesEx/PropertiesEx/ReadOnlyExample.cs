using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesEx
{
    internal class ReadOnlyExample1
    {
        public int AccountNo { get; } = 12;
        public string BranchName { get; } = "Andhra";
        public string BankName { get; } = "Union";
    }
    internal class ReadOnlyExampleNew
    {
        static void Main()
        {
            ReadOnlyExample1 bank = new ReadOnlyExample1();
            Console.WriteLine("Account No  " + bank.AccountNo);
            Console.WriteLine("Bank Name  " + bank.BankName);
            Console.WriteLine("Branch Name  " + bank.BranchName);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

}

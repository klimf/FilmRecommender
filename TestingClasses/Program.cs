using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            TestClass tst = new TestClass();
            Console.WriteLine(tst.Test(5));
        }
    }
}

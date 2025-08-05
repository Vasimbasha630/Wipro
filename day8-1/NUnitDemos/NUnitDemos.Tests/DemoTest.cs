using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnitDemos;
using NUnit.Framework;
namespace NUnitDemos.Tests
{
    [TestFixture]
    public class DemoTest
    {
        [Test]
        public void TestSum()
        {
           
            DemoTest demoTest = new DemoTest();
            Assert.AreEqual(5, demoTest.TestSum(3, 2));
        }


    }
}

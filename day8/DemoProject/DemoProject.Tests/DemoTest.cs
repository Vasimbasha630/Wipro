using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DemoProject.Tests
{
    [TestFixture]
    public class DemoTest
    {
        [Test]
        public void HellowTest()
        {
            Demo demo = new Demo();
            Assert.AreEqual("Hi Vasim", demo.Hellow());
        }

    }
       
        
}

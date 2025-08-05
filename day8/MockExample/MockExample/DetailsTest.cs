using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using MockExample; 

namespace MockExample.Tests
{
    [TestFixture]
    public class DetailsTest
    {
        [Test]
        public void TestShowStudent_WithMock()
        {
            var mockDetails = new Mock<IDetails>();
            mockDetails.Setup(d => d.ShowStudent()).Returns("Hi I am Vasim...");
            Assert.AreEqual("Hi I am Vasim...", mockDetails.Object.ShowStudent());
        }

        [Test]
        public void TestShowCompany_WithMock()
        {
            var mock = new Mock<IDetails>();
            mock.Setup(x => x.ShowCompany()).Returns("Its from Wipro Bangalore...");
            Assert.AreEqual("Its from Wipro Bangalore...", mock.Object.ShowCompany());
        }

        [Test]
        public void TestShowCompany_WithRealObject()
        {
            IDetails details = new Details();
            Assert.AreEqual("Its from Wipro Chennai...", details.ShowCompany());
        }

        [Test]
        public void TestShowStudent_WithRealObject()
        {
            IDetails details = new Details();
            Assert.AreEqual("Hi I am Vasim...", details.ShowStudent());
        }
    }
}

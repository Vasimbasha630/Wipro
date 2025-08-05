using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CalculatorLibrary;

namespace CalculatorLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new Calculator();
        }

        [Test]
        public void Add_ValidInputs_ReturnsSum()
        {
            Assert.That(calculator.Add(2, 3), Is.EqualTo(5));
        }

        [Test]
        public void Subtract_ValidInputs_ReturnsDifference()
        {
            Assert.That(calculator.Subtract(2, 3), Is.EqualTo(-1));
        }

        [Test]
        public void Multiply_ValidInputs_ReturnsProduct()
        {
            Assert.That(calculator.Multiply(2, 3), Is.EqualTo(6));
        }

        [Test]
        public void Divide_ByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(2, 0));
        }

        [Test]
        public void Divide_ValidInputs_ReturnsQuotient()
        {
            Assert.That(calculator.Divide(6, 3), Is.EqualTo(2));
        }

        [Test]
        public void Add_AddingZero_ReturnsSameNumber()
        {
            Assert.That(calculator.Add(3, 0), Is.EqualTo(3));
        }
    }
}

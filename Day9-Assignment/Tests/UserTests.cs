using Service;
using System;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void Password_Hashing_And_Verification_Works()
        {
            var service = new AuthenticationService();
            var password = "pass123";
            var hash = service.HashPassword(password);

            Assert.AreEqual(hash, service.HashPassword("pass123"));
            Assert.AreNotEqual(hash, service.HashPassword("wrong"));
        }
    }
}

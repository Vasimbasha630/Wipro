using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using System;
using Service;

namespace Tests
{
    [TestFixture]
    public class AuthenticationServiceTests
    {
        private AuthenticationService authService;

        [SetUp]
        public void Setup()
        {
            authService = new AuthenticationService();
        }

       
        [Test]
        public void Register_NewUser_ReturnsTrue()
        {
            var result = authService.Register("john", "password123");
            Assert.IsTrue(result);
        }
        [Test]
        public void Register_ExistingUser_ReturnsFalse()
        {
            authService.Register("john", "password123");


            Assert.IsFalse(authService.Register("john", "newpass456"));
        }

        [Test]
        public void Login_ValidCredentials_ReturnsTrue()
        {
            authService.Register("jane", "securepass");
            var result = authService.Login("jane", "securepass");

            Assert.IsTrue(result);
        }

        [Test]
        public void Login_InvalidPassword_ReturnsFalse()
        {
            authService.Register("jane", "securepass");
            var result = authService.Login("jane", "wrongpass");

            Assert.IsFalse(result);
        }

        [Test]
        public void Login_NonExistentUser_ReturnsFalse()
        {
            var result = authService.Login("nonexistent", "pass");

            Assert.IsFalse(result);
        }
    }
}

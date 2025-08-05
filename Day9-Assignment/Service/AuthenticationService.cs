using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Service
{
    public class AuthenticationService
    {
        private readonly Dictionary<string, string> users = new Dictionary<string, string>();

        public bool Register(string username, string password)
        {
            if (users.ContainsKey(username))
                return false;

            string hashedPassword = HashPassword(password);
            users[username] = hashedPassword;
            return true;
        }

        public bool Login(string username, string password)
        {
            if (!users.ContainsKey(username)) return false;
            string hashedPassword = HashPassword(password);
            return users[username] == hashedPassword;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public object HashPassword(string password)
        {
            throw new NotImplementedException();
        }
    }
}
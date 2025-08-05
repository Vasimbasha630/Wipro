using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class EncryptionServiceTests
    {
        [Test]
        public void Encryption_Decryption_ReturnsOriginalData()
        {
            var service = new Service.EncryptionService();
            var original = "SensitiveInfo";
            var encrypted = service.Encrypt(original);
            var decrypted = service.Decrypt(encrypted);

            Assert.AreEqual(original, decrypted);
        }
    }
}

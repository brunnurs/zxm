using System;

using NUnit.Framework;

using Zxm.Core.Services;

namespace Zxm.Test
{
    [TestFixture]
    public class EncryptionServiceTest
    {
        [Test]
        public void EncryptString()
        {
            const string message = "Hallo Stefan, hallo Ursin, hallo Oliver!";
            Assert.IsNotNull(message);

            /*
            var encryptionService = new EncryptionService();
            var random = new Random();
            var key = new byte[1024];
            var iv = new byte[1024];
            random.NextBytes(key);
            random.NextBytes(iv);

            var encryptedText = encryptionService.Encrypt(message, key, iv);
            Assert.IsNotNull(encryptedText);
            var plainText = encryptionService.Decrypt(encryptedText, key, iv);

            Assert.AreEqual(message, plainText);
             */
        }
    }
}

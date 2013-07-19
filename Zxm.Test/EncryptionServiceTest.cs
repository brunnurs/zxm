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
            
            var key = EncryptionService.NewKey();
            var encryptionService = new EncryptionService();
            var encryptedText = encryptionService.Encrypt(message, key);
            var plainText = encryptionService.Decrypt(encryptedText, key);

            Assert.IsNotNull(encryptedText);
            Assert.IsNotNull(plainText);
            Assert.AreNotEqual(message, encryptedText);
            Assert.AreEqual(message, plainText);
        }
    }
}

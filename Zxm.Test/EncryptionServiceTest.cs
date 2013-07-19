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
            
            var random = new Random();
            var key = new byte[32];
            random.NextBytes(key);
            var encryptedText = AesGcm.SimpleEncrypt(message, key);
            var plainText = AesGcm.SimpleDecrypt(encryptedText, key);

            Assert.IsNotNull(encryptedText);
            Assert.IsNotNull(plainText);
            Assert.AreNotEqual(message, encryptedText);
            Assert.AreEqual(message, plainText);
        }
    }
}

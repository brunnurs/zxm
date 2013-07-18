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

            var random = new Random();
            var key = new byte[32];
            random.NextBytes(key);
            
            var encryptedText = AesGcm.SimpleEncrypt(message, key);
            Assert.IsNotNull(encryptedText);
            Assert.AreNotEqual(message, encryptedText);
            var plainText = AesGcm.SimpleDecrypt(encryptedText, key);

            Assert.AreEqual(message, plainText);
        }
    }
}

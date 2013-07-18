using NUnit.Framework;

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
        }
    }
}

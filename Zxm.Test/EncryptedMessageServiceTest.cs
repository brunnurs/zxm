using System;
using NUnit.Framework;
using NSubstitute;
using Zxm.Core.Services;

namespace Zxm.Test
{
    [TestFixture]
    public class EncryptedMessageServiceTest
    {
        [TestFixtureSetUp] 
        public void InitMocks()
        { /* ... */ 
        }


        [Test]
        public void MessageEncrypition()
        {
            /* when */
            var encryptionServiceMock = Substitute.For<EncryptionService>();
            var messageServiceMock = Substitute.For<IMessageService>();

            /* given */

            /* then */
        }
    }
}


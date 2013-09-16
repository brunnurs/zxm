using System;
using NUnit.Framework;
using NSubstitute;
using Zxm.Core.Services;
using Zxm.Core.Model;

namespace Zxm.Test
{
    [TestFixture]
    public class EncryptedMessageServiceTest
    {
        const string EncryptedMessageString = "XXXXi'mEncryptedXXXX";

        EncrytedMessageService testee;

        EncryptionService encryptionServiceMock;
        MessageService messageServiceMock;
        UserSettingsService userSettingsServiceMock;


        [TestFixtureSetUp] 
        public void InitMocks()
        {
            encryptionServiceMock = Substitute.For<EncryptionService>();
            messageServiceMock = Substitute.For<MessageService>();
            userSettingsServiceMock = Substitute.For<UserSettingsService>();

            testee = new EncrytedMessageService(encryptionServiceMock, userSettingsServiceMock,messageServiceMock);
        }


        [Test]
        public void MessageEncrypition()
        {
            /* when */
            encryptionServiceMock.Encrypt(Arg.Any<String>(), Arg.Any<Byte[]>()).Returns(EncryptedMessageString);

            messageServiceMock.SendMessage(Arg.Is<Message>(m => m.Content == EncryptedMessageString), Arg.Invoke(new Message(), true));
//            messageServiceMock
//                .When(x=>x.SendMessage(Arg.Is<Message>(m => m.Content == EncryptedMessageString),Arg.Any<Action<Message,bool>>()))
//                    .Do(x=>{
//                        challengeAttemptRESTStoreMock.OnNetworkingError += Raise.Event<Action<Exception>>(new Exception("communication failed"));
//                    });

            var testmessage = new Message(){ Content = "This is the unencrypted text" };

            bool result = false;

            /* given */
            testee.SendMessage(testmessage, (Message m, bool wasSuccessfull) => result = wasSuccessfull);

            /* then */
            Assert.IsTrue(result);
        }
    }
}


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
            /* given */
            string encryptedMessageText = "XXXXi'mEncryptedXXXX";
            string messageText = "This is the unencrypted text";
            string password = "1234";

            var message = new Message(){ Content = messageText };

            MockSetup(encryptedMessageText,password);

            bool messageSuccessfullySent = false;
            Message resultMessage = null;

            /* when */
            testee.SendMessage(message, (msg, wasSuccessfull) => {messageSuccessfullySent = wasSuccessfull; resultMessage = msg;});

            /* then */
            Assert.IsTrue(messageSuccessfullySent);
            Assert.AreEqual(messageText, resultMessage.Content);
        }

        void MockSetup(string encryptedMessasgeString, string password)
        {
            encryptionServiceMock.Encrypt(Arg.Any<String>(), Arg.Any<Byte[]>()).Returns(encryptedMessasgeString);

            userSettingsServiceMock.UserSettings.Returns(new UserSettings() {
                Password = password
            });

            messageServiceMock.SendMessage(Arg.Is<Message>(m => m.Content == encryptedMessasgeString), Arg.Invoke(new Message(), true));
        }
    }
}


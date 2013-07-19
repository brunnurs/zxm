﻿using System;
using System.Collections.Generic;
using System.Threading;

using NSubstitute;
using NSubstitute.Core;

using NUnit.Framework;

using Zxm.Core.Model;
using Zxm.Core.Services;

namespace Zxm.Test
{
    [TestFixture]
    public class MessageServiceTest
    {
        [Test]
        public void SendMessage()
        {
            var encryptionService = new EncryptionService();
            var databaseService = Substitute.For<IDatabaseService>();
            var userSettings = new UserSettings();
            userSettings.Password = UserSettings.DEFAULT_PASSWORD;
            databaseService.GetAll<UserSettings>().Returns(_ => new List<UserSettings>{userSettings});
            
            var messageService = new MessageService(encryptionService, databaseService);

            var message = new Message();
            message.DateTime = DateTime.Now.ToLongDateString();
            message.Sender = "Oliver Brack";
            message.Content = "Ich grüsse die ganze Welt!";

            messageService.SendMessage(message, () => { });
            // TODO: Check if sending was successful
        }
    }
}
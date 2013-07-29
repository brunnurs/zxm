using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

using Newtonsoft.Json;
using Zxm.Core.Common;
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
            var databaseService = Substitute.For<DatabaseService>();
            var userSettings = new UserSettings();
            userSettings.Password = Config.DefaultUserPassword;
            databaseService.GetAll<UserSettings>().Returns(_ => new List<UserSettings>{userSettings});

            var userSettingsService = new UserSettingsService(databaseService);
            
            var messageService = new MessageService(encryptionService,userSettingsService);

            var message = new Message();
            message.DateSent = DateTime.Now;
            message.Sender = "Oliver Brack";
            message.Content = "Ich grüsse die ganze Welt!";

            messageService.SendMessage(message, (m, b) => { });
            // TODO: Check if sending was successful
        }

        [Test]
        public void ParseJsonDate()
        {
            const string JsonMessage = "{\"DateSent\":\"/Date(1374249163470+0000)/\"}";
            var expectedDate = new DateTime(2013, 7, 19);

            var message = JsonConvert.DeserializeObject<JsonMessage>(JsonMessage, new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            });

            Assert.AreEqual(expectedDate.Date, message.DateSent.Date);
        }

        public class JsonMessage
        {
            public DateTime DateSent { get; set; }
        }
    }
}

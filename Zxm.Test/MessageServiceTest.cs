using System;
using System.Collections.Generic;
using System.Threading;

using NSubstitute;
using NSubstitute.Core;

using NUnit.Framework;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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
            userSettings.Password = UserSettings.DefaultPassword;
            databaseService.GetAll<UserSettings>().Returns(_ => new List<UserSettings>{userSettings});

            var userSettingsService = new UserSettingsService(databaseService);
            
            var messageService = new MessageWebService(encryptionService,userSettingsService);

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

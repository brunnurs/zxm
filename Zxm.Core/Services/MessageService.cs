using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;
using RestSharp;
using Zxm.Core.Model;
using Zxm.Core.Common;

namespace Zxm.Core.Services
{
    public class MessageService : IMessageService
    {
        // TODO: Duplicated in UserService
        private const string Url = "http://zxm.azurewebsites.net/";

        private static readonly UnicodeEncoding Encoding = new UnicodeEncoding();

        private readonly IEncryptionService _encryptionService;
        private readonly IDatabaseService _databaseService;

        public MessageService(IEncryptionService encryptionService, IDatabaseService databaseService)
        {
            _encryptionService = encryptionService;
            _databaseService = databaseService;
        }

        public void RequestMessages(Action<List<Message>> messageCallback)
        {
            var client = new RestClient(Url);
            var request = new RestRequest("message?format=json", Method.GET);
            client.ExecuteAsync(request, (response, x) => messageCallback(JsonConvert.DeserializeObject<List<Message>>(response.Content).ForEach(DecryptMessage)));
        }

        private void DecryptMessage(Message message)
        {
            var decryptedContent = _encryptionService.Decrypt(message.Content, GetKey());
            message.Content = decryptedContent;
        }

        public void SendMessage(Message newMessage)
        {
            // Encrypt message
            var encryptedContent = _encryptionService.Encrypt(newMessage.Content, GetKey());
            newMessage.Content = encryptedContent;

            var client = new RestClient(Url);
            var request = new RestRequest("message?format=json", Method.POST);
            //TODO: use AddBody does not seem to work
            request.AddParameter("text/json", JsonConvert.SerializeObject(newMessage), ParameterType.RequestBody);
            client.ExecuteAsync(request, (arg1, arg2) => { });
        }

        private byte[] GetKey()
        {
            var userSettings = _databaseService.GetAll<UserSettings>().FirstOrDefault();
            if (userSettings == null)
            {
                userSettings = new UserSettings();
                var newKey = EncryptionService.NewKey();
                var password = Encoding.GetString(newKey, 0, newKey.Length);
                userSettings.Password = password;
                _databaseService.Insert(userSettings);
            }

            var key = Encoding.GetBytes(userSettings.Password);
            return key;
        }
    }
}
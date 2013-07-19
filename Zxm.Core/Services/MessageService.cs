using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;
using RestSharp;
using Zxm.Core.Model;
using System.Diagnostics;

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
			Debug.WriteLine ("RequestMessages called");
            var client = new RestClient(Url);
            var request = new RestRequest("message?format=json", Method.GET);
			client.ExecuteAsync(request, (response, x) => MessagesLoaded(response,messageCallback));
        }


		private void MessagesLoaded(IRestResponse response, Action<List<Message>> messageCallback)
		{
			if (response.StatusCode == System.Net.HttpStatusCode.OK)
			{
				var receivedMessages = JsonConvert.DeserializeObject<List<Message>>(response.Content);
                Debug.WriteLine ("received {0} new messages. Try to deserialize",receivedMessages.Count);
				receivedMessages.ForEach(DecryptMessage);

				Debug.WriteLine ("deserializing worked");
				messageCallback(receivedMessages);
			}
			else
			{
				Debug.WriteLine ("receiving messages failed");
			}
		}

        private void DecryptMessage(Message message)
        {
			try
			{
				byte[] key = GetKey();
                var decryptedContent = _encryptionService.Decrypt(message.Content,key);
                message.Content = decryptedContent;
			}
			catch(Exception ex)
			{
				Debug.WriteLine("failed to decrypt message from {0}. Exception: {1}", message.Sender,ex);
			}
        }

		public void SendMessage(Message newMessage, Action messageSentCallback)
        {
            // Encrypt message
            var encryptedContent = _encryptionService.Encrypt(newMessage.Content, GetKey());
            newMessage.Content = encryptedContent;

            var client = new RestClient(Url);
            var request = new RestRequest("message?format=json", Method.POST);
            //TODO: use AddBody does not seem to work
            request.AddParameter("text/json", JsonConvert.SerializeObject(newMessage), ParameterType.RequestBody);
			client.ExecuteAsync(request,(response, x) => MessageSent(response,messageSentCallback));
			Debug.WriteLine ("sending new message...");
        }

		void MessageSent(IRestResponse response,Action messageSentCallback)
		{
			if (response.StatusCode == System.Net.HttpStatusCode.OK) 
			{
				Debug.WriteLine ("message successfully sent");
				messageSentCallback ();
			} 
			else 
			{
				Debug.WriteLine ("sending message failed {0}",response.StatusCode);
			}
		}

        private byte[] GetKey()
        {
            var userSettings = _databaseService.GetAll<UserSettings>().FirstOrDefault();
            if (userSettings == null)
            {
                userSettings = new UserSettings();
				userSettings.UserName = "John Bird";
				userSettings.Password = UserSettings.DEFAULT_PASSWORD;
          
                _databaseService.Insert(userSettings);
            }

			Debug.WriteLine("Password for key will be:" + userSettings.Password);
            return EncryptionService.GetKeyFromPassword(userSettings.Password);
        }
    }
}
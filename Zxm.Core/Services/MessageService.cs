using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;
using RestSharp;
using Zxm.Core.Model;
using System.Diagnostics;
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

        public event EventHandler<MessageEventArgs> MessageSent; 

        public MessageService(IEncryptionService encryptionService, IDatabaseService databaseService)
        {
            _encryptionService = encryptionService;
            _databaseService = databaseService;
        }

        public void RequestMessages(Action<List<Message>> messageCallback)
        {
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
            var decryptedContent = _encryptionService.Decrypt(message.Content, GetKey());
            message.Content = decryptedContent;
        }

		public void SendMessage(Message newMessage, Action messageSentCallback)
		{
            // Make a copy which can be used for the MessageSent-Event
		    var originalMessage = new Message(newMessage);

            // Encrypt message
            var encryptedContent = _encryptionService.Encrypt(newMessage.Content, GetKey());
            newMessage.Content = encryptedContent;

            var client = new RestClient(Url);
            var request = new RestRequest("message?format=json", Method.POST);
            //TODO: use AddBody does not seem to work
            request.AddParameter("text/json", JsonConvert.SerializeObject(newMessage), ParameterType.RequestBody);
			client.ExecuteAsync(request,(response, x) => MessageSentCallback(response,messageSentCallback, originalMessage));
			Debug.WriteLine ("sending new message...");
        }

		private void MessageSentCallback(IRestResponse response,Action messageSentCallback, Message message)
		{
			if (response.StatusCode == System.Net.HttpStatusCode.OK) 
			{
                if (MessageSent != null)
                {
                    MessageSent(this, new MessageEventArgs{Message = message});
                }
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
                var newKey = EncryptionService.NewKey();
                userSettings.Password = Encoding.GetString(newKey, 0, newKey.Length);
                _databaseService.Insert(userSettings);
            }

            if (string.IsNullOrEmpty(userSettings.Password))
            {
                var newKey = EncryptionService.NewKey();
                userSettings.Password = Encoding.GetString(newKey, 0, newKey.Length);
                _databaseService.Update(userSettings);
            }

            return EncryptionService.GetKeyFromPassword(userSettings.Password);
        }
    }

    public class MessageEventArgs : EventArgs
    {
        public Message Message { get; set; }
    }
}
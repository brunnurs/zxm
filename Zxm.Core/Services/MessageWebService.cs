using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using Zxm.Core.Common;
using Zxm.Core.Model;
using System.Diagnostics;

namespace Zxm.Core.Services
{
    public class MessageWebService : IMessageWebService
    {
        // TODO: Duplicated in UserService
        private const string Url = "http://zxm.azurewebsites.net/api/";

        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
        };

        private readonly IEncryptionService _encryptionService;
        private readonly IUserSettingsService _userSettingsService;

        public event EventHandler<MessageEventArgs> MessageSent;

        public MessageWebService(IEncryptionService encryptionService, IUserSettingsService userSettingsService)
        {
            _encryptionService = encryptionService;
            _userSettingsService = userSettingsService;
        }

        public void RequestMessages(Action<List<Message>> messageCallback)
        {
            Debug.WriteLine("RequestMessages called");
            var client = new RestClient(Url);
            var request = new RestRequest("message?format=json", Method.GET);
            client.ExecuteAsync(request, (response, x) => MessagesLoaded(response, messageCallback));
        }

        public void SendMessage(Message newMessage, Action<Message,bool> messageSentCallback)
        {
            // Make a copy which can be used for the MessageSent-Event
            var originalMessage = new Message(newMessage);

            // Encrypt message
            var encryptedContent = _encryptionService.Encrypt(newMessage.Content, GetKey());
            newMessage.Content = encryptedContent;

            var client = new RestClient(Url);
            var request = new RestRequest("message?format=json", Method.POST);
            //TODO: use AddBody does not seem to work
            string json = JsonConvert.SerializeObject(newMessage, SerializerSettings);
            request.AddParameter("text/json", json, ParameterType.RequestBody);
            client.ExecuteAsync(request, (response, x) => MessageSentCallback(response, messageSentCallback, originalMessage));
            Debug.WriteLine("sending new message...");
        }

        private void MessagesLoaded(IRestResponse response, Action<List<Message>> messageCallback)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var receivedMessages = JsonConvert.DeserializeObject<List<Message>>(response.Content, new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                });

                Debug.WriteLine ("received {0} new messages. Try to deserialize",receivedMessages.Count);
                receivedMessages.ForEach(DecryptMessage);

                Debug.WriteLine("deserializing worked");
                messageCallback(receivedMessages);
            }
            else
            {
                Debug.WriteLine("receiving messages failed");
            }
        }

        private void DecryptMessage(Message message)
        {
            try
            {
                byte[] key = GetKey();
                var decryptedContent = _encryptionService.Decrypt(message.Content, key);
                message.Content = decryptedContent;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("failed to decrypt message from {0}. Exception: {1}", message.Sender, ex);
            }
        }



        private void MessageSentCallback(IRestResponse response, Action<Message,bool> messageSentCallback, Message message)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (MessageSent != null)
                {
                    MessageSent(this, new MessageEventArgs { Message = message });
                }
                Debug.WriteLine("message successfully sent");
                messageSentCallback(message,true);
            }
            else
            {
                Debug.WriteLine("sending message failed {0}", response.StatusCode);
                messageSentCallback(message,false);
            }
        }

        private byte[] GetKey()
        {
            return EncryptionService.GetKeyFromPassword(_userSettingsService.UserSettings.Password);
        }
    }
}
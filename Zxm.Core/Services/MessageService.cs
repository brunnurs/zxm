using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using Zxm.Core.Common;
using Zxm.Core.Model;
using System.Diagnostics;

namespace Zxm.Core.Services
{
    public class MessageService
    {
        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
        };

        public event EventHandler<EventArgs<Message>> MessageSent;

        public void RequestMessages(Action<List<Message>> messageCallback)
        {
            Debug.WriteLine("RequestMessages called");
            var client = new RestClient(Config.WebserviceUrlApi);
            var request = new RestRequest("message?format=json", Method.GET);
            client.ExecuteAsync(request, (response, x) => MessagesLoadedCallback(response, messageCallback));
        }

        public virtual void SendMessage(Message message, Action<Message, bool> messageSentCallback)
        {
            var client = new RestClient(Config.WebserviceUrlApi);
            var request = new RestRequest("message?format=json", Method.POST);
            string json = JsonConvert.SerializeObject(message, SerializerSettings);
            request.AddParameter("text/json", json, ParameterType.RequestBody);

            client.ExecuteAsync(request, (response, x) => MessageSentCallback(response, messageSentCallback, message));
            Debug.WriteLine("sending new message...");
        }

        private void MessagesLoadedCallback(IRestResponse response, Action<List<Message>> messageCallback)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var receivedMessages = JsonConvert.DeserializeObject<List<Message>>(response.Content, SerializerSettings);
                messageCallback(receivedMessages);
            }
            else
            {
                Debug.WriteLine("receiving messages failed");
            }
        }

        private void MessageSentCallback(IRestResponse response, Action<Message, bool> messageSentCallback, Message message)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (MessageSent != null)
                {
                    MessageSent(this, new EventArgs<Message>(message));
                }
                Debug.WriteLine("message successfully sent");
                messageSentCallback(message, true);
            }
            else
            {
                Debug.WriteLine("sending message failed {0}", response.StatusCode);
                messageSentCallback(message, false);
            }
        }
    }
}
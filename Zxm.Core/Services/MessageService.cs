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
        }


        private void MessagesLoadedCallback(IRestResponse response, Action<List<Message>> messageCallback)
        {
            var receivedMessages = JsonConvert.DeserializeObject<List<Message>>(response.Content, SerializerSettings);
            messageCallback(receivedMessages);
        }

        private void MessageSentCallback(IRestResponse response, Action<Message, bool> messageSentCallback, Message message)
        {
            bool wasSuccessfully = response.StatusCode == System.Net.HttpStatusCode.OK;
            if (wasSuccessfully)
            {
                if (MessageSent != null)
                {
                    MessageSent(this, new EventArgs<Message>(message));
                }
            }

            messageSentCallback(message, wasSuccessfully);
        }
    }
}
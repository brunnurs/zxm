using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using RestSharp;
using Zxm.Core.Model;

namespace Zxm.Core.Services
{
    public class MessageService : IMessageService
    {
        private Action<List<Message>> _messageCallback;

        // TODO: Duplicated in UserService
        private const string Url = "http://zxm.azurewebsites.net/";


        public void RequestMessages(Action<List<Message>> messageCallback)
        {
            //TODO: Other way then instance variable
            _messageCallback = messageCallback;

            var client = new RestClient(Url);
            var request = new RestRequest("message?format=json", Method.GET);
            client.ExecuteAsync(request, RequestMessageCallback);
        }

        private void RequestMessageCallback(IRestResponse restResponse, RestRequestAsyncHandle arg2)
        {
            //TODO: RequestFormat?
            _messageCallback(JsonConvert.DeserializeObject<List<Message>>(restResponse.Content));
        }

        public void SendMessage(Message newMessage)
        {
            var client = new RestClient(Url);
            var request = new RestRequest("message?format=json", Method.POST);
            //TODO: use AddBody does not seem to work
            request.AddParameter("text/json", JsonConvert.SerializeObject(newMessage), ParameterType.RequestBody);
            client.ExecuteAsync(request, SendMessageCallback);
        }

        private void SendMessageCallback(IRestResponse arg1, RestRequestAsyncHandle arg2)
        {
        }
    }
}
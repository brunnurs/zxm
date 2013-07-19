﻿using System;
using System.Collections.Generic;
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

        public void RequestMessages(Action<List<Message>> messageCallback)
        {
            var client = new RestClient(Url);
            var request = new RestRequest("message?format=json", Method.GET);
            client.ExecuteAsync(request, (response, x) => messageCallback(JsonConvert.DeserializeObject<List<Message>>(response.Content)));
        }

		public void SendMessage(Message newMessage,Action messageSentCallback)
        {
            var client = new RestClient(Url);
            var request = new RestRequest("message?format=json", Method.POST);
            //TODO: use AddBody does not seem to work
            request.AddParameter("text/json", JsonConvert.SerializeObject(newMessage), ParameterType.RequestBody);
			client.ExecuteAsync(request,(response, x) =>{ MessageSent(response,messageSentCallback); });
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

    }
}
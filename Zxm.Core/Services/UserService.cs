using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using RestSharp;
using Zxm.Core.Model;

namespace Zxm.Core.Services
{
    public class UserService : IUserService
    {
        private const string Url = "http://zxm.azurewebsites.net/";
        private Action<List<User>> _callback; 

        public void RequestAllUser(Action<List<User>> callback)
        {
            _callback = callback;

            var client = new RestClient(Url);
            var request = new RestRequest("user?format=json", Method.GET);
            client.ExecuteAsync(request, CallBack);
        }

        private void CallBack(IRestResponse arg1, RestRequestAsyncHandle arg2)
        {
            _callback(JsonConvert.DeserializeObject<List<User>>(arg1.Content));
        }
    }
}

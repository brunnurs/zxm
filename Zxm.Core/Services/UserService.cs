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
        private Action<List<User>> _requestAllUserCallback; 

        public void RequestAllUser(Action<List<User>> callback)
        {
            //TODO: Better solution than an instance-variable?
            _requestAllUserCallback = callback;

            var client = new RestClient(Url);
            var request = new RestRequest("user?format=json", Method.GET);
            client.ExecuteAsync(request, RequestAllUserCallback);
        }

        private void RequestAllUserCallback(IRestResponse arg1, RestRequestAsyncHandle arg2)
        {
            _requestAllUserCallback(JsonConvert.DeserializeObject<List<User>>(arg1.Content));
        }
    }
}

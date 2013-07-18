using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using Zxm.Core.Model;

namespace Zxm.Core.Services
{
    public class UserService : IUserService
    {
        private const string Url = "http://zxm.azurewebsites.net/";
        public void RequestAllUser(Action<List<User>> callback)
        {
            var client = new RestClient(Url);
            var request = new RestRequest("user?format=json", Method.GET);
            client.ExecuteAsync(request, (response, x) => callback(JsonConvert.DeserializeObject<List<User>>(response.Content)));
        }
    }
}

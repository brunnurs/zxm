using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using Zxm.Core.Common;
using Zxm.Core.Model;

namespace Zxm.Core.Services
{
    public class UserService
    {
        public void RequestAllUser(Action<List<User>> callback)
        {
            var client = new RestClient(Config.WebserviceUrl);
            var request = new RestRequest("user?format=json", Method.GET);
            client.ExecuteAsync(request, (response, x) => callback(JsonConvert.DeserializeObject<List<User>>(response.Content)));
        }
    }
}

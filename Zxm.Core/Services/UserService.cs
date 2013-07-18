using System.Collections.Generic;
using Zxm.Core.Model;

namespace Zxm.Core.Services
{
    public class UserService : IUserService
    {
        private const string Url = "http://zxm.azurewebsites.net/user?format=json";

        //public async Task<List<User>> GetAllUsersAsync()
        //{
        //    var client = new HttpClient();
        //    var msg = await client.GetAsync(Url);
        //    if (msg.IsSuccessStatusCode)
        //    {
        //        using (var stream = await msg.Content.ReadAsStreamAsync())
        //        {
        //            using (var streamReader = new StreamReader(stream))
        //            {
        //                var str = await streamReader.ReadToEndAsync();
        //                var obj = await JsonConvert.DeserializeObjectAsync<List<User>>(str);
        //                return obj;
        //            }
        //        }
        //    }
        //    return null;
        //}

        public List<User> GetAllUser()
        {
            return new List<User> {new User {FirstName = "Stefan"}, new User {FirstName = "Hans"}};
        }

        public User GetCurrentUser()
        {
            throw new System.NotImplementedException();
        }
    }
}

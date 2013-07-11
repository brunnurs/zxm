//using System.IO;
//using System.Net.Http;
//using System.Threading.Tasks;
//using Newtonsoft.Json;
//using Zxm.Core.Model;

//namespace Zxm.Core.Services
//{
//    public class UserService : IUserService
//    {
//        public async Task<User> GetAllUsersAsync()
//        {
//            var client = new HttpClient();
//            var msg = await client.GetAsync("");
//            if (msg.IsSuccessStatusCode)
//            {
//                using (var stream = await msg.Content.ReadAsStreamAsync())
//                {
//                    using (var streamReader = new StreamReader(stream))
//                    {
//                        var str = await streamReader.ReadToEndAsync();
//                        var obj = await JsonConvert.DeserializeObjectAsync<User>(str);
//                        return obj;
//                    }
//                }
//            }
//            return null;
//        }
//    }
//}

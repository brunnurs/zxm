using System.Collections.Generic;
using Zxm.Core.Model;

namespace Zxm.Core.Services
{
    public interface IUserService
    {
        //Task<List<User>> GetAllUsersAsync();

        List<User> GetAllUser();
        User GetCurrentUser();
    }
}
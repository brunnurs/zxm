using System.Collections.Generic;
using System.Threading.Tasks;
using Zxm.Core.Model;

namespace Zxm.Core.Services
{
    internal interface IUserService
    {
        Task<User> GetAllUsersAsync();
    }
}
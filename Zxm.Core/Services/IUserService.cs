using System;
using System.Collections.Generic;
using Zxm.Core.Model;

namespace Zxm.Core.Services
{
    public interface IUserService
    {
        void RequestAllUser(Action<List<User>> callback);
    }
}
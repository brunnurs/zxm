using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceInterface;
using Zxm.Webservice.Model;
using Zxm.Webservice.Persistence;

namespace Zxm.Webservice.Services
{
    public class UserService : Service
    {
        public UserRepository Repository { get; set; }

        public object Get(User request)
        {
            if (request.Id != default(int))
            {
                return Repository.GetById(request.Id);
            }

            return Repository.GetAll();
        }
    }
}
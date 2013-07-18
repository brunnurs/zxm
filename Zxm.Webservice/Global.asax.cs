using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using ServiceStack.WebHost.Endpoints;
using Zxm.Webservice.Persistence;
using Zxm.Webservice.Services;

namespace Zxm.Webservice
{
    public class Global : System.Web.HttpApplication
    {
        public class HelloAppHost : AppHostBase
        {
            //Tell Service Stack the name of your application and where to find your web services
            public HelloAppHost() : base("Hello Web Services", typeof(UserService).Assembly) { }

            public override void Configure(Funq.Container container)
            {
                container.Register(new UserRepository());
                container.Register(new MessageRepository());
            }
        }

        //Initialize your application singleton
        protected void Application_Start(object sender, EventArgs e)
        {
            new HelloAppHost().Init();
        }
    }
}
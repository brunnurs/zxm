using System.Collections.Generic;
using System.Web.Mvc;

using ServiceStack.WebHost.Endpoints;

using Zxm.Webservice.Model;
using Zxm.Webservice.Persistence;

namespace Zxm.Webservice.Controllers
{
    public class UserController : Controller
    {
        // GET: /User/ 
        public string Index()
        {
            return "Use the API URL to get a list of all users.";
        }

        // GET: /User/Details?userId={Id}
        public ActionResult Details(int userId)
        {
            var container = EndpointHost.Config.ServiceManager.Container;
            var userRepository = container.Resolve<UserRepository>();
            var user = userRepository.GetById(userId);

            // Get all properties using reflection
            var userProperties = new Dictionary<string, object>();
            var userType = typeof(User);
            foreach (var property in userType.GetProperties())
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(user);

                userProperties.Add(propertyName, propertyValue);
            }
            ViewBag.UserProperties = userProperties;
            ViewBag.User = user;

            return View();
        } 
    }
}

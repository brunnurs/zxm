using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceHost;

namespace Zxm.Webservice.Model
{
    [Route("/user", "GET")]
    [Route("/user/{Id}", "GET")]
    public class User : IReturn<List<User>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string WebPage { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Street { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Department { get; set; }
        public string Office { get; set; }
        public string Profession { get; set; }
        public string ManagersName { get; set; }
        public string AssistantName { get; set; }
        public string Nickname { get; set; }
        public DateTime Birthday { get; set; }
        public int Sales { get; set; }
        public int Margin { get; set; }
        public string ImageUri { get; set; }

        public User(int id)
        {
            Id = id;
        }

        public override string ToString()
        {
            return string.Format("Id: {0}, FirstName: {1}, LastName: {2}", Id, FirstName, LastName);
        }
    }
}
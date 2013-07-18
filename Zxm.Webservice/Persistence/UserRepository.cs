using System;
using System.Collections.Generic;
using System.Linq;
using Zxm.Webservice.Model;

namespace Zxm.Webservice.Persistence
{
    public class UserRepository
    {
        public List<User> Users { get; set; }

        public UserRepository()
        {
            Users = new List<User>();
            foreach (var customer in TestDataGenerator.GenerateTestUsers())
            {
                Users.Add(customer);
            }
        }

        public User GetById(int id)
        {
            return Users.FirstOrDefault(x => x.Id == id);
        }

        public List<User> GetAll()
        {
            return Users;
        }

        public User Save(User user)
        {
            Users.Add(user);
            return user;
        }

        public void DeleteById(int id)
        {
            Users.Remove(Users.FirstOrDefault(x => x.Id == id));
        }
    }
}
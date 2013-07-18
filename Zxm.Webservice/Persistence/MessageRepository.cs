using System;
using System.Collections.Generic;
using System.Linq;
using Zxm.Webservice.Model;

namespace Zxm.Webservice.Persistence
{
    public class MessageRepository
    {
        public List<Message> Messages { get; set; }

        public MessageRepository()
        {
            Messages = new List<Message>();
            foreach (var message in TestDataGenerator.GenerateTestMessages())
            {
                Messages.Add(message);
            }
        }

        public Message GetById(int id)
        {
            return Messages.FirstOrDefault(x => x.Id == id);
        }

        public List<Message> GetAll()
        {
            return Messages;
        }

        public Message Save(Message message)
        {
            Messages.Add(message);
            return message;
        }

        public void DeleteById(int id)
        {
            Messages.Remove(Messages.FirstOrDefault(x => x.Id == id));
        }
    }
}
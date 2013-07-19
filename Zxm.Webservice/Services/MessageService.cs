using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceInterface;
using Zxm.Webservice.Model;
using Zxm.Webservice.Persistence;

namespace Zxm.Webservice.Services
{
    public class MessageService : Service
    {
        public MessageRepository Repository { get; set; }

        public object Get(GetMessage request)
        {
            if (request.Id != default(int))
            {
                return Repository.GetById(request.Id);
            }

            return Repository.GetAll();
        }

        public object Post(CreateMessage messages)
        {
            var message = new Message(messages);
            var maxId = Repository.Messages.Max(m => m.Id);
            maxId++;
            message.Id = maxId;
            message.DateSent = DateTime.Now;

            return Repository.Save(message);
        }
    }
}
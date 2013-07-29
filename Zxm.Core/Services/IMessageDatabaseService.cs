using System;
using System.Collections.Generic;
using Zxm.Core.Model;

namespace Zxm.Core.Services
{
    public interface IMessageDatabaseService
    {
        List<Message> GetAllMessages();

        Message GetMessage(Message message);

        void InsertMessage(Message message);

        void DeleteMessage(Message message);
    }
}


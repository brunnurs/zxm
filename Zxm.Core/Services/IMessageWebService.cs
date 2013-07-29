using System;
using System.Collections.Generic;
using Zxm.Core.Model;
using Zxm.Core.Services;

namespace Zxm.Core
{
    public interface IMessageWebService
    {
        void RequestMessages(Action<List<Message>> messageCallback);
        void SendMessage(Message newMessage, Action<Message,bool> messageSentCallback);

        event EventHandler<MessageEventArgs> MessageSent;
    }
}


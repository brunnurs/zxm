using System;
using System.Collections.Generic;
using Zxm.Core.Model;

namespace Zxm.Core.Services
{
    public interface IMessageService
    {
        void RequestMessages(Action<List<Message>> messageCallback);
        void SendMessage(Message newMessage, Action messageSentCallback);

        event EventHandler<MessageEventArgs> MessageSent;
    }
}

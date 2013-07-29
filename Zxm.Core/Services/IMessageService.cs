using System;
using System.Collections.Generic;
using Zxm.Core.Common;
using Zxm.Core.Model;

namespace Zxm.Core.Services
{
    public interface IMessageService
    {
        void SendMessage(Message newMessage, Action<Message, bool> messageSentCallback);
        event EventHandler<MessageEventArgs> MessageSent;
        void RequestMessages(Action<List<Message>> loadMessagesCallback);
    }
}
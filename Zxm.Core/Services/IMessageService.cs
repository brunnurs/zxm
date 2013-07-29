using System;
using System.Collections.Generic;
using Zxm.Core.Common;
using Zxm.Core.Model;

namespace Zxm.Core.Services
{
    public interface IMessageService
    {
        void SendMessage(Message newMessage, Action<Message, bool> messageSentCallback);
        event EventHandler<EventArgs<Message>> MessageSent;
        void RequestMessages(Action<List<Message>> loadMessagesCallback);
    }
}
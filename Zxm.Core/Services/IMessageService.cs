using System.Collections.Generic;
using Zxm.Core.Model;

namespace Zxm.Core.Services
{
    interface IMessageService
    {
        void SendMessage(string message);
        IEnumerable<Message> ReadMessages();
    }
}

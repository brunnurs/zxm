using System;
using System.Collections.Generic;
using Zxm.Core.Model;

namespace Zxm.Core.Services
{
    public interface IMessageService
    {
        void SendMessage(Message newMessage, Action messageSentCallback);

        IMessageWebService WebService { get;}
    }
}

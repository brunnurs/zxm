using System;
using Zxm.Core.Model;
using System.Diagnostics;

namespace Zxm.Core.Services
{
    public class CachedMessageService :IMessageService
    {
        IMessageWebService messageWebService;
        IMessageDatabaseService databaseService;

        public CachedMessageService(IMessageWebService messageService,IMessageDatabaseService databaseService)
        {
            this.databaseService = databaseService;
            this.messageWebService = messageService;
        }

        public void SendMessage(Message newMessage, Action messageSentCallback) 
        {
            Debug.WriteLine("cache message {0} before sending", newMessage);
            databaseService.InsertMessage(newMessage);
            messageWebService.SendMessage(newMessage, (Message message,bool success) => messageSent(message,success, messageSentCallback));
        }

        private void messageSent(Message message,bool success,Action messageSentCallback)
        {
            if (success)
            {
                Debug.WriteLine("Removed message {0} from cache", message);
                databaseService.DeleteMessage(message);
                messageSentCallback();
            }
        }

        public IMessageWebService WebService
        {
            get
            {
                return messageWebService;
            }
        }
    }
}


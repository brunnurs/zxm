using System;
using Zxm.Core.Model;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

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
            databaseService.InsertMessage(newMessage);

            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

            Action<Task> repeatAction = null;

            repeatAction = t1 =>
            {
                TrySendingMessage(newMessage, messageSentCallback, cancelTokenSource);

                Task.Delay(10000, cancelTokenSource.Token).ContinueWith( t2 => repeatAction(t2), cancelTokenSource.Token);

            };

            Task.Delay(0, cancelTokenSource.Token).ContinueWith(repeatAction);
        }

        private void MessageSent(Message message,bool success,Action messageSentCallback,CancellationTokenSource cancelTokenSource)
        {
            if (success)
            {
                Debug.WriteLine("Removed message {0} from cache, cancel Sending", message);
                databaseService.DeleteMessage(message);
                cancelTokenSource.Cancel();
                messageSentCallback();
            }
        }

        private void TrySendingMessage(Message newMessage, Action messageSentCallback, CancellationTokenSource cancelTokenSource)
        {
            messageWebService.SendMessage(newMessage, (Message message,bool success) => MessageSent(message,success, messageSentCallback,cancelTokenSource));
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


using System;
using Zxm.Core.Model;
using System.Diagnostics;
//using System.Threading;
//using System.Threading.Tasks;

namespace Zxm.Core.Services
{
    //TODO: WE NEED PCL SUPPORT
//    public class CachedMessageService : MessageService
//    {
//        private readonly MessageDatabaseService _databaseService;
//
//        public CachedMessageService(MessageDatabaseService databaseService, EncryptionService encryptionService, UserSettingsService userSettingsService)
//            : base(encryptionService, userSettingsService)
//        {
//            _databaseService = databaseService;
//        }
//
//        public void SendMessage(Message newMessage, Action messageSentCallback)
//        {
//            _databaseService.Insert(newMessage);
//
//            var cancelTokenSource = new CancellationTokenSource();
//
//            Action<Task> repeatAction = null;
//
//            repeatAction = t1 =>
//            {
//                TrySendingMessage(newMessage, messageSentCallback, cancelTokenSource);
//
//                Task.Delay(10000, cancelTokenSource.Token).ContinueWith(t2 => repeatAction(t2), cancelTokenSource.Token);
//
//            };
//
//            Task.Delay(0, cancelTokenSource.Token).ContinueWith(repeatAction);
//        }
//
//        private void MessageSentCallback(Message message, bool success, Action messageSentCallback, CancellationTokenSource cancelTokenSource)
//        {
//            if (success)
//            {
//                Debug.WriteLine("Removed message {0} from cache, cancel Sending", message);
//                _databaseService.Delete(message);
//                cancelTokenSource.Cancel();
//                messageSentCallback();
//            }
//        }
//
//        private void TrySendingMessage(Message newMessage, Action messageSentCallback, CancellationTokenSource cancelTokenSource)
//        {
//            SendMessage(newMessage, (Message message, bool success) => MessageSentCallback(message, success, messageSentCallback, cancelTokenSource));
//        }
//    }
}


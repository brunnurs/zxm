using System;
using System.Diagnostics;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using Zxm.Core.Common;
using Zxm.Core.Model;
using Zxm.Core.Services;

namespace Zxm.Core.ViewModels
{
    public class ComposeMessageViewModel : MvxViewModel
    {
        private readonly MessageService _encryptedMessageService;

        public ComposeMessageViewModel(MessageService encryptedMessageService)
        {
            _encryptedMessageService = encryptedMessageService;
            SendMessageCommand = new MvxCommand(SendMessageCommandExecute);
        }

        private void SendMessageCommandExecute()
        {
            Debug.WriteLine("Start sending");
			var newMessage = new Message { Content = Message, DateSent = DateTime.Now, Sender = Config.DefaultUserName };
            Debug.WriteLine("Message created");
            _encryptedMessageService.SendMessage(newMessage, (message, successful) =>  ChangePresentation(new MvxClosePresentationHint(this)));
        }

        public string Message { get; set; }
        public ICommand SendMessageCommand { get; set; }
    }
}

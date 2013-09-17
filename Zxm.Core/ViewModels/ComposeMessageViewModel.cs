using System;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using Zxm.Core.Common;
using Zxm.Core.Model;
using Zxm.Core.Services;

namespace Zxm.Core.ViewModels
{
    public class ComposeMessageViewModel : MvxViewModel
    {
        private readonly MessageService _messageService;

        public ComposeMessageViewModel(MessageService messageService)
        {
            _messageService = messageService;
            SendMessageCommand = new MvxCommand(SendMessageCommandExecute);
        }

        private void SendMessageCommandExecute()
        {
			var newMessage = new Message { Content = Message, DateSent = DateTime.Now, Sender = Config.DefaultUserName };
            _messageService.SendMessage(newMessage, (message, successful) =>  ChangePresentation(new MvxClosePresentationHint(this)));
        }

        public string Message { get; set; }
        public ICommand SendMessageCommand { get; set; }
    }
}

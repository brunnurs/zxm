using System;
using System.Diagnostics;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using Zxm.Core.Model;
using Zxm.Core.Services;

namespace Zxm.Core.ViewModels.Tabs
{
    public class ComposeMessageViewModel : MvxViewModel
    {

        private readonly IMessageService _messageService;
        private readonly UserSettingsService _userSettingsService;

        public ComposeMessageViewModel(MessageService messageService, UserSettingsService userSettingsService)
        {
            _messageService = messageService;
            _userSettingsService = userSettingsService;
            SendMessageCommand = new MvxCommand(SendMessageCommandExecute);
        }

        private void SendMessageCommandExecute()
        {
            Debug.WriteLine("Start sending");
			var newMessage = new Message { Content = Message, DateSent = DateTime.Now, Sender = _userSettingsService.UserSettings.UserName };
            Debug.WriteLine("Message created");
            _messageService.SendMessage(newMessage, (message, successful) =>  ChangePresentation(new MvxClosePresentationHint(this)));
        }

        public string Message { get; set; }
        public ICommand SendMessageCommand { get; set; }
    }
}

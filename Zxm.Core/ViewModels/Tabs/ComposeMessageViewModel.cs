using System;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using Zxm.Core.Model;
using Zxm.Core.Services;

namespace Zxm.Core.ViewModels.Tabs
{
    public class ComposeMessageViewModel : MvxViewModel
    {

        private readonly IMessageService _messageService;
        private readonly IUserSettingsService _userSettingsService;

        public ComposeMessageViewModel(IMessageService messageService, IUserSettingsService userSettingsService)
        {
            _messageService = messageService;
            _userSettingsService = userSettingsService;
            SendMessageCommand = new MvxCommand(SendMessageCommandExecute);
        }

        private void SendMessageCommandExecute()
        {
			var newMessage = new Message { Content = Message, DateSent = DateTime.Now, Sender = _userSettingsService.UserSettings.UserName };
            _messageService.SendMessage(newMessage, () => ChangePresentation(new MvxClosePresentationHint(this)));
        }

        public string Message { get; set; }
        public ICommand SendMessageCommand { get; set; }
    }
}

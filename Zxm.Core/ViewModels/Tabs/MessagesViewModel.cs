using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using Zxm.Core.Model;
using Zxm.Core.Services;

namespace Zxm.Core.ViewModels.Tabs
{
    public class MessagesViewModel : MvxViewModel
    {
        private readonly IMessageService _messageService;

        public MessagesViewModel(IMessageService messageService)
        {
            _messageService = messageService;

            Messages = new ObservableCollection<Message>();

            LoadMessagesCommand = new MvxCommand(LoadMessagesCommandExecute);
            ComposeMessageCommand = new MvxCommand(() => ShowViewModel<ComposeMessageViewModel>());
        }

        private void LoadMessagesCommandExecute()
        {
            _messageService.RequestMessages(LoadMessagesCallback);
        }

        private void LoadMessagesCallback(List<Message> newMessages)
        {
            Messages = new ObservableCollection<Message>(newMessages);
        }

        private ObservableCollection<Message> _messages;
        public ObservableCollection<Message> Messages
        {
            get { return _messages; }
            set
            {
                _messages = value;
                RaisePropertyChanged(() => Messages);
            }
        }

        public ICommand LoadMessagesCommand { get; set; }
        public ICommand ComposeMessageCommand { get; set; }
    }
}

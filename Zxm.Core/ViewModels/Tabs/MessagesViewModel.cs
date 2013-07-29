using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using Zxm.Core.Common;
using Zxm.Core.Model;
using Zxm.Core.Services;

namespace Zxm.Core.ViewModels.Tabs
{
    public class MessagesViewModel : MvxViewModel
    {
        private readonly IMessageService _cachedMessageService;

        public MessagesViewModel(MessageService cachedMessageService)
        {
            _cachedMessageService = cachedMessageService;

            _cachedMessageService.MessageSent += MessageServiceOnMessageSent;

            Messages = new ObservableCollection<Message>();

            LoadMessagesCommand = new MvxCommand(LoadMessagesCommandExecute);
            ComposeMessageCommand = new MvxCommand(() => ShowViewModel<ComposeMessageViewModel>());
        }

        private void MessageServiceOnMessageSent(object sender, EventArgs<Message> eventArgs)
        {
            //that InvokeOnMainThread-hack is necessary because ObservableCollection is not a MvvmCross-class. See that answer:
            //http://stackoverflow.com/questions/16142629/mvvmcross-calling-web-service-from-view-model
            InvokeOnMainThread(() => Messages.Add(eventArgs.Data));
        }

        private void LoadMessagesCommandExecute()
        {
            _cachedMessageService.RequestMessages(LoadMessagesCallback);
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

        public override void Start()
        {
            base.Start();
            LoadMessagesCommandExecute();
        }
    }
}

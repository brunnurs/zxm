﻿using System;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using Zxm.Core.Model;
using Zxm.Core.Services;

namespace Zxm.Core.ViewModels.Tabs
{
    public class ComposeMessageViewModel : MvxViewModel
    {

        private readonly IMessageService _messageService;

        public ComposeMessageViewModel(IMessageService messageService)
        {
            _messageService = messageService;
            SendMessageCommand = new MvxCommand(SendMessageCommandExecute);
        }

        private void SendMessageCommandExecute()
        {
            _messageService.SendMessage(new Message { Content = Message, DateTime = DateTime.Now.ToString(), Sender = "Hansii" });
        }

        public string Message { get; set; }
        public ICommand SendMessageCommand { get; set; }
    }
}

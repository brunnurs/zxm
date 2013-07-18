using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace Zxm.Core.ViewModels.Tabs
{
    public class AddMessageViewModel : MvxViewModel
    {
        public string Message { get; set; }
        public ICommand SendMessageCommand { get; set; }
    }
}

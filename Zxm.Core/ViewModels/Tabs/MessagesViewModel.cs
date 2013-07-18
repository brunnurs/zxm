using System.Collections.ObjectModel;
using Cirrious.MvvmCross.ViewModels;
using Zxm.Core.Model;

namespace Zxm.Core.ViewModels.Tabs
{
    public class MessagesViewModel : MvxViewModel
    {
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
		//TODO: just for testing purpose. Replace it with a list
		private string message;

		public string Message 
		{
			get { return message; }
			set 
			{
				message = value;
				RaisePropertyChanged (() => Message);
			}
		}

    }
}

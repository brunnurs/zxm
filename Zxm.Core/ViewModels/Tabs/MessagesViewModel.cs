using Cirrious.MvvmCross.ViewModels;

namespace Zxm.Core.ViewModels.Tabs
{
    public class MessagesViewModel : MvxViewModel
    {
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

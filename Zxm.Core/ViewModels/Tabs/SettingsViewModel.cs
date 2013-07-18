using Cirrious.MvvmCross.ViewModels;

namespace Zxm.Core.ViewModels.Tabs
{
    public class SettingsViewModel : MvxViewModel
    {
		private string _userName;

		public string UserName 
		{
			get { return _userName; }
			set 
			{
				_userName = value;
				RaisePropertyChanged (() => UserName);
			}
		}
    }
}

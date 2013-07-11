using Cirrious.MvvmCross.ViewModels;
using Zxm.Core.ViewModels.Tabs;

namespace Zxm.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        public HomeViewModel()
        {
            SettingsViewModel = new SettingsViewModel();
            UserListViewModel = new UserListViewModel();
            MessagesViewModel = new MessagesViewModel();
        }

        public SettingsViewModel SettingsViewModel { get; set; }
        public UserListViewModel UserListViewModel { get; set; }
        public MessagesViewModel MessagesViewModel { get; set; }
    }
}

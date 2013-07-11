using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Zxm.Core.ViewModels.Tabs;

namespace Zxm.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        public HomeViewModel()
        {
            SettingsViewModel = Mvx.Resolve<SettingsViewModel>();
            UserListViewModel = Mvx.Resolve<UserListViewModel>();
            MessagesViewModel = Mvx.Resolve<MessagesViewModel>();
        }

        public SettingsViewModel SettingsViewModel { get; set; }
        public UserListViewModel UserListViewModel { get; set; }
        public MessagesViewModel MessagesViewModel { get; set; }
    }
}

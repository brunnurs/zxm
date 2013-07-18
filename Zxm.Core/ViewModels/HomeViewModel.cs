using Cirrious.MvvmCross.ViewModels;
using Zxm.Core.Services;
using Zxm.Core.ViewModels.Tabs;

namespace Zxm.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        public HomeViewModel(IUserService userService)
        {
            SettingsViewModel = new SettingsViewModel();
            UserListViewModel = new UserListViewModel(userService);
            MessagesViewModel = new MessagesViewModel();
        }

        public SettingsViewModel SettingsViewModel { get; set; }
        public UserListViewModel UserListViewModel { get; set; }
        public MessagesViewModel MessagesViewModel { get; set; }
    }
}

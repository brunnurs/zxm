using Cirrious.MvvmCross.ViewModels;
using Zxm.Core.Services;
using Zxm.Core.ViewModels.Tabs;

namespace Zxm.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        public HomeViewModel(IUserService userService, IMessageService messageService, IDatabaseService databaseService)
        {
            SettingsViewModel = new SettingsViewModel(databaseService);
            UserListViewModel = new UserListViewModel(userService);
            MessagesViewModel = new MessagesViewModel(messageService);
        }

        public SettingsViewModel SettingsViewModel { get; set; }
        public UserListViewModel UserListViewModel { get; set; }
        public MessagesViewModel MessagesViewModel { get; set; }
    }
}

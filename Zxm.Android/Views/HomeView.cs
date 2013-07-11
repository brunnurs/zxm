using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Fragging;
using Zxm.Core.ViewModels;

namespace Zxm.Android.Views
{
    [Activity]
    public class HomeView : MvxTabsFragmentActivity
    {
        public HomeView()
            : base(Resource.Layout.HomeView, Resource.Id.actualtabcontent)
        {
        }

        private HomeViewModel HomeViewModel
        {
            get { return ((HomeViewModel)ViewModel); }
        }

        protected override void AddTabs(Bundle args)
        {
            AddTab<UserListFragment>("UserList", "User List", args, HomeViewModel.UserListViewModel);
            AddTab<MessagesFragment>("Messages", "Messages", args, HomeViewModel.MessagesViewModel);
            AddTab<SettingsFragment>("Settings", "Settings", args, HomeViewModel.SettingsViewModel);
        }
    }
}
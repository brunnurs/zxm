using Android.App;
using Android.OS;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Droid.Fragging;
using Cirrious.MvvmCross.ViewModels;
using Zxm.Core.ViewModels.Tabs;

namespace Zxm.Android.Views
{
    [Activity]
    public class HomeView : MvxTabsFragmentActivity
    {
        public HomeView()
            : base(Resource.Layout.HomeView, Resource.Id.actualtabcontent)
        {
        }

        protected override void AddTabs(Bundle args)
        {
            AddTab<UserListFragment, UserListViewModel>("UserList", "User List", args);
            AddTab<MessagesFragment, MessagesViewModel>("Messages", "Messages", args);
            AddTab<SettingsFragment, SettingsViewModel>("Settings", "Settings", args);
        }

        private void AddTab<TFragment, TViewModel>(string specName, string tabName, Bundle args) where TViewModel : IMvxViewModel
        {
            var loaderService = Mvx.Resolve<IMvxViewModelLoader>();
            var vm = (TViewModel)loaderService.LoadViewModel(new MvxViewModelRequest(typeof(TViewModel), null, null, null), null); 
            AddTab<TFragment>(specName, tabName, args, vm);
        }
    }
}
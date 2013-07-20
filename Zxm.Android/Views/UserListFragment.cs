using Android.OS;
using Android.Views;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Zxm.Android.Views.ActionBarTabs;
using Zxm.Core.ViewModels.Tabs;

namespace Zxm.Android.Views
{
    public class UserListFragment : MvxFragment, IOptionsMenuHandler
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.UserListView, null);
        }

        public void HandleOptionsMenuCall(int optionsMenuId)
        {
            if (optionsMenuId == Resource.Id.menuUserRefresh)
            {
                ((UserListViewModel)ViewModel).LoadUsersCommand.Execute(null);
            }
        }
    }
}
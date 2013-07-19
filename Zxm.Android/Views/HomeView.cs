using System;
using Android.App;
using Android.Support.V4.View;
using Android.Views;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Core;
using Cirrious.MvvmCross.Droid.Fragging;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Cirrious.MvvmCross.ViewModels;
using Zxm.Android.Views.ActionBarTabs;
using Zxm.Core.ViewModels.Tabs;
using Fragment = Android.Support.V4.App.Fragment;

namespace Zxm.Android.Views
{
    //TODO: Schöb: Check supportframework usage
    [Activity]
    public class HomeView : MvxFragmentActivity, ActionBar.ITabListener
    {
        private ViewPager _viewPager;

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();

            SetContentView(Resource.Layout.HomeView);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            _viewPager = FindViewById<ViewPager>(Resource.Id.pager);
            _viewPager.PageSelected += (sender, args) => ActionBar.SetSelectedNavigationItem(args.P0);

            var adapter = new TabFragmentAdapter(SupportFragmentManager);
            AddTab<UserListFragment, UserListViewModel>("UserList", adapter);
            AddTab<MessagesFragment, MessagesViewModel>("Messages", adapter);
            AddTab<SettingsFragment, SettingsViewModel>("Settings", adapter);
            _viewPager.Adapter = adapter;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            switch (_viewPager.CurrentItem)
            {
                case 0:
                    MenuInflater.Inflate(Resource.Menu.menuUser, menu);
                    break;
                case 1:
                    MenuInflater.Inflate(Resource.Menu.menuMessages, menu);
                    break;
            }
            return true;
        }

        //TODO: This is ugly.. i do not want to directly access the viewmodels of each fragment...
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var currentFragment =
                (MvxFragment) ((TabFragmentAdapter) _viewPager.Adapter).GetItem(_viewPager.CurrentItem);
                    
            switch (item.ItemId)
            {
                case Resource.Id.menuMessageAdd:
                    var messageViewModel = (MessagesViewModel)currentFragment.DataContext;
                    messageViewModel.ComposeMessageCommand.Execute(null);
                    break;
                case Resource.Id.menuMessageRefresh:
                    var messageViewModelRefresh = (MessagesViewModel)currentFragment.DataContext;
                    messageViewModelRefresh.LoadMessagesCommand.Execute(null);
                    break;
                case Resource.Id.menuUserRefresh:
                    var userViewModel = (UserListViewModel)currentFragment.DataContext;
                    userViewModel.LoadUsersCommand.Execute(null);
                    break;

            }
            return true;
        }

        private void AddTab<TFragment, TViewModel>(string specName, TabFragmentAdapter adapter)
            where TViewModel : IMvxViewModel
            where TFragment : Fragment
        {
            var fragment = (TFragment)Fragment.Instantiate(this, FragmentJavaName(typeof(TFragment)));
            FixupDataContext<TFragment, TViewModel>(fragment);
            adapter.AddFragment(fragment, specName);

            ActionBar.Tab tab = ActionBar.NewTab()
                                         .SetText(specName)
                                         .SetTabListener(this);
            ActionBar.AddTab(tab);
        }

        private static void FixupDataContext<TFragment, TViewModel>(TFragment fragment)
        {
            var mvxDataConsumer = fragment as IMvxDataConsumer;
            if (mvxDataConsumer == null)
            {
                return;
            }

            var loaderService = Mvx.Resolve<IMvxViewModelLoader>();
            var vm = (TViewModel)loaderService.LoadViewModel(new MvxViewModelRequest(typeof(TViewModel), null, null, null), null);
            mvxDataConsumer.DataContext = vm;
        }

        private static string FragmentJavaName(Type fragmentType)
        {
            string str = fragmentType.Namespace ?? "";
            if (str.Length > 0)
            {
                str = str.ToLowerInvariant() + ".";
            }
            return str + fragmentType.Name;
        }

        public void OnTabReselected(ActionBar.Tab tab, FragmentTransaction ft)
        {
        }

        public void OnTabSelected(ActionBar.Tab tab, FragmentTransaction ft)
        {
            _viewPager.SetCurrentItem(tab.Position, true);
            InvalidateOptionsMenu();
        }

        public void OnTabUnselected(ActionBar.Tab tab, FragmentTransaction ft)
        {
        }
    }
}
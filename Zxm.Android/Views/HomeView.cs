using System;
using Android.App;
using Android.Support.V4.View;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Core;
using Cirrious.MvvmCross.Droid.Fragging;
using Cirrious.MvvmCross.ViewModels;
using Zxm.Android.Views.ActionBarTabs;
using Zxm.Core.ViewModels.Tabs;
using Fragment = Android.Support.V4.App.Fragment;

namespace Zxm.Android.Views
{
    //TODO: Schöb: Check supportframework usage
    [Activity]
    public class HomeView : MvxFragmentActivity
    {
        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();

            SetContentView(Resource.Layout.HomeView);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            var viewPager = FindViewById<ViewPager>(Resource.Id.pager);
            viewPager.PageSelected += (sender, args) => ActionBar.SetSelectedNavigationItem(args.P0);

            var adapter = new TabFragmentAdapter(SupportFragmentManager);
            AddTab<UserListFragment, UserListViewModel>("UserList", adapter, viewPager);
            AddTab<MessagesFragment, MessagesViewModel>("Messages", adapter, viewPager);
            AddTab<SettingsFragment, SettingsViewModel>("Settings", adapter, viewPager);
            viewPager.Adapter = adapter;
        }

        private void AddTab<TFragment, TViewModel>(string specName, TabFragmentAdapter adapter, ViewPager viewPager)
            where TViewModel : IMvxViewModel
            where TFragment : Fragment
        {
            var fragment = (TFragment)Fragment.Instantiate(this, FragmentJavaName(typeof(TFragment)));
            FixupDataContext<TFragment, TViewModel>(fragment);
            adapter.AddFragment(fragment, specName);

            var tabListener = new ActionBarTabListener(viewPager);
            ActionBar.Tab tab = ActionBar.NewTab()
                                         .SetText(specName)
                                         .SetTabListener(tabListener);
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
    }
}
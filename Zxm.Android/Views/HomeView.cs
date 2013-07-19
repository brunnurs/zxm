using System;
using Android.App;
using Android.Support.V4.App;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Core;
using Cirrious.MvvmCross.Droid.Fragging;
using Cirrious.MvvmCross.ViewModels;
using Zxm.Core.ViewModels.Tabs;
using Fragment = Android.Support.V4.App.Fragment;
using FragmentTransaction = Android.Support.V4.App.FragmentTransaction;

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

            AddTab<UserListFragment, UserListViewModel>("UserList");
            AddTab<MessagesFragment, MessagesViewModel>("Messages");
            AddTab<SettingsFragment, SettingsViewModel>("Settings");

        }

        private void AddTab<TFragment, TViewModel>(string specName)
            where TViewModel : IMvxViewModel
            where TFragment : Fragment
        {

            var fragment = (TFragment)Fragment.Instantiate(this, FragmentJavaName(typeof(TFragment)));
            FixupDataContext<TFragment, TViewModel>(fragment);

            ActionBar.Tab tab = ActionBar.NewTab();
            tab.SetText(specName);
            var tabListener = new ActionBarTabListener<TFragment>(fragment, specName, this);
            tab.SetTabListener(tabListener);
            ActionBar.AddTab(tab);
        }

        private void FixupDataContext<TFragment, TViewModel>(TFragment fragment)
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

        private string FragmentJavaName(Type fragmentType)
        {
            string str = fragmentType.Namespace ?? "";
            if (str.Length > 0)
            {
                str = str.ToLowerInvariant() + ".";
            }
            return str + fragmentType.Name;
        }


    }

    public class ActionBarTabListener<TFragment> : Java.Lang.Object, ActionBar.ITabListener where TFragment : Fragment
    {
        private readonly TFragment _fragment;
        private readonly string _tag;
        private readonly FragmentActivity _activity;

        public ActionBarTabListener(TFragment fragment, string tag, FragmentActivity activity)
        {
            _fragment = fragment;
            _tag = tag;
            _activity = activity;
        }

        public void OnTabReselected(ActionBar.Tab tab, global::Android.App.FragmentTransaction ft)
        {
        }

        public void OnTabSelected(ActionBar.Tab tab, global::Android.App.FragmentTransaction ft)
        {
            if (!_fragment.IsAdded && !_fragment.IsDetached)
            {
                FragmentTransaction fragmentTransaction = _activity.SupportFragmentManager.BeginTransaction();
                fragmentTransaction.Add(Resource.Id.homecontent, _fragment, _tag);
                fragmentTransaction.Commit();
            }
            else
            {
                // If it exists, simply attach it in order to show it
                FragmentTransaction fragmentTransaction = _activity.SupportFragmentManager.BeginTransaction();
                fragmentTransaction.Attach(_fragment);
                fragmentTransaction.Commit();
            }
        }

        public void OnTabUnselected(ActionBar.Tab tab, global::Android.App.FragmentTransaction ft)
        {
            if (!_fragment.IsDetached)
            {
                FragmentTransaction fragmentTransaction = _activity.SupportFragmentManager.BeginTransaction();
                fragmentTransaction.Detach(_fragment);
                fragmentTransaction.Commit();
            }
        }

    }
}
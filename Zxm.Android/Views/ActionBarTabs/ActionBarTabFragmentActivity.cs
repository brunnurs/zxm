using System.Collections.Generic;
using Android.App;
using Android.Support.V4.View;
using Android.Views;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Droid.Fragging;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;

namespace Zxm.Android.Views.ActionBarTabs
{
    public abstract class ActionBarTabFragmentActivity : MvxFragmentActivity, ActionBar.ITabListener
    {
        private ViewPager _viewPager;
        private List<TabFragmentDescription> _tabDescriptions;

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();

            CreateAndInitializeViewPager();

            _tabDescriptions = GetTabDescriptions();

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            var adapter = new TabFragmentAdapter(SupportFragmentManager);
            foreach (var tabDescription in _tabDescriptions)
            {
                CreateAndAddTab(tabDescription, adapter);
            }

            _viewPager.Adapter = adapter;

            SetContentView(_viewPager);
        }

        private void CreateAndInitializeViewPager()
        {
            _viewPager = new ViewPager(this);
            _viewPager.Id = 0x02121234;
            _viewPager.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.FillParent,
                                                                     ViewGroup.LayoutParams.FillParent);
            _viewPager.PageSelected += (sender, args) => ActionBar.SetSelectedNavigationItem(args.Position);
        }

        private void CreateAndAddTab(TabFragmentDescription tabFragmentDescription, TabFragmentAdapter adapter)
        {
            var fragment = TabFragmentFactory.CreateFragment(this, tabFragmentDescription);
            adapter.AddFragment(fragment);

            ActionBar.Tab tab = ActionBar.NewTab()
                                         .SetText(tabFragmentDescription.TitleResourceId)
                                         .SetTabListener(this);
            ActionBar.AddTab(tab);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            int? menuResourceId = _tabDescriptions[_viewPager.CurrentItem].MenueResourceId;
            if (menuResourceId.HasValue)
            {
                MenuInflater.Inflate(menuResourceId.Value, menu);   
            }
           
            return true;
        }

        protected abstract List<TabFragmentDescription> GetTabDescriptions();

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var currentFragment = (MvxFragment)((TabFragmentAdapter)_viewPager.Adapter).GetItem(_viewPager.CurrentItem);

            var handlingFragment = currentFragment as IOptionsMenuHandler;
            if (handlingFragment != null)
            {
                handlingFragment.HandleOptionsMenuCall(item.ItemId);
            }
            else
            {
                Mvx.TaggedWarning("ActionBarTabFragmentActivity", "Try to execute option menu on a fragment which is not aware off. Each fragment should implement the IOptionsMenuHandler");
            }

            return true;
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
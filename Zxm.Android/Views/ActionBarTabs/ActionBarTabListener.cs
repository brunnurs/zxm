using Android.App;
using Android.Support.V4.View;

namespace Zxm.Android.Views.ActionBarTabs
{
    public class ActionBarTabListener : Java.Lang.Object, ActionBar.ITabListener
    {
        private readonly ViewPager _viewPager;

        public ActionBarTabListener(ViewPager viewPager)
        {
            _viewPager = viewPager;
        }

        public void OnTabSelected(ActionBar.Tab tab, FragmentTransaction ft)
        {
            _viewPager.SetCurrentItem(tab.Position, true);
        }

        public void OnTabUnselected(ActionBar.Tab tab, FragmentTransaction ft)
        {
        }

        public void OnTabReselected(ActionBar.Tab tab, FragmentTransaction ft)
        {
        }
    }
}
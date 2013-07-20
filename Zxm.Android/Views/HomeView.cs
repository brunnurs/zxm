using System.Collections.Generic;
using Android.App;
using Zxm.Android.Views.ActionBarTabs;
using Zxm.Core.ViewModels.Tabs;

namespace Zxm.Android.Views
{
    [Activity(Label = "")]
    public class HomeView : ActionBarTabFragmentActivity
    {
        protected override List<TabFragmentDescription> GetTabDescriptions()
        {
            var list = new List<TabFragmentDescription>
                {
                    new TabFragmentDescription( "UserListView",Resource.String.TabUsers, typeof(UserListFragment), typeof(UserListViewModel)) {MenueResourceId = Resource.Menu.menuUser},
                    new TabFragmentDescription( "MessagesView",Resource.String.TabMessages, typeof(MessagesFragment), typeof(MessagesViewModel)) {MenueResourceId = Resource.Menu.menuMessages},
                    new TabFragmentDescription( "SettingsView",Resource.String.TabSettings, typeof(SettingsFragment), typeof(SettingsViewModel)) 
                };
            return list;
        }
    }
}
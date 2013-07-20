using Android.OS;
using Android.Views;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Zxm.Android.Views.ActionBarTabs;
using Zxm.Core.ViewModels.Tabs;

namespace Zxm.Android.Views
{
    public class MessagesFragment : MvxFragment, IOptionsMenuHandler
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.MessagesView, null);
        }

        public void HandleOptionsMenuCall(int optionsMenuId)
        {
            switch (optionsMenuId)
            {
                case Resource.Id.menuMessageAdd:
                    ((MessagesViewModel)ViewModel).ComposeMessageCommand.Execute(null);
                    break;
                case Resource.Id.menuMessageRefresh:
                    ((MessagesViewModel)ViewModel).LoadMessagesCommand.Execute(null);
                    break;
            }
        }
    }
}
using Android.App;
using Android.Views;
using Cirrious.MvvmCross.Droid.Views;
using Zxm.Core.ViewModels.Tabs;

namespace Zxm.Android.Views
{
    [Activity]
    public class ComposeMessageView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.ComposeMessageView);

            ActionBar.SetHomeButtonEnabled(true);

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menuComposeMessage, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.menuMessageSend)
            {
                ((ComposeMessageViewModel)ViewModel).SendMessageCommand.Execute(null);
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}
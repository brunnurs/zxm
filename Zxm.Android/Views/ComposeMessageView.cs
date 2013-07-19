using Android.App;
using Android.Views;
using Cirrious.MvvmCross.Droid.Views;
using Zxm.Core.ViewModels.Tabs;

namespace Zxm.Android.Views
{
    [Activity(Label = "")]
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
            switch (item.ItemId)
            {
                case global::Android.Resource.Id.Home:
                    Finish();
                    return true;
                case Resource.Id.menuMessageSend:
                    ((ComposeMessageViewModel)ViewModel).SendMessageCommand.Execute(null);
                return true;
            }

            if (item.ItemId == Resource.Id.menuMessageSend)
            {
                
            }



            return base.OnOptionsItemSelected(item);
        }
    }
}
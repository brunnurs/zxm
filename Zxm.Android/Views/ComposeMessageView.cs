using Android.App;
using Cirrious.MvvmCross.Droid.Views;

namespace Zxm.Android.Views
{
    [Activity]
    public class ComposeMessageView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.ComposeMessageView);
        }
    }
}
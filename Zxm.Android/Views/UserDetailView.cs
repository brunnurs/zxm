using Android.App;
using Cirrious.MvvmCross.Droid.Views;

namespace Zxm.Android.Views
{
    [Activity(Label = "User Details")]
    public class UserDetailView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.UserDetailsView);

            ActionBar.SetDisplayHomeAsUpEnabled(true);
        }
    }
}
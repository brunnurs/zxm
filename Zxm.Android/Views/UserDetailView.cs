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

        public override bool OnOptionsItemSelected(global::Android.Views.IMenuItem item)
        {
            if (item.ItemId == global::Android.Resource.Id.Home)
            {
                Finish();
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}
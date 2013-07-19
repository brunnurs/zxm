using Android.App;
using Cirrious.MvvmCross.Droid.Views;

namespace Zxm.Android
{
    [Activity(
		Label = "ZXM"
		, MainLauncher = true
		, Icon = "@drawable/icon"
		, Theme = "@style/Theme.Splash"
		, NoHistory = true)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Zxm.Android.Views
{
    // Fix focus problem: https://code.google.com/p/android/issues/detail?id=2516
    public class TabPatchView : View
    {
        public TabPatchView(Context context)
            : base(context)
        {
        }

        public TabPatchView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
        }

        public TabPatchView(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
        }

        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();

            var tabHost = (TabHost)RootView.FindViewById(16908306);
            tabHost.ViewTreeObserver.RemoveOnTouchModeChangeListener(tabHost);
        }
    }
}
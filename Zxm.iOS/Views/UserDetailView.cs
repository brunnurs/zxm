using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using Zxm.Core.ViewModels;

namespace Zxm.iOS
{
    public partial class UserDetailView : MvxViewController
    {
        public UserDetailView() : base ("UserDetailView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			
            var webView = new UIWebView(new RectangleF (0, 0, 320, 600));
            this.Add(webView);

            var myViewModel = (UserDetailViewModel)ViewModel;

            this.NavigationItem.Title = myViewModel.UserName;

            webView.LoadRequest(new NSUrlRequest(new NSUrl(myViewModel.DetailUrl)));

        }
    }
}


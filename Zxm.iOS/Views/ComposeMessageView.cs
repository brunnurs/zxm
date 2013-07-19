using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using Zxm.Core.ViewModels.Tabs;

namespace Zxm.iOS
{
	public partial class ComposeMessageView : MvxViewController
	{
		public ComposeMessageView () : base ("ComposeMessageView", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			var sendButton = new UIBarButtonItem();
			sendButton.Title = "send";

			NavigationItem.RightBarButtonItem = sendButton;
			NavigationItem.Title = "New message";

			var set = this.CreateBindingSet<ComposeMessageView,ComposeMessageViewModel> ();
			set.Bind (sendButton).To (vm => vm.SendMessageCommand);
			set.Apply ();

		}
	}
}


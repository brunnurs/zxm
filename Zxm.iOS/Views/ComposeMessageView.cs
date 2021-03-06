using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using Zxm.Core.ViewModels;
using Zxm.Core.ViewModels.Tabs;

namespace Zxm.iOS
{
	public partial class ComposeMessageView : MvxViewController
	{
        UIBarButtonItem sendButton;

        UITextView messageContentTextView;

		public ComposeMessageView () : base ("ComposeMessageView", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
            CreateUI();

			var set = this.CreateBindingSet<ComposeMessageView,ComposeMessageViewModel> ();
			set.Bind (sendButton).To (vm => vm.SendMessageCommand);
            set.Bind(messageContentTextView).To(vm => vm.Message);
			set.Apply ();

		}

        void CreateUI()
        {
            sendButton = new UIBarButtonItem();
            sendButton.Title = "send";
            NavigationItem.RightBarButtonItem = sendButton;
            NavigationItem.Title = "New message";
            messageContentTextView = new UITextView(new RectangleF(0, 0, 320, 342));
            Add(messageContentTextView);
        }
	}
}


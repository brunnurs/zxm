using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using Zxm.Core.ViewModels.Tabs;

namespace Zxm.iOS
{
	public partial class MessagesView : MvxViewController
	{
		public MessagesView () : base ("MessagesView", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var set = this.CreateBindingSet<MessagesView,MessagesViewModel> ();
			set.Bind (messageEdit).To (vm => vm.Message);
			set.Bind (messageLabel).To (vm => vm.Message);
		
			set.Apply ();
		}
	}
}


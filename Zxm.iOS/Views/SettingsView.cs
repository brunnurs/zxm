using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using Zxm.Core.ViewModels.Tabs;

namespace Zxm.iOS
{
	public partial class SettingsView : MvxViewController
	{
		public SettingsView () : base ("SettingsView", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var set = this.CreateBindingSet<SettingsView,SettingsViewModel> ();
			set.Bind (usernameEdit).To (vm => vm.UserName);
			set.Bind (usernameLabel).To (vm => vm.UserName);

			set.Apply ();
		}
	}
}


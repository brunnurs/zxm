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
			set.Bind (passwordEdit).To (vm => vm.Password);

			set.Apply ();
		}


        /// <summary>
        /// Removes Keyboard when clicking somewhere
        /// </summary>
        /// <param name="touches">Touches.</param>
        /// <param name="evt">Evt.</param>
        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);
            this.View.EndEditing(true);
        }
	}
}


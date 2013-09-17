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
        UITextField passwordEdit;
        UITextField usernameEdit;

		public SettingsView () : base ("SettingsView", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

            CreateUI();


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

        void CreateUI()
        {
            usernameEdit = new UITextField(new RectangleF(20, 20, 280, 30));
            usernameEdit.Placeholder = "username";
            usernameEdit.BorderStyle = UITextBorderStyle.RoundedRect;
            Add(usernameEdit);
            passwordEdit = new UITextField(new RectangleF(20, 70, 280, 30));
            passwordEdit.Placeholder = "crypto password";
            passwordEdit.BorderStyle = UITextBorderStyle.RoundedRect;
            Add(passwordEdit);
        }
	}
}


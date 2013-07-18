using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using Zxm.Core.Model;

namespace Zxm.iOS
{
	public partial class UserCell : MvxTableViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("UserCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("UserCell");

		public UserCell (IntPtr handle) : base (handle)
		{
			var imageLoader = new MvxImageViewLoader (() => UserImageView);

			this.DelayBind(() => {
				var set = this.CreateBindingSet<UserCell, User> ();
				set.Bind (UserTitleLabel).To (item => item.Title);
				set.Bind (UserFirstnameLabel).To (item => item.FirstName);
				set.Bind (UserLastnameLabel).To (item => item.LastName);
				set.Bind(imageLoader.ImageUrl).To(User => User.ImageUri);
				set.Apply();
			});

		}

		public static UserCell Create ()
		{
			return (UserCell)Nib.Instantiate (null, null) [0];
		}
	}
}


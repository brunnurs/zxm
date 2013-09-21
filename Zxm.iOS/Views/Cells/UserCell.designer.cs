// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace Zxm.iOS
{
	[Register ("UserCell")]
	partial class UserCell
	{
		[Outlet]
		MonoTouch.UIKit.UILabel UserCompanyLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel UserFirstnameLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView UserImageView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel UserLastnameLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel UserTitleLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (UserFirstnameLabel != null) {
				UserFirstnameLabel.Dispose ();
				UserFirstnameLabel = null;
			}

			if (UserImageView != null) {
				UserImageView.Dispose ();
				UserImageView = null;
			}

			if (UserLastnameLabel != null) {
				UserLastnameLabel.Dispose ();
				UserLastnameLabel = null;
			}

			if (UserTitleLabel != null) {
				UserTitleLabel.Dispose ();
				UserTitleLabel = null;
			}

			if (UserCompanyLabel != null) {
				UserCompanyLabel.Dispose ();
				UserCompanyLabel = null;
			}
		}
	}
}

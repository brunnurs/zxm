// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Zxm.iOS
{
	[Register ("SettingsView")]
	partial class SettingsView
	{
		[Outlet]
		MonoTouch.UIKit.UITextField usernameEdit { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel usernameLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (usernameEdit != null) {
				usernameEdit.Dispose ();
				usernameEdit = null;
			}

			if (usernameLabel != null) {
				usernameLabel.Dispose ();
				usernameLabel = null;
			}
		}
	}
}
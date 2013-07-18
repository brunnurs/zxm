// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Zxm.iOS
{
	[Register ("MessagesView")]
	partial class MessagesView
	{
		[Outlet]
		MonoTouch.UIKit.UITextField messageEdit { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel messageLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (messageEdit != null) {
				messageEdit.Dispose ();
				messageEdit = null;
			}

			if (messageLabel != null) {
				messageLabel.Dispose ();
				messageLabel = null;
			}
		}
	}
}

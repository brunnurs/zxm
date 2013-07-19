// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Zxm.iOS
{
	[Register ("MessageCell")]
	partial class MessageCell
	{
		[Outlet]
		MonoTouch.UIKit.UITextView MessageContentLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel MessageSenderLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel MessageTimestampLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (MessageTimestampLabel != null) {
				MessageTimestampLabel.Dispose ();
				MessageTimestampLabel = null;
			}

			if (MessageSenderLabel != null) {
				MessageSenderLabel.Dispose ();
				MessageSenderLabel = null;
			}

			if (MessageContentLabel != null) {
				MessageContentLabel.Dispose ();
				MessageContentLabel = null;
			}
		}
	}
}

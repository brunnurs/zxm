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
		MonoTouch.UIKit.UITextView MessageBody { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel MessageSender { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel MessageTimestamp { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (MessageSender != null) {
				MessageSender.Dispose ();
				MessageSender = null;
			}

			if (MessageBody != null) {
				MessageBody.Dispose ();
				MessageBody = null;
			}

			if (MessageTimestamp != null) {
				MessageTimestamp.Dispose ();
				MessageTimestamp = null;
			}
		}
	}
}
